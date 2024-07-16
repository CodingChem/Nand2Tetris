using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Components.Interfaces;
/// <summary>
/// The <c>ITranslator</c> can translate <c>IInstructions</c>.
/// </summary>
public interface ITranslator
{
    /// <summary>
    /// Translate the given instruction.
    /// </summary>
    /// <param name="instruction">The instruction to be translated.</param>
    /// <returns>A <c>string</c> containing the binary representation of the instruction.</returns>
    public string Translate(IInstruction instruction);
}
