using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using YoutubeExplode.Videos.ClosedCaptions;

namespace YoutubeDownloader.Core.Utils;

public static class SubRip
{
    private static string FormatTime(TimeSpan time) =>
        time.ToString(@"hh\:mm\:ss\,fff", CultureInfo.InvariantCulture);

    // Writes the captions overlapping [start, end] as SRT, shifted so that 'start' becomes zero
    public static string Format(
        IEnumerable<ClosedCaption> captions,
        TimeSpan? start = null,
        TimeSpan? end = null
    )
    {
        var clipStart = start ?? TimeSpan.Zero;
        var clipEnd = end ?? TimeSpan.MaxValue;

        var buffer = new StringBuilder();
        var index = 0;

        foreach (var caption in captions)
        {
            if (string.IsNullOrWhiteSpace(caption.Text))
                continue;

            var captionStart = caption.Offset;
            var captionEnd = caption.Offset + caption.Duration;
            if (captionEnd <= clipStart || captionStart >= clipEnd)
                continue;

            var from = (captionStart < clipStart ? clipStart : captionStart) - clipStart;
            var to = (captionEnd > clipEnd ? clipEnd : captionEnd) - clipStart;

            buffer
                .Append(++index)
                .Append('\n')
                .Append(FormatTime(from))
                .Append(" --> ")
                .Append(FormatTime(to))
                .Append('\n')
                .Append(caption.Text.Trim())
                .Append("\n\n");
        }

        return buffer.ToString();
    }
}
