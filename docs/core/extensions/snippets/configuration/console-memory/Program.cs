using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((_, configuration) =>
        configuration.AddInMemoryCollection(
            new Dictionary<string, string>
            {
                ["SecretKey"] = "Dictionary MyKey Value",
                ["TransientFaultHandlingOptions:Enabled"] = bool.TrueString,
                ["TransientFaultHandlingOptions:AutoRetryDelay"] = "00:00:07",
                ["Logging:LogLevel:Default"] = "Warning"
            }))
    .Build();

// Application code should start here.

await host.RunAsync();
