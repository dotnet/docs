---
title: Using the MongoDB Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in MongoDB.
author: dmytrostruk
ms.topic: concept-article
ms.author: dmytrostruk
ms.date: 10/25/2024
---
# Using the MongoDB Vector Store connector (Preview)

> [!WARNING]
> The MongoDB Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The MongoDB Vector Store connector can be used to access and manage data in MongoDB. The connector has the following characteristics.

| Feature Area | Support |
|--|--|
| Collection maps to | MongoDB Collection + Index |
| Supported key property types | string |
| Supported data property types | <ul><li>string</li><li>int</li><li>long</li><li>double</li><li>float</li><li>decimal</li><li>bool</li><li>DateTime</li><li>*and enumerables of each of these types*</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types | N/A |
| Supported distance functions | <ul><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanDistance</li></ul> |
| Supported filter clauses | <ul><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | No |
| StorageName supported? | No, use BsonElementAttribute instead. [See here for more info.](#data-mapping) |
| HybridSearch supported? | Yes |

## Get started

Add the MongoDB Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.MongoDB --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods from the Semantic Kernel connector packages.

```csharp
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMongoVectorStore(connectionString, databaseName);
```

Extension methods that take no parameters are also provided. These require an instance of `MongoDB.Driver.IMongoDatabase` to be separately registered with the dependency injection container.

```csharp
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMongoDatabase>(
    sp =>
    {
        var mongoClient = new MongoClient(connectionString);
        return mongoClient.GetDatabase(databaseName);
    });
builder.Services.AddMongoVectorStore();
```

You can construct a MongoDB Vector Store instance directly.

```csharp
using Microsoft.SemanticKernel.Connectors.MongoDB;
using MongoDB.Driver;

var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase(databaseName);
var vectorStore = new MongoVectorStore(database);
```

It's possible to construct a direct reference to a named collection.

```csharp
using Microsoft.SemanticKernel.Connectors.MongoDB;
using MongoDB.Driver;

var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase(databaseName);
var collection = new MongoCollection<string, Hotel>(
    database,
    "skhotels");
```

## Data mapping

The MongoDB Vector Store connector provides a default mapper when mapping data from the data model to storage.

This mapper does a direct conversion of the list of properties on the data model to the fields in MongoDB and uses `MongoDB.Bson.Serialization`
to convert to the storage schema. This means that usage of the `MongoDB.Bson.Serialization.Attributes.BsonElement` is supported if a different storage name to the
data model property name is required. The only exception is the key of the record which is mapped to a database field named `_id`, since all MongoDB
records must use this name for ids.

### Property name override

For data properties and vector properties, you can provide override field names to use in storage that is different to the
property names on the data model. This is not supported for keys, since a key has a fixed name in MongoDB.

The property name override is done by setting the `BsonElement` attribute on the data model properties.

Here is an example of a data model with `BsonElement` set.

```csharp
using Microsoft.Extensions.VectorData;
using MongoDB.Bson.Serialization.Attributes;

public class Hotel
{
    [VectorStoreKey]
    public ulong HotelId { get; set; }

    [BsonElement("hotel_name")]
    [VectorStoreData(IsIndexed = true)]
    public string HotelName { get; set; }

    [BsonElement("hotel_description")]
    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [BsonElement("hotel_description_embedding")]
    [VectorStoreVector(4, DistanceFunction = DistanceFunction.CosineSimilarity)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
```