using HackAssembler.Library.Components.Components;
using HackAssembler.Library.Components.Factories;
using HackAssembler.Library.Components.Interfaces;
using HackAssembler.Library.Components.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HackAssembler.Library;
/// <summary>
/// The <c>Builder</c> builds the objects and handles dependencies.
/// </summary>
public static class Builder
{
	/// <summary>
	/// Produces the Host Builder.
	/// </summary>
	/// <returns>An <c>IHost</c> with which objects can be retrived.</returns>
	private static IHost GenerateHost()
	{
		return Host.CreateDefaultBuilder()
			.ConfigureServices((context, services) =>
			{
				services.AddSingleton<IAssembler, Assembler>();
				services.AddSingleton<IParser, Parser>();
				services.AddSingleton<ITranslator, Translator>();
				services.AddSingleton<IWriter, FileWriter>();
				services.AddSingleton<IReader, FileReader>();
				services.AddSingleton<ISymbolTable, SymbolTable>();
				services.AddSingleton<IInstructionFactory, InstructionFactory>();
			})
			.Build();
	}
	public static IAssembler Assembler => ActivatorUtilities
		.GetServiceOrCreateInstance<Assembler>(GenerateHost().Services);
	public static ISymbolTable SymbolTable => ActivatorUtilities
		.GetServiceOrCreateInstance<SymbolTable>(GenerateHost().Services);
	public static IInstructionFactory InstructionFactory => ActivatorUtilities
		.GetServiceOrCreateInstance<InstructionFactory>(GenerateHost().Services);
	public static ITranslator Translator => ActivatorUtilities
		.GetServiceOrCreateInstance<Translator>(GenerateHost().Services);
}
