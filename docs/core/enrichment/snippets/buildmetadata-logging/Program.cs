using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddBuildMetadata(builder.Configuration.GetSection("BuildMetadata"));
builder.Services.AddSingleton<LoggingService>();

var host = builder.Build();

var loggingService = host.Services.GetRequiredService<LoggingService>();
loggingService.LogWithBuildInfo();

await host.RunAsync();

public class LoggingService(
    ILogger<LoggingService> logger,
    IOptions<BuildMetadata> metadata)
{
    private readonly ILogger<LoggingService> _logger = logger;
    private readonly BuildMetadata _metadata = metadata.Value;

    public void LogWithBuildInfo()
    {
        _logger.LogInformation(
            "Processing request from build {BuildNumber} (commit: {Commit})",
            _metadata.BuildNumber,
            _metadata.SourceVersion?[..7]); // Short commit SHA
    }
}
