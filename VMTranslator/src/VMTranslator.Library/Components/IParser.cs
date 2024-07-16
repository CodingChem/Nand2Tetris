using VMTranslator.Library.Commands;

namespace VMTranslator.Library.Components;

public interface IParser
{
  IEnumerable<ICommand> GetCommands();
}
