using System;
using System.Collections.Generic;
using System.Linq;

namespace YoutubeDownloader.Utils;

public static class LinkListParser
{
    private static readonly char[] Separators = [',', ';', '\t'];

    // Common header cells of spreadsheets exported as CSV
    private static readonly string[] HeaderCells =
    [
        "url",
        "urls",
        "link",
        "links",
        "lien",
        "liens",
    ];

    // One entry per non-empty line: first non-empty cell, lines starting with '#' are comments
    public static IReadOnlyList<string> Parse(string text)
    {
        var result = new List<string>();

        foreach (var rawLine in text.Split('\n'))
        {
            var line = rawLine.Trim().TrimStart('﻿');
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#'))
                continue;

            var cell = line.Split(Separators)
                .Select(c => c.Trim().Trim('"', '\'').Trim())
                .FirstOrDefault(c => !string.IsNullOrWhiteSpace(c));

            if (cell is null || HeaderCells.Contains(cell, StringComparer.OrdinalIgnoreCase))
                continue;

            result.Add(cell);
        }

        return result;
    }
}
