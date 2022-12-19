using BroadcastChannel.GrainInterfaces;
using BroadcastChannel.Silo.Options;
using BroadcastChannel.Silo.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleans((context, silo) =>
    {
        silo.Services.AddOptions<AlphaVantageOptions>()
            .Bind(context.Configuration.GetSection(nameof(AlphaVantageOptions)));
        silo.Services.AddTransient<StockClient>();
        silo.Services.AddHttpClient<StockClient>(client =>
        {
            client.BaseAddress = new("https://www.alphavantage.co/");
        });
        silo.Services.AddHostedService<StockWorker>();
        silo.UseLocalhostClustering();
        silo.AddBroadcastChannel(
            ChannelNames.LiveStockTicker,
            options => options.FireAndForgetDelivery = false);
    })
    .Build();

await host.RunAsync();
