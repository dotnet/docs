---
title: "Using Vector Databases to Extend LLM Capabilities"
description: "Learn how vector databases extend LLM capabilities by storing and processing embeddings in .NET."
ms.topic: concept-article #Don't change.
ms.date: 11/24/2024

#customer intent: As a .NET developer, I want to learn how vector databases store and process embeddings in .NET so I can make more data available to LLMs in my apps.

---

# Vector databases for .NET + AI

Vector databases are designed to store and manage vector [embeddings](embeddings.md). Embeddings are numeric representations of non-numeric data that preserve semantic meaning. Words, documents, images, audio, and other types of data can all be vectorized. You can use embeddings to help an AI model understand the meaning of inputs so that it can perform comparisons and transformations, such as summarizing text, finding contextually related data, or creating images from text descriptions.

For example, you can use a vector database to:

- Identify similar images, documents, and songs based on their contents, themes, sentiments, and styles.
- Identify similar products based on their characteristics, features, and user groups.
- Recommend content, products, or services based on user preferences.
- Identify the best potential options from a large pool of choices to meet complex requirements.
- Identify data anomalies or fraudulent activities that are dissimilar from predominant or normal patterns.

## Understand vector search

Vector databases provide vector search capabilities to find similar items based on their data characteristics rather than by exact matches on a property field. Vector search works by analyzing the vector representations of your data that you created using an AI embedding model such the [Azure OpenAI embedding models](/azure/ai-services/openai/concepts/models#embeddings-models). The search process measures the distance between the data vectors and your query vector. The data vectors that are closest to your query vector are the ones that are found to be most similar semantically.

Some services such as [Azure Cosmos DB for MongoDB vCore](/azure/cosmos-db/mongodb/vcore/vector-search) provide native vector search capabilities for your data. Other databases can be enhanced with vector search by indexing the stored data using a service such as Azure AI Search, which can scan and index your data to provide vector search capabilities.

## Vector search workflows with .NET and OpenAI

Vector databases and their search features are especially useful in [RAG pattern](rag.md) workflows with Azure OpenAI. This pattern allows you to augment or enhance your AI model with additional semantically rich knowledge of your data. A common AI workflow using vector databases might include the following steps:

1. Create embeddings for your data using an OpenAI embedding model.
1. Store and index the embeddings in a vector database or search service.
1. Convert user prompts from your application to embeddings.
1. Run a vector search across your data, comparing the user prompt embedding to the embeddings your database.
1. Use a language model such as GPT-35 or GPT-4 to assembly a user friendly completion from the vector search results.

Visit the [Implement Azure OpenAI with RAG using vector search in a .NET app](../tutorials/tutorial-ai-vector-search.md) tutorial for a hands-on example of this flow.

Other benefits of the RAG pattern include:

- Generate contextually relevant and accurate responses to user prompts from AI models.
- Overcome LLM tokens limits - the heavy lifting is done through the database vector search.
- Reduce the costs from frequent fine-tuning on updated data.

## Available vector database solutions

[!INCLUDE [vector-databases](../includes/vector-databases.md)]

## Related content

- [Implement Azure OpenAI with RAG using vector search in a .NET app](../tutorials/tutorial-ai-vector-search.md)
- [More Semantic Kernel .NET connectors](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors)
