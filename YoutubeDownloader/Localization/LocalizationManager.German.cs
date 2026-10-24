using System.Collections.Generic;

namespace YoutubeDownloader.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> GermanLocalization = new Dictionary<
        string,
        string
    >
    {
        // Dashboard
        [nameof(QueryPlaceholderText)] = "URL oder Suchanfrage",
        [nameof(QueryTooltip)] =
            "Jede gültige YouTube-URL oder -ID wird akzeptiert. Stellen Sie ein Fragezeichen (?) voran, um nach Text zu suchen.",
        [nameof(ProcessQueryTooltip)] = "Anfrage verarbeiten (Enter)",
        [nameof(AuthTooltip)] = "Authentifizierung",
        [nameof(SettingsTooltip)] = "Einstellungen",
        [nameof(DashboardPlaceholder)] = """
            **URL** einfügen oder **Suchanfrage** eingeben um den Download zu starten
            Drücken Sie **Shift+Enter** um mehrere Einträge hinzuzufügen
            """,
        [nameof(DownloadsFileColumnHeader)] = "Datei",
        [nameof(DownloadsStatusColumnHeader)] = "Status",
        [nameof(ContextMenuRemoveSuccessful)] = "Erfolgreiche Downloads entfernen",
        [nameof(ContextMenuRemoveInactive)] = "Inaktive Downloads entfernen",
        [nameof(ContextMenuRestartFailed)] = "Fehlgeschlagene Downloads neu starten",
        [nameof(ContextMenuCancelAll)] = "Alle Downloads abbrechen",
        [nameof(DownloadStatusEnqueued)] = "Ausstehend...",
        [nameof(DownloadStatusCompleted)] = "Fertig",
        [nameof(DownloadStatusCanceled)] = "Abgebrochen",
        [nameof(DownloadStatusFailed)] = "Fehlgeschlagen",
        [nameof(ClickToCopyErrorTooltip)] = "Hinweis: Klicken zum Kopieren der Fehlermeldung",
        [nameof(ShowFileTooltip)] = "Datei anzeigen",
        [nameof(PlayTooltip)] = "Abspielen",
        [nameof(CancelDownloadTooltip)] = "Download abbrechen",
        [nameof(RestartDownloadTooltip)] = "Download neu starten",
        // School
        [nameof(AppHeaderTitle)] = "Videobibliothek",
        [nameof(AppHeaderSubtitle)] = "Laden Sie Videos für Ihren Unterricht herunter",
        [nameof(AddToLibraryButton)] = "Hinzufügen",
        [nameof(AccountButton)] = "YouTube-Konto",
        [nameof(SettingsButton)] = "Einstellungen",
        [nameof(SchoolQueryPlaceholderText)] =
            "Fügen Sie einen YouTube-Link ein (Video, Playlist oder Kanal) oder geben Sie Suchbegriffe gefolgt von ? ein",
        [nameof(StepCopyTitle)] = "Link kopieren",
        [nameof(StepCopyText)] = "Auf YouTube auf Teilen und dann auf Kopieren klicken",
        [nameof(StepPasteTitle)] = "Oben einfügen",
        [nameof(StepPasteText)] = "Mehrere Links? Einer pro Zeile (Umschalt+Eingabe)",
        [nameof(StepDownloadTitle)] = "Qualität wählen",
        [nameof(StepDownloadText)] = "MP4 läuft auf jedem Computer im Klassenzimmer",
        [nameof(CopyrightNoticeTitle)] = "Urheberrecht beachten",
        [nameof(CopyrightNoticeMessage)] =
            "Laden Sie nur Videos herunter, die Sie im Unterricht verwenden dürfen: Creative-Commons-Lizenz, Bildungsschranke oder Erlaubnis des Urhebers. Beachten Sie die Regeln Ihrer Schule.",
        [nameof(DownloadsListTitle)] = "Downloads",
        [nameof(SummaryActiveLabel)] = "laufend",
        [nameof(SummaryCompletedLabel)] = "fertig",
        [nameof(SummaryFailedLabel)] = "fehlgeschlagen",
        [nameof(RetryFailedButton)] = "Fehlgeschlagene wiederholen",
        [nameof(ClearListButton)] = "Abgeschlossene entfernen",
        [nameof(CancelAllButton)] = "Alle abbrechen",
        [nameof(OpenLibraryFolderButton)] = "Ordner öffnen",
        [nameof(SchoolSectionLabel)] = "Schule",
        [nameof(SchoolNameLabel)] = "Name der Schule",
        [nameof(SchoolNameTooltip)] = "Wird oben im Fenster angezeigt",
        [nameof(SchoolNamePlaceholderText)] = "z. B. Goethe-Schule",
        [nameof(DefaultDownloadDirLabel)] = "Download-Ordner",
        [nameof(DefaultDownloadDirTooltip)] =
            "Videos werden automatisch hier gespeichert, ohne jedes Mal nachzufragen (zum Beispiel ein freigegebenes Laufwerk). Leer lassen, um jedes Mal auszuwählen.",
        [nameof(DefaultDownloadDirPlaceholderText)] = "Jedes Mal fragen",
        [nameof(GeneralSectionLabel)] = "Allgemein",
        [nameof(ClipSectionLabel)] = "Ausschnitt (optional)",
        [nameof(ClipStartLabel)] = "Beginn",
        [nameof(ClipEndLabel)] = "Ende",
        [nameof(ClipPlaceholderText)] = "h:mm:ss oder mm:ss",
        [nameof(ClipTooltip)] =
            "Nur einen Teil des Videos behalten. Leer lassen, um das ganze Video herunterzuladen.",
        [nameof(ClipInvalidFormatMessage)] =
            "Verwenden Sie das Format h:mm:ss oder mm:ss (z. B. 1:30).",
        [nameof(ClipEndBeforeStartMessage)] = "Das Ende muss nach dem Beginn liegen.",
        [nameof(ClipOutOfRangeMessage)] = "Der Ausschnitt geht über die Länge des Videos hinaus.",
        [nameof(ClipLabel)] = "Ausschnitt",
        [nameof(ClassPresetButton)] = "Klassen-Voreinstellung",
        [nameof(ClassPresetTooltip)] =
            "MP4, beste Qualität bis 720p: läuft auf jedem Computer und Beamer im Klassenzimmer",
        [nameof(ClassPresetDefaultLabel)] = "Klassen-Voreinstellung standardmäßig",
        [nameof(ClassPresetDefaultTooltip)] =
            "Bei der Formatauswahl automatisch MP4 bis 720p wählen",
        [nameof(SaveSubtitleFilesLabel)] = "Untertitel als .srt-Dateien speichern",
        [nameof(SaveSubtitleFilesTooltip)] =
            "Untertitel zusätzlich als separate .srt-Dateien neben dem Video speichern (sie werden nicht verschoben, wenn nur ein Ausschnitt behalten wird)",
        [nameof(SubtitleLanguageLabel)] = "Untertitelsprache",
        [nameof(SubtitleLanguageTooltip)] =
            "Sprachcode der zu behaltenden Untertitel (z. B. de, en). Leer lassen, um alle Sprachen zu behalten. Hat das Video keine Untertitel in dieser Sprache, werden alle behalten.",
        [nameof(SubtitleLanguagePlaceholderText)] = "Alle Sprachen",
        [nameof(CategoryLabel)] = "Ablegen unter",
        [nameof(CategoryPlaceholderText)] = "z. B. Klasse 5/Biologie",
        [nameof(CategoryTooltip)] =
            "Unterordner des Download-Ordners für die nächsten Downloads (Klasse, Fach…). Mit / mehrere Ebenen anlegen. Leer lassen, um direkt im Download-Ordner zu speichern.",
        [nameof(WriteSourceFileLabel)] = "Quelldatei erstellen",
        [nameof(WriteSourceFileTooltip)] =
            "Neben jedem Video eine .source.txt-Datei mit Titel, Kanal, Link, Downloaddatum und einem Lizenzhinweis speichern, um die Quelle im Unterricht anzugeben",
        [nameof(SourceFileTitleLine)] = "Titel: {0}",
        [nameof(SourceFileChannelLine)] = "Kanal: {0}",
        [nameof(SourceFileVideoUrlLine)] = "Video: {0}",
        [nameof(SourceFileChannelUrlLine)] = "Kanalseite: {0}",
        [nameof(SourceFileDurationLine)] = "Dauer: {0}",
        [nameof(SourceFileClipLine)] = "Ausschnitt: {0}",
        [nameof(SourceFileDownloadedAtLine)] = "Heruntergeladen am: {0}",
        [nameof(SourceFileSchoolLine)] = "Schule: {0}",
        [nameof(SourceFileLicenseLine)] =
            "Lizenz: auf der Videoseite zu prüfen (Creative Commons, Bildungsschranke…)",
        [nameof(AdminSectionLabel)] = "Verwaltung",
        [nameof(AdminPinLabel)] = "Admin-PIN",
        [nameof(AdminPinTooltip)] =
            "Ist eine PIN festgelegt, wird sie zum Öffnen der Einstellungen oder des YouTube-Kontos benötigt",
        [nameof(AdminPinPlaceholderText)] = "mind. 4 Zeichen",
        [nameof(AdminPinSetButton)] = "Festlegen",
        [nameof(AdminPinActiveLabel)] = "Einstellungen durch PIN gesperrt",
        [nameof(AdminPinRemoveButton)] = "PIN entfernen",
        [nameof(MaxVideoQualityLabel)] = "Maximale Qualität",
        [nameof(MaxVideoQualityTooltip)] =
            "Höchste beim Herunterladen angebotene Videoqualität (spart Bandbreite und Speicherplatz)",
        [nameof(PinPromptTitle)] = "Gesperrt",
        [nameof(PinPromptMessage)] = "Geben Sie die Administrator-PIN ein, um fortzufahren.",
        [nameof(PinPlaceholderText)] = "PIN",
        [nameof(PinWrongMessage)] = "Falsche PIN, bitte erneut versuchen.",
        [nameof(UnlockButton)] = "ENTSPERREN",
        [nameof(ImportLinkListButton)] = "Liste importieren",
        [nameof(ImportLinkListTooltip)] =
            "Eine .txt- oder .csv-Datei mit einem YouTube-Link pro Zeile öffnen (erste Spalte bei einer Tabelle). Zeilen, die mit # beginnen, werden ignoriert.",
        [nameof(LinkListFileType)] = "Linkliste",
        [nameof(LinkListEmptyMessage)] = "Kein Link in dieser Datei gefunden",
        [nameof(HistoryButton)] = "Verlauf",
        [nameof(HistoryTooltip)] = "Auf diesem Computer durchgeführte Downloads",
        [nameof(HistoryTitle)] = "Download-Verlauf",
        [nameof(HistoryEmptyText)] = "Noch keine Downloads",
        [nameof(HistoryOpenCsvButton)] = "CSV-DATEI ÖFFNEN",
        [nameof(HistoryDateColumnHeader)] = "Datum",
        [nameof(HistoryUserColumnHeader)] = "Benutzer",
        [nameof(HistoryTitleColumnHeader)] = "Titel",
        [nameof(HistoryUrlColumnHeader)] = "URL",
        [nameof(HistoryFileColumnHeader)] = "Datei",
        [nameof(HistoryStatusColumnHeader)] = "Status",
        [nameof(DeferredModeLabel)] = "Später herunterladen (ab {0})",
        [nameof(DeferredModeTooltip)] =
            "Videos, die bei aktivierter Option hinzugefügt werden, warten bis zur geplanten Uhrzeit (in den Einstellungen festgelegt), z. B. um das Schulnetz während des Unterrichts nicht zu verlangsamen. Lassen Sie die App geöffnet.",
        [nameof(DownloadStatusScheduled)] = "Geplant um {0}",
        [nameof(SummaryScheduledLabel)] = "geplant",
        [nameof(MaxDownloadRateLabel)] = "Geschwindigkeitslimit (KB/s)",
        [nameof(MaxDownloadRateTooltip)] =
            "Maximale Gesamt-Downloadgeschwindigkeit in Kilobyte pro Sekunde, um das Schulnetz zu teilen. 0 = unbegrenzt.",
        [nameof(ScheduledStartTimeLabel)] = "Geplante Startzeit",
        [nameof(ScheduledStartTimeTooltip)] =
            "Uhrzeit (HH:mm), zu der die mit \"Später herunterladen\" hinzugefügten Downloads starten",
        [nameof(PreviewButton)] = "Vorschau",
        [nameof(PreviewTooltip)] =
            "Video hier ansehen, bevor Sie es herunterladen (beginnt am Anfang des Ausschnitts, falls festgelegt)",
        [nameof(PreviewOpenInBrowserButton)] = "Im Browser öffnen",
        [nameof(PreviewCloseButton)] = "Vorschau schließen",
        // Color themes
        [nameof(DownloadStatusTrimming)] = "Ausschnitt wird zugeschnitten… {0}",
        [nameof(YoutubeForbiddenMessage)] =
            "YouTube hat den Zugriff auf dieses Video verweigert (Fehler 403). Das ist oft nur vorübergehend: Versuchen Sie es in einigen Minuten erneut. Ist das Video altersbeschränkt oder privat, melden Sie sich zuerst über YouTube-Konto an.",
        [nameof(ColorThemeLabel)] = "Farben",
        [nameof(ColorThemeTooltip)] = "Farbpalette der Benutzeroberfläche",
        [nameof(ColorThemeSchool)] = "Schulblau",
        [nameof(ColorThemeNature)] = "Naturgrün",
        [nameof(ColorThemeOcean)] = "Ozean",
        [nameof(ColorThemeLavender)] = "Lavendel",
        [nameof(ColorThemeSunset)] = "Sonnenuntergang",
        [nameof(ColorThemeClassic)] = "Klassisch",
        // Settings
        [nameof(SettingsTitle)] = "Einstellungen",
        [nameof(ThemeLabel)] = "Design",
        [nameof(ThemeTooltip)] = "Bevorzugtes Oberflächendesign",
        [nameof(LanguageLabel)] = "Sprache",
        [nameof(LanguageTooltip)] = "Bevorzugte Anzeigesprache für die Benutzeroberfläche",
        [nameof(AutoUpdateLabel)] = "Automatische Updates",
        [nameof(AutoUpdateTooltip)] = """
            Automatische Updates bei jedem Start durchführen.
            **Hinweis:** Es wird empfohlen, diese Option aktiviert zu lassen, um die Kompatibilität mit der neuesten YouTube-Version zu gewährleisten.
            """,
        [nameof(PersistAuthLabel)] = "Authentifizierung speichern",
        [nameof(PersistAuthTooltip)] = """
            Authentifizierungs-Cookies in einer Datei speichern für sitzungsübergreifende Persistenz.
            **Warnung**: Die Cookies werden mit Verschlüsselung gespeichert, können aber dennoch von einem Angreifer mit Zugriff auf Ihr System wiederhergestellt werden.
            """,
        [nameof(InjectAltLanguagesLabel)] = "Alternative Sprachen einbetten",
        [nameof(InjectAltLanguagesTooltip)] =
            "Audiotracks in alternativen Sprachen (falls verfügbar) in heruntergeladene Dateien einbetten",
        [nameof(InjectSubtitlesLabel)] = "Untertitel einbetten",
        [nameof(InjectSubtitlesTooltip)] =
            "Untertitel (falls verfügbar) in heruntergeladene Dateien einbetten",
        [nameof(InjectTagsLabel)] = "Medien-Tags einbetten",
        [nameof(InjectTagsTooltip)] =
            "Medien-Tags (falls verfügbar) in heruntergeladene Dateien einbetten",
        [nameof(SkipExistingFilesLabel)] = "Vorhandene Dateien überspringen",
        [nameof(SkipExistingFilesTooltip)] =
            "Beim Herunterladen mehrerer Videos solche überspringen, für die bereits passende Dateien im Ausgabeverzeichnis vorhanden sind",
        [nameof(FileNameTemplateLabel)] = "Dateinamen-Vorlage",
        [nameof(FileNameTemplateTooltip)] = """
            Vorlage für die Generierung von Dateinamen heruntergeladener Videos.

            Verfügbare Token:
            **$num** — Position des Videos in der Liste (falls zutreffend)
            **$id** — Video-ID
            **$title** — Videotitel
            **$author** — Videoautor
            """,
        [nameof(ParallelLimitLabel)] = "Paralleles Limit",
        [nameof(ParallelLimitTooltip)] = "Wie viele Downloads gleichzeitig aktiv sein können",
        [nameof(FFmpegPathLabel)] = "FFmpeg-Pfad",
        [nameof(FFmpegPathTooltip)] =
            "Pfad zur FFmpeg-Programmdatei. Leer lassen für automatische Erkennung.",
        [nameof(FFmpegPathPlaceholderText)] = "Auto",
        [nameof(FFmpegPathResetTooltip)] = "Zurücksetzen auf automatische Erkennung",
        [nameof(FFmpegPathBrowseTooltip)] = "FFmpeg-Programmdatei suchen",
        // Auth Setup
        [nameof(AuthenticationTitle)] = "Authentifizierung",
        [nameof(AuthenticatedText)] = "Sie sind derzeit authentifiziert",
        [nameof(LogOutButton)] = "Abmelden",
        [nameof(AuthenticationPlaceholderText)] = """
            Laden...

            Wenn der Browser nicht erscheint:
            - Windows: Installieren Sie Microsoft Edge WebView2 Runtime.
            - macOS: Installieren Sie die neuesten Systemupdates.
            - Linux: Installieren Sie GTK 3, WebKitGTK 4.1 und libsoup 3.
            """,
        // Download Single Setup
        [nameof(CopyMenuItem)] = "Kopieren",
        [nameof(LiveLabel)] = "Live",
        [nameof(AudioLabel)] = "Audio",
        [nameof(UpscaledLabel)] = "Hochskaliert",
        [nameof(FormatLabel)] = "Format",
        // Download Multiple Setup
        [nameof(ContainerLabel)] = "Container",
        [nameof(VideoQualityLabel)] = "Videoqualität",
        // Common buttons
        [nameof(CloseButton)] = "SCHLIESSEN",
        [nameof(DownloadButton)] = "HERUNTERLADEN",
        [nameof(CancelButton)] = "ABBRECHEN",
        // Dialog messages
        [nameof(UkraineSupportTitle)] = "Danke für Ihre Unterstützung der Ukraine!",
        [nameof(UkraineSupportMessage)] = """
            Während Russland einen Vernichtungskrieg gegen mein Land führt, bin ich jedem dankbar, der weiterhin zur Ukraine in unserem Kampf für die Freiheit steht.

            Klicken Sie auf MEHR ERFAHREN um Wege zu finden, wie Sie helfen können.
            """,
        [nameof(LearnMoreButton)] = "MEHR ERFAHREN",
        [nameof(UnstableBuildTitle)] = "Warnung: Instabiler Build",
        [nameof(UnstableBuildMessage)] = """
            Sie verwenden einen Entwicklungs-Build von {0}. Diese Builds wurden nicht gründlich getestet und können Fehler enthalten.

            Automatische Updates sind für Entwicklungs-Builds deaktiviert.

            Klicken Sie auf RELEASES ANZEIGEN um stattdessen einen stabilen Release herunterzuladen.
            """,
        [nameof(SeeReleasesButton)] = "RELEASES ANZEIGEN",
        [nameof(FFmpegMissingTitle)] = "FFmpeg fehlt",
        [nameof(FFmpegMissingMessage)] = """
            FFmpeg wurde auf Ihrem System nicht gefunden. Es wird benötigt damit {0} funktioniert. Möchten Sie es jetzt herunterladen?

            Alternativ können Sie diesen Dialog schließen und in den Einstellungen manuell einen benutzerdefinierten FFmpeg-Pfad festlegen.
            """,
        [nameof(FFmpegDownloadingTitle)] = "FFmpeg wird heruntergeladen...",
        [nameof(FFmpegDownloadCompletedTitle)] = "FFmpeg heruntergeladen",
        [nameof(NothingFoundTitle)] = "Nichts gefunden",
        [nameof(NothingFoundMessage)] =
            "Es konnten keine Videos basierend auf der angegebenen Anfrage oder URL gefunden werden",
        [nameof(ErrorTitle)] = "Fehler",
        [nameof(UpdateDownloadingMessage)] = "Update für {0} v{1} wird heruntergeladen...",
        [nameof(UpdateReadyMessage)] =
            "Update wurde heruntergeladen und wird beim Beenden installiert",
        [nameof(UpdateInstallNowButton)] = "JETZT INSTALLIEREN",
        [nameof(UpdateFailedMessage)] = "Anwendungsupdate konnte nicht durchgeführt werden",
    };
}
