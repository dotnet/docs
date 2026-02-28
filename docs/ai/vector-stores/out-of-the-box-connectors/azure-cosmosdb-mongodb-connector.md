---
title: Using the Azure CosmosDB MongoDB (vCore) Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Azure CosmosDB MongoDB (vCore).
ms.topic: concept-article
ms.date: 09/23/2024
---
# Using the Azure CosmosDB MongoDB (vCore) Vector Store connector (Preview)

> [!WARNING]
> The Azure CosmosDB MongoDB (vCore) Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Azure CosmosDB MongoDB Vector Store connector can be used to access and manage data in Azure CosmosDB MongoDB (vCore). The connector has the following characteristics.

| Feature Area                 | Support                                            |
|------------------------------|----------------------------------------------------|
| Collection maps to           | Azure Cosmos DB MongoDB (vCore) Collection + Index |
| Supported key property types | string                                             |
| Supported data property types | <ul><li>string</li><li>int</li><li>long</li><li>double</li><li>float</li><li>decimal</li><li>bool</li><li>DateTime</li><li>*and enumerables of each of these types*</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types | <ul><li>Hnsw</li><li>IvfFlat</li></ul> |
| Supported distance functions | <ul><li>CosineDistance</li><li>DotProductSimilarity</li><li>EuclideanDistance</li></ul> |
| Supported filter clauses | <ul><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | No |
| StorageName supported? | No, use BsonElementAttribute instead. For more information, see [Data mapping](#data-mapping). |
| HybridSearch supported? | No |

## Limitations

This connector is compatible with Azure Cosmos DB MongoDB (vCore) and is *not* designed to be compatible with Azure Cosmos DB MongoDB (RU).

## Get started

Add the Azure CosmosDB MongoDB Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.CosmosMongoDB --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

:::code language="csharp" source="./snippets/azure-cosmosdb-mongodb-connector.cs" id="GetStarted1":::

:::code language="csharp" source="./snippets/azure-cosmosdb-mongodb-connector.cs" id="GetStarted2":::

Extension methods that take no parameters are also provided. These require an instance of `MongoDB.Driver.IMongoDatabase` to be separately registered with the dependency injection container.

:::code language="csharp" source="./snippets/azure-cosmosdb-mongodb-connector.cs" id="GetStarted3":::

:::code language="csharp" source="./snippets/azure-cosmosdb-mongodb-connector.cs" id="GetStarted4":::

You can construct an Azure CosmosDB MongoDB Vector Store instance directly.

:::code language="csharp" source="./snippets/azure-cosmosdb-mongodb-connector.cs" id="GetStarted5":::

It's possible to construct a direct reference to a named collection.

:::code language="csharp" source="./snippets/azure-cosmosdb-mongodb-connector.cs" id="GetStarted6":::

## Data mapping

The Azure CosmosDB MongoDB Vector Store connector provides a default mapper when mapping data from the data model to storage.

This mapper does a direct conversion of the list of properties on the data model to the fields in Azure CosmosDB MongoDB and uses `MongoDB.Bson.Serialization` to convert to the storage schema. This means that usage of the `MongoDB.Bson.Serialization.Attributes.BsonElement` is supported if a different storage name to the data model property name is required. The only exception is the key of the record which is mapped to a database field named `_id`, since all CosmosDB MongoDB records must use this name for ids.

### Property name override

For data properties and vector properties, you can provide override field names to use in storage that is different to the property names on the data model. This is not supported for keys, since a key has a fixed name in MongoDB.

The property name override is done by setting the `BsonElement` attribute on the data model properties.

Here is an example of a data model with `BsonElement` set.

:::code language="csharp" source="./snippets/azure-cosmosdb-mongodb-connector.cs" id="PropertyNameOverride":::