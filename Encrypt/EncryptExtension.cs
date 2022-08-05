using System.Security.Cryptography;
using System.Text;

namespace Encrypt;
public static class EncryptExtension
{
    public static string ToEncrypt(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        using var md5 = MD5.Create();

        var inputBytes = Encoding.ASCII.GetBytes(text);

        var hashBytes = md5.ComputeHash(inputBytes);

        var sb = new StringBuilder();
        foreach (var t in hashBytes)
            sb.Append(t.ToString("X2"));

        return sb.ToString().ToLower();

    }

    public static string ToGravatar(this string email, int size = 80)
    {
        if (string.IsNullOrEmpty(email))
            return string.Empty;

        return $"https://www.gravatar.com/avatar/{email.ToEncrypt()}?s={size}";  

    }

}
