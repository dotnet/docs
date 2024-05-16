using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Configuration.Sources.Clear();

IHostEnvironment env = builder.Environment;

builder.Configuration
    .AddIniFile("appsettings.ini", optional: true, reloadOnChange: true)
    .AddIniFile($"appsettings.{env.EnvironmentName}.ini", true, true);

foreach ((string key, string? value) in
    builder.Configuration.AsEnumerable().Where(t => t.Value is not null))
{
    Console.WriteLine($"{key}={value}");
}

using IHost host = builder.Build();

// Application code should start here.

await host.RunAsync();

// <Output>
// Sample output:
//    TransientFaultHandlingOptions:Enabled=True
//    TransientFaultHandlingOptions:AutoRetryDelay=00:00:07
//    SecretKey=Secret key value
//    Logging:LogLevel:Microsoft=Warning
//    Logging:LogLevel:Default=Information
// </Output>
