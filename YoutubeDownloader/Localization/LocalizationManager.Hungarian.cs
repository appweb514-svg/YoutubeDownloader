using System.Collections.Generic;

namespace YoutubeDownloader.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> HungarianLocalization =
        new Dictionary<string, string>
        {
            // Dashboard
            [nameof(QueryPlaceholderText)] = "URL vagy keresés",
            [nameof(QueryTooltip)] =
                "Bármilyen érvényes YouTube URL vagy videóazonosító megadható. Szöveges kereséshez írj egy kérdőjelet (?) a keresőkifejezés elé.",
            [nameof(ProcessQueryTooltip)] = "Keresés indítása (Enter)",
            [nameof(AuthTooltip)] = "Bejelentkezés",
            [nameof(SettingsTooltip)] = "Beállítások",
            [nameof(DashboardPlaceholder)] = """
                Másold be egy videó **URL**-jét vagy írj be egy **kifejezést** a kereséshez
                Több elem hozzáadásához nyomj **Shift+Enter**-t
                """,
            [nameof(DownloadsFileColumnHeader)] = "Fájl",
            [nameof(DownloadsStatusColumnHeader)] = "Státusz",
            [nameof(ContextMenuRemoveSuccessful)] = "Sikeres letöltések eltávolítása",
            [nameof(ContextMenuRemoveInactive)] = "Inaktív letöltések eltávolítása",
            [nameof(ContextMenuRestartFailed)] = "Sikertelen letöltések újraindítása",
            [nameof(ContextMenuCancelAll)] = "Összes letöltés megszakítása",
            [nameof(DownloadStatusEnqueued)] = "Függőben...",
            [nameof(DownloadStatusCompleted)] = "Kész",
            [nameof(DownloadStatusCanceled)] = "Megszakítva",
            [nameof(DownloadStatusFailed)] = "Sikertelen",
            [nameof(ClickToCopyErrorTooltip)] = "Megjegyzés: kattints a hibaüzenet másolásához",
            [nameof(ShowFileTooltip)] = "Fájlhoz ugrás",
            [nameof(PlayTooltip)] = "Lejátszás",
            [nameof(CancelDownloadTooltip)] = "Letöltés megszakítása",
            [nameof(RestartDownloadTooltip)] = "Letöltés újraindítása",
            // School
            [nameof(AppHeaderTitle)] = "Videótár",
            [nameof(AppHeaderSubtitle)] = "Töltsön le videókat az óráihoz",
            [nameof(AddToLibraryButton)] = "Hozzáadás",
            [nameof(AccountButton)] = "YouTube-fiók",
            [nameof(SettingsButton)] = "Beállítások",
            [nameof(SchoolQueryPlaceholderText)] =
                "Illesszen be egy YouTube-linket (videó, lejátszási lista vagy csatorna), vagy írjon be kulcsszavakat, utánuk ?",
            [nameof(StepCopyTitle)] = "Másolja a linket",
            [nameof(StepCopyText)] = "A YouTube-on kattintson a Megosztás, majd a Másolás gombra",
            [nameof(StepPasteTitle)] = "Illessze be fent",
            [nameof(StepPasteText)] = "Több link? Soronként egy (Shift+Enter)",
            [nameof(StepDownloadTitle)] = "Válassza ki a minőséget",
            [nameof(StepDownloadText)] = "Az MP4 minden tantermi számítógépen lejátszható",
            [nameof(CopyrightNoticeTitle)] = "Tartsa tiszteletben a szerzői jogokat",
            [nameof(CopyrightNoticeMessage)] =
                "Csak olyan videókat töltsön le, amelyeket az órán felhasználhat: Creative Commons licenc, oktatási célú kivétel vagy a szerző engedélye. Ellenőrizze az iskola szabályait.",
            [nameof(DownloadsListTitle)] = "Letöltések",
            [nameof(SummaryActiveLabel)] = "folyamatban",
            [nameof(SummaryCompletedLabel)] = "kész",
            [nameof(SummaryFailedLabel)] = "sikertelen",
            [nameof(RetryFailedButton)] = "Sikertelenek újrapróbálása",
            [nameof(ClearListButton)] = "Befejezettek törlése",
            [nameof(CancelAllButton)] = "Összes megszakítása",
            [nameof(OpenLibraryFolderButton)] = "Mappa megnyitása",
            [nameof(SchoolSectionLabel)] = "Iskola",
            [nameof(SchoolNameLabel)] = "Iskola neve",
            [nameof(SchoolNameTooltip)] = "Az ablak tetején jelenik meg",
            [nameof(SchoolNamePlaceholderText)] = "pl. Petőfi Sándor Általános Iskola",
            [nameof(DefaultDownloadDirLabel)] = "Letöltési mappa",
            [nameof(DefaultDownloadDirTooltip)] =
                "A videók automatikusan ide kerülnek, anélkül hogy minden alkalommal rákérdezne (például egy megosztott meghajtó). Hagyja üresen, ha minden alkalommal választani szeretne.",
            [nameof(DefaultDownloadDirPlaceholderText)] = "Rákérdezés minden alkalommal",
            [nameof(GeneralSectionLabel)] = "Általános",
            [nameof(ClipSectionLabel)] = "Részlet (opcionális)",
            [nameof(ClipStartLabel)] = "Kezdet",
            [nameof(ClipEndLabel)] = "Vége",
            [nameof(ClipPlaceholderText)] = "ó:pp:mm vagy pp:mm",
            [nameof(ClipTooltip)] =
                "Csak a videó egy részének megtartása. Hagyja üresen a teljes videó letöltéséhez.",
            [nameof(ClipInvalidFormatMessage)] =
                "Használja az ó:pp:mm vagy pp:mm formátumot (pl. 1:30).",
            [nameof(ClipEndBeforeStartMessage)] = "A végének a kezdet után kell lennie.",
            [nameof(ClipOutOfRangeMessage)] = "A részlet túlnyúlik a videó hosszán.",
            [nameof(ClipLabel)] = "Részlet",
            [nameof(ClassPresetButton)] = "Tantermi beállítás",
            [nameof(ClassPresetTooltip)] =
                "MP4, legjobb minőség 720p-ig: minden tantermi számítógépen és projektoron lejátszható",
            [nameof(ClassPresetDefaultLabel)] = "Tantermi beállítás alapértelmezésként",
            [nameof(ClassPresetDefaultTooltip)] =
                "Formátumválasztáskor automatikusan MP4 legfeljebb 720p kiválasztása",
            [nameof(SaveSubtitleFilesLabel)] = "Feliratok mentése .srt fájlként",
            [nameof(SaveSubtitleFilesTooltip)] =
                "A feliratok mentése külön .srt fájlként is a videó mellé (nem tolódnak el, ha csak egy részlet marad meg)",
            [nameof(SubtitleLanguageLabel)] = "Felirat nyelve",
            [nameof(SubtitleLanguageTooltip)] =
                "A megtartandó feliratok nyelvkódja (pl. hu, en). Hagyja üresen az összes nyelv megtartásához. Ha a videónak nincs ilyen nyelvű felirata, mindegyik megmarad.",
            [nameof(SubtitleLanguagePlaceholderText)] = "Minden nyelv",
            [nameof(CategoryLabel)] = "Mentés ide",
            [nameof(CategoryPlaceholderText)] = "pl. 5. osztály/Természettudomány",
            [nameof(CategoryTooltip)] =
                "A letöltési mappa almappája a következő letöltésekhez (osztály, tantárgy…). Több szinthez használja a / jelet. Hagyja üresen, ha közvetlenül a letöltési mappába szeretne menteni.",
            [nameof(WriteSourceFileLabel)] = "Forrásfájl készítése",
            [nameof(WriteSourceFileTooltip)] =
                "Minden videó mellé egy .source.txt fájl mentése a címmel, csatornával, linkkel, letöltési dátummal és licencemlékeztetővel, hogy az órán meg lehessen jelölni a forrást",
            [nameof(SourceFileTitleLine)] = "Cím: {0}",
            [nameof(SourceFileChannelLine)] = "Csatorna: {0}",
            [nameof(SourceFileVideoUrlLine)] = "Videó: {0}",
            [nameof(SourceFileChannelUrlLine)] = "Csatorna oldala: {0}",
            [nameof(SourceFileDurationLine)] = "Időtartam: {0}",
            [nameof(SourceFileClipLine)] = "Részlet: {0}",
            [nameof(SourceFileDownloadedAtLine)] = "Letöltve: {0}",
            [nameof(SourceFileSchoolLine)] = "Iskola: {0}",
            [nameof(SourceFileLicenseLine)] =
                "Licenc: a videó oldalán ellenőrizendő (Creative Commons, oktatási célú kivétel…)",
            [nameof(AdminSectionLabel)] = "Adminisztráció",
            [nameof(AdminPinLabel)] = "Rendszergazdai PIN",
            [nameof(AdminPinTooltip)] =
                "Ha PIN van beállítva, az szükséges a beállítások vagy a YouTube-fiók megnyitásához",
            [nameof(AdminPinPlaceholderText)] = "min. 4 karakter",
            [nameof(AdminPinSetButton)] = "Beállítás",
            [nameof(AdminPinActiveLabel)] = "A beállításokat PIN zárolja",
            [nameof(AdminPinRemoveButton)] = "PIN eltávolítása",
            [nameof(MaxVideoQualityLabel)] = "Maximális minőség",
            [nameof(MaxVideoQualityTooltip)] =
                "A letöltéskor felkínált legmagasabb videóminőség (sávszélességet és tárhelyet takarít meg)",
            [nameof(PinPromptTitle)] = "Zárolva",
            [nameof(PinPromptMessage)] = "A folytatáshoz adja meg a rendszergazdai PIN-t.",
            [nameof(PinPlaceholderText)] = "PIN",
            [nameof(PinWrongMessage)] = "Hibás PIN, próbálja újra.",
            [nameof(UnlockButton)] = "FELOLDÁS",
            [nameof(ImportLinkListButton)] = "Lista importálása",
            [nameof(ImportLinkListTooltip)] =
                "Egy .txt vagy .csv fájl megnyitása, soronként egy YouTube-linkkel (táblázat esetén az első oszlop). A # jellel kezdődő sorokat figyelmen kívül hagyja.",
            [nameof(LinkListFileType)] = "Linklista",
            [nameof(LinkListEmptyMessage)] = "Nem található link ebben a fájlban",
            [nameof(HistoryButton)] = "Előzmények",
            [nameof(HistoryTooltip)] = "Ezen a számítógépen végzett letöltések",
            [nameof(HistoryTitle)] = "Letöltési előzmények",
            [nameof(HistoryEmptyText)] = "Még nincs letöltés",
            [nameof(HistoryOpenCsvButton)] = "CSV-FÁJL MEGNYITÁSA",
            [nameof(HistoryDateColumnHeader)] = "Dátum",
            [nameof(HistoryUserColumnHeader)] = "Felhasználó",
            [nameof(HistoryTitleColumnHeader)] = "Cím",
            [nameof(HistoryUrlColumnHeader)] = "URL",
            [nameof(HistoryFileColumnHeader)] = "Fájl",
            [nameof(HistoryStatusColumnHeader)] = "Állapot",
            [nameof(DeferredModeLabel)] = "Letöltés később ({0}-tól)",
            [nameof(DeferredModeTooltip)] =
                "Az opció bekapcsolt állapotában hozzáadott videók letöltés előtt megvárják az ütemezett időpontot (a beállításokban adható meg), pl. hogy ne lassítsák az iskolai hálózatot az órák alatt. Hagyja nyitva az alkalmazást.",
            [nameof(DownloadStatusScheduled)] = "Ütemezve: {0}",
            [nameof(SummaryScheduledLabel)] = "ütemezett",
            [nameof(MaxDownloadRateLabel)] = "Sebességkorlát (KB/s)",
            [nameof(MaxDownloadRateTooltip)] =
                "A teljes letöltési sebesség felső határa kilobájt/másodpercben, az iskolai hálózat megosztásához. 0 = korlátlan.",
            [nameof(ScheduledStartTimeLabel)] = "Ütemezett kezdési idő",
            [nameof(ScheduledStartTimeTooltip)] =
                "Az időpont (ÓÓ:pp), amikor a \"Letöltés később\" opcióval hozzáadott letöltések elindulnak",
            [nameof(PreviewButton)] = "Előnézet",
            [nameof(PreviewTooltip)] =
                "A videó megtekintése itt a letöltés előtt (a részlet elejétől indul, ha meg van adva)",
            [nameof(PreviewOpenInBrowserButton)] = "Megnyitás böngészőben",
            [nameof(PreviewCloseButton)] = "Előnézet bezárása",
            // Color themes
            [nameof(DownloadStatusTrimming)] = "Részlet kivágása… {0}",
            [nameof(ColorThemeLabel)] = "Színek",
            [nameof(ColorThemeTooltip)] = "A felület színpalettája",
            [nameof(ColorThemeSchool)] = "Iskolai kék",
            [nameof(ColorThemeNature)] = "Természetzöld",
            [nameof(ColorThemeOcean)] = "Óceán",
            [nameof(ColorThemeLavender)] = "Levendula",
            [nameof(ColorThemeSunset)] = "Naplemente",
            [nameof(ColorThemeClassic)] = "Klasszikus",
            // Settings
            [nameof(SettingsTitle)] = "Beállítások",
            [nameof(ThemeLabel)] = "Téma",
            [nameof(ThemeTooltip)] = "Felhasználói felület témája",
            [nameof(LanguageLabel)] = "Nyelv",
            [nameof(LanguageTooltip)] = "Felhasználói felület nyelve",
            [nameof(AutoUpdateLabel)] = "Automatikus frissítés",
            [nameof(AutoUpdateTooltip)] = """
                Frissítések keresése minden indításkor.
                **Figyelem:** javasolt ennek a beállításnak a bekapcsolása annak érdekében, hogy az alkalmazás mindig naprakész és a YouTube aktuális szolgáltatásaival kompatibilis legyen.
                """,
            [nameof(PersistAuthLabel)] = "Bejelentkezve maradok",
            [nameof(PersistAuthTooltip)] = """
                Sütik elmentése fájlba, hogy a későbbi munkamenetek során is belépve tudj maradni.
                **Figyelem**: bár a sütik titkosítva tárolódnak, hozzáértő támadók a rendszeredhez hozzáférve vissza tudják fejteni.
                """,
            [nameof(InjectAltLanguagesLabel)] = "Alternatív nyelvek beszúrása",
            [nameof(InjectAltLanguagesTooltip)] =
                "Más nyelvű audiosávok beszúrása (amennyiben léteznek) a letöltött fájlba",
            [nameof(InjectSubtitlesLabel)] = "Feliratok beszúrása",
            [nameof(InjectSubtitlesTooltip)] = "Feliratok (ha vannak) beszúrása a letöltött fájlba",
            [nameof(InjectTagsLabel)] = "Médiacímkék beszúrása",
            [nameof(InjectTagsTooltip)] = "Médiacímkék (ha vannak) beszúrása a letöltött fájlokba",
            [nameof(SkipExistingFilesLabel)] = "Létező fájlok kihagyása",
            [nameof(SkipExistingFilesTooltip)] =
                "Több videó letöltése esetén azok kihagyása, amik már léteznek a célmappában",
            [nameof(FileNameTemplateLabel)] = "Fájlnévminta",
            [nameof(FileNameTemplateTooltip)] = """
                A letöltött videók fájlnevének létrehozásához használt minta.

                Elérhető változók:
                **$num** — videó pozíciója/sorszáma a listában (ha van)
                **$id** — videó azonosítója
                **$title** — videó címe
                **$author** — videó szerzője
                """,
            [nameof(ParallelLimitLabel)] = "Egyidejű letöltések",
            [nameof(ParallelLimitTooltip)] = "Hány letöltés futhat egyidejűleg",
            [nameof(FFmpegPathLabel)] = "FFmpeg elérési útja",
            [nameof(FFmpegPathTooltip)] =
                "Az FFmpeg futtatható fájljának elérési útja. Az automatikus felismeréshez hagyd üresen",
            [nameof(FFmpegPathPlaceholderText)] = "Automatikus felismerés",
            [nameof(FFmpegPathResetTooltip)] = "Visszaállítás automatikus felismerésre",
            [nameof(FFmpegPathBrowseTooltip)] = "FFmpeg tallózása",
            // Auth Setup
            [nameof(AuthenticationTitle)] = "Bejelentkezés",
            [nameof(AuthenticatedText)] = "Be vagy jelentkezve",
            [nameof(LogOutButton)] = "Kijelentkezés",
            [nameof(AuthenticationPlaceholderText)] = """
                Betöltés...

                Ha a böngésző nem jelenik meg:
                - Windows: telepítsd a Microsoft Edge WebView2 Runtime-ot.
                - macOS: telepítsd a legújabb rendszerfrissítéseket.
                - Linux: telepítsd a GTK 3-at, a WebKitGTK 4.1-et és a libsoup 3-at.
                """,
            // Download Single Setup
            [nameof(CopyMenuItem)] = "Másolás",
            [nameof(LiveLabel)] = "Élő",
            [nameof(AudioLabel)] = "Audió",
            [nameof(UpscaledLabel)] = "Felskálázott",
            [nameof(FormatLabel)] = "Formátum",
            // Download Multiple Setup
            [nameof(ContainerLabel)] = "Konténer",
            [nameof(VideoQualityLabel)] = "Videó minőség",
            // Common buttons
            [nameof(CloseButton)] = "BEZÁRÁS",
            [nameof(DownloadButton)] = "LETÖLTÉS",
            [nameof(CancelButton)] = "MÉGSE",
            // Dialog messages
            [nameof(UkraineSupportTitle)] = "Köszönet Ukrajna támogatásáért!",
            [nameof(UkraineSupportMessage)] = """
                Mialatt Oroszország népirtó háborút vív hazám ellen, hálás vagyok mindenkinek, aki továbbra is Ukrajna mellett áll a szabadságért folytatott harcunkban.

                A TUDJ MEG TÖBBET gombra kattintva megtudhatod, hogyan segíthetsz.
                """,
            [nameof(LearnMoreButton)] = "Tudj meg többet",
            [nameof(UnstableBuildTitle)] = "Figyelmeztetés nem stabil kiadásra",
            [nameof(UnstableBuildMessage)] = """
                A(z) {0} fejlesztői verzióját használod. Ezek a kiadások még nincsenek alaposan tesztelve és hibákat tartalmazhatnak.

                Automatikus frissítések ki vannak kapcsolva a fejlesztői verziók esetén.

                Válaszd inkább a KIADÁSOK MEGTEKINTÉSE opciót a stabil kiadás letöltéséhez.
                """,
            [nameof(SeeReleasesButton)] = "KIADÁSOK MEGTEKINTÉSE",
            [nameof(FFmpegMissingTitle)] = "Az FFmpeg hiányzik",
            [nameof(FFmpegMissingMessage)] = """
                Az FFmpeg nem található a rendszereden. A(z) {0} működéséhez szükség van rá. Szeretnéd most letölteni?

                Másik lehetőségként bezárhatod ezt az ablakot, és saját kezűleg beállíthatod az FFmpeg elérési útját a beállításokban.
                """,
            [nameof(FFmpegDownloadingTitle)] = "FFmpeg letöltése...",
            [nameof(FFmpegDownloadCompletedTitle)] = "FFmpeg letöltve",
            [nameof(NothingFoundTitle)] = "Nem található",
            [nameof(NothingFoundMessage)] =
                "Nem találhatók videók a megadott keresés vagy URL alapján.",
            [nameof(ErrorTitle)] = "Hiba",
            [nameof(UpdateDownloadingMessage)] = "Frissítés letöltése a(z) {0} v{1} verzióra...",
            [nameof(UpdateReadyMessage)] =
                "A frissítés letöltődött és telepítve lesz, miután bezártad az alkalmazást",
            [nameof(UpdateInstallNowButton)] = "TELEPÍTÉS MOST",
            [nameof(UpdateFailedMessage)] = "Az alkalmazás frissítése sikertelen",
        };
}
