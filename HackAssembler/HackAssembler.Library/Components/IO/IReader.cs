namespace HackAssembler.Library.Components.IO;
/// <summary>
/// <c>IReader</c> can <c>Read()</c> files
/// </summary>
public interface IReader
{
    /// <summary>
    /// Read the given file and return the contents.
    /// </summary>
    /// <param name="path">The path of the file to be read.</param>
    /// <returns>A string Array containing the lines in the read file.</returns>
    string[] Read(string path);
}
