using System;
using System.Globalization;

namespace YoutubeDownloader.Utils;

public static class ClipTime
{
    // Accepts 'h:mm:ss', 'mm:ss' or plain seconds; empty input means "not set"
    public static bool TryParse(string? text, out TimeSpan? value)
    {
        value = null;

        if (string.IsNullOrWhiteSpace(text))
            return true;

        var parts = text.Trim().Split(':');
        if (parts.Length > 3)
            return false;

        long totalSeconds = 0;
        for (var i = 0; i < parts.Length; i++)
        {
            if (
                !int.TryParse(
                    parts[i].Trim(),
                    NumberStyles.None,
                    CultureInfo.InvariantCulture,
                    out var number
                )
            )
                return false;

            // Minutes and seconds after the leading component must stay below 60
            if (i > 0 && number >= 60)
                return false;

            totalSeconds = totalSeconds * 60 + number;
        }

        // Guard against absurd values (more than a few days)
        if (totalSeconds > 1_000_000)
            return false;

        value = TimeSpan.FromSeconds(totalSeconds);
        return true;
    }

    public static string Format(TimeSpan value) =>
        value.TotalHours >= 1
            ? value.ToString(@"h\:mm\:ss", CultureInfo.InvariantCulture)
            : value.ToString(@"m\:ss", CultureInfo.InvariantCulture);

    public static string? FormatRange(TimeSpan? start, TimeSpan? end) =>
        start is null && end is null
            ? null
            : $"{Format(start ?? TimeSpan.Zero)} – {(end is { } e ? Format(e) : "…")}";
}
