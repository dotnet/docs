using LogSamplingFileConfig;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var hostBuilder = Host.CreateApplicationBuilder();

hostBuilder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss";
});

// Add the Random probabilistic sampler to the logging pipeline.
hostBuilder.Logging.AddRandomProbabilisticSampler(hostBuilder.Configuration);

using var app = hostBuilder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("SamplingDemo");

while (true)
{
    logger.EnteredWhileLoop();
    logger.NoisyMessage();
    logger.LeftWhileLoop();
    await Task.Delay(100);
}
