using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Orleans.BroadcastChannel;

var name = "live-stock-ticker";

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.AddBroadcastChannel(
            name, options => options.FireAndForgetDelivery = false);
    })
    .Build();

var client = host.Services.GetRequiredService<IClusterClient>();

await host.RunAsync();
