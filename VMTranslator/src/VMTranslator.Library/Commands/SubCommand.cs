namespace VMTranslator.Library.Commands;

internal class SubCommand : ArithmeticCommand
{
    /// <summary>
    /// Produces the instruction necessary to sub the D and M register and stores the result in the M register.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    public override string ArithmeticInstruction()
    {
        return "M=D-M";
    }

    /// <summary>
    /// Returns the VM command as a comment.
    /// </summary>
    /// <returns>
    /// the comment as a string.
    /// </returns>
    public override string InstructionComment()
    {
        return "//sub";
    }
}
