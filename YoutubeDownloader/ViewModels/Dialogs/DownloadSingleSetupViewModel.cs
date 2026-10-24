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
using YoutubeDownloader.Utils.Extensions;
using YoutubeDownloader.ViewModels.Components;
using YoutubeExplode.Videos;

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

    public override Task InitializeAsync()
    {
        SelectedDownloadOption = AvailableDownloadOptions?.FirstOrDefault(o =>
            o.Container == settingsService.LastContainer
        );

        return Task.CompletedTask;
    }

    [RelayCommand]
    private async Task CopyTitleAsync()
    {
        if (Application.Current?.ApplicationLifetime?.TryGetTopLevel()?.Clipboard is { } clipboard)
            await clipboard.SetTextAsync(Video?.Title);
    }

    [RelayCommand]
    private async Task ConfirmAsync()
    {
        if (Video is null || SelectedDownloadOption is null)
            return;

        var container = SelectedDownloadOption.Container;

        var fileName = FileNameTemplate.Apply(settingsService.FileNameTemplate, Video, container);

        // When a default download folder is configured (e.g. a shared school drive),
        // save there directly instead of asking every time
        var filePath = !string.IsNullOrWhiteSpace(settingsService.DefaultDownloadDirPath)
            ? Path.EnsureUniqueFilePath(
                Path.Combine(settingsService.DefaultDownloadDirPath, fileName)
            )
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

        Close(viewModelManager.GetDownloadViewModel(Video, SelectedDownloadOption, filePath));
    }
}
