using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConsoleMemory.Example;

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        // Application code should start here.

        await host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, configuration) =>
                configuration.AddInMemoryCollection(
                    new Dictionary<string, string>
                    {
                        ["SecretKey"] = "Dictionary MyKey Value",
                        ["TransientFaultHandlingOptions:Enabled"] = bool.TrueString,
                        ["TransientFaultHandlingOptions:AutoRetryDelay"] = "00:00:07",
                        ["Logging:LogLevel:Default"] = "Warning"
                    }));
}
