using VMTranslator.Library;

namespace VMTranslator.Library.Tests;

[TestClass]
public class TranslatorTests
{
    [TestMethod]
    public void Translator_EmptyInputProducesEmptyOutput()
    {
        // Arrange
        string[] vmCode = Array.Empty<string>();
        string[] expectedOutput = vmCode;
        // Act
        string[] actualOutput = Translator.Translate(vmCode);
        // Assert
        
        Assert.AreEqual(expectedOutput.Length, actualOutput.Length);
        for (int i = 0; i < actualOutput.Length; i++)
        {
            Assert.AreEqual(expectedOutput[i],actualOutput[i]);
        }
    }
}
