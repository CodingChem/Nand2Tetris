namespace HackAssembler.Library.Instructions;
/// <summary>
/// An Instruction to be translated.
/// </summary>
public interface IInstruction
{
	/// <summary>
	/// Translates the instruction
	/// </summary>
	/// <returns>A string containing the binary representation of the instruction.</returns>
	public string Translate();
}
