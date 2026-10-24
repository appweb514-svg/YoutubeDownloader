# Plan — 10 fonctionnalités « école » (branche feature/interface-ecole)

Contexte : fork de Tyrrrz/YoutubeDownloader (Avalonia 12, .NET 10, MVVM CommunityToolkit, Material.Avalonia).
L'interface « Vidéothèque » est déjà en place (DashboardView, réglages Établissement, `DefaultDownloadDirPath`).
Build : `export PATH=$HOME/.dotnet:$PATH DOTNET_ROOT=$HOME/.dotnet; dotnet build YoutubeDownloader/YoutubeDownloader.csproj -v q`
(CSharpier.MsBuild formate/vérifie au build : 0 avertissement attendu.)

Règles transverses
- Tout nouveau texte visible : propriété dans `Localization/LocalizationManager.cs` (section School) + entrées EN et FR
  (`LocalizationManager.English.cs`, `LocalizationManager.French.cs`). Les autres langues retombent sur l'anglais.
- Nouveaux réglages : `[ObservableProperty]` dans `Services/SettingsService.cs`, exposés dans `SettingsViewModel`
  (même style que l'existant) et affichés dans `SettingsView.axaml` (sections avec titres comme « Établissement »).
- Nouveaux dialogues : suivre le couple ViewModel/View existant (voir `Framework/ViewManager.cs`, `ViewModelManager.cs`,
  enregistrement DI dans `App.axaml.cs`).
- Garder le style du code environnant (commentaires rares, noms explicites). Pas de nouveau paquet NuGet sauf nécessité.

## 1. Découpage d'un extrait (début / fin)
- `DownloadSingleSetupView` : deux champs « Début » / « Fin » (format `h:mm:ss` ou `mm:ss`, vides = vidéo entière), validation.
- `DownloadViewModel` : `TimeSpan? ClipStart`, `TimeSpan? ClipEnd` ; passés par `ViewModelManager.GetDownloadViewModel` (surcharge optionnelle).
- Après téléchargement (dans `DashboardViewModel.EnqueueDownload`), si un extrait est défini : nouvelle méthode Core
  `FFmpeg.TrimAsync(ffmpegPath, input, output, start, end, ct)` qui lance ffmpeg (`-ss start -to end -i input` + réencodage
  par défaut du conteneur, `-y`), puis remplace le fichier. Chemin ffmpeg : `settings.FFmpegFilePath ?? FFmpeg.TryGetCliFilePath() ?? "ffmpeg"`.
- Le nom de fichier n'a pas besoin de changer. Restart d'un téléchargement : conserver l'extrait.

## 2. Préréglage « Classe » en un clic
- Bouton « Préréglage classe » dans `DownloadSingleSetupView` et `DownloadMultipleSetupView` :
  MP4, meilleure qualité ≤ 720p (single : choisir l'option MP4 de plus haute qualité ≤ 720p ; multiple : `Container.Mp4` + `UpTo720p`).
- Réglage `IsClassPresetDefault` (bool, défaut false) : si vrai, le préréglage est appliqué à l'ouverture des dialogues.

## 3. Sous-titres : fichier .srt séparé + langue
- Réglages : `ShouldSaveSubtitleFiles` (bool, défaut false), `PreferredSubtitleLanguage` (string, défaut "fr" ; vide = toutes).
- `VideoDownloader.DownloadVideoAsync` : filtrer les pistes injectées par code langue préféré quand il est renseigné
  (comparer `track.Language.Code` en début de chaîne, ex. "fr" ↔ "fr-FR" ; si aucune piste ne correspond, ne rien filtrer).
- Nouvelle méthode Core `DownloadSubtitleFilesAsync(filePath, video, languageCode, ct)` : écrit `<fichier>.<lang>.srt`
  via `_youtube.Videos.ClosedCaptions.DownloadAsync(trackInfo, path)`. Appelée après téléchargement si le réglage est actif
  (erreurs non bloquantes, comme les tags). Si un extrait est défini, ne pas décaler les sous-titres (documenter la limite).

## 4. Rangement automatique par classe / matière
- Dashboard : champ « Classer dans » (AutoCompleteBox ou TextBox + liste) sous la barre de recherche, ex. `CM2/Sciences`.
  Visible seulement si `DefaultDownloadDirPath` est défini. Réglages : `CurrentCategory` (string?), `RecentCategories` (List<string>, 10 max).
- Les dialogues single/multiple utilisent `Path.Combine(DefaultDownloadDirPath, CurrentCategory)` quand défini (nettoyer
  les caractères invalides de chaque segment, interdire `..`). Créer le dossier.

## 5. Fiche de source à côté de chaque vidéo
- Réglage `ShouldWriteSourceFile` (bool, défaut true).
- Après téléchargement réussi : écrire `<fichier sans extension>.source.txt` (UTF-8) : titre, chaîne, URL de la vidéo
  (`https://www.youtube.com/watch?v={id}`), URL de la chaîne, durée, extrait (si défini), date de téléchargement,
  établissement (`SchoolName`), et une ligne « Licence : à vérifier sur la page de la vidéo (Creative Commons, exception pédagogique…) ».
  Texte en français et anglais selon la langue (passer par la localisation). Non bloquant en cas d'erreur.

## 6. Mode verrouillé administré
- Réglages : `AdminPinHash` (string?), `AdminPinSalt` (string?), `MaxVideoQuality` (VideoQualityPreference, défaut Highest).
- Section « Administration » dans les paramètres : définir / supprimer le code PIN, plafond de qualité.
- Si un PIN est défini : ouvrir les Paramètres ou le Compte YouTube demande le PIN (nouveau dialogue `PinPromptViewModel`/`PinPromptView`,
  champ masqué, retour bool). Hash SHA-256 de salt+PIN (`System.Security.Cryptography`), comparaison à temps constant.
- Plafond de qualité appliqué : single = filtrer `AvailableDownloadOptions` (garder audio seul + vidéos ≤ plafond) ;
  multiple = limiter les préférences proposées. Utiliser la hauteur de `VideoQuality` de l'option.
- Déploiement : le fichier de réglages peut déjà être imposé via la variable `YOUTUBEDOWNLOADER_SETTINGS_PATH` ;
  le documenter dans `.project/ARCHITECTURE.md` (pas de nouveau mécanisme).

## 7. Import d'une liste de liens (txt / csv)
- Bouton « Importer une liste » dans le dashboard (à côté du champ de saisie ou dans l'écran vide) → `DialogManager.PromptOpenFilePathAsync`
  filtré `*.txt;*.csv`. Extraire les liens/ID : pour chaque ligne, prendre la première cellule (séparateurs `,` `;` tab) non vide,
  ignorer les lignes commençant par `#`. Mettre le résultat dans `Query` (une entrée par ligne) puis exécuter `ProcessQueryCommand`.

## 8. Historique des téléchargements
- `Services/HistoryService.cs` : ajoute une ligne CSV (`;`, UTF-8 avec BOM pour Excel) dans `history.csv` placé à côté du fichier
  de réglages (`Path.GetDirectoryName(StartOptions.Current.SettingsPath)`) : date ISO, utilisateur (`Environment.UserName`),
  titre, URL, fichier, statut (Terminé/Échec/Annulé), extrait. Échapper les guillemets.
- Appelé à la fin de chaque téléchargement (`EnqueueDownload`, finally selon statut). Thread-safe (verrou).
- Dialogue « Historique » (bouton dans l'en-tête) : liste des 200 dernières entrées (DataGrid lecture seule), boutons
  « Ouvrir le fichier CSV » et « Fermer ».

## 9. Limite de débit + file programmée
- Réglage `MaxDownloadRateKBps` (int, 0 = illimité ; slider/zone de saisie dans les paramètres).
- Core : `Utils/ThrottlingHandler.cs` (DelegatingHandler) qui enveloppe le flux de réponse dans un `ThrottledStream`
  partagé (seau à jetons global, limite modifiable via une propriété statique `Http.MaxBytesPerSecond`).
  `Http.Client` construit avec `new HttpClient(new ThrottlingHandler(new SocketsHttpHandler()))`. Copier les en-têtes de contenu.
  Le Dashboard met à jour la limite via `WatchProperty`.
- File programmée : réglage `ScheduledStartTime` (string "HH:mm", défaut "18:00"). Interrupteur « Télécharger plus tard (à partir de HH:mm) »
  dans le dashboard (`IsDeferredMode`). Les téléchargements ajoutés dans ce mode portent `ScheduledAt` (prochaine occurrence de l'heure) ;
  `EnqueueDownload` attend (`Task.Delay` annulable) avant d'acquérir le sémaphore ; statut « Programmé à HH:mm » affiché
  (nouveau `DownloadStatus.Scheduled` ou texte dédié ; mettre à jour compteurs et styles de statut).

## 10. Aperçu intégré avant téléchargement
- Bouton « Aperçu » dans `DownloadSingleSetupView` → dialogue `VideoPreviewViewModel`/`VideoPreviewView` avec `NativeWebView`
  (comme `AuthSetupView`) sur `https://www.youtube-nocookie.com/embed/{id}?start={secondes}` (prend le début de l'extrait s'il est défini).
  Bouton « Fermer ». Si la WebView n'est pas disponible, ouvrir l'URL dans le navigateur (`Process.StartShellExecute`).

## Vérification attendue
- Build sans erreur ni avertissement après chaque fonctionnalité.
- Tests Core existants (s'il y en a) verts : `dotnet test` sur les projets de test présents.
- Rapport final : liste par fonctionnalité de ce qui est fait, fichiers touchés, limites connues.
