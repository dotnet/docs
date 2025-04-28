---
title:  Unified AI building blocks for .NET
description: Learn how to develop with unified AI building blocks for .NET using Microsoft.Extensions.AI and Microsoft.Extensions.AI.Abstractions libraries
ms.date: 12/16/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Unified AI building blocks for .NET using Microsoft.Extensions.AI

The .NET ecosystem provides abstractions for integrating AI services into .NET applications and libraries using the <xref:Microsoft.Extensions.AI> libraries. In this article, you learn:

- Core concepts and capabilities of the `Microsoft.Extensions.AI` libraries.
- How to work with AI abstractions in your apps and the benefits they offer.
- Essential AI middleware concepts.

For more information, see [Introduction to Microsoft.Extensions.AI](../core/extensions/artificial-intelligence.md).

## What are the Microsoft.Extensions.AI libraries?

The `Microsoft.Extensions.AI` libraries provides core exchange types and abstractions for interacting with AI services, such as small and large language models (SLMs and LLMs). They also provide the ability to register services like logging and caching in your dependency injection (DI) container.

:::image type="content" source="media/ai-extensions/meai-architecture-diagram.png" lightbox="media/ai-extensions/meai-architecture-diagram.png" alt-text="An architectural diagram of the AI extensions libraries.":::

The `Microsoft.Extensions.AI` namespaces provide abstractions that can be implemented by various services, all adhering to the same core concepts. This library is not intended to provide APIs tailored to any specific provider's services. The goal of `Microsoft.Extensions.AI` is to act as a unifying layer within the .NET ecosystem, enabling developers to choose their preferred frameworks and libraries while ensuring seamless integration and collaboration across the ecosystem.

## Work with abstractions for common AI services

AI capabilities are rapidly evolving, with patterns emerging for common functionality:

- Chat features to conversationally prompt an AI for information or data analysis.
- Embedding generation to integrate with vector search capabilities.
- Tool calling to integrate with other services, platforms, or code.

The `Microsoft.Extensions.AI.Abstractions` package provides abstractions for these types of tasks, so developers can focus on coding against conceptual AI capabilities rather than specific platforms or provider implementations. Unified abstractions are crucial for developers to work effectively across different sources.

For example, the <xref:Microsoft.Extensions.AI.IChatClient> interface allows consumption of language models from various providers, such as an Azure OpenAI service or a local Ollama installation. Any .NET package that provides an AI client can implement the `IChatClient` interface to enable seamless integration with consuming .NET code:

```csharp
IChatClient client =
    environment.IsDevelopment ?
    new OllamaChatClient(...) :
    new AzureAIInferenceChatClient(...);
```

Then, regardless of the provider you're using, you can send requests by calling <xref:Microsoft.Extensions.AI.IChatClient.GetResponseAsync(System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,System.Threading.CancellationToken)>, as follows:

```csharp
var response = await chatClient.GetResponseAsync(
      "Translate the following text into Pig Latin: I love .NET and AI");

Console.WriteLine(response.Message);
```

These abstractions allow for idiomatic C# code for various scenarios with minimal code changes. They make it easy to use different services for development and production, addressing hybrid scenarios, or exploring other service providers.

Library authors who implement these abstractions make their clients interoperable with the broader `Microsoft.Extensions.AI` ecosystem. Service-specific APIs remain accessible if needed, allowing consumers to code against the standard abstractions and pass through to proprietary APIs only when required.

`Microsoft.Extensions.AI` provides implementations for the following services through additional packages:

- [OpenAI](https://aka.ms/meai-openai-nuget)
- [Azure OpenAI](https://aka.ms/meai-openai-nuget)
- [Azure AI Inference](https://aka.ms/meai-azaiinference-nuget)
- [Ollama](https://aka.ms/meai-ollama-nuget)

In the future, implementations of these `Microsoft.Extensions.AI` abstractions will be part of the respective client libraries rather than requiring installation of additional packages.

## Middleware implementations for AI services

Connecting to and using AI services is just one aspect of building robust applications. Production-ready applications require additional features like telemetry, logging, caching, and tool-calling capabilities. The `Microsoft.Extensions.AI` packages provides APIs that enable you to easily integrate these components into your applications using familiar dependency injection and middleware patterns.

The following sample demonstrates how to register an OpenAI `IChatClient`. You can attach capabilities in a consistent way across various providers by calling methods such as <xref:Microsoft.Extensions.AI.FunctionInvokingChatClientBuilderExtensions.UseFunctionInvocation(Microsoft.Extensions.AI.ChatClientBuilder,Microsoft.Extensions.Logging.ILoggerFactory,System.Action{Microsoft.Extensions.AI.FunctionInvokingChatClient})> on a <xref:Microsoft.Extensions.AI.ChatClientBuilder>.

```csharp
app.Services.AddChatClient(builder => builder
    .UseLogging()
    .UseFunctionInvocation()
    .UseDistributedCache()   
    .UseOpenTelemetry()
    .Use(new OpenAIClient(...)).AsChatClient(...));
```

The capabilities demonstrated in this snippet are included in the `Microsoft.Extensions.AI` library, but they're only a small subset of the capabilities that can be layered in with this approach. .NET developers are able to expose many types of middleware to create powerful AI functionality.

## Build with Microsoft.Extensions.AI

You can start building with `Microsoft.Extensions.AI` in the following ways:

- **Library developers**: If you own libraries that provide clients for AI services, consider implementing the interfaces in your libraries. This allows users to easily integrate your NuGet package via the abstractions.
- **Service consumers**: If you're developing libraries that consume AI services, use the abstractions instead of hardcoding to a specific AI service. This approach gives your consumers the flexibility to choose their preferred service.
- **Application developers**: Use the abstractions to simplify integration into your apps. This enables portability across models and services, facilitates testing and mocking, leverages middleware provided by the ecosystem, and maintains a consistent API throughout your app, even if you use different services in different parts of your application.
- **Ecosystem contributors**: If you're interested in contributing to the ecosystem, consider writing custom middleware components.

To get started, see the samples in the [dotnet/ai-samples](https://aka.ms/meai-samples) GitHub repository.

For an end-to-end sample using `Microsoft.Extensions.AI`, see [eShopSupport](https://github.com/dotnet/eShopSupport).

## Next steps

- [Build an AI chat app with .NET](quickstarts/build-chat-app.md)
- [Quickstart - Summarize text using Azure AI chat app with .NET](quickstarts/prompt-model.md)
