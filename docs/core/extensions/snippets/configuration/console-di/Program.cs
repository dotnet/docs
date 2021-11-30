// <Program>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConsoleDI.Example;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<ITransientOperation, DefaultOperation>()
            .AddScoped<IScopedOperation, DefaultOperation>()
            .AddSingleton<ISingletonOperation, DefaultOperation>()
            .AddTransient<OperationLogger>())
    .Build();

ExemplifyScoping(host.Services, "Scope 1");
ExemplifyScoping(host.Services, "Scope 2");

await host.RunAsync();

static void ExemplifyScoping(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    OperationLogger logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

    Console.WriteLine("...");

    logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

    Console.WriteLine();
}
// </Program>

// <Output>
// Sample output:
// Scope 1-Call 1 .GetRequiredService<OperationLogger>(): ITransientOperation [ 80f4...Always different        ]
// Scope 1-Call 1 .GetRequiredService<OperationLogger>(): IScopedOperation    [ c878...Changes only with scope ]
// Scope 1-Call 1 .GetRequiredService<OperationLogger>(): ISingletonOperation [ 1586...Always the same         ]
// ...
// Scope 1-Call 2 .GetRequiredService<OperationLogger>(): ITransientOperation [ f3c0...Always different        ]
// Scope 1-Call 2 .GetRequiredService<OperationLogger>(): IScopedOperation    [ c878...Changes only with scope ]
// Scope 1-Call 2 .GetRequiredService<OperationLogger>(): ISingletonOperation [ 1586...Always the same         ]
//
// Scope 2-Call 1 .GetRequiredService<OperationLogger>(): ITransientOperation [ f9af...Always different        ]
// Scope 2-Call 1 .GetRequiredService<OperationLogger>(): IScopedOperation    [ 2bd0...Changes only with scope ]
// Scope 2-Call 1 .GetRequiredService<OperationLogger>(): ISingletonOperation [ 1586...Always the same         ]
// ...
// Scope 2-Call 2 .GetRequiredService<OperationLogger>(): ITransientOperation [ fa65...Always different        ]
// Scope 2-Call 2 .GetRequiredService<OperationLogger>(): IScopedOperation    [ 2bd0...Changes only with scope ]
// Scope 2-Call 2 .GetRequiredService<OperationLogger>(): ISingletonOperation [ 1586...Always the same         ]
// </Output>
