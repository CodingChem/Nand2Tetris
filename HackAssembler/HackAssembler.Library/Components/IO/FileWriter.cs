namespace HackAssembler.Library.Components.IO;

public class FileWriter : IWriter
{
    private readonly List<string> _lines;
    public FileWriter()
    {
        _lines = [];
    }

	public string GetOutputFileName(string fileName)
	{
        string outputFilename = fileName.Replace(".asm", ".hack");
        if (!outputFilename.Contains(".hack"))
            throw new ArgumentException("Invalid Filename");
        return outputFilename;
	}

    public void WriteFile(string outputFile)
    {
		using StreamWriter writer = new(outputFile);
		foreach (string line in _lines)
		{
			writer.WriteLine(line);
		}
	}
	public Task WriteFileAsync(string outputFile)
    {
        return Task.Run(() =>
        {
            WriteFile(outputFile);
        });
    }

    public void WriteLine(string line)
    {
        _lines.Add(line);
    }

}
