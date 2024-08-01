namespace VMTranslator.Library.Commands;

/// <summary>
/// The <c>CommandFactory</c> produces appropriate <c>ICommand</c> from a VM command.
/// </summary>
internal static class CommandFactory
{
    /// <summary>
    /// Produce a <c>ICommand</c> from the given line.
    /// </summary>
    /// <param name="line">
    /// A string corresponding to a VM command.
    /// </param>
    /// <returns>
    /// A ICommand according to the VM command provided.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException" />
    public static ICommand GetCommand(string line)
    {
        switch (line.Split(' '))
        {
            case ["push", "constant", string x]:
                return int.TryParse(x, out int number) switch
                {
                    false => throw new ArgumentException($"argument x: {x}, could not be parsed."),
                    true
                        => number switch
                        {
                            <= 32767 and >= 0 => new PushConstantCommand(number),
                            _
                                => throw new ArgumentOutOfRangeException(
                                    $"number must be between 0 and 32767. Actual value: {number}"
                                )
                        }
                };
            case ["add"]:
                return new AddCommand();
            case ["sub"]:
                return new SubCommand();
            case ["neg"]:
                return new NegCommand();
            case ["not"]:
                return new NotCommand();
            case ["and"]:
                return new AndCommand();
            case ["or"]:
                return new OrCommand();
            default:
                throw new ArgumentException($"Invalid instruction: {line}");
        }
    }
}
