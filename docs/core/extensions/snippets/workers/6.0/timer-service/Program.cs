using App.TimerHostedService;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<TimerService>();
    });

IHost host = builder.Build();
host.Run();
