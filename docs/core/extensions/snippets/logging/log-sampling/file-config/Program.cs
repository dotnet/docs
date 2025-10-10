using LogSamplingFileConfig;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder();

builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss";
});

// Add the Random probabilistic sampler to the logging pipeline.
builder.Logging.AddRandomProbabilisticSampler(builder.Configuration);

using var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("SamplingDemo");

while (true)
{
    logger.EnteredWhileLoop();
    logger.NoisyMessage();
    logger.LeftWhileLoop();
    await Task.Delay(100);
}
