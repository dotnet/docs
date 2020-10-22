using Microsoft.Extensions.Hosting;

namespace Console.ExampleFormatters.Systemd
{
    class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSystemdConsole(o => {
                    o.IncludeScopes = true;
                    o.TimestampFormat = "hh:mm:ss ";
                });
            });

            var logger = loggerFactory.CreateLogger<Program>();
            using (logger.BeginScope("[scope is enabled]"))
            {
                logger.LogInformation("Hello World!");
                logger.LogInformation("Logs contain timestamp and log level.");
                logger.LogInformation("Systemd console logs never provide color options.");
                logger.LogInformation("Systemd console logs always appear in a single line.");
            }
        }
    }
}
