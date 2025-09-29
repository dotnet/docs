using System.Diagnostics;
using LogSamplingTraceBased;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Trace;

using ActivitySource demoSource = new("LogSamplingTraceBased");

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss";
});

// Add the Random probabilistic sampler to the logging pipeline.
builder.Logging.AddTraceBasedSampler();

using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    // Enable Tracing sampling configured with 50% probability:
    .SetSampler(new TraceIdRatioBasedSampler(0.5))
    .AddSource("LogSamplingTraceBased")
    .AddConsoleExporter()
    .Build();

using var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("SamplingDemo");

// On average, 50% of Activities and logs will be sampled:
for (int i = 0; i < 10; i++)
{
    using var activity = demoSource.StartActivity("SayHello");
    activity?.SetTag("foo", "bar");
    activity?.SetStatus(ActivityStatusCode.Ok);

    // The parent activity is sampled with 50% probability,
    // and the same sampling decision will be used for logging
    logger.NoisyMessage(i);
}
