using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubeDownloader.Core.Utils;

// Shared token bucket: all throttled streams draw from the same budget, so the limit applies globally
internal static class DownloadRateLimiter
{
    private static readonly Lock SyncRoot = new();
    private static readonly Stopwatch Clock = Stopwatch.StartNew();

    private static double _availableBytes;
    private static TimeSpan _lastRefill = Clock.Elapsed;

    public static int GetChunkSize(int requestedSize)
    {
        var limit = Http.MaxBytesPerSecond;
        if (limit <= 0)
            return requestedSize;

        // Small chunks keep the flow smooth instead of bursty
        return (int)Math.Min(requestedSize, Math.Max(1024, limit / 10));
    }

    public static async ValueTask ConsumeAsync(int byteCount, CancellationToken cancellationToken)
    {
        var limit = Http.MaxBytesPerSecond;
        if (limit <= 0 || byteCount <= 0)
            return;

        TimeSpan delay;
        lock (SyncRoot)
        {
            var now = Clock.Elapsed;
            _availableBytes = Math.Min(
                limit,
                _availableBytes + (now - _lastRefill).TotalSeconds * limit
            );
            _lastRefill = now;

            // Going into debt is allowed; the caller then waits until it is paid back
            _availableBytes -= byteCount;
            delay =
                _availableBytes < 0
                    ? TimeSpan.FromSeconds(-_availableBytes / limit)
                    : TimeSpan.Zero;
        }

        if (delay > TimeSpan.Zero)
            await Task.Delay(delay, cancellationToken);
    }
}

internal class ThrottledStream(Stream inner) : Stream
{
    public override bool CanRead => inner.CanRead;

    public override bool CanSeek => false;

    public override bool CanWrite => false;

    public override long Length => inner.Length;

    public override long Position
    {
        get => inner.Position;
        set => throw new NotSupportedException();
    }

    public override int Read(byte[] buffer, int offset, int count) =>
        ReadAsync(buffer.AsMemory(offset, count)).AsTask().GetAwaiter().GetResult();

    public override Task<int> ReadAsync(
        byte[] buffer,
        int offset,
        int count,
        CancellationToken cancellationToken
    ) => ReadAsync(buffer.AsMemory(offset, count), cancellationToken).AsTask();

    public override async ValueTask<int> ReadAsync(
        Memory<byte> buffer,
        CancellationToken cancellationToken = default
    )
    {
        var chunkSize = DownloadRateLimiter.GetChunkSize(buffer.Length);
        var bytesRead = await inner.ReadAsync(buffer[..chunkSize], cancellationToken);

        await DownloadRateLimiter.ConsumeAsync(bytesRead, cancellationToken);

        return bytesRead;
    }

    public override void Flush() { }

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count) =>
        throw new NotSupportedException();

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            inner.Dispose();

        base.Dispose(disposing);
    }
}

public class ThrottlingHandler(HttpMessageHandler innerHandler) : DelegatingHandler(innerHandler)
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        var response = await base.SendAsync(request, cancellationToken);

        var originalContent = response.Content;
        var throttledContent = new StreamContent(
            new ThrottledStream(await originalContent.ReadAsStreamAsync(cancellationToken))
        );

        foreach (var header in originalContent.Headers)
            throttledContent.Headers.TryAddWithoutValidation(header.Key, header.Value);

        response.Content = throttledContent;

        return response;
    }
}
