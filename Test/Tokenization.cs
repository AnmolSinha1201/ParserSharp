using ParserSharp;

namespace ParserSharp.Tests;

public class Tokenization
{
	[Fact]
	public void Success_TokenizeAs_NotTriggered()
	{
		var parser = new Parser()
			.FromText("123")
			.TokenizeAs("Number");

		var result = parser.Parse("123");

		Assert.True(result.Success);
		Assert.Equal(3, result.CursorPosition);
		Assert.Equal("123", result.Text.ToString());
	}

	[Fact]
	public void Failure_TokenizeAs_Triggered()
	{
		var parser = new Parser()
			.FromText("123")
			.TokenizeAs("Number");

		var exception = Assert.Throws<Exception>(() => parser.Parse("abc"));
		Assert.Contains("Number", exception.Message);
	}a
}