using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Register build metadata with custom values
builder.Services.AddBuildMetadata(metadata =>
{
    metadata.BuildId = "12345";
    metadata.BuildNumber = "1.0.0-local.1";
    metadata.SourceBranchName = "main";
    metadata.SourceVersion = "a1b2c3d4e5f6";
});

var host = builder.Build();
await host.RunAsync();
