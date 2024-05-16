await Host.CreateDefaultBuilder(args)
    .UseOrleans((_, silo) =>
    {
        silo.UseLocalhostClustering();

        if (Environment.GetEnvironmentVariable(
                "ORLEANS_STORAGE_CONNECTION_STRING") is { } connectionString)
        {
            silo.AddAzureTableTransactionalStateStorage(
                "TransactionStore", 
                options => options.ConfigureTableServiceClient(connectionString));
        }
        else
        {
            silo.AddMemoryGrainStorageAsDefault();
        }

        silo.UseTransactions();
    })
    .RunConsoleAsync();
