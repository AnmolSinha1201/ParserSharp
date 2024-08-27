using System.Security.Principal;

namespace ParserSharp;

public partial class Parser
{
	public List<IParserPrimitive> ParsingSequence = new();

    public void AddToParsingSequence(IParserPrimitive primitive)
    => ParsingSequence.Add(primitive);

	public string TokenName = string.Empty;
	public Parser TokenizeAs(string tokenName)
	{
		this.TokenName = tokenName;
		return this;
	}

    public ParseResult Parse(ReadOnlySpan<char> textToParse)
    {
		var cursorPosition = 0;
		var localSpan = textToParse;

		foreach (var primitive in ParsingSequence)
		{
			var result = primitive.Parse(localSpan);
			if (!result.Success)
			{
				var expectedText = string.IsNullOrEmpty(TokenName) ? primitive.GetTokenName() : TokenName;
				throw new Exception($"Found {localSpan.Truncate(3)}, Expected {expectedText}");
			}
				
			localSpan = localSpan.Slice(result.CursorPosition);
			cursorPosition = result.CursorPosition;
		}

		return new ParseResult(true, cursorPosition, textToParse.Slice(0, cursorPosition));
    }
}