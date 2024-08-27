namespace ParserSharp;

public class ThenPrimitive : IParserPrimitive
{
	public readonly Parser InternalParser;
	public ThenPrimitive(Parser parser)
	=> this.InternalParser = parser;

	public ThenPrimitive(IParserPrimitive primitive)
	{
		if (this.InternalParser == default)
			this.InternalParser = new Parser();

		this.InternalParser.AddToParsingSequence(primitive);
	}

    public ParseResult Parse(ReadOnlySpan<char> textToParse)
	=> this.InternalParser.Parse(textToParse);

	public string GetTokenName()
	=> this.InternalParser.GetTokenName();
}

public partial class Parser
{
	public Parser Then(Parser parser)
	{
		var primitive = new ThenPrimitive(parser);
		this.AddToParsingSequence(primitive);

		return this;
	}
}