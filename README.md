![GitHub last commit](https://img.shields.io/github/last-commit/AnmolSinha1201/ParserSharp?style=flat-square)
![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/AnmolSinha1201/ParserSharp/Test.yml?branch=main&style=flat-square)



# ParserSharp
Welcome to ParserSharp, an efficient parser-combinator library created in C# for effective text parsing. Designed from scratch with user-friendliness in mind, it enables the definition and description of complex structures using a fluent API, making the process feel intuitive.

Additionally, it utilizes the latest C# features to minimize memory usage and ensure fast parsing speeds. We are continuously evolving and adding new features, so stay tuned for updates.

## Documentation
The documentation can be found at [here](https://github.com/AnmolSinha1201/ParserSharp/wiki) with some examples and best practices. To get started, here are a few examples.

### Creating a basic parser.
```cs
var parser = new Parser()
    .FromText("123");

var result = parser.Parse("1234");
// Success = true, Result = "123", CursorPosition = 3
```
### Chaining different parsers.
```cs
var foo = new Parser()
	.FromText("123");

var bar = new Parser()
	.FromText("0")
	.Then(foo);

var result = bar.Parse("0123");
```

Also refer to the documentation for more complete explanation of code and behavior.