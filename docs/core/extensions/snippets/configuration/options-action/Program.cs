using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMyLibraryService(options =>
        {
            // User defined option values
            // options.SomePropertyValue = ...
        });
    })
    .Build();

// Application code should start here.

await host.RunAsync();
