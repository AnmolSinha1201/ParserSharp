using ParserSharp;

namespace ParserSharp.Tests;

public class Then
{
	[Fact]
	public void Success_Then()
	{
		var parser = new Parser()
			.FromText("123")
			.TokenizeAs("Number");

		var parser2 = new Parser()
			.FromText("0")
			.Then(parser);

		var result = parser2.Parse("0123");

		Assert.True(result.Success);
		Assert.Equal(4, result.CursorPosition);
		Assert.Equal("0123", result.Text.ToString());
	}

	[Fact]
	public void Failure_Then_HalfParse_CheckCorrectTokenName()
	{
		var parser = new Parser()
			.FromText("123")
			.TokenizeAs("Number");

		var parser2 = new Parser()
			.FromText("0")
			.Then(parser);

		var exception = Assert.Throws<Exception>(() => parser2.Parse("abc"));
		Assert.Contains("0", exception.Message);

		var exception2 = Assert.Throws<Exception>(() => parser2.Parse("0124"));
		Assert.Contains("Number", exception2.Message);
	}
}