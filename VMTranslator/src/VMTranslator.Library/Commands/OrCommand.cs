namespace VMTranslator.Library.Commands;

/// <summary>
///
/// </summary>
class OrCommand : ICommand
{
    /// <summary>
    /// Returns the instructions necessary to perform a or command.
    /// </summary>
    /// <returns>
    /// The assembly instructions required to perform the operation.
    /// </returns>
    public string[] ToAssembly()
    {
        return ["//or", "@SP", "M=M-1", "A=M", "D=M", "A=A-1", "M=D|M"];
    }
}
