using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConsoleIni.Example;

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
            .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration.Sources.Clear();

                IHostEnvironment env = hostingContext.HostingEnvironment;

                configuration
                    .AddIniFile("appsettings.ini", optional: true, reloadOnChange: true)
                    .AddIniFile($"appsettings.{env.EnvironmentName}.ini", true, true);

                foreach ((string key, string value) in
                    configuration.Build().AsEnumerable().Where(t => t.Value is not null))
                {
                    Console.WriteLine($"{key}={value}");
                }
            });
    // <Output>
    // Sample output:
    //    TransientFaultHandlingOptions:Enabled=True
    //    TransientFaultHandlingOptions:AutoRetryDelay=00:00:07
    //    SecretKey=Secret key value
    //    Logging:LogLevel:Microsoft=Warning
    //    Logging:LogLevel:Default=Information
    // </Output>
}
