using WorkerService.Example;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddHostedService<Worker>())
    .Build()
    .RunAsync();
