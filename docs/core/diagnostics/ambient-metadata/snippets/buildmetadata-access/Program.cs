using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Add build metadata to configuration and services
builder.Configuration.AddBuildMetadata();
builder.Services.AddBuildMetadata(builder.Configuration.GetSection("ambientmetadata:build"));

var host = builder.Build();

var metadata = host.Services.GetRequiredService<IOptions<BuildMetadata>>().Value;
Console.WriteLine($"Build ID: {metadata.BuildId}");
Console.WriteLine($"Build Number: {metadata.BuildNumber}");
Console.WriteLine($"Branch: {metadata.SourceBranchName}");
Console.WriteLine($"Commit: {metadata.SourceVersion}");

await host.RunAsync();
