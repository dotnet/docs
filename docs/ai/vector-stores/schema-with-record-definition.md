---
title: Defining your storage schema using a record definition
description: Describes how to create a record definition to use when writing to or reading from a Vector Store.
ms.topic: reference
ms.date: 02/28/2026
---
# Define your storage schema using a record definition

The Vector Store connectors use a model first approach to interacting with databases and allows annotating models with information that is needed for creating indexes or mapping data to the database schema.

Another way of providing this information is via record definitions, which can be defined and supplied separately to the data model. This can be useful in multiple scenarios:

- You want to use the same data model with more than one configuration.
- You want to use a built-in type, like a `Dictionary`, or an optimized format, like a dataframe, and still wants to leverage the vector store functionality.

Here's an example of how to create a record definition:

:::code language="csharp" source="./snippets/schema-with-record-definition.cs" id="UseRecordDefinition":::

When you create a definition, you always have to provide a name and type for each property in your schema, since this is required for index creation and data mapping.

To use the definition, pass it to the `GetCollection` method.

:::code language="csharp" source="./snippets/schema-with-record-definition.cs" id="DefineYourStorageSchemaUsingARecordDefin2":::

## Record property configuration classes

### VectorStoreKeyProperty

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreKeyProperty> class to indicate that your property is the key of the record.

:::code language="csharp" source="./snippets/schema-with-record-definition.cs" id="VectorStoreKeyProperty":::

#### VectorStoreKeyProperty configuration settings

| Parameter | Required | Description |
|-----------|:--------:|-------------|
| `Name` | Yes | The name of the property on the data model. Used by the mapper to automatically map between the storage schema and data model and for creating indexes. |
| `Type` | No | The type of the property on the data model. Used by the mapper to automatically map between the storage schema and data model and for creating indexes. |
| `StorageName` | No | Can be used to supply an alternative name for the property in the database. This parameter is not supported by all connectors, for example, where alternatives like `JsonPropertyNameAttribute` is supported. |

### VectorStoreDataProperty

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreDataProperty> class to indicate that your property contains general data that isn't a key or a vector.

:::code language="csharp" source="./snippets/schema-with-record-definition.cs" id="VectorStoreDataProperty":::

#### VectorStoreDataProperty configuration settings

| Parameter | Required | Description |
|-----------|:--------:|-------------|
| `Name` | Yes | The name of the property on the data model. Used by the mapper to automatically map between the storage schema and data model and for creating indexes. |
| `Type` | No | The type of the property on the data model. Used by the mapper to automatically map between the storage schema and data model and for creating indexes. |
| `IsIndexed` | No | Indicates whether the property should be indexed for filtering in cases where a database requires opting in to indexing per property. Default is false. |
| `IsFullTextIndexed` | No | Indicates whether the property should be indexed for full text search for databases that support full text search. Default is false. |
| `StorageName` | No | Can be used to supply an alternative name for the property in the database. This parameter is not supported by all connectors, for example, where alternatives like `JsonPropertyNameAttribute` is supported. |

### VectorStoreVectorProperty

Use the <xref:Microsoft.Extensions.VectorData.VectorStoreVectorProperty> class to indicate that your property contains a vector.

:::code language="csharp" source="./snippets/schema-with-record-definition.cs" id="VectorStoreVectorProperty":::

#### VectorStoreVectorProperty configuration settings

| Parameter | Required | Description |
|-----------|:--------:|-------------|
| `Name` | Yes | The name of the property on the data model. Used by the mapper to automatically map between the storage schema and data model and for creating indexes. |
| `Type` | No | The type of the property on the data model. Used by the mapper to automatically map between the storage schema and data model and for creating indexes. |
| `Dimensions` | Yes | The number of dimensions that the vector has. This is required for creating a vector index for a collection. |
| `IndexKind` | No | The type of index to index the vector with. Default varies by vector store type. |
| `DistanceFunction` | No | The type of function to use when doing vector comparison during vector search over this vector. Default varies by vector store type. |
| `StorageName` | No | Can be used to supply an alternative name for the property in the database. This parameter is not supported by all connectors, for example, where alternatives like `JsonPropertyNameAttribute` is supported. |
| `EmbeddingGenerator` | No | Allows specifying a `Microsoft.Extensions.AI.IEmbeddingGenerator` instance to use for generating embeddings automatically for the decorated property. |
