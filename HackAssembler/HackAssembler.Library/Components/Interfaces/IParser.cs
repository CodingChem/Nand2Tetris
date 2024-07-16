using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Components.Interfaces;
/// <summary>
/// An <c>IParser</c> parses lines of hack assemblyand produces instructions.
/// </summary>
public interface IParser
{
    /// <summary>
    /// Parse the given line array.
    /// </summary>
    /// <param name="lines">the line array to be parsed.</param>
    public void Parse(string[] lines);
    /// <summary>
    /// Returns the parsed lines.
    /// </summary>
    /// <returns>The lines parsed by the <c>Parse()</c> method.</returns>
    public IEnumerable<IInstruction> Instructions();
}
