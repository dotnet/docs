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

## Local development

For more information, see [Local development configuration](local-development-configuration.md).

:::zone target="docs" pivot="orleans-7-0,orleans-8-0,orleans-9-0,orleans-10-0"

## Reliable production deployment using Azure

For a reliable production deployment using Azure, use the Azure Table option for cluster membership. This configuration is typical for deployments to on-premises servers, containers, or Azure virtual machine instances.

### [Managed identity (recommended)](#tab/managed-identity)

Using <xref:Azure.Identity.DefaultAzureCredential> with a URI endpoint is the recommended approach for production environments. This pattern avoids storing secrets in configuration and leverages Azure managed identities for secure authentication.

Silo configuration:

```csharp
using Azure.Identity;

var endpoint = new Uri(configuration["AZURE_TABLE_STORAGE_ENDPOINT"]!);
var credential = new DefaultAzureCredential();

var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        })
        .UseAzureStorageClustering(options =>
        {
            options.ConfigureTableServiceClient(endpoint, credential);
        })
        .ConfigureEndpoints(siloPort: 11_111, gatewayPort: 30_000)
        .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
    })
    .Build();
```

Client configuration:

```csharp
using Azure.Identity;

var endpoint = new Uri(configuration["AZURE_TABLE_STORAGE_ENDPOINT"]!);
var credential = new DefaultAzureCredential();

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
        clientBuilder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        })
        .UseAzureStorageClustering(options =>
        {
            options.ConfigureTableServiceClient(endpoint, credential);
        }))
    .Build();
```

> [!NOTE]
> The `AZURE_TABLE_STORAGE_ENDPOINT` configuration value should be the Table Storage endpoint URL, such as `https://<storage-account-name>.table.core.windows.net`.

### [Connection string](#tab/connection-string)

Using a connection string is suitable for development scenarios or when managed identity isn't available.

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
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        })
        .UseAzureStorageClustering(
            options => options.ConfigureTableServiceClient(connectionString))
        .ConfigureEndpoints(siloPort: 11_111, gatewayPort: 30_000)
        .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
    })
    .Build();
```

Client configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
        clientBuilder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        })
        .UseAzureStorageClustering(
            options => options.ConfigureTableServiceClient(connectionString)))
    .Build();
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
    .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
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
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        })
        .UseAdoNetClustering(options =>
        {
          options.ConnectionString = connectionString;
          options.Invariant = "Microsoft.Data.SqlClient"; // Orleans 10.0+
        })
        .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)
        .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
    })
    .Build();
```

### [Orleans 7.0-9.x](#tab/orleans-7)

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.Configure<ClusterOptions>(options =>
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
        .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
    })
    .Build();
```

---

Client configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
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
        }))
    .Build();
```

## Unreliable deployment on a cluster of dedicated servers

For testing on a cluster of dedicated servers where reliability isn't a concern, you can leverage `MembershipTableGrain` and avoid dependency on Azure Table. You just need to designate one of the nodes as primary.

On the silos:

```csharp
var primarySiloEndpoint = new IPEndPoint(PRIMARY_SILO_IP_ADDRESS, 11_111);
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder
            .UseDevelopmentClustering(primarySiloEndpoint)
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "Cluster42";
                options.ServiceId = "MyAwesomeService";
            })
            .ConfigureEndpoints(siloPort: 11_111, gatewayPort: 30_000)
            .ConfigureLogging(logging => logging.AddConsole())
    })
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

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
        clientBuilder.UseStaticClustering(gateways)
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "Cluster42";
                options.ServiceId = "MyAwesomeService";
            }))
    .Build();
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
    .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
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
