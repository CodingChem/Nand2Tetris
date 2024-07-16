using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Models;

namespace HackAssembler.Library.Components.Components;
/// <summary>
/// A <c>SymbolTable</c> which stores and looks up any labels, symbols or builtin constants
/// in the hack assembly file.
/// </summary>
public class SymbolTable : ISymbolTable
{
    private readonly List<Symbol> _symbols;
    private int _nextVariableIndex;
    /// <summary>
    /// Constructs a <c>SymbolTable</c>.
    /// </summary>
    public SymbolTable()
    {
        _symbols = LoadBuiltinSymbols();
        _nextVariableIndex = 16;
    }

    /// <summary>
    /// Produces a List of Symbols containing all the builtin symbols per the hack assembly specification.
    /// </summary>
    /// <returns><c>List</c> of <c>Symbol</c> containing all the builtins.</returns>
    private static List<Symbol> LoadBuiltinSymbols()
    {
        return [
            new Symbol { Name="R0", Address=0 },
            new Symbol { Name="R1", Address=1 },
            new Symbol { Name="R2", Address=2 },
            new Symbol { Name="R3", Address=3 },
            new Symbol { Name="R4", Address=4 },
            new Symbol { Name="R5", Address=5 },
            new Symbol { Name="R6", Address=6 },
            new Symbol { Name="R7", Address=7 },
            new Symbol { Name="R8", Address=8 },
            new Symbol { Name="R9", Address=9 },
            new Symbol { Name="R10", Address=10 },
            new Symbol { Name="R11", Address=11 },
            new Symbol { Name="R12", Address=12 },
            new Symbol { Name="R13", Address=13 },
            new Symbol { Name="R14", Address=14 },
            new Symbol { Name="R15", Address=15 },
            new Symbol { Name="SCREEN", Address=16384 },
            new Symbol { Name="KBD", Address=24576 },
            new Symbol { Name="SP", Address=0 },
            new Symbol { Name="LCL", Address=1 },
            new Symbol { Name="ARG", Address=2 },
            new Symbol { Name="THIS", Address=3 },
            new Symbol { Name="THAT", Address=4 }
        ];
    }

    /// <summary>
    /// Adds a symbol to the table.
    /// </summary>
    /// <param name="symbolName">The name of the symbol to be added.</param>
    public void AddSymbol(string symbolName)
    {
        AddSymbol(symbolName, _nextVariableIndex++);
    }

    /// <summary>
    /// Adds a symbol address pair to the table.
    /// </summary>
    /// <param name="symbolName">The name of the symbol.</param>
    /// <param name="Address">The address of the symbol.</param>
    public void AddSymbol(string symbolName, int Address)
    {
        _symbols.Add(new Symbol { Name = symbolName, Address = Address });
    }

    /// <summary>
    /// Returns the address of the symbol in the table.
    /// </summary>
    /// <param name="symbolName">The name of the symbol to be added.</param>
    /// <returns>The address of the symbol.</returns>
    public int LookupSymbol(string symbolName)
    {
        return _symbols.First((symbol) => symbol.Name == symbolName).Address;
    }
/// <summary>
/// Checks if the symbol exists in the table.
/// </summary>
/// <param name="symbolName">The name of the symbol to check.</param>
/// <returns><c>true</c> if the symbol exists in the table.</returns>
    public bool SymbolExists(string symbolName)
    {
        return _symbols.Any(symbol => symbol.Name == symbolName);
    }
}
