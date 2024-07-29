namespace VMTranslator.Library.Commands;

/// <summary>
/// <c>PushConstantCommand</c> is a command that pushes a constant on the stack.
/// </summary>
internal class PushConstantCommand : ICommand
{
    private readonly int _constant;
    /// <summary>
    /// produces a push constant command which pushes <c>constant</c> to the stack.
    /// </summary>
    /// <param name="constant">
    /// The constant to push to the stack. Must be a integer between 0 and 32 767.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Will throw if the int is out of range.
    /// </exception>
    public PushConstantCommand(int constant)
    {
        if (constant > 32767 || constant < 0)
        {
            throw new ArgumentOutOfRangeException($"argument out of range: {constant}, should be between [0, 32767].");
        }
        _constant = constant;
    }
    /// <summary>
    /// Returns the assembly instructions required to perform the command.
    /// </summary>
    /// <returns>
    /// The lines of assembly required to perform the command.
    /// </return>
    public string[] ToAssembly()
    {
        return [
          $"//push constant {_constant}",
          $"@{_constant}",
          "D=A",
          "@0",
          "A=M",
          "M=D",
          "@0",
          "M=M+1"
        ];
    }
}
