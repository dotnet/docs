namespace GeneratedHttp.Example;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Diagnostics;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// An example of some accessor that is able to read latency context
builder.Services.AddSingleton<ILatencyContextAccessor, LatencyContextAccessor>();

// Register HTTP client latency telemetry first so its delegating handler runs earlier.
builder.Services.AddHttpClientLatencyTelemetry();

// Register export handler (runs after telemetry; sees finalized ILatencyContext).
builder.Services.AddTransient<HttpLatencyExportHandler>();

// Register an HttpClient that will emit and export latency measures.
builder.Services
    .AddHttpClient("observed")
    .AddHttpMessageHandler<HttpLatencyExportHandler>();

var host = builder.Build();
await host.RunAsync();
