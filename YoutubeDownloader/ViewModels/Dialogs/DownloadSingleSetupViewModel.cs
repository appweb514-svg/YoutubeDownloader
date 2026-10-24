using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Input.Platform;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PowerKit.Extensions;
using YoutubeDownloader.Core.Downloading;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeDownloader.Services;
using YoutubeDownloader.Utils;
using YoutubeDownloader.Utils.Extensions;
using YoutubeDownloader.ViewModels.Components;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloader.ViewModels.Dialogs;

public partial class DownloadSingleSetupViewModel(
    ViewModelManager viewModelManager,
    DialogManager dialogManager,
    LocalizationManager localizationManager,
    SettingsService settingsService
) : DialogViewModelBase<DownloadViewModel>
{
    public LocalizationManager LocalizationManager { get; } = localizationManager;

    [ObservableProperty]
    public partial IVideo? Video { get; set; }

    [ObservableProperty]
    public partial IReadOnlyList<VideoDownloadOption>? AvailableDownloadOptions { get; set; }

    [ObservableProperty]
    public partial VideoDownloadOption? SelectedDownloadOption { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ClipErrorMessage))]
    [NotifyPropertyChangedFor(nameof(HasClipError))]
    [NotifyCanExecuteChangedFor(nameof(ConfirmCommand))]
    public partial string? ClipStartText { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ClipErrorMessage))]
    [NotifyPropertyChangedFor(nameof(HasClipError))]
    [NotifyCanExecuteChangedFor(nameof(ConfirmCommand))]
    public partial string? ClipEndText { get; set; }

    public string? ClipErrorMessage
    {
        get
        {
            if (
                !ClipTime.TryParse(ClipStartText, out var start)
                || !ClipTime.TryParse(ClipEndText, out var end)
            )
                return LocalizationManager.ClipInvalidFormatMessage;

            if (start is not null && end is not null && end <= start)
                return LocalizationManager.ClipEndBeforeStartMessage;

            if (
                Video?.Duration is { } duration
                && ((start is not null && start >= duration) || (end is not null && end > duration))
            )
                return LocalizationManager.ClipOutOfRangeMessage;

            return null;
        }
    }

    public bool HasClipError => ClipErrorMessage is not null;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsPreviewVisible))]
    public partial VideoPreviewViewModel? Preview { get; private set; }

    public bool IsPreviewVisible => Preview is not null;

    [RelayCommand]
    private void ShowPreview()
    {
        if (Video is null)
            return;

        ClosePreview();

        // Start the preview at the beginning of the clip, if one is set
        ClipTime.TryParse(ClipStartText, out var start);

        var preview = viewModelManager.GetVideoPreviewViewModel(Video.Id, start);
        preview.CloseRequested += (_, _) => ClosePreview();

        Preview = preview;
    }

    private void ClosePreview()
    {
        var preview = Preview;
        Preview = null;
        preview?.Dispose();
    }

    public override Task InitializeAsync()
    {
        // Administrator-defined quality cap: keep audio-only options and videos up to the cap
        if (
            AvailableDownloadOptions is not null
            && settingsService.MaxVideoQuality.TryGetMaxHeight() is { } maxHeight
        )
        {
            AvailableDownloadOptions = AvailableDownloadOptions
                .Where(o =>
                    o.IsAudioOnly
                    || o.VideoQuality is null
                    || o.VideoQuality.Value.MaxHeight <= maxHeight
                )
                .ToArray();
        }

        SelectedDownloadOption = AvailableDownloadOptions?.FirstOrDefault(o =>
            o.Container == settingsService.LastContainer
        );

        if (settingsService.IsClassPresetDefault)
            ApplyClassPreset();

        return Task.CompletedTask;
    }

    // Class preset: MP4 plays everywhere, and 720p is a good trade-off for projectors and file size
    [RelayCommand]
    private void ApplyClassPreset()
    {
        var option = AvailableDownloadOptions
            ?.Where(o =>
                !o.IsAudioOnly && o.Container == Container.Mp4 && o.VideoQuality?.MaxHeight <= 720
            )
            .MaxBy(o => o.VideoQuality);

        if (option is not null)
            SelectedDownloadOption = option;
    }

    [RelayCommand]
    private async Task CopyTitleAsync()
    {
        if (Application.Current?.ApplicationLifetime?.TryGetTopLevel()?.Clipboard is { } clipboard)
            await clipboard.SetTextAsync(Video?.Title);
    }

    private bool CanConfirm() => !HasClipError;

    [RelayCommand(CanExecute = nameof(CanConfirm))]
    private async Task ConfirmAsync()
    {
        if (Video is null || SelectedDownloadOption is null)
            return;

        if (
            !ClipTime.TryParse(ClipStartText, out var clipStart)
            || !ClipTime.TryParse(ClipEndText, out var clipEnd)
        )
            return;

        // A clip starting at zero and running to the end is the whole video
        if (clipStart == TimeSpan.Zero && clipEnd is null)
            clipStart = null;

        var container = SelectedDownloadOption.Container;

        var fileName = FileNameTemplate.Apply(settingsService.FileNameTemplate, Video, container);

        // When a default download folder is configured (e.g. a shared school drive),
        // save there directly instead of asking every time
        var filePath = settingsService.TryGetDownloadDirPath() is { } dirPath
            ? Path.EnsureUniqueFilePath(Path.Combine(dirPath, fileName))
            : await dialogManager.PromptSaveFilePathAsync(
                [
                    new FilePickerFileType($"{container.Name} file")
                    {
                        Patterns = [$"*.{container.Name}"],
                    },
                ],
                fileName
            );

        if (string.IsNullOrWhiteSpace(filePath))
            return;

        // Download does not start immediately, so lock in the file path to avoid conflicts
        Directory.CreateForFile(filePath);
        await File.WriteAllBytesAsync(filePath, []);

        settingsService.LastContainer = container;
        settingsService.RememberCurrentCategory();

        ClosePreview();

        Close(
            viewModelManager.GetDownloadViewModel(
                Video,
                SelectedDownloadOption,
                filePath,
                clipStart,
                clipEnd
            )
        );
    }
}
