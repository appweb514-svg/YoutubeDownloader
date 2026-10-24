using System;
using System.IO;

namespace YoutubeDownloader;

public partial class StartOptions
{
    public required string DataDirPath { get; init; }

    public required string SettingsPath { get; init; }

    public required bool IsAutoUpdateAllowed { get; init; }
}

public partial class StartOptions
{
    // Portable by default: data lives next to the executable, so the app runs from any folder
    // (Documents, USB stick) without administrator rights. If that folder is read-only
    // (e.g. extracted under Program Files), fall back to the user's local app data.
    private static string ResolveDataDirPath()
    {
        if (IsDirectoryWritable(AppContext.BaseDirectory))
            return AppContext.BaseDirectory;

        var dirPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Youtube4School"
        );

        Directory.CreateDirectory(dirPath);
        return dirPath;
    }

    private static bool IsDirectoryWritable(string dirPath)
    {
        try
        {
            var probeFilePath = Path.Combine(dirPath, $".write-test-{Guid.NewGuid():N}");
            File.WriteAllBytes(probeFilePath, []);
            File.Delete(probeFilePath);

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static StartOptions Create()
    {
        var dataDirPath = ResolveDataDirPath();

        return new()
        {
            DataDirPath = dataDirPath,
            SettingsPath =
                Environment.GetEnvironmentVariable("YOUTUBEDOWNLOADER_SETTINGS_PATH") is { } path
                && !string.IsNullOrWhiteSpace(path)
                    ? Path.EndsInDirectorySeparator(path) || Directory.Exists(path)
                        ? Path.Combine(path, "Settings.dat")
                        : path
                    : Path.Combine(dataDirPath, "Settings.dat"),
            IsAutoUpdateAllowed = !(
                Environment.GetEnvironmentVariable("YOUTUBEDOWNLOADER_ALLOW_AUTO_UPDATE") is { } env
                && env.Equals("false", StringComparison.OrdinalIgnoreCase)
            ),
        };
    }

    public static StartOptions Current { get; } = Create();
}
