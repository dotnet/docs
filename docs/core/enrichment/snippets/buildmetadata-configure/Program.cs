using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Add build metadata to configuration and services (two-step approach)
// Alternatively, you can use: builder.UseBuildMetadata(); which combines both steps
builder.Configuration.AddBuildMetadata();
builder.Services.AddBuildMetadata(builder.Configuration.GetSection("ambientmetadata:build"));

var host = builder.Build();
await host.RunAsync();
