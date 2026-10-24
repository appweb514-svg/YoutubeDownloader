using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using Cogwheel;
using CommunityToolkit.Mvvm.ComponentModel;
using YoutubeDownloader.Core.Downloading;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeDownloader.Utils;
using Container = YoutubeExplode.Videos.Streams.Container;

namespace YoutubeDownloader.Services;

[ObservableObject]
public partial class SettingsService()
    : SettingsBase(StartOptions.Current.SettingsPath, SettingsSerializerContext.Default)
{
    [ObservableProperty]
    public partial bool IsUkraineSupportMessageEnabled { get; set; } = true;

    [ObservableProperty]
    public partial ThemeVariant Theme { get; set; }

    [ObservableProperty]
    public partial ColorTheme ColorTheme { get; set; }

    [ObservableProperty]
    public partial string? SchoolName { get; set; }

    [ObservableProperty]
    public partial string? DefaultDownloadDirPath { get; set; }

    [ObservableProperty]
    public partial string? CurrentCategory { get; set; }

    [ObservableProperty]
    public partial IReadOnlyList<string> RecentCategories { get; set; } = [];

    [ObservableProperty]
    public partial bool IsClassPresetDefault { get; set; }

    [ObservableProperty]
    public partial bool ShouldWriteSourceFile { get; set; } = true;

    [ObservableProperty]
    public partial string? AdminPinHash { get; set; }

    [ObservableProperty]
    public partial string? AdminPinSalt { get; set; }

    [ObservableProperty]
    public partial VideoQualityPreference MaxVideoQuality { get; set; } =
        VideoQualityPreference.Highest;

    [ObservableProperty]
    public partial Language Language { get; set; }

    [ObservableProperty]
    public partial bool IsAutoUpdateEnabled { get; set; } = true;

    [ObservableProperty]
    public partial bool IsAuthPersisted { get; set; } = true;

    [ObservableProperty]
    public partial string? FFmpegFilePath { get; set; }

    [ObservableProperty]
    public partial bool ShouldInjectLanguageSpecificAudioStreams { get; set; } = true;

    [ObservableProperty]
    public partial bool ShouldInjectSubtitles { get; set; } = true;

    [ObservableProperty]
    public partial bool ShouldSaveSubtitleFiles { get; set; }

    [ObservableProperty]
    public partial string PreferredSubtitleLanguage { get; set; } = "fr";

    [ObservableProperty]
    public partial bool ShouldInjectTags { get; set; } = true;

    [ObservableProperty]
    public partial bool ShouldSkipExistingFiles { get; set; }

    [ObservableProperty]
    public partial string FileNameTemplate { get; set; } = "$title";

    [ObservableProperty]
    public partial int ParallelLimit { get; set; } = 2;

    [ObservableProperty]
    public partial int MaxDownloadRateKBps { get; set; }

    [ObservableProperty]
    public partial string ScheduledStartTime { get; set; } = "18:00";

    [ObservableProperty]
    [JsonConverter(typeof(AuthCookiesEncryptionConverter))]
    public partial IReadOnlyList<Cookie>? LastAuthCookies { get; set; }

    [ObservableProperty]
    [JsonConverter(typeof(ContainerConverter))]
    public partial Container LastContainer { get; set; } = Container.Mp4;

    [ObservableProperty]
    public partial VideoQualityPreference LastVideoQualityPreference { get; set; } =
        VideoQualityPreference.Highest;

    // Download folder for new downloads, including the current class/subject sub-folder, if configured
    public string? TryGetDownloadDirPath() =>
        !string.IsNullOrWhiteSpace(DefaultDownloadDirPath)
            ? CategoryPath.Combine(DefaultDownloadDirPath, CurrentCategory)
            : null;

    [JsonIgnore]
    public bool IsAdminPinSet => !string.IsNullOrWhiteSpace(AdminPinHash);

    public void SetAdminPin(string? pin)
    {
        if (string.IsNullOrWhiteSpace(pin))
        {
            AdminPinSalt = null;
            AdminPinHash = null;
            return;
        }

        var salt = PinHasher.CreateSalt();
        AdminPinSalt = salt;
        AdminPinHash = PinHasher.Hash(salt, pin);
    }

    public void RememberCurrentCategory()
    {
        if (CategoryPath.Sanitize(CurrentCategory) is null)
            return;

        var category = CurrentCategory!.Trim();

        RecentCategories =
        [
            category,
            .. RecentCategories
                .Where(c => !string.Equals(c, category, StringComparison.OrdinalIgnoreCase))
                .Take(9),
        ];
    }

    public override void Save()
    {
        // Clear the cookies if they are not supposed to be persisted
        var lastAuthCookies = LastAuthCookies;
        if (!IsAuthPersisted)
            LastAuthCookies = null;

        base.Save();

        LastAuthCookies = lastAuthCookies;
    }
}

public partial class SettingsService
{
    [JsonSerializable(typeof(SettingsService))]
    [JsonSourceGenerationOptions(UseStringEnumConverter = true)]
    private partial class SettingsSerializerContext : JsonSerializerContext;
}
