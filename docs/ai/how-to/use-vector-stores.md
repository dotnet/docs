---
title: Use vector stores in .NET AI apps
description: Learn how to use Microsoft.Extensions.VectorData to store, search, and manage embeddings in vector databases for .NET AI applications.
ms.topic: how-to
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Use vector stores in .NET AI apps

The [📦 Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) package provides a unified API for working with vector stores in .NET. You can use the same code to store and search embeddings across different vector database providers.

This article shows you how to use the key features of the library.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- An understanding of [embeddings](../conceptual/embeddings.md) and [vector databases](../conceptual/vector-databases.md)

## Install the packages

Install the `Microsoft.Extensions.VectorData.Abstractions` package and a connector for your vector database. The following example uses the in-memory connector for development and testing:

```dotnetcli
dotnet add package Microsoft.Extensions.VectorData.Abstractions
dotnet add package Microsoft.SemanticKernel.Connectors.InMemory --prerelease
```

For production scenarios, replace `Microsoft.SemanticKernel.Connectors.InMemory` with the connector for your database. For a full list of available connectors, see [Available vector store connectors](../conceptual/vector-databases.md#available-vector-store-connectors).

## Define a data model

Define a .NET class to represent the records you want to store in the vector store. Use the following attributes from the <xref:Microsoft.Extensions.VectorData> namespace to describe the properties:

- <xref:Microsoft.Extensions.VectorData.VectorStoreKeyAttribute>: The primary key of each record.
- <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute>: A data property that gets stored. Set `IsIndexed = true` to enable filtering on the property.
- <xref:Microsoft.Extensions.VectorData.VectorStoreVectorAttribute>: An embedding vector property. Set the `Dimensions` parameter to match your embedding model's output size.

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Hotel.cs" id="DataModel":::

The `Dimensions` parameter in `[VectorStoreVector]` must match the output size of the embedding model you use. Common values include 1536 for `text-embedding-3-small` and 3072 for `text-embedding-3-large`.

## Create a vector store

Create an instance of the `VectorStore` implementation for your chosen database. The following example creates an in-memory vector store:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="CreateVectorStore":::

## Get a collection

Call `GetCollection<TKey, TRecord>` on the vector store to get a typed reference to a collection. Then call `EnsureCollectionExistsAsync` to create the collection if it doesn't already exist:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="GetCollection":::

The collection name maps to the underlying storage concept for your database (for example, a table in SQL Server, an index in Azure AI Search, or a container in Cosmos DB).

## Upsert records

Use `UpsertAsync` to insert or update records in the collection. If a record with the same key already exists, it gets updated:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="UpsertRecords":::

> [!IMPORTANT]
> In a real app, you should generate the embedding vectors using an `IEmbeddingGenerator` before storing the records. In the following example, the placeholder `CreateFakeEmbedding` method generates dummy vectors. For a working example with real embeddings, see [Build a .NET AI vector search app](../quickstarts/build-vector-search-app.md).

## Get records

Use `GetAsync` to retrieve a single record by its key. To retrieve multiple records, pass an `IEnumerable<TKey>` to `GetAsync`:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="GetRecord":::

To retrieve multiple records at once:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="GetBatch":::

## Perform vector search

Use `SearchAsync` to find records that are semantically similar to a query. Pass the embedding vector for your query and the number of results to return:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="SearchBasic":::

Each `VectorSearchResult<T>` contains the matching record and a similarity score. Higher scores indicate a closer semantic match.

## Filter search results

Use <xref:Microsoft.Extensions.VectorData.VectorSearchOptions`1> to filter search results before the vector comparison. You can filter on any property marked with `IsIndexed = true`:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="SearchWithFilter":::

## Delete records

To delete a single record by key, use `DeleteAsync`:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="DeleteRecord":::

## Delete a collection

To remove an entire collection from the vector store, use `EnsureCollectionDeletedAsync`:

:::code language="csharp" source="./snippets/use-vector-stores/csharp/VectorStoresExamples/Program.cs" id="DeleteCollection":::

## Switch vector store connectors

Because all connectors implement the same `VectorStore` abstract class, you can switch between them by changing the concrete type at startup. Your collection and search code remains the same.

For example, to switch from in-memory to Azure AI Search:

```csharp
// Development: in-memory
var vectorStore = new InMemoryVectorStore();

// Production: Azure AI Search (swap in at startup)
// var vectorStore = new AzureAISearchVectorStore(new SearchIndexClient(...));
```

This approach lets you develop and test locally without any external services, then deploy to a production database with minimal changes.

## Related content

- [Vector databases for .NET AI apps](../conceptual/vector-databases.md)
- [Build a .NET AI vector search app](../quickstarts/build-vector-search-app.md)
- [Data ingestion](../conceptual/data-ingestion.md)
- [Embeddings in .NET](../conceptual/embeddings.md)
