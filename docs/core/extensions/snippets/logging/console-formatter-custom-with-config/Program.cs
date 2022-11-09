using Console.ExampleFormatters.CustomWithConfig;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(builder =>
    {
        builder.AddConsole()
            .AddConsoleFormatter
                <CustomTimePrefixingFormatter, CustomWrappingConsoleFormatterOptions>();
    })
    .Build();

ILoggerFactory loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

using (logger.BeginScope("Logging scope"))
{
    logger.LogInformation("Hello World!");
    logger.LogInformation("The .NET developer community happily welcomes you.");
}
