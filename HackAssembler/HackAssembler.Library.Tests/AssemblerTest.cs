using HackAssembler.Library.Components.Components;
using HackAssembler.Library.Components.Factories;
using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Components.IO;
using HackAssembler.Library.Tests.Mock;

namespace HackAssembler.Library.Tests;

[TestClass]
public class AssemblerTest
{
	private InMemoryWriter _writer = new();
	private IAssembler assembler = Builder.Assembler;
	[TestInitialize]
	public void InitializeTests()
	{
		// Reset the writer.
		_writer = new InMemoryWriter();
		// Pass a new assembler with a fresh symbolTable before every test.
		var symbolTable = new SymbolTable();
		assembler = new Assembler(
				new Parser(
						symbolTable,
						new InstructionFactory(symbolTable)
					),
				new Translator(),
				new FileReader(),
				_writer
				);
	}
	[TestMethod]
	public void Assembler_CanBeInitialized()
	{
		Assert.IsNotNull(assembler);
	}
	[TestMethod]
	[DynamicData(nameof(AssemblyFiles))]
	public void Assembler_ProducesCorrectOutputWithoutSymbols(string assemblyFile)
	{
		string asmPath = Path.Combine("TestData", (assemblyFile.Contains("Add") ? assemblyFile : assemblyFile.Replace(".asm", "L.asm")));
		string[] compareFile = new FileReader().Read(asmPath.Replace("L.asm", ".hack").Replace(".asm", ".hack"));

		assembler.Assemble(asmPath);
		
		Assert.AreEqual(compareFile.Length, _writer.Contents.Length);
		for (int i = 0; i < compareFile.Length; i++)
		{
			Assert.AreEqual(compareFile[i], _writer.Contents[i], $"Comparison failure in line {i}\nExpected {compareFile[i]}\nActual {_writer.Contents[i]}");
		}
	}
	[TestMethod]
	[DynamicData(nameof(AssemblyFiles))]
	public void Assembler_ProducesCorrectOutputWithSymbols(string assemblyFile)
	{
		string asmPath = Path.Combine("TestData", assemblyFile);
		string[] compareFile = new FileReader().Read(asmPath.Replace(".asm", ".hack"));

		assembler.Assemble(asmPath);
		
		Assert.AreEqual(compareFile.Length, _writer.Contents.Length);
		for (int i = 0; i < compareFile.Length; i++)
		{
			Assert.AreEqual(compareFile[i], _writer.Contents[i], $"Comparison failure in line {i}\nExpected {compareFile[i]}\nActual {_writer.Contents[i]}");
		}
	}
	public static IEnumerable<object[]> AssemblyFiles
	{
		get
		{
			foreach (string test in new string[] { "Add.asm", "Max.asm", "Pong.asm", "Rect.asm" })
			{
				yield return [test];
			}
			yield break;
		}
	}
}