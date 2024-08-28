namespace ParserSharp;

public class FromTextPrimitive : IParserPrimitive
{
	public readonly ReadOnlyMemory<char> TextToMatch;
	public FromTextPrimitive(ReadOnlyMemory<char> textToMatch)
	=> this.TextToMatch = textToMatch;

    public ParseResult Parse(ReadOnlySpan<char> textToParse)
	{
		if (textToParse.Length < TextToMatch.Length)
			return new ParseResult(false, 0, ReadOnlySpan<char>.Empty);

		var slice = textToParse[..TextToMatch.Length];
		if (slice.Equals(TextToMatch.Span, StringComparison.Ordinal))
			return new ParseResult(true, TextToMatch.Length, slice);

		return new ParseResult(false, 0, ReadOnlySpan<char>.Empty);
	}

	public string GetTokenName()
	=> TextToMatch.ToString();
}

public partial class Parser
{
	public Parser FromText(string text)
	=> this.FromText(text.AsMemory());

	public Parser FromText(ReadOnlyMemory<char> text)
	{
		var primitive = new FromTextPrimitive(text);
		this.AddToParsingSequence(primitive);
		return this;
	}
}