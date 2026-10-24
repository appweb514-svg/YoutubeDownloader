using System.Collections.Generic;

namespace YoutubeDownloader.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> ChineseSimplifiedLocalization =
        new Dictionary<string, string>
        {
            // Dashboard
            [nameof(QueryPlaceholderText)] = "粘贴链接或搜索",
            [nameof(QueryTooltip)] =
                "接受任何有效的 YouTube 网页链接或视频 ID。在开头添加问号 (?) 可进行文本搜索。",
            [nameof(ProcessQueryTooltip)] = "开始查询 (Enter)",
            [nameof(AuthTooltip)] = "身份验证",
            [nameof(SettingsTooltip)] = "设置",
            [nameof(DashboardPlaceholder)] = """
                复制并粘贴 **网页链接** 或 **搜索** 以开始下载
                使用 **Shift+Enter** 可添加多个项目
                """,
            [nameof(DownloadsFileColumnHeader)] = "文件",
            [nameof(DownloadsStatusColumnHeader)] = "状态",
            [nameof(ContextMenuRemoveSuccessful)] = "移除已完成的下载",
            [nameof(ContextMenuRemoveInactive)] = "移除未激活的下载",
            [nameof(ContextMenuRestartFailed)] = "重下失败的下载",
            [nameof(ContextMenuCancelAll)] = "取消所有下载",
            [nameof(DownloadStatusEnqueued)] = "正在排队...",
            [nameof(DownloadStatusCompleted)] = "已完成",
            [nameof(DownloadStatusCanceled)] = "已取消",
            [nameof(DownloadStatusFailed)] = "失败",
            [nameof(ClickToCopyErrorTooltip)] = "提示：点击可复制此错误信息",
            [nameof(ShowFileTooltip)] = "显示文件",
            [nameof(PlayTooltip)] = "播放",
            [nameof(CancelDownloadTooltip)] = "取消下载",
            [nameof(RestartDownloadTooltip)] = "重新下载",
            // School
            [nameof(AppHeaderTitle)] = "视频库",
            [nameof(AppHeaderSubtitle)] = "为您的课堂下载视频",
            [nameof(AddToLibraryButton)] = "添加",
            [nameof(AccountButton)] = "YouTube 账户",
            [nameof(SettingsButton)] = "设置",
            [nameof(SchoolQueryPlaceholderText)] =
                "粘贴 YouTube 链接（视频、播放列表或频道），或输入关键词并在后面加上 ?",
            [nameof(StepCopyTitle)] = "复制链接",
            [nameof(StepCopyText)] = "在 YouTube 上点击“分享”，然后点击“复制”",
            [nameof(StepPasteTitle)] = "粘贴到上方",
            [nameof(StepPasteText)] = "多个链接？每行一个（Shift+Enter）",
            [nameof(StepDownloadTitle)] = "选择画质",
            [nameof(StepDownloadText)] = "MP4 可在所有教室电脑上播放",
            [nameof(CopyrightNoticeTitle)] = "尊重版权",
            [nameof(CopyrightNoticeMessage)] =
                "仅下载允许在课堂上使用的视频：知识共享（Creative Commons）许可、教育用途例外或作者授权。请查阅学校的相关规定。",
            [nameof(DownloadsListTitle)] = "下载",
            [nameof(SummaryActiveLabel)] = "进行中",
            [nameof(SummaryCompletedLabel)] = "已完成",
            [nameof(SummaryFailedLabel)] = "失败",
            [nameof(RetryFailedButton)] = "重试失败项",
            [nameof(ClearListButton)] = "清除已完成",
            [nameof(CancelAllButton)] = "全部取消",
            [nameof(OpenLibraryFolderButton)] = "打开文件夹",
            [nameof(SchoolSectionLabel)] = "学校",
            [nameof(SchoolNameLabel)] = "学校名称",
            [nameof(SchoolNameTooltip)] = "显示在窗口顶部",
            [nameof(SchoolNamePlaceholderText)] = "例如：第一实验小学",
            [nameof(DefaultDownloadDirLabel)] = "下载文件夹",
            [nameof(DefaultDownloadDirTooltip)] =
                "视频会自动保存到此处，无需每次询问（例如共享网络驱动器）。留空则每次手动选择。",
            [nameof(DefaultDownloadDirPlaceholderText)] = "每次询问",
            [nameof(GeneralSectionLabel)] = "常规",
            [nameof(ClipSectionLabel)] = "片段（可选）",
            [nameof(ClipStartLabel)] = "开始",
            [nameof(ClipEndLabel)] = "结束",
            [nameof(ClipPlaceholderText)] = "h:mm:ss 或 mm:ss",
            [nameof(ClipTooltip)] = "仅保留视频的一部分。留空则下载完整视频。",
            [nameof(ClipInvalidFormatMessage)] = "请使用 h:mm:ss 或 mm:ss 格式（例如 1:30）。",
            [nameof(ClipEndBeforeStartMessage)] = "结束时间必须晚于开始时间。",
            [nameof(ClipOutOfRangeMessage)] = "片段超出了视频的时长。",
            [nameof(ClipLabel)] = "片段",
            [nameof(ClassPresetButton)] = "课堂预设",
            [nameof(ClassPresetTooltip)] =
                "MP4，最高 720p 的最佳画质：可在所有教室电脑和投影仪上播放",
            [nameof(ClassPresetDefaultLabel)] = "默认使用课堂预设",
            [nameof(ClassPresetDefaultTooltip)] = "选择格式时自动选中最高 720p 的 MP4",
            [nameof(SaveSubtitleFilesLabel)] = "将字幕另存为 .srt 文件",
            [nameof(SaveSubtitleFilesTooltip)] =
                "同时将字幕以独立的 .srt 文件保存在视频旁边（仅保留片段时，字幕时间不会随之偏移）",
            [nameof(SubtitleLanguageLabel)] = "字幕语言",
            [nameof(SubtitleLanguageTooltip)] =
                "要保留的字幕语言代码（例如 zh、en）。留空则保留所有语言。如果视频没有该语言的字幕，则保留全部字幕。",
            [nameof(SubtitleLanguagePlaceholderText)] = "所有语言",
            [nameof(CategoryLabel)] = "归档到",
            [nameof(CategoryPlaceholderText)] = "例如：五年级/科学",
            [nameof(CategoryTooltip)] =
                "下载文件夹中用于后续下载的子文件夹（班级、学科…）。使用 / 创建多级目录。留空则直接保存到下载文件夹。",
            [nameof(WriteSourceFileLabel)] = "生成来源文件",
            [nameof(WriteSourceFileTooltip)] =
                "在每个视频旁保存一个 .source.txt 文件，包含标题、频道、链接、下载日期和许可提醒，便于在课堂上注明来源",
            [nameof(SourceFileTitleLine)] = "标题：{0}",
            [nameof(SourceFileChannelLine)] = "频道：{0}",
            [nameof(SourceFileVideoUrlLine)] = "视频：{0}",
            [nameof(SourceFileChannelUrlLine)] = "频道页面：{0}",
            [nameof(SourceFileDurationLine)] = "时长：{0}",
            [nameof(SourceFileClipLine)] = "片段：{0}",
            [nameof(SourceFileDownloadedAtLine)] = "下载日期：{0}",
            [nameof(SourceFileSchoolLine)] = "学校：{0}",
            [nameof(SourceFileLicenseLine)] =
                "许可：请在视频页面上核实（知识共享许可、教育用途例外…）",
            [nameof(AdminSectionLabel)] = "管理",
            [nameof(AdminPinLabel)] = "管理员 PIN 码",
            [nameof(AdminPinTooltip)] = "设置 PIN 码后，打开设置或 YouTube 账户时需要输入该 PIN 码",
            [nameof(AdminPinPlaceholderText)] = "至少 4 个字符",
            [nameof(AdminPinSetButton)] = "设置",
            [nameof(AdminPinActiveLabel)] = "设置已被 PIN 码锁定",
            [nameof(AdminPinRemoveButton)] = "移除 PIN 码",
            [nameof(MaxVideoQualityLabel)] = "最高画质",
            [nameof(MaxVideoQualityTooltip)] = "下载时提供的最高视频画质（节省带宽和磁盘空间）",
            [nameof(PinPromptTitle)] = "已锁定",
            [nameof(PinPromptMessage)] = "请输入管理员 PIN 码以继续。",
            [nameof(PinPlaceholderText)] = "PIN",
            [nameof(PinWrongMessage)] = "PIN 码错误，请重试。",
            [nameof(UnlockButton)] = "解锁",
            [nameof(ImportLinkListButton)] = "导入列表",
            [nameof(ImportLinkListTooltip)] =
                "打开每行一个 YouTube 链接的 .txt 或 .csv 文件（电子表格取第一列）。以 # 开头的行将被忽略。",
            [nameof(LinkListFileType)] = "链接列表",
            [nameof(LinkListEmptyMessage)] = "此文件中未找到链接",
            [nameof(HistoryButton)] = "历史记录",
            [nameof(HistoryTooltip)] = "在此电脑上进行的下载",
            [nameof(HistoryTitle)] = "下载历史记录",
            [nameof(HistoryEmptyText)] = "暂无下载",
            [nameof(HistoryOpenCsvButton)] = "打开 CSV 文件",
            [nameof(HistoryDateColumnHeader)] = "日期",
            [nameof(HistoryUserColumnHeader)] = "用户",
            [nameof(HistoryTitleColumnHeader)] = "标题",
            [nameof(HistoryUrlColumnHeader)] = "URL",
            [nameof(HistoryFileColumnHeader)] = "文件",
            [nameof(HistoryStatusColumnHeader)] = "状态",
            [nameof(DeferredModeLabel)] = "稍后下载（从 {0} 开始）",
            [nameof(DeferredModeTooltip)] =
                "开启此选项时添加的视频会等到预定时间（在设置中指定）才开始下载，例如避免在上课期间拖慢学校网络。请保持应用处于打开状态。",
            [nameof(DownloadStatusScheduled)] = "已计划于 {0}",
            [nameof(SummaryScheduledLabel)] = "已计划",
            [nameof(MaxDownloadRateLabel)] = "速度限制（KB/s）",
            [nameof(MaxDownloadRateTooltip)] =
                "总下载速度上限，单位为千字节每秒，用于合理共享学校网络。0 = 不限制。",
            [nameof(ScheduledStartTimeLabel)] = "计划开始时间",
            [nameof(ScheduledStartTimeTooltip)] = "通过\"稍后下载\"添加的下载开始的时间（HH:mm）",
            [nameof(PreviewButton)] = "预览",
            [nameof(PreviewTooltip)] = "下载前在此观看视频（如已设置片段，则从片段开头开始播放）",
            [nameof(PreviewOpenInBrowserButton)] = "在浏览器中打开",
            [nameof(PreviewCloseButton)] = "关闭预览",
            // Color themes
            [nameof(DownloadStatusTrimming)] = "正在剪辑片段… {0}",
            [nameof(ColorThemeLabel)] = "颜色",
            [nameof(ColorThemeTooltip)] = "界面配色方案",
            [nameof(ColorThemeSchool)] = "校园蓝",
            [nameof(ColorThemeNature)] = "自然绿",
            [nameof(ColorThemeOcean)] = "海洋",
            [nameof(ColorThemeLavender)] = "薰衣草",
            [nameof(ColorThemeSunset)] = "日落",
            [nameof(ColorThemeClassic)] = "经典",
            // Settings
            [nameof(SettingsTitle)] = "设置",
            [nameof(ThemeLabel)] = "主题",
            [nameof(ThemeTooltip)] = "首选的用户界面主题",
            [nameof(LanguageLabel)] = "语言",
            [nameof(LanguageTooltip)] = "首选的用户界面显示语言",
            [nameof(AutoUpdateLabel)] = "自动更新",
            [nameof(AutoUpdateTooltip)] = """
                每次启动时执行自动更新。
                **警告：** 建议保持此选项启用，以确保应用程序与最新版本的 YouTube 兼容。
                """,
            [nameof(PersistAuthLabel)] = "持久化身份验证",
            [nameof(PersistAuthTooltip)] = """
                将身份验证 Cookie 保存到文件中，以便在不同会话之间持久化。
                **警告：** 尽管 Cookie 是加密存储的，但拥有系统访问权限的攻击者仍可能恢复它们。
                """,
            [nameof(InjectAltLanguagesLabel)] = "注入多音轨",
            [nameof(InjectAltLanguagesTooltip)] =
                "将替代语言的音频轨道（如果可用）注入到下载的文件中",
            [nameof(InjectSubtitlesLabel)] = "注入字幕",
            [nameof(InjectSubtitlesTooltip)] = "将字幕（如果可用）注入到下载的文件中",
            [nameof(InjectTagsLabel)] = "注入媒体标签",
            [nameof(InjectTagsTooltip)] = "将媒体标签（如果可用）注入到下载的文件中",
            [nameof(SkipExistingFilesLabel)] = "跳过已存在的文件",
            [nameof(SkipExistingFilesTooltip)] =
                "下载多个视频时，跳过输出目录中已存在匹配文件的视频",
            [nameof(FileNameTemplateLabel)] = "文件名模板",
            [nameof(FileNameTemplateTooltip)] = """
                用于生成下载视频文件名的模板。

                可用标记：
                **$num** — 视频在列表中的位置（如果适用）
                **$id** — 视频 ID
                **$title** — 视频标题
                **$author** — 视频作者
                """,
            [nameof(ParallelLimitLabel)] = "并行下载限制",
            [nameof(ParallelLimitTooltip)] = "允许同时进行的下载任务数量",
            [nameof(FFmpegPathLabel)] = "FFmpeg 路径",
            [nameof(FFmpegPathTooltip)] = "FFmpeg 可执行文件的路径。留空则使用自动检测。",
            [nameof(FFmpegPathPlaceholderText)] = "自动检测",
            [nameof(FFmpegPathResetTooltip)] = "重置为自动检测",
            [nameof(FFmpegPathBrowseTooltip)] = "浏览 FFmpeg 可执行文件",
            // Auth Setup
            [nameof(AuthenticationTitle)] = "身份验证",
            [nameof(AuthenticatedText)] = "你当前已通过身份验证",
            [nameof(LogOutButton)] = "退出登录",
            [nameof(AuthenticationPlaceholderText)] = """
                正在加载...

                如果浏览器未显示：
                - Windows：安装 Microsoft Edge WebView2 Runtime。
                - macOS：安装最新的系统更新。
                - Linux：安装 GTK 3、WebKitGTK 4.1 和 libsoup 3。
                """,
            // Download Single Setup
            [nameof(CopyMenuItem)] = "复制",
            [nameof(LiveLabel)] = "直播",
            [nameof(AudioLabel)] = "音频",
            [nameof(UpscaledLabel)] = "超分辨率",
            [nameof(FormatLabel)] = "格式",
            // Download Multiple Setup
            [nameof(ContainerLabel)] = "封装格式",
            [nameof(VideoQualityLabel)] = "视频质量",
            // Common buttons
            [nameof(CloseButton)] = "关闭",
            [nameof(DownloadButton)] = "下载",
            [nameof(CancelButton)] = "取消",
            // Dialog messages
            [nameof(UkraineSupportTitle)] = "感谢你支持乌克兰！",
            [nameof(UkraineSupportMessage)] = """
                由于俄罗斯正对我的国家发动一场种族灭绝战争，我向所有在我们的自由之战中继续支持乌克兰的人表示感谢。

                点击“了解更多”以寻找你可以提供帮助的途径。
                """,
            [nameof(LearnMoreButton)] = "了解更多",
            [nameof(UnstableBuildTitle)] = "不稳定版本警告",
            [nameof(UnstableBuildMessage)] = """
                你正在使用 {0} 的开发版本。这些版本未经严格测试，可能包含漏洞。

                开发版本已禁用自动更新。

                如果你想下载稳定版本，请点击“查看发布版本”。
                """,
            [nameof(SeeReleasesButton)] = "查看发布版本",
            [nameof(FFmpegMissingTitle)] = "缺少 FFmpeg",
            [nameof(FFmpegMissingMessage)] = """
                系统中未找到 FFmpeg。{0} 需要它才能正常工作。是否立即下载？

                或者，您可以关闭此对话框，并在设置中手动指定自定义 FFmpeg 路径。
                """,
            [nameof(FFmpegDownloadingTitle)] = "正在下载 FFmpeg...",
            [nameof(FFmpegDownloadCompletedTitle)] = "FFmpeg 下载完成",
            [nameof(NothingFoundTitle)] = "未找到内容",
            [nameof(NothingFoundMessage)] = "无法根据你提供的查询或 URL 找到任何视频",
            [nameof(ErrorTitle)] = "错误",
            [nameof(UpdateDownloadingMessage)] = "正在下载更新至 {0} v{1}...",
            [nameof(UpdateReadyMessage)] = "更新已下载，将在你退出时安装",
            [nameof(UpdateInstallNowButton)] = "立即安装",
            [nameof(UpdateFailedMessage)] = "应用程序更新失败",
        };
}
