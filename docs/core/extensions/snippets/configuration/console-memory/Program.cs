using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConsoleMemory.Example
{
    class Program
    {
        static Task Main(string[] args) =>
            CreateHostBuilder(args).Build().RunAsync();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                    configuration.AddInMemoryCollection(
                        new Dictionary<string, string>
                        {
                            ["SecretKey"] = "Dictionary MyKey Value",
                            ["TransientFaultHandlingOptions:Enabled"] = bool.TrueString,
                            ["TransientFaultHandlingOptions:AutoRetryDelay"] = "00:00:07",
                            ["Logging:LogLevel:Default"] = "Warning"
                        }));
    }
}
