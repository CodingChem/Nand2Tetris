using VMTranslator.Library.Commands;

namespace VMTranslator.Library.Components;

public interface ICodeWriter
{
  void WriteCommand(ICommand command);
  void Close();
}
