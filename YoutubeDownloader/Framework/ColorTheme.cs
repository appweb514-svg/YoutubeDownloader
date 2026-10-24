using Avalonia.Media;

namespace YoutubeDownloader.Framework;

public enum ColorTheme
{
    School,
    Nature,
    Ocean,
    Lavender,
    Sunset,
    Classic,
}

public static class ColorThemeExtensions
{
    extension(ColorTheme theme)
    {
        // Primary color drives the header and buttons, secondary color drives progress and accents
        public (Color Primary, Color Secondary) GetColors(bool isDark) =>
            (theme, isDark) switch
            {
                (ColorTheme.Nature, false) => (Color.Parse("#2E6B3A"), Color.Parse("#C77C02")),
                (ColorTheme.Nature, true) => (Color.Parse("#8FD19E"), Color.Parse("#FBBF24")),
                (ColorTheme.Ocean, false) => (Color.Parse("#0E6378"), Color.Parse("#0EA5A4")),
                (ColorTheme.Ocean, true) => (Color.Parse("#7DD3E8"), Color.Parse("#5EEAD4")),
                (ColorTheme.Lavender, false) => (Color.Parse("#5B3D9B"), Color.Parse("#D9468F")),
                (ColorTheme.Lavender, true) => (Color.Parse("#C4B5FD"), Color.Parse("#F9A8D4")),
                (ColorTheme.Sunset, false) => (Color.Parse("#B4401E"), Color.Parse("#E39B0B")),
                (ColorTheme.Sunset, true) => (Color.Parse("#FDBA8C"), Color.Parse("#FCD34D")),
                // Original YoutubeDownloader look
                (ColorTheme.Classic, false) => (Color.Parse("#343838"), Color.Parse("#F9A825")),
                (ColorTheme.Classic, true) => (Color.Parse("#E8E8E8"), Color.Parse("#F9A825")),
                // School palette: calm blue for structure, green for progress and success
                (_, false) => (Color.Parse("#1F4E9C"), Color.Parse("#0F8A6A")),
                (_, true) => (Color.Parse("#8AB4F8"), Color.Parse("#34D399")),
            };
    }
}
