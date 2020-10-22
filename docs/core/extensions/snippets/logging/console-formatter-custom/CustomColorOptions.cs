using Microsoft.Extensions.Logging.Console;

namespace Console.ExampleFormatters.Custom
{
    public class CustomOptions : SimpleConsoleFormatterOptions
    {
        public string CustomPrefix { get; set; }
    }
}
