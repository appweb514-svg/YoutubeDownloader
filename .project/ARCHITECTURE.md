# Architecture

- `YoutubeDownloader/` : application Avalonia 12 (.NET 10), MVVM (CommunityToolkit), thème Material.Avalonia.
  - `Views/Components/DashboardView.axaml` : écran principal (en-tête, saisie, guide vide, liste des téléchargements).
  - `ViewModels/Components/DashboardViewModel.cs` : résolution des requêtes, file de téléchargements, compteurs.
  - `Services/SettingsService.cs` : réglages persistés (dont `SchoolName`, `DefaultDownloadDirPath`).
  - `Localization/` : textes par langue ; repli sur l'anglais.
- `YoutubeDownloader.Core/` : résolution (QueryResolver), téléchargement (VideoDownloader, FFmpeg), tags.
  - `Utils/ConsentCookie.cs` : cookie SOCS frais passé à chaque `YoutubeClient`.

## Fonctionnalités « école » (feature/interface-ecole)

- Extrait : `DownloadViewModel.ClipStart/ClipEnd` ; après téléchargement, `FFmpeg.TrimAsync` (Core) réencode `-ss/-to` dans `<nom>.clip.<ext>` puis remplace le fichier. Saisie et validation : `Utils/ClipTime.cs`.
- Préréglage classe (MP4 ≤ 720p) dans les deux dialogues de configuration ; `IsClassPresetDefault` l'applique à l'ouverture.
- Sous-titres : `VideoDownloader.FilterTracksByLanguage` (langue préférée, repli sur toutes) et `DownloadSubtitleFilesAsync` (`<nom>.<lang>.srt`, non décalés pour un extrait).
- Rangement : `CurrentCategory` / `RecentCategories` ; `SettingsService.TryGetDownloadDirPath()` combine le dossier par défaut et la catégorie nettoyée (`Utils/CategoryPath.cs`, `..` interdit).
- Fiche de source : `<nom>.source.txt` (UTF-8) écrit par `DashboardViewModel.WriteSourceFileAsync`, textes localisés.
- Mode verrouillé : PIN haché SHA-256(salt+PIN) (`Utils/PinHasher.cs`), demandé par `PinPromptViewModel/View` avant Paramètres et Compte YouTube ; plafond `MaxVideoQuality` appliqué aux options proposées.
- Import de liste : `Utils/LinkListParser.cs` (première cellule, `#` = commentaire) → `Query` → `ProcessQueryCommand`.
- Historique : `Services/HistoryService.cs` (CSV `;`, UTF-8 BOM, `history.csv` à côté du fichier de réglages) ; dialogue `HistoryViewModel/View`.
- Débit : `Core/Utils/ThrottlingHandler.cs` (seau à jetons global, `Http.MaxBytesPerSecond`) branché sur `Http.Client` ; file programmée via `DownloadStatus.Scheduled` et `Utils/ScheduleTime.cs`.
- Aperçu : `VideoPreviewViewModel/View` (NativeWebView sur youtube-nocookie) affiché dans le dialogue de configuration (pas de dialogue imbriqué : `DialogManager` n'en ouvre qu'un à la fois).

## Déploiement en établissement

- Le fichier de réglages peut être imposé avec la variable d'environnement `YOUTUBEDOWNLOADER_SETTINGS_PATH` (chemin de fichier, ou dossier → `Settings.dat`) : y préremplir `SchoolName`, `DefaultDownloadDirPath`, `MaxVideoQuality`, `MaxDownloadRateKBps`, `AdminPinHash`/`AdminPinSalt`, etc.
- `history.csv` est créé dans le même dossier que ce fichier de réglages.
- Le PIN protège l'interface, pas le fichier : protéger le fichier de réglages par les droits du système (lecture seule pour les élèves) si nécessaire.
