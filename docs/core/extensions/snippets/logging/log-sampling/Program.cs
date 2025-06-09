using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Sampling;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder();
builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss";
});

// Add the Random probabilistic sampler to the logging pipeline.
builder.Logging.AddRandomProbabilisticSampler(0.01, LogLevel.Information);
builder.Logging.AddRandomProbabilisticSampler(0.1, LogLevel.Warning);

using var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("SamplingDemo");

while (true)
{
    Log.EnteredWhileLoop(logger);
    Log.NoisyLogMessage(logger);
    Log.LeftWhileLoop(logger);

    await Task.Delay(100);
}
