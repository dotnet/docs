---
title: Orleans NuGet packages
description: Explore the many .NET Orleans NuGet packages.
ms.date: 03/21/2022
---

# Orleans NuGet packages

## Key Packages

There are 5 key NuGet packages you will need to use in most scenarios:

### [Microsoft Orleans Core Abstractions](https://www.nuget.org/packages/Microsoft.Orleans.Core.Abstractions/)

```powershell
Install-Package Microsoft.Orleans.Core.Abstractions
```

Contains _Orleans.Core.Abstractions.dll_, which defines Orleans public types that are needed for developing application code (grain interfaces and classes). This package is needed to be directly or indirectly referenced by any Orleans project.
Add it to your projects that define grain interfaces and classes.

### Microsoft Orleans Build-time Code Generation

* [Microsoft.Orleans.OrleansCodeGenerator.Build](https://www.nuget.org/packages/Microsoft.Orleans.OrleansCodeGenerator.Build/).

    ```powershell
    Install-Package Microsoft.Orleans.OrleansCodeGenerator.Build
    ```

    Appeared in Orleans 1.2.0. Build time support for grain interfaces and implementation projects.
    Add it to your grain interfaces and implementation projects to enable code generation of grain references and serializers.

* [Microsoft.Orleans.CodeGenerator.MSBuild](https://www.nuget.org/packages/Microsoft.Orleans.CodeGenerator.MSBuild/).

    ```powershell
    Install-Package Microsoft.Orleans.CodeGenerator.MSBuild
    ```

    Appeared as part of [Orleans 2.1.0](https://dotnet.github.io/orleans/blog/announcing-orleans-2.1.html). An alternative to the `Microsoft.Orleans.OrleansCodeGenerator.Build` package. Leverages Roslyn for code analysis to avoid loading application binaries and improves support for incremental builds, which should result in shorter build times.

### [Microsoft Orleans Server Libraries](https://www.nuget.org/packages/Microsoft.Orleans.Server/)

```powershell
Install-Package Microsoft.Orleans.Server
```

A meta-package for easily building and starting a silo. Includes the following packages:

* Microsoft.Orleans.Core.Abstractions
* Microsoft.Orleans.Core
* Microsoft.Orleans.OrleansRuntime
* Microsoft.Orleans.OrleansProviders

### [Microsoft Orleans Client Libraries](https://www.nuget.org/packages/Microsoft.Orleans.Client/)

```powershell
Install-Package Microsoft.Orleans.Client
```

A meta-package for easily building and starting an Orleans client (frontend). Includes the following packages:

* Microsoft.Orleans.Core.Abstractions
* Microsoft.Orleans.Core
* Microsoft.Orleans.OrleansProviders

### [Microsoft Orleans Core Library](https://www.nuget.org/packages/Microsoft.Orleans.Core/)

```powershell
Install-Package Microsoft.Orleans.Core
```

Contains implementation for most Orleans public types used by application code and Orleans clients (frontends).
Reference it for building libraries and client applications that use Orleans types but don't deal with hosting or silos.
Included in Microsoft.Orleans.Client and Microsoft.Orleans.Server meta-packages, and is referenced, directly or indirectly, by most other packages.

## Hosting

### [Microsoft Orleans Runtime](https://www.nuget.org/packages/Microsoft.Orleans.OrleansRuntime/)

```powershell
Install-Package Microsoft.Orleans.OrleansRuntime
```

Library for configuring and starting a silo. Reference it in your silo host project. Included in Microsoft.Orleans.Server meta-package.

### [Microsoft Orleans Runtime Abstractions](https://www.nuget.org/packages/Microsoft.Orleans.Runtime.Abstractions/)

```powershell
Install-Package Microsoft.Orleans.Runtime.Abstractions
```

Contains interfaces and abstractions for types implemented in Microsoft.Orleans.OrleansRuntime.

### [Microsoft Orleans Hosting on Azure Cloud Services](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.AzureCloudServices/)

```powershell
Install-Package Microsoft.Orleans.Hosting.AzureCloudServices
```

Contains helper classes for hosting silos and Orleans clients as Azure Cloud Services (Worker Roles and Web Roles).

### [Microsoft Orleans Service Fabric Hosting Support](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.ServiceFabric/)

```powershell
Install-Package Microsoft.Orleans.Hosting.ServiceFabric
```

Contains helper classes for hosting silos as a stateless Service Fabric service.

## Clustering Providers

The below packages include plugins for persisting cluster membership data in various storage technologies.

### [Microsoft Orleans clustering provider for Azure Table Storages](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Clustering.AzureStorage
```

Includes the plugin for using Azure Tables for storing cluster membership data.

### [Microsoft Orleans clustering provider for ADO.NET Providers](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AdoNet/)

```powershell
Install-Package Microsoft.Orleans.Clustering.AdoNet
```

Includes the plugin for using ADO.NET for storing cluster membership data in one of the supported databases.

### [Microsoft Orleans Consul Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansConsulUtils/)

```powershell
Install-Package Microsoft.Orleans.OrleansConsulUtils
```

Includes the plugin for using Consul for storing cluster membership data.

### [Microsoft Orleans ZooKeeper Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansZooKeeperUtils/)

```powershell
Install-Package Microsoft.Orleans.OrleansZooKeeperUtils
```

Includes the plugin for using ZooKeeper for storing cluster membership data.

### [Microsoft Orleans clustering provider for AWS DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.DynamoDB/)

```powershell
Install-Package Microsoft.Orleans.Clustering.DynamoDB
```

Includes the plugin for using AWS DynamoDB for storing cluster membership data.

## Reminder Providers

The below packages include plugins for persisting reminders in various storage technologies.

### [Microsoft Orleans Reminders Azure Table Storage](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Reminders.AzureStorage
```

Includes the plugin for using Azure Tables for storing reminders.

### [Microsoft Orleans Reminders ADO.NET Providers](https://www.nuget.org/packages/Microsoft.Orleans.reminders.AdoNet/)

```powershell
Install-Package Microsoft.Orleans.Reminders.AdoNet
```

Includes the plugin for using ADO.NET for storing reminders in one of the supported databases.

### [Microsoft Orleans reminders provider for AWS DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.DynamoDB/)

```powershell
Install-Package Microsoft.Orleans.Reminders.DynamoDB
```

Includes the plugin for using AWS DynamoDB for storing reminders.

## Grain Storage Providers

The below packages include plugins for persisting grain state in various storage technologies.

### [Microsoft Orleans Persistence Azure Storage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Persistence.AzureStorage
```

Includes the plugins for using Azure Tables or Azure Blobs for storing grain state.

### [Microsoft Orleans Persistence ADO.NET Providers](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AdoNet/)

```powershell
Install-Package Microsoft.Orleans.Persistence.AdoNet
```

Includes the plugin for using ADO.NET for storing grain state in one of the supported databases.

### [Microsoft Orleans Persistence DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.DynamoDB/)

```powershell
Install-Package Microsoft.Orleans.Persistence.DynamoDB
```

Includes the plugin for using AWS DynamoDB for storing grain state.

## Stream Providers

The below packages include plugins for delivering streaming events.

### [Microsoft Orleans ServiceBus Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansServiceBus/)

```powershell
Install-Package Microsoft.Orleans.OrleansServiceBus
```

Includes the stream provider for Azure Event Hubs.

### [Microsoft Orleans Streaming Azure Storage](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Streaming.AzureStorage
```

Includes the stream provider for Azure Queues.

### [Microsoft Orleans Streaming AWS SQS](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.SQS/)

```powershell
Install-Package Microsoft.Orleans.Streaming.SQS
```

Includes the stream provider for AWS SQS service.

### [Microsoft Orleans Google Cloud Platform Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansGCPUtils/)

```powershell
Install-Package Microsoft.Orleans.OrleansGCPUtils
```

Includes the stream provider for GCP PubSub service.

## Additional Packages

### [Microsoft Orleans Code Generation](https://www.nuget.org/packages/Microsoft.Orleans.OrleansCodeGenerator/)

```powershell
Install-Package Microsoft.Orleans.OrleansCodeGenerator
```

Includes the run time code generator.

### [Microsoft Orleans Event-Sourcing](https://www.nuget.org/packages/Microsoft.Orleans.EventSourcing/)

```powershell
Install-Package Microsoft.Orleans.EventSourcing
```

Contains a set of base types for creating grain classes with event-sourced state.

## Development and Testing

### [Microsoft Orleans Providers](https://www.nuget.org/packages/Microsoft.Orleans.OrleansProviders/)

```powershell
Install-Package Microsoft.Orleans.OrleansProviders
```

Contains a set of persistence and stream providers that keep data in memory.
Intended for testing. In general, not recommended for production use, unless data loss in case of a silo failure is acceptable.

### [Microsoft Orleans Testing Host Library](https://www.nuget.org/packages/Microsoft.Orleans.TestingHost/)

```powershell
Install-Package Microsoft.Orleans.TestingHost
```

Includes the library for hosting silos and clients in a testing project.

## Serializers

### [Microsoft Orleans Bond Serializer](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.Bond/)

```powershell
Install-Package Microsoft.Orleans.Serialization.Bond
```

Includes support for [Bond serializer](https://github.com/microsoft/bond).

### [Microsoft Orleans Google Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansGoogleUtils/)

```powershell
Install-Package Microsoft.Orleans.OrleansGoogleUtils
```

Includes Google Protocol Buffers serializer.

### [Microsoft Orleans protobuf-net Serializer](https://www.nuget.org/packages/Microsoft.Orleans.ProtobufNet/)

```powershell
Install-Package Microsoft.Orleans.ProtobufNet
```

Includes protobuf-net version of Protocol Buffers serializer.

## Telemetry

### [Microsoft Orleans Telemetry Consumer - Performance Counters](https://www.nuget.org/packages/Microsoft.Orleans.OrleansTelemetryConsumers.Counters/)

```powershell
Install-Package Microsoft.Orleans.OrleansTelemetryConsumers.Counters
```

Windows Performance Counters implementation of Orleans Telemetry API.

### [Microsoft Orleans Telemetry Consumer - Azure Application Insights](https://www.nuget.org/packages/Microsoft.Orleans.OrleansTelemetryConsumers.AI/)

```powershell
Install-Package Microsoft.Orleans.OrleansTelemetryConsumers.AI
```

Includes the telemetry consumer for Azure Application Insights.

### [Microsoft Orleans Telemetry Consumer - NewRelic](https://www.nuget.org/packages/Microsoft.Orleans.OrleansTelemetryConsumers.NewRelic/)

```powershell
Install-Package Microsoft.Orleans.OrleansTelemetryConsumers.NewRelic
```

Includes the telemetry consumer for NewRelic.

## Tools

### [Microsoft Orleans Performance Counter Tool](https://www.nuget.org/packages/Microsoft.Orleans.CounterControl/)

```powershell
Install-Package Microsoft.Orleans.CounterControl
```

Includes OrleansCounterControl.exe, which registers Windows performance counter categories for Orleans statistics and for deployed grain classes. Requires elevation. Can be executed in Azure as part of a role startup task.

## Transactions

### [Microsoft Orleans Transactions support](https://www.nuget.org/packages/Microsoft.Orleans.Transactions/)

```powershell
Install-Package Microsoft.Orleans.Transactions
```

Includes support for cross-grain transactions (beta).

### [Microsoft Orleans Transactions on Azure](https://www.nuget.org/packages/Microsoft.Orleans.Transactions.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Transactions.AzureStorage
```

Includes a plugin for persisting transaction log in Azure Table (beta).
