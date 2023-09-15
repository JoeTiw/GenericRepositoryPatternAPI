using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Learning_API.Helper;

public class PasswordEncryption
{
    public static byte[] GetSecurePasswordSalt()
    {
        return RandomNumberGenerator.GetBytes(32);
    }

    public static string HashPassword(string password, byte[] passwordSalt)
    {
        byte[] key =
            KeyDerivation.Pbkdf2(password, passwordSalt, KeyDerivationPrf.HMACSHA256, iterationCount: 3000, 32);
            return Convert.ToBase64String(key);
    }
}