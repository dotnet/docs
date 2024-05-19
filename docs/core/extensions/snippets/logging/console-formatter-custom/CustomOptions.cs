using Microsoft.Extensions.Logging.Console;

namespace Console.ExampleFormatters.Custom;

public sealed class CustomOptions : ConsoleFormatterOptions
{
    public string? CustomPrefix { get; set; }
}
