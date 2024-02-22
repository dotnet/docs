using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMyLibraryService(
    builder.Configuration.GetSection("LibraryOptions"));

using IHost host = builder.Build();

// Application code should start here.

await host.RunAsync();
