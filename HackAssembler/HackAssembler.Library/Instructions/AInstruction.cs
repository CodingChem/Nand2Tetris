using HackAssembler.Library.Components;

namespace HackAssembler.Library.Instructions;

public class AInstruction : IInstruction
{
	private string _value;
    public AInstruction(string instruction)
    {
		try
		{
			int address = int.Parse(instruction.Trim('@'));
			_value = Convert.ToString(address, 2).PadLeft(16,'0');		
		}
		catch (ArgumentException)
		{
			throw new ArgumentException($"Error converting {instruction} to AInstruction");
		}
    }
    public string Translate()
	{
		return _value;
	}
}
