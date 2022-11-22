using WorkerServiceOptions.Example;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddHostedService<Worker>()
            .AddTransient<PriorityQueue>())
    .Build();

host.Run();
