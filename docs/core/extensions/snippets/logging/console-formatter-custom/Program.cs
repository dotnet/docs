using Microsoft.Extensions.Hosting;

namespace Console.ExampleFormatters.Custom
{
    class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddCustomFormatter(options =>
                {
                    options.CustomPrefix = " ~~~~~ ";
                });
            });

            var logger = loggerFactory.CreateLogger<Program>();
            using (logger.BeginScope("TODO: Add logic to enable scopes"))
            {
                logger.LogInformation("Hello World!");
                logger.LogInformation("TODO: Add logic to enable timestamp and log level info.");
            }
        }
    }
}
