using System.IO;
using System.Reflection;
using ExampleAssembly;
using ExtensionMethods;
using XmlDocMarkdown.Core;
using Xunit;

namespace XmlDocMarkdown.Tests
{
	public class MarkdownGeneratorTests
	{
		[Fact]
		public void ExampleAssembly()
		{
			XmlDocMarkdownGenerator.Generate(
				typeof(ExampleClass).GetTypeInfo().Assembly.Location,
				Path.Combine(Path.GetTempPath(), "MarkdownGeneratorTests"),
				new XmlDocMarkdownSettings { IsDryRun = true });
		}

		[Fact]
		public void FSharpWithNulls()
		{
			XmlDocMarkdownGenerator.Generate(
				typeof(Augment).GetTypeInfo().Assembly.Location,
				Path.Combine(Path.GetTempPath(), "MarkdownGeneratorTests"),
				new XmlDocMarkdownSettings { IsDryRun = true });
		}

		[Fact]
		public void SourceSymbolTests()
		{
			// generated into `/tests/data` using the following commands
			//
			// dotnet tool install --global SourceLinkExtract
			// dotnet tool install --global SourceSymbolMapper
			//
			// extract test.pdb meta.json out
			// mapper meta.json out symbols.json
			//
			// For this test only the symbols.json is needed, the remaining output can be discarded.
			// Assumes tests are run in $(ProjectDir) := /tests/
			XmlDocMarkdownGenerator.Generate(
				typeof(ExampleClass).GetTypeInfo().Assembly.Location,
				Path.Combine(Path.GetTempPath(), "MarkdownGeneratorTests"),
				new() { IsDryRun = true, SourceSymbols = Environment.CurrentDirectory + "/tests/data/symbols.json"});
		}
	}
}
