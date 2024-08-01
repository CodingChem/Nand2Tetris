namespace VMTranslator.Library.Commands;

/// <summary>
///
/// </summary>
class LtCommand : ICommand
{
    /// <summary>
    /// Returns the instructions necessary to perform a lt command.
    /// </summary>
    /// <returns>
    /// The assembly instructions required to perform the operation.
    /// </returns>
    public string[] ToAssembly()
    {
        Guid g = System.Guid.NewGuid();
        // TODO:Check if it works.
        return
        [
            "//lt",
            "@SP",
            "M=M-1",
            "A=M",
            "D=M",
            "A=A-1",
            "D=M-D",
            $"@LT_{g}",
            "D;JLT", // jumps to LT if lt true
            "@0",
            "D=A",
            $"@End_{g}",
            "0;JMP",
            $"(LT_{g})",
            "@1",
            "D=A",
            $"(End_{g})",
            "@SP",
            "A=M-1",
            "M=D"
        ];
    }
}
