# Architecture

- `YoutubeDownloader/` : application Avalonia 12 (.NET 10), MVVM (CommunityToolkit), thème Material.Avalonia.
  - `Views/Components/DashboardView.axaml` : écran principal (en-tête, saisie, guide vide, liste des téléchargements).
  - `ViewModels/Components/DashboardViewModel.cs` : résolution des requêtes, file de téléchargements, compteurs.
  - `Services/SettingsService.cs` : réglages persistés (dont `SchoolName`, `DefaultDownloadDirPath`).
  - `Localization/` : textes par langue ; repli sur l'anglais.
- `YoutubeDownloader.Core/` : résolution (QueryResolver), téléchargement (VideoDownloader, FFmpeg), tags.
  - `Utils/ConsentCookie.cs` : cookie SOCS frais passé à chaque `YoutubeClient`.
