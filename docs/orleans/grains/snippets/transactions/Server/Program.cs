await Host.CreateDefaultBuilder()
    .UseOrleans((_, silo) => 
        silo.UseLocalhostClustering()
            .AddMemoryGrainStorageAsDefault()
            .UseTransactions())
    .RunConsoleAsync();
