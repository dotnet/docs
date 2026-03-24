---
title: Define your vector store data model
description: Describes how to create a data model with Microsoft.Extensions.VectorData to use when writing to or reading from a vector store.
ms.topic: reference
ms.date: 02/28/2026
ai-usage: ai-assisted
---
# Define your data model

<xref:Microsoft.Extensions.VectorData> uses a model-first approach to interacting with databases.

All methods to upsert or get records use strongly typed model classes. The properties on these classes are decorated with [attributes](#attributes) that indicate the purpose of each property. Here's an example of a model that's decorated with these attributes.

:::code language="csharp" source="./snippets/conceptual/defining-your-data-model.cs" id="Overview":::

> [!TIP]
>
> - For an alternative to using attributes, see [Define your storage schema using a record definition](./schema-with-record-definition.md).

## Attributes

The attributes that define data models for vector databases are:

- [VectorStoreKeyAttribute](#vectorstorekeyattribute)
- [VectorStoreDataAttribute](#vectorstoredataattribute)
- [VectorStoreVectorAttribute](#vectorstorevectorattribute)

### VectorStoreKeyAttribute

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreKeyAttribute> attribute to indicate that your property is the primary key of the record.

:::code language="csharp" source="./snippets/conceptual/defining-your-data-model.cs" id="VectorStoreKeyAttribute":::

#### VectorStoreKeyAttribute parameters

| Parameter     | Required | Description |
|---------------|:--------:|-------------|
| <xref:Microsoft.Extensions.VectorData.VectorStoreKeyAttribute.StorageName> | No | Can be used to supply an alternative name for the property in the database. This parameter isn't supported by all providers, for example, where alternatives like `JsonPropertyNameAttribute` are supported. |

### VectorStoreDataAttribute

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute> attribute to indicate that your property contains general data that is not a key or a vector.

:::code language="csharp" source="./snippets/conceptual/defining-your-data-model.cs" id="VectorStoreDataAttribute":::

#### VectorStoreDataAttribute parameters

| Parameter   | Required | Description |
|-------------|:--------:|-------------|
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> | No       | Indicates whether the property should be indexed for filtering in cases where a database requires opting in to indexing per property. The default is `false`. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsFullTextIndexed> | No | Indicates whether the property should be indexed for full text search for databases that support full text search. The default is `false`. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> | No | Can be used to supply an alternative name for the property in the database. This parameter is not supported by all providers, for example, where alternatives like `JsonPropertyNameAttribute` are supported. |

### VectorStoreVectorAttribute

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute> attribute to indicate that your property contains a vector.

:::code language="csharp" source="./snippets/conceptual/defining-your-data-model.cs" id="VectorStoreVectorAttribute1":::

It's also possible to use <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute> on properties that don't have a vector type, for example, a property of type `string`. When a property is decorated in this way, you need to provide an <xref:Microsoft.Extensions.AI.IEmbeddingGenerator> instance to the vector store. When upserting the record, the text that's in the `string` property is automatically converted and stored as a vector in the database. (It's not possible to retrieve a vector using this mechanism.)

```csharp
[VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
public string DescriptionEmbedding { get; set; }
```

> [!TIP]
> For more information on how to use built-in embedding generation, see [Let the vector store generate embeddings](embedding-generation.md#let-the-vector-store-generate-embeddings).

#### VectorStoreVectorAttribute parameters

| Parameter    | Required | Description |
|--------------|:--------:|-------------|
| <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute.Dimensions> | Yes      | The number of dimensions that the vector has. This is required when creating a vector index for a collection. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute.IndexKind> | No | The type of index to index the vector with. Default varies by vector store type. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute.DistanceFunction> | No | The type of function to use when doing vector comparison during vector search over this vector. Default varies by vector store type. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute.StorageName> | No | Can be used to supply an alternative name for the property in the database. This parameter is not supported by all providers, for example, where alternatives like `JsonPropertyNameAttribute` is supported. |

Common index kinds and distance function types are supplied as static values on the <xref:Microsoft.Extensions.VectorData.IndexKind> and <xref:Microsoft.Extensions.VectorData.DistanceFunction> classes.
Individual vector store implementations might also use their own index kinds and distance functions, where the database supports unusual types.

## Use vector store abstractions without defining your own data model

Vector store providers use a model-first approach to interact with databases. This makes using the providers easy and simple, since your data model reflects the schema of your database records. To add any additional schema information, you can simply add attributes to your data model properties.

However, there are cases where it isn't desirable or possible to define your own data model. For example, imagine that you don't know at compile time what your database schema looks like, and the schema is only provided via configuration. Creating a data model that reflects the schema would be impossible in this case. Instead, you can map *dynamically* by using a `Dictionary<string, object?>` for the record type. Properties are added to the `Dictionary` with key as the property name and the value as the property value.

> [!NOTE]
> Most apps will simply use strongly typed .NET types to model their data. Dynamic mapping via `Dictionary<string, object?>` is for advanced, arbitrary data-mapping scenarios.

### Supply schema information when using `Dictionary`

When you use a `Dictionary`, providers still need to know what the database schema looks like. Without the schema information, the provider would not be able to create a collection or know how to map to and from the storage representation that each database uses.

A record definition can be used to provide the schema information. Unlike a data model, a record definition can be created from configuration at *runtime* when schema information isn't known at compile time.

> [!TIP]
> For information about creating a record definition, see [Defining your schema with a record definition](./schema-with-record-definition.md).

### Example

To use `Dictionary` with a provider, specify it as your data model when you create the collection. Also provide a record definition.

:::code language="csharp" source="./snippets/conceptual/dynamic-data-model.cs" id="Example1":::
