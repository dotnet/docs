---
title: "Integrate Your Data into AI Apps with Retrival-Augmented Generation"
description: "Learn how retreival-augmented generation lets you use your data with LLMs to generate better completions in .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/15/2024

#customer intent: As a .NET developer, I want to understand how retrieval-augmented generation works in .NET so that LLMs can use my data sources to provide more valuable completions.

---

# Retrieval-augmented generation (RAG) provides LLM knowledge

This article describes how retrieval-augmented generation lets LLMs treat your data sources as knowledge without having to train.

LLMs have extensive knowledge bases. For most use cases, you can select an LLM with the knowledge you need. But, LLMs don't know about your data unless you've customized them through training. Retrieval-augmented generation lets you make your data available to LLMs without training them on it first.

## How RAG works

To perform retrieval-augmented generation, you create embeddings for your data along with common questions about it. You can do this on the fly or you can create and store the embeddings by using a vector database solution.

When a user asks a question, the LLM uses your embeddings to compare the user's question to your data and find the most relevant context. This context and the user's question then go to the LLM in a prompt, and the LLM provides a response based on your data.

### Example RAG solution

Consider a consumer retail "Intelligent Agent" that allows users to ask questions about products, services, and the like.

The solution architecture is represented by this diagram: This solution is composed of the following services:

Azure Cosmos DB for MongoDB vCore - Stores the operational retail data and their vectors in three collections: products, customers and salesorders. It also stores all of the chat history in the completions collection.
Azure Functions - Hosts two HTTP triggers, Ingest And Vectorize imports and vectorizes data. A second HTTP trigger, Add Remove Data is used to add and remove a product from the product catalog to highlight how to add and remove data in real-time for an AI solution.
Azure App Service - Hosts the chat web application.
Azure OpenAI Service - Generates vectors using the Embeddings API on the text-embedding-ada-002 model and chat completions using the Completion API on the gpt-4-32k model.

## Related content

- [Prompt engineering](prompt-engineering-in-dot-net.md)
- [Get started with the .NET enterprise chat sample using RAG](/dotnet/ai/get-started-app-chat-template?tabs=github-codespaces)
