namespace VMTranslator.Library.Commands;

/// <summary>
/// Represents the Add command.
/// </summary>
class AndCommand : ICommand
{
    /// <summary>
    /// Returns the instructions necessary to perform a and command.
    /// </summary>
    /// <returns>
    /// The assembly instructions required to perform the operation.
    /// </returns>
    public string[] ToAssembly()
    {
        return ["//and", "@SP", "M=M-1", "A=M", "D=M", "A=A-1", "M=D&M"];
    }
}
