# Décisions

## 2026-10-24 — Interface « Vidéothèque » pour l'école
- Contexte : l'application doit être utilisable par des enseignants peu techniques.
- Décision : palette bleu/vert, en-tête avec nom de l'établissement, boutons avec libellés, guide en 3 étapes et rappel sur le droit d'auteur à l'écran vide, liste de téléchargements en cartes (miniature, titre, barre de progression), compteurs et actions groupées visibles (plus de menu contextuel caché). Traductions ajoutées en FR et EN ; les autres langues se rabattent sur l'anglais pour les nouveaux textes.
- Conséquences : `DashboardView.axaml` réécrit (DataGrid remplacé par ItemsControl) ; nouvelles clés de localisation dans la section « School ».

## 2026-10-24 — Dossier de téléchargement par défaut
- Contexte : en classe, choisir un dossier à chaque fois fait perdre du temps ; les écoles ont souvent un lecteur partagé.
- Décision : réglage `DefaultDownloadDirPath` ; s'il est défini, les dialogues d'enregistrement sont sautés (noms uniques garantis) et un bouton « Ouvrir le dossier » apparaît.
- Conséquences : si le dossier est vide, le comportement d'origine (demander à chaque fois) est conservé.

## 2026-10-24 — Contournement du cookie SOCS périmé
- Contexte : YoutubeExplode 6.6.2 envoie un cookie de consentement daté du 2025-10-03, expiré après 13 mois → redirection vers consent.youtube.com.
- Décision : `ConsentCookie.WithFreshConsent` génère un cookie à la date du jour, ajouté avant les cookies utilisateur (il remplace celui de la bibliothèque). Ne compte pas comme authentification.
- Conséquences : à retirer quand une version de YoutubeExplode intégrant Tyrrrz/YoutubeExplode#975 sera publiée.

## 2026-10-24 — Les 10 fonctionnalités « école »
- Contexte : rendre l'outil adapté à un usage en classe et administrable par l'établissement (détail : PLAN-fonctionnalites-ecole.md).
- Décisions :
  - Extrait : découpage par FFmpeg après téléchargement, avec réencodage (précision à l'image près) et copie des pistes de sous-titres.
  - Préréglage classe : MP4 ≤ 720p, applicable par défaut.
  - Sous-titres : filtre par langue (défaut « fr ») et export .srt optionnel (non décalé pour un extrait).
  - Rangement par classe/matière sous le dossier par défaut, avec liste de catégories récentes.
  - Fiche de source `.source.txt` à côté de chaque vidéo (activée par défaut).
  - Mode administré : code PIN (SHA-256 salé) devant Paramètres/Compte, plafond de qualité ; déploiement via `YOUTUBEDOWNLOADER_SETTINGS_PATH`.
  - Import de listes txt/csv, historique CSV (anti-formules Excel), limite de débit globale (seau à jetons dans un DelegatingHandler), file programmée à une heure donnée.
  - Aperçu : lecteur youtube-nocookie dans le dialogue de téléchargement (un seul dialogue à la fois dans DialogManager).
- Conséquences : le PIN protège l'interface, pas le fichier de réglages ; le découpage allonge le temps de traitement sans progression affichée ; l'aperçu peut être refusé par YouTube (erreur 153) → bouton « Ouvrir dans le navigateur ».

## 2026-10-24 — Mises à jour automatiques désactivées
- Contexte : l'updater (Onova) téléchargeait les versions du dépôt d'origine, ce qui aurait remplacé l'édition école par l'application originale.
- Décision : `UpdateService.IsAvailable = false`, aucun gestionnaire de mise à jour créé ; réglage masqué dans les paramètres.
- Conséquences : mises à jour manuelles ; pour les réactiver, publier des paquets `YoutubeDownloader.<rid>.zip` sur le fork et pointer `GithubPackageResolver` vers appweb514-svg/YoutubeDownloader.

## 2026-10-24 — Nom Youtube4School et thèmes de couleur
- Contexte : l'école veut une identité propre et pouvoir choisir les couleurs de l'interface.
- Décision : `Program.Name = "Youtube4School"` (affichage seulement ; assembly, identifiant de bundle et chemins de paramètres inchangés). Nouveau réglage `ColorTheme` (enum dans `Framework/ColorTheme.cs`, couples primaire/secondaire clair/sombre) appliqué par `App.InitializeTheme` et réappliqué à chaud via `WatchProperty`.
- Conséquences : les paramètres existants restent compatibles (défaut = Bleu école). Les fonds de page (PageBrush/StepBadgeBrush) restent neutres et ne suivent pas la palette.

## 2026-10-24 — Extraits : progression et sous-titres recalés ; en-tête compact
- Contexte : le découpage FFmpeg ne montrait aucune progression et les `.srt` séparés gardaient les horaires de la vidéo complète.
- Décision : `FFmpeg.TrimAsync` lit `-progress pipe:1` (out_time_us) rapporté sur la durée attendue de l'extrait ; `DownloadViewModel.IsTrimming` affiche « Découpage de l'extrait… X % ». `DownloadSubtitleFilesAsync` accepte `clipStart/clipEnd` et écrit le SRT via `Core/Utils/SubRip` (sous-titres filtrés, bornés et décalés). En dessous de 760 px, l'en-tête passe en classe `compact` (icônes seules).
- Conséquences : traductions DE/ES/HU/UK/ZH des textes école générées automatiquement, à faire relire par des locuteurs.

## 2026-10-24 — Distribution portable sans droits administrateur (Windows)
- Contexte : les postes de l'école n'accordent pas les droits administrateur.
- Décision : pas d'installateur ; publication autonome (self-contained, aucun runtime .NET à installer) en zip `Youtube4School-portable.<rid>.zip` avec `LISEZMOI.txt`. Manifeste `requestedExecutionLevel=asInvoker`. `StartOptions.DataDirPath` : dossier de l'exe s'il est inscriptible (portable, clé USB), sinon `%LOCALAPPDATA%\Youtube4School` ; réglages, historique et FFmpeg téléchargé y sont rangés (chemin FFmpeg mémorisé s'il n'est pas trouvé par sondage).
- Conséquences : l'exe n'est pas signé → avertissement SmartScreen contournable sans droits admin. Paquet ~79 Mo (non élagué, PublishTrimmed=false hérité).
