namespace HackAssembler.Library.Components.IO;

public class FileReader : IReader
{
    public string[] Read(string path)
    {
        return File.ReadAllLines(path);
    }
}
