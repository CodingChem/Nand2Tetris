using VMTranslator.Library.Commands;
using VMTranslator.Library.Components;

namespace VMTranslator.Library;

/// <summary>
/// The <c>VMTranslator</c> Can translate VM code to hack Assembly code.
/// </summary>
public static class Translator
{
    /// <summary>
    /// Translates VM Code to Assembly code.
    /// </summary>
    /// <param name="vmCode">
    /// The VM code to be translated.
    /// </param>
    /// <returns>
    /// The lines of translated assembly code.
    /// </returns>
    public static string[] Translate(string[] vmCode)
    {
        IParser parser = new Parser(vmCode);
        ICodeWriter writer = new CodeWriter();

        foreach (ICommand command in parser.GetCommands())
        {
            writer.WriteCommand(command);
        }

        return writer.GetAssembly();
    }
}
