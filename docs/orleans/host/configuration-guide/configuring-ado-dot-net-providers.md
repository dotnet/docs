---
title: Configure ADO.NET providers
description: Learn how to configure ADO.NET providers in .NET Orleans.
ms.date: 05/23/2025
ms.topic: how-to
---

# Configure ADO.NET providers

Any reliable deployment of Orleans requires persistent storage to keep system state, specifically the Orleans cluster membership table and reminders. One available option is using a SQL database via ADO.NET providers.

To use ADO.NET for persistence, clustering, or reminders, you need to configure the ADO.NET providers as part of the silo configuration and, for clustering, also as part of the client configurations.

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

Set the `ConnectionString` to a valid ADO.NET Server connection string.

To use ADO.NET providers for persistence, reminders, or clustering, you need scripts to create database artifacts. All servers hosting Orleans silos must have access to the database defined by these scripts. You can find scripts for popular providers in [ADO.NET Database configuration](adonet-configuration.md). Lack of access to the target database is a common mistake developers make.

You also need to install the `*.AdoNet` NuGet package for the features you configure. We split ADO.NET NuGets into per-feature packages:

- `Microsoft.Orleans.Clustering.AdoNet`: for clustering.
- `Microsoft.Orleans.Persistence.AdoNet`: for persistence.
- `Microsoft.Orleans.Reminders.AdoNet`: for reminders.
