using VMTranslator.Library.Commands;

namespace VMTranslator.Library.Components;

/// <summary>
/// Translates HACK VM commands to symbolic assembly code.
/// </summary>
internal class CodeWriter : ICodeWriter
{
    private List<string> _asmOutput = new();
    /// <summary>
    /// Writes the command as assembly to the writer object.
    /// </summary>
    /// <param name="command">
    /// the command to be written.
    /// </param>
    public void WriteCommand(ICommand command)
    {
        foreach(string line in command.ToAssembly())
        {
            _asmOutput.Add(line);
        }
    }
    /// <summary>
    /// Get the assembly of the translated commands.
    /// </summary>
    /// <returns>
    /// The Assembly code of the VM commands.
    /// </returns>
    public string[] GetAssembly()
    {
        return _asmOutput.ToArray();
    }
}
