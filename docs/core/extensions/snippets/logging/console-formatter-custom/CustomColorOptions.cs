using Microsoft.Extensions.Logging.Console;

namespace Console.ExampleFormatters.Custom;

public class CustomColorOptions : SimpleConsoleFormatterOptions
{
    public string? CustomPrefix { get; set; }
}
