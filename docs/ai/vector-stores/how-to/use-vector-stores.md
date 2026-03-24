---
title: Use vector stores in .NET AI apps
description: Learn how to use Microsoft.Extensions.VectorData to store, search, and manage embeddings in vector databases for .NET AI applications.
ms.topic: how-to
ms.date: 02/28/2026
ai-usage: ai-generated
---

# Use vector stores in .NET AI apps

The [📦 Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) (MEVD) package provides a unified API for working with vector stores in .NET. You can use the same code to store and search embeddings across different vector database providers.

This article shows you how to use the key features of the library.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- An understanding of [embeddings](../../conceptual/embeddings.md) and [vector databases](../overview.md)

## Install the packages

Install a provider package for your vector database. The `Microsoft.Extensions.VectorData.Abstractions` package is brought in automatically as a transitive dependency. The following example uses the in-memory provider for development and testing:

```dotnetcli
dotnet package add Microsoft.SemanticKernel.Connectors.InMemory --prerelease
```

For production scenarios, replace `Microsoft.SemanticKernel.Connectors.InMemory` with the provider for your database. For available providers, see [Out-of-the-box Vector Store providers](/semantic-kernel/concepts/vector-store-connectors/out-of-the-box-connectors/). (Despite the inclusion of "SemanticKernel" in the provider package names, these providers have nothing to do with Semantic Kernel and are usable anywhere in .NET, including Agent Framework.)

## Define a data model

Define a .NET class to represent the records you want to store in the vector store. Use attributes to annotate properties in the class according to whether they represent the primary key, general data, or vector data. Here's a simple example:

:::code language="csharp" source="../snippets/conceptual/defining-your-data-model.cs" id="Overview":::

As an alternative to using attributes, you can define your schema programmatically using a <xref:Microsoft.Extensions.VectorData.VectorStoreCollectionDefinition>. This approach is useful when you want to use the same data model with different configurations, or when you can't add attributes to the data model class.

For more information, see [Define your data model](../define-your-data-model.md).

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
> In a real app, it's recommended to [let MEVD generate embeddings](../embedding-generation.md#let-the-vector-store-generate-embeddings) before storing the records.

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

Filters are expressed as LINQ expressions. The supported operations vary by provider, but all providers support common comparisons like equality, inequality, and logical `&&` and `||`.

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

For more information, see [Let the vector store generate embeddings](../embedding-generation.md#let-the-vector-store-generate-embeddings).

## Hybrid search

Some vector stores support *hybrid search*, which combines vector similarity with keyword matching. This approach can improve result relevance compared to vector-only search.

To use hybrid search, check whether your collection implements <xref:Microsoft.Extensions.VectorData.IKeywordHybridSearchable`1>. Only providers for databases that support this feature implement this interface.

For more information, see [Hybrid search using vector store providers](../hybrid-search.md).

## Delete records

To delete a single record by key, use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.DeleteAsync*>:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="DeleteRecord":::

## Delete a collection

To remove an entire collection from the vector store, use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.EnsureCollectionDeletedAsync*>:

:::code language="csharp" source="../snippets/how-to/Program.cs" id="DeleteCollection":::

## Switch vector store providers

Because all providers implement the same <xref:Microsoft.Extensions.VectorData.VectorStore> abstract class, you can switch between them by changing the concrete type at startup. For the most part, your collection and search code remains the same. However, some adjustments are usually required, for example, because different databases support different data types.

## Related content

- [Vector databases for .NET AI apps](../overview.md)
- [Build a .NET AI vector search app](build-vector-search-app.md)
- [Data ingestion](../../conceptual/data-ingestion.md)
- [Embeddings in .NET](../../conceptual/embeddings.md)
