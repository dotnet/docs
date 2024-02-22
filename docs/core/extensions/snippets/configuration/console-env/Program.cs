using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddEnvironmentVariables(prefix: "CustomPrefix_");

using IHost host = builder.Build();

// Application code should start here.

await host.RunAsync();
