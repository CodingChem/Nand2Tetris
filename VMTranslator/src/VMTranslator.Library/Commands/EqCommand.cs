namespace VMTranslator.Library.Commands;

/// <summary>
///
/// </summary>
class EqCommand : ICommand
{
    /// <summary>
    /// Returns the instructions necessary to perform a eq command.
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
            "//eq",
            "@SP",
            "M=M-1",
            "A=M",
            "D=M",
            "A=A-1",
            "D=M-D",
            $"@EQ_{g}",
            "D;JEQ", // jumps to LT if lt true
            "@0",
            "D=A",
            $"@End_{g}",
            "0;JMP",
            $"(EQ_{g})",
            "@1",
            "D=A",
            $"(End_{g})",
            "@SP",
            "A=M-1",
            "M=D"
        ];
    }
}
