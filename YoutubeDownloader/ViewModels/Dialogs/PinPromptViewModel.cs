using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeDownloader.Services;
using YoutubeDownloader.Utils;

namespace YoutubeDownloader.ViewModels.Dialogs;

public partial class PinPromptViewModel(
    LocalizationManager localizationManager,
    SettingsService settingsService
) : DialogViewModelBase
{
    public LocalizationManager LocalizationManager { get; } = localizationManager;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ConfirmCommand))]
    public partial string? Pin { get; set; }

    [ObservableProperty]
    public partial bool IsPinWrong { get; set; }

    private bool CanConfirm() => !string.IsNullOrWhiteSpace(Pin);

    [RelayCommand(CanExecute = nameof(CanConfirm))]
    private void Confirm()
    {
        if (PinHasher.Verify(Pin, settingsService.AdminPinSalt, settingsService.AdminPinHash))
        {
            Close(true);
            return;
        }

        IsPinWrong = true;
        Pin = null;
    }
}
