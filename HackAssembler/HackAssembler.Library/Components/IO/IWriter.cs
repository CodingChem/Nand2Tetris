namespace HackAssembler.Library.Components.IO;
/// <summary>
/// <c>IWriter</c> Takes lines with the <c>WriteLine</c> method
/// and writes the output with the <c>WriteFile</c> and <c>WriteFileAsync</c> methods.
/// </summary>
public interface IWriter
{
    /// <summary>
    /// Writes a line to the Writer buffer.
    /// </summary>
    /// <param name="line">The line to add to the writer</param>
    public void WriteLine(string line);
    /// <summary>
    /// Creates and writes a file async.
    /// </summary>
    /// <param name="outputFile"></param>
    /// <returns>Task</returns>
    public Task WriteFileAsync(string outputFile);
    /// <summary>
    /// Creates a file and writes the line.
    /// </summary>
    /// <param name="outputfile"></param>
    public void WriteFile(string outputfile);
    /// <summary>
    /// Returns the generated output file name for a given input file name.
    /// </summary>
    /// <param name="fileName">The path of the input file</param>
    /// <returns></returns>
    public string GetOutputFileName(string fileName);
}
