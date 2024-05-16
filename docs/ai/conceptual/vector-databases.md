---
title: "Using Vector Databases to Extend LLM Capabilities"
description: "Learn how vector databases extend LLM capabilities by storing and processing embeddings in .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 05/16/2024

#customer intent: As a .NET developer, I want to learn how vector databases store and process embeddings in .NET so I can make more data available to LLMs in my apps.

---

# Vector databases in .NET

A vector database is designed to store and manage vector [embeddings](embeddings.md). Embeddings are numeric representations of non-numeric data that preserve semantic meaning. Words, phrases, or entire documents, and images, audio, and other types of data can all be vectorized. You can use embeddings to help an AI model understand the meaning of inputs so that it can perform comparisons and transformations, such as summarizing text or creating images from text descriptions.

Vector databases can store embeddings for text, images, and other data types. You can then perform vector analysis on the embeddings to find semantic similarities in the source data. For example, you can use a vector database to:

- Identify similar images, documents, and songs based on their contents, themes, sentiments, and styles
- Identify similar products based on their characteristics, features, and user groups
- Recommend content, products, or services based on user preferences
- Identify the best potential options from a large pool of choices to meet complex requirements
- Identify data anomalies or fraudulent activities that are dissimilar from predominant or normal patterns

## Understand vector search

Vector databases provide vector search capabilities to help you find similar items based on their data characteristics rather than by exact matches on a property field. This technique is useful in application scenarios such as searching for similar text, finding related images, making recommendations, or even detecting anomalies. Vector search works by taking the vector representations (lists of numbers) of your data that you created by using a machine learning model by using an embeddings API, such as Azure OpenAI Embeddings. It then measures the distance between the data vectors and your query vector. The data vectors that are closest to your query vector are the ones that are found to be most similar semantically. Using a native vector search feature offers an efficient way to store, index, and search high-dimensional vector data directly alongside other application data.

Some services such as Azure CosmosDB for MongoDb provide native vector search capabilities for your data. Other databases can be enhanced with vector search by indexing the stored data using a service such as Azure AI Search, which can scan and index your data to provide vector search capabilities.

## Vector search workflows with .NET and OpenAI

Vector databases and vector search features are especially useful in [RAG pattern](rag.md) workflows with Azure OpenAI. This pattern allows you to augment or enhance your AI model with additional semantically rich knowledge of your data. A common AI workflow using vector databases might include the following steps:

1. Create embeddings for your data using an OpenAI embedding model.
1. Store and index the embeddings in a vector database or search service.
1. Convert user prompts from your application to embeddings.
1. Run a vector search across your data, comparing the user prompt embedding to the embeddings your database.
1. Use a language model such as GPT-35 or GPT-4 to assembly a user friendly completion from the vector search results.

Benefits of the RAG pattern include:

- Generate contextually relevant and accurate responses to user prompts from AI models.
- Overcome LLM tokens limits - the heavy lifting is done through the database vector search.
- Reduce the costs from frequent fine-tuning on updated data.

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
