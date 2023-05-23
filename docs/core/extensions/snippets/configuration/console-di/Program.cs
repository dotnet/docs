// <Program>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConsoleDI.Example;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IExampleTransientService, ExampleTransientService>();
        services.AddScoped<IExampleScopedService, ExampleScopedService>();
        services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
        services.AddTransient<ServiceLifetimeReporter>();
    })
    .Build();

ExemplifyServiceLifetime(host.Services, "Lifetime 1");
ExemplifyServiceLifetime(host.Services, "Lifetime 2");

await host.RunAsync();

static void ExemplifyServiceLifetime(IServiceProvider hostProvider, string lifetime)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    ServiceLifetimeReporter logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails(
        $"{lifetime}: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()");

    Console.WriteLine("...");

    logger = provider.GetRequiredService<ServiceLifetimeReporter>();
    logger.ReportServiceLifetimeDetails(
        $"{lifetime}: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()");

    Console.WriteLine();
}
// </Program>

// <Output>
// Sample output:
// Lifetime 1: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()
//     IExampleTransientService: d08a27fa-87d2-4a06-98d7-2773af886125 (Always different)
//     IExampleScopedService: 402c83c9-b4ed-4be1-b78c-86be1b1d908d (Changes only with lifetime)
//     IExampleSingletonService: a61f1ff4-0b14-4508-bd41-21d852484a7b (Always the same)
// ...
// Lifetime 1: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()
//     IExampleTransientService: b43d68fb-2c7b-4a9b-8f02-fc507c164326 (Always different)
//     IExampleScopedService: 402c83c9-b4ed-4be1-b78c-86be1b1d908d (Changes only with lifetime)
//     IExampleSingletonService: a61f1ff4-0b14-4508-bd41-21d852484a7b (Always the same)
// 
// Lifetime 2: Call 1 to provider.GetRequiredService<ServiceLifetimeReporter>()
//     IExampleTransientService: f3856b59-ab3f-4bbd-876f-7bab0013d392 (Always different)
//     IExampleScopedService: bba80089-1157-4041-936d-e96d81dd9d1c (Changes only with lifetime)
//     IExampleSingletonService: a61f1ff4-0b14-4508-bd41-21d852484a7b (Always the same)
// ...
// Lifetime 2: Call 2 to provider.GetRequiredService<ServiceLifetimeReporter>()
//     IExampleTransientService: a8015c6a-08cd-4799-9ec3-2f2af9cbbfd2 (Always different)
//     IExampleScopedService: bba80089-1157-4041-936d-e96d81dd9d1c (Changes only with lifetime)
//     IExampleSingletonService: a61f1ff4-0b14-4508-bd41-21d852484a7b (Always the same)
// </Output>
