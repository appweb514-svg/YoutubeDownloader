using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace YoutubeDownloader.Core.Utils;

// YoutubeExplode v6.6.2 sends a hardcoded SOCS consent cookie dated 2025-10-03.
// Once it passed its 13-month validity, YouTube started redirecting every watch page
// to consent.youtube.com, which surfaces as "Video watch page is broken".
// User-supplied cookies are added after the built-in one and replace it, so we supply
// a cookie generated with the current date until the upstream fix is released.
// https://github.com/Tyrrrz/YoutubeDownloader/issues/909
// https://github.com/Tyrrrz/YoutubeExplode/pull/975
public static class ConsentCookie
{
    // Protobuf-encoded consent record: { 1: 2, 2: { 1: 3, 2: "813836352", 3: "en", 4: 1 }, 3: { 1: <timestamp> } }
    public static string GenerateValue(DateTimeOffset consentDate)
    {
        static void WriteVarint(List<byte> buffer, ulong value)
        {
            while (value >= 0x80)
            {
                buffer.Add((byte)(value | 0x80));
                value >>= 7;
            }

            buffer.Add((byte)value);
        }

        // Round down to the start of the day, like the cookies issued by YouTube
        var timestamp = (ulong)(consentDate.ToUnixTimeSeconds() / 86400 * 86400);

        var timestampMessage = new List<byte> { 0x08 };
        WriteVarint(timestampMessage, timestamp);

        var buffer = new List<byte> { 0x08, 0x02, 0x12, 0x13, 0x08, 0x03, 0x12, 0x09 };
        buffer.AddRange(Encoding.ASCII.GetBytes("813836352"));
        buffer.AddRange([0x1A, 0x02, (byte)'e', (byte)'n', 0x20, 0x01]);
        buffer.AddRange([0x1A, (byte)timestampMessage.Count]);
        buffer.AddRange(timestampMessage);

        return Convert
            .ToBase64String(buffer.ToArray())
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
    }

    // Prepends a fresh consent cookie, unless the user's own cookies already carry one
    public static IReadOnlyList<Cookie> WithFreshConsent(IReadOnlyList<Cookie>? cookies)
    {
        cookies ??= [];

        if (cookies.Any(c => string.Equals(c.Name, "SOCS", StringComparison.Ordinal)))
            return cookies;

        return
        [
            new Cookie("SOCS", GenerateValue(DateTimeOffset.UtcNow)) { Domain = "youtube.com" },
            .. cookies,
        ];
    }
}
