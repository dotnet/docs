---
title: Using the SQLite Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in SQLite.
author: dmytrostruk
ms.topic: concept-article
ms.author: dmytrostruk
ms.date: 10/24/2024
---
# Using the SQLite Vector Store connector (Preview)

> [!WARNING]
> The Sqlite Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The SQLite Vector Store connector can be used to access and manage data in SQLite. The connector has the following characteristics.

| Feature Area | Support |
|--|--|
| Collection maps to | SQLite table |
| Supported key property types | <ul><li>int</li><li>long</li><li>string</li></ul> |
| Supported data property types | <ul><li>int</li><li>long</li><li>short</li><li>string</li><li>bool</li><li>float</li><li>double</li><li>byte[]</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types | N/A |
| Supported distance functions | <ul><li>CosineDistance</li><li>ManhattanDistance</li><li>EuclideanDistance</li></ul> |
| Supported filter clauses | <ul><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed    supported? | No |
| IsFullTextIndexed supported? | No |
| StorageName supported? | Yes |
| HybridSearch supported? | No |

## Get started

Add the SQLite Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.SqliteVec --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods from the Semantic Kernel connector packages.

```csharp
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqliteVectorStore(_ => "Data Source=:memory:");
```

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqliteVectorStore(_ => "Data Source=:memory:")
```

You can construct a SQLite Vector Store instance directly.

```csharp
using Microsoft.SemanticKernel.Connectors.SqliteVec;

var vectorStore = new SqliteVectorStore("Data Source=:memory:");
```

It's possible to construct a direct reference to a named collection.

```csharp
using Microsoft.SemanticKernel.Connectors.SqliteVec;

var collection = new SqliteCollection<string, Hotel>("Data Source=:memory:", "skhotels");
```

## Data mapping

The SQLite Vector Store connector provides a default mapper when mapping from the data model to storage.
This mapper does a direct conversion of the list of properties on the data model to the columns in SQLite.

With the vector search extension, vectors are stored in virtual tables, separately from key and data properties.
By default, the virtual table with vectors will use the same name as the table with key and data properties, but with a `vec_` prefix. For example, if the collection name in `SqliteCollection` is `skhotels`, the name of the virtual table with vectors will be `vec_skhotels`. It's possible to override the virtual table name by using the `SqliteVectorStoreOptions.VectorVirtualTableName` or `SqliteCollectionOptions<TRecord>.VectorVirtualTableName` properties.

### Property name override

You can provide override property names to use in storage that is different to the property names on the data model.
The property name override is done by setting the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> option via the data model property attributes or record definition.

Here is an example of a data model with <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> set on its attributes and how that will be represented in a SQLite command.

```csharp
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public ulong HotelId { get; set; }

    [VectorStoreData(StorageName = "hotel_name")]
    public string? HotelName { get; set; }

    [VectorStoreData(StorageName = "hotel_description")]
    public string? Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineDistance)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
```

```tsql
CREATE TABLE Hotels (
    HotelId INTEGER PRIMARY KEY,
    hotel_name TEXT,
    hotel_description TEXT
);

CREATE VIRTUAL TABLE vec_Hotels (
    HotelId INTEGER PRIMARY KEY,
    DescriptionEmbedding FLOAT[4] distance_metric=cosine
);
```