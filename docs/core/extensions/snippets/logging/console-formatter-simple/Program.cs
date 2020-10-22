using Microsoft.Extensions.Logging.Console;

namespace Console.ExampleFormatters.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSimpleConsole(o =>
                {
                    o.IncludeScopes = true;
                    o.SingleLine = true;
                    o.TimestampFormat = "hh:mm:ss ";
                });
            });

            var logger = loggerFactory.CreateLogger<Program>();
            using (logger.BeginScope("[scope is enabled]"))
            {
                logger.LogInformation("Hello World!");
                logger.LogInformation("Logs contain timestamp and log level.");
                logger.LogInformation("Each log message is fit in a single line.");
            }
        }
    }
}
