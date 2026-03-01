---
title: Hybrid search using Vector Store connectors
description: Describes the different options you can use when doing a hybrid search using Vector Store connectors.
ms.topic: concept-article
ms.date: 02/28/2026
---
# Hybrid search using Vector Store connectors

The <xref:Microsoft.Extensions.VectorData> library provides hybrid search capabilities, including filtering, as part of its Vector Store abstractions.

The hybrid search is based on a vector search and a keyword search, both of which are executed in parallel. The hybrid search returns a union of the two result sets. (Sparse vector&ndash;based hybrid search isn't currently supported.)

To execute a hybrid search, your database schema needs to have a vector field and a string field with full-text search capabilities enabled. If you're creating a collection using the Vector Store connectors, enable the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsFullTextIndexed> option on the string field that you want to target for the keyword search.

> [!TIP]
> For more information on how to enable <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsFullTextIndexed>, see [VectorStoreDataAttribute parameters](./defining-your-data-model.md#vectorstoredataattribute-parameters) or [VectorStoreDataProperty configuration settings](./schema-with-record-definition.md#vectorstoredataproperty-configuration-settings)

## Hybrid search

The <xref:Microsoft.Extensions.VectorData.IKeywordHybridSearchable`1.HybridSearchAsync``1(``0,System.Collections.Generic.ICollection{System.String},System.Int32,Microsoft.Extensions.VectorData.HybridSearchOptions{`0},System.Threading.CancellationToken)?displayProperty=nameWithType> method searches using a vector and an `ICollection` of string keywords. It also takes an optional `HybridSearchOptions<TRecord>` class as input.

Only connectors for databases that support vector plus keyword hybrid search implement [the interface](xref:Microsoft.Extensions.VectorData.IKeywordHybridSearchable`1) that provides this method.

The following example shows how to perform a hybrid search on a collection in a Qdrant database.

:::code language="csharp" source="./snippets/conceptual/hybrid-search.cs" id="HybridSearch":::

> [!TIP]
> For more information on how to generate embeddings, see [embedding generation](./embedding-generation.md).

## Supported vector types

<xref:Microsoft.Extensions.VectorData.IKeywordHybridSearchable`1.HybridSearchAsync*> takes a generic type as the vector parameter.
The types of vectors supported by each data store vary.

It's also important for the search vector type to match the target vector that's being searched. For example, if you have two vectors
on the same record with different vector types, make sure that the search vector you supply matches the type of the specific vector
you're targeting. For information on how to pick a target vector if you have more than one per record, see [VectorProperty and AdditionalProperty](#vectorproperty-and-additionalproperty).

## Hybrid search options

The following options can be provided using the <xref:Microsoft.Extensions.VectorData.HybridSearchOptions`1> class.

### VectorProperty and AdditionalProperty

Use the <xref:Microsoft.Extensions.VectorData.HybridSearchOptions`1.VectorProperty> and <xref:Microsoft.Extensions.VectorData.HybridSearchOptions`1.AdditionalProperty> options to specify the vector property and full-text search property to target during the search.

When no `VectorProperty` is provided:

- If the data model contains only one vector, that vector is used.
- If the data model contains no vector or multiple vectors, the search method throws an exception.

When no `AdditionalProperty` is provided:

- If the data model contains only one full-text search property, that property is used.
- If the data model contains no full-text search property or multiple full-text search properties, the search method throws an exception.

:::code language="csharp" source="./snippets/conceptual/hybrid-search.cs" id="VectorPropertyAndAdditionalProperty":::

### `Top` and `Skip`

The `Top` and `Skip` options allow you to limit the number of results to the top `n` results and to skip a number of results from the top of the result set. You can use `Top` and `Skip` to do paging if you want to retrieve a large number of results using separate calls.

:::code language="csharp" source="./snippets/conceptual/hybrid-search.cs" id="TopAndSkip":::

The default value for `Skip` is 0.

### IncludeVectors

The `IncludeVectors` option allows you to specify whether you want to return vectors in the search results. If `false`, the vector properties on the returned model are left null. Using `false` can significantly reduce the amount of data retrieved from the vector store during search, making searches more efficient.

The default value for `IncludeVectors` is `false`.

:::code language="csharp" source="./snippets/conceptual/hybrid-search.cs" id="IncludeVectors":::

### Filter

Use the vector search filter option to provide a filter for filtering the records in the chosen collection before applying the vector search. This has multiple benefits:

- Reduce latency and processing cost, since only records remaining after filtering need to be compared with the search vector and therefore fewer vector comparisons have to be done.
- Limit the result set for by excluding data that the user shouldn't have access to. This can be useful for access-control purposes.

For fields to be used for filtering, many vector stores require them to be indexed first. Some vector stores allow filtering using any field, but might optionally allow indexing to improve filtering performance.

If you're creating a collection via the Vector Store abstractions and you want to enable filtering on a field, set the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> property to `true` when defining your data model or when creating your record definition.

> [!TIP]
> For more information on how to set the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> property, see [VectorStoreDataAttribute parameters](./defining-your-data-model.md#vectorstoredataattribute-parameters) or [VectorStoreDataProperty configuration settings](./schema-with-record-definition.md).

Filters are expressed using LINQ expressions based on the type of the data model. The set of LINQ expressions supported varies depending on the functionality supported by each database, but all databases support a broad base of common expressions, for example, `equals`, `not equals`, `and`, and `or`.

:::code language="csharp" source="./snippets/conceptual/hybrid-search.cs" id="Filter":::
