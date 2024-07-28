using VMTranslator.ConsoleApp;

namespace VMTranslator.ConsoleApp.Tests;

[TestClass]
public class ConsoleAppTests
{
	[TestMethod]
	public void ConsoleApp_CorrectInputProducesOutputFile()
	{
		string inputPath = Path.Combine("TestData", "test.vm");
		string outputPath = Path.Combine("TestData", "test.asm");

    Program.Main([inputPath]);

		Assert.IsTrue(File.Exists(outputPath));

		File.Delete(outputPath);
	}
	[TestMethod]
	public void ConsoleApp_NonExsistingFile_ThrowsFileNotFoundException()
	{
		string inputPath = Path.Combine("TestData", "NotAFile.vm");

		Assert.ThrowsException<FileNotFoundException>(() => Program.Main([inputPath]));
	}
	[TestMethod]
	public void ConsoleApp_WrongFormatFile_ThrowsArgumentException()
	{
		string inputPath = Path.Combine("TestData", "test.txt");

		Assert.ThrowsException<ArgumentException>(() => Program.Main([inputPath]));
	}
}
