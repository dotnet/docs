using ExampleLibrary.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
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

static void WriteSupportOptions(SupportOptions support)
{
    Console.WriteLine();
    Console.WriteLine("Support options:");
    Console.WriteLine("  URL: {0}", support.Url);
    Console.WriteLine("  Email: {0}", support.Email);
    Console.WriteLine("  Phone number: {0}", support.PhoneNumber);
    Console.WriteLine();
}
