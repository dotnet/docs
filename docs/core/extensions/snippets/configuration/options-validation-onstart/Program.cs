using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(static services =>
    {
        services.AddMyLibraryService("Support");
    })
    .Build();

IOptionsMonitor<SupportOptions> options = host.Services
        .GetRequiredService<IOptionsMonitor<SupportOptions>>();

WriteSupportOptions(options.CurrentValue);

using (options.OnChange(
    listener: static (SupportOptions changedSupportOptions, string? _) =>
        WriteSupportOptions(changedSupportOptions)))
{
    // While this is running, update the appsettings.json file in the Debug folder.
    await host.RunAsync();
}

static void WriteSupportOptions(SupportOptions support) =>
    Console.WriteLine($"""
        
        Support options:
          URL: {support.Url}
          Email: {support.Email}
          Phone number: {support.PhoneNumber}
        
        """);
