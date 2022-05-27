using Microsoft.Extensions.Logging.Console;

namespace Console.ExampleFormatters.Custom;

public class CustomOptions : ConsoleFormatterOptions
{
    public string? CustomPrefix { get; set; }
}
