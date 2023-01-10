using System.Text.Json;
using Console.ExampleFormatters.Json;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>())
    .ConfigureLogging(builder =>
        builder.AddJsonConsole(options =>
        {
            options.IncludeScopes = false;
            options.TimestampFormat = "HH:mm:ss ";
            options.JsonWriterOptions = new JsonWriterOptions
            {
                Indented = true
            };
        }))
    .Build();

var logger =
    host.Services
        .GetRequiredService<ILoggerFactory>()
        .CreateLogger<Startup>();

logger.LogInformation("Hello .NET friends!");

await host.RunAsync();
