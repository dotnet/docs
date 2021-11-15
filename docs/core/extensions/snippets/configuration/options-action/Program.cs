using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Options.Action;

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
                        // User defined option values
                        // options.SomePropertyValue = ...
                });
            });
}
