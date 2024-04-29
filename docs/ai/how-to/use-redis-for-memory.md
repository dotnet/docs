---
title: "Use Redis for Memory Storage with the Semantic Kernel SDK"
description: "Learn how to use a Redis database together with the RediSearch module to give your AI memories in Semantic Kernel SDK for .NET."
author: haywoodsloan
ms.topic: how-to
ms.date: 04/17/2024

#customer intent: As a .NET developer, I want to use Redis for memory storage together with the Semantic Kernel SDK so that I can store and recall memories in my application.

---

# Use Redis for memory storage with the Semantic Kernel SDK

This article demonstrates how to integrate a Redis database with the RediSearch module into the [Semantic Kernel SDK](/semantic-kernel/overview) and use it for memory storage and retrieval.

[Memories](/semantic-kernel/memories/) represent text information that has been stored alongside a precomputed embedding vector for the whole text. When an LLM is prompted to recall a memory, it uses these precomputed embeddings to efficiently evaluate whether a memory is relevant to the prompt. After the LLM finds a matching memory, it uses the memory's text information as context for the next steps in the prompt completion.

Memory storage that's added to the Semantic Kernel SDK provides a broader context for your requests. It also enables you to store data in the same manner as you store a traditional database, but query it by using natural language.

## Prerequisites

* An Azure account that has an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [`Microsoft.SemanticKernel` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel)
* [`Microsoft.SemanticKernel.Connectors.Redis` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Redis)
* [`Microsoft.SemanticKernel.Plugins.Memory` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel.Plugins.Memory)
* [`StackExchange.Redis` NuGet package](https://www.nuget.org/packages/StackExchange.Redis)
* A Redis database that has the RediSearch module, [deployed and accessible to your .NET application](/azure/azure-cache-for-redis/quickstart-create-redis-enterprise)

## Implement memory storage using a Redis database

Before you integrate your Redis database to the Semantic Kernel SDK, make sure that you have the RediSearch module enabled. For module information for _Azure Cache for Redis_, see [Use Redis modules with Azure Cache for Redis](/azure/azure-cache-for-redis/cache-redis-modules#adding-modules-to-your-cache).

1. Initialize a connection to your Redis database. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/MemoryExamples.cs" id="initRedis":::

2. Build the `Kernel` by including `ITextEmbeddingGenerationService`. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/MemoryExamples.cs" id="initKernel":::

3. Wrap the Redis database in a `RedisMemoryStore` instance, and then initialize a `SemanticTextMemory` object by using the memory store and embedding generation service. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/MemoryExamples.cs" id="initMemory":::

4. Add the semantic text memory to the `Kernel` by using the `TextMemoryPlugin` class. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/MemoryExamples.cs" id="addMemory":::

5. Use the `Kernel` and plug-in to save, retrieve, and recall memories. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/MemoryExamples.cs" id="useMemory":::

6. Use memory recall as part of a prompt by using the [prompt template syntax `{{...}}`](/semantic-kernel/prompts/prompt-template-syntax). For example:

    :::code language="csharp" source="./snippets/semantic-kernel/MemoryExamples.cs" id="promptMemory":::

## Related content

<!-- TODO: update these links once the other docs are done -->

* [Use RAG with SQL]<!-- (link.md) -->
* [Data ingestion from SharePoint]<!-- (link.md) -->
* [Working with vector databases]<!-- (link.md) -->
