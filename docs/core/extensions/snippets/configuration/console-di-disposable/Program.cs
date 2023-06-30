// <Program>
using ConsoleDisposable.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient<TransientDisposable>();
builder.Services.AddScoped<ScopedDisposable>();
builder.Services.AddSingleton<SingletonDisposable>();

using IHost host = builder.Build();

ExemplifyDisposableScoping(host.Services, "Scope 1");
Console.WriteLine();

ExemplifyDisposableScoping(host.Services, "Scope 2");
Console.WriteLine();

await host.RunAsync();

static void ExemplifyDisposableScoping(IServiceProvider services, string scope)
{
    Console.WriteLine($"{scope}...");

    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    _ = provider.GetRequiredService<TransientDisposable>();
    _ = provider.GetRequiredService<ScopedDisposable>();
    _ = provider.GetRequiredService<SingletonDisposable>();
}
// </Program>
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
//          Content root path: .\configuration\console-di-disposable\bin\Debug\net7.0
//     info: Microsoft.Hosting.Lifetime[0]
//          Application is shutting down...
//     SingletonDisposable.Dispose()
// </Output>
