using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Components.Components;

/// <summary>
/// <c>Parser</c> parses a hack assembly file into a series of <c>IInstruction</c>
/// </summary>
/// <param name="symbolTable">An <c>ISymbolTable</c></param>
/// <param name="instructionFactory">An <c>IInstructionFactory</c></param>
public class Parser(ISymbolTable symbolTable, IInstructionFactory instructionFactory) : IParser
{
    private readonly ISymbolTable _symbolTable = symbolTable;
    private readonly IInstructionFactory _instructionFactory = instructionFactory;
    private readonly List<IInstruction> _instructions = [];
    /// <summary>
    /// Retrieves the instructions of a parsed file.
    /// <remarks>Must be used after <c>Parse()</c> method.</remarks>
    /// </summary>
    /// <returns>An <c>IEnumerable</c> containing the parsed instructions</returns>
	public IEnumerable<IInstruction> Instructions()
    {
        foreach (var instruction in _instructions)
        {
            yield return instruction;
        }
        yield break;
    }

    /// <summary>
    /// Parses the lines into instructions.
    /// Use <c>Instructions()</c> to retrive the instructions.
    /// </summary>
    /// <param name="lines">A string collection containing the lines in a hack assembly program.</param>
    public void Parse(string[] lines)
    {

        lines = lines.Select(x => x.Contains("//") ? x.Remove(x.IndexOf("//")) : x).ToArray();
        PreProccess(lines);
        foreach (string line in lines)
        {
            if (IsInstruction(line))
                _instructions.Add(_instructionFactory.CreateInstruction(line));
        }
    }
    /// <summary>
    /// Populate the <c>ISymbolTable</c> with any labels prior to parsing.
    /// </summary>
    /// <param name="lines">A string array containing the lines to be parsed.</param>
    private void PreProccess(string[] lines)
    {
        int idx = 0;
        foreach (string line in lines)
        {
            if (IsLabel(line))
                _symbolTable.AddSymbol(line.Trim().Trim('(', ')'), idx);
            if (IsInstruction(line))
                idx++;
        }
    }
    /// <summary>
    /// Checks if the passed line is a valid instruction.
    /// </summary>
    /// <param name="line">The line that may be an instruction.</param>
    /// <returns><c>true</c> if the line is a valid instruction.</returns>
    private static bool IsInstruction(string line)
    {
        if (line.Trim().StartsWith("//") || line.Trim() == "" || IsLabel(line))
        {
            return false;
        }
        return true; // Assumption beeing the asm passed in is correct.
    }
    /// <summary>
    /// Checks if the passed line is a label.
    /// </summary>
    /// <param name="line">the line to be checked.</param>
    /// <returns><c>true</c> if the line is a label.</returns>
    private static bool IsLabel(string line)
    {
        return line.Trim().StartsWith('(');
    }
}
