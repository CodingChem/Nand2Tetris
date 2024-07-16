using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Components.Components;
/// <summary>
/// The translator translates <c>IInstructions</c> into binary strings.
/// Which represent the opcode of the instruction.
/// </summary>
public class Translator : ITranslator
{
    /// <summary>
    /// Translates the instruction into a binary string.
    /// </summary>
    /// <param name="instruction">The instruction to translate.</param>
    /// <returns>a <c>string</c> of the binary representation of the instruction.</returns>
    public string Translate(IInstruction instruction)
    {
        return instruction.Translate();
    }
}
