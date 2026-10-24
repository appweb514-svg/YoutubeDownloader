using System.Collections.Generic;

namespace YoutubeDownloader.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> FrenchLocalization = new Dictionary<
        string,
        string
    >
    {
        // Dashboard
        [nameof(QueryPlaceholderText)] = "URL ou requête de recherche",
        [nameof(QueryTooltip)] =
            "Toute URL ou ID YouTube valide est acceptée. Ajoutez un point d'interrogation (?) pour rechercher par texte.",
        [nameof(ProcessQueryTooltip)] = "Traiter la requête (Entrée)",
        [nameof(AuthTooltip)] = "Authentification",
        [nameof(SettingsTooltip)] = "Paramètres",
        [nameof(DashboardPlaceholder)] = """
            Collez une **URL** ou entrez une **requête de recherche** pour commencer
            Appuyez sur **Shift+Entrée** pour ajouter plusieurs éléments
            """,
        [nameof(DownloadsFileColumnHeader)] = "Fichier",
        [nameof(DownloadsStatusColumnHeader)] = "Statut",
        [nameof(ContextMenuRemoveSuccessful)] = "Supprimer les téléchargements réussis",
        [nameof(ContextMenuRemoveInactive)] = "Supprimer les téléchargements inactifs",
        [nameof(ContextMenuRestartFailed)] = "Relancer les téléchargements échoués",
        [nameof(ContextMenuCancelAll)] = "Annuler tous les téléchargements",
        [nameof(DownloadStatusEnqueued)] = "En attente...",
        [nameof(DownloadStatusCompleted)] = "Terminé",
        [nameof(DownloadStatusCanceled)] = "Annulé",
        [nameof(DownloadStatusFailed)] = "Échec",
        [nameof(ClickToCopyErrorTooltip)] = "Note : Cliquez pour copier ce message d'erreur",
        [nameof(ShowFileTooltip)] = "Afficher le fichier",
        [nameof(PlayTooltip)] = "Lire",
        [nameof(CancelDownloadTooltip)] = "Annuler le téléchargement",
        [nameof(RestartDownloadTooltip)] = "Relancer le téléchargement",
        // School
        [nameof(AppHeaderTitle)] = "Vidéothèque",
        [nameof(AppHeaderSubtitle)] = "Téléchargez des vidéos pour vos cours",
        [nameof(AddToLibraryButton)] = "Ajouter",
        [nameof(AccountButton)] = "Compte YouTube",
        [nameof(SettingsButton)] = "Paramètres",
        [nameof(SchoolQueryPlaceholderText)] =
            "Collez un lien YouTube (vidéo, playlist ou chaîne) ou tapez des mots-clés suivis de ?",
        [nameof(StepCopyTitle)] = "Copiez le lien",
        [nameof(StepCopyText)] = "Sur YouTube, cliquez sur Partager puis Copier",
        [nameof(StepPasteTitle)] = "Collez-le ci-dessus",
        [nameof(StepPasteText)] = "Plusieurs liens ? Un par ligne (Maj+Entrée)",
        [nameof(StepDownloadTitle)] = "Choisissez la qualité",
        [nameof(StepDownloadText)] = "Le MP4 se lit sur tous les ordinateurs de la classe",
        [nameof(CopyrightNoticeTitle)] = "Respectez le droit d'auteur",
        [nameof(CopyrightNoticeMessage)] =
            "Ne téléchargez que des vidéos dont l'usage en classe est autorisé : licence Creative Commons, exception pédagogique ou accord de l'auteur. Vérifiez les règles de votre établissement.",
        [nameof(DownloadsListTitle)] = "Téléchargements",
        [nameof(SummaryActiveLabel)] = "en cours",
        [nameof(SummaryCompletedLabel)] = "terminé(s)",
        [nameof(SummaryFailedLabel)] = "en échec",
        [nameof(RetryFailedButton)] = "Relancer les échecs",
        [nameof(ClearListButton)] = "Nettoyer la liste",
        [nameof(CancelAllButton)] = "Tout annuler",
        [nameof(OpenLibraryFolderButton)] = "Ouvrir le dossier",
        [nameof(SchoolSectionLabel)] = "Établissement",
        [nameof(SchoolNameLabel)] = "Nom de l'établissement",
        [nameof(SchoolNameTooltip)] = "Affiché en haut de la fenêtre",
        [nameof(SchoolNamePlaceholderText)] = "ex. École Jules Ferry",
        [nameof(DefaultDownloadDirLabel)] = "Dossier de téléchargement",
        [nameof(DefaultDownloadDirTooltip)] =
            "Les vidéos y sont enregistrées automatiquement, sans le demander à chaque fois (par exemple un lecteur partagé). Laissez vide pour choisir à chaque fois.",
        [nameof(DefaultDownloadDirPlaceholderText)] = "Demander à chaque fois",
        [nameof(GeneralSectionLabel)] = "Général",
        [nameof(ClipSectionLabel)] = "Extrait (facultatif)",
        [nameof(ClipStartLabel)] = "Début",
        [nameof(ClipEndLabel)] = "Fin",
        [nameof(ClipPlaceholderText)] = "h:mm:ss ou mm:ss",
        [nameof(ClipTooltip)] =
            "Ne garder qu'une partie de la vidéo. Laissez vide pour télécharger la vidéo entière.",
        [nameof(ClipInvalidFormatMessage)] = "Utilisez le format h:mm:ss ou mm:ss (ex. 1:30).",
        [nameof(ClipEndBeforeStartMessage)] = "La fin doit être après le début.",
        [nameof(ClipOutOfRangeMessage)] = "L'extrait dépasse la durée de la vidéo.",
        [nameof(ClipLabel)] = "Extrait",
        [nameof(ClassPresetButton)] = "Préréglage classe",
        [nameof(ClassPresetTooltip)] =
            "MP4, meilleure qualité jusqu'à 720p : lisible sur tous les ordinateurs et vidéoprojecteurs de la classe",
        [nameof(ClassPresetDefaultLabel)] = "Préréglage classe par défaut",
        [nameof(ClassPresetDefaultTooltip)] =
            "Sélectionner automatiquement MP4 jusqu'à 720p au moment de choisir le format",
        [nameof(SaveSubtitleFilesLabel)] = "Enregistrer les sous-titres (.srt)",
        [nameof(SaveSubtitleFilesTooltip)] =
            "Enregistrer aussi les sous-titres à côté de la vidéo, dans des fichiers .srt séparés (ils ne sont pas décalés si seul un extrait est gardé)",
        [nameof(SubtitleLanguageLabel)] = "Langue des sous-titres",
        [nameof(SubtitleLanguageTooltip)] =
            "Code de la langue des sous-titres à garder (ex. fr, en). Laissez vide pour garder toutes les langues. Si la vidéo n'a pas de sous-titres dans cette langue, tous sont gardés.",
        [nameof(SubtitleLanguagePlaceholderText)] = "Toutes les langues",
        [nameof(CategoryLabel)] = "Classer dans",
        [nameof(CategoryPlaceholderText)] = "ex. CM2/Sciences",
        [nameof(CategoryTooltip)] =
            "Sous-dossier du dossier de téléchargement pour les prochains téléchargements (classe, matière…). Utilisez / pour créer plusieurs niveaux. Laissez vide pour enregistrer directement dans le dossier de téléchargement.",
        [nameof(WriteSourceFileLabel)] = "Créer une fiche de source",
        [nameof(WriteSourceFileTooltip)] =
            "Enregistrer à côté de chaque vidéo un fichier .source.txt avec le titre, la chaîne, le lien, la date de téléchargement et un rappel sur la licence, pour citer la source en classe",
        [nameof(SourceFileTitleLine)] = "Titre : {0}",
        [nameof(SourceFileChannelLine)] = "Chaîne : {0}",
        [nameof(SourceFileVideoUrlLine)] = "Vidéo : {0}",
        [nameof(SourceFileChannelUrlLine)] = "Page de la chaîne : {0}",
        [nameof(SourceFileDurationLine)] = "Durée : {0}",
        [nameof(SourceFileClipLine)] = "Extrait : {0}",
        [nameof(SourceFileDownloadedAtLine)] = "Téléchargé le : {0}",
        [nameof(SourceFileSchoolLine)] = "Établissement : {0}",
        [nameof(SourceFileLicenseLine)] =
            "Licence : à vérifier sur la page de la vidéo (Creative Commons, exception pédagogique…)",
        [nameof(AdminSectionLabel)] = "Administration",
        [nameof(AdminPinLabel)] = "Code PIN administrateur",
        [nameof(AdminPinTooltip)] =
            "Quand un code PIN est défini, il est demandé pour ouvrir les paramètres ou le compte YouTube",
        [nameof(AdminPinPlaceholderText)] = "4 caractères min.",
        [nameof(AdminPinSetButton)] = "Définir",
        [nameof(AdminPinActiveLabel)] = "Paramètres verrouillés par un code PIN",
        [nameof(AdminPinRemoveButton)] = "Supprimer le code",
        [nameof(MaxVideoQualityLabel)] = "Qualité maximale",
        [nameof(MaxVideoQualityTooltip)] =
            "Qualité vidéo la plus élevée proposée au téléchargement (économise la bande passante et l'espace disque)",
        [nameof(PinPromptTitle)] = "Accès verrouillé",
        [nameof(PinPromptMessage)] = "Saisissez le code PIN administrateur pour continuer.",
        [nameof(PinPlaceholderText)] = "Code PIN",
        [nameof(PinWrongMessage)] = "Code PIN incorrect, réessayez.",
        [nameof(UnlockButton)] = "DÉVERROUILLER",
        [nameof(ImportLinkListButton)] = "Importer une liste",
        [nameof(ImportLinkListTooltip)] =
            "Ouvrir un fichier .txt ou .csv avec un lien YouTube par ligne (première colonne pour un tableur). Les lignes commençant par # sont ignorées.",
        [nameof(LinkListFileType)] = "Liste de liens",
        [nameof(LinkListEmptyMessage)] = "Aucun lien trouvé dans ce fichier",
        [nameof(HistoryButton)] = "Historique",
        [nameof(HistoryTooltip)] = "Téléchargements effectués sur ce poste",
        [nameof(HistoryTitle)] = "Historique des téléchargements",
        [nameof(HistoryEmptyText)] = "Aucun téléchargement pour l'instant",
        [nameof(HistoryOpenCsvButton)] = "OUVRIR LE FICHIER CSV",
        [nameof(HistoryDateColumnHeader)] = "Date",
        [nameof(HistoryUserColumnHeader)] = "Utilisateur",
        [nameof(HistoryTitleColumnHeader)] = "Titre",
        [nameof(HistoryUrlColumnHeader)] = "URL",
        [nameof(HistoryFileColumnHeader)] = "Fichier",
        [nameof(HistoryStatusColumnHeader)] = "Statut",
        [nameof(DeferredModeLabel)] = "Télécharger plus tard (à partir de {0})",
        [nameof(DeferredModeTooltip)] =
            "Les vidéos ajoutées pendant que cette option est active attendent l'heure programmée (réglable dans les paramètres) avant d'être téléchargées, par exemple pour ne pas ralentir le réseau pendant les cours. Laissez l'application ouverte.",
        [nameof(DownloadStatusScheduled)] = "Programmé à {0}",
        [nameof(SummaryScheduledLabel)] = "programmés",
        [nameof(MaxDownloadRateLabel)] = "Limite de débit (Ko/s)",
        [nameof(MaxDownloadRateTooltip)] =
            "Vitesse de téléchargement totale maximale, en kilo-octets par seconde, pour partager le réseau de l'établissement. 0 = illimité.",
        [nameof(ScheduledStartTimeLabel)] = "Heure de téléchargement programmé",
        [nameof(ScheduledStartTimeTooltip)] =
            "Heure (HH:mm) à laquelle démarrent les téléchargements ajoutés avec « Télécharger plus tard »",
        [nameof(PreviewButton)] = "Aperçu",
        [nameof(PreviewTooltip)] =
            "Regarder la vidéo ici avant de la télécharger (commence au début de l'extrait, s'il est défini)",
        [nameof(PreviewOpenInBrowserButton)] = "Ouvrir dans le navigateur",
        [nameof(PreviewCloseButton)] = "Fermer l'aperçu",
        // Settings
        [nameof(SettingsTitle)] = "Paramètres",
        [nameof(ThemeLabel)] = "Thème",
        [nameof(ThemeTooltip)] = "Thème d'interface préféré",
        [nameof(LanguageLabel)] = "Langue",
        [nameof(LanguageTooltip)] = "Langue d'affichage préférée pour l'interface utilisateur",
        [nameof(AutoUpdateLabel)] = "Mise à jour automatique",
        [nameof(AutoUpdateTooltip)] = """
            Effectuer des mises à jour automatiques à chaque démarrage.
            **Avertissement :** il est recommandé de laisser cette option activée pour assurer la compatibilité avec la dernière version de YouTube.
            """,
        [nameof(PersistAuthLabel)] = "Conserver l'authentification",
        [nameof(PersistAuthTooltip)] = """
            Enregistrer les cookies d'authentification dans un fichier pour les conserver entre les sessions.
            **Avertissement** : bien que les cookies soient stockés avec chiffrement, ils peuvent toujours être récupérés par un attaquant ayant accès à votre système.
            """,
        [nameof(InjectAltLanguagesLabel)] = "Injecter les langues alternatives",
        [nameof(InjectAltLanguagesTooltip)] =
            "Injecter des pistes audio en langues alternatives (si disponibles) dans les fichiers téléchargés",
        [nameof(InjectSubtitlesLabel)] = "Injecter les sous-titres",
        [nameof(InjectSubtitlesTooltip)] =
            "Injecter les sous-titres (si disponibles) dans les fichiers téléchargés",
        [nameof(InjectTagsLabel)] = "Injecter les balises média",
        [nameof(InjectTagsTooltip)] =
            "Injecter les balises média (si disponibles) dans les fichiers téléchargés",
        [nameof(SkipExistingFilesLabel)] = "Ignorer les fichiers existants",
        [nameof(SkipExistingFilesTooltip)] =
            "Lors du téléchargement de plusieurs vidéos, ignorer celles qui ont déjà des fichiers correspondants dans le répertoire de sortie",
        [nameof(FileNameTemplateLabel)] = "Modèle de nom de fichier",
        [nameof(FileNameTemplateTooltip)] = """
            Modèle utilisé pour générer les noms de fichiers des vidéos téléchargées.

            Jetons disponibles :
            **$num** — position de la vidéo dans la liste (si applicable)
            **$id** — ID de la vidéo
            **$title** — titre de la vidéo
            **$author** — auteur de la vidéo
            """,
        [nameof(ParallelLimitLabel)] = "Limite parallèle",
        [nameof(ParallelLimitTooltip)] =
            "Combien de téléchargements peuvent être actifs en même temps",
        [nameof(FFmpegPathLabel)] = "Chemin FFmpeg",
        [nameof(FFmpegPathTooltip)] =
            "Chemin vers l'exécutable FFmpeg. Laisser vide pour la détection automatique.",
        [nameof(FFmpegPathPlaceholderText)] = "Auto",
        [nameof(FFmpegPathResetTooltip)] = "Réinitialiser la détection automatique",
        [nameof(FFmpegPathBrowseTooltip)] = "Parcourir l'exécutable FFmpeg",
        // Auth Setup
        [nameof(AuthenticationTitle)] = "Authentification",
        [nameof(AuthenticatedText)] = "Vous êtes actuellement authentifié",
        [nameof(LogOutButton)] = "Se déconnecter",
        [nameof(AuthenticationPlaceholderText)] = """
            Chargement...

            Si le navigateur ne s'affiche pas :
            - Windows : installez Microsoft Edge WebView2 Runtime.
            - macOS : installez les dernières mises à jour du système.
            - Linux : installez GTK 3, WebKitGTK 4.1 et libsoup 3.
            """,
        // Download Single Setup
        [nameof(CopyMenuItem)] = "Copier",
        [nameof(LiveLabel)] = "En direct",
        [nameof(AudioLabel)] = "Audio",
        [nameof(UpscaledLabel)] = "Suréchantillonné",
        [nameof(FormatLabel)] = "Format",
        // Download Multiple Setup
        [nameof(ContainerLabel)] = "Conteneur",
        [nameof(VideoQualityLabel)] = "Qualité vidéo",
        // Common buttons
        [nameof(CloseButton)] = "FERMER",
        [nameof(DownloadButton)] = "TÉLÉCHARGER",
        [nameof(CancelButton)] = "ANNULER",
        // Dialog messages
        [nameof(UkraineSupportTitle)] = "Merci de soutenir l'Ukraine !",
        [nameof(UkraineSupportMessage)] = """
            Alors que la Russie mène une guerre génocidaire contre mon pays, je suis reconnaissant envers tous ceux qui continuent à soutenir l'Ukraine dans notre combat pour la liberté.

            Cliquez sur EN SAVOIR PLUS pour trouver des moyens d'aider.
            """,
        [nameof(LearnMoreButton)] = "EN SAVOIR PLUS",
        [nameof(UnstableBuildTitle)] = "Avertissement : build instable",
        [nameof(UnstableBuildMessage)] = """
            Vous utilisez une version de développement de {0}. Ces versions ne sont pas rigoureusement testées et peuvent contenir des bugs.

            Les mises à jour automatiques sont désactivées pour les versions de développement.

            Cliquez sur VOIR LES VERSIONS pour télécharger une version stable.
            """,
        [nameof(SeeReleasesButton)] = "VOIR LES VERSIONS",
        [nameof(FFmpegMissingTitle)] = "FFmpeg est manquant",
        [nameof(FFmpegMissingMessage)] = """
            FFmpeg est introuvable sur votre système. Il est requis pour que {0} fonctionne. Voulez-vous le télécharger maintenant ?

            Sinon, vous pouvez fermer cette boîte de dialogue et définir manuellement un chemin FFmpeg personnalisé dans les paramètres.
            """,
        [nameof(FFmpegDownloadingTitle)] = "Téléchargement de FFmpeg...",
        [nameof(FFmpegDownloadCompletedTitle)] = "FFmpeg téléchargé",
        [nameof(NothingFoundTitle)] = "Rien trouvé",
        [nameof(NothingFoundMessage)] =
            "Impossible de trouver des vidéos correspondant à la requête ou l'URL fournie",
        [nameof(ErrorTitle)] = "Erreur",
        [nameof(UpdateDownloadingMessage)] = "Téléchargement de la mise à jour {0} v{1}...",
        [nameof(UpdateReadyMessage)] =
            "La mise à jour a été téléchargée et sera installée à la fermeture",
        [nameof(UpdateInstallNowButton)] = "INSTALLER MAINTENANT",
        [nameof(UpdateFailedMessage)] = "Échec de la mise à jour de l'application",
    };
}
