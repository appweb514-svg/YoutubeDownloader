using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using PowerKit.Extensions;
using YoutubeDownloader.Core.Downloading;
using YoutubeDownloader.Localization;
using YoutubeDownloader.ViewModels;
using YoutubeDownloader.ViewModels.Components;
using YoutubeDownloader.ViewModels.Dialogs;
using YoutubeExplode.Videos;

namespace YoutubeDownloader.Framework;

public class ViewModelManager(IServiceProvider services, LocalizationManager localizationManager)
{
    public MainViewModel GetMainViewModel() => services.GetRequiredService<MainViewModel>();

    public DashboardViewModel GetDashboardViewModel() =>
        services.GetRequiredService<DashboardViewModel>();

    public AuthSetupViewModel GetAuthSetupViewModel() =>
        services.GetRequiredService<AuthSetupViewModel>();

    public DownloadViewModel GetDownloadViewModel(
        IVideo video,
        VideoDownloadOption downloadOption,
        string filePath,
        TimeSpan? clipStart = null,
        TimeSpan? clipEnd = null
    )
    {
        var viewModel = services.GetRequiredService<DownloadViewModel>();

        viewModel.Video = video;
        viewModel.DownloadOption = downloadOption;
        viewModel.FilePath = filePath;
        viewModel.ClipStart = clipStart;
        viewModel.ClipEnd = clipEnd;

        return viewModel;
    }

    public DownloadViewModel GetDownloadViewModel(
        IVideo video,
        VideoDownloadPreference downloadPreference,
        string filePath,
        TimeSpan? clipStart = null,
        TimeSpan? clipEnd = null
    )
    {
        var viewModel = services.GetRequiredService<DownloadViewModel>();

        viewModel.Video = video;
        viewModel.DownloadPreference = downloadPreference;
        viewModel.FilePath = filePath;
        viewModel.ClipStart = clipStart;
        viewModel.ClipEnd = clipEnd;

        return viewModel;
    }

    public VideoPreviewViewModel GetVideoPreviewViewModel(VideoId videoId, TimeSpan? start)
    {
        var viewModel = services.GetRequiredService<VideoPreviewViewModel>();

        viewModel.VideoId = videoId;
        viewModel.Start = start;

        return viewModel;
    }

    public DownloadMultipleSetupViewModel GetDownloadMultipleSetupViewModel(
        string title,
        IReadOnlyList<IVideo> availableVideos,
        bool preselectVideos = true
    )
    {
        var viewModel = services.GetRequiredService<DownloadMultipleSetupViewModel>();

        viewModel.Title = title;
        viewModel.AvailableVideos = availableVideos;

        if (preselectVideos)
            viewModel.SelectedVideos.AddRange(availableVideos);

        return viewModel;
    }

    public DownloadSingleSetupViewModel GetDownloadSingleSetupViewModel(
        IVideo video,
        IReadOnlyList<VideoDownloadOption> availableDownloadOptions
    )
    {
        var viewModel = services.GetRequiredService<DownloadSingleSetupViewModel>();

        viewModel.Video = video;
        viewModel.AvailableDownloadOptions = availableDownloadOptions;

        return viewModel;
    }

    public HistoryViewModel GetHistoryViewModel() =>
        services.GetRequiredService<HistoryViewModel>();

    public MessageBoxViewModel GetMessageBoxViewModel(
        string title,
        string message,
        string? okButtonText,
        string? cancelButtonText
    )
    {
        var viewModel = services.GetRequiredService<MessageBoxViewModel>();

        viewModel.Title = title;
        viewModel.Message = message;
        viewModel.DefaultButtonText = okButtonText;
        viewModel.CancelButtonText = cancelButtonText;

        return viewModel;
    }

    public MessageBoxViewModel GetMessageBoxViewModel(string title, string message) =>
        GetMessageBoxViewModel(title, message, localizationManager.CloseButton, null);

    public PinPromptViewModel GetPinPromptViewModel() =>
        services.GetRequiredService<PinPromptViewModel>();

    public SettingsViewModel GetSettingsViewModel() =>
        services.GetRequiredService<SettingsViewModel>();
}
