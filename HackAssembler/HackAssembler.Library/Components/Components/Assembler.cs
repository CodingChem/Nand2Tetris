using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Components.IO;
using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Components.Components;
/// <summary>
/// Class <c>Assembler</c> decodes a .asm hack assembly file into a .hack binary files.
/// </summary>
/// <remarks>
/// It should be retrieved from the <c>Builder</c>, but it can be assembled manually from the constructor.
/// </remarks>
/// <param name="parser"></param> An IParser to parse the input file.
/// <param name="translator"></param> An ITranslator to translate the Mnemonics to instructions
/// <param name="reader"></param> An IReader to get the input
/// <param name="writer"></param> An IWriter to handle the output
public class Assembler(IParser parser, ITranslator translator, IReader reader, IWriter writer) : IAssembler
{
    private readonly IParser _parser = parser;
    private readonly ITranslator _translator = translator;
    private readonly IReader _reader = reader;
    private readonly IWriter _writer = writer;
    /// <summary>
    /// Method <c>Assemble</c> decodes a .asm file to a .hack file.
    /// </summary>
    /// <param name="inputFile">The file to assemble.</param>
    /// <returns></returns>
    public Task Assemble(string inputFile)
    {
        string[] fileContents = _reader.Read(inputFile);
        string outputFileName = _writer.GetOutputFileName(inputFile);

        _parser.Parse(fileContents);

        // Write the output.
        foreach (IInstruction instruction in _parser.Instructions())
        {
            _writer.WriteLine(_translator.Translate(instruction));
        }
        return Task.Run(() => _writer.WriteFileAsync(outputFileName));
    }
}
