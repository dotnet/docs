---
title: Vector search using Vector Store connectors
description: Describes the different options you can use when doing a vector search using Vector Store connectors.
ms.topic: concept-article
ms.date: 02/28/2026
---
# Vector search using Vector Store connectors

The <xref:Microsoft.Extensions.VectorData> library provides vector search capabilities as part of its Vector Store abstractions. These capabilities include filtering and many other options.

> [!TIP]
> To see how you can search without generating embeddings yourself, see [Let the Vector Store generate embeddings](./embedding-generation.md#letting-the-vector-store-generate-embeddings).

## Vector search

The <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.SearchAsync*> method allows searching using data that has already been vectorized. This method takes a vector and an optional <xref:Microsoft.Extensions.VectorData.VectorSearchOptions`1> class as input. <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.SearchAsync*> is available on the following types:

- <xref:Microsoft.Extensions.VectorData.IVectorSearchable`1>
- <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2>

Note that <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2> implements `IVectorSearchable<TRecord>`.

Assuming you have a collection that already contains data, you can easily search it. Here is an example using Qdrant.

:::code language="csharp" source="./snippets/vector-search.cs" id="VectorSearch":::

> [!TIP]
> For more information on how to generate embeddings see [embedding generation](./embedding-generation.md).

## Supported vector types

<xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.SearchAsync*> takes a generic type as the vector parameter. The types of vectors supported by each data store vary.

It's also important for the search vector type to match the target vector that is being searched, for example, if you have two vectors on the same record with different vector types, make sure that the search vector you supply matches the type of the specific vector you are targeting. For information on how to pick a target vector if you have more than one per record, see [VectorProperty](#vectorproperty).

## Vector search options

The following options can be provided using the `VectorSearchOptions<TRecord>` class.

### VectorProperty

Use the `VectorProperty` option to specify the vector property to target during the search. If none is provided and the data model contains only one vector, that vector will be used. If the data model contains no vector or multiple vectors and `VectorProperty` is not provided, the search method throws an exceptoin.

:::code language="csharp" source="./snippets/vector-search.cs" id="VectorProperty":::

### `Top` and `Skip`

The `Top` and `Skip` options allow you to limit the number of results to the top `n` results and
to skip a number of results from the top of the resultset. You can use `Top` and `Skip` to do paging if you want to retrieve a large number of results using separate calls.

:::code language="csharp" source="./snippets/vector-search.cs" id="TopAndSkip":::

The default value for `Skip` is 0.

### IncludeVectors

The `IncludeVectors` option allows you to specify whether you want to return vectors in the search results.
If `false`, the vector properties on the returned model are left null. Using `false` can significantly reduce the amount of data retrieved from the vector store during search, making searches more efficient.

The default value for `IncludeVectors` is `false`.

:::code language="csharp" source="./snippets/vector-search.cs" id="IncludeVectors":::

### Filter

The vector search filter option can be used to provide a filter for filtering the records in the chosen collection before applying the vector search. This has multiple benefits:

- Reduce latency and processing cost, since only records remaining after filtering need to be compared with the search vector and therefore fewer vector comparisons have to be done.
- Limit the resultset for for example, access control purposes, by excluding data that the user shouldn't have access to.

For fields to be used for filtering, many vector stores require those fields to be indexed first. Some vector stores will allow filtering using any field, but might optionally allow indexing to improve filtering performance.

If you're creating a collection via the Vector Store abstractions and you want to enable filtering on a field, set the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> property to `true` when defining your data model or when creating your record definition.

> [!TIP]
> For more information on how to set the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> property, see [VectorStoreDataAttribute parameters](./defining-your-data-model.md#vectorstoredataattribute-parameters) or [VectorStoreDataProperty configuration settings](./schema-with-record-definition.md#vectorstoredataproperty-configuration-settings).

Filters are expressed using LINQ expressions based on the type of the data model. The set of LINQ expressions supported will vary depending on the functionality supported by each database, but all databases support a broad base of common expressions, for example, equals, not equals, `and`, and `or`.

:::code language="csharp" source="./snippets/vector-search.cs" id="Filter":::
