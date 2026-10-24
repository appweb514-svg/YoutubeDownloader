using System.Collections.Generic;

namespace YoutubeDownloader.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> EnglishLocalization =
        new Dictionary<string, string>
        {
            // Dashboard
            [nameof(QueryPlaceholderText)] = "URL or search query",
            [nameof(QueryTooltip)] =
                "Any valid YouTube URL or ID is accepted. Prepend a question mark (?) to perform search by text.",
            [nameof(ProcessQueryTooltip)] = "Process query (Enter)",
            [nameof(AuthTooltip)] = "Authentication",
            [nameof(SettingsTooltip)] = "Settings",
            [nameof(DashboardPlaceholder)] = """
                Copy-paste a **URL** or enter a **search query** to start downloading
                Press **Shift+Enter** to add multiple items
                """,
            [nameof(DownloadsFileColumnHeader)] = "File",
            [nameof(DownloadsStatusColumnHeader)] = "Status",
            [nameof(ContextMenuRemoveSuccessful)] = "Remove successful downloads",
            [nameof(ContextMenuRemoveInactive)] = "Remove inactive downloads",
            [nameof(ContextMenuRestartFailed)] = "Restart failed downloads",
            [nameof(ContextMenuCancelAll)] = "Cancel all downloads",
            [nameof(DownloadStatusEnqueued)] = "Pending...",
            [nameof(DownloadStatusCompleted)] = "Done",
            [nameof(DownloadStatusCanceled)] = "Canceled",
            [nameof(DownloadStatusFailed)] = "Failed",
            [nameof(ClickToCopyErrorTooltip)] = "Note: Click to copy this error message",
            [nameof(ShowFileTooltip)] = "Show file",
            [nameof(PlayTooltip)] = "Play",
            [nameof(CancelDownloadTooltip)] = "Cancel download",
            [nameof(RestartDownloadTooltip)] = "Restart download",
            // School
            [nameof(AppHeaderTitle)] = "Video library",
            [nameof(AppHeaderSubtitle)] = "Download videos for your lessons",
            [nameof(AddToLibraryButton)] = "Add",
            [nameof(AccountButton)] = "YouTube account",
            [nameof(SettingsButton)] = "Settings",
            [nameof(SchoolQueryPlaceholderText)] =
                "Paste a YouTube link (video, playlist or channel) or type keywords followed by ?",
            [nameof(StepCopyTitle)] = "Copy the link",
            [nameof(StepCopyText)] = "On YouTube, click Share then Copy",
            [nameof(StepPasteTitle)] = "Paste it above",
            [nameof(StepPasteText)] = "Several links? One per line (Shift+Enter)",
            [nameof(StepDownloadTitle)] = "Pick the quality",
            [nameof(StepDownloadText)] = "MP4 plays on every classroom computer",
            [nameof(CopyrightNoticeTitle)] = "Respect copyright",
            [nameof(CopyrightNoticeMessage)] =
                "Only download videos you are allowed to use in class: Creative Commons licence, educational exception, or permission from the author. Check your school's rules.",
            [nameof(DownloadsListTitle)] = "Downloads",
            [nameof(SummaryActiveLabel)] = "in progress",
            [nameof(SummaryCompletedLabel)] = "done",
            [nameof(SummaryFailedLabel)] = "failed",
            [nameof(RetryFailedButton)] = "Retry failed",
            [nameof(ClearListButton)] = "Clear finished",
            [nameof(CancelAllButton)] = "Cancel all",
            [nameof(OpenLibraryFolderButton)] = "Open folder",
            [nameof(SchoolSectionLabel)] = "School",
            [nameof(SchoolNameLabel)] = "School name",
            [nameof(SchoolNameTooltip)] = "Shown at the top of the window",
            [nameof(SchoolNamePlaceholderText)] = "e.g. Jules Ferry School",
            [nameof(DefaultDownloadDirLabel)] = "Download folder",
            [nameof(DefaultDownloadDirTooltip)] =
                "Videos are saved here automatically, without asking each time (for example a shared drive). Leave empty to choose every time.",
            [nameof(DefaultDownloadDirPlaceholderText)] = "Ask every time",
            [nameof(GeneralSectionLabel)] = "General",
            [nameof(ClipSectionLabel)] = "Clip (optional)",
            [nameof(ClipStartLabel)] = "Start",
            [nameof(ClipEndLabel)] = "End",
            [nameof(ClipPlaceholderText)] = "h:mm:ss or mm:ss",
            [nameof(ClipTooltip)] =
                "Only keep part of the video. Leave empty to download the whole video.",
            [nameof(ClipInvalidFormatMessage)] = "Use the format h:mm:ss or mm:ss (e.g. 1:30).",
            [nameof(ClipEndBeforeStartMessage)] = "The end must be after the start.",
            [nameof(ClipOutOfRangeMessage)] = "The clip goes beyond the length of the video.",
            [nameof(ClipLabel)] = "Clip",
            [nameof(ClassPresetButton)] = "Class preset",
            [nameof(ClassPresetTooltip)] =
                "MP4, best quality up to 720p: plays on every classroom computer and projector",
            [nameof(ClassPresetDefaultLabel)] = "Class preset by default",
            [nameof(ClassPresetDefaultTooltip)] =
                "Select MP4 up to 720p automatically when choosing the format",
            [nameof(SaveSubtitleFilesLabel)] = "Save subtitles as .srt files",
            [nameof(SaveSubtitleFilesTooltip)] =
                "Also save the subtitles next to the video, as separate .srt files (they are not shifted when only a clip is kept)",
            [nameof(SubtitleLanguageLabel)] = "Subtitle language",
            [nameof(SubtitleLanguageTooltip)] =
                "Language code of the subtitles to keep (e.g. fr, en). Leave empty to keep all languages. If the video has no subtitles in this language, all are kept.",
            [nameof(SubtitleLanguagePlaceholderText)] = "All languages",
            [nameof(CategoryLabel)] = "File under",
            [nameof(CategoryPlaceholderText)] = "e.g. Year 5/Science",
            [nameof(CategoryTooltip)] =
                "Sub-folder of the download folder for the next downloads (class, subject…). Use / to create several levels. Leave empty to save directly in the download folder.",
            [nameof(WriteSourceFileLabel)] = "Write a source file",
            [nameof(WriteSourceFileTooltip)] =
                "Save a .source.txt file next to each video with its title, channel, link, download date and a licence reminder, to cite the source in class",
            [nameof(SourceFileTitleLine)] = "Title: {0}",
            [nameof(SourceFileChannelLine)] = "Channel: {0}",
            [nameof(SourceFileVideoUrlLine)] = "Video: {0}",
            [nameof(SourceFileChannelUrlLine)] = "Channel page: {0}",
            [nameof(SourceFileDurationLine)] = "Duration: {0}",
            [nameof(SourceFileClipLine)] = "Clip: {0}",
            [nameof(SourceFileDownloadedAtLine)] = "Downloaded on: {0}",
            [nameof(SourceFileSchoolLine)] = "School: {0}",
            [nameof(SourceFileLicenseLine)] =
                "Licence: to be checked on the video page (Creative Commons, educational exception…)",
            [nameof(AdminSectionLabel)] = "Administration",
            [nameof(AdminPinLabel)] = "Admin PIN",
            [nameof(AdminPinTooltip)] =
                "When a PIN is set, it is required to open the settings or the YouTube account",
            [nameof(AdminPinPlaceholderText)] = "4 characters min.",
            [nameof(AdminPinSetButton)] = "Set",
            [nameof(AdminPinActiveLabel)] = "Settings locked by a PIN",
            [nameof(AdminPinRemoveButton)] = "Remove PIN",
            [nameof(MaxVideoQualityLabel)] = "Maximum quality",
            [nameof(MaxVideoQualityTooltip)] =
                "Highest video quality offered when downloading (saves bandwidth and disk space)",
            [nameof(PinPromptTitle)] = "Locked",
            [nameof(PinPromptMessage)] = "Enter the administrator PIN to continue.",
            [nameof(PinPlaceholderText)] = "PIN",
            [nameof(PinWrongMessage)] = "Wrong PIN, try again.",
            [nameof(UnlockButton)] = "UNLOCK",
            [nameof(ImportLinkListButton)] = "Import a list",
            [nameof(ImportLinkListTooltip)] =
                "Open a .txt or .csv file with one YouTube link per line (first column for a spreadsheet). Lines starting with # are ignored.",
            [nameof(LinkListFileType)] = "List of links",
            [nameof(LinkListEmptyMessage)] = "No link found in this file",
            [nameof(HistoryButton)] = "History",
            [nameof(HistoryTooltip)] = "Downloads made on this computer",
            [nameof(HistoryTitle)] = "Download history",
            [nameof(HistoryEmptyText)] = "No download yet",
            [nameof(HistoryOpenCsvButton)] = "OPEN CSV FILE",
            [nameof(HistoryDateColumnHeader)] = "Date",
            [nameof(HistoryUserColumnHeader)] = "User",
            [nameof(HistoryTitleColumnHeader)] = "Title",
            [nameof(HistoryUrlColumnHeader)] = "URL",
            [nameof(HistoryFileColumnHeader)] = "File",
            [nameof(HistoryStatusColumnHeader)] = "Status",
            [nameof(DeferredModeLabel)] = "Download later (from {0})",
            [nameof(DeferredModeTooltip)] =
                "Videos added while this is on wait for the scheduled time (set in the settings) before downloading, e.g. to avoid slowing down the school network during lessons. Keep the app open.",
            [nameof(DownloadStatusScheduled)] = "Scheduled at {0}",
            [nameof(SummaryScheduledLabel)] = "scheduled",
            [nameof(MaxDownloadRateLabel)] = "Speed limit (KB/s)",
            [nameof(MaxDownloadRateTooltip)] =
                "Maximum total download speed, in kilobytes per second, to share the school network. 0 = unlimited.",
            [nameof(ScheduledStartTimeLabel)] = "Scheduled start time",
            [nameof(ScheduledStartTimeTooltip)] =
                "Time (HH:mm) at which downloads added with \"Download later\" start",
            [nameof(PreviewButton)] = "Preview",
            [nameof(PreviewTooltip)] =
                "Watch the video here before downloading it (starts at the beginning of the clip, if set)",
            [nameof(PreviewOpenInBrowserButton)] = "Open in browser",
            [nameof(PreviewCloseButton)] = "Close preview",
            // Color themes
            [nameof(DownloadStatusTrimming)] = "Trimming the clip… {0}",
            [nameof(YoutubeForbiddenMessage)] =
                "YouTube refused access to this video (error 403). This is often temporary: try again in a few minutes. If the video is age-restricted or private, sign in with YouTube Account first.",
            [nameof(ColorThemeLabel)] = "Colors",
            [nameof(ColorThemeTooltip)] = "Color palette of the interface",
            [nameof(ColorThemeSchool)] = "School blue",
            [nameof(ColorThemeNature)] = "Nature green",
            [nameof(ColorThemeOcean)] = "Ocean",
            [nameof(ColorThemeLavender)] = "Lavender",
            [nameof(ColorThemeSunset)] = "Sunset",
            [nameof(ColorThemeClassic)] = "Classic",
            // Settings
            [nameof(SettingsTitle)] = "Settings",
            [nameof(ThemeLabel)] = "Theme",
            [nameof(ThemeTooltip)] = "Preferred user interface theme",
            [nameof(LanguageLabel)] = "Language",
            [nameof(LanguageTooltip)] = "Preferred display language for the user interface",
            [nameof(AutoUpdateLabel)] = "Auto-update",
            [nameof(AutoUpdateTooltip)] = """
                Perform automatic updates on every launch.
                **Warning:** it's recommended to leave this option enabled to ensure that the app is compatible with the latest version of YouTube.
                """,
            [nameof(PersistAuthLabel)] = "Persist authentication",
            [nameof(PersistAuthTooltip)] = """
                Save authentication cookies to a file so that they can be persisted between sessions.
                **Warning**: although the cookies are stored with encryption, they may still be recovered by an attacker who has access to your system.
                """,
            [nameof(InjectAltLanguagesLabel)] = "Inject alternative languages",
            [nameof(InjectAltLanguagesTooltip)] =
                "Inject audio tracks in alternative languages (if available) into downloaded files",
            [nameof(InjectSubtitlesLabel)] = "Inject subtitles",
            [nameof(InjectSubtitlesTooltip)] =
                "Inject subtitles (if available) into downloaded files",
            [nameof(InjectTagsLabel)] = "Inject media tags",
            [nameof(InjectTagsTooltip)] = "Inject media tags (if available) into downloaded files",
            [nameof(SkipExistingFilesLabel)] = "Skip existing files",
            [nameof(SkipExistingFilesTooltip)] =
                "When downloading multiple videos, skip those that already have matching files in the output directory",
            [nameof(FileNameTemplateLabel)] = "File name template",
            [nameof(FileNameTemplateTooltip)] = """
                Template used for generating file names for downloaded videos.

                Available tokens:
                **$num** — video's position in the list (if applicable)
                **$id** — video ID
                **$title** — video title
                **$author** — video author
                """,
            [nameof(ParallelLimitLabel)] = "Parallel limit",
            [nameof(ParallelLimitTooltip)] = "How many downloads can be active at the same time",
            [nameof(FFmpegPathLabel)] = "FFmpeg path",
            [nameof(FFmpegPathTooltip)] =
                "Path to the FFmpeg executable. Leave empty to use auto-detection.",
            [nameof(FFmpegPathPlaceholderText)] = "Auto-detect",
            [nameof(FFmpegPathResetTooltip)] = "Reset to auto-detection",
            [nameof(FFmpegPathBrowseTooltip)] = "Browse for FFmpeg executable",
            // Auth Setup
            [nameof(AuthenticationTitle)] = "Authentication",
            [nameof(AuthenticatedText)] = "You are currently authenticated",
            [nameof(LogOutButton)] = "Log out",
            [nameof(AuthenticationPlaceholderText)] = """
                Loading...

                If the browser does not appear:
                - Windows: install Microsoft Edge WebView2 Runtime.
                - macOS: install the latest system updates.
                - Linux: install GTK 3, WebKitGTK 4.1, and libsoup 3.
                """,
            // Download Single Setup
            [nameof(CopyMenuItem)] = "Copy",
            [nameof(LiveLabel)] = "Live",
            [nameof(AudioLabel)] = "Audio",
            [nameof(UpscaledLabel)] = "Upscaled",
            [nameof(FormatLabel)] = "Format",
            // Download Multiple Setup
            [nameof(ContainerLabel)] = "Container",
            [nameof(VideoQualityLabel)] = "Video quality",
            // Common buttons
            [nameof(CloseButton)] = "CLOSE",
            [nameof(DownloadButton)] = "DOWNLOAD",
            [nameof(CancelButton)] = "CANCEL",
            // Dialog messages
            [nameof(UkraineSupportTitle)] = "Thank you for supporting Ukraine!",
            [nameof(UkraineSupportMessage)] = """
                As Russia wages a genocidal war against my country, I'm grateful to everyone who continues to stand with Ukraine in our fight for freedom.

                Click LEARN MORE to find ways that you can help.
                """,
            [nameof(LearnMoreButton)] = "LEARN MORE",
            [nameof(UnstableBuildTitle)] = "Unstable build warning",
            [nameof(UnstableBuildMessage)] = """
                You're using a development build of {0}. These builds are not thoroughly tested and may contain bugs.

                Auto-updates are disabled for development builds.

                Click SEE RELEASES if you want to download a stable release instead.
                """,
            [nameof(SeeReleasesButton)] = "SEE RELEASES",
            [nameof(FFmpegMissingTitle)] = "FFmpeg is missing",
            [nameof(FFmpegMissingMessage)] = """
                FFmpeg was not found on your system. It is required for {0} to work. Would you like to download it now?

                Alternatively, you can close this dialog and manually set a custom FFmpeg path in settings.
                """,
            [nameof(FFmpegDownloadingTitle)] = "Downloading FFmpeg...",
            [nameof(FFmpegDownloadCompletedTitle)] = "FFmpeg downloaded",
            [nameof(NothingFoundTitle)] = "Nothing found",
            [nameof(NothingFoundMessage)] =
                "Couldn't find any videos based on the query or URL you provided",
            [nameof(ErrorTitle)] = "Error",
            [nameof(UpdateDownloadingMessage)] = "Downloading update to {0} v{1}...",
            [nameof(UpdateReadyMessage)] =
                "Update has been downloaded and will be installed when you exit",
            [nameof(UpdateInstallNowButton)] = "INSTALL NOW",
            [nameof(UpdateFailedMessage)] = "Failed to perform application update",
        };
}
