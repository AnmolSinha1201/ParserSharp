namespace ParserSharp;

public interface IParserPrimitive
{
	ParseResult Parse(ReadOnlySpan<char> textToParse);
	string GetTokenName();
}