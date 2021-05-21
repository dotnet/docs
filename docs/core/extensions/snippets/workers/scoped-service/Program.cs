using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using App.ScopedService;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ScopedBackgroudService>();
        services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();
    })
    .Build();

await host.RunAsync();
