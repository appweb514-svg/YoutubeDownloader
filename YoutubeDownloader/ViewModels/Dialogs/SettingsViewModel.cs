using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PowerKit.Extensions;
using YoutubeDownloader.Core.Downloading;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeDownloader.Services;
using YoutubeDownloader.Utils;

namespace YoutubeDownloader.ViewModels.Dialogs;

public partial class SettingsViewModel : DialogViewModelBase
{
    private readonly DialogManager _dialogManager;
    private readonly SettingsService _settingsService;

    private readonly IDisposable _eventSubscription;

    public SettingsViewModel(
        DialogManager dialogManager,
        LocalizationManager localizationManager,
        SettingsService settingsService
    )
    {
        _dialogManager = dialogManager;
        LocalizationManager = localizationManager;
        _settingsService = settingsService;

        _eventSubscription = _settingsService.WatchAllProperties(OnAllPropertiesChanged);
    }

    public LocalizationManager LocalizationManager { get; }

    public IReadOnlyList<ThemeVariant> AvailableThemes { get; } = Enum.GetValues<ThemeVariant>();

    public ThemeVariant Theme
    {
        get => _settingsService.Theme;
        set => _settingsService.Theme = value;
    }

    public string? SchoolName
    {
        get => _settingsService.SchoolName;
        set => _settingsService.SchoolName = !string.IsNullOrWhiteSpace(value) ? value : null;
    }

    public string? DefaultDownloadDirPath
    {
        get => _settingsService.DefaultDownloadDirPath;
        set =>
            _settingsService.DefaultDownloadDirPath = !string.IsNullOrWhiteSpace(value)
                ? value
                : null;
    }

    public bool IsClassPresetDefault
    {
        get => _settingsService.IsClassPresetDefault;
        set => _settingsService.IsClassPresetDefault = value;
    }

    public bool ShouldWriteSourceFile
    {
        get => _settingsService.ShouldWriteSourceFile;
        set => _settingsService.ShouldWriteSourceFile = value;
    }

    public bool IsAdminPinSet => _settingsService.IsAdminPinSet;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SetAdminPinCommand))]
    public partial string? NewAdminPin { get; set; }

    public IReadOnlyList<VideoQualityPreference> AvailableMaxVideoQualities { get; } =
        Enum.GetValues<VideoQualityPreference>()
            .Where(p => p != VideoQualityPreference.Lowest)
            .Reverse()
            .ToArray();

    public VideoQualityPreference MaxVideoQuality
    {
        get => _settingsService.MaxVideoQuality;
        set => _settingsService.MaxVideoQuality = value;
    }

    public IReadOnlyList<Language> AvailableLanguages { get; } = Enum.GetValues<Language>();

    public Language Language
    {
        get => _settingsService.Language;
        set => _settingsService.Language = value;
    }

    public bool IsAutoUpdateAvailable { get; } =
        OperatingSystem.IsWindows() && StartOptions.Current.IsAutoUpdateAllowed;

    public bool IsAutoUpdateEnabled
    {
        get => _settingsService.IsAutoUpdateEnabled;
        set => _settingsService.IsAutoUpdateEnabled = value;
    }

    public bool IsAuthPersisted
    {
        get => _settingsService.IsAuthPersisted;
        set => _settingsService.IsAuthPersisted = value;
    }

    public string? FFmpegFilePath
    {
        get => _settingsService.FFmpegFilePath;
        set => _settingsService.FFmpegFilePath = !string.IsNullOrWhiteSpace(value) ? value : null;
    }

    public bool ShouldInjectLanguageSpecificAudioStreams
    {
        get => _settingsService.ShouldInjectLanguageSpecificAudioStreams;
        set => _settingsService.ShouldInjectLanguageSpecificAudioStreams = value;
    }

    public bool ShouldInjectSubtitles
    {
        get => _settingsService.ShouldInjectSubtitles;
        set => _settingsService.ShouldInjectSubtitles = value;
    }

    public bool ShouldSaveSubtitleFiles
    {
        get => _settingsService.ShouldSaveSubtitleFiles;
        set => _settingsService.ShouldSaveSubtitleFiles = value;
    }

    public string PreferredSubtitleLanguage
    {
        get => _settingsService.PreferredSubtitleLanguage;
        set => _settingsService.PreferredSubtitleLanguage = value?.Trim() ?? "";
    }

    public bool ShouldInjectTags
    {
        get => _settingsService.ShouldInjectTags;
        set => _settingsService.ShouldInjectTags = value;
    }

    public bool ShouldSkipExistingFiles
    {
        get => _settingsService.ShouldSkipExistingFiles;
        set => _settingsService.ShouldSkipExistingFiles = value;
    }

    public string FileNameTemplate
    {
        get => _settingsService.FileNameTemplate;
        set => _settingsService.FileNameTemplate = value;
    }

    public int ParallelLimit
    {
        get => _settingsService.ParallelLimit;
        set => _settingsService.ParallelLimit = Math.Clamp(value, 1, 10);
    }

    public int MaxDownloadRateKBps
    {
        get => _settingsService.MaxDownloadRateKBps;
        set => _settingsService.MaxDownloadRateKBps = Math.Max(0, value);
    }

    public string ScheduledStartTime
    {
        get => _settingsService.ScheduledStartTime;
        set =>
            _settingsService.ScheduledStartTime = ScheduleTime.TryParse(value) is { } time
                ? ScheduleTime.Format(time)
                : value;
    }

    private bool CanSetAdminPin() => NewAdminPin?.Trim().Length >= 4;

    [RelayCommand(CanExecute = nameof(CanSetAdminPin))]
    private void SetAdminPin()
    {
        _settingsService.SetAdminPin(NewAdminPin?.Trim());
        NewAdminPin = null;
    }

    [RelayCommand]
    private void RemoveAdminPin() => _settingsService.SetAdminPin(null);

    [RelayCommand]
    private async Task BrowseFFmpegFilePathAsync()
    {
        var fileTypes = OperatingSystem.IsWindows()
            ? new[]
            {
                new FilePickerFileType("FFmpeg executable") { Patterns = ["*.exe"] },
                FilePickerFileTypes.All,
            }
            : null;

        var filePath = await _dialogManager.PromptOpenFilePathAsync(fileTypes);

        if (string.IsNullOrWhiteSpace(filePath))
            return;

        FFmpegFilePath = filePath;
    }

    [RelayCommand]
    private void ResetFFmpegFilePath() => FFmpegFilePath = null;

    [RelayCommand]
    private async Task BrowseDefaultDownloadDirPathAsync()
    {
        var dirPath = await _dialogManager.PromptDirectoryPathAsync(DefaultDownloadDirPath ?? "");

        if (string.IsNullOrWhiteSpace(dirPath))
            return;

        DefaultDownloadDirPath = dirPath;
    }

    [RelayCommand]
    private void ResetDefaultDownloadDirPath() => DefaultDownloadDirPath = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _eventSubscription.Dispose();
        }

        base.Dispose(disposing);
    }
}
