using App.ScopedService;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ScopedBackgroundService>();
        services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();
    });

IHost host = builder.Build();
host.Run();
