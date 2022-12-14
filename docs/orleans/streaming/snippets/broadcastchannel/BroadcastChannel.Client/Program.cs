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
var provider = client.GetBroadcastChannelProvider(name);
var channelId = ChannelId.Create(name, Guid.Empty);
provider.GetChannelWriter<string>(channelId);

await host.RunAsync();
