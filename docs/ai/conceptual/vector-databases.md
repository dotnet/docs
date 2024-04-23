---
title: "Using Vector Databases to Extend LLM Capabilities"
description: "Learn how vector databases extend LLM capabilities by storing and processing embeddings in .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/12/2024

#customer intent: As a .NET developer, I want to learn how vector databases store and process embeddings in .NET so I can make more data available to LLMs in my apps.

---

# Vector databases in .NET

This article explains how vector databases help you use *embeddings* to extend the data available to LLMs in .NET.

You can use a vector database to store embeddings that you generate with AI embedding models. Embeddings have dimensions that correspond to the learned features or attributes of the embedding model you use. An embedding contains a value for each dimension, providing a semantic and mathematical representation of the source text.

Vector databases can store embeddings for text, images, and other data types. You can then perform vector analysis on the embeddings to find semantic similarities in the source data, unlocking numerous AI use cases.

## Available vector database solutions

You can use the following resources as vector database solutions in .NET:

| Resource | SK support | AOAI support |
|:-|:-|:-|
| [Azure AI Search](/azure/search/vector-search-overview) | ✔️ | ✔️ |
| [Azure Cache for Redis](/azure/azure-cache-for-redis/cache-tutorial-vector-similarity) | ❌ | ✔️ |
| [Azure Cosmos DB for MongoDB vCore](/azure/cosmos-db/mongodb/vcore/vector-search) | ✔️ | ✔️ |
| [Azure Cosmos DB for NoSQL](/azure/cosmos-db/vector-search) | ❌ | ✔️ |
| [Azure Cosmos DB for PostgreSQL](/azure/cosmos-db/postgresql/howto-use-pgvector) | ❌ | ✔️ |
| [Azure Database for PostgreSQL - Flexible Server](/azure/postgresql/flexible-server/how-to-use-pgvector) | ✔️ | ✔️ |
| [Azure SQL Database](/azure/azure-sql/database/ai-artificial-intelligence-intelligent-applications?&preserve-view=true#vector-search) | ✔️ | ✔️ |
| [Open-source vector databases](/azure/cosmos-db/mongodb/vcore/vector-search-ai) | ✔️ | ❌ |
| | | |

You use [connectors](/semantic-kernel/memories/vector-db#available-connectors-to-vector-databases) to access vector databases solutions with Semantic Kernel. Because in Semantic Kernel you build connectors into the [kernel](/semantic-kernel/agents/kernel/?tabs=Csharp), you can use [planners](/semantic-kernel/agents/planners/?tabs=Csharp) to orchestrate vector database functions.

## Related content

- [More Semantic Kernel .NET connectors](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors)
