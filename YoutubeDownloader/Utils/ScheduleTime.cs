using System;
using System.Globalization;

namespace YoutubeDownloader.Utils;

public static class ScheduleTime
{
    public static TimeOnly Default { get; } = new(18, 0);

    public static TimeOnly? TryParse(string? text) =>
        TimeOnly.TryParseExact(
            text?.Trim(),
            ["H:mm", "HH:mm", "H\\hmm", "HH\\hmm", "H\\h"],
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var time
        )
            ? time
            : null;

    public static TimeOnly ParseOrDefault(string? text) => TryParse(text) ?? Default;

    public static string Format(TimeOnly time) =>
        time.ToString("HH:mm", CultureInfo.InvariantCulture);

    // Next time the clock shows the given time: later today, or tomorrow if already past
    public static DateTimeOffset GetNextOccurrence(TimeOnly time, DateTimeOffset now)
    {
        var candidate = new DateTimeOffset(now.Date + time.ToTimeSpan(), now.Offset);
        return candidate > now ? candidate : candidate.AddDays(1);
    }
}
