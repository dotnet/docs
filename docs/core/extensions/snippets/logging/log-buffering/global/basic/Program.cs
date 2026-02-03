using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Buffering;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Log = GlobalLogBufferingBasic.Log;

var hostBuilder = Host.CreateApplicationBuilder();

hostBuilder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss";
    options.UseUtcTimestamp = true;
});

// Add the Global buffer to the logging pipeline.
hostBuilder.Logging.AddGlobalBuffer(LogLevel.Information);

using var app = hostBuilder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("BufferingDemo");
var buffer = app.Services.GetRequiredService<GlobalLogBuffer>();

for (int i = 1; i < 21; i++)
{
    try
    {
        Log.InformationMessage(logger);

        if(i % 10 == 0)
        {
           throw new Exception("Simulated exception");
        }
    }
    catch (Exception ex)
    {
        Log.ErrorMessage(logger, ex.Message);
        buffer.Flush();
    }

    await Task.Delay(1000).ConfigureAwait(false);
}
