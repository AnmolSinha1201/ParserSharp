using ParserSharp;

var foo = new Parser()
	.FromText("123")
	.TokenizeAs("Number");

var bar = new Parser()
	.FromText("0")
	.Then(foo);

// char[] toParse = ['1', '2', '3', '1', '2', '3'];
var toParse = "0123";
var result = bar.Parse(toParse);
// toParse[1] = '4';

Console.WriteLine("foobar");