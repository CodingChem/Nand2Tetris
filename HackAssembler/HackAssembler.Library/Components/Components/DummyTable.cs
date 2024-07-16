using HackAssembler.Library.Components.Interfaces;

namespace HackAssembler.Library.Components.Components;
/// <summary>
/// <c>DummyTable</c> implements the <c>ISymbolTable</c> but is only used to test the assembler 
/// on assemblyfiles which do not use symbols or labels.
/// </summary>
internal class DummyTable : ISymbolTable
{
    /// <summary>
    /// This method will throw if invoked.
    /// </summary>
    /// <param name="symbolName"></param>
    /// <param name="Address"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void AddSymbol(string symbolName, int Address)
    {
        throw new NotImplementedException("Implement SymbolTable to be able to assemble code with symbols.");
    }
    /// <summary>
    /// This method will throw if invoked.
    /// </summary>
    /// <param name="symbolName"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void AddSymbol(string symbolName)
    {
        throw new NotImplementedException("Implement SymbolTable to be able to assemble code with symbols.");
    }
    /// <summary>
    /// This method will throw if invoked.
    /// </summary>
    /// <param name="symbolName"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int LookupSymbol(string symbolName)
    {
        throw new NotImplementedException("Implement SymbolTable to be able to assemble code with symbols.");
    }

    /// <summary>
    /// Checks if the symbol is in the table.
    /// </summary>
    /// <param name="symbolName"></param>
    /// <returns>Always returns false.</returns>
    public bool SymbolExists(string symbolName)
    {
        return false;
    }
}
