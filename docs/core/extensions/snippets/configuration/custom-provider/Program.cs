using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using CustomProvider.Example;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.Sources.Clear();
builder.Configuration.AddEntityConfiguration();
builder.Services.Configure<WidgetOptions>(
    builder.Configuration.GetSection("WidgetOptions"));

using IHost host = builder.Build();

WidgetOptions options = host.Services.GetRequiredService<IOptions<WidgetOptions>>().Value;
Console.WriteLine($"DisplayLabel={options.DisplayLabel}");
Console.WriteLine($"EndpointId={options.EndpointId}");
Console.WriteLine($"WidgetRoute={options.WidgetRoute}");

await host.RunAsync();
// Sample output:
//    WidgetRoute=api/widgets
//    EndpointId=b3da3c4c-9c4e-4411-bc4d-609e2dcc5c67
//    DisplayLabel=Widgets Incorporated, LLC.
