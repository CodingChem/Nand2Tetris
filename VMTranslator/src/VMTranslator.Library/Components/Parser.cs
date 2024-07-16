using VMTranslator.Library.Commands;

namespace VMTranslator.Library.Components;
//TODO: XML Documentation.
public class Parser : IParser
{
    private readonly List<ICommand> _commands = new List<ICommand>();
    public Parser(IFileReader reader)
    {
        string[] lines = reader.ReadLines();
        foreach (string line in lines)
        {
            _commands.Add(CommandFactory.GetCommand(line));
        }
    }
    public IEnumerable<ICommand> GetCommands()
    {
        return _commands;
    }
}
