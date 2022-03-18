---
title: Typical configurations
description: Learn about typical configurations in .NET Orleans.
ms.date: 03/16/2022
---

# Typical configurations

Below are examples of typical configurations that can be used for development and production deployments.

## Local development

For more information, see [Local development configuration](local-development-configuration.md).

## Reliable production deployment using Azure

For a reliable production deployment using Azure, you need to use the Azure Table option for cluster membership. This configuration is typical of deployments to either on-premise servers, containers, or Azure virtual machine instances.

 The format of the `DataConnection` string is a `;` separated list of `Key=Value` pairs. The following options are supported:

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
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        })
        .UseAzureStorageClustering(options => options.ConnectionString = connectionString)
        .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)
        .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
    })
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
    .UseAzureStorageClustering(options => options.ConnectionString = connectionString)
    .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
    .Build();
```

## Reliable production deployment using SQL Server

For a reliable production deployment using SQL server, a SQL server connection string needs to be supplied.

Silo configuration:

```csharp
const string connectionString = "YOUR_CONNECTION_STRING_HERE";
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
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
    })
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
    .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
    .Build();
```

## Unreliable deployment on a cluster of dedicated servers

For testing on a cluster of dedicated servers when reliability isn't a concern you can leverage `MembershipTableGrain` and avoid dependency on Azure Table. You just need to designate one of the nodes as a primary.

On the silos:

```csharp
var primarySiloEndpoint = new IPEndpoint(PRIMARY_SILO_IP_ADDRESS, 11111);
var silo = new HostBuilder()
    .UseOrleans(builder =>
    {
        .UseDevelopmentClustering(primarySiloEndpoint)
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "Cluster42";
            options.ServiceId = "MyAwesomeService";
        })
        .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)
        .ConfigureLogging(logging => logging.AddConsole())
    })
    .Build();
```

On the clients:

```csharp
var gateways = new IPEndPoint[]
{
    new IPEndPoint(PRIMARY_SILO_IP_ADDRESS, 30000),
    new IPEndPoint(OTHER_SILO__IP_ADDRESS_1, 30000),
    // ...
    new IPEndPoint(OTHER_SILO__IP_ADDRESS_N, 30000),
};
var client = new ClientBuilder()
    .UseStaticClustering(gateways)
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "Cluster42";
        options.ServiceId = "MyAwesomeService";
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .Build();
```
