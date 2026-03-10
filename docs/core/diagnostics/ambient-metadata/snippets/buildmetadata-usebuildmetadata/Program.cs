using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.AmbientMetadata;

var builder = Host.CreateApplicationBuilder(args);

builder.UseBuildMetadata();

var host = builder.Build();
await host.RunAsync();
