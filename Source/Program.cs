using ParserSharp;

var foo = new Parser()
	.FromText("123")
	.TokenizeAs("Number");
// char[] toParse = ['1', '2', '3', '1', '2', '3'];
var toParse = "asd";
var result = foo.Parse(toParse);
// toParse[1] = '4';

Console.WriteLine("foobar");