---
title: Using the Qdrant Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Qdrant.
ms.topic: concept-article
ms.date: 07/08/2024
---
# Using the Qdrant connector (Preview)

> [!WARNING]
> The Qdrant Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Qdrant Vector Store connector can be used to access and manage data in Qdrant. The connector has the following characteristics.

| Feature Area                 | Support                                                           |
|------------------------------|-------------------------------------------------------------------|
| Collection maps to           | Qdrant collection with payload indices for filterable data fields |
| Supported key property types | <ul><li>ulong</li><li>Guid</li></ul>                              |
| Supported data property types | <ul><li>string</li><li>int</li><li>long</li><li>double</li><li>float</li><li>bool</li><li>*and enumerables of each of these types*</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types | Hnsw |
| Supported distance functions | <ul><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanDistance</li><li>ManhattanDistance</li></ul> |
| Supported filter clauses | <ul><li>AnyTagEqualTo</li><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes (configurable) |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | Yes |
| StorageName supported? | Yes |
| HybridSearch supported? | Yes |

## Get started

Add the Qdrant Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.Qdrant --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="GetStarted1":::

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="GetStarted2":::

Extension methods that take no parameters are also provided. These require an instance of the `Qdrant.Client.QdrantClient` class to be separately registered with the dependency injection container.

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="GetStarted3":::

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="GetStarted4":::

You can construct a Qdrant Vector Store instance directly.

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="GetStarted5":::

It's possible to construct a direct reference to a named collection.

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="GetStarted6":::

## Data mapping

The Qdrant connector provides a default mapper when mapping data from the data model to storage.
Qdrant requires properties to be mapped into id, payload and vector(s) groupings.
The default mapper uses the model annotations or record definition to determine the type of each property and to do this mapping.

- The data model property annotated as a key will be mapped to the Qdrant point id.
- The data model properties annotated as data will be mapped to the Qdrant point payload object.
- The data model properties annotated as vectors will be mapped to the Qdrant point vector object.

### Property name override

For data properties and vector properties (if using named vectors mode), you can provide override field names to use in storage that is different to the
property names on the data model. This is not supported for keys, since a key has a fixed name in Qdrant. It's also not supported for vectors in *single
unnamed vector* mode, since the vector is stored under a fixed name.

The property name override is done by setting the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> option via the data model attributes or record definition.

Here is an example of a data model with <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> set on its attributes and how that will be represented in Qdrant.

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="PropertyNameOverride":::

```json
{
    "id": 1,
    "payload": { "hotel_name": "Hotel Happy", "hotel_description": "A place where everyone can be happy." },
    "vector": {
        "hotel_description_embedding": [0.9, 0.1, 0.1, 0.1],
    }
}
```

### Qdrant vector modes

Qdrant supports two modes for vector storage and the Qdrant Connector with default mapper supports both modes.
The default mode is *single unnamed vector*.

#### Single unnamed vector

With this option a collection might only contain a single vector and it will be unnamed in the storage model in Qdrant.
Here is an example of how an object is represented in Qdrant when using *single unnamed vector* mode:

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="SingleUnnamedVector":::

```json
{
    "id": 1,
    "payload": { "HotelName": "Hotel Happy", "Description": "A place where everyone can be happy." },
    "vector": [0.9, 0.1, 0.1, 0.1]
}
```

#### Named vectors

If using the named vectors mode, it means that each point in a collection might contain more than one vector, and each will be named.
Here is an example of how an object is represented in Qdrant when using *named vectors* mode:

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="NamedVectors1":::

```json
{
    "id": 1,
    "payload": { "HotelName": "Hotel Happy", "Description": "A place where everyone can be happy." },
    "vector": {
        "HotelNameEmbedding": [0.9, 0.5, 0.5, 0.5],
        "DescriptionEmbedding": [0.9, 0.1, 0.1, 0.1],
    }
}
```

To enable named vectors mode, pass this as an option when constructing a Vector Store or collection.
The same options can also be passed to any of the provided dependency injection container extension methods.

:::code language="csharp" source="./snippets/qdrant-connector.cs" id="NamedVectors2":::