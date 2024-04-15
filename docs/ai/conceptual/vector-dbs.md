---
title: "Understanding vector databases in .NET"
description: "Understand how vector databases support embeddings in .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/10/2024

#customer intent: As a .NET developer, I want to understand vector databases in .NET so I can generate and store embeddings.

---

# Understanding vector databases in .NET

This article explains how vector databases help you to manage embeddings in .NET.

You can use a vector database to generate and store embeddings with AI models. Embedding vectors have dimensions that correspond to the learned features or attributes of an AI model. An embedding contains a value for each dimension, providing a semantic and mathematical representation of the associated text. You generate embeddings, then store and process them using a suitable vector database solution.

Vector databases can help you generate embeddings for text, images, and other data types. You can then use the embeddings for semantic analysis of the source data, which enhances and enables AI model capabilities.

## Available vector database solutions

You can use the following resources as vector database solutions in .NET:

| Resource | SK support | AOAI support |
|:-|:-|:-|
| [Azure AI Search](/azure/search/vector-search-overview) | y | y |
| [Azure Cache for Redis](/azure/azure-cache-for-redis/cache-tutorial-vector-similarity) | n | y |
| [Azure Cosmos DB for MongoDB vCore](/azure/cosmos-db/mongodb/vcore/vector-search) | y | y |
| [Azure Cosmos DB for NoSQL](/azure/cosmos-db/vector-search) | n | y |
| [Azure Cosmos DB for PostgreSQL](/azure/cosmos-db/postgresql/howto-use-pgvector) | n | y |
| [Azure Database for PostgreSQL - Flexible Server](/azure/postgresql/flexible-server/how-to-use-pgvector) | y | y |
| [Azure SQL Database](/azure/azure-sql/database/ai-artificial-intelligence-intelligent-applications?&preserve-view=true#vector-search) | y | y |
| [Open-source vector databases](/azure/cosmos-db/mongodb/vcore/vector-search-ai) | y | n |
| | | |

You use [connectors](/semantic-kernel/memories/vector-db#available-connectors-to-vector-databases) to access vector databases solutions with Semantic Kernel. Because you build connectors into the [kernel](/semantic-kernel/agents/kernel/?tabs=Csharp), you can use [planners](/semantic-kernel/agents/planners/?tabs=Csharp) to orchestrate vector database functions.

## Related content

- [More Semantic Kernel .NET connectors](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors)