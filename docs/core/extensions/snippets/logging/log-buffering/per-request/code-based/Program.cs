using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss:fff";
    options.UseUtcTimestamp = true;
});
builder.Logging.AddPerIncomingRequestBuffer(options =>
{
    options.AutoFlushDuration = TimeSpan.FromSeconds(5);
    options.Rules.Add(new Microsoft.Extensions.Diagnostics.Buffering.LogBufferingFilterRule("PerRequestLogBufferingCodeBased.*", LogLevel.Information));
});

var app = builder.Build();
app.MapControllers();
var serverTask = app.RunAsync();

using var httpClient = new HttpClient();
var baseUrl = "http://localhost:5000";
httpClient.BaseAddress = new Uri(baseUrl);

var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Client");
logger.LogInformation("Starting to send requests to the controller...");

for (var i = 1; i < 21; i++)
{
    _ = await httpClient.GetAsync($"home/index/{i}").ConfigureAwait(false);

    await Task.Delay(1000).ConfigureAwait(false);
}

logger.LogInformation("All requests completed");
