using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleDisposable.Example;

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        ExemplifyDisposableScoping(host.Services, "Scope 1");
        Console.WriteLine();

        ExemplifyDisposableScoping(host.Services, "Scope 2");
        Console.WriteLine();

        await host.RunAsync();
    }

// <Output>
    // Sample output:
    //     Scope 1...
    //     ScopedDisposable.Dispose()
    //     TransientDisposable.Dispose()

    //     Scope 2...
    //     ScopedDisposable.Dispose()
    //     TransientDisposable.Dispose()

    //     info: Microsoft.Hosting.Lifetime[0]
    //           Application started.Press Ctrl+C to shut down.
    //     info: Microsoft.Hosting.Lifetime[0]
    //          Hosting environment: Production
    //     info: Microsoft.Hosting.Lifetime[0]
    //          Content root path: .\configuration\console-di-disposable\bin\Debug\net5.0
    //     info: Microsoft.Hosting.Lifetime[0]
    //          Application is shutting down...
    //     SingletonDisposable.Dispose()
// </Output>

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services.AddTransient<TransientDisposable>()
                        .AddScoped<ScopedDisposable>()
                        .AddSingleton<SingletonDisposable>());

    static void ExemplifyDisposableScoping(IServiceProvider services, string scope)
    {
        Console.WriteLine($"{scope}...");

        using IServiceScope serviceScope = services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;

        _ = provider.GetRequiredService<TransientDisposable>();
        _ = provider.GetRequiredService<ScopedDisposable>();
        _ = provider.GetRequiredService<SingletonDisposable>();
    }
}
