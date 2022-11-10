using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddMyLibraryService(
            context.Configuration.GetSection("LibraryOptions"));
    })
    .Build();

// Application code should start here.

await host.RunAsync();
