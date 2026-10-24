using System.Collections.Generic;

namespace YoutubeDownloader.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> UkrainianLocalization =
        new Dictionary<string, string>
        {
            // Dashboard
            [nameof(QueryPlaceholderText)] = "URL або пошуковий запит",
            [nameof(QueryTooltip)] =
                "Приймається будь-який дійсний URL або ID YouTube. Додайте знак питання (?) для пошуку за текстом.",
            [nameof(ProcessQueryTooltip)] = "Виконати запит (Enter)",
            [nameof(AuthTooltip)] = "Автентифікація",
            [nameof(SettingsTooltip)] = "Налаштування",
            [nameof(DashboardPlaceholder)] = """
                Вставте **URL** або введіть **пошуковий запит** для завантаження
                Натисніть **Shift+Enter**, щоб додати декілька елементів
                """,
            [nameof(DownloadsFileColumnHeader)] = "Файл",
            [nameof(DownloadsStatusColumnHeader)] = "Статус",
            [nameof(ContextMenuRemoveSuccessful)] = "Видалити успішні завантаження",
            [nameof(ContextMenuRemoveInactive)] = "Видалити неактивні завантаження",
            [nameof(ContextMenuRestartFailed)] = "Перезапустити невдалі завантаження",
            [nameof(ContextMenuCancelAll)] = "Скасувати всі завантаження",
            [nameof(DownloadStatusEnqueued)] = "В черзі...",
            [nameof(DownloadStatusCompleted)] = "Готово",
            [nameof(DownloadStatusCanceled)] = "Скасовано",
            [nameof(DownloadStatusFailed)] = "Помилка",
            [nameof(ClickToCopyErrorTooltip)] = "Примітка: натисніть, щоб скопіювати повідомлення",
            [nameof(ShowFileTooltip)] = "Показати файл",
            [nameof(PlayTooltip)] = "Відтворити",
            [nameof(CancelDownloadTooltip)] = "Скасувати завантаження",
            [nameof(RestartDownloadTooltip)] = "Перезапустити завантаження",
            // School
            [nameof(AppHeaderTitle)] = "Відеотека",
            [nameof(AppHeaderSubtitle)] = "Завантажуйте відео для своїх уроків",
            [nameof(AddToLibraryButton)] = "Додати",
            [nameof(AccountButton)] = "Обліковий запис YouTube",
            [nameof(SettingsButton)] = "Налаштування",
            [nameof(SchoolQueryPlaceholderText)] =
                "Вставте посилання YouTube (відео, плейлист або канал) або введіть ключові слова, а після них ?",
            [nameof(StepCopyTitle)] = "Скопіюйте посилання",
            [nameof(StepCopyText)] = "На YouTube натисніть «Поділитися», а потім «Копіювати»",
            [nameof(StepPasteTitle)] = "Вставте його вище",
            [nameof(StepPasteText)] = "Кілька посилань? По одному в рядку (Shift+Enter)",
            [nameof(StepDownloadTitle)] = "Оберіть якість",
            [nameof(StepDownloadText)] = "MP4 відтворюється на будь-якому комп'ютері в класі",
            [nameof(CopyrightNoticeTitle)] = "Дотримуйтеся авторського права",
            [nameof(CopyrightNoticeMessage)] =
                "Завантажуйте лише ті відео, які дозволено використовувати на уроках: ліцензія Creative Commons, освітній виняток або дозвіл автора. Ознайомтеся з правилами вашої школи.",
            [nameof(DownloadsListTitle)] = "Завантаження",
            [nameof(SummaryActiveLabel)] = "триває",
            [nameof(SummaryCompletedLabel)] = "готово",
            [nameof(SummaryFailedLabel)] = "з помилкою",
            [nameof(RetryFailedButton)] = "Повторити невдалі",
            [nameof(ClearListButton)] = "Прибрати завершені",
            [nameof(CancelAllButton)] = "Скасувати все",
            [nameof(OpenLibraryFolderButton)] = "Відкрити папку",
            [nameof(SchoolSectionLabel)] = "Школа",
            [nameof(SchoolNameLabel)] = "Назва школи",
            [nameof(SchoolNameTooltip)] = "Відображається у верхній частині вікна",
            [nameof(SchoolNamePlaceholderText)] = "напр. Ліцей № 1",
            [nameof(DefaultDownloadDirLabel)] = "Папка завантажень",
            [nameof(DefaultDownloadDirTooltip)] =
                "Відео автоматично зберігаються сюди без запиту щоразу (наприклад, спільний диск). Залиште порожнім, щоб обирати щоразу.",
            [nameof(DefaultDownloadDirPlaceholderText)] = "Запитувати щоразу",
            [nameof(GeneralSectionLabel)] = "Загальні",
            [nameof(ClipSectionLabel)] = "Фрагмент (необов'язково)",
            [nameof(ClipStartLabel)] = "Початок",
            [nameof(ClipEndLabel)] = "Кінець",
            [nameof(ClipPlaceholderText)] = "г:хх:сс або хх:сс",
            [nameof(ClipTooltip)] =
                "Зберегти лише частину відео. Залиште порожнім, щоб завантажити все відео.",
            [nameof(ClipInvalidFormatMessage)] =
                "Використовуйте формат г:хх:сс або хх:сс (напр. 1:30).",
            [nameof(ClipEndBeforeStartMessage)] = "Кінець має бути пізніше за початок.",
            [nameof(ClipOutOfRangeMessage)] = "Фрагмент виходить за межі тривалості відео.",
            [nameof(ClipLabel)] = "Фрагмент",
            [nameof(ClassPresetButton)] = "Шаблон для класу",
            [nameof(ClassPresetTooltip)] =
                "MP4, найкраща якість до 720p: відтворюється на будь-якому комп'ютері та проєкторі в класі",
            [nameof(ClassPresetDefaultLabel)] = "Шаблон для класу за замовчуванням",
            [nameof(ClassPresetDefaultTooltip)] =
                "Автоматично обирати MP4 до 720p під час вибору формату",
            [nameof(SaveSubtitleFilesLabel)] = "Зберігати субтитри у файлах .srt",
            [nameof(SaveSubtitleFilesTooltip)] =
                "Також зберігати субтитри поруч із відео окремими файлами .srt (вони не зсуваються, якщо зберігається лише фрагмент)",
            [nameof(SubtitleLanguageLabel)] = "Мова субтитрів",
            [nameof(SubtitleLanguageTooltip)] =
                "Код мови субтитрів, які слід зберегти (напр. uk, en). Залиште порожнім, щоб зберегти всі мови. Якщо у відео немає субтитрів цією мовою, буде збережено всі.",
            [nameof(SubtitleLanguagePlaceholderText)] = "Усі мови",
            [nameof(CategoryLabel)] = "Зберегти в",
            [nameof(CategoryPlaceholderText)] = "напр. 5 клас/Природознавство",
            [nameof(CategoryTooltip)] =
                "Підпапка папки завантажень для наступних завантажень (клас, предмет…). Використовуйте /, щоб створити кілька рівнів. Залиште порожнім, щоб зберігати безпосередньо в папку завантажень.",
            [nameof(WriteSourceFileLabel)] = "Створювати файл джерела",
            [nameof(WriteSourceFileTooltip)] =
                "Зберігати поруч із кожним відео файл .source.txt із назвою, каналом, посиланням, датою завантаження та нагадуванням про ліцензію, щоб вказати джерело на уроці",
            [nameof(SourceFileTitleLine)] = "Назва: {0}",
            [nameof(SourceFileChannelLine)] = "Канал: {0}",
            [nameof(SourceFileVideoUrlLine)] = "Відео: {0}",
            [nameof(SourceFileChannelUrlLine)] = "Сторінка каналу: {0}",
            [nameof(SourceFileDurationLine)] = "Тривалість: {0}",
            [nameof(SourceFileClipLine)] = "Фрагмент: {0}",
            [nameof(SourceFileDownloadedAtLine)] = "Завантажено: {0}",
            [nameof(SourceFileSchoolLine)] = "Школа: {0}",
            [nameof(SourceFileLicenseLine)] =
                "Ліцензія: перевірте на сторінці відео (Creative Commons, освітній виняток…)",
            [nameof(AdminSectionLabel)] = "Адміністрування",
            [nameof(AdminPinLabel)] = "PIN адміністратора",
            [nameof(AdminPinTooltip)] =
                "Якщо PIN встановлено, він потрібен для відкриття налаштувань або облікового запису YouTube",
            [nameof(AdminPinPlaceholderText)] = "щонайменше 4 символи",
            [nameof(AdminPinSetButton)] = "Встановити",
            [nameof(AdminPinActiveLabel)] = "Налаштування заблоковано PIN-кодом",
            [nameof(AdminPinRemoveButton)] = "Видалити PIN",
            [nameof(MaxVideoQualityLabel)] = "Максимальна якість",
            [nameof(MaxVideoQualityTooltip)] =
                "Найвища якість відео, яка пропонується під час завантаження (економить трафік і місце на диску)",
            [nameof(PinPromptTitle)] = "Заблоковано",
            [nameof(PinPromptMessage)] = "Введіть PIN адміністратора, щоб продовжити.",
            [nameof(PinPlaceholderText)] = "PIN",
            [nameof(PinWrongMessage)] = "Неправильний PIN, спробуйте ще раз.",
            [nameof(UnlockButton)] = "РОЗБЛОКУВАТИ",
            [nameof(ImportLinkListButton)] = "Імпортувати список",
            [nameof(ImportLinkListTooltip)] =
                "Відкрити файл .txt або .csv з одним посиланням YouTube у кожному рядку (перший стовпець для таблиці). Рядки, що починаються з #, ігноруються.",
            [nameof(LinkListFileType)] = "Список посилань",
            [nameof(LinkListEmptyMessage)] = "У цьому файлі не знайдено жодного посилання",
            [nameof(HistoryButton)] = "Історія",
            [nameof(HistoryTooltip)] = "Завантаження, виконані на цьому комп'ютері",
            [nameof(HistoryTitle)] = "Історія завантажень",
            [nameof(HistoryEmptyText)] = "Ще немає завантажень",
            [nameof(HistoryOpenCsvButton)] = "ВІДКРИТИ ФАЙЛ CSV",
            [nameof(HistoryDateColumnHeader)] = "Дата",
            [nameof(HistoryUserColumnHeader)] = "Користувач",
            [nameof(HistoryTitleColumnHeader)] = "Назва",
            [nameof(HistoryUrlColumnHeader)] = "URL",
            [nameof(HistoryFileColumnHeader)] = "Файл",
            [nameof(HistoryStatusColumnHeader)] = "Статус",
            [nameof(DeferredModeLabel)] = "Завантажити пізніше (з {0})",
            [nameof(DeferredModeTooltip)] =
                "Відео, додані при ввімкненій опції, чекають запланованого часу (задається в налаштуваннях) перед завантаженням, напр. щоб не сповільнювати шкільну мережу під час уроків. Не закривайте застосунок.",
            [nameof(DownloadStatusScheduled)] = "Заплановано на {0}",
            [nameof(SummaryScheduledLabel)] = "заплановано",
            [nameof(MaxDownloadRateLabel)] = "Обмеження швидкості (КБ/с)",
            [nameof(MaxDownloadRateTooltip)] =
                "Максимальна загальна швидкість завантаження в кілобайтах за секунду, щоб розподіляти шкільну мережу. 0 = без обмежень.",
            [nameof(ScheduledStartTimeLabel)] = "Запланований час початку",
            [nameof(ScheduledStartTimeTooltip)] =
                "Час (ГГ:хх), коли починаються завантаження, додані з опцією \"Завантажити пізніше\"",
            [nameof(PreviewButton)] = "Попередній перегляд",
            [nameof(PreviewTooltip)] =
                "Переглянути відео тут перед завантаженням (починається з початку фрагмента, якщо його задано)",
            [nameof(PreviewOpenInBrowserButton)] = "Відкрити в браузері",
            [nameof(PreviewCloseButton)] = "Закрити попередній перегляд",
            // Color themes
            [nameof(DownloadStatusTrimming)] = "Обрізання фрагмента… {0}",
            [nameof(YoutubeForbiddenMessage)] =
                "YouTube відмовив у доступі до цього відео (помилка 403). Часто це тимчасово: спробуйте ще раз за кілька хвилин. Якщо відео має вікове обмеження або є приватним, спершу увійдіть через «Обліковий запис YouTube».",
            [nameof(ColorThemeLabel)] = "Кольори",
            [nameof(ColorThemeTooltip)] = "Колірна палітра інтерфейсу",
            [nameof(ColorThemeSchool)] = "Шкільний синій",
            [nameof(ColorThemeNature)] = "Природний зелений",
            [nameof(ColorThemeOcean)] = "Океан",
            [nameof(ColorThemeLavender)] = "Лаванда",
            [nameof(ColorThemeSunset)] = "Захід сонця",
            [nameof(ColorThemeClassic)] = "Класична",
            // Settings
            [nameof(SettingsTitle)] = "Налаштування",
            [nameof(ThemeLabel)] = "Тема",
            [nameof(ThemeTooltip)] = "Бажана тема інтерфейсу",
            [nameof(LanguageLabel)] = "Мова",
            [nameof(LanguageTooltip)] = "Бажана мова відображення інтерфейсу користувача",
            [nameof(AutoUpdateLabel)] = "Авто-оновлення",
            [nameof(AutoUpdateTooltip)] = """
                Виконувати автоматичні оновлення при кожному запуску.
                **Увага:** рекомендується залишити цю опцію увімкненою для сумісності з останньою версією YouTube.
                """,
            [nameof(PersistAuthLabel)] = "Зберігати автентифікацію",
            [nameof(PersistAuthTooltip)] = """
                Зберігати файли cookie у файлі для збереження між сеансами.
                **Увага**: хоча cookies зберігаються із шифруванням, зловмисник з доступом до вашої системи може їх відновити.
                """,
            [nameof(InjectAltLanguagesLabel)] = "Вставляти альтернативні мови",
            [nameof(InjectAltLanguagesTooltip)] =
                "Вставляти аудіодоріжки альтернативними мовами (якщо доступні) у завантажені файли",
            [nameof(InjectSubtitlesLabel)] = "Вставляти субтитри",
            [nameof(InjectSubtitlesTooltip)] =
                "Вставляти субтитри (якщо доступні) у завантажені файли",
            [nameof(InjectTagsLabel)] = "Вставляти медіатеги",
            [nameof(InjectTagsTooltip)] = "Вставляти медіатеги (якщо доступні) у завантажені файли",
            [nameof(SkipExistingFilesLabel)] = "Пропускати наявні файли",
            [nameof(SkipExistingFilesTooltip)] =
                "При завантаженні кількох відео пропускати ті, для яких вже є відповідні файли",
            [nameof(FileNameTemplateLabel)] = "Шаблон імені файлу",
            [nameof(FileNameTemplateTooltip)] = """
                Шаблон для генерації імен файлів завантажених відео.

                Доступні токени:
                **$num** — позиція відео у списку (якщо застосовно)
                **$id** — ідентифікатор відео
                **$title** — назва відео
                **$author** — автор відео
                """,
            [nameof(ParallelLimitLabel)] = "Ліміт паралелізації",
            [nameof(ParallelLimitTooltip)] = "Скільки завантажень може бути активними одночасно",
            [nameof(FFmpegPathLabel)] = "Шлях FFmpeg",
            [nameof(FFmpegPathTooltip)] =
                "Шлях до виконуваного файлу FFmpeg. Залиште порожнім для автоматичного визначення.",
            [nameof(FFmpegPathPlaceholderText)] = "Авто",
            [nameof(FFmpegPathResetTooltip)] = "Скинути до автоматичного визначення",
            [nameof(FFmpegPathBrowseTooltip)] = "Вибрати файл FFmpeg",
            // Auth Setup
            [nameof(AuthenticationTitle)] = "Автентифікація",
            [nameof(AuthenticatedText)] = "Ви автентифіковані",
            [nameof(LogOutButton)] = "Вийти",
            [nameof(AuthenticationPlaceholderText)] = """
                Завантаження...

                Якщо браузер не відображається:
                - Windows: встановіть Microsoft Edge WebView2 Runtime.
                - macOS: встановіть останні оновлення системи.
                - Linux: встановіть GTK 3, WebKitGTK 4.1 і libsoup 3.
                """,
            // Download Single Setup
            [nameof(CopyMenuItem)] = "Копіювати",
            [nameof(LiveLabel)] = "Живе",
            [nameof(AudioLabel)] = "Аудіо",
            [nameof(UpscaledLabel)] = "Збільшене",
            [nameof(FormatLabel)] = "Формат",
            // Download Multiple Setup
            [nameof(ContainerLabel)] = "Контейнер",
            [nameof(VideoQualityLabel)] = "Якість відео",
            // Common buttons
            [nameof(CloseButton)] = "ЗАКРИТИ",
            [nameof(DownloadButton)] = "ЗАВАНТАЖИТИ",
            [nameof(CancelButton)] = "СКАСУВАТИ",
            // Dialog messages
            [nameof(UkraineSupportTitle)] = "Дякуємо за підтримку України!",
            [nameof(UkraineSupportMessage)] = """
                Поки Росія веде геноцидну війну проти моєї країни, я вдячний кожному, хто продовжує підтримувати Україну у нашій боротьбі за свободу.

                Натисніть ДІЗНАТИСЬ БІЛЬШЕ, щоб знайти способи допомогти.
                """,
            [nameof(LearnMoreButton)] = "ДІЗНАТИСЬ БІЛЬШЕ",
            [nameof(UnstableBuildTitle)] = "Попередження про нестабільну збірку",
            [nameof(UnstableBuildMessage)] = """
                Ви використовуєте збірку розробки {0}. Ці збірки не пройшли ретельного тестування та можуть містити помилки.

                Авто-оновлення вимкнено для збірок розробки.

                Натисніть ПЕРЕГЛЯНУТИ РЕЛІЗИ, щоб завантажити стабільний реліз.
                """,
            [nameof(SeeReleasesButton)] = "ПЕРЕГЛЯНУТИ РЕЛІЗИ",
            [nameof(FFmpegMissingTitle)] = "FFmpeg відсутній",
            [nameof(FFmpegMissingMessage)] = """
                FFmpeg не знайдено на вашому пристрої. Він потрібен для роботи {0}. Бажаєте завантажити його зараз?

                Або ви можете закрити це діалогове вікно та вручну вказати власний шлях до FFmpeg у налаштуваннях.
                """,
            [nameof(FFmpegDownloadingTitle)] = "Завантаження FFmpeg...",
            [nameof(FFmpegDownloadCompletedTitle)] = "FFmpeg завантажено",
            [nameof(NothingFoundTitle)] = "Нічого не знайдено",
            [nameof(NothingFoundMessage)] = "Не вдалося знайти відео за вказаним запитом або URL",
            [nameof(ErrorTitle)] = "Помилка",
            [nameof(UpdateDownloadingMessage)] = "Завантаження оновлення {0} v{1}...",
            [nameof(UpdateReadyMessage)] = "Оновлення завантажено та буде встановлено після виходу",
            [nameof(UpdateInstallNowButton)] = "ВСТАНОВИТИ ЗАРАЗ",
            [nameof(UpdateFailedMessage)] = "Не вдалося виконати оновлення програми",
        };
}
