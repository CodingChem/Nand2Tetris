namespace VMTranslator.Library.Commands;

/// <summary>
/// A base class for arithmetic operations.
/// </summary>
internal abstract class ArithmeticCommand : ICommand
{
    /// <summary>
    /// Call the <c>InstructionComment</c>.
    /// Stores the first argument in the D register, decrement the SP and moves to the second argument.
    /// After which the <c>ArithmeticInstruction</c> is called.
    /// </summary>
    /// <returns>
    /// The assembly instructions required to perform the operation.
    /// </returns>
    public string[] ToAssembly()
    {
        return
        [
            InstructionComment(),
            "@SP",
            "M=M-1",
            "A=M", // Going to the first item on the stack.
            "D=M",
            "@SP",
            "A=M-1", // Going to the second argument.
            ArithmeticInstruction()
        ];
    }

    public abstract string ArithmeticInstruction();
    public abstract string InstructionComment();
}
