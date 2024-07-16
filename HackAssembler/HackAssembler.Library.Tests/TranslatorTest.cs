using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Components.IO;
using HackAssembler.Library.Instructions;

namespace HackAssembler.Library.Tests;
[TestClass]
public class TranslatorTest
{
	private readonly ITranslator _translator = Builder.Translator;

	[TestMethod]
	public void Translator_CInstruction_HasRigthLength()
	{
		IInstruction instruction = new CInstruction("D=D+1;JLE");

		string decodedInstruction = _translator.Translate(instruction);

		Assert.AreEqual(16, decodedInstruction.Length, "Instruction should be 16 bits");
	}
	[TestMethod]
	public void Translator_CanTranslate_CInstruction()
	{
		IInstruction aInstruction1 = new CInstruction("D=D+1;JLE");
		string DecodedAInstruction1 = "1110011111010110";

		string aInstruction1_decoded = _translator.Translate(aInstruction1);

		Assert.AreEqual(DecodedAInstruction1, aInstruction1_decoded, "");
	}
	[TestMethod]
	public void Translator_CanTranslate_AInstruction()
	{
		IInstruction aInstruction1 = new AInstruction("@255");
		string DecodedAInstruction1 = "11111111".PadLeft(16, '0');

		IInstruction aInstruction2 = new AInstruction("@254");
		string DecodedAInstruction2 = "11111110".PadLeft(16, '0');

		string decoded1 = _translator.Translate(aInstruction1);
		string decoded2 = _translator.Translate(aInstruction2);

		Assert.AreEqual(decoded1, DecodedAInstruction1);
		Assert.AreEqual(decoded2, DecodedAInstruction2);
	}
	[TestMethod]
	[DynamicData(nameof(MnemonicTranslationTable))]
	public void Translator_CanTranslateAllCInstructions_Comp(string mnemonic, string expected)
	{
		CInstruction cInstruction = new(mnemonic);

		string binaryTranslation = _translator.Translate(cInstruction);

		Assert.IsNotNull(binaryTranslation);
		Assert.AreEqual(expected, binaryTranslation.Substring(3,7));
	}
	public static IEnumerable<object[]> MnemonicTranslationTable
	{
		get
		{
			var reader = new FileReader();
			string[] lines = reader.Read(Path.Combine("TestData","CTable.csv"));
			foreach (string line in lines)
			{
				yield return new object[] { line.Split(' ')[0], line.Split(' ')[1] };
			}
			yield break;
		}
	}
}
