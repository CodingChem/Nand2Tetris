using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Components.Interfaces;

/// <summary>
/// The <c>IInstructionFactory</c> produces <c>IInstructions</c> from lines of valid hack assembly.
/// </summary>
public interface IInstructionFactory
{
    /// <summary>
    /// Produce a <c>IInstruction</c> from the given line of hack assembly.
    /// </summary>
    /// <param name="line">The line of hack assembly to be translated to an IInstruction</param>
    /// <returns>The corresponding <c>IInstruction</c> of the line</returns>
    IInstruction CreateInstruction(string line);
}