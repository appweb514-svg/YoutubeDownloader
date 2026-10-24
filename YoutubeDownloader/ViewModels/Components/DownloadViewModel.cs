using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Input.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gress;
using PowerKit.Extensions;
using YoutubeDownloader.Core.Downloading;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeDownloader.Utils;
using YoutubeDownloader.Utils.Extensions;
using YoutubeExplode.Videos;

namespace YoutubeDownloader.ViewModels.Components;

public partial class DownloadViewModel : ViewModelBase
{
    private readonly ViewModelManager _viewModelManager;
    private readonly DialogManager _dialogManager;

    private readonly IDisposable _eventSubscription;
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private bool _isDisposed;

    public DownloadViewModel(
        ViewModelManager viewModelManager,
        DialogManager dialogManager,
        LocalizationManager localizationManager
    )
    {
        _viewModelManager = viewModelManager;
        _dialogManager = dialogManager;
        LocalizationManager = localizationManager;

        _eventSubscription = Progress.WatchProperty(
            o => o.Current,
            _ => OnPropertyChanged(nameof(IsProgressIndeterminate))
        );
    }

    public LocalizationManager LocalizationManager { get; }

    [ObservableProperty]
    public partial IVideo? Video { get; set; }

    [ObservableProperty]
    public partial VideoDownloadOption? DownloadOption { get; set; }

    [ObservableProperty]
    public partial VideoDownloadPreference? DownloadPreference { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FileName))]
    public partial string? FilePath { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasClip))]
    [NotifyPropertyChangedFor(nameof(ClipText))]
    public partial TimeSpan? ClipStart { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasClip))]
    [NotifyPropertyChangedFor(nameof(ClipText))]
    public partial TimeSpan? ClipEnd { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ScheduledStatusText))]
    public partial DateTimeOffset? ScheduledAt { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsCanceledOrFailed))]
    [NotifyCanExecuteChangedFor(nameof(CancelCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowFileCommand))]
    [NotifyCanExecuteChangedFor(nameof(OpenFileCommand))]
    public partial DownloadStatus Status { get; set; } = DownloadStatus.Enqueued;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CopyErrorMessageCommand))]
    public partial string? ErrorMessage { get; set; }

    public CancellationToken CancellationToken => _cancellationTokenSource.Token;

    public string? FileName => Path.GetFileName(FilePath);

    public ProgressContainer<Percentage> Progress { get; } = new();

    public bool IsProgressIndeterminate => Progress.Current.Fraction is <= 0 or >= 1;

    public bool HasClip => ClipStart is not null || ClipEnd is not null;

    public string? ClipText => ClipTime.FormatRange(ClipStart, ClipEnd);

    public string? ScheduledStatusText =>
        ScheduledAt is { } scheduledAt
            ? string.Format(
                LocalizationManager.DownloadStatusScheduled,
                scheduledAt.ToString("HH:mm", CultureInfo.InvariantCulture)
            )
            : null;

    public bool IsCanceledOrFailed => Status is DownloadStatus.Canceled or DownloadStatus.Failed;

    private bool CanCancel() =>
        Status is DownloadStatus.Scheduled or DownloadStatus.Enqueued or DownloadStatus.Started;

    [RelayCommand(CanExecute = nameof(CanCancel))]
    private void Cancel()
    {
        if (_isDisposed)
            return;

        _cancellationTokenSource.Cancel();
    }

    private bool CanShowFile() =>
        Status == DownloadStatus.Completed
        && (OperatingSystem.IsWindows() || OperatingSystem.IsMacOS() || OperatingSystem.IsLinux());

    [RelayCommand(CanExecute = nameof(CanShowFile))]
    private async Task ShowFileAsync()
    {
        if (string.IsNullOrWhiteSpace(FilePath))
            return;

        try
        {
            if (OperatingSystem.IsWindows())
                // Navigate to the file in Windows Explorer
                Process.Start("explorer", ["/select,", FilePath]);
            else if (OperatingSystem.IsMacOS())
                // Reveal the file in Finder
                Process.Start("open", ["-R", FilePath]);
            else
                // No portable way to select a file, so open its folder instead
                Process.StartShellExecute(Path.GetDirectoryName(FilePath) ?? FilePath);
        }
        catch (Exception ex)
        {
            await _dialogManager.ShowDialogAsync(
                _viewModelManager.GetMessageBoxViewModel(LocalizationManager.ErrorTitle, ex.Message)
            );
        }
    }

    private bool CanOpenFile() => Status == DownloadStatus.Completed;

    [RelayCommand(CanExecute = nameof(CanOpenFile))]
    private async Task OpenFileAsync()
    {
        if (string.IsNullOrWhiteSpace(FilePath))
            return;

        try
        {
            Process.StartShellExecute(FilePath);
        }
        catch (Exception ex)
        {
            await _dialogManager.ShowDialogAsync(
                _viewModelManager.GetMessageBoxViewModel(LocalizationManager.ErrorTitle, ex.Message)
            );
        }
    }

    [RelayCommand]
    private async Task CopyErrorMessageAsync()
    {
        if (string.IsNullOrWhiteSpace(ErrorMessage))
            return;

        if (Application.Current?.ApplicationLifetime?.TryGetTopLevel()?.Clipboard is { } clipboard)
            await clipboard.SetTextAsync(ErrorMessage);
    }

    protected override void Dispose(bool disposing)
    {
        if (_isDisposed)
            return;

        _isDisposed = true;

        _eventSubscription.Dispose();
        _cancellationTokenSource.Dispose();
    }
}
