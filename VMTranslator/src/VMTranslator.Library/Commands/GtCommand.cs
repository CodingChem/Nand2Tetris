namespace VMTranslator.Library.Commands;

/// <summary>
///
/// </summary>
class GtCommand : ICommand
{
    /// <summary>
    /// Returns the instructions necessary to perform a gt command.
    /// </summary>
    /// <returns>
    /// The assembly instructions required to perform the operation.
    /// </returns>
    public string[] ToAssembly()
    {
        Guid g = System.Guid.NewGuid();
        // TODO: Check if it works.
        return
        [
            "//gt",
            "@SP",
            "M=M-1",
            "A=M",
            "D=M",
            "A=A-1",
            "D=M-D",
            $"@GT_{g}",
            "D;JGT", // jumps to GT if lt true
            "@0",
            "D=A",
            $"@End_{g}",
            "0;JMP",
            $"(GT_{g})",
            "@1",
            "D=A",
            $"(End_{g})",
            "@SP",
            "A=M-1",
            "M=D"
        ];
    }
}
