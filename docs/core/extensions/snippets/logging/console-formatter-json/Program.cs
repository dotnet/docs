using System.Text.Json;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddJsonConsole(options =>
{
    options.IncludeScopes = false;
    options.TimestampFormat = "HH:mm:ss ";
    options.JsonWriterOptions = new JsonWriterOptions
    {
        Indented = true
    };
});

using IHost host = builder.Build();

var logger =
    host.Services
        .GetRequiredService<ILoggerFactory>()
        .CreateLogger<Program>();

logger.LogInformation("Hello .NET friends!");

await host.RunAsync();
