---
title: "Vector databases for .NET AI apps"
description: "Learn how vector databases extend LLM capabilities by storing and processing embeddings in .NET, and how to use Microsoft.Extensions.VectorData to build semantic search features."
ms.topic: concept-article
ms.date: 02/28/2026
ai-usage: ai-assisted
---

# Vector databases for .NET AI apps

Vector databases store and manage vector [*embeddings*](../conceptual/embeddings.md). Embeddings are numeric representations of data that preserve semantic meaning. Words, documents, images, audio, and other types of data can all be vectorized. You can use embeddings to help an AI model understand the meaning of inputs so that it can perform comparisons and transformations, such as summarizing text, finding contextually related data, or creating images from text descriptions.

For example, you can use a vector database to:

- Identify similar images, documents, and songs based on their contents, themes, sentiments, and styles.
- Identify similar products based on their characteristics, features, and user groups.
- Recommend content, products, or services based on user preferences.
- Identify the best potential options from a large pool of choices to meet complex requirements.
- Identify data anomalies or fraudulent activities that are dissimilar from predominant or normal patterns.

## Understand vector search

Vector databases provide vector search capabilities to find similar items based on their data characteristics rather than by exact matches on a property field. Vector search works by analyzing the vector representations of your data that you created using an AI embedding model such as the [Azure OpenAI embedding models](/azure/ai-services/openai/concepts/models#embeddings-models). The search process measures the distance between the data vectors and your query vector. The data vectors that are closest to your query vector are the ones that are most similar semantically.

Most modern database products support vector search alongside traditional querying; this is the case with [Azure SQL/SQL Server](/sql/sql-server/ai/vectors), [Azure Cosmos DB](/azure/cosmos-db/vector-database), [PostgreSQL](https://github.com/pgvector/pgvector-dotnet), and many other major products. As an alternative, a wide range of dedicated, specialized vector database products exist. These products are highly optimized to perform vector search, and are typically installed alongside a traditional database exclusively to handle vector search workloads.

## Vector search workflows with .NET and OpenAI

Vector databases and their search features are especially useful in [RAG pattern](../conceptual/rag.md) workflows with Azure OpenAI. This pattern lets you augment your AI model with additional semantically rich knowledge of your data. A common AI workflow using vector databases includes these steps:

1. Create embeddings for your data using an OpenAI embedding model.
1. Store and index the embeddings in a vector database or search service.
1. Convert user prompts from your application to embeddings.
1. Run a vector search across your data, comparing the user prompt embedding to the embeddings in your database.
1. Use a language model such as gpt-4o to assemble a user-friendly completion from the vector search results.

For a hands-on example of this flow, see the [Implement Azure OpenAI with RAG using vector search in a .NET app](tutorial-vector-search.md) tutorial.

Other benefits of the RAG pattern include:

- Generate contextually relevant and accurate responses to user prompts from AI models.
- Overcome LLM token limits—the heavy lifting is done through the database vector search.
- Reduce the costs from frequent fine-tuning on updated data.

## The Microsoft.Extensions.VectorData library

To use vector search from .NET, you can use your regular database driver or SDK without requiring any additional library or API. For example, on SQL Server, vector search can be performed in T-SQL when using the standard .NET driver, SqlClient. However, accessing vector search in this way is often quite low-level, requires considerable ceremony to handle serialization/deserialization, and the resulting code isn't portable across databases.

As an alternative, the [📦 Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) package provides a unified layer of abstractions for interacting with vector stores in .NET. These abstractions let you write simple, high-level code against a single API, and swap out the underlying vector store with minimal changes to your application.

The library provides the following key capabilities:

- **Seamless .NET type mapping**: Map your .NET type directly to the database, similar to an object/relational mapper.
- **Unified data model**: Define your data model once using .NET attributes and use it across any supported vector store.
- **CRUD operations**: Create, read, update, and delete records in a vector store.
- **Vector and hybrid search**: Query records by semantic similarity using vector search, or combine vector and text search for hybrid search.
- **Embedding generation management**: Configure your embedding generator once and let the library transparently handle generation.
- **Collection management**: Create, list, and delete collections (tables or indices) in a vector store.

Microsoft.Extensions.VectorData is also the building block for additional, higher-level layers which need to interact with vector database. For example, the [Microsoft.Extensions.DataIngestion](../conceptual/data-ingestion.md).

### Microsoft.Extensions.VectorData and Entity Framework Core

If you are already using Entity Framework Core to access your database, it's likely that your database provider already supports vector search, and LINQ queries can be used to express such searches; Microsoft.Extensions.VectorData isn't necessarily needed in such applications. However, most dedicated vector databases are not supported by EF Core, and Microsoft.Extensions.VectorData can provide a good experience for working with those. In addition, you may also find yourself using both EF and Microsoft.Extensions.VectorData in the same application, e.g. when using an additional layer such as Microsoft.Extensions.DataIngestion.

## Key abstractions

Here's a minimal end-to-end example that creates a collection, upserts records, and performs a vector search:

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;

// Configure an embedding generator to transform text to embeddings
IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = ...;

// Create a vector store and get a collection with the embedding generator
var vectorStore = new InMemoryVectorStore(new() { EmbeddingGenerator = embeddingGenerator });
var collection = vectorStore.GetCollection<int, Movie>("movies");
await collection.EnsureCollectionExistsAsync();

// Upsert some records
await collection.UpsertAsync(new Movie { Key = 1, Title = "The Lion King", Description = "An animated film about a young lion prince" });
await collection.UpsertAsync(new Movie { Key = 2, Title = "Inception", Description = "A thief who steals corporate secrets through dream-sharing technology" });
await collection.UpsertAsync(new Movie { Key = 3, Title = "Finding Nemo", Description = "A fish searches the ocean for his lost son" });

// Search for movies similar to the query text
await foreach (var result in collection.SearchAsync("animals in the wild", top: 2))
{
    Console.WriteLine($"{result.Record.Title} (score: {result.Score})");
}

// Define the data model
class Movie
{
    [VectorStoreKey]
    public int Key { get; set; }

    [VectorStoreData]
    public string Title { get; set; }

    [VectorStoreVector(Dimensions: 1536)]
    public string Description { get; set; }
}
```

## Vector store providers

The `Microsoft.Extensions.VectorData.Abstractions` package defines the abstractions, and separate [provider packages](/semantic-kernel/concepts/vector-store-connectors/out-of-the-box-connectors/) provide implementations for specific vector databases. Choose the provider that matches your vector database, for example, [Microsoft.SemanticKernel.Connectors.AzureAISearch](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.AzureAISearch).

> [!NOTE]
> Despite the inclusion of "SemanticKernel" in the package names, these providers have nothing to do with Semantic Kernel and are usable anywhere in .NET, including Agent Framework.

All providers implement the same <xref:Microsoft.Extensions.VectorData.VectorStore> and <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2> abstract classes, so you can switch between them without changing your application logic.

> [!TIP]
> Use the in-memory provider ([Microsoft.SemanticKernel.Connectors.InMemory](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.InMemory)) during initial development/prototyping - it doesn't require any external service or configuration, and you can swap it out for a production provider later. Avoid using the InMemory provider for testing, as there can be important differences between this provider and your production database. Consider using [testcontainers](https://dotnet.testcontainers.org/) to run tests against your production database system.

## Related content

- [Use vector stores in .NET AI apps](how-to/use-vector-stores.md)
- [Build a .NET AI vector search app](how-to/build-vector-search-app.md)
- [Implement Azure OpenAI with RAG using vector search in a .NET app](tutorial-vector-search.md)
- [Data ingestion](../conceptual/data-ingestion.md)
- [Embeddings in .NET](../conceptual/embeddings.md)
