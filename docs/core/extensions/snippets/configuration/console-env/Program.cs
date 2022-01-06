using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
        configuration.AddEnvironmentVariables(
            prefix: "CustomPrefix_"))
    .Build();

// Application code should start here.

await host.RunAsync();
