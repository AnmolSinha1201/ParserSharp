namespace ParserSharp;

public readonly ref struct ParseResult (bool success, int cursorPosition, ReadOnlySpan<char> text)
{
	public readonly bool Success = success;
	public readonly int CursorPosition = cursorPosition;
	public readonly ReadOnlySpan<char> Text = text;
}