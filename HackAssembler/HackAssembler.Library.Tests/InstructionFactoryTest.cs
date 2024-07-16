namespace HackAssembler.Library.Tests;

using HackAssembler.Library;
using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Instructions;

[TestClass]
public class InstructionFactoryTest
{
	private IInstructionFactory? factory;
	[TestInitialize]
	public void Initialize_InstructionFactory()
	{
		factory = Builder.InstructionFactory;
	}
	public static IEnumerable<object[]> BuiltInnSymbolData
	{
		get
		{
			return
			[
				["@R0", "".PadLeft(16,'0')],
				["@KBD", Convert.ToString(24576,2).PadLeft(16,'0')]
			];
		}
	}
	[TestMethod]
	[DynamicData(nameof(BuiltInnSymbolData))]
	public void InstructionFactory_RetrivesCorrect_BuiltinSymbol(string instruction, string expectedResult)
	{
		AInstruction? aInstruction = factory!.CreateInstruction(instruction) as AInstruction;
		Assert.IsNotNull(aInstruction);
		Assert.AreEqual(expectedResult, aInstruction.Translate());
	}
}