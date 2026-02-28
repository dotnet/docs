---
title: Define your Vector Store data model
description: Describes how to create a data model with Microsoft.Extensions.VectorData to use when writing to or reading from a Vector Store.
ms.topic: reference
ms.date: 07/08/2024
---
# Define your data model

## Overview

The Vector Store connectors use a model-first approach to interacting with databases.

All methods to upsert or get records use strongly typed model classes.
The properties on these classes are decorated with attributes that indicate the purpose of each property.

> [!TIP]
> For an alternative to using attributes, see [defining your schema with a record definition](./schema-with-record-definition.md).
> [!TIP]
> For an alternative to defining your own data model, see [using Vector Store abstractions without defining your own data model](./generic-data-model.md).

Here is an example of a model that is decorated with these attributes.

```csharp
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public ulong HotelId { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string[] Tags { get; set; }
}
```

## Attributes

### VectorStoreKeyAttribute

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreKeyAttribute> attribute to indicate that your property is the key of the record.

```csharp
[VectorStoreKey]
public ulong HotelId { get; set; }
```

#### VectorStoreKeyAttribute parameters

| Parameter     | Required | Description |
|---------------|:--------:|-------------|
| <xref:Microsoft.Extensions.VectorData.VectorStoreKeyAttribute.StorageName> | No | Can be used to supply an alternative name for the property in the database. This parameter isn't supported by all connectors, for example, where alternatives like `JsonPropertyNameAttribute` are supported. |

### VectorStoreDataAttribute

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute> attribute to indicate that your property contains general data that is not a key or a vector.

```csharp
[VectorStoreData(IsIndexed = true)]
public string HotelName { get; set; }
```

#### VectorStoreDataAttribute parameters

| Parameter   | Required | Description |
|-------------|:--------:|-------------|
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> | No       | Indicates whether the property should be indexed for filtering in cases where a database requires opting in to indexing per property. The default is `false`. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsFullTextIndexed> | No | Indicates whether the property should be indexed for full text search for databases that support full text search. The default is `false`. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> | No | Can be used to supply an alternative name for the property in the database. This parameter is not supported by all connectors, for example, where alternatives like `JsonPropertyNameAttribute` are supported. |

> [!TIP]
> For more information on which connectors support <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> and what alternatives are available, see [the documentation for each connector](./out-of-the-box-connectors/index.md).

### VectorStoreVectorAttribute

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute> attribute to indicate that your property contains a vector.

```csharp
[VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
```

It's also possible to use <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute> on properties that dont' have a vector type, for example, a property of type `string`.
When a property is decorated in this way, you need to provide an <xref:Microsoft.Extensions.AI.IEmbeddingGenerator> instance to the vector store.
When upserting the record, the text that is in the `string` property is automatically converted and stored as a vector in the database.
It's not possible to retrieve a vector using this mechanism.

```csharp
[VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
public string DescriptionEmbedding { get; set; }
```

> [!TIP]
> For more information on how to use built-in embedding generation, see [Let the Vector Store generate embeddings](./embedding-generation.md#letting-the-vector-store-generate-embeddings).

#### VectorStoreVectorAttribute parameters

| Parameter  | Required | Description |
|------------|:--------:|-------------|
| `Dimensions` | Yes      | The number of dimensions that the vector has. This is required when creating a vector index for a collection. |
| <xref:Microsoft.Extensions.VectorData.IndexKind> | No | The type of index to index the vector with. Default varies by vector store type. |
| <xref:Microsoft.Extensions.VectorData.DistanceFunction> | No | The type of function to use when doing vector comparison during vector search over this vector. Default varies by vector store type. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> | No | Can be used to supply an alternative name for the property in the database. This parameter is not supported by all connectors, for example, where alternatives like `JsonPropertyNameAttribute` is supported. |

Common index kinds and distance function types are supplied as static values on the <xref:Microsoft.Extensions.VectorData.IndexKind> and <xref:Microsoft.Extensions.VectorData.DistanceFunction> classes.
Individual Vector Store implementations might also use their own index kinds and distance functions, where the database supports unusual types.

> [!TIP]
> For more information on which connectors support <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> and what alternatives are available, see [the documentation for each connector](./out-of-the-box-connectors/index.md).