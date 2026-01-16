using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Register build metadata (automatically captures from environment variables)
builder.Services.AddBuildMetadata(builder.Configuration.GetSection("BuildMetadata"));

var host = builder.Build();
await host.RunAsync();
