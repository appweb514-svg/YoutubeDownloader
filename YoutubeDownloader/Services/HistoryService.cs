using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using YoutubeDownloader.Localization;

namespace YoutubeDownloader.Services;

public record HistoryEntry(
    string Date,
    string UserName,
    string Title,
    string Url,
    string FilePath,
    string Status,
    string Clip
);

// Download log kept next to the settings file, as a CSV that opens directly in Excel
public class HistoryService(LocalizationManager localizationManager)
{
    private readonly Lock _lock = new();

    public string FilePath { get; } =
        Path.Combine(
            Path.GetDirectoryName(StartOptions.Current.SettingsPath) ?? AppContext.BaseDirectory,
            "history.csv"
        );

    public void Append(HistoryEntry entry)
    {
        lock (_lock)
        {
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath) ?? ".");

                // BOM so that Excel detects UTF-8
                File.WriteAllText(
                    FilePath,
                    FormatLine([
                        localizationManager.HistoryDateColumnHeader,
                        localizationManager.HistoryUserColumnHeader,
                        localizationManager.HistoryTitleColumnHeader,
                        localizationManager.HistoryUrlColumnHeader,
                        localizationManager.HistoryFileColumnHeader,
                        localizationManager.HistoryStatusColumnHeader,
                        localizationManager.ClipLabel,
                    ]),
                    new UTF8Encoding(true)
                );
            }

            File.AppendAllText(
                FilePath,
                FormatLine([
                    entry.Date,
                    entry.UserName,
                    entry.Title,
                    entry.Url,
                    entry.FilePath,
                    entry.Status,
                    entry.Clip,
                ]),
                new UTF8Encoding(false)
            );
        }
    }

    public IReadOnlyList<HistoryEntry> GetRecentEntries(int count)
    {
        string[] lines;
        lock (_lock)
        {
            if (!File.Exists(FilePath))
                return [];

            lines = File.ReadAllLines(FilePath, Encoding.UTF8);
        }

        return lines
            // Skip the header
            .Skip(1)
            .Select(ParseLine)
            .Where(cells => cells.Count >= 7)
            .Select(cells => new HistoryEntry(
                cells[0],
                cells[1],
                cells[2],
                cells[3],
                cells[4],
                cells[5],
                cells[6]
            ))
            .TakeLast(count)
            .Reverse()
            .ToArray();
    }

    private static string EscapeCell(string value)
    {
        // Keep one record per line
        value = value.Replace('\r', ' ').Replace('\n', ' ');

        // Prevent spreadsheet formula injection from video titles
        if (value.Length > 0 && value[0] is '=' or '+' or '-' or '@')
            value = "'" + value;

        return '"' + value.Replace("\"", "\"\"") + '"';
    }

    private static string FormatLine(IEnumerable<string> cells) =>
        string.Join(';', cells.Select(EscapeCell)) + Environment.NewLine;

    private static IReadOnlyList<string> ParseLine(string line)
    {
        var cells = new List<string>();
        var cell = new StringBuilder();
        var isQuoted = false;

        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];

            if (isQuoted)
            {
                if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    cell.Append('"');
                    i++;
                }
                else if (c == '"')
                {
                    isQuoted = false;
                }
                else
                {
                    cell.Append(c);
                }
            }
            else if (c == '"')
            {
                isQuoted = true;
            }
            else if (c == ';')
            {
                cells.Add(cell.ToString());
                cell.Clear();
            }
            else
            {
                cell.Append(c);
            }
        }

        cells.Add(cell.ToString());

        // Undo the formula-injection guard for display
        return cells
            .Select(v =>
                v.Length > 1 && v[0] == '\'' && v[1] is '=' or '+' or '-' or '@' ? v[1..] : v
            )
            .ToArray();
    }
}
