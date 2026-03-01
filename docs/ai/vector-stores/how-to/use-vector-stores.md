---
title: Use vector stores in .NET AI apps
description: Learn how to use Microsoft.Extensions.VectorData to store, search, and manage embeddings in vector databases for .NET AI applications.
ms.topic: how-to
ms.date: 02/28/2026
ai-usage: ai-generated
---

# Use vector stores in .NET AI apps

The [📦 Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) package provides a unified API for working with vector stores in .NET. You can use the same code to store and search embeddings across different vector database providers.

This article shows you how to use the key features of the library.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- An understanding of [embeddings](../../conceptual/embeddings.md) and [vector databases](../overview.md)

## Install the packages

Install the `Microsoft.Extensions.VectorData.Abstractions` package and a connector for your vector database. The following example uses the in-memory connector for development and testing:

```dotnetcli
dotnet add package Microsoft.Extensions.VectorData.Abstractions
dotnet add package Microsoft.SemanticKernel.Connectors.InMemory --prerelease
```

For production scenarios, replace `Microsoft.SemanticKernel.Connectors.InMemory` with the connector for your database. For a full list of available connectors, see [Available vector store connectors](../overview.md#available-vector-store-connectors).

## Define a data model

Define a .NET class to represent the records you want to store in the vector store. Use the following attributes from the <xref:Microsoft.Extensions.VectorData> namespace to describe the properties:

- <xref:Microsoft.Extensions.VectorData.VectorStoreKeyAttribute>: The primary key of each record.
- <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute>: A data property that gets stored. Set `IsIndexed = true` to enable filtering on the property, or `IsFullTextIndexed = true` to enable full-text search on it.
- <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute>: An embedding vector property. Set the `Dimensions` parameter to match your embedding model's output size.

:::code language="csharp" source="../snippets/how-to/Hotel.cs" id="DataModel":::

The `Dimensions` parameter in `[VectorStoreVector]` must match the output size of the embedding model you use. Common values include 1536 for `text-embedding-3-small` and 3072 for `text-embedding-3-large`.

### Attribute parameters

The following tables describe all available parameters for each attribute.

#### VectorStoreKeyAttribute parameters

| Parameter | Required | Description |
|---|---|---|
| <xref:Microsoft.Extensions.VectorData.VectorStoreKeyAttribute.StorageName> | No | An alternative name for the property in storage. Not supported by all connectors. |

#### VectorStoreDataAttribute parameters

| Parameter | Required | Description |
|---|---|---|
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> | No | Whether to index this property for filtering. Default is `false`. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsFullTextIndexed> | No | Whether to index this property for full-text search. Default is `false`. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> | No | An alternative name for the property in storage. Not supported by all connectors. |

#### VectorStoreVectorAttribute parameters

| Parameter | Required | Description |
|---|---|---|
| <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute.Dimensions> | Yes (for collection creation) | The number of dimensions in the vector. Must match your embedding model. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute.IndexKind> | No | The type of index to use. Defaults vary by connector. Common values: `Hnsw`, `Flat`. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute.DistanceFunction> | No | The distance function for similarity comparisons. Defaults vary by connector. Common values: `CosineSimilarity`, `DotProductSimilarity`, `EuclideanDistance`. |
| <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute.StorageName> | No | An alternative name for the property in storage. Not supported by all connectors. |

## Define a schema programmatically

As an alternative to using attributes, you can define your schema programmatically using a <xref:Microsoft.Extensions.VectorData.VectorStoreCollectionDefinition>. This approach is useful when you want to use the same data model with different configurations, or when you can't add attributes to the data model class.

For more information, see [Define your storage schema using a record definition](../schema-with-record-definition.md).

## Create a vector store

Create an instance of the <xref:Microsoft.Extensions.VectorData.VectorStore> implementation for your chosen database. The following example creates an in-memory vector store:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="CreateVectorStore":::

## Get a collection

Call <xref:Microsoft.Extensions.VectorData.VectorStore.GetCollection*> on the <xref:Microsoft.Extensions.VectorData.VectorStore> to get a typed <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2> reference. Then call <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.EnsureCollectionExistsAsync*> to create the collection if it doesn't already exist:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="GetCollection":::

The collection name maps to the underlying storage concept for your database (for example, a table in SQL Server, an index in Azure AI Search, or a container in Cosmos DB).

## Upsert records

Use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.UpsertAsync*> to insert or update records in the collection. If a record with the same key already exists, it gets updated:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="UpsertRecords":::

> [!IMPORTANT]
> In a real app, generate the embedding vectors using an `IEmbeddingGenerator` before storing the records. For a working example with real embeddings, see [Build a .NET AI vector search app](build-vector-search-app.md).

## Get records

Use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.GetAsync*> to retrieve a single record by its key. To retrieve multiple records, pass an `IEnumerable<TKey>` to <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.GetAsync*>:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="GetRecord":::

To retrieve multiple records at once:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="GetBatch":::

## Perform vector search

Use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.SearchAsync*> to find records that are semantically similar to a query. Pass the embedding vector for your query and the number of results to return:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="SearchBasic":::

Each <xref:Microsoft.Extensions.VectorData.VectorSearchResult`1> contains the matching record and a similarity score. Higher scores indicate a closer semantic match.

## Filter search results

Use <xref:Microsoft.Extensions.VectorData.VectorSearchOptions`1> to filter search results before the vector comparison. You can filter on any property marked with `IsIndexed = true`:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="SearchWithFilter":::

Filters are expressed as LINQ expressions. The supported operations vary by connector, but all connectors support common comparisons like equality, inequality, and logical `&&` and `||`.

## Control search behavior with VectorSearchOptions

Use <xref:Microsoft.Extensions.VectorData.VectorSearchOptions`1> to control various aspects of vector search behavior:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="SearchOptions":::

The following table describes the available options:

| Option           | Description                                                                                    |
|------------------|------------------------------------------------------------------------------------------------|
| `Filter`         | A LINQ expression to filter records before vector comparison.                                  |
| `VectorProperty` | The vector property to search on. Required when the data model has multiple vector properties. |
| `Skip`           | Number of results to skip before returning. Useful for paging. Default is `0`.                 |
| `IncludeVectors` | Whether to include vector data in the returned records. Omitting vectors reduces data transfer. Default is `false`. |

For more information, see [Vector search options](../vector-search.md#vector-search-options).

## Use built-in embedding generation

Instead of generating embeddings manually before each upsert, you can configure an `IEmbeddingGenerator` on the vector store or collection. When you do, declare your vector property as a `string` type (the source text) and the store generates the embedding automatically.

For more information, see [Let the Vector Store generate embeddings](../embedding-generation.md#let-the-vector-store-generate-embeddings).

## Hybrid search

Some vector stores support *hybrid search*, which combines vector similarity with keyword matching. This approach can improve result relevance compared to vector-only search.

To use hybrid search, check whether your collection implements <xref:Microsoft.Extensions.VectorData.IKeywordHybridSearchable`1>. Only connectors for databases that support this feature implement this interface.

For more information, see [Hybrid search using Vector Store connectors](../hybrid-search.md).

## Delete records

To delete a single record by key, use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.DeleteAsync*>:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="DeleteRecord":::

## Delete a collection

To remove an entire collection from the vector store, use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.EnsureCollectionDeletedAsync*>:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="DeleteCollection":::

## Switch vector store connectors

Because all connectors implement the same <xref:Microsoft.Extensions.VectorData.VectorStore> abstract class, you can switch between them by changing the concrete type at startup. Your collection and search code remains the same. This approach lets you develop and test locally without any external services, then deploy to a production database with minimal changes.

## Related content

- [Vector databases for .NET AI apps](../overview.md)
- [Build a .NET AI vector search app](build-vector-search-app.md)
- [Data ingestion](../../conceptual/data-ingestion.md)
- [Embeddings in .NET](../../conceptual/embeddings.md)
