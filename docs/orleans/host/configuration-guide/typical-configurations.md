---
title: Typical configurations
description: Learn about typical configurations in .NET Orleans.
ms.date: 01/21/2026
ms.topic: reference
zone_pivot_groups: orleans-version
ms.custom: sfi-ropc-nochange
---

# Typical configurations

Below are examples of typical configurations you can use for development and production deployments.

:::zone target="docs" pivot="orleans-8-0,orleans-9-0,orleans-10-0"

## Recommended: .NET Aspire configuration

[.NET Aspire](../aspire-integration.md) is the recommended approach for configuring Orleans applications. Aspire provides declarative resource management, automatic service discovery, built-in observability, and simplified deployment—eliminating most manual configuration.

### Production configuration with Redis

This configuration uses Redis for clustering, grain storage, and reminders with multiple silo replicas:

**AppHost project (Program.cs):**

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(redis)
    .WithGrainStorage("Default", redis)
    .WithReminders(redis);

// Add Orleans silo with 3 replicas for production
builder.AddProject<Projects.MySilo>("silo")
    .WithReference(orleans)
    .WithReference(redis)
    .WithReplicas(3);

// Add a separate client project (e.g., an API)
builder.AddProject<Projects.MyApi>("api")
    .WithReference(orleans.AsClient())
    .WithReference(redis);

builder.Build().Run();
```

**Silo project (Program.cs):**

```csharp
var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddKeyedRedisClient("redis");
builder.UseOrleans();

builder.Build().Run();
```

**Client project (Program.cs):**

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddKeyedRedisClient("redis");
builder.UseOrleansClient();

var app = builder.Build();
// ... configure API endpoints
app.Run();
```

> [!TIP]
> Use `WithReplicas(n)` to run multiple silo instances for high availability. Use `orleans.AsClient()` when a project only needs to call grains, not host them.

### Production configuration with Azure Storage

This configuration uses Azure Table Storage for clustering and Azure Blob Storage for grain storage:

**AppHost project (Program.cs):**

```csharp
var builder = DistributedApplication.CreateBuilder(args);

var storage = builder.AddAzureStorage("storage");
var tables = storage.AddTables("clustering");
var blobs = storage.AddBlobs("grainstate");

var orleans = builder.AddOrleans("cluster")
    .WithClustering(tables)
    .WithGrainStorage("Default", blobs);

builder.AddProject<Projects.MySilo>("silo")
    .WithReference(orleans)
    .WithReference(tables)
    .WithReference(blobs)
    .WithReplicas(3);

builder.Build().Run();
```

**Silo project (Program.cs):**

```csharp
var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddKeyedAzureTableServiceClient("clustering");
builder.AddKeyedAzureBlobServiceClient("grainstate");
builder.UseOrleans();

builder.Build().Run();
```

> [!TIP]
> During local development, Aspire automatically uses the Azurite emulator for Azure Storage. In production deployments, Aspire connects to your real Azure Storage account based on your Azure deployment configuration.

> [!IMPORTANT]
> You must call the appropriate `AddKeyed*` method (such as `AddKeyedRedisClient`, `AddKeyedAzureTableServiceClient`, or `AddKeyedAzureBlobServiceClient`) to register the backing resource in the dependency injection container. Orleans providers look up resources by their keyed service name—if you skip this step, Orleans won't be able to resolve the resource and will throw a dependency resolution error at runtime.

For comprehensive documentation on Orleans and .NET Aspire integration, see [Orleans and .NET Aspire integration](../aspire-integration.md).

:::zone-end

## Local development

For more information, see [Local development configuration](local-development-configuration.md).

:::zone target="docs" pivot="orleans-8-0,orleans-9-0,orleans-10-0"

## Traditional configurations (without Aspire)

The following sections describe traditional Orleans configurations that don't use .NET Aspire. These are useful when Aspire isn't available or when you need fine-grained control over Orleans configuration.

:::zone-end

:::zone target="docs" pivot="orleans-7-0,orleans-8-0,orleans-9-0,orleans-10-0"

## Reliable production deployment using Azure

For a reliable production deployment using Azure, use the Azure Table option for cluster membership. This configuration is typical for deployments to on-premises servers, containers, or Azure virtual machine instances.

### [Managed identity (recommended)](#tab/managed-identity)

Using a `TokenCredential` with a URI endpoint is the recommended approach for production environments. This pattern avoids storing secrets in configuration and leverages Azure managed identities for secure authentication.

[!INCLUDE [credential-chain-guidance](../../includes/credential-chain-guidance.md)]

Silo configuration:

```csharp
using Azure.Identity;

var endpoint = new Uri(configuration["AZURE_TABLE_STORAGE_ENDPOINT"]!);
var credential = new ManagedIdentityCredential();

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleans(siloBuilder =>
{
    siloBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAzureStorageClustering(options =>
    {
        options.ConfigureTableServiceClient(endpoint, credential);
    })
    .ConfigureEndpoints(siloPort: 11_111, gatewayPort: 30_000);
});

builder.Logging.SetMinimumLevel(LogLevel.Information).AddConsole();

using var host = builder.Build();
```

Client configuration:

```csharp
using Azure.Identity;

var endpoint = new Uri(configuration["AZURE_TABLE_STORAGE_ENDPOINT"]!);
var credential = new ManagedIdentityCredential();

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAzureStorageClustering(options =>
    {
        options.ConfigureTableServiceClient(endpoint, credential);
    });
});

using var host = builder.Build();
```

> [!NOTE]
> The `AZURE_TABLE_STORAGE_ENDPOINT` configuration value should be the Table Storage endpoint URL, such as `https://<storage-account-name>.table.core.windows.net`.

### [Connection string](#tab/connection-string)

> [!WARNING]
> Connection strings contain secrets and should be avoided in production. Use managed identity whenever possible.

The format of the `DataConnection` string is a semicolon-separated list of `Key=Value` pairs. The following options are supported:

| Key                        | Value                               |
|----------------------------|-------------------------------------|
| `DefaultEndpointsProtocol` | `https`                             |
| `AccountName`              | `<Azure storage account>`           |
| `AccountKey`               | `<Azure table storage account key>` |

The following is an example of a `DataConnection` string for Azure Table storage:

```
"DefaultEndpointsProtocol=https;AccountName=<Azure storage account>;AccountKey=<Azure table storage account key>"
```

Silo configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleans(siloBuilder =>
{
    siloBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAzureStorageClustering(
        options => options.ConfigureTableServiceClient(connectionString))
    .ConfigureEndpoints(siloPort: 11_111, gatewayPort: 30_000);
});

builder.Logging.SetMinimumLevel(LogLevel.Information).AddConsole();

using var host = builder.Build();
```

Client configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAzureStorageClustering(
        options => options.ConfigureTableServiceClient(connectionString));
});

using var host = builder.Build();
```

---

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

## Reliable production deployment using Azure

For a reliable production deployment using Azure, use the Azure Table option for cluster membership. This configuration is typical for deployments to on-premises servers, containers, or Azure virtual machine instances.

The format of the `DataConnection` string is a semicolon-separated list of `Key=Value` pairs. The following options are supported:

| Key                        | Value                               |
|----------------------------|-------------------------------------|
| `DefaultEndpointsProtocol` | `https`                             |
| `AccountName`              | `<Azure storage account>`           |
| `AccountKey`               | `<Azure table storage account key>` |

The following is an example of a `DataConnection` string for Azure Table storage:

```
"DefaultEndpointsProtocol=https;AccountName=<Azure storage account>;AccountKey=<Azure table storage account key>"
```

Silo configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";
var silo = new SiloHostBuilder()
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAzureStorageClustering(
        options => options.ConnectionString = connectionString)
    .ConfigureEndpoints(siloPort: 11_111, gatewayPort: 30_000)
    .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Information).AddConsole())
    .Build();
```

Client configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

var client = new ClientBuilder()
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAzureStorageClustering(
        options => options.ConnectionString = connectionString)
    .Build();
```

:::zone-end

:::zone target="docs" pivot="orleans-7-0,orleans-8-0,orleans-9-0,orleans-10-0"

## Reliable production deployment using SQL Server

For a reliable production deployment using SQL Server, supply a SQL Server connection string.

> [!NOTE]
> Starting with Orleans 10.0, ADO.NET providers require the `Microsoft.Data.SqlClient` package instead of `System.Data.SqlClient`. Use the invariant `Microsoft.Data.SqlClient` in Orleans 10.0 and later.

### [Orleans 10.0+](#tab/orleans-10)

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleans(siloBuilder =>
{
    siloBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAdoNetClustering(options =>
    {
        options.ConnectionString = connectionString;
        options.Invariant = "Microsoft.Data.SqlClient"; // Orleans 10.0+
    })
    .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000);
});

builder.Logging.SetMinimumLevel(LogLevel.Information).AddConsole();

using var host = builder.Build();
```

### [Orleans 7.0-9.x](#tab/orleans-7)

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleans(siloBuilder =>
{
    siloBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAdoNetClustering(options =>
    {
        options.ConnectionString = connectionString;
        options.Invariant = "System.Data.SqlClient";
    })
    .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000);
});

builder.Logging.SetMinimumLevel(LogLevel.Information).AddConsole();

using var host = builder.Build();
```

---

Client configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder.Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAdoNetClustering(options =>
    {
        options.ConnectionString = connectionString;
        // Use "Microsoft.Data.SqlClient" for Orleans 10.0+
        // Use "System.Data.SqlClient" for Orleans 7.0-9.x
        options.Invariant = "Microsoft.Data.SqlClient";
    });
});

using var host = builder.Build();
```

## Unreliable deployment on a cluster of dedicated servers

For testing on a cluster of dedicated servers where reliability isn't a concern, you can leverage `MembershipTableGrain` and avoid dependency on Azure Table. You just need to designate one of the nodes as primary.

On the silos:

```csharp
var primarySiloEndpoint = new IPEndPoint(PRIMARY_SILO_IP_ADDRESS, 11_111);

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleans(siloBuilder =>
{
    siloBuilder
        .UseDevelopmentClustering(primarySiloEndpoint)
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        })
        .ConfigureEndpoints(siloPort: 11_111, gatewayPort: 30_000);
});
builder.Logging.AddConsole();

using var host = builder.Build();
await host.RunAsync();
```

On the clients:

```csharp
var gateways = new IPEndPoint[]
{
    new IPEndPoint(PRIMARY_SILO_IP_ADDRESS, 30_000),
    new IPEndPoint(OTHER_SILO__IP_ADDRESS_1, 30_000),
    // ...
    new IPEndPoint(OTHER_SILO__IP_ADDRESS_N, 30_000),
};

var builder = Host.CreateApplicationBuilder(args);
builder.UseOrleansClient(clientBuilder =>
{
    clientBuilder.UseStaticClustering(gateways)
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        });
});

using var host = builder.Build();
await host.StartAsync();
```

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

## Reliable production deployment using SQL Server

For a reliable production deployment using SQL Server, supply a SQL Server connection string.

Silo configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";
var silo = new SiloHostBuilder()
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAdoNetClustering(options =>
    {
      options.ConnectionString = connectionString;
      options.Invariant = "System.Data.SqlClient";
    })
    .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)
    .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Information).AddConsole())
    .Build();
```

Client configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

var client = new ClientBuilder()
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .UseAdoNetClustering(options =>
    {
      options.ConnectionString = connectionString;
      options.Invariant = "System.Data.SqlClient";
    })
    .Build();
```

## Unreliable deployment on a cluster of dedicated servers

For testing on a cluster of dedicated servers where reliability isn't a concern, you can leverage `MembershipTableGrain` and avoid dependency on Azure Table. You just need to designate one of the nodes as primary.

On the silos:

```csharp
var primarySiloEndpoint = new IPEndPoint(PRIMARY_SILO_IP_ADDRESS, 11_111);
var silo = new SiloHostBuilder()
    .UseDevelopmentClustering(primarySiloEndpoint)
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .ConfigureEndpoints(siloPort: 11_111, gatewayPort: 30_000)
    .ConfigureLogging(logging => logging.AddConsole())
    .Build();
```

On the clients:

```csharp
var gateways = new IPEndPoint[]
{
    new IPEndPoint(PRIMARY_SILO_IP_ADDRESS, 30_000),
    new IPEndPoint(OTHER_SILO__IP_ADDRESS_1, 30_000),
    // ...
    new IPEndPoint(OTHER_SILO__IP_ADDRESS_N, 30_000),
};

var client = new ClientBuilder()
    .UseStaticClustering(gateways)
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .Build();
```

:::zone-end
