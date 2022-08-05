namespace Encrypt.Tests;

[TestClass]
public class EncryptExtensionsTests
{
    [TestMethod]
    [DataRow(null, "")]
    [DataRow("", "")]
    [DataRow(" ", "7215ee9c7d9dc229d2921a40e899ec5f")]
    [DataRow("a@a", "4b9411a9b28f9063ea75e5fee24bb2a8")]
    [DataRow("bartie.devops@outlook.com", "cb6193ae759b6598472702ed352f148b")]
    public void ShouldValidateToEncrypt(string text, string crypto)
    {

        if (text.ToEncrypt() != crypto)
        {
            Assert.Fail(string.Format("Crypty: [{0}]", text.ToEncrypt()));
        }

    }

    [TestMethod]
    [DataRow("", "")]
    [DataRow(" ", "7215ee9c7d9dc229d2921a40e899ec5f")]
    [DataRow("a@a", "4b9411a9b28f9063ea75e5fee24bb2a8")]
    [DataRow("bartie.devops@outlook.com", "cb6193ae759b6598472702ed352f148b")]
    [DataRow("bartie.devops@outlook.com", "cb6193ae759b6598472702ed352f148b", null)]
    [DataRow("bartie.devops@outlook.com", "cb6193ae759b6598472702ed352f148b", 90)]
    public void ShouldValidateToGravatar(string email, string crypto, int size = 80)
    {

        var gerado = email.ToGravatar(size);
        var esperado = "";

        if (!string.IsNullOrEmpty(email))
            esperado = $"https://www.gravatar.com/avatar/{crypto}?s={size}";

        if (gerado != esperado)
        {
            Assert.Fail(string.Format("Gravatar: [{0}]", gerado));
        }

    }


}