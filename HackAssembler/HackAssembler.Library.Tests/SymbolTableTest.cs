using HackAssembler.Library.Components.Factories;
using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Tests;

[TestClass]
public class SymbolTableTest
{
	private ISymbolTable symbolTable = Builder.SymbolTable;
	[TestInitialize]
	public void ResetSymbolTable()
	{
		symbolTable = Builder.SymbolTable;
	}
	[TestMethod]
	[DataRow("R0")]
	[DataRow("KBD")]
	public void SymbolTableContainsBuiltinSymbols(string symbol)
	{
		Assert.IsTrue(symbolTable.SymbolExists(symbol));
	}
	[TestMethod]
	[DataRow("@myVariable")]
	public void SymbolTable_CanCreateVariables(string variable)
	{
		Assert.IsFalse(symbolTable.SymbolExists(variable));
		symbolTable.AddSymbol(variable);
		Assert.IsTrue(symbolTable.SymbolExists(variable));
	}
	[TestMethod]
	public void SymbolTable_NewVariablesStartAt16()
	{
		string variable = "@myVariable";
		symbolTable.AddSymbol(variable);

		Assert.AreEqual(16, symbolTable.LookupSymbol(variable));
	}
	[TestMethod]
	public void SymbolTable_VariableAddressIncrements()
	{
		string firstVariable = "@myFirstVariable";
		string secoundVariable = "@mySecoundVariable";

		symbolTable.AddSymbol(firstVariable);
		symbolTable.AddSymbol(secoundVariable);

		int addressDifference = symbolTable.LookupSymbol(secoundVariable) - symbolTable.LookupSymbol(firstVariable);

		Assert.AreEqual(1, addressDifference);
	}
}
