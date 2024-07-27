using VMTranslator.Library.Commands;

namespace VMTranslator.Library.Components;
///<Summary>
///The Parser parses VM Code to ICommand objects.
///</Summary>
public class Parser : IParser
{
    private readonly List<ICommand> _commands = new List<ICommand>();
    ///<Summary>
    ///Constructor for a Parser object.
    ///</Summary>
    ///<param name="lines">
    ///The lines of VM code to parse.
    ///</param>
    public Parser(string[] lines)
    {
        foreach (string line in lines)
        {
            if (IsCommand(line.Trim()))
                _commands.Add(CommandFactory.GetCommand(line.Trim().Split("//")[0]));
        }
    }
    ///<Summary>
    ///Get the ICommands.
    ///</Summary>
    ///<returns>
    ///Returns the set of ICommands parsed from the IFileReader.
    ///</returns>
    public IEnumerable<ICommand> GetCommands()
    {
        return _commands;
    }
    ///<Summary>
    ///Checks if the given string is a valid ICommand.
    ///</Summary>
    ///<param name="line">
    ///The string to test if it is a valid ICommand.
    ///</param>
    ///<returns>
    ///Returns <c>true</c> if the string is a valid ICommand.
    ///</returns>
    private bool IsCommand(string line)
    {
        return !IsComment(line) && !IsWhiteSpace(line);
    }
    ///<Summary>
    ///Checks if the given string is a comment.
    ///</Summary>
    ///<param name="line">
    ///The string to test.
    ///</param>
    ///<returns>
    ///Returns <c>true</c> if the string is a comment.
    ///</returns>
    private bool IsComment(string line)
    {
        return line.StartsWith("//");
    }
    ///<Summary>
    ///Checks if the given string contains only white space.
    ///</Summary>
    ///<param name="line">
    ///The string to test.
    ///</param>
    ///<returns>
    ///Returns <c>true</c> if the line contains only white space.
    ///</returns>
    private bool IsWhiteSpace(string line)
    {
        return line == "";
    }
}
