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

public static partial class ParserExtensions
{
	public static T FromText<T>(this T construct, string text) where T : BaseParserConstruct
	=> construct.FromText(text.AsMemory());

	public static T FromText<T>(this T construct, ReadOnlyMemory<char> text) where T : BaseParserConstruct
	{
		var primitive = new FromTextPrimitive(text);
		construct.AddToParsingSequence(primitive);
		return construct;
	}
}