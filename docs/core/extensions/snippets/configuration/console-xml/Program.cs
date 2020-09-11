using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConsoleXml.Example
{
    class Program
    {
        static Task Main(string[] args) =>
            CreateHostBuilder(args).Build().RunAsync();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    IHostEnvironment env = hostingContext.HostingEnvironment;

                    configuration
                        .AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true)
                        .AddXmlFile($"appsettings.{env.EnvironmentName}.xml", true, true);

                    foreach ((string key, string value) in
                        configuration.Build().AsEnumerable().Where(t => t.Value is not null))
                    {
                        Console.WriteLine($"{key}={value}");
                    }
                });
        // Sample output:
        //    TransientFaultHandlingOptions:Enabled=True
        //    TransientFaultHandlingOptions:AutoRetryDelay=00:00:07
        //    SecretKey=Secret key value
        //    Logging:LogLevel:Microsoft=Warning
        //    Logging:LogLevel:Default=Information
    }
}
