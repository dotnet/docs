---
title:  Unified AI building blocks for .NET
description: Learn how to develop with unified AI building blocks for .NET using Microsoft.Extensions.AI and Microsoft.Extensions.AI.Abstractions libraries
ms.date: 11/04/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Unified AI building blocks for .NET using Microsoft.Extensions.AI

The .NET ecosystem provides abstractions for integrating AI services into .NET applications and libraries using the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI) and [`Microsoft.Extensions.AI.Abstractions`](https://www.nuget.org/packages/Microsoft.Extensions.AI.Abstractions) libraries. The .NET team also enhanced the core `Microsoft.Extensions.*` libraries with these abstractions for .NET Generative AI applications and libraries. In the sections ahead, you learn:

- Core concepts and capabilities of the `Microsoft.Extensions.AI` libraries.
- How to work with AI abstractions in your apps and the benefits they offer.
- Essential AI middleware concepts.

## What is the Microsoft.Extensions.AI library?

`Microsoft.Extensions.AI` is a set of core .NET libraries created in collaboration with developers across the .NET ecosystem, including Semantic Kernel. These libraries provide a unified layer of C# abstractions for interacting with AI services, such as small and large language models (SLMs and LLMs), embeddings, and middleware.

:::image type="content" source="media/ai-extensions/meai-architecture-diagram.png" alt-text="An architectural diagram of the AI extensions libraries.":::

`Microsoft.Extensions.AI` provides abstractions that can be implemented by various services, all adhering to the same core concepts. This library is not intended to provide APIs tailored to any specific provider's services. The goal of `Microsoft.Extensions.AI` is to act as a unifying layer within the .NET ecosystem, enabling developers to choose their preferred frameworks and libraries while ensuring seamless integration and collaboration across the ecosystem.

## Work with abstractions for common AI services

AI capabilities are rapidly evolving, with patterns emerging for common functionality:

- Chat features to conversationally prompt an AI for information or data analysis.
- Embedding generation to integrate with vector search capabilities.
- Tool calling to integrate with other services, platforms, or code.

The `Microsoft.Extensions.AI` library provides abstractions for these types of tasks, so developers can focus on coding against conceptual AI capabilities rather than specific platforms or provider implementations. Unified abstractions are crucial for developers to work effectively across different sources.

For example, the `IChatClient` interface allows consumption of language models from various providers, whether you're connecting to an Azure OpenAI service or running a local Ollama installation. Any .NET package that provides an AI client can implement the `IChatClient` interface, enabling seamless integration with consuming .NET code:

```csharp
IChatClient client =
    environment.IsDevelopment ?  
    new OllamaChatClient(...) : 
    new AzureAIInferenceChatClient(...); 
```

Then, regardless of the provider you're using, you can send requests as follows:

```csharp
var response = await chatClient.CompleteAsync( 
      "Translate the following text into Pig Latin: I love .NET and AI"); 

Console.WriteLine(response.Message);  
```

These abstractions allow for idiomatic C# code for various scenarios with minimal code changes, whether you're using different services for development and production, addressing hybrid scenarios, or exploring other service providers.

Library authors who implement these abstractions make their clients interoperable with the broader `Microsoft.Extensions.AI` ecosystem. Service-specific APIs remain accessible if needed, allowing consumers to code against the standard abstractions and pass through to proprietary APIs only when required.

`Microsoft.Extensions.AI` provides implementations for the following services through additional packages:

- [OpenAI](https://aka.ms/meai-openai-nuget)
- [Azure OpenAI](https://aka.ms/meai-openai-nuget)
- [Azure AI Inference](https://aka.ms/meai-azaiinference-nuget)
- [Ollama](https://aka.ms/meai-ollama-nuget)

In the future, implementations of these `Microsoft.Extensions.AI` abstractions will be part of the respective client libraries rather than requiring installation of additional packages.

## Middleware implementations for AI services

Connecting to and using AI services is just one aspect of building robust applications. Production-ready applications require additional features like telemetry, logging, and tool calling capabilities. The `Microsoft.Extensions.AI` abstractions enable you to easily integrate these components into your applications using familiar patterns.

The following sample demonstrates how to register an OpenAI `IChatClient`. `IChatClient` allows you to attach the capabilities in a consistent way across various providers.

```csharp
app.Services.AddChatClient(builder => builder 
    .UseLogging()
    .UseFunctionInvocation() 
    .UseDistributedCache()    
    .UseOpenTelemetry()  
    .Use(new OpenAIClient(...)).AsChatClient(...)); 
```

The capabilities demonstrated in this snippet are included in the `Microsoft.Extensions.AI` library, but they are only a small subset of the capabilities that can be layered in with this approach. .NET developers are able to expose many types of middleware to create powerful AI functionality.

## Build with Microsoft.Extensions.AI

You can start building with `Microsoft.Extensions.AI` in the following ways:

- **Library Developers**: If you own libraries that provide clients for AI services, consider implementing the interfaces in your libraries. This allows users to easily integrate your NuGet package via the abstractions.
- **Service Consumers**: If you're developing libraries that consume AI services, use the abstractions instead of hardcoding to a specific AI service. This approach gives your consumers the flexibility to choose their preferred service.
- **Application Developers**: Use the abstractions to simplify integration into your apps. This enables portability across models and services, facilitates testing and mocking, leverages middleware provided by the ecosystem, and maintains a consistent API throughout your app, even if you use different services in different parts of your application.
- **Ecosystem Contributors**: If you're interested in contributing to the ecosystem, consider writing custom middleware components.
To get started, see the samples in the [dotnet/ai-samples](https://aka.ms/meai-samples) GitHub repository.

For an end-to-end sample using `Microsoft.Extensions.AI`, see [eShopSupport](https://github.com/dotnet/eShopSupport).

## Next steps

- [Build an AI chat app with .NET](./quickstarts/get-started-openai.md)
- [Quickstart - Summarize text using Azure AI chat app with .NET](./quickstarts/quickstart-openai-summarize-text.md)
