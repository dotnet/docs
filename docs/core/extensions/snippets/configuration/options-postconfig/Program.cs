using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Options.PostConfig;

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
            .ConfigureServices(services =>
            {
                services.AddMyLibraryService(options =>
                {
                        // Specify option values
                        // options.SomePropertyValue = ...
                });
            });
}
