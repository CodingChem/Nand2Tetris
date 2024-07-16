using HackAssembler.Library;

namespace HackAssembler
{
	internal class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 1)
			{
				Builder.Assembler.Assemble(args[0]);
			}
			else if (args.Length > 1)
			{
				throw new NotImplementedException("Multiple arguents is not yet supported.");
			}
			else
			{
				Console.WriteLine("Invalid Arguments.");
			}
		}
	}
}
