using App.TimerHostedService;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<TimerService>();
    })
    .Build();

await host.RunAsync();
