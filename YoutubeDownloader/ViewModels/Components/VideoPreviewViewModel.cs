using System;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PowerKit.Extensions;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeExplode.Videos;

namespace YoutubeDownloader.ViewModels.Components;

public partial class VideoPreviewViewModel(LocalizationManager localizationManager) : ViewModelBase
{
    public LocalizationManager LocalizationManager { get; } = localizationManager;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EmbedUri))]
    [NotifyPropertyChangedFor(nameof(WatchUri))]
    public partial VideoId? VideoId { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EmbedUri))]
    [NotifyPropertyChangedFor(nameof(WatchUri))]
    public partial TimeSpan? Start { get; set; }

    private int StartSeconds => (int)(Start?.TotalSeconds ?? 0);

    // Privacy-enhanced player: no tracking cookies until the video is played
    public Uri? EmbedUri =>
        VideoId is { } id
            ? new Uri($"https://www.youtube-nocookie.com/embed/{id}?start={StartSeconds}")
            : null;

    public Uri? WatchUri =>
        VideoId is { } id
            ? new Uri($"https://www.youtube.com/watch?v={id}&t={StartSeconds}s")
            : null;

    public event EventHandler? CloseRequested;

    [RelayCommand]
    private void OpenInBrowser()
    {
        if (WatchUri is { } uri)
            Process.StartShellExecute(uri.AbsoluteUri);
    }

    [RelayCommand]
    private void Close() => CloseRequested?.Invoke(this, EventArgs.Empty);
}
