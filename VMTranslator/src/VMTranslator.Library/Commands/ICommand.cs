namespace VMTranslator.Library.Commands;
/// <summary>
/// The ICommand represents a VM command.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// produces lines of assembly code to represent the vm command.
    /// </summary>
    /// <returns>
    /// The lines of assembly code.
    /// </returns>
    public string[] ToAssembly();
}
