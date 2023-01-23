using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMyLibraryService("LibraryOptions");
    })
    .Build();

LibraryOptions options =
    host.Services
        .GetRequiredService<IOptions<LibraryOptions>>()
        .Value;

Console.WriteLine($"Support URL: {options.SupportUrl}");
Console.WriteLine($"Support Email: {options.SupportEmail}");
Console.WriteLine($"Support Phone: {options.SupportPhoneNumber}");

await host.RunAsync();
