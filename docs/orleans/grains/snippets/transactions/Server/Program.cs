using Orleans.Hosting;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder()
    .UseOrleans((_, silo) => 
        silo.UseLocalhostClustering()
            .AddMemoryGrainStorageAsDefault()
            .UseTransactions())
    .RunConsoleAsync();
