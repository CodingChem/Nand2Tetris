using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Components.Factories;

/// <summary>
/// The <c>InstructionFactory</c> creates appropriate <c>IInstructions</c> given a valid hack assembly instruction.
/// </summary>
/// <param name="symbolTable">A <c>ISymbolTable</c></param>
public class InstructionFactory(ISymbolTable symbolTable) : IInstructionFactory
{
	private readonly ISymbolTable _symbolTable = symbolTable;
	/// <summary>
	/// Create an appopriate instruction from a line of hack assembly.
	/// </summary>
	/// <param name="line">the assembly line to be prossessed.</param>
	/// <returns>An <c>IInstruction</c> that corresponds to the given assembly instruction.</returns>
	public IInstruction CreateInstruction(string line)
	{
		if (line.Contains('@'))
		{
			return CreateAInstruction(line);
		}
		return new CInstruction(line);
	}
	/// <summary>
	/// Creates an A instruction.
	/// </summary>
	/// <param name="line">A hack assembly a-instruction</param>
	/// <returns>The corresponding AInstruction</returns>
	private AInstruction CreateAInstruction(string line)
	{
		string lineTrimmed = line.Trim().Trim('@');
		bool isNumber = int.TryParse(lineTrimmed, out _);
		if (isNumber)
			return new AInstruction(lineTrimmed);
		if (_symbolTable.SymbolExists(lineTrimmed))
			return new AInstruction(_symbolTable.LookupSymbol(lineTrimmed).ToString());
		_symbolTable.AddSymbol(lineTrimmed);
		return new AInstruction(_symbolTable.LookupSymbol(lineTrimmed).ToString());
	}
}
