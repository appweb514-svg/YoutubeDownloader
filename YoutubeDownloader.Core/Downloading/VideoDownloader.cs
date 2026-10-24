using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gress;
using YoutubeDownloader.Core.Utils;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.ClosedCaptions;

namespace YoutubeDownloader.Core.Downloading;

public class VideoDownloader(IReadOnlyList<Cookie>? initialCookies = null) : IDisposable
{
    private readonly YoutubeClient _youtube = new(
        Http.Client,
        ConsentCookie.WithFreshConsent(initialCookies)
    );

    public async Task<IReadOnlyList<VideoDownloadOption>> GetDownloadOptionsAsync(
        VideoId videoId,
        bool includeLanguageSpecificAudioStreams = true,
        CancellationToken cancellationToken = default
    )
    {
        // YouTube sometimes rejects stream URLs with 403 for a while; a new manifest often works
        for (var attempt = 1; ; attempt++)
        {
            try
            {
                var manifest = await _youtube.Videos.Streams.GetManifestAsync(
                    videoId,
                    cancellationToken
                );

                return VideoDownloadOption.ResolveAll(
                    manifest,
                    includeLanguageSpecificAudioStreams
                );
            }
            catch (HttpRequestException ex)
                when (ex.StatusCode == HttpStatusCode.Forbidden && attempt < 3)
            {
                await Task.Delay(TimeSpan.FromSeconds(2 * attempt), cancellationToken);
            }
        }
    }

    public async Task<VideoDownloadOption> GetBestDownloadOptionAsync(
        VideoId videoId,
        VideoDownloadPreference preference,
        bool includeLanguageSpecificAudioStreams = true,
        CancellationToken cancellationToken = default
    )
    {
        var options = await GetDownloadOptionsAsync(
            videoId,
            includeLanguageSpecificAudioStreams,
            cancellationToken
        );

        return preference.TryGetBestOption(options)
            ?? throw new InvalidOperationException("No suitable download option found.");
    }

    public async Task DownloadVideoAsync(
        string filePath,
        IVideo video,
        VideoDownloadOption downloadOption,
        bool includeSubtitles = true,
        string? preferredSubtitleLanguage = null,
        string? ffmpegPath = null,
        IProgress<Percentage>? progress = null,
        CancellationToken cancellationToken = default
    )
    {
        // Include subtitles in the output container
        var trackInfos = new List<ClosedCaptionTrackInfo>();
        if (includeSubtitles && !downloadOption.Container.IsAudioOnly)
        {
            var manifest = await _youtube.Videos.ClosedCaptions.GetManifestAsync(
                video.Id,
                cancellationToken
            );

            trackInfos.AddRange(FilterTracksByLanguage(manifest.Tracks, preferredSubtitleLanguage));
        }

        var dirPath = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrWhiteSpace(dirPath))
            Directory.CreateDirectory(dirPath);

        await _youtube.Videos.DownloadAsync(
            downloadOption.StreamInfos,
            trackInfos,
            new ConversionRequestBuilder(filePath)
                .SetFFmpegPath(ffmpegPath ?? FFmpeg.TryGetCliFilePath() ?? "ffmpeg")
                .SetContainer(downloadOption.Container)
                .SetPreset(ConversionPreset.Medium)
                .Build(),
            progress?.ToDoubleBased(),
            cancellationToken
        );
    }

    private static bool IsLanguageMatch(string code, string languageCode) =>
        code.StartsWith(languageCode, StringComparison.OrdinalIgnoreCase)
        || languageCode.StartsWith(code + "-", StringComparison.OrdinalIgnoreCase);

    // Keeps the tracks in the preferred language ("fr" matches "fr-FR"), or all of them if none match
    public static IReadOnlyList<ClosedCaptionTrackInfo> FilterTracksByLanguage(
        IReadOnlyList<ClosedCaptionTrackInfo> trackInfos,
        string? languageCode
    )
    {
        if (string.IsNullOrWhiteSpace(languageCode))
            return trackInfos;

        var matchingTrackInfos = trackInfos
            .Where(t => IsLanguageMatch(t.Language.Code, languageCode.Trim()))
            .ToArray();

        return matchingTrackInfos.Any() ? matchingTrackInfos : trackInfos;
    }

    public async Task<IReadOnlyList<string>> DownloadSubtitleFilesAsync(
        string filePath,
        IVideo video,
        string? languageCode = null,
        TimeSpan? clipStart = null,
        TimeSpan? clipEnd = null,
        CancellationToken cancellationToken = default
    )
    {
        var manifest = await _youtube.Videos.ClosedCaptions.GetManifestAsync(
            video.Id,
            cancellationToken
        );

        var dirPath = Path.GetDirectoryName(filePath) ?? "";
        var baseFileName = Path.GetFileNameWithoutExtension(filePath);

        var subtitleFilePaths = new List<string>();
        foreach (var trackInfo in FilterTracksByLanguage(manifest.Tracks, languageCode))
        {
            // Players pick up '<video>.<lang>.srt' automatically
            var suffix = trackInfo.Language.Code + (trackInfo.IsAutoGenerated ? ".auto" : "");
            var subtitleFilePath = Path.Combine(dirPath, $"{baseFileName}.{suffix}.srt");
            if (subtitleFilePaths.Contains(subtitleFilePath))
                continue;

            if (clipStart is null && clipEnd is null)
            {
                await _youtube.Videos.ClosedCaptions.DownloadAsync(
                    trackInfo,
                    subtitleFilePath,
                    null,
                    cancellationToken
                );
            }
            else
            {
                // Clip: keep only the captions shown within it, with times relative to its start
                var track = await _youtube.Videos.ClosedCaptions.GetAsync(
                    trackInfo,
                    cancellationToken
                );

                await File.WriteAllTextAsync(
                    subtitleFilePath,
                    SubRip.Format(track.Captions, clipStart, clipEnd),
                    cancellationToken
                );
            }

            subtitleFilePaths.Add(subtitleFilePath);
        }

        return subtitleFilePaths;
    }

    public void Dispose() => _youtube.Dispose();
}
