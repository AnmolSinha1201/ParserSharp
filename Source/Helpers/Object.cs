namespace ParserSharp;

internal static partial class Helpers
{
	public static T With<T>(this T input, Action<T> predicate)
	{
		predicate(input);
		return input;
	}
}