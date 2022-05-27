using WorkerScope.Example;

using var host =
    Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (_, services) =>
                services.AddHostedService<Worker>()
                    .AddScoped<IObjectIdProvider, AutoIncrementingIdProvider>()
                    .AddScoped<IObjectRelay, ObjectWorkerService>()
                    .AddScoped<IObjectStore, ObjectWorkerService>()
                    .AddScoped<IObjectProcessor, ObjectWorkerService>())
        .Build();

await host.RunAsync();
