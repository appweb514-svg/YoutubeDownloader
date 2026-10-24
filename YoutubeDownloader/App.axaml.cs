using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using Material.Styles.Themes;
using Microsoft.Extensions.DependencyInjection;
using PowerKit.Extensions;
using YoutubeDownloader.Framework;
using YoutubeDownloader.Localization;
using YoutubeDownloader.Services;
using YoutubeDownloader.Utils.Extensions;
using YoutubeDownloader.ViewModels;
using YoutubeDownloader.ViewModels.Components;
using YoutubeDownloader.ViewModels.Dialogs;

namespace YoutubeDownloader;

public partial class App : Application, IDisposable
{
    private readonly ServiceProvider _services;
    private readonly SettingsService _settingsService;

    private readonly IDisposable _eventSubscription;

    private bool _isDisposed;

    public App()
    {
        var services = new ServiceCollection();

        // Framework
        services.AddSingleton<DialogManager>();
        services.AddSingleton<SnackbarManager>();
        services.AddSingleton<ViewManager>();
        services.AddSingleton<ViewModelManager>();

        // Localization
        services.AddSingleton<LocalizationManager>();

        // Services
        services.AddSingleton<SettingsService>();
        services.AddSingleton<UpdateService>();
        services.AddSingleton<HistoryService>();

        // View models
        services.AddTransient<MainViewModel>();
        services.AddTransient<DashboardViewModel>();
        services.AddTransient<DownloadViewModel>();
        services.AddTransient<VideoPreviewViewModel>();
        services.AddTransient<AuthSetupViewModel>();
        services.AddTransient<DownloadMultipleSetupViewModel>();
        services.AddTransient<DownloadSingleSetupViewModel>();
        services.AddTransient<HistoryViewModel>();
        services.AddTransient<MessageBoxViewModel>();
        services.AddTransient<PinPromptViewModel>();
        services.AddTransient<SettingsViewModel>();

        _services = services.BuildServiceProvider(true);
        _settingsService = _services.GetRequiredService<SettingsService>();

        // Re-initialize the theme when the user changes it
        _eventSubscription = _settingsService.WatchProperty(
            o => o.Theme,
            v =>
            {
                RequestedThemeVariant = v switch
                {
                    ThemeVariant.Light => Avalonia.Styling.ThemeVariant.Light,
                    ThemeVariant.Dark => Avalonia.Styling.ThemeVariant.Dark,
                    _ => Avalonia.Styling.ThemeVariant.Default,
                };

                InitializeTheme();
            }
        );
    }

    private void InitializeTheme()
    {
        var actualTheme = RequestedThemeVariant?.Key switch
        {
            "Light" => PlatformThemeVariant.Light,
            "Dark" => PlatformThemeVariant.Dark,
            _ => PlatformSettings?.GetColorValues().ThemeVariant ?? PlatformThemeVariant.Light,
        };

        this.LocateMaterialTheme<MaterialThemeBase>().CurrentTheme =
            actualTheme == PlatformThemeVariant.Light
                // School palette: calm blue for structure, green for progress and success
                ? Theme.Create(Theme.Light, Color.Parse("#1F4E9C"), Color.Parse("#0F8A6A"))
                : Theme.Create(Theme.Dark, Color.Parse("#8AB4F8"), Color.Parse("#34D399"));
    }

    public override void Initialize()
    {
        base.Initialize();

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Load settings
        _settingsService.Load();

        // Initialize and configure the main window
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var viewManager = _services.GetRequiredService<ViewManager>();
            var viewModelManager = _services.GetRequiredService<ViewModelManager>();

            desktop.MainWindow = viewManager.TryBindWindow(viewModelManager.GetMainViewModel());

            // Although `App.Dispose()` is invoked from `Program.Main(...)`, on some platforms
            // it may be called too late in the shutdown lifecycle. Attach an exit
            // handler to ensure timely disposal as a safeguard.
            // https://github.com/Tyrrrz/YoutubeDownloader/issues/795
            desktop.Exit += (_, _) => Dispose();
        }

        // Initialize the theme for the first time; must be done after the main window is created
        InitializeTheme();

        base.OnFrameworkInitializationCompleted();
    }

    private void Application_OnActualThemeVariantChanged(object? sender, EventArgs args) =>
        // Re-initialize the theme when the system theme changes
        InitializeTheme();

    public void Dispose()
    {
        if (_isDisposed)
            return;

        _isDisposed = true;

        _eventSubscription.Dispose();
        _services.Dispose();
    }
}

public partial class App
{
    public static void Shutdown(int exitCode = 0)
    {
        if (Current?.ApplicationLifetime?.TryShutdown(exitCode) != true)
            Environment.Exit(exitCode);
    }
}
