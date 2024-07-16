using HackAssembler.Library.Components.IO;

namespace HackAssembler.Library.Tests.Mock;

internal class InMemoryWriter : IWriter
{
    public string[] Contents { get; private set; }
	public InMemoryWriter() => Contents = [];
	public string GetOutputFileName(string fileName)
	{
		return "";
	}

	public void WriteFile(string outputfile)
	{
		return;
	}

	public Task WriteFileAsync(string outputFile)
	{
		return Task.CompletedTask;
	}

	public void WriteLine(string line)
	{
		Contents = [.. Contents, line];
	}
}
