using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Orleans.BroadcastChannel;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.AddBroadcastChannel(
            "live-stock-ticker",
            options => options.FireAndForgetDelivery = false);
    })
    .Build();

var provider =
    host.Services.GetRequiredService<IBroadcastChannelProvider>();

var channelId = ChannelId.Create("live-stock-ticker", Guid.Empty);
provider.GetChannelWriter<string>(channelId);

await host.RunAsync();
