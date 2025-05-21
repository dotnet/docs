---
title: Configure ADO.NET providers
description: Learn how to configure ADO.NET providers in .NET Orleans.
ms.date: 09/10/2024
ms.topic: how-to
---

# Configure ADO.NET providers

Any reliable deployment of Orleans requires using persistent storage to keep system state, specifically Orleans cluster membership table and reminders. One of the available options is using a SQL database via the ADO.NET providers.

To use ADO.NET for persistence, clustering, or reminders, one needs to configure the ADO.NET providers as part of the silo configuration, and, in the case of clustering, also as part of the client configurations.

The silo configuration code should look like this:

```csharp
var siloHostBuilder = new SiloHostBuilder();

var invariant = "System.Data.SqlClient";
var connectionString = "Data Source=(localdb)\MSSQLLocalDB;" +
    "Initial Catalog=Orleans;Integrated Security=True;" +
    "Pooling=False;Max Pool Size=200;" +
    "Asynchronous Processing=True;MultipleActiveResultSets=True";

// Use ADO.NET for clustering
siloHostBuilder.UseAdoNetClustering(options =>
{
    options.Invariant = invariant;
    options.ConnectionString = connectionString;
});
// Use ADO.NET for reminder service
siloHostBuilder.UseAdoNetReminderService(options =>
{
    options.Invariant = invariant;
    options.ConnectionString = connectionString;
});
// Use ADO.NET for persistence
siloHostBuilder.AddAdoNetGrainStorage("GrainStorageForTest", options =>
{
    options.Invariant = invariant;
    options.ConnectionString = connectionString;
});
```

The client configuration code should look like this:

```csharp
var siloHostBuilder = new SiloHostBuilder();

var invariant = "System.Data.SqlClient";
var connectionString = "Data Source=(localdb)\MSSQLLocalDB;" +
    "Initial Catalog=Orleans;Integrated Security=True;" +
    "Pooling=False;Max Pool Size=200;" +
    "Asynchronous Processing=True;MultipleActiveResultSets=True";

// Use ADO.NET for clustering
siloHostBuilder.UseAdoNetClustering(options =>
{
    options.Invariant = invariant;
    options.ConnectionString = connectionString;
});
```

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

Where the `ConnectionString` is set to a valid AdoNet Server connection string.

To use ADO.NET providers for persistence, reminders, or clustering, there are scripts for creating database artifacts, to which all servers that will be hosting Orleans silos need to have access. The scripts for popular providers can be found in [ADO.NET Configuration](adonet-configuration.md). Lack of access to the target database is a typical mistake we see developers making.

You also need to install `*.AdoNet` NuGet for features you configure. We split ADO.NET NuGets into per feature NuGets:

- `Microsoft.Orleans.Clustering.AdoNet`: for clustering.
- `Microsoft.Orleans.Persistence.AdoNet`: for persistence.
- `Microsoft.Orleans.Reminders.AdoNet`: for reminders.
