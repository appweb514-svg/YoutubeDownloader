using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using PowerKit.Extensions;

namespace YoutubeDownloader.Core.Utils;

public static class Http
{
    // Global download speed limit in bytes per second; 0 or less means unlimited
    public static long MaxBytesPerSecond { get; set; }

    public static HttpClient Client { get; } =
        new(new ThrottlingHandler(new SocketsHttpHandler()))
        {
            DefaultRequestHeaders =
            {
                // Required by some of the services we're using
                UserAgent =
                {
                    new ProductInfoHeaderValue(
                        "YoutubeDownloader",
                        Assembly.GetExecutingAssembly().TryGetVersionString()
                    ),
                },
            },
        };
}
