using VMTranslator.Library.Commands;

namespace VMTranslator.Library.Components;
///<summary>
///The IParser retrieves ICommand objects.
///</summary>
internal interface IParser
{
  /// <summary>
  /// Get the ICommands.
  /// </summary>
  /// <returns>
  /// an IEnumerable of ICommand.
  /// </returns>
  IEnumerable<ICommand> GetCommands();
}
