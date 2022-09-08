using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using CustomProvider.Example;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((_, configuration) =>
    {
        configuration.Sources.Clear();
        configuration.AddYamlFile("config.yaml", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
        services.Configure<WidgetOptions>(
            context.Configuration.GetSection("WidgetOptions")))
    .Build();

var options = host.Services.GetRequiredService<IOptions<WidgetOptions>>().Value;
Console.WriteLine($"DisplayLabel={options.DisplayLabel}");
Console.WriteLine($"EndpointId={options.EndpointId}");
Console.WriteLine($"WidgetRoute={options.WidgetRoute}");
Console.WriteLine($"IPAddressRange={string.Join(", ", options.IPAddressRange)}");
Console.WriteLine($"FeatureFlags.IsTelemetryEnabled={string.Join(", ", options.FeatureFlags.IsTelemetryEnabled)}");

await host.RunAsync();
// Sample output:
//     DisplayLabel=Widgets Incorporated, LLC.
//     EndpointId=b3da3c4c-9c4e-4411-bc4d-609e2dcc5c67
//     WidgetRoute=api/widgets
//     IPAddressRange=46.36.198.123, 46.36.198.124, 46.36.198.125
//     FeatureFlags.IsTelemetryEnabled=True
