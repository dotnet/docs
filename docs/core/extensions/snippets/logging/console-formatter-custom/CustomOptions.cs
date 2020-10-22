using Microsoft.Extensions.Logging.Console;

namespace Console.ExampleFormatters.Json
{
    public class CustomOptions : ConsoleFormatterOptions
    {
        public string CustomPrefix { get; set; }
    }
}
