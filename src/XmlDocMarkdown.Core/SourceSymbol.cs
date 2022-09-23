namespace XmlDocMarkdown.Core;

internal readonly record struct SourceSymbol(string type, string link, string path, int start, int end);
