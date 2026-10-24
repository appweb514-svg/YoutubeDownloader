using System;
using System.IO;
using System.Linq;

namespace YoutubeDownloader.Utils;

public static class CategoryPath
{
    // Characters rejected by Windows file systems, so that shared drives work everywhere
    private static readonly char[] InvalidChars =
    [
        .. Path.GetInvalidFileNameChars(),
        '<',
        '>',
        ':',
        '"',
        '|',
        '?',
        '*',
    ];

    // Turns user input like "CM2/Sciences" into a safe relative path, or null if nothing usable remains
    public static string? Sanitize(string? category)
    {
        if (string.IsNullOrWhiteSpace(category))
            return null;

        var segments = category
            .Split(['/', '\\'], StringSplitOptions.RemoveEmptyEntries)
            .Select(segment =>
                new string(
                    segment
                        .Select(c => InvalidChars.Contains(c) || char.IsControl(c) ? '_' : c)
                        .ToArray()
                )
                    // Windows ignores trailing dots and spaces
                    .Trim()
                    .TrimEnd('.')
                    .Trim()
            )
            .Where(segment => !string.IsNullOrWhiteSpace(segment))
            .ToArray();

        return segments.Any() ? Path.Combine(segments) : null;
    }

    public static string Combine(string baseDirPath, string? category) =>
        Sanitize(category) is { } relativePath
            ? Path.Combine(baseDirPath, relativePath)
            : baseDirPath;
}
