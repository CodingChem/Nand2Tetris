namespace VMTranslator.Library.Commands;

/// <summary>
/// A Class representing the Not operation.
/// </summary>
class NotCommand : ICommand
{
    /// <summary>
    /// Returns the instructions necessary to perform a not command.
    /// </summary>
    /// <returns>
    /// The assembly instructions required to perform the operation.
    /// </returns>

    public string[] ToAssembly()
    {
        return ["//not", "@SP", "A=M-1", "M=!M"];
    }
}
