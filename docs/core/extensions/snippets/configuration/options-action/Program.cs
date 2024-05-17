using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMyLibraryService(options =>
{
    // User defined option values
    // options.SomePropertyValue = ...
});
                                                                        
using IHost host = builder.Build();

// Application code should start here.

await host.RunAsync();
