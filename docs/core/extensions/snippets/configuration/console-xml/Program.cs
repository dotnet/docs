using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ConsoleXml.Example;

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

                configuration
                    .AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true)
                    .AddXmlFile("repeating-example.xml", optional: true, reloadOnChange: true);

                configuration.AddEnvironmentVariables();

                if (args is { Length: > 0 })
                {
                    configuration.AddCommandLine(args);
                }

                IConfigurationRoot configurationRoot = configuration.Build();

                string key00 = "section:section0:key:key0";
                string key01 = "section:section0:key:key1";
                string key10 = "section:section1:key:key0";
                string key11 = "section:section1:key:key1";

                string val00 = configurationRoot[key00];
                string val01 = configurationRoot[key01];
                string val10 = configurationRoot[key10];
                string val11 = configurationRoot[key11];

                Console.WriteLine($"{key00} = {val00}");
                Console.WriteLine($"{key01} = {val01}");
                Console.WriteLine($"{key10} = {val10}");
                Console.WriteLine($"{key10} = {val11}");
            });
    // <Output>
    // Sample output:
    //    section:section0:key:key0 = value 00
    //    section:section0:key:key1 = value 01
    //    section:section1:key:key0 = value 10
    //    section:section1:key:key0 = value 11
    // </Output>
}
