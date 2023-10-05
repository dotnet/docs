---
title: Azure Cosmos DB grain persistence
description: Use the Azure Cosmos DB grain to persist Azure Cosmos DB for NoSQL data in a .NET Orleans application.
ms.topic: conceptual
ms.devlang: csharp
ms.date: 10/03/2023
---

# Azure Cosmos DB for NoSQL grain persistence

The Azure Cosmos DB grain persistence provider supports the [API for NoSQL](/azure/cosmos-db/nosql).

## Install NuGet package

Install the [Microsoft.Orleans.Persistence.Cosmos](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Cosmos) and [Microsoft.Orleans.Clustering.Cosmos](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.Cosmos) NuGet packages. The Azure Cosmos DB provider stores state in a container item.

> [!IMPORTANT]
> The default database name used by the provider is **Orleans**. The default clustering container name is **OrleansCluster** and the default storage container name is **OrleansStorage**. The cluster container expects a partition key value of `/ClusterId` and the storage container expects `/PartitionKey`.

## Configure clustering provider

To configure the clustering provider use the `HostingExtensions.UseCosmosClustering` extension method.

```csharp
siloBuilder.UseCosmosClustering(
    configureOptions: static options =>
    {
        options.DatabaseName = "Orleans";
        options.DatabaseThroughput = 400;
        options.ContainerName = "OrleansCluster";
        options.ConfigureCosmosClient("AccountName=example;Key=example;");
    });
```

## Configure storage provider

Configure the Azure Cosmos DB grain persistence provider using the `HostingExtensions.AddCosmosGrainStorage` extension method.

```csharp
siloBuilder.AddCosmosGrainStorage(
    name: "profileStore",
    configureOptions: static options =>
    {
        options.DatabaseName = "Orleans";
        options.DatabaseThroughput = 400;
        options.ContainerName = "OrleansStorage";
        options.ConfigureCosmosClient("AccountName=example;Key=example;");
    });
```
