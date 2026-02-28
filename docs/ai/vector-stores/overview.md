---
title: "Vector databases for .NET AI apps"
description: "Learn how vector databases extend LLM capabilities by storing and processing embeddings in .NET, and how to use Microsoft.Extensions.VectorData to build semantic search features."
ms.topic: concept-article
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Vector databases for .NET AI apps

Vector databases store and manage vector [*embeddings*](embeddings.md). Embeddings are numeric representations of data that preserve semantic meaning. Words, documents, images, audio, and other types of data can all be vectorized. You can use embeddings to help an AI model understand the meaning of inputs so that it can perform comparisons and transformations, such as summarizing text, finding contextually related data, or creating images from text descriptions.

For example, you can use a vector database to:

- Identify similar images, documents, and songs based on their contents, themes, sentiments, and styles.
- Identify similar products based on their characteristics, features, and user groups.
- Recommend content, products, or services based on user preferences.
- Identify the best potential options from a large pool of choices to meet complex requirements.
- Identify data anomalies or fraudulent activities that are dissimilar from predominant or normal patterns.

## Understand vector search

Vector databases provide vector search capabilities to find similar items based on their data characteristics rather than by exact matches on a property field. Vector search works by analyzing the vector representations of your data that you created using an AI embedding model such as the [Azure OpenAI embedding models](/azure/ai-services/openai/concepts/models#embeddings-models). The search process measures the distance between the data vectors and your query vector. The data vectors that are closest to your query vector are the ones that are most similar semantically.

Some services such as [Azure Cosmos DB for MongoDB vCore](/azure/cosmos-db/mongodb/vcore/vector-search) provide native vector search capabilities for your data. Other databases can be enhanced with vector search by indexing the stored data using a service such as Azure AI Search, which can scan and index your data to provide vector search capabilities.

## Vector search workflows with .NET and OpenAI

Vector databases and their search features are especially useful in [RAG pattern](rag.md) workflows with Azure OpenAI. This pattern allows you to augment or enhance your AI model with additional semantically rich knowledge of your data. A common AI workflow using vector databases includes the following steps:

1. Create embeddings for your data using an OpenAI embedding model.
1. Store and index the embeddings in a vector database or search service.
1. Convert user prompts from your application to embeddings.
1. Run a vector search across your data, comparing the user prompt embedding to the embeddings in your database.
1. Use a language model such as GPT-4 to assemble a user-friendly completion from the vector search results.

For a hands-on example of this flow, see the [Implement Azure OpenAI with RAG using vector search in a .NET app](../tutorials/tutorial-ai-vector-search.md) tutorial.

Other benefits of the RAG pattern include:

- Generate contextually relevant and accurate responses to user prompts from AI models.
- Overcome LLM token limits—the heavy lifting is done through the database vector search.
- Reduce the costs from frequent fine-tuning on updated data.

## The Microsoft.Extensions.VectorData library

The [📦 Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) package provides a unified layer of abstractions for interacting with vector stores in .NET. These abstractions let you write code against a single API and swap out the underlying vector store with minimal changes to your application.

The library provides the following key capabilities:

- **Unified data model**: Define your data model once using .NET attributes and use it across any supported vector store.
- **CRUD operations**: Create, read, update, and delete records in a vector store.
- **Vector and text search**: Query records by semantic similarity using vector search, or by keyword using text search.
- **Collection management**: Create, list, and delete collections (tables or indices) in a vector store.

### Key abstractions

The `Microsoft.Extensions.VectorData.Abstractions` library exposes the following main abstract classes:

- <xref:Microsoft.Extensions.VectorData.VectorStore>: The top-level class for a vector database. Use it to retrieve and manage collections.
- <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2>: Represents a named collection of records within a vector store. Use it to perform CRUD and search operations. Also inherits from `IVectorSearchable<TRecord>`.
- `IKeywordHybridSearchable<TRecord>`: Implemented by collections that support hybrid search combining vector similarity with keyword matching.

For a step-by-step guide covering data model definition, CRUD operations, vector search, filtering, hybrid search, and embedding generation, see [Use vector stores in .NET AI apps](how-to/use-vector-stores.md).

## Available vector store connectors

The `Microsoft.Extensions.VectorData.Abstractions` package defines the abstractions, and separate connector packages implement them for specific vector databases. Choose the connector that matches your vector database:

| Connector | NuGet package |
|---|---|
| In-memory (for testing/development) | [Microsoft.SemanticKernel.Connectors.InMemory](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.InMemory) |
| Azure AI Search | [Microsoft.SemanticKernel.Connectors.AzureAISearch](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.AzureAISearch) |
| Azure Cosmos DB (NoSQL) | [Microsoft.SemanticKernel.Connectors.CosmosNoSQL](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.CosmosNoSQL) |
| Azure Cosmos DB (MongoDB) | [Microsoft.SemanticKernel.Connectors.CosmosMongoDB](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.CosmosMongoDB) |
| Azure SQL / SQL Server | [Microsoft.SemanticKernel.Connectors.SqlServer](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.SqlServer) |
| Couchbase | [CouchbaseVectorStore.SemanticKernel](https://www.nuget.org/packages/CouchbaseVectorStore.SemanticKernel) |
| Elasticsearch | [Elastic.SemanticKernel.Connectors.Elasticsearch](https://www.nuget.org/packages/Elastic.SemanticKernel.Connectors.Elasticsearch) |
| MongoDB | [Microsoft.SemanticKernel.Connectors.MongoDB](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.MongoDB) |
| Oracle | [OracleVectorStore.SemanticKernel](https://www.nuget.org/packages/OracleVectorStore.SemanticKernel) |
| Pinecone | [Microsoft.SemanticKernel.Connectors.Pinecone](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Pinecone) |
| PostgreSQL (pgvector) | [Microsoft.SemanticKernel.Connectors.PgVector](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.PgVector) |
| Qdrant | [Microsoft.SemanticKernel.Connectors.Qdrant](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Qdrant) |
| Redis | [Microsoft.SemanticKernel.Connectors.Redis](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Redis) |
| SQLite | [Microsoft.SemanticKernel.Connectors.SqliteVec](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.SqliteVec) |
| Weaviate | [Microsoft.SemanticKernel.Connectors.Weaviate](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Weaviate) |

All connectors implement the same <xref:Microsoft.Extensions.VectorData.VectorStore> and <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> abstract classes, so you can switch between them without changing your application logic.

> [!TIP]
> Use the in-memory connector (`Microsoft.SemanticKernel.Connectors.InMemory`) during development and testing. It doesn't require any external service or configuration, and you can swap it out for a production connector later.

> [!IMPORTANT]
> Not all connectors are maintained by the Microsoft Semantic Kernel team. When evaluating a connector, review its quality, licensing, support, and compatibility to ensure it meets your requirements.

## Related content

- [Use vector stores in .NET AI apps](how-to/use-vector-stores.md)
- [Build a .NET AI vector search app](../quickstarts/build-vector-search-app.md)
- [Implement Azure OpenAI with RAG using vector search in a .NET app](../tutorials/tutorial-ai-vector-search.md)
- [Data ingestion](../conceptual/data-ingestion.md)
- [Embeddings in .NET](../conceptual/embeddings.md)