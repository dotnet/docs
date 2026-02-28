---
title: Using the Azure CosmosDB NoSQL Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Azure CosmosDB NoSQL.
ms.topic: concept-article
ms.date: 09/23/2024
---
# Using the Azure CosmosDB NoSQL Vector Store connector (Preview)

> [!WARNING]
> The Azure CosmosDB NoSQL Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Azure CosmosDB NoSQL Vector Store connector can be used to access and manage data in Azure CosmosDB NoSQL. The connector has the following characteristics.

| Feature Area       | Support                         |
|--------------------|---------------------------------|
| Collection maps to | Azure Cosmos DB NoSQL Container |
| Supported key property types | <ul><li>string</li><li>CosmosNoSqlCompositeKey</li></ul> |
| Supported data property types | <ul><li>string</li><li>int</li><li>long</li><li>double</li><li>float</li><li>bool</li><li>DateTimeOffset</li><li>*and enumerables of each of these types*</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li><li>ReadOnlyMemory\<byte\></li><li>Embedding\<byte\></li><li>byte[]</li><li>ReadOnlyMemory\<sbyte\></li><li>Embedding\<sbyte\></li><li>sbyte[]</li></ul> |
| Supported index types | <ul><li>Flat</li><li>QuantizedFlat</li><li>DiskAnn</li></ul> |
| Supported distance functions | <ul><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanDistance</li></ul> |
| Supported filter clauses | <ul><li>AnyTagEqualTo</li><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | Yes |
| StorageName supported? | No, use `JsonSerializerOptions` and `JsonPropertyNameAttribute` instead. [See here for more info.](#data-mapping) |
| HybridSearch supported? | Yes |

## Limitations

When initializing `CosmosClient` manually, it is necessary to specify `CosmosClientOptions.UseSystemTextJsonSerializerWithOptions` due to limitations in the default serializer. This option can be set to `JsonSerializerOptions.Default` or customized with other serializer options to meet specific configuration needs.

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="Limitations":::

## Get started

Add the Azure CosmosDB NoSQL Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.CosmosNoSql --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="GetStarted1":::

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="GetStarted2":::

Extension methods that take no parameters are also provided. These require an instance of `Microsoft.Azure.Cosmos.Database` to be separately registered with the dependency injection container.

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="GetStarted3":::

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="GetStarted4":::

You can construct an Azure CosmosDB NoSQL Vector Store instance directly.

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="GetStarted5":::

It's possible to construct a direct reference to a named collection.

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="GetStarted6":::

## Data mapping

The Azure CosmosDB NoSQL Vector Store connector provides a default mapper when mapping from the data model to storage.

This mapper does a direct conversion of the list of properties on the data model to the fields in Azure CosmosDB NoSQL and uses `System.Text.Json.JsonSerializer`
to convert to the storage schema. This means that usage of the `JsonPropertyNameAttribute` is supported if a different storage name to the
data model property name is required. The only exception is the key of the record which is mapped to a database field named `id`, since all CosmosDB NoSQL
records must use this name for ids.

It's also possible to use a custom `JsonSerializerOptions` instance with a customized property naming policy. To enable this, the `JsonSerializerOptions`
must be passed to the `CosmosNoSqlCollection` on construction.

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="DataMapping1":::

Using the above custom `JsonSerializerOptions` which is using `SnakeCaseUpper`, the following data model will be mapped to the below json.

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="DataMapping2":::

```json
{
    "id": "1",
    "HOTEL_NAME": "Hotel Happy",
    "DESCRIPTION": "A place where everyone can be happy.",
    "HOTEL_DESCRIPTION_EMBEDDING": [0.9, 0.1, 0.1, 0.1],
}
```

## Using partition key

In the Azure Cosmos DB for NoSQL connector, the partition key property defaults to the key property - `id`. The `PartitionKeyPropertyName` property in `CosmosNoSqlCollectionOptions` class allows specifying a different property as the partition key.

The `CosmosNoSqlCollection` class supports two key types: `string` and `CosmosNoSqlCompositeKey`. The `CosmosNoSqlCompositeKey` consists of `RecordKey` and `PartitionKey`.

If the partition key property is not set (and the default key property is used), `string` keys can be used for operations with database records. However, if a partition key property is specified, it is recommended to use `CosmosNoSqlCompositeKey` to provide both the key and partition key values.

Specify partition key property name:

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="UsingPartitionKey1":::

Get with partition key:

:::code language="csharp" source="./snippets/azure-cosmosdb-nosql-connector.cs" id="UsingPartitionKey2":::