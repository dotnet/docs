#!/usr/local/share/dotnet/dotnet run

// <ColorfulPackage>
#:package Colorful.Console@1.2.15
// </ColorfulPackage>
// <CommandLinePackage>
#:package System.CommandLine@2.0.0-beta6
// </CommandLinePackage>

// <Usings>
using System.CommandLine;
using System.CommandLine.Parsing;
// </Usings>

// <OptionArgument>
Option<int> delayOption = new("--delay")
{
    Description = "Delay between lines, specified as milliseconds.",
    DefaultValueFactory = parseResult => 100
};

Argument<string[]> messagesArgument = new("Messages")
{
    Description = "Text to render."
};
// </OptionArgument>

// <RootCommand>
RootCommand rootCommand = new("Ascii Art file-based program sample");

rootCommand.Options.Add(delayOption);
rootCommand.Arguments.Add(messagesArgument);
// </RootCommand>

// <ParseAndValidate>
ParseResult result = rootCommand.Parse(args);
foreach (ParseError parseError in result.Errors)
{
    Console.Error.WriteLine(parseError.Message);
}
if (result.Errors.Count > 0)
{
    return 1;
}
// </ParseAndValidate>

// <InvokeCommand>
var parsedArgs = await ProcessParseResults(result);

await WriteAsciiArt(parsedArgs);
return 0;
// </InvokeCommand>

// <ProcessParsedArgs>
async Task<AsciiMessageOptions> ProcessParseResults(ParseResult result)
{
    int delay = result.GetValue(delayOption);
    List<string> messages = [.. result.GetValue(messagesArgument) ?? Array.Empty<string>()];

    if (messages.Count == 0)
    {
        while (Console.ReadLine() is string line && line.Length > 0)
        {
            // <WriteAscii>
            Colorful.Console.WriteAscii(line);
            // </WriteAscii>
            await Task.Delay(delay);
        }
    }
    return new([.. messages], delay);
}
// </ProcessParsedArgs>

// <WriteAscii>
async Task WriteAsciiArt(AsciiMessageOptions options)
{
    foreach (string message in options.Messages)
    {
        Colorful.Console.WriteAscii(message);
        await Task.Delay(options.Delay);
    }
}
// </WriteAscii>

// <Record>
public record AsciiMessageOptions(string[] Messages, int Delay);
// </Record>
