using VMTranslator.Library.Commands;

namespace VMTranslator.Library.Components;
/// <summary>
/// A ICodeWriter translates <c>ICommand</c> to hack assembly.
/// </summary>
internal interface ICodeWriter
{
  /// <summary>
  /// Adds the ICommand to the assembly.
  /// </summary>
  /// <param name="command">The <c>ICommand</c> to prosess.</param>
  void WriteCommand(ICommand command);
  /// <summary>
  /// Gets the produced assembly code.
  /// </summary>
  /// <returns>
  /// The lines of assembly code
  /// </returns>
  string[] GetAssembly();
}
