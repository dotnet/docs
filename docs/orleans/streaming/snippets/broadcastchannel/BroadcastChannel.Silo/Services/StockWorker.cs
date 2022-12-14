using System.Diagnostics;
using BroadcastChannel.Grains;
using Microsoft.Extensions.Hosting;
using Orleans.BroadcastChannel;
using Orleans.Runtime;

namespace BroadcastChannel.Silo.Services;

internal sealed class StockWorker : BackgroundService
{
    private readonly StockClient _client;
    private readonly IBroadcastChannelProvider _provider;
    private readonly List<string> _symbols =
        new() { "MSFT", "GOOG", "AAPL", "AMZN", "TSLA" };

    public StockWorker(StockClient client, IServiceProvider provider)
    {
        _client = client;
        _provider =
            provider.GetRequiredServiceByName<IBroadcastChannelProvider>(
                "live-stock-ticker");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Capture the starting timestamp.
            var startingTimetstamp = Stopwatch.GetTimestamp();

            // Get all updated stock values.
            var stocks = await Task.WhenAll(
                tasks: _symbols.Select(selector: _client.GetStockAsync));

            // Get the live stock ticker broadcast channel.
            var channelId = ChannelId.Create("live-stock-ticker", Guid.Empty);
            var channelWriter = _provider.GetChannelWriter<Stock>(channelId);

            // Broadcast all stock updates on this channel.
            await Task.WhenAll(stocks.Select(channelWriter.Publish));

            // Use the elapsed time to calculate a 15 second delay.
            var elapsed = Stopwatch.GetElapsedTime(startingTimetstamp).Milliseconds;
            var remaining = Math.Max(0, 15_000 - elapsed);

            await Task.Delay(remaining, stoppingToken);
        }
    }
}
