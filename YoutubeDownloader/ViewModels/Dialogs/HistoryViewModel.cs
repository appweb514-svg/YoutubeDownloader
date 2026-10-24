using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PowerKit.Extensions;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeDownloader.Services;

namespace YoutubeDownloader.ViewModels.Dialogs;

public partial class HistoryViewModel(
    ViewModelManager viewModelManager,
    DialogManager dialogManager,
    LocalizationManager localizationManager,
    HistoryService historyService
) : DialogViewModelBase
{
    public LocalizationManager LocalizationManager { get; } = localizationManager;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsEmpty))]
    public partial IReadOnlyList<HistoryEntry> Entries { get; private set; } = [];

    public bool IsEmpty => Entries.Count == 0;

    public override async Task InitializeAsync()
    {
        try
        {
            Entries = await Task.Run(() => historyService.GetRecentEntries(200));
        }
        catch (Exception ex)
        {
            await dialogManager.ShowDialogAsync(
                viewModelManager.GetMessageBoxViewModel(LocalizationManager.ErrorTitle, ex.Message)
            );
        }
    }

    [RelayCommand]
    private void OpenCsvFile()
    {
        if (File.Exists(historyService.FilePath))
            Process.StartShellExecute(historyService.FilePath);
    }
}
