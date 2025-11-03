using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);
builder.UseApplicationMetadata();
builder.Logging.EnableEnrichment();
builder.Logging.AddJsonConsole(op =>
{
    op.JsonWriterOptions = new JsonWriterOptions
    {
        Indented = true
    };
});
builder.Services.AddServiceLogEnricher(builder.Configuration.GetSection("ApplicationLogEnricherOptions"));

var host = builder.Build();
var logger = host.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("This is a sample log message");

await host.RunAsync();
