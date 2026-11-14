---
title: "Vector databases for .NET AI apps"
description: "Learn how vector databases extend LLM capabilities by storing and processing embeddings in .NET, and how to use Microsoft.Extensions.VectorData to build semantic search features."
ms.topic: concept-article
ms.date: 11/01/2026
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

## Microsoft.Extensions.VectorData library

To use vector search from .NET, you can use your regular database driver or SDK without requiring any additional library or API. For example, on SQL Server, vector search can be performed in T-SQL when using the standard .NET driver, SqlClient. However, accessing vector search in this way is often quite low-level, requires considerable ceremony to handle serialization/deserialization, and the resulting code isn't portable across databases.

As an alternative, the [Microsoft.Extensions.VectorData library](../conceptual/mevd-library.md) provides a unified layer of abstractions for interacting with vector stores in .NET.

## Key abstractions

Here's a minimal end-to-end example that creates a collection, upserts records, and performs a vector search:

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using CommunityToolkit.VectorData.InMemory;

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

    [VectorStoreVector(dimensions: 1536)]
    public string Description { get; set; }
}
```

## Vector store providers

The `Microsoft.Extensions.VectorData.Abstractions` package defines the core abstractions, and provider packages provide concrete implementations for specific vector databases and search services. Choose the provider that matches your vector database.

All providers implement the same <xref:Microsoft.Extensions.VectorData.VectorStore> and <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2> abstract classes, so you can switch between them without changing your application logic.

The following table lists common vector store providers available for .NET:

| Store or engine | Type | NuGet package | Description |
|---|---|---|---|
| In-Memory | Prototyping | [`CommunityToolkit.VectorData.InMemory`](https://www.nuget.org/packages/CommunityToolkit.VectorData.InMemory) | Fast, in-process store with no external dependencies; ideal for prototyping and local experimentation. |
| [Qdrant](https://qdrant.tech/) | Open source | [`CommunityToolkit.VectorData.Qdrant`](https://www.nuget.org/packages/CommunityToolkit.VectorData.Qdrant) | Open-source, production-ready vector search engine with extended filtering support. |
| [Redis](https://redis.io/) | Open source | [`CommunityToolkit.VectorData.Redis`](https://www.nuget.org/packages/CommunityToolkit.VectorData.Redis) | In-memory key-value data store with vector indexing and search capabilities. |
| [Chroma](https://www.trychroma.com/) | Open source | [`CommunityToolkit.VectorData.Chroma`](https://www.nuget.org/packages/CommunityToolkit.VectorData.Chroma) | Open-source embedding database built for AI applications and local development. |
| [Milvus](https://milvus.io/) | Open source | [`Microsoft.SemanticKernel.Connectors.Milvus`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Milvus) | Cloud-native, open-source vector database built for massive-scale similarity search. |
| [PostgreSQL](https://www.postgresql.org/) ([pgvector](https://github.com/pgvector/pgvector-dotnet)) | Open source / Relational | [`Pgvector`](https://www.nuget.org/packages/Pgvector) / [`Pgvector.EntityFrameworkCore`](https://www.nuget.org/packages/Pgvector.EntityFrameworkCore) | Vector similarity search extension for PostgreSQL; supports native SQL and EF Core LINQ queries. |
| [SQL Server / Azure SQL](/sql/sql-server/ai/vectors) | Relational | [`CommunityToolkit.VectorData.SqlServer`](https://www.nuget.org/packages/CommunityToolkit.VectorData.SqlServer) | Native vector search support integrated into SQL Server and Azure SQL Database. |
| [Azure AI Search](/azure/search/vector-search-overview) | Cloud search service | [`CommunityToolkit.VectorData.AzureAISearch`](https://www.nuget.org/packages/CommunityToolkit.VectorData.AzureAISearch) | Managed cloud information retrieval platform with hybrid search, semantic ranking, and vector indexing. |
| [Azure Cosmos DB](/azure/cosmos-db/vector-database) | Cloud document / NoSQL | [`CommunityToolkit.VectorData.AzureCosmosDB`](https://www.nuget.org/packages/CommunityToolkit.VectorData.AzureCosmosDB) | Distributed multi-model database with integrated vector indexing for NoSQL and MongoDB vCore APIs. |
| [MongoDB](https://www.mongodb.com/) | Document | [`Microsoft.SemanticKernel.Connectors.MongoDB`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.MongoDB) | Document database with vector search indexing for hybrid and similarity queries. |
| [Elasticsearch](https://www.elastic.co/) | Search / Analytics | [`Elastic.SemanticKernel.Connectors.Elasticsearch`](https://www.nuget.org/packages/Elastic.SemanticKernel.Connectors.Elasticsearch) | Distributed search and analytics engine with approximate nearest neighbor (ANN) vector search. |

> [!NOTE]
> Provider packages with `SemanticKernel` in their package name implement the standard `Microsoft.Extensions.VectorData` abstractions. You can use them directly in any .NET application without requiring the Semantic Kernel orchestration framework.
>
> For a comprehensive list of community and ecosystem connectors, see [Out-of-the-box Vector Store providers](/semantic-kernel/concepts/vector-store-connectors/out-of-the-box-connectors/).

> [!TIP]
> Use the in-memory provider ([CommunityToolkit.VectorData.InMemory](https://www.nuget.org/packages/CommunityToolkit.VectorData.InMemory)) during initial development and prototyping because it does not require external service configuration. Avoid using the in-memory provider for integration testing, as behavior can differ from production databases. Consider using [Testcontainers](https://dotnet.testcontainers.org/) to test against your target database engine.

## Related content

- [Use vector stores in .NET AI apps](how-to/use-vector-stores.md)
- [Build a .NET AI vector search app](how-to/build-vector-search-app.md)
- [Implement Azure OpenAI with RAG using vector search in a .NET app](tutorial-vector-search.md)
- [Data ingestion](../conceptual/data-ingestion.md)
- [Embeddings in .NET](../conceptual/embeddings.md)
