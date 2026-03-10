using Microsoft.Extensions.AmbientMetadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddBuildMetadata();
builder.Services.AddBuildMetadata(builder.Configuration.GetSection("ambientmetadata:build"));

var host = builder.Build();
await host.RunAsync();
