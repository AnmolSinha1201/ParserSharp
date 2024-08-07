namespace ParserSharp;

public static partial class Helpers
{
	public static string Truncate(this ReadOnlySpan<char> inputSpan, int maxLength, string suffix = "...")
	{
		if (inputSpan.Length <= maxLength)
			return inputSpan.ToString();
		return $"{inputSpan}{suffix}";
	}
}