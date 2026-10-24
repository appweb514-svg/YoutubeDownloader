using Avalonia.Interactivity;
using YoutubeDownloader.Framework;
using YoutubeDownloader.ViewModels.Dialogs;

namespace YoutubeDownloader.Views.Dialogs;

public partial class PinPromptView : UserControl<PinPromptViewModel>
{
    public PinPromptView() => InitializeComponent();

    private void UserControl_OnLoaded(object? sender, RoutedEventArgs args) => PinTextBox.Focus();
}
