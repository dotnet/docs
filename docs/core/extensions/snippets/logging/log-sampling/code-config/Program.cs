using LogSamplingCodeConfig;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Sampling;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss";
});

// Add the Random probabilistic sampler to the logging pipeline.
builder.Logging.AddRandomProbabilisticSampler(options =>
{
    options.Rules.Add(
        new RandomProbabilisticSamplerFilterRule(
            probability: 0.05d,
            eventId : 1001));
});

using var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("SamplingDemo");

for (int i = 0; i < 1_000_000; i++)
{
    logger.NoisyMessage();
}
