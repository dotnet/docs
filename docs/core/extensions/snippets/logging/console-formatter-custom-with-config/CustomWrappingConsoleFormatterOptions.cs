using Microsoft.Extensions.Logging.Console;

namespace Console.ExampleFormatters.CustomWithConfig;

public sealed class CustomWrappingConsoleFormatterOptions : ConsoleFormatterOptions
{
    public string? CustomPrefix { get; set; }

    public string? CustomSuffix { get; set; }
}
