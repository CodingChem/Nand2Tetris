namespace VMTranslator.Library.Commands;

/// <summary>
/// A Class representing the neg operation.
/// </summary>
class NegCommand : ICommand
{
    /// <summary>
    /// Returns the instructions necessary to perform a neg command.
    /// </summary>
    /// <returns>
    /// The assembly instructions required to perform the operation.
    /// </returns>
    public string[] ToAssembly()
    {
        return ["//neg", "@SP", "A=M-1", "M=!M"];
    }
}
