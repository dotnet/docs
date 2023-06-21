using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ConsoleJson.Example;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.Sources.Clear();

IHostEnvironment env = builder.Environment;

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

IConfigurationRoot configurationRoot = builder.Configuration;

TransientFaultHandlingOptions options = new();
configurationRoot.GetSection(nameof(TransientFaultHandlingOptions))
    .Bind(options);

Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");

using IHost host = builder.Build();

// Application code should start here.

await host.RunAsync();

// <Output>
// Sample output:
//    TransientFaultHandlingOptions.Enabled=True
//    TransientFaultHandlingOptions.AutoRetryDelay=00:00:07
// </Output>
