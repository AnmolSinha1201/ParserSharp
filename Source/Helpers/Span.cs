namespace ParserSharp;

internal static partial class Helpers
{
	public static ReadOnlySpan<char> Truncate(this ReadOnlySpan<char> inputSpan, int maxLength, string suffix = "...")
	{
		if (inputSpan.Length <= maxLength)
			return inputSpan;
		return $"{inputSpan[..maxLength]}{suffix}";
	}
}