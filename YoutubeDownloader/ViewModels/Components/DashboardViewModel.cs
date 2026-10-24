using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gress;
using Gress.Completable;
using PowerKit;
using PowerKit.Extensions;
using YoutubeDownloader.Core.Downloading;
using YoutubeDownloader.Core.Resolving;
using YoutubeDownloader.Core.Tagging;
using YoutubeDownloader.Core.Utils;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeDownloader.Services;
using YoutubeDownloader.Utils;
using YoutubeExplode.Exceptions;

namespace YoutubeDownloader.ViewModels.Components;

public partial class DashboardViewModel : ViewModelBase
{
    private readonly ViewModelManager _viewModelManager;
    private readonly SnackbarManager _snackbarManager;
    private readonly DialogManager _dialogManager;
    private readonly LocalizationManager _localizationManager;
    private readonly SettingsService _settingsService;
    private readonly HistoryService _historyService;

    private readonly IDisposable _eventSubscription;
    private readonly ResizableSemaphore _downloadSemaphore = new();
    private readonly AutoResetProgressMuxer _progressMuxer;

    public DashboardViewModel(
        ViewModelManager viewModelManager,
        SnackbarManager snackbarManager,
        DialogManager dialogManager,
        LocalizationManager localizationManager,
        SettingsService settingsService,
        HistoryService historyService
    )
    {
        _viewModelManager = viewModelManager;
        _snackbarManager = snackbarManager;
        _dialogManager = dialogManager;
        _localizationManager = localizationManager;
        LocalizationManager = localizationManager;
        _settingsService = settingsService;
        _historyService = historyService;

        _progressMuxer = Progress.CreateMuxer().WithAutoReset();

        _eventSubscription = Disposable.Merge(
            _settingsService.WatchProperty(
                o => o.ParallelLimit,
                v => _downloadSemaphore.MaxCount = v,
                true
            ),
            _settingsService.WatchProperty(
                o => o.MaxDownloadRateKBps,
                v => Http.MaxBytesPerSecond = Math.Max(0, v) * 1024L,
                true
            ),
            _settingsService.WatchProperty(
                o => o.ScheduledStartTime,
                _ => OnPropertyChanged(nameof(DeferredModeText))
            ),
            LocalizationManager.WatchProperty(
                o => o.Language,
                _ => OnPropertyChanged(nameof(DeferredModeText))
            ),
            _settingsService.WatchProperty(
                o => o.SchoolName,
                _ => OnPropertyChanged(nameof(HeaderSubtitle))
            ),
            LocalizationManager.WatchProperty(
                o => o.Language,
                _ => OnPropertyChanged(nameof(HeaderSubtitle))
            ),
            _settingsService.WatchProperty(
                o => o.DefaultDownloadDirPath,
                _ => OnPropertyChanged(nameof(HasDefaultDownloadDir))
            ),
            _settingsService.WatchProperty(
                o => o.CurrentCategory,
                _ => OnPropertyChanged(nameof(CurrentCategory))
            ),
            _settingsService.WatchProperty(
                o => o.RecentCategories,
                _ => OnPropertyChanged(nameof(RecentCategories))
            ),
            Progress.WatchProperty(
                o => o.Current,
                _ => OnPropertyChanged(nameof(IsProgressIndeterminate))
            )
        );

        Downloads.CollectionChanged += (_, _) => RefreshSummary();
    }

    public LocalizationManager LocalizationManager { get; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsProgressIndeterminate))]
    [NotifyCanExecuteChangedFor(nameof(ProcessQueryCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowAuthSetupCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowSettingsCommand))]
    [NotifyCanExecuteChangedFor(nameof(ImportLinkListCommand))]
    public partial bool IsBusy { get; set; }

    public ProgressContainer<Percentage> Progress { get; } = new();

    public bool IsProgressIndeterminate => IsBusy && Progress.Current.Fraction is <= 0 or >= 1;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ProcessQueryCommand))]
    public partial string? Query { get; set; }

    public ObservableCollection<DownloadViewModel> Downloads { get; } = [];

    public string HeaderSubtitle =>
        !string.IsNullOrWhiteSpace(_settingsService.SchoolName)
            ? _settingsService.SchoolName
            : LocalizationManager.AppHeaderSubtitle;

    public bool HasDefaultDownloadDir =>
        !string.IsNullOrWhiteSpace(_settingsService.DefaultDownloadDirPath);

    public string? CurrentCategory
    {
        get => _settingsService.CurrentCategory;
        set => _settingsService.CurrentCategory = !string.IsNullOrWhiteSpace(value) ? value : null;
    }

    public IReadOnlyList<string> RecentCategories => _settingsService.RecentCategories;

    [ObservableProperty]
    public partial bool IsDeferredMode { get; set; }

    public string DeferredModeText =>
        string.Format(
            LocalizationManager.DeferredModeLabel,
            ScheduleTime.Format(ScheduleTime.ParseOrDefault(_settingsService.ScheduledStartTime))
        );

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasCancelableDownloads))]
    public partial int ActiveDownloadsCount { get; private set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasCancelableDownloads))]
    public partial int ScheduledDownloadsCount { get; private set; }

    public bool HasCancelableDownloads => ActiveDownloadsCount + ScheduledDownloadsCount > 0;

    [ObservableProperty]
    public partial int CompletedDownloadsCount { get; private set; }

    [ObservableProperty]
    public partial int FailedDownloadsCount { get; private set; }

    private void RefreshSummary()
    {
        ActiveDownloadsCount = Downloads.Count(d =>
            d.Status is DownloadStatus.Enqueued or DownloadStatus.Started
        );
        CompletedDownloadsCount = Downloads.Count(d => d.Status == DownloadStatus.Completed);
        FailedDownloadsCount = Downloads.Count(d => d.Status == DownloadStatus.Failed);
        ScheduledDownloadsCount = Downloads.Count(d => d.Status == DownloadStatus.Scheduled);
    }

    private async Task EnsureFFmpegAsync()
    {
        // If a custom path is set, trust that the user knows what they're doing
        if (_settingsService.FFmpegFilePath is not null)
            return;

        // If FFmpeg can be auto-detected, all good
        if (FFmpeg.TryGetCliFilePath() is not null)
            return;

        // Otherwise, prompt the user to download FFmpeg
        var dialog = _viewModelManager.GetMessageBoxViewModel(
            _localizationManager.FFmpegMissingTitle,
            string.Format(_localizationManager.FFmpegMissingMessage, Program.Name),
            _localizationManager.DownloadButton,
            _localizationManager.CloseButton
        );

        // If the user declined, open settings to nudge them to set a custom FFmpeg path
        if (await _dialogManager.ShowDialogAsync(dialog) != true)
        {
            await ShowSettingsAsync();
            return;
        }

        IsBusy = true;
        var progress = _progressMuxer.CreateInput();
        _snackbarManager.Notify(_localizationManager.FFmpegDownloadingTitle);

        try
        {
            await FFmpeg.DownloadAsync(
                Path.Combine(AppContext.BaseDirectory, FFmpeg.CliFileName),
                progress
            );

            _snackbarManager.Notify(_localizationManager.FFmpegDownloadCompletedTitle);
        }
        catch (Exception ex)
        {
            await _dialogManager.ShowDialogAsync(
                _viewModelManager.GetMessageBoxViewModel(
                    _localizationManager.ErrorTitle,
                    ex.Message
                )
            );

            App.Shutdown(3);
        }
        finally
        {
            progress.ReportCompletion();
            IsBusy = false;
        }
    }

    public override async Task InitializeAsync() => await EnsureFFmpegAsync();

    private bool CanShowAuthSetup() => !IsBusy;

    // In locked mode, settings and the YouTube account are reserved to whoever knows the PIN
    private async Task<bool> EnsureAdminAccessAsync() =>
        !_settingsService.IsAdminPinSet
        || await _dialogManager.ShowDialogAsync(_viewModelManager.GetPinPromptViewModel()) == true;

    [RelayCommand(CanExecute = nameof(CanShowAuthSetup))]
    private async Task ShowAuthSetupAsync()
    {
        if (!await EnsureAdminAccessAsync())
            return;

        await _dialogManager.ShowDialogAsync(_viewModelManager.GetAuthSetupViewModel());
    }

    [RelayCommand]
    private async Task OpenDefaultDownloadDirAsync()
    {
        var dirPath = _settingsService.DefaultDownloadDirPath;
        if (string.IsNullOrWhiteSpace(dirPath))
            return;

        try
        {
            Directory.CreateDirectory(dirPath);
            Process.StartShellExecute(dirPath);
        }
        catch (Exception ex)
        {
            await _dialogManager.ShowDialogAsync(
                _viewModelManager.GetMessageBoxViewModel(LocalizationManager.ErrorTitle, ex.Message)
            );
        }
    }

    [RelayCommand]
    private async Task ShowHistoryAsync() =>
        await _dialogManager.ShowDialogAsync(_viewModelManager.GetHistoryViewModel());

    private bool CanShowSettings() => !IsBusy;

    [RelayCommand(CanExecute = nameof(CanShowSettings))]
    private async Task ShowSettingsAsync()
    {
        if (!await EnsureAdminAccessAsync())
            return;

        await _dialogManager.ShowDialogAsync(_viewModelManager.GetSettingsViewModel());
    }

    private async Task TrimDownloadAsync(DownloadViewModel download)
    {
        var filePath = download.FilePath!;
        var trimmedFilePath = Path.Combine(
            Path.GetDirectoryName(filePath) ?? "",
            Path.GetFileNameWithoutExtension(filePath) + ".clip" + Path.GetExtension(filePath)
        );

        download.IsTrimming = true;
        download.Progress.Report(Percentage.FromFraction(0));

        try
        {
            await FFmpeg.TrimAsync(
                _settingsService.FFmpegFilePath ?? FFmpeg.TryGetCliFilePath() ?? "ffmpeg",
                filePath,
                trimmedFilePath,
                download.ClipStart,
                download.ClipEnd,
                (download.ClipEnd ?? download.Video?.Duration)
                    - (download.ClipStart ?? TimeSpan.Zero),
                download.Progress,
                download.CancellationToken
            );

            File.Move(trimmedFilePath, filePath, true);
        }
        finally
        {
            download.IsTrimming = false;

            if (File.Exists(trimmedFilePath))
                File.Delete(trimmedFilePath);
        }
    }

    // Plain-text record of where the video comes from, to cite it and check its licence later
    private async Task WriteSourceFileAsync(DownloadViewModel download)
    {
        var video = download.Video!;
        var filePath = download.FilePath!;

        var lines = new List<string>
        {
            string.Format(LocalizationManager.SourceFileTitleLine, video.Title),
            string.Format(LocalizationManager.SourceFileChannelLine, video.Author.ChannelTitle),
            string.Format(
                LocalizationManager.SourceFileVideoUrlLine,
                $"https://www.youtube.com/watch?v={video.Id}"
            ),
            string.Format(
                LocalizationManager.SourceFileChannelUrlLine,
                $"https://www.youtube.com/channel/{video.Author.ChannelId}"
            ),
        };

        if (video.Duration is { } duration)
        {
            lines.Add(
                string.Format(LocalizationManager.SourceFileDurationLine, ClipTime.Format(duration))
            );
        }

        if (download.ClipText is { } clipText)
            lines.Add(string.Format(LocalizationManager.SourceFileClipLine, clipText));

        lines.Add(
            string.Format(
                LocalizationManager.SourceFileDownloadedAtLine,
                DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)
            )
        );

        if (!string.IsNullOrWhiteSpace(_settingsService.SchoolName))
        {
            lines.Add(
                string.Format(LocalizationManager.SourceFileSchoolLine, _settingsService.SchoolName)
            );
        }

        lines.Add("");
        lines.Add(LocalizationManager.SourceFileLicenseLine);

        var sourceFilePath = Path.Combine(
            Path.GetDirectoryName(filePath) ?? "",
            Path.GetFileNameWithoutExtension(filePath) + ".source.txt"
        );

        await File.WriteAllLinesAsync(
            sourceFilePath,
            lines,
            new UTF8Encoding(true),
            download.CancellationToken
        );
    }

    private void AppendToHistory(DownloadViewModel download)
    {
        var status = download.Status switch
        {
            DownloadStatus.Completed => LocalizationManager.DownloadStatusCompleted,
            DownloadStatus.Failed => LocalizationManager.DownloadStatusFailed,
            DownloadStatus.Canceled => LocalizationManager.DownloadStatusCanceled,
            _ => null,
        };

        if (status is null || download.Video is null)
            return;

        try
        {
            _historyService.Append(
                new HistoryEntry(
                    DateTimeOffset.Now.ToString(
                        "yyyy-MM-dd HH:mm:ss",
                        CultureInfo.InvariantCulture
                    ),
                    Environment.UserName,
                    download.Video.Title,
                    $"https://www.youtube.com/watch?v={download.Video.Id}",
                    download.FilePath ?? "",
                    status,
                    download.ClipText ?? ""
                )
            );
        }
        catch
        {
            // The history is not critical
        }
    }

    private void ScheduleIfDeferred(DownloadViewModel download)
    {
        if (!IsDeferredMode)
            return;

        download.ScheduledAt = ScheduleTime.GetNextOccurrence(
            ScheduleTime.ParseOrDefault(_settingsService.ScheduledStartTime),
            DateTimeOffset.Now
        );
    }

    private static async Task WaitUntilScheduledTimeAsync(DownloadViewModel download)
    {
        if (download.ScheduledAt is not { } scheduledAt)
            return;

        // Short steps so that sleep/wake cycles of the computer don't delay the start
        while (DateTimeOffset.Now < scheduledAt)
        {
            var remaining = scheduledAt - DateTimeOffset.Now;
            await Task.Delay(
                remaining < TimeSpan.FromSeconds(30) ? remaining : TimeSpan.FromSeconds(30),
                download.CancellationToken
            );
        }
    }

    private async void EnqueueDownload(DownloadViewModel download, int position = 0)
    {
        if (download.ScheduledAt is not null)
            download.Status = DownloadStatus.Scheduled;

        Downloads.Insert(position, download);

        // Scheduled downloads join the global progress only once their time has come
        ICompletableProgress<Percentage>? progress = null;

        try
        {
            if (download.Status == DownloadStatus.Scheduled)
            {
                await WaitUntilScheduledTimeAsync(download);

                download.Status = DownloadStatus.Enqueued;
                RefreshSummary();
            }

            progress = _progressMuxer.CreateInput();

            using var downloader = new VideoDownloader(_settingsService.LastAuthCookies);
            var tagInjector = new MediaTagInjector();

            using var access = await _downloadSemaphore.AcquireAsync(download.CancellationToken);

            download.Status = DownloadStatus.Started;
            RefreshSummary();

            var downloadOption =
                download.DownloadOption
                ?? await downloader.GetBestDownloadOptionAsync(
                    download.Video!.Id,
                    download.DownloadPreference!,
                    _settingsService.ShouldInjectLanguageSpecificAudioStreams,
                    download.CancellationToken
                );

            await downloader.DownloadVideoAsync(
                download.FilePath!,
                download.Video!,
                downloadOption,
                _settingsService.ShouldInjectSubtitles,
                _settingsService.PreferredSubtitleLanguage,
                _settingsService.FFmpegFilePath,
                download.Progress.Merge(progress),
                download.CancellationToken
            );

            if (download.HasClip)
                await TrimDownloadAsync(download);

            // Separate .srt files follow the clip, if any
            if (_settingsService.ShouldSaveSubtitleFiles)
            {
                try
                {
                    await downloader.DownloadSubtitleFilesAsync(
                        download.FilePath!,
                        download.Video!,
                        _settingsService.PreferredSubtitleLanguage,
                        download.ClipStart,
                        download.ClipEnd,
                        download.CancellationToken
                    );
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    // Subtitle files are not critical
                }
            }

            if (_settingsService.ShouldInjectTags)
            {
                try
                {
                    await tagInjector.InjectTagsAsync(
                        download.FilePath!,
                        download.Video!,
                        download.CancellationToken
                    );
                }
                catch
                {
                    // Media tagging is not critical
                }
            }

            if (_settingsService.ShouldWriteSourceFile)
            {
                try
                {
                    await WriteSourceFileAsync(download);
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    // The source file is not critical
                }
            }

            download.Status = DownloadStatus.Completed;
            RefreshSummary();
        }
        catch (Exception ex)
        {
            try
            {
                // Delete the incompletely downloaded file
                if (!string.IsNullOrWhiteSpace(download.FilePath))
                    File.Delete(download.FilePath);
            }
            catch
            {
                // Ignore
            }

            download.Status =
                ex is OperationCanceledException ? DownloadStatus.Canceled : DownloadStatus.Failed;

            // Short error message for YouTube-related errors, full for others
            download.ErrorMessage = ex is YoutubeExplodeException ? ex.Message : ex.ToString();
            RefreshSummary();
        }
        finally
        {
            progress?.ReportCompletion();
            AppendToHistory(download);
            download.Dispose();
        }
    }

    private bool CanProcessQuery() => !IsBusy && !string.IsNullOrWhiteSpace(Query);

    [RelayCommand(CanExecute = nameof(CanProcessQuery))]
    private async Task ProcessQueryAsync()
    {
        if (string.IsNullOrWhiteSpace(Query))
            return;

        IsBusy = true;

        // Small weight so as to not offset any existing download operations
        var progress = _progressMuxer.CreateInput(0.01);

        try
        {
            using var resolver = new QueryResolver(_settingsService.LastAuthCookies);

            // Split queries by newlines
            var queries = Query.Split(
                '\n',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
            );

            // Process individual queries
            var queryResults = new List<QueryResult>();
            foreach (var (i, query) in queries.Index())
            {
                try
                {
                    queryResults.Add(await resolver.ResolveAsync(query));
                }
                // If it's not the only query in the list, don't interrupt the process
                // and report the error via an async notification instead of a sync dialog.
                // https://github.com/Tyrrrz/YoutubeDownloader/issues/563
                catch (YoutubeExplodeException ex)
                    when (ex is VideoUnavailableException or PlaylistUnavailableException
                        && queries.Length > 1
                    )
                {
                    _snackbarManager.Notify(ex.Message);
                }

                progress.Report(Percentage.FromFraction((i + 1.0) / queries.Length));
            }

            // Aggregate results
            var queryResult = QueryResult.Aggregate(queryResults);

            // Single video result
            if (queryResult.Videos.Count == 1)
            {
                var video = queryResult.Videos.Single();

                using var downloader = new VideoDownloader(_settingsService.LastAuthCookies);

                var downloadOptions = await downloader.GetDownloadOptionsAsync(
                    video.Id,
                    _settingsService.ShouldInjectLanguageSpecificAudioStreams
                );

                var download = await _dialogManager.ShowDialogAsync(
                    _viewModelManager.GetDownloadSingleSetupViewModel(video, downloadOptions)
                );

                if (download is null)
                    return;

                ScheduleIfDeferred(download);
                EnqueueDownload(download);

                Query = "";
            }
            // Multiple videos
            else if (queryResult.Videos.Count > 1)
            {
                var downloads = await _dialogManager.ShowDialogAsync(
                    _viewModelManager.GetDownloadMultipleSetupViewModel(
                        queryResult.Title,
                        queryResult.Videos,
                        // Pre-select videos if they come from a single query and not from search
                        queryResult.Kind
                            is not QueryResultKind.Search
                                and not QueryResultKind.Aggregate
                    )
                );

                if (downloads is null)
                    return;

                foreach (var download in downloads)
                {
                    ScheduleIfDeferred(download);
                    EnqueueDownload(download);
                }

                Query = "";
            }
            // No videos found
            else
            {
                await _dialogManager.ShowDialogAsync(
                    _viewModelManager.GetMessageBoxViewModel(
                        LocalizationManager.NothingFoundTitle,
                        LocalizationManager.NothingFoundMessage
                    )
                );
            }
        }
        catch (Exception ex)
        {
            await _dialogManager.ShowDialogAsync(
                _viewModelManager.GetMessageBoxViewModel(
                    LocalizationManager.ErrorTitle,
                    // Short error message for YouTube-related errors, full for others
                    ex is YoutubeExplodeException
                        ? ex.Message
                        : ex.ToString()
                )
            );
        }
        finally
        {
            progress.ReportCompletion();
            IsBusy = false;
        }
    }

    private bool CanImportLinkList() => !IsBusy;

    [RelayCommand(CanExecute = nameof(CanImportLinkList))]
    private async Task ImportLinkListAsync()
    {
        try
        {
            var filePath = await _dialogManager.PromptOpenFilePathAsync([
                new FilePickerFileType(LocalizationManager.LinkListFileType)
                {
                    Patterns = ["*.txt", "*.csv"],
                },
                FilePickerFileTypes.All,
            ]);

            if (string.IsNullOrWhiteSpace(filePath))
                return;

            var links = LinkListParser.Parse(await File.ReadAllTextAsync(filePath));
            if (!links.Any())
            {
                _snackbarManager.Notify(LocalizationManager.LinkListEmptyMessage);
                return;
            }

            Query = string.Join('\n', links);
        }
        catch (Exception ex)
        {
            await _dialogManager.ShowDialogAsync(
                _viewModelManager.GetMessageBoxViewModel(LocalizationManager.ErrorTitle, ex.Message)
            );

            return;
        }

        if (ProcessQueryCommand.CanExecute(null))
            await ProcessQueryCommand.ExecuteAsync(null);
    }

    private void RemoveDownload(DownloadViewModel download)
    {
        Downloads.Remove(download);
        download.CancelCommand.ExecuteIfCan(null);
        download.Dispose();
    }

    [RelayCommand]
    private void RemoveSuccessfulDownloads()
    {
        foreach (var download in Downloads.ToArray())
        {
            if (download.Status == DownloadStatus.Completed)
                RemoveDownload(download);
        }
    }

    [RelayCommand]
    private void RemoveInactiveDownloads()
    {
        foreach (var download in Downloads.ToArray())
        {
            if (
                download.Status
                is DownloadStatus.Completed
                    or DownloadStatus.Failed
                    or DownloadStatus.Canceled
            )
                RemoveDownload(download);
        }
    }

    [RelayCommand]
    private void RestartDownload(DownloadViewModel download)
    {
        var position = Math.Max(0, Downloads.IndexOf(download));
        RemoveDownload(download);

        var newDownload = download.DownloadOption is not null
            ? _viewModelManager.GetDownloadViewModel(
                download.Video!,
                download.DownloadOption,
                download.FilePath!,
                download.ClipStart,
                download.ClipEnd
            )
            : _viewModelManager.GetDownloadViewModel(
                download.Video!,
                download.DownloadPreference!,
                download.FilePath!,
                download.ClipStart,
                download.ClipEnd
            );

        EnqueueDownload(newDownload, position);
    }

    [RelayCommand]
    private void RestartFailedDownloads()
    {
        foreach (var download in Downloads.ToArray())
        {
            if (download.Status == DownloadStatus.Failed)
                RestartDownload(download);
        }
    }

    [RelayCommand]
    private void CancelAllDownloads()
    {
        foreach (var download in Downloads)
            download.CancelCommand.ExecuteIfCan(null);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            CancelAllDownloads();

            _eventSubscription.Dispose();
            _downloadSemaphore.Dispose();
        }

        base.Dispose(disposing);
    }
}
