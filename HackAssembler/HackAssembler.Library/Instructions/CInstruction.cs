namespace HackAssembler.Library.Instructions;
/// <summary>
/// A C Instruction of the hack processor.
/// </summary>
public class CInstruction : IInstruction
{
    private string? _dest;
    private string? _comp;
    private string? _jump;
    /// <summary>
    /// Construct a CInstruction from the given assembly instruction.
    /// </summary>
    /// <param name="assemblyInstruction">The assembly instruction.</param>
    public CInstruction(string assemblyInstruction)
    {
        if (assemblyInstruction.Contains('='))
        {
            _dest = assemblyInstruction.Split('=')[0];
            assemblyInstruction = assemblyInstruction.Split('=')[1];
        }
        if (assemblyInstruction.Contains(';'))
        {
            _jump = assemblyInstruction.Split(";")[1];
            assemblyInstruction = assemblyInstruction.Split(";")[0];
        }
        _comp = assemblyInstruction;
    }
    /// <summary>
    /// Translates the instruction.
    /// </summary>
    /// <returns>A string containing the binary representation of the instruction.</returns>
    public string Translate()
	{
        return "111" +
            GetComp() +
            GetDest() +
            GetJump();
	}
    /// <summary>
    /// Generate the comp part of the <c>CInstruction</c>.
    /// </summary>
    /// <returns>The a and cn bits of the <c>CInstruction</c></returns>
    /// <exception cref="ArgumentException"></exception>
    private string GetComp()
    {
        switch (_comp?.Trim())
        {
            case "0":
                return "0101010";
            case "1":
                return "0111111";
            case "-1":
                return "0111010";
            case "D":
                return "0001100";
            case "A":
                return "0110000";
            case "M":
                return "1110000";
            case "!D":
                return "0001101";
            case "!A":
                return "0110001";
            case "!M":
                return "1110001";
            case "-D":
                return "0001111";
            case "-A":
                return "0110011";
            case "-M":
                return "1110011";
            case "D+1":
                return "0011111";
            case "A+1":
                return "0110111";
            case "M+1":
                return "1110111";
            case "D-1":
                return "0001110";
            case "A-1":
                return "0110010";
            case "M-1":
                return "1110010";
            case "D+A":
                return "0000010";
            case "D+M":
                return "1000010";
            case "D-A":
                return "0010011";
            case "D-M":
                return "1010011";
            case "A-D":
                return "0000111";
            case "M-D":
                return "1000111";
            case "D&A":
                return "0000000";
            case "D&M":
                return "1000000";
            case "D|A":
                return "0010101";
            case "D|M":
                return "1010101";
            default:
                throw new ArgumentException($"Invalid Comp instruction {_comp}");
        }
    }
    /// <summary>
    /// Generate the dest part of the <c>CInstruction</c>
    /// </summary>
    /// <returns>The dn bits of the <c>CInstruction</c></returns>
    private string GetDest()
    {
        if (_dest == null)
            return "000";
        return
            (_dest.Contains('A') ? "1" : "0") +
            (_dest.Contains('D') ? "1" : "0") +
            (_dest.Contains('M') ? "1" : "0");
    }
    /// <summary>
    /// Generate the jmp part of the <c>CInstruction</c>.
    /// </summary>
    /// <returns>The jn bits of the <c>CInstruction</c.></returns>
    /// <exception cref="ArgumentException"></exception>
    private string GetJump()
    {
        switch (_jump?.Trim())
        {
            case null:
            case "null":
                return "000";
            case "JGT":
                return "001";
            case "JEQ":
                return "010";
            case "JGE":
                return "011";
            case "JLT":
                return "100";
            case "JNE":
                return "101";
            case "JLE":
                return "110";
            case "JMP":
                return "111";
            default:
                throw new ArgumentException($"invalid jump instruction: {_jump}");
        }
    }
}
