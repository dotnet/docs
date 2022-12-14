using BroadcastChannel.Silo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient<StockClient>(client =>
        {
            client.BaseAddress = new("https://www.alphavantage.co/");
        });
        services.AddTransient<StockClient>();
        services.AddHostedService<StockWorker>();
    })
    .UseOrleans(silo =>
    {
        silo.AddBroadcastChannel(
            "live-stock-ticker",
            options => options.FireAndForgetDelivery = false);
    })
    .Build();

await host.RunAsync();
