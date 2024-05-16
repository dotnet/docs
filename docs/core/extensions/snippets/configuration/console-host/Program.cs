using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Environment.ContentRootPath = Directory.GetCurrentDirectory();
builder.Configuration.AddJsonFile("hostsettings.json", optional: true);
builder.Configuration.AddEnvironmentVariables(prefix: "PREFIX_");
builder.Configuration.AddCommandLine(args);

using IHost host = builder.Build();

// Application code should start here.

await host.RunAsync();
