using System;
using System.Security.Cryptography;
using System.Text;

namespace YoutubeDownloader.Utils;

public static class PinHasher
{
    public static string CreateSalt() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));

    public static string Hash(string salt, string pin) =>
        Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(salt + pin)));

    public static bool Verify(string? pin, string? salt, string? hash)
    {
        if (string.IsNullOrEmpty(pin) || salt is null || hash is null)
            return false;

        byte[] expected;
        try
        {
            expected = Convert.FromBase64String(hash);
        }
        catch (FormatException)
        {
            return false;
        }

        var actual = SHA256.HashData(Encoding.UTF8.GetBytes(salt + pin));
        return CryptographicOperations.FixedTimeEquals(actual, expected);
    }
}
