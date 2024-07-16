namespace HackAssembler.Library.Components.Interfaces;
/// <summary>
/// A Table of symbols.
/// </summary>
public interface ISymbolTable
{
    /// <summary>
    /// Add a given symbol to the table.
    /// </summary>
    /// <param name="symbolName">the name of the symbol to be added.</param>
    public void AddSymbol(string symbolName);
    /// <summary>
    /// Add a given symbol address pair to the table.
    /// </summary>
    /// <param name="symbolName">The name of the symbol to be added.</param>
    /// <param name="Address">The address of the symbol to be added.</param>
    public void AddSymbol(string symbolName, int Address);
    /// <summary>
    /// Retrieves the address of the given symbol.
    /// </summary>
    /// <param name="symbolName">The name of the symbol to be retrieved.</param>
    /// <returns>The address of the symbol.</returns>
    public int LookupSymbol(string symbolName);
    /// <summary>
    /// Checks if a given symbol exists in the table.
    /// </summary>
    /// <param name="symbolName">The symbol to be checked.</param>
    /// <returns><c>true</c> if the symbol exists.</returns>
    public bool SymbolExists(string symbolName);
}
