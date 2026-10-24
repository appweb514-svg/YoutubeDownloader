using System.Collections.Generic;

namespace YoutubeDownloader.Localization;

public partial class LocalizationManager
{
    private static readonly IReadOnlyDictionary<string, string> SpanishLocalization =
        new Dictionary<string, string>
        {
            // Dashboard
            [nameof(QueryPlaceholderText)] = "URL o consulta de búsqueda",
            [nameof(QueryTooltip)] =
                "Se acepta cualquier URL o ID de YouTube válido. Antepone un signo de interrogación (?) para buscar por texto.",
            [nameof(ProcessQueryTooltip)] = "Procesar consulta (Enter)",
            [nameof(AuthTooltip)] = "Autenticación",
            [nameof(SettingsTooltip)] = "Configuración",
            [nameof(DashboardPlaceholder)] = """
                Pega una **URL** o ingresa una **consulta de búsqueda** para comenzar
                Presiona **Shift+Enter** para agregar múltiples elementos
                """,
            [nameof(DownloadsFileColumnHeader)] = "Archivo",
            [nameof(DownloadsStatusColumnHeader)] = "Estado",
            [nameof(ContextMenuRemoveSuccessful)] = "Eliminar descargas exitosas",
            [nameof(ContextMenuRemoveInactive)] = "Eliminar descargas inactivas",
            [nameof(ContextMenuRestartFailed)] = "Reiniciar descargas fallidas",
            [nameof(ContextMenuCancelAll)] = "Cancelar todas las descargas",
            [nameof(DownloadStatusEnqueued)] = "Pendiente...",
            [nameof(DownloadStatusCompleted)] = "Listo",
            [nameof(DownloadStatusCanceled)] = "Cancelado",
            [nameof(DownloadStatusFailed)] = "Fallido",
            [nameof(ClickToCopyErrorTooltip)] = "Nota: Haz clic para copiar este mensaje de error",
            [nameof(ShowFileTooltip)] = "Mostrar archivo",
            [nameof(PlayTooltip)] = "Reproducir",
            [nameof(CancelDownloadTooltip)] = "Cancelar descarga",
            [nameof(RestartDownloadTooltip)] = "Reiniciar descarga",
            // School
            [nameof(AppHeaderTitle)] = "Videoteca",
            [nameof(AppHeaderSubtitle)] = "Descarga vídeos para tus clases",
            [nameof(AddToLibraryButton)] = "Añadir",
            [nameof(AccountButton)] = "Cuenta de YouTube",
            [nameof(SettingsButton)] = "Ajustes",
            [nameof(SchoolQueryPlaceholderText)] =
                "Pega un enlace de YouTube (vídeo, lista de reproducción o canal) o escribe palabras clave seguidas de ?",
            [nameof(StepCopyTitle)] = "Copia el enlace",
            [nameof(StepCopyText)] = "En YouTube, haz clic en Compartir y luego en Copiar",
            [nameof(StepPasteTitle)] = "Pégalo arriba",
            [nameof(StepPasteText)] = "¿Varios enlaces? Uno por línea (Mayús+Intro)",
            [nameof(StepDownloadTitle)] = "Elige la calidad",
            [nameof(StepDownloadText)] = "El MP4 se reproduce en cualquier ordenador del aula",
            [nameof(CopyrightNoticeTitle)] = "Respeta los derechos de autor",
            [nameof(CopyrightNoticeMessage)] =
                "Descarga solo los vídeos que puedas usar en clase: licencia Creative Commons, excepción educativa o permiso del autor. Consulta las normas de tu centro.",
            [nameof(DownloadsListTitle)] = "Descargas",
            [nameof(SummaryActiveLabel)] = "en curso",
            [nameof(SummaryCompletedLabel)] = "terminadas",
            [nameof(SummaryFailedLabel)] = "fallidas",
            [nameof(RetryFailedButton)] = "Reintentar fallidas",
            [nameof(ClearListButton)] = "Quitar terminadas",
            [nameof(CancelAllButton)] = "Cancelar todo",
            [nameof(OpenLibraryFolderButton)] = "Abrir carpeta",
            [nameof(SchoolSectionLabel)] = "Centro educativo",
            [nameof(SchoolNameLabel)] = "Nombre del centro",
            [nameof(SchoolNameTooltip)] = "Se muestra en la parte superior de la ventana",
            [nameof(SchoolNamePlaceholderText)] = "p. ej. Colegio Miguel de Cervantes",
            [nameof(DefaultDownloadDirLabel)] = "Carpeta de descargas",
            [nameof(DefaultDownloadDirTooltip)] =
                "Los vídeos se guardan aquí automáticamente, sin preguntar cada vez (por ejemplo, una unidad compartida). Déjalo vacío para elegir cada vez.",
            [nameof(DefaultDownloadDirPlaceholderText)] = "Preguntar cada vez",
            [nameof(GeneralSectionLabel)] = "General",
            [nameof(ClipSectionLabel)] = "Fragmento (opcional)",
            [nameof(ClipStartLabel)] = "Inicio",
            [nameof(ClipEndLabel)] = "Fin",
            [nameof(ClipPlaceholderText)] = "h:mm:ss o mm:ss",
            [nameof(ClipTooltip)] =
                "Conservar solo una parte del vídeo. Déjalo vacío para descargar el vídeo completo.",
            [nameof(ClipInvalidFormatMessage)] = "Usa el formato h:mm:ss o mm:ss (p. ej. 1:30).",
            [nameof(ClipEndBeforeStartMessage)] = "El fin debe ser posterior al inicio.",
            [nameof(ClipOutOfRangeMessage)] = "El fragmento supera la duración del vídeo.",
            [nameof(ClipLabel)] = "Fragmento",
            [nameof(ClassPresetButton)] = "Ajuste para clase",
            [nameof(ClassPresetTooltip)] =
                "MP4, mejor calidad hasta 720p: se reproduce en cualquier ordenador y proyector del aula",
            [nameof(ClassPresetDefaultLabel)] = "Ajuste para clase por defecto",
            [nameof(ClassPresetDefaultTooltip)] =
                "Seleccionar automáticamente MP4 hasta 720p al elegir el formato",
            [nameof(SaveSubtitleFilesLabel)] = "Guardar subtítulos como archivos .srt",
            [nameof(SaveSubtitleFilesTooltip)] =
                "Guardar también los subtítulos junto al vídeo, como archivos .srt separados (no se desplazan cuando solo se conserva un fragmento)",
            [nameof(SubtitleLanguageLabel)] = "Idioma de los subtítulos",
            [nameof(SubtitleLanguageTooltip)] =
                "Código del idioma de los subtítulos que se conservan (p. ej. es, en). Déjalo vacío para conservar todos los idiomas. Si el vídeo no tiene subtítulos en ese idioma, se conservan todos.",
            [nameof(SubtitleLanguagePlaceholderText)] = "Todos los idiomas",
            [nameof(CategoryLabel)] = "Guardar en",
            [nameof(CategoryPlaceholderText)] = "p. ej. 5.º Primaria/Ciencias",
            [nameof(CategoryTooltip)] =
                "Subcarpeta de la carpeta de descargas para las próximas descargas (clase, asignatura…). Usa / para crear varios niveles. Déjalo vacío para guardar directamente en la carpeta de descargas.",
            [nameof(WriteSourceFileLabel)] = "Crear un archivo de fuente",
            [nameof(WriteSourceFileTooltip)] =
                "Guardar junto a cada vídeo un archivo .source.txt con su título, canal, enlace, fecha de descarga y un recordatorio de licencia, para citar la fuente en clase",
            [nameof(SourceFileTitleLine)] = "Título: {0}",
            [nameof(SourceFileChannelLine)] = "Canal: {0}",
            [nameof(SourceFileVideoUrlLine)] = "Vídeo: {0}",
            [nameof(SourceFileChannelUrlLine)] = "Página del canal: {0}",
            [nameof(SourceFileDurationLine)] = "Duración: {0}",
            [nameof(SourceFileClipLine)] = "Fragmento: {0}",
            [nameof(SourceFileDownloadedAtLine)] = "Descargado el: {0}",
            [nameof(SourceFileSchoolLine)] = "Centro: {0}",
            [nameof(SourceFileLicenseLine)] =
                "Licencia: a comprobar en la página del vídeo (Creative Commons, excepción educativa…)",
            [nameof(AdminSectionLabel)] = "Administración",
            [nameof(AdminPinLabel)] = "PIN de administrador",
            [nameof(AdminPinTooltip)] =
                "Si se define un PIN, se pedirá para abrir los ajustes o la cuenta de YouTube",
            [nameof(AdminPinPlaceholderText)] = "mín. 4 caracteres",
            [nameof(AdminPinSetButton)] = "Definir",
            [nameof(AdminPinActiveLabel)] = "Ajustes bloqueados con PIN",
            [nameof(AdminPinRemoveButton)] = "Quitar PIN",
            [nameof(MaxVideoQualityLabel)] = "Calidad máxima",
            [nameof(MaxVideoQualityTooltip)] =
                "Calidad de vídeo más alta ofrecida al descargar (ahorra ancho de banda y espacio en disco)",
            [nameof(PinPromptTitle)] = "Bloqueado",
            [nameof(PinPromptMessage)] = "Introduce el PIN de administrador para continuar.",
            [nameof(PinPlaceholderText)] = "PIN",
            [nameof(PinWrongMessage)] = "PIN incorrecto, inténtalo de nuevo.",
            [nameof(UnlockButton)] = "DESBLOQUEAR",
            [nameof(ImportLinkListButton)] = "Importar una lista",
            [nameof(ImportLinkListTooltip)] =
                "Abrir un archivo .txt o .csv con un enlace de YouTube por línea (primera columna en una hoja de cálculo). Las líneas que empiezan por # se ignoran.",
            [nameof(LinkListFileType)] = "Lista de enlaces",
            [nameof(LinkListEmptyMessage)] = "No se ha encontrado ningún enlace en este archivo",
            [nameof(HistoryButton)] = "Historial",
            [nameof(HistoryTooltip)] = "Descargas realizadas en este ordenador",
            [nameof(HistoryTitle)] = "Historial de descargas",
            [nameof(HistoryEmptyText)] = "Todavía no hay descargas",
            [nameof(HistoryOpenCsvButton)] = "ABRIR ARCHIVO CSV",
            [nameof(HistoryDateColumnHeader)] = "Fecha",
            [nameof(HistoryUserColumnHeader)] = "Usuario",
            [nameof(HistoryTitleColumnHeader)] = "Título",
            [nameof(HistoryUrlColumnHeader)] = "URL",
            [nameof(HistoryFileColumnHeader)] = "Archivo",
            [nameof(HistoryStatusColumnHeader)] = "Estado",
            [nameof(DeferredModeLabel)] = "Descargar más tarde (a partir de las {0})",
            [nameof(DeferredModeTooltip)] =
                "Los vídeos añadidos con esta opción activada esperan a la hora programada (definida en los ajustes) antes de descargarse, p. ej. para no ralentizar la red del centro durante las clases. Mantén la aplicación abierta.",
            [nameof(DownloadStatusScheduled)] = "Programada a las {0}",
            [nameof(SummaryScheduledLabel)] = "programadas",
            [nameof(MaxDownloadRateLabel)] = "Límite de velocidad (KB/s)",
            [nameof(MaxDownloadRateTooltip)] =
                "Velocidad total máxima de descarga, en kilobytes por segundo, para compartir la red del centro. 0 = sin límite.",
            [nameof(ScheduledStartTimeLabel)] = "Hora de inicio programada",
            [nameof(ScheduledStartTimeTooltip)] =
                "Hora (HH:mm) a la que empiezan las descargas añadidas con \"Descargar más tarde\"",
            [nameof(PreviewButton)] = "Vista previa",
            [nameof(PreviewTooltip)] =
                "Ver el vídeo aquí antes de descargarlo (empieza al inicio del fragmento, si está definido)",
            [nameof(PreviewOpenInBrowserButton)] = "Abrir en el navegador",
            [nameof(PreviewCloseButton)] = "Cerrar vista previa",
            // Color themes
            [nameof(DownloadStatusTrimming)] = "Recortando el fragmento… {0}",
            [nameof(ColorThemeLabel)] = "Colores",
            [nameof(ColorThemeTooltip)] = "Paleta de colores de la interfaz",
            [nameof(ColorThemeSchool)] = "Azul escolar",
            [nameof(ColorThemeNature)] = "Verde naturaleza",
            [nameof(ColorThemeOcean)] = "Océano",
            [nameof(ColorThemeLavender)] = "Lavanda",
            [nameof(ColorThemeSunset)] = "Atardecer",
            [nameof(ColorThemeClassic)] = "Clásico",
            // Settings
            [nameof(SettingsTitle)] = "Configuración",
            [nameof(ThemeLabel)] = "Tema",
            [nameof(ThemeTooltip)] = "Tema de interfaz preferido",
            [nameof(LanguageLabel)] = "Idioma",
            [nameof(LanguageTooltip)] =
                "Idioma de visualización preferido para la interfaz de usuario",
            [nameof(AutoUpdateLabel)] = "Actualización automática",
            [nameof(AutoUpdateTooltip)] = """
                Realizar actualizaciones automáticas en cada inicio.
                **Advertencia:** se recomienda dejar esta opción habilitada para asegurar la compatibilidad con la última versión de YouTube.
                """,
            [nameof(PersistAuthLabel)] = "Conservar autenticación",
            [nameof(PersistAuthTooltip)] = """
                Guardar las cookies de autenticación en un archivo para persistirlas entre sesiones.
                **Advertencia**: aunque las cookies se almacenan con cifrado, un atacante con acceso a su sistema podría recuperarlas.
                """,
            [nameof(InjectAltLanguagesLabel)] = "Insertar idiomas alternativos",
            [nameof(InjectAltLanguagesTooltip)] =
                "Insertar pistas de audio en idiomas alternativos (si están disponibles) en los archivos descargados",
            [nameof(InjectSubtitlesLabel)] = "Insertar subtítulos",
            [nameof(InjectSubtitlesTooltip)] =
                "Insertar subtítulos (si están disponibles) en los archivos descargados",
            [nameof(InjectTagsLabel)] = "Insertar etiquetas multimedia",
            [nameof(InjectTagsTooltip)] =
                "Insertar etiquetas multimedia (si están disponibles) en los archivos descargados",
            [nameof(SkipExistingFilesLabel)] = "Omitir archivos existentes",
            [nameof(SkipExistingFilesTooltip)] =
                "Al descargar múltiples videos, omitir los que ya tengan archivos correspondientes en el directorio de salida",
            [nameof(FileNameTemplateLabel)] = "Plantilla de nombre de archivo",
            [nameof(FileNameTemplateTooltip)] = """
                Plantilla para generar nombres de archivo de los videos descargados.

                Tokens disponibles:
                **$num** — posición del video en la lista (si aplica)
                **$id** — ID del video
                **$title** — título del video
                **$author** — autor del video
                """,
            [nameof(ParallelLimitLabel)] = "Límite paralelo",
            [nameof(ParallelLimitTooltip)] =
                "Cuántas descargas pueden estar activas al mismo tiempo",
            [nameof(FFmpegPathLabel)] = "Ruta de FFmpeg",
            [nameof(FFmpegPathTooltip)] =
                "Ruta al ejecutable de FFmpeg. Dejar vacío para detección automática.",
            [nameof(FFmpegPathPlaceholderText)] = "Auto",
            [nameof(FFmpegPathResetTooltip)] = "Restablecer detección automática",
            [nameof(FFmpegPathBrowseTooltip)] = "Buscar ejecutable de FFmpeg",
            // Auth Setup
            [nameof(AuthenticationTitle)] = "Autenticación",
            [nameof(AuthenticatedText)] = "Actualmente estás autenticado",
            [nameof(LogOutButton)] = "Cerrar sesión",
            [nameof(AuthenticationPlaceholderText)] = """
                Cargando...

                Si el navegador no aparece:
                - Windows: instala Microsoft Edge WebView2 Runtime.
                - macOS: instala las últimas actualizaciones del sistema.
                - Linux: instala GTK 3, WebKitGTK 4.1 y libsoup 3.
                """,
            // Download Single Setup
            [nameof(CopyMenuItem)] = "Copiar",
            [nameof(LiveLabel)] = "En vivo",
            [nameof(AudioLabel)] = "Audio",
            [nameof(UpscaledLabel)] = "Reescalado",
            [nameof(FormatLabel)] = "Formato",
            // Download Multiple Setup
            [nameof(ContainerLabel)] = "Contenedor",
            [nameof(VideoQualityLabel)] = "Calidad de video",
            // Common buttons
            [nameof(CloseButton)] = "CERRAR",
            [nameof(DownloadButton)] = "DESCARGAR",
            [nameof(CancelButton)] = "CANCELAR",
            // Dialog messages
            [nameof(UkraineSupportTitle)] = "¡Gracias por apoyar a Ucrania!",
            [nameof(UkraineSupportMessage)] = """
                Mientras Rusia libra una guerra genocida contra mi país, estoy agradecido con todos los que continúan apoyando a Ucrania en nuestra lucha por la libertad.

                Haz clic en MÁS INFORMACIÓN para encontrar formas en que puedes ayudar.
                """,
            [nameof(LearnMoreButton)] = "MÁS INFORMACIÓN",
            [nameof(UnstableBuildTitle)] = "Advertencia: versión inestable",
            [nameof(UnstableBuildMessage)] = """
                Estás usando una versión de desarrollo de {0}. Estas versiones no han sido probadas exhaustivamente y pueden contener errores.

                Las actualizaciones automáticas están desactivadas para versiones de desarrollo.

                Haz clic en VER LANZAMIENTOS para descargar una versión estable.
                """,
            [nameof(SeeReleasesButton)] = "VER LANZAMIENTOS",
            [nameof(FFmpegMissingTitle)] = "Falta FFmpeg",
            [nameof(FFmpegMissingMessage)] = """
                FFmpeg no se encontró en tu sistema. Es necesario para que {0} funcione. ¿Te gustaría descargarlo ahora?

                Como alternativa, puedes cerrar este diálogo y establecer manualmente una ruta personalizada de FFmpeg en configuración.
                """,
            [nameof(FFmpegDownloadingTitle)] = "Descargando FFmpeg...",
            [nameof(FFmpegDownloadCompletedTitle)] = "FFmpeg descargado",
            [nameof(NothingFoundTitle)] = "Nada encontrado",
            [nameof(NothingFoundMessage)] =
                "No se encontraron videos basados en la consulta o URL proporcionada",
            [nameof(ErrorTitle)] = "Error",
            [nameof(UpdateDownloadingMessage)] = "Descargando actualización de {0} v{1}...",
            [nameof(UpdateReadyMessage)] =
                "La actualización se ha descargado y se instalará al salir",
            [nameof(UpdateInstallNowButton)] = "INSTALAR AHORA",
            [nameof(UpdateFailedMessage)] = "Error al realizar la actualización de la aplicación",
        };
}
