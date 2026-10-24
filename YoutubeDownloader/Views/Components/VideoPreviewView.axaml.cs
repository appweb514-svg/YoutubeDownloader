using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;
using PowerKit.Extensions;
using YoutubeDownloader.Framework;
using YoutubeDownloader.ViewModels.Components;

namespace YoutubeDownloader.Views.Components;

public partial class VideoPreviewView : UserControl<VideoPreviewViewModel>
{
    public VideoPreviewView() => InitializeComponent();

    private void WebBrowser_OnEnvironmentRequested(
        object? sender,
        WebViewEnvironmentRequestedEventArgs args
    )
    {
        args.EnableDevTools = false;

        switch (args)
        {
            case WindowsWebView2EnvironmentRequestedEventArgs windowsArgs:
                windowsArgs.IsInPrivateModeEnabled = true;
                break;
            case AppleWKWebViewEnvironmentRequestedEventArgs appleArgs:
                appleArgs.NonPersistentDataStore = true;
                break;
            case GtkWebViewEnvironmentRequestedEventArgs gtkArgs:
                gtkArgs.EphemeralDataManager = true;
                break;
        }
    }

    private void WebBrowser_OnLoaded(object? sender, RoutedEventArgs args)
    {
        try
        {
            if (DataContext.EmbedUri is { } uri)
                WebBrowser.Source = uri;
        }
        catch
        {
            // No usable web view on this system: fall back to the default browser
            DataContext.OpenInBrowserCommand.ExecuteIfCan(null);
            DataContext.CloseCommand.ExecuteIfCan(null);
        }
    }
}
