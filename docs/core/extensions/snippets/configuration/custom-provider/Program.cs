using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CustomProvider.Example
{
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
                {
                    configuration.Sources.Clear();

                    configuration.AddEntityConfiguration(
                        options => options.UseInMemoryDatabase("InMemoryDb"));

                    foreach ((string key, string value) in
                        configuration.Build().AsEnumerable().Where(t => t.Value is not null))
                    {
                        Console.WriteLine($"{key}={value}");
                    }
                });
        // Sample output:
        //    WidgetRoute=api/widgets
        //    EndpointId=b3da3c4c-9c4e-4411-bc4d-609e2dcc5c67
        //    DisplayLabel=Widgets Incorporated, LLC.
    }
}
