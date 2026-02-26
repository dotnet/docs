using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);

// Add build metadata to configuration and services
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddBuildMetadata(builder.Configuration.GetSection("ambientmetadata:build"));

// Register application service
builder.Services.AddSingleton<ApplicationService>();

var host = builder.Build();

// Use build metadata
var appService = host.Services.GetRequiredService<ApplicationService>();
appService.Start();

await host.RunAsync();

public class ApplicationService(
    ILogger<ApplicationService> logger,
    IOptions<BuildMetadata> buildMetadata)
{
    private readonly ILogger<ApplicationService> _logger = logger;
    private readonly BuildMetadata _buildMetadata = buildMetadata.Value;

    public void Start()
    {
        _logger.LogInformation(
            "Application started - Build: {BuildNumber}, Branch: {Branch}, Commit: {Commit}",
            _buildMetadata.BuildNumber,
            _buildMetadata.SourceBranchName,
            _buildMetadata.SourceVersion?[..7]);
    }
}
