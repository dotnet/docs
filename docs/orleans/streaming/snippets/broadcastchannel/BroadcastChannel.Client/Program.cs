using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BroadcastChannel.GrainInterfaces;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
        client.AddBroadcastChannel(
            ChannelNames.LiveStockTicker,
            options => options.FireAndForgetDelivery = false);
    })
    .UseConsoleLifetime()
    .Build();

var client = host.Services.GetRequiredService<IClusterClient>();
var liveStocks = client.GetGrain<ILiveStockGrain>(Guid.Empty);

foreach (var symbol in Enum.GetValues<StockSymbol>())
{
    var stock = await liveStocks.GetStock(symbol);
    Console.WriteLine($"{symbol}: {stock.GlobalQuote.Price:C}");
}

await host.RunAsync();
