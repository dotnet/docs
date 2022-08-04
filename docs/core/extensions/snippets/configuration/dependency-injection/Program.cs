using DependencyInjection.Example;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(
    services =>
        services.AddHostedService<Worker>()
            .AddScoped<IMessageWriter, MessageWriter>());

var host = builder.Build();

host.Run();
