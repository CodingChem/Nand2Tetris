namespace VMTranslator.Library.Components;

public interface IFileWriter
{
  void WriteLine(string line);
  void Close();
}
