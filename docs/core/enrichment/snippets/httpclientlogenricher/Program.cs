using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddHttpClientLogEnricher<CustomHttpClientLogEnricher>();
builder.Services.AddExtendedHttpClientLogging();
builder.Services.AddRedaction();

builder.Services.AddHostedService<HostedService>();

builder.Logging.AddJsonConsole(op =>
{
    op.JsonWriterOptions = new JsonWriterOptions
    {
        Indented = true
    };
});

using IHost host = builder.Build();

await host.RunAsync();
