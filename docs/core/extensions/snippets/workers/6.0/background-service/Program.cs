using App.WorkerService;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    });

IHost host = builder.Build();
host.Run();
