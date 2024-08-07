using System.Security.Principal;

namespace ParserSharp;

public class Parser : BaseParserConstruct
{
	public List<IParserPrimitive> ParsingSequence = new();

    public override void AddToParsingSequence(FromTextPrimitive primitive)
    => ParsingSequence.Add(primitive);

    public override ParseResult Parse(ReadOnlySpan<char> textToParse)
    {
		var cursorPosition = 0;
		var localSpan = textToParse;

		foreach (var primitive in ParsingSequence)
		{
			var result = primitive.Parse(localSpan);
			if (!result.Success)
			{
				var expectedText = TokenName ?? primitive.GetTokenName();
				throw new Exception($"Found {localSpan.Truncate(3)}, Expected {expectedText}");
			}
				
			localSpan = localSpan.Slice(result.CursorPosition);
			cursorPosition = result.CursorPosition;
		}

		return new ParseResult(true, cursorPosition, textToParse.Slice(0, cursorPosition));
    }
}