---
title: Typical configurations
description: Learn about typical configurations in .NET Orleans.
ms.date: 05/23/2025
ms.topic: reference
---

# Typical configurations

Below are examples of typical configurations you can use for development and production deployments.

## Local development

For more information, see [Local development configuration](local-development-configuration.md).

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

## Reliable production deployment using SQL Server

For a reliable production deployment using SQL Server, supply a SQL Server connection string.

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
          options.Invariant = "System.Data.SqlClient";
        }))
    .Build();
```

## Unreliable deployment on a cluster of dedicated servers

For testing on a cluster of dedicated servers where reliability isn't a concern, you can leverage `MembershipTableGrain` and avoid dependency on Azure Table. You just need to designate one of the nodes as primary.

On the silos:

```csharp
var primarySiloEndpoint = new IPEndpoint(PRIMARY_SILO_IP_ADDRESS, 11_111);
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
