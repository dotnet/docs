---
title: Microsoft.Extensions.AI libraries
description: Learn how to use the Microsoft.Extensions.AI libraries to integrate and interact with various AI services in your .NET applications.
ms.date: 12/10/2025
---

# Microsoft.Extensions.AI libraries

.NET developers need to integrate and interact with a growing variety of artificial intelligence (AI) services in their apps. The `Microsoft.Extensions.AI` libraries provide a unified approach for representing generative AI components, and enable seamless integration and interoperability with various AI services. This article introduces the libraries and provides in-depth usage examples to help you get started.

## The packages

The [📦 Microsoft.Extensions.AI.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.AI.Abstractions) package provides the core exchange types, including <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2>. Any .NET library that provides an LLM client can implement the `IChatClient` interface to enable seamless integration with consuming code.

The [📦 Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI) package has an implicit dependency on the `Microsoft.Extensions.AI.Abstractions` package. This package enables you to easily integrate components such as automatic function tool invocation, telemetry, and caching into your applications using familiar dependency injection and middleware patterns. For example, it provides the <xref:Microsoft.Extensions.AI.OpenTelemetryChatClientBuilderExtensions.UseOpenTelemetry(Microsoft.Extensions.AI.ChatClientBuilder,Microsoft.Extensions.Logging.ILoggerFactory,System.String,System.Action{Microsoft.Extensions.AI.OpenTelemetryChatClient})> extension method, which adds OpenTelemetry support to the chat client pipeline.

### Which package to reference

To have access to higher-level utilities for working with generative AI components, reference the `Microsoft.Extensions.AI` package instead (which itself references `Microsoft.Extensions.AI.Abstractions`). Most consuming applications and services should reference the `Microsoft.Extensions.AI` package along with one or more libraries that provide concrete implementations of the abstractions.

Libraries that provide implementations of the abstractions typically reference only `Microsoft.Extensions.AI.Abstractions`.

### Install the packages

For information about how to install NuGet packages, see [dotnet package add](../core/tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../core/tools/dependencies.md).

## APIs and functionality

- [The `IChatClient` interface](#the-ichatclient-interface)
- [The `IEmbeddingGenerator` interface](#the-iembeddinggenerator-interface)
- [The `IImageGenerator` interface (experimental)](#the-iimagegenerator-interface-experimental)

### The `IChatClient` interface

The <xref:Microsoft.Extensions.AI.IChatClient> interface defines a client abstraction responsible for interacting with AI services that provide chat capabilities. It includes methods for sending and receiving messages with multi-modal content (such as text, images, and audio), either as a complete set or streamed incrementally.

For more information and detailed usage examples, see [Use the IChatClient interface](ichatclient.md).

### The IImageGenerator interface (experimental)

The <xref:Microsoft.Extensions.AI.IImageGenerator> interface represents a generator for creating images from text prompts or other input. This interface enables applications to integrate image generation capabilities from various AI services through a consistent API. The interface supports text-to-image generation (by calling <xref:Microsoft.Extensions.AI.IImageGenerator.GenerateAsync(Microsoft.Extensions.AI.ImageGenerationRequest,Microsoft.Extensions.AI.ImageGenerationOptions,System.Threading.CancellationToken)>) and [configuration options](xref:Microsoft.Extensions.AI.ImageGenerationOptions) for image size and format. Like other interfaces in the library, it can be composed with middleware for caching, telemetry, and other cross-cutting concerns.

For more information, see [Generate images from text using AI](quickstarts/text-to-image.md).

## Build with Microsoft.Extensions.AI

You can start building with `Microsoft.Extensions.AI` in the following ways:

- **Library developers**: If you own libraries that provide clients for AI services, consider implementing the interfaces in your libraries. This allows users to easily integrate your NuGet package via the abstractions. For example implementations, see [Sample implementations of IChatClient and IEmbeddingGenerator](advanced/sample-implementations.md).
- **Service consumers**: If you're developing libraries that consume AI services, use the abstractions instead of hardcoding to a specific AI service. This approach gives your consumers the flexibility to choose their preferred provider.
- **Application developers**: Use the abstractions to simplify integration into your apps. This enables portability across models and services, facilitates testing and mocking, leverages middleware provided by the ecosystem, and maintains a consistent API throughout your app, even if you use different services in different parts of your application.
- **Ecosystem contributors**: If you're interested in contributing to the ecosystem, consider writing custom middleware components.

For more samples, see the [dotnet/ai-samples](https://aka.ms/meai-samples) GitHub repository. For an end-to-end sample, see [eShopSupport](https://github.com/dotnet/eShopSupport).

## See also

- [Request a response with structured output](./quickstarts/structured-output.md)
- [Build an AI chat app with .NET](./quickstarts/build-chat-app.md)
- [Dependency injection in .NET](../core/extensions/dependency-injection.md)
- [Caching in .NET](../core/extensions/caching.md)
- [Rate limit an HTTP handler in .NET](../core/extensions/http-ratelimiter.md)
