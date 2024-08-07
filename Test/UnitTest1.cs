using ParserSharp;

namespace Test;

public class BasicParsing
{
	[Fact]
	public void Success_Complete()
	{
		var parser = new Parser()
			.FromText("123");

		var result = parser.Parse("123");

		Assert.True(result.Success);
		Assert.Equal(3, result.CursorPosition);
		Assert.Equal("123", result.Text.ToString());
	}

	[Fact]
	public void Success_Partial()
	{
		var parser = new Parser()
			.FromText("123");

		var result = parser.Parse("1234");

		Assert.True(result.Success);
		Assert.Equal(3, result.CursorPosition);
		Assert.Equal("123", result.Text.ToString());
	}

	[Fact]
	public void Failure_Partial()
	{
		var parser = new Parser()
			.FromText("123");

		Assert.Throws<Exception>(() => parser.Parse("12"));
	}

	[Fact]
	public void Failure_SomethingElse()
	{
		var parser = new Parser()
			.FromText("123");

		Assert.Throws<Exception>(() => parser.Parse("abc"));
	}
}