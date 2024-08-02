namespace VMTranslator.Library.Tests;

[TestClass]
public class TranslatorTests
{
    [TestMethod]
    public void Translator_ProducesCorrectSubCommandInstructions()
    {
        string[] inputVMCommand = ["sub"];
        string[] expectedOutput = ["//sub", "@SP", "M=M-1", "A=M", "D=M", "@SP", "A=M-1", "M=D-M"];

        string[] actualOutput = Translator.Translate(inputVMCommand);

        Assert.AreEqual(expectedOutput.Length, actualOutput.Length);
        for (int i = 0; i < actualOutput.Length; i++)
        {
            Assert.AreEqual(expectedOutput[i], actualOutput[i]);
        }
    }

    [TestMethod]
    public void Translator_ProducesCorrectAddCommandInstructions()
    {
        string[] inputVMCommand = ["add"];
        string[] expectedOutput = ["//add", "@SP", "M=M-1", "A=M", "D=M", "@SP", "A=M-1", "M=D+M"];

        string[] actualOutput = Translator.Translate(inputVMCommand);

        Assert.AreEqual(expectedOutput.Length, actualOutput.Length);
        for (int i = 0; i < actualOutput.Length; i++)
        {
            Assert.AreEqual(expectedOutput[i], actualOutput[i]);
        }
    }

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
            Assert.AreEqual(expectedOutput[i], actualOutput[i]);
        }
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(32767)]
    public void Translator_PushConstantCommandsIsTranslated(int num)
    {
        string[] vmCode = [$"push constant {num}"];
        string[] expectedOutput =
        [
            $"//push constant {num}",
            $"@{num}",
            "D=A",
            "@0",
            "A=M",
            "M=D",
            "@0",
            "M=M+1"
        ];

        string[] actualOutput = Translator.Translate(vmCode);

        Assert.AreEqual(expectedOutput.Length, actualOutput.Length);
        for (int i = 0; i < actualOutput.Length; i++)
        {
            Assert.AreEqual(expectedOutput[i], actualOutput[i]);
        }
    }

    [TestMethod]
    [DataRow(-1)]
    [DataRow(32768)]
    public void Translator_PushingConstantsOutOfBounds_Throws(int num)
    {
        string[] vmCode = [$"push constant {num}"];

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Translator.Translate(vmCode));
    }
}
