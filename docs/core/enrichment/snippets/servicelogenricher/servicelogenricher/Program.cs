using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder(args);
builder.UseApplicationMetadata();
builder.ConfigureLogging(builder =>
{
    builder.EnableEnrichment();
    builder.AddJsonConsole(op =>
    {
        op.JsonWriterOptions = new JsonWriterOptions
        {
            Indented = true
        };
    });
});
builder.ConfigureServices((context, services) =>
{
    services.AddServiceLogEnricher(context.Configuration.GetSection("applicationlogenricheroptions"));
});

var host = builder.Build();
var logger = host.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("This is a sample log message");

await host.RunAsync();


