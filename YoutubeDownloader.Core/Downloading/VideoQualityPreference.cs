using System;

namespace YoutubeDownloader.Core.Downloading;

public enum VideoQualityPreference
{
    // ReSharper disable InconsistentNaming
    Lowest,
    UpTo360p,
    UpTo480p,
    UpTo720p,
    UpTo1080p,
    Highest,
    // ReSharper restore InconsistentNaming
}

public static class VideoQualityPreferenceExtensions
{
    extension(VideoQualityPreference preference)
    {
        public string GetDisplayName() =>
            preference switch
            {
                VideoQualityPreference.Lowest => "Lowest quality",
                VideoQualityPreference.UpTo360p => "≤ 360p",
                VideoQualityPreference.UpTo480p => "≤ 480p",
                VideoQualityPreference.UpTo720p => "≤ 720p",
                VideoQualityPreference.UpTo1080p => "≤ 1080p",
                VideoQualityPreference.Highest => "Highest quality",
                _ => throw new ArgumentOutOfRangeException(nameof(preference)),
            };

        // Maximum video height allowed by this preference when used as a cap, or null if unlimited
        public int? TryGetMaxHeight() =>
            preference switch
            {
                VideoQualityPreference.Lowest => 144,
                VideoQualityPreference.UpTo360p => 360,
                VideoQualityPreference.UpTo480p => 480,
                VideoQualityPreference.UpTo720p => 720,
                VideoQualityPreference.UpTo1080p => 1080,
                _ => null,
            };
    }
}
