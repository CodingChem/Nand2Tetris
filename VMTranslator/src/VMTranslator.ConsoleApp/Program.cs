using VMTranslator.Library;

namespace VMTranslator.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
      string inputFile = args[0];
      ValidateInput(inputFile);

      string outputFile = inputFile.Replace(".vm", ".asm");
      string[] assemblyCode = Translator.Translate(
              File.ReadLines(inputFile).ToArray<string>()
          );

      using (StreamWriter writer = new(outputFile))
      {
          foreach (string line in assemblyCode)
          {
              writer.WriteLine(line);    
          }
      }
  }
  /// <summary>
  /// Throws exceptions if the input is not valid.
  /// </summary>
  /// <exception cref="FileNotFoundException">
  /// Thrown if the file can not be found.
  /// </exception>
  /// <exception cref="ArgumentException">
  /// Thrown if the file is not a valid vm file.
  /// </exception>
  static void ValidateInput(string input)
  {
      if (!File.Exists(input))
      {
          throw new FileNotFoundException($"The file: {input} could not be found.");
      }
      if (!input.Contains(".vm"))
      {
          throw new ArgumentException($"The file: {input} is not a valid VM file.");
      }
      
  }
}
