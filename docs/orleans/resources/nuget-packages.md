---
title: Orleans NuGet packages
description: Explore the many .NET Orleans NuGet packages.
ms.date: 01/21/2026
zone_pivot_groups: orleans-version
---

# Orleans NuGet packages

Consumers of Orleans rely on various NuGet packages to achieve specific desired behaviors. There are several common packages and abstractions, and many individual single purpose packages. This article provides insights to help developers learn which Orleans packages should be used.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0,orleans-9-0,orleans-8-0"
<!-- markdownlint-enable MD044 -->

[!INCLUDE [Orleans-version-note](../includes/orleans-version-note.md)]

## Key packages

You reference one of two mutually exclusive NuGet packages when writing Orleans apps, depending on the chosen workload. For example, when you write an Orleans Silo, you'll reference the [Microsoft.Orleans.Server](https://www.nuget.org/packages/Microsoft.Orleans.Server) NuGet package. When you write an Orleans Client app, you'll reference the [Microsoft.Orleans.Client](https://www.nuget.org/packages/Microsoft.Orleans.Client) NuGet package. All Orleans projects, such as abstractions or grain class libraries, reference the [Microsoft.Orleans.Sdk](https://www.nuget.org/packages/Microsoft.Orleans.Sdk) NuGet package. The `Microsoft.Orleans.Sdk` package is included with both the `Client` and `Server` packages.

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Client](https://www.nuget.org/packages/Microsoft.Orleans.Client) | Client-exclusive package, required for Orleans client. |
| [Microsoft.Orleans.Sdk](https://www.nuget.org/packages/Microsoft.Orleans.Sdk) | Metapackage required by all Orleans apps, server and client packages depend on this package. |
| [Microsoft.Orleans.Server](https://www.nuget.org/packages/Microsoft.Orleans.Server) | Server-exclusive package, required for Orleans silos. |

For information on installing NuGet packages, see the following options:

- [.NET CLI: dotnet package add](../../core/tools/dotnet-package-add.md)
- [Ways to install a NuGet package](/nuget/consume-packages/overview-and-workflow#ways-to-install-a-nuget-package)

## Orleans Dashboard (Orleans 10.0+)

The official Orleans Dashboard provides real-time cluster monitoring and visualization.

| NuGet package | Status | Description |
|---|---|---|
| [Microsoft.Orleans.Dashboard](https://www.nuget.org/packages/Microsoft.Orleans.Dashboard) | Stable | Orleans Dashboard for real-time cluster monitoring and visualization. |
| [Microsoft.Orleans.Dashboard.Abstractions](https://www.nuget.org/packages/Microsoft.Orleans.Dashboard.Abstractions) | Stable | Abstractions for Orleans Dashboard. |

> [!NOTE]
> For more information, see [Orleans Dashboard](../dashboard/index.md).

## Orleans 10.0 Preview and Alpha packages

The following packages are new in Orleans 10.0 and are in preview or alpha status:

| NuGet package | Status | Description |
|---|---|---|
| [Microsoft.Orleans.DurableJobs](https://www.nuget.org/packages/Microsoft.Orleans.DurableJobs) | Alpha | Durable Jobs library for scheduled, at-least-once job execution. |
| [Microsoft.Orleans.DurableJobs.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.DurableJobs.AzureStorage) | Alpha | Azure Storage provider for Durable Jobs. |
| [Microsoft.Orleans.Journaling](https://www.nuget.org/packages/Microsoft.Orleans.Journaling) | Alpha | Durable state machines with replicated state for grains. |
| [Microsoft.Orleans.Journaling.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Journaling.AzureStorage) | Alpha | Azure Storage provider for Journaling. |
| [Microsoft.Orleans.Streaming.NATS](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.NATS) | Alpha | Orleans streaming provider backed by NATS JetStream. |

> [!TIP]
> For more information, see [Durable Jobs](../grains/durable-jobs/index.md), [Journaling](../grains/journaling/index.md), and [Stream providers](../streaming/stream-providers.md).

## Hosting

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Hosting.AzureCloudServices](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.AzureCloudServices) | Hosting utilities for Azure Cloud Services of Orleans. *(Deprecated: Azure Cloud Services is retired)* |
| [Microsoft.Orleans.Hosting.Kubernetes](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.Kubernetes) | Orleans hosting support for Kubernetes. |
| [Microsoft.Orleans.Runtime](https://www.nuget.org/packages/Microsoft.Orleans.Runtime) | Core runtime library of Orleans that hosts and executes grains within a silo. |

## Clustering providers

| NuGet package | Introduced | Description |
|---|---|---|
| [Microsoft.Orleans.Clustering.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AzureStorage) | 1.0 | Orleans clustering provider backed by Azure Table Storage. |
| [Microsoft.Orleans.Clustering.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AdoNet) | 1.0 | Orleans clustering provider backed by ADO.NET. |
| [Microsoft.Orleans.Clustering.DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.DynamoDB) | 1.0 | Orleans clustering provider backed by AWS DynamoDB. |
| [Microsoft.Orleans.Clustering.Cosmos](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.Cosmos) | 7.2 | Orleans clustering provider backed by Azure Cosmos DB. |
| [Microsoft.Orleans.Clustering.Redis](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.Redis) | 7.2 | Orleans clustering provider backed by Redis. |
| [Microsoft.Orleans.Clustering.Cassandra](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.Cassandra) | 8.2 | Orleans clustering provider backed by Apache Cassandra. |
| [Microsoft.Orleans.Clustering.Consul](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.Consul) | 1.0 | Orleans clustering provider backed by HashiCorp Consul. |
| [Microsoft.Orleans.Clustering.ZooKeeper](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.ZooKeeper) | 1.0 | Orleans clustering provider backed by Apache ZooKeeper. |

## Reminder providers

| NuGet package | Introduced | Description |
|---|---|---|
| [Microsoft.Orleans.Reminders](https://www.nuget.org/packages/Microsoft.Orleans.Reminders) | 7.0 | Reminders library for Microsoft Orleans used on the server. |
| [Microsoft.Orleans.Reminders.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.AzureStorage) | 1.0 | Orleans reminders provider backed by Azure Table Storage. |
| [Microsoft.Orleans.Reminders.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.AdoNet) | 1.0 | Orleans reminders provider backed by ADO.NET. |
| [Microsoft.Orleans.Reminders.DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.DynamoDB) | 1.0 | Orleans reminders provider backed by AWS DynamoDB. |
| [Microsoft.Orleans.Reminders.Cosmos](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.Cosmos) | 7.2 | Orleans reminders provider backed by Azure Cosmos DB. |
| [Microsoft.Orleans.Reminders.Redis](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.Redis) | 7.2 | Orleans reminders provider backed by Redis. |

## Grain storage providers

| NuGet package | Introduced | Description |
|---|---|---|
| [Microsoft.Orleans.Persistence.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AdoNet) | 1.0 | Orleans persistence provider backed by ADO.NET. |
| [Microsoft.Orleans.Persistence.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage) | 1.0 | Orleans persistence provider backed by Azure Table Storage. |
| [Microsoft.Orleans.Persistence.DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.DynamoDB) | 1.0 | Orleans persistence provider backed by AWS DynamoDB. |
| [Microsoft.Orleans.Persistence.Cosmos](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Cosmos) | 7.2 | Orleans persistence provider backed by Azure Cosmos DB. |
| [Microsoft.Orleans.Persistence.Redis](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Redis) | 7.2 | Orleans persistence provider backed by Redis. |
| [Microsoft.Orleans.Persistence.Memory](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Memory) | 1.0 | In-memory storage for Orleans. |

## Grain directory providers

| NuGet package | Status | Description |
|---|---|---|
| [Microsoft.Orleans.GrainDirectory.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.GrainDirectory.AzureStorage) | Stable | Orleans grain directory provider backed by Azure Table Storage. |
| [Microsoft.Orleans.GrainDirectory.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.GrainDirectory.AdoNet) | Alpha | Orleans grain directory provider backed by ADO.NET. *(Orleans 9.2+)* |
| [Microsoft.Orleans.GrainDirectory.Redis](https://www.nuget.org/packages/Microsoft.Orleans.GrainDirectory.Redis) | Stable | Orleans grain directory provider backed by Redis. |

## Stream providers

| NuGet package | Status | Description |
|---|---|---|
| [Microsoft.Orleans.Streaming](https://www.nuget.org/packages/Microsoft.Orleans.Streaming) | Stable | Streaming library for Orleans used both on the client and server. |
| [Microsoft.Orleans.Streaming.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.AzureStorage) | Stable | Orleans streaming provider backed by Azure Queue Storage. |
| [Microsoft.Orleans.Streaming.EventHubs](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.EventHubs) | Stable | Orleans streaming provider backed by Azure Event Hubs. |
| [Microsoft.Orleans.Streaming.SQS](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.SQS) | Stable | Orleans streaming provider backed by AWS SQS. |
| [Microsoft.Orleans.Streaming.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.AdoNet) | Alpha | Orleans streaming provider backed by ADO.NET. *(Orleans 9.2+)* |
| [Microsoft.Orleans.Streaming.NATS](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.NATS) | Alpha | Orleans streaming provider backed by NATS JetStream. *(Orleans 10.0+)* |

## Additional packages

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Analyzers](https://www.nuget.org/packages/Microsoft.Orleans.Analyzers) | C# Analyzers for Orleans. |
| [Microsoft.Orleans.CodeGenerator](https://www.nuget.org/packages/Microsoft.Orleans.CodeGenerator) | Code generation library for `Microsoft.Orleans.Serialization`. |
| [Microsoft.Orleans.EventSourcing](https://www.nuget.org/packages/Microsoft.Orleans.EventSourcing) | Base types for creating Orleans grains with event-sourced state. |
| [Microsoft.Orleans.Connections.Security](https://www.nuget.org/packages/Microsoft.Orleans.Connections.Security) | Support for security communication using TLS in Orleans. |
| [Microsoft.Orleans.BroadcastChannel](https://www.nuget.org/packages/Microsoft.Orleans.BroadcastChannel) | Support for broadcast channels in Orleans. |

## Development and testing

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.TestingHost](https://www.nuget.org/packages/Microsoft.Orleans.TestingHost) | Orleans library for hosting a silo in a testing project. |
| [Microsoft.Orleans.Transactions.TestKit.Base](https://www.nuget.org/packages/Microsoft.Orleans.Transactions.TestKit.Base) | Test kit base library for transactions. |
| [Microsoft.Orleans.Transactions.TestKit.xUnit](https://www.nuget.org/packages/Microsoft.Orleans.Transactions.TestKit.xUnit) | xUnit test kit library for transactions. |
| [Microsoft.Orleans.Serialization.TestKit](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.TestKit) | Test kit for projects using `Microsoft.Orleans.Serialization`. |

## Serializers

| NuGet package | Introduced | Description |
|---|---|---|
| [Microsoft.Orleans.Serialization](https://www.nuget.org/packages/Microsoft.Orleans.Serialization) | 7.0 | Fast, flexible, and version-tolerant serializer for .NET. |
| [Microsoft.Orleans.Serialization.Abstractions](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.Abstractions) | 7.0 | Serialization abstractions for Orleans. |
| [Microsoft.Orleans.Serialization.SystemTextJson](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.SystemTextJson) | 7.0 | `System.Text.Json` integration for `Microsoft.Orleans.Serialization`. |
| [Microsoft.Orleans.Serialization.FSharp](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.FSharp) | 7.0 | F# core type support for `Microsoft.Orleans.Serialization`. |
| [Microsoft.Orleans.Serialization.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.NewtonsoftJson) | 7.0 | `Newtonsoft.Json` integration for `Microsoft.Orleans.Serialization`. |
| [Microsoft.Orleans.Serialization.MessagePack](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.MessagePack) | 8.2 | MessagePack integration for `Microsoft.Orleans.Serialization`. |
| [Microsoft.Orleans.Serialization.Protobuf](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.Protobuf) | 8.0 | Protocol Buffers (Protobuf) integration for `Microsoft.Orleans.Serialization`. |

## Transactions

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Transactions](https://www.nuget.org/packages/Microsoft.Orleans.Transactions) | Core transaction library of Orleans used on the server. |
| [Microsoft.Orleans.Transactions.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Transactions.AzureStorage) | Orleans transactions storage provider backed by Azure Storage. |

## Deprecated packages

The following packages are deprecated and should not be used in new Orleans 7.0+ projects:

| NuGet package | Replacement | Notes |
|---|---|---|
| Microsoft.Orleans.OrleansCodeGenerator.Build | Source generators (automatic) | Replaced by compile-time source generators in Orleans 7.0. |
| Microsoft.Orleans.CodeGenerator.MSBuild | Source generators (automatic) | Replaced by compile-time source generators in Orleans 7.0. |
| Microsoft.Orleans.OrleansRuntime | Microsoft.Orleans.Server | Use the Server metapackage instead. |
| Microsoft.Orleans.OrleansServiceBus | Microsoft.Orleans.Streaming.EventHubs | Use the EventHubs streaming package instead. |
| Microsoft.Orleans.Core | Microsoft.Orleans.Sdk | Use the Sdk package instead. |
| Microsoft.Orleans.Core.Abstractions | Microsoft.Orleans.Sdk | Use the Sdk package instead. |

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

## Key packages

You reference one of two mutually exclusive NuGet packages when writing Orleans apps, depending on the chosen workload. For example, when you write an Orleans Silo, you'll reference the [Microsoft.Orleans.Server](https://www.nuget.org/packages/Microsoft.Orleans.Server) NuGet package. When you write an Orleans Client app, you'll reference the [Microsoft.Orleans.Client](https://www.nuget.org/packages/Microsoft.Orleans.Client) NuGet package. All Orleans projects, such as abstractions or grain class libraries, reference the [Microsoft.Orleans.Sdk](https://www.nuget.org/packages/Microsoft.Orleans.Sdk) NuGet package. The `Microsoft.Orleans.Sdk` package is included with both the `Client` and `Server` packages.

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Client](https://www.nuget.org/packages/Microsoft.Orleans.Client) | Client-exclusive package, required for Orleans client. |
| [Microsoft.Orleans.Sdk](https://www.nuget.org/packages/Microsoft.Orleans.Sdk) | Metapackage required by all Orleans apps, server and client packages depend on this package. |
| [Microsoft.Orleans.Server](https://www.nuget.org/packages/Microsoft.Orleans.Server) | Server-exclusive package, required for Orleans silos. |

For information on installing NuGet packages, see the following options:

- [.NET CLI: dotnet package add](../../core/tools/dotnet-package-add.md)
- [Ways to install a NuGet package](/nuget/consume-packages/overview-and-workflow#ways-to-install-a-nuget-package)

## Hosting

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Hosting.AzureCloudServices](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.AzureCloudServices) | Hosting utilities for Azure Cloud Services of Orleans. |
| [Microsoft.Orleans.Hosting.Kubernetes](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.Kubernetes) | Orleans hosting support for Kubernetes. |
| [Microsoft.Orleans.Runtime](https://www.nuget.org/packages/Microsoft.Orleans.Runtime) | Core runtime library of Orleans that hosts and executes grains within a silo. |

## Clustering providers

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Clustering.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AzureStorage) | Orleans clustering provider backed by Azure Table Storage. |
| [Microsoft.Orleans.Clustering.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AdoNet) | Orleans clustering provider backed by ADO.NET. |
| [Microsoft.Orleans.Clustering.DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.DynamoDB) | Orleans clustering provider backed by AWS DynamoDB. |

## Reminder providers

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Reminders](https://www.nuget.org/packages/Microsoft.Orleans.Reminders) | Reminders library for Microsoft Orleans used on the server. |
| [Microsoft.Orleans.Reminders.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.AzureStorage) | Orleans reminders provider backed by Azure Table Storage. |
| [Microsoft.Orleans.Reminders.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.AdoNet) | Orleans reminders provider backed by ADO.NET. |
| [Microsoft.Orleans.Reminders.DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.DynamoDB) | Orleans reminders provider backed by AWS DynamoDB. |

## Grain storage providers

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Persistence.AdoNet](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AdoNet) | Orleans persistence provider backed by ADO.NET. |
| [Microsoft.Orleans.Persistence.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage) | Orleans persistence provider backed by Azure Table Storage. |
| [Microsoft.Orleans.Persistence.DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.DynamoDB) | Orleans persistence provider backed by AWS DynamoDB. |
| [Microsoft.Orleans.Persistence.Memory](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Memory) | In-memory storage for Orleans. |

## Stream providers

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Streaming](https://www.nuget.org/packages/Microsoft.Orleans.Streaming) | Streaming library for Orleans used both on the client and server. |
| [Microsoft.Orleans.Streaming.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.AzureStorage) | Orleans streaming provider backed by Azure Queue Storage. |
| [Microsoft.Orleans.Streaming.EventHubs](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.EventHubs) | Orleans streaming provider backed by Azure Event Hubs. |
| [Microsoft.Orleans.Streaming.SQS](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.SQS) | Orleans streaming provider backed by AWS SQS. |

## Additional packages

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Analyzers](https://www.nuget.org/packages/Microsoft.Orleans.Analyzers) | C# Analyzers for Orleans. |
| [Microsoft.Orleans.CodeGenerator](https://www.nuget.org/packages/Microsoft.Orleans.CodeGenerator) | Code generation library for `Microsoft.Orleans.Serialization`. |
| [Microsoft.Orleans.EventSourcing](https://www.nuget.org/packages/Microsoft.Orleans.EventSourcing) | Base types for creating Orleans grains with event-sourced state. |
| [Microsoft.Orleans.Connections.Security](https://www.nuget.org/packages/Microsoft.Orleans.Connections.Security) | Support for security communication using TLS in Orleans. |

## Development and testing

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.TestingHost](https://www.nuget.org/packages/Microsoft.Orleans.TestingHost) | Orleans library for hosting a silo in a testing project. |
| [Microsoft.Orleans.Transactions.TestKit.Base](https://www.nuget.org/packages/Microsoft.Orleans.Transactions.TestKit.Base) | Test kit base library for transactions. |
| [Microsoft.Orleans.Transactions.TestKit.xUnit](https://www.nuget.org/packages/Microsoft.Orleans.Transactions.TestKit.xUnit) | xUnit test kit library for transactions. |
| [Microsoft.Orleans.Serialization.TestKit](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.TestKit) | Test kit for projects using `Microsoft.Orleans.Serialization`. |

## Serializers

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Serialization](https://www.nuget.org/packages/Microsoft.Orleans.Serialization) | Fast, flexible, and version-tolerant serializer for .NET. |
| [Microsoft.Orleans.Serialization.Abstractions](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.Abstractions) | Serialization abstractions for Orleans. |
| [Microsoft.Orleans.Serialization.SystemTextJson](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.SystemTextJson) | `System.Text.Json` integration for `Microsoft.Orleans.Serialization`. |
| [Microsoft.Orleans.Serialization.FSharp](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.FSharp) | F# core type support for `Microsoft.Orleans.Serialization`. |
| [Microsoft.Orleans.Serialization.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.NewtonsoftJson) | `Newtonsoft.Json` integration for `Microsoft.Orleans.Serialization`. |

## Transactions

| NuGet package | Description |
|---|---|
| [Microsoft.Orleans.Transactions](https://www.nuget.org/packages/Microsoft.Orleans.Transactions) | Core transaction library of Orleans used on the server. |
| [Microsoft.Orleans.Transactions.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Transactions.AzureStorage) | Orleans transactions storage provider backed by Azure Storage. |

## Tools

One popular Orleans tool is the [OrleansDashboard](https://www.nuget.org/packages/OrleansDashboard) NuGet package. This dashboard provides some simple metrics and insights into what is happening inside your Orleans app. For more information, see [GitHub: Orleans Dashboard](https://github.com/OrleansContrib/OrleansDashboard).

> [!TIP]
> In Orleans 10.0+, an official [Microsoft.Orleans.Dashboard](https://www.nuget.org/packages/Microsoft.Orleans.Dashboard) package is available. See [Orleans Dashboard](../dashboard/index.md) for more information.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

## Key packages

There are 5 key NuGet packages you will need to use in most scenarios:

### [Orleans Core Abstractions](https://www.nuget.org/packages/Microsoft.Orleans.Core.Abstractions/)

```powershell
Install-Package Microsoft.Orleans.Core.Abstractions
```

Contains _Orleans.Core.Abstractions.dll_, which defines Orleans public types that are needed for developing application code (grain interfaces and classes). This package is needed to be directly or indirectly referenced by any Orleans project.
Add it to your projects that define grain interfaces and classes.

### Orleans build-time code generation

- [Microsoft.Orleans.OrleansCodeGenerator.Build](https://www.nuget.org/packages/Microsoft.Orleans.OrleansCodeGenerator.Build/).

    ```powershell
    Install-Package Microsoft.Orleans.OrleansCodeGenerator.Build
    ```

    Appeared in Orleans 1.2.0. Build time support for grain interfaces and implementation projects.
    Add it to your grain interfaces and implementation projects to enable code generation of grain references and serializers.

- [Microsoft.Orleans.CodeGenerator.MSBuild](https://www.nuget.org/packages/Microsoft.Orleans.CodeGenerator.MSBuild/).

    ```powershell
    Install-Package Microsoft.Orleans.CodeGenerator.MSBuild
    ```

    Appeared as part of [Orleans 2.1.0](https://dotnet.github.io/orleans/blog/announcing-orleans-2.1.html). An alternative to the `Microsoft.Orleans.OrleansCodeGenerator.Build` package. Leverages Roslyn for code analysis to avoid loading application binaries and improves support for incremental builds, which should result in shorter build times.

### [Orleans Server Libraries](https://www.nuget.org/packages/Microsoft.Orleans.Server/)

```powershell
Install-Package Microsoft.Orleans.Server
```

A meta-package for easily building and starting a silo. Includes the following packages:

- `Microsoft.Orleans.Core.Abstractions`
- `Microsoft.Orleans.Core`
- `Microsoft.Orleans.OrleansRuntime`
- `Microsoft.Orleans.OrleansProviders`

### [Orleans Client Libraries](https://www.nuget.org/packages/Microsoft.Orleans.Client/)

```powershell
Install-Package Microsoft.Orleans.Client
```

A meta-package for easily building and starting an Orleans client (frontend). Includes the following packages:

- `Microsoft.Orleans.Core.Abstractions`
- `Microsoft.Orleans.Core`
- `Microsoft.Orleans.OrleansProviders`

### [Orleans Core Library](https://www.nuget.org/packages/Microsoft.Orleans.Core/)

```powershell
Install-Package Microsoft.Orleans.Core
```

Contains implementation for most Orleans public types used by application code and Orleans clients (frontends).
Reference it for building libraries and client applications that use Orleans types but don't deal with hosting or silos.
Included in Microsoft.Orleans.Client and Microsoft.Orleans.Server meta-packages, and is referenced, directly or indirectly, by most other packages.

## Hosting

### [Orleans Runtime](https://www.nuget.org/packages/Microsoft.Orleans.OrleansRuntime/)

```powershell
Install-Package Microsoft.Orleans.OrleansRuntime
```

Library for configuring and starting a silo. Reference it in your silo host project. Included in Microsoft.Orleans.Server meta-package.

### [Orleans Runtime Abstractions](https://www.nuget.org/packages/Microsoft.Orleans.Runtime.Abstractions/)

```powershell
Install-Package Microsoft.Orleans.Runtime.Abstractions
```

Contains interfaces and abstractions for types implemented in `Microsoft.Orleans.OrleansRuntime`.

### [Orleans Hosting on Azure Cloud Services](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.AzureCloudServices/)

```powershell
Install-Package Microsoft.Orleans.Hosting.AzureCloudServices
```

Contains helper classes for hosting silos and Orleans clients as Azure Cloud Services (Worker Roles and Web Roles).

### [Orleans Service Fabric Hosting Support](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.ServiceFabric/)

```powershell
Install-Package Microsoft.Orleans.Hosting.ServiceFabric
```

Contains helper classes for hosting silos as a stateless Service Fabric service.

## Clustering providers

The below packages include plugins for persisting cluster membership data in various storage technologies.

### [Orleans clustering provider for Azure Table Storages](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Clustering.AzureStorage
```

Includes the plugin for using Azure Tables for storing cluster membership data.

### [Orleans clustering provider for ADO.NET Providers](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.AdoNet/)

```powershell
Install-Package Microsoft.Orleans.Clustering.AdoNet
```

Includes the plugin for using ADO.NET for storing cluster membership data in one of the supported databases.

### [Orleans Consul Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansConsulUtils/)

```powershell
Install-Package Microsoft.Orleans.OrleansConsulUtils
```

Includes the plugin for using Consul for storing cluster membership data.

### [Orleans ZooKeeper Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansZooKeeperUtils/)

```powershell
Install-Package Microsoft.Orleans.OrleansZooKeeperUtils
```

Includes the plugin for using ZooKeeper for storing cluster membership data.

### [Orleans clustering provider for AWS DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.DynamoDB/)

```powershell
Install-Package Microsoft.Orleans.Clustering.DynamoDB
```

Includes the plugin for using AWS DynamoDB for storing cluster membership data.

## Reminder providers

The below packages include plugins for persisting reminders in various storage technologies.

### [Orleans Reminders Azure Table Storage](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Reminders.AzureStorage
```

Includes the plugin for using Azure Tables for storing reminders.

### [Orleans Reminders ADO.NET Providers](https://www.nuget.org/packages/Microsoft.Orleans.reminders.AdoNet/)

```powershell
Install-Package Microsoft.Orleans.Reminders.AdoNet
```

Includes the plugin for using ADO.NET for storing reminders in one of the supported databases.

### [Orleans reminders provider for AWS DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Reminders.DynamoDB/)

```powershell
Install-Package Microsoft.Orleans.Reminders.DynamoDB
```

Includes the plugin for using AWS DynamoDB for storing reminders.

## Grain storage providers

The below packages include plugins for persisting grain state in various storage technologies.

### [Orleans Persistence Azure Storage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Persistence.AzureStorage
```

Includes the plugins for using Azure Tables or Azure Blobs for storing grain state.

### [Orleans Persistence ADO.NET Providers](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AdoNet/)

```powershell
Install-Package Microsoft.Orleans.Persistence.AdoNet
```

Includes the plugin for using ADO.NET for storing grain state in one of the supported databases.

### [Orleans Persistence DynamoDB](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.DynamoDB/)

```powershell
Install-Package Microsoft.Orleans.Persistence.DynamoDB
```

Includes the plugin for using AWS DynamoDB for storing grain state.

## Stream providers

The below packages include plugins for delivering streaming events.

### [Orleans ServiceBus Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansServiceBus/)

```powershell
Install-Package Microsoft.Orleans.OrleansServiceBus
```

Includes the stream provider for Azure Event Hubs.

### [Orleans Streaming Azure Storage](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Streaming.AzureStorage
```

Includes the stream provider for Azure Queues.

### [Orleans Streaming AWS SQS](https://www.nuget.org/packages/Microsoft.Orleans.Streaming.SQS/)

```powershell
Install-Package Microsoft.Orleans.Streaming.SQS
```

Includes the stream provider for AWS SQS service.

### [Orleans Google Cloud Platform Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansGCPUtils/)

```powershell
Install-Package Microsoft.Orleans.OrleansGCPUtils
```

Includes the stream provider for GCP PubSub service.

## Additional packages

### [Orleans Code Generation](https://www.nuget.org/packages/Microsoft.Orleans.OrleansCodeGenerator/)

```powershell
Install-Package Microsoft.Orleans.OrleansCodeGenerator
```

Includes the run-time code generator.

### [Orleans Event-Sourcing](https://www.nuget.org/packages/Microsoft.Orleans.EventSourcing/)

```powershell
Install-Package Microsoft.Orleans.EventSourcing
```

Contains a set of base types for creating grain classes with event-sourced state.

## Development and testing

### [Orleans Providers](https://www.nuget.org/packages/Microsoft.Orleans.OrleansProviders/)

```powershell
Install-Package Microsoft.Orleans.OrleansProviders
```

Contains a set of persistence and stream providers that keep data in memory.
Intended for testing. In general, not recommended for production use, unless data loss in case of a silo failure is acceptable.

### [Orleans Testing Host Library](https://www.nuget.org/packages/Microsoft.Orleans.TestingHost/)

```powershell
Install-Package Microsoft.Orleans.TestingHost
```

Includes the library for hosting silos and clients in a testing project.

## Serializers

### [Orleans Bond Serializer](https://www.nuget.org/packages/Microsoft.Orleans.Serialization.Bond/)

```powershell
Install-Package Microsoft.Orleans.Serialization.Bond
```

Includes support for [Bond serializer](https://github.com/microsoft/bond).

### [Orleans Google Utilities](https://www.nuget.org/packages/Microsoft.Orleans.OrleansGoogleUtils/)

```powershell
Install-Package Microsoft.Orleans.OrleansGoogleUtils
```

Includes Google Protocol Buffers serializer.

### [Orleans protobuf-net Serializer](https://www.nuget.org/packages/Microsoft.Orleans.ProtobufNet/)

```powershell
Install-Package Microsoft.Orleans.ProtobufNet
```

Includes protobuf-net version of Protocol Buffers serializer.

## Telemetry

### [Orleans Telemetry Consumer - Performance Counters](https://www.nuget.org/packages/Microsoft.Orleans.OrleansTelemetryConsumers.Counters/)

```powershell
Install-Package Microsoft.Orleans.OrleansTelemetryConsumers.Counters
```

Windows Performance Counters implementation of Orleans Telemetry API.

### [Orleans Telemetry Consumer - Azure Application Insights](https://www.nuget.org/packages/Microsoft.Orleans.OrleansTelemetryConsumers.AI/)

```powershell
Install-Package Microsoft.Orleans.OrleansTelemetryConsumers.AI
```

Includes the telemetry consumer for Azure Application Insights.

### [Orleans Telemetry Consumer - NewRelic](https://www.nuget.org/packages/Microsoft.Orleans.OrleansTelemetryConsumers.NewRelic/)

```powershell
Install-Package Microsoft.Orleans.OrleansTelemetryConsumers.NewRelic
```

Includes the telemetry consumer for NewRelic.

## Transactions

### [Orleans Transactions support](https://www.nuget.org/packages/Microsoft.Orleans.Transactions/)

```powershell
Install-Package Microsoft.Orleans.Transactions
```

Includes support for cross-grain transactions (beta).

### [Orleans Transactions on Azure](https://www.nuget.org/packages/Microsoft.Orleans.Transactions.AzureStorage/)

```powershell
Install-Package Microsoft.Orleans.Transactions.AzureStorage
```

Includes a plugin for persisting transaction log in Azure Table (beta).

## Tools

### [Orleans Performance Counter Tool](https://www.nuget.org/packages/Microsoft.Orleans.CounterControl/)

```powershell
Install-Package Microsoft.Orleans.CounterControl
```

Includes `OrleansCounterControl.exe`, which registers Windows performance counter categories for Orleans statistics and for deployed grain classes. Requires elevation. Can be executed in Azure as part of a role startup task.

:::zone-end
