---
title: Artificial Intelligence in .NET (Preview)
description: Learn how to use the Microsoft.Extensions.AI libraries to integrate and interact with various AI services in your .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 01/06/2025
ms.collection: ce-skilling-ai-copilot
---

# Artificial intelligence in .NET (Preview)

With a growing variety of artificial intelligence (AI) services available, developers need a way to integrate and interact with these services in their .NET applications. The `Microsoft.Extensions.AI` libraries provide a unified approach for representing generative AI components, which enables seamless integration and interoperability with various AI services. This article introduces the libraries and provides installation instructions and usage examples to help you get started.

The [📦 Microsoft.Extensions.AI.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.AI.Abstractions) package provides the core exchange types: <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2>. Any .NET library that provides an AI client can implement the `IChatClient` interface to enable seamless integration with consuming code.

The [📦 Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI) package has an implicit dependency on the `Microsoft.Extensions.AI.Abstractions` package. This package enables you to easily integrate components such as telemetry and caching into your applications using familiar dependency injection and middleware patterns. For example, it provides the <xref:Microsoft.Extensions.AI.OpenTelemetryChatClientBuilderExtensions.UseOpenTelemetry(Microsoft.Extensions.AI.ChatClientBuilder,Microsoft.Extensions.Logging.ILoggerFactory,System.String,System.Action{Microsoft.Extensions.AI.OpenTelemetryChatClient})> extension method, which adds OpenTelemetry support to the chat client pipeline.

## Install the package

To install the [📦 Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI) and [📦 Microsoft.Extensions.AI.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.AI.Abstractions) NuGet packages, use the .NET CLI or add package references directly to your C# project file:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.AI --prerelease
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.AI"
                  Version="*" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## The `IChatClient` interface

The <xref:Microsoft.Extensions.AI.IChatClient> interface defines a client abstraction responsible for interacting with AI services that provide chat capabilities. It includes methods for sending and receiving messages with multi-modal content (such as text, images, and audio), either as a complete set or streamed incrementally. Additionally, it provides metadata information about the client and allows retrieving strongly typed services.

> [!IMPORTANT]
> For more usage examples and real-world scenarios, see [AI for .NET developers](../../ai/index.yml).

The following sample implements `IChatClient` to show the general structure.

:::code language="csharp" source="snippets/ai/AI.Shared/SampleChatClient.cs":::

You can find other concrete implementations of `IChatClient` in the following NuGet packages:

- [📦 Microsoft.Extensions.AI.AzureAIInference](https://www.nuget.org/packages/Microsoft.Extensions.AI.AzureAIInference): Implementation backed by [Azure AI Model Inference API](/azure/ai-studio/reference/reference-model-inference-api).
- [📦 Microsoft.Extensions.AI.Ollama](https://www.nuget.org/packages/Microsoft.Extensions.AI.Ollama): Implementation backed by [Ollama](https://ollama.com/).
- [📦 Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI): Implementation backed by either [OpenAI](https://openai.com/) or OpenAI-compatible endpoints (such as [Azure OpenAI](https://azure.microsoft.com/products/ai-services/openai-service)).

The following subsections show specific `IChatClient` usage examples:

- [Request chat completion](#request-chat-completion)
- [Request chat completion with streaming](#request-chat-completion-with-streaming)
- [Tool calling](#tool-calling)
- [Cache responses](#cache-responses)
- [Use telemetry](#use-telemetry)
- [Provide options](#provide-options)
- [Functionality pipelines](#functionality-pipelines)
- [Custom `IChatClient` middleware](#custom-ichatclient-middleware)
- [Dependency injection](#dependency-injection)

### Request chat completion

To request a completion, call the <xref:Microsoft.Extensions.AI.IChatClient.CompleteAsync*?displayProperty=nameWithType> method. The request is composed of one or more messages, each of which is composed of one or more pieces of content. Accelerator methods exist to simplify common cases, such as constructing a request for a single piece of text content.

:::code language="csharp" source="snippets/ai/ConsoleAI/Program.cs":::

The core `IChatClient.CompleteAsync` method accepts a list of messages. This list represents the history of all messages that are part of the conversation.

:::code language="csharp" source="snippets/ai/ConsoleAI.CompleteAsyncArgs/Program.cs":::

Each message in the history is represented by a <xref:Microsoft.Extensions.AI.ChatMessage> object. The `ChatMessage` class provides a <xref:Microsoft.Extensions.AI.ChatMessage.Role?displayProperty=nameWithType> property that indicates the role of the message. By default, the <xref:Microsoft.Extensions.AI.ChatRole.User?displayProperty=nameWithType> is used. The following roles are available:

- <xref:Microsoft.Extensions.AI.ChatRole.Assistant?displayProperty=nameWithType>: Instructs or sets the behavior of the assistant.
- <xref:Microsoft.Extensions.AI.ChatRole.System?displayProperty=nameWithType>: Provides responses to system-instructed, user-prompted input.
- <xref:Microsoft.Extensions.AI.ChatRole.Tool?displayProperty=nameWithType>: Provides additional information and references for chat completions.
- <xref:Microsoft.Extensions.AI.ChatRole.User?displayProperty=nameWithType>: Provides input for chat completions.

Each chat message is instantiated, assigning to its <xref:Microsoft.Extensions.AI.ChatMessage.Contents> property a new <xref:Microsoft.Extensions.AI.TextContent>. There are various [types of content](xref:Microsoft.Extensions.AI.AIContent) that can be represented, such as a simple string or a more complex object that represents a multi-modal message with text, images, and audio:

- <xref:Microsoft.Extensions.AI.AudioContent>
- <xref:Microsoft.Extensions.AI.DataContent>
- <xref:Microsoft.Extensions.AI.FunctionCallContent>
- <xref:Microsoft.Extensions.AI.FunctionResultContent>
- <xref:Microsoft.Extensions.AI.ImageContent>
- <xref:Microsoft.Extensions.AI.TextContent>
- <xref:Microsoft.Extensions.AI.UsageContent>

### Request chat completion with streaming

The inputs to <xref:Microsoft.Extensions.AI.IChatClient.CompleteStreamingAsync*?displayProperty=nameWithType> are identical to those of `CompleteAsync`. However, rather than returning the complete response as part of a <xref:Microsoft.Extensions.AI.ChatCompletion> object, the method returns an <xref:System.Collections.Generic.IAsyncEnumerable`1> where `T` is <xref:Microsoft.Extensions.AI.StreamingChatCompletionUpdate>, providing a stream of updates that collectively form the single response.

:::code language="csharp" source="snippets/ai/ConsoleAI.CompleteStreamingAsync/Program.cs":::

> [!TIP]
> Streaming APIs are nearly synonymous with AI user experiences. C# enables compelling scenarios with its `IAsyncEnumerable<T>` support, allowing for a natural and efficient way to stream data.

### Tool calling

Some models and services support _tool calling_, where requests can include tools for the model to invoke functions to gather additional information. Instead of sending a final response, the model requests a function invocation with specific arguments. The client then invokes the function and sends the results back to the model along with the conversation history. The `Microsoft.Extensions.AI` library includes abstractions for various message content types, including function call requests and results. While consumers can interact with this content directly, `Microsoft.Extensions.AI` automates these interactions and provides:

- <xref:Microsoft.Extensions.AI.AIFunction>: Represents a function that can be described to an AI service and invoked.
- <xref:Microsoft.Extensions.AI.AIFunctionFactory>: Provides factory methods for creating commonly used implementations of `AIFunction`.
- <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient>: Wraps an `IChatClient` to add automatic function invocation capabilities.

Consider the following example that demonstrates a random function invocation:

:::code language="csharp" source="snippets/ai/ConsoleAI.ToolCalling/Program.cs":::

The preceding example depends on the [📦 Microsoft.Extensions.AI.Ollama](https://www.nuget.org/packages/Microsoft.Extensions.AI.Ollama) NuGet package.

The preceding code:

- Defines a function named `GetCurrentWeather` that returns a random weather forecast.
  - This function is decorated with a <xref:System.ComponentModel.DescriptionAttribute>, which is used to provide a description of the function to the AI service.
- Instantiates a <xref:Microsoft.Extensions.AI.ChatClientBuilder> with an <xref:Microsoft.Extensions.AI.OllamaChatClient> and configures it to use function invocation.
- Calls `CompleteStreamingAsync` on the client, passing a prompt and a list of tools that includes a function created with <xref:Microsoft.Extensions.AI.AIFunctionFactory.Create*>.
- Iterates over the response, printing each update to the console.

### Cache responses

If you're familiar with [Caching in .NET](caching.md), it's good to know that <xref:Microsoft.Extensions.AI> provides other such delegating `IChatClient` implementations. The <xref:Microsoft.Extensions.AI.DistributedCachingChatClient> is an `IChatClient` that layers caching around another arbitrary `IChatClient` instance. When a unique chat history is submitted to the `DistributedCachingChatClient`, it forwards it to the underlying client and then caches the response before sending it back to the consumer. The next time the same prompt is submitted, such that a cached response can be found in the cache, the `DistributedCachingChatClient` returns the cached response rather than needing to forward the request along the pipeline.

:::code language="csharp" source="snippets/ai/ConsoleAI.CacheResponses/Program.cs":::

The preceding example depends on the [📦 Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory) NuGet package. For more information, see [Caching in .NET](caching.md).

### Use telemetry

Another example of a delegating chat client is the <xref:Microsoft.Extensions.AI.OpenTelemetryChatClient>. This implementation adheres to the [OpenTelemetry Semantic Conventions for Generative AI systems](https://opentelemetry.io/docs/specs/semconv/gen-ai/). Similar to other `IChatClient` delegators, it layers metrics and spans around any underlying `IChatClient` implementation, providing enhanced observability.

:::code language="csharp" source="snippets/ai/ConsoleAI.UseTelemetry/Program.cs":::

The preceding example depends on the [📦 OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console) NuGet package.

### Provide options

Every call to <xref:Microsoft.Extensions.AI.IChatClient.CompleteAsync*> or <xref:Microsoft.Extensions.AI.IChatClient.CompleteStreamingAsync*> can optionally supply a <xref:Microsoft.Extensions.AI.ChatOptions> instance containing additional parameters for the operation. The most common parameters among AI models and services show up as strongly typed properties on the type, such as <xref:Microsoft.Extensions.AI.ChatOptions.Temperature?displayProperty=nameWithType>. Other parameters can be supplied by name in a weakly typed manner via the <xref:Microsoft.Extensions.AI.ChatOptions.AdditionalProperties?displayProperty=nameWithType> dictionary.

You can also specify options when building an `IChatClient` with the fluent <xref:Microsoft.Extensions.AI.ChatClientBuilder> API and chaining a call to the `ConfigureOptions` extension method. This delegating client wraps another client and invokes the supplied delegate to populate a `ChatOptions` instance for every call. For example, to ensure that the <xref:Microsoft.Extensions.AI.ChatOptions.ModelId?displayProperty=nameWithType> property defaults to a particular model name, you can use code like the following:

:::code language="csharp" source="snippets/ai/ConsoleAI.ProvideOptions/Program.cs":::

The preceding example depends on the [📦 Microsoft.Extensions.AI.Ollama](https://www.nuget.org/packages/Microsoft.Extensions.AI.Ollama) NuGet package.

### Functionality pipelines

`IChatClient` instances can be layered to create a pipeline of components, each adding specific functionality. These components can come from `Microsoft.Extensions.AI`, other NuGet packages, or custom implementations. This approach allows you to augment the behavior of the `IChatClient` in various ways to meet your specific needs. Consider the following example code that layers a distributed cache, function invocation, and OpenTelemetry tracing around a sample chat client:

:::code language="csharp" source="snippets/ai/ConsoleAI.FunctionalityPipelines/Program.cs":::

The preceding example depends on the following NuGet packages:

- [📦 Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory)
- [📦 Microsoft.Extensions.AI.Ollama](https://www.nuget.org/packages/Microsoft.Extensions.AI.Ollama)
- [📦 OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console)

### Custom `IChatClient` middleware

To add additional functionality, you can implement `IChatClient` directly or use the <xref:Microsoft.Extensions.AI.DelegatingChatClient> class. This class serves as a base for creating chat clients that delegate operations to another `IChatClient` instance. It simplifies chaining multiple clients, allowing calls to pass through to an underlying client.

The `DelegatingChatClient` class provides default implementations for methods like `CompleteAsync`, `CompleteStreamingAsync`, and `Dispose`, which forward calls to the inner client. You can derive from this class and override only the methods you need to enhance behavior, while delegating other calls to the base implementation. This approach helps create flexible and modular chat clients that are easy to extend and compose.

The following is an example class derived from `DelegatingChatClient` to provide rate limiting functionality, utilizing the <xref:System.Threading.RateLimiting.RateLimiter>:

:::code language="csharp" source="snippets/ai/AI.Shared/RateLimitingChatClient.cs":::

The preceding example depends on the [📦 System.Threading.RateLimiting](https://www.nuget.org/packages/System.Threading.RateLimiting) NuGet package. Composition of the `RateLimitingChatClient` with another client is straightforward:

:::code language="csharp" source="snippets/ai/ConsoleAI.CustomClientMiddle/Program.cs":::

To simplify the composition of such components with others, component authors should create a `Use*` extension method for registering the component into a pipeline. For example, consider the following extension method:

:::code language="csharp" source="snippets/ai/AI.Shared/RateLimitingChatClientExtensions.cs" id="one":::

Such extensions can also query for relevant services from the DI container; the <xref:System.IServiceProvider> used by the pipeline is passed in as an optional parameter:

:::code language="csharp" source="snippets/ai/AI.Shared/RateLimitingChatClientExtensions.OptionalOverload.cs"  id="two":::

The consumer can then easily use this in their pipeline, for example:

:::code language="csharp" source="snippets/ai/ConsoleAI.ConsumeClientMiddleware/Program.cs" id="program":::

This example demonstrates [hosted scenario](generic-host.md), where the consumer relies on [dependency injection](dependency-injection.md) to provide the `RateLimiter` instance. The preceding extension methods demonstrate using a `Use` method on <xref:Microsoft.Extensions.AI.ChatClientBuilder>. The `ChatClientBuilder` also provides <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use*> overloads that make it easier to write such delegating handlers.

- <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(Microsoft.Extensions.AI.AnonymousDelegatingChatClient.CompleteSharedFunc)>
- <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(System.Func{Microsoft.Extensions.AI.IChatClient,Microsoft.Extensions.AI.IChatClient})>
- <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(System.Func{Microsoft.Extensions.AI.IChatClient,System.IServiceProvider,Microsoft.Extensions.AI.IChatClient})>
- <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(System.Func{System.Collections.Generic.IList{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,Microsoft.Extensions.AI.IChatClient,System.Threading.CancellationToken,System.Threading.Tasks.Task{Microsoft.Extensions.AI.ChatCompletion}},System.Func{System.Collections.Generic.IList{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,Microsoft.Extensions.AI.IChatClient,System.Threading.CancellationToken,System.Collections.Generic.IAsyncEnumerable{Microsoft.Extensions.AI.StreamingChatCompletionUpdate}})>

For example, in the earlier `RateLimitingChatClient` example, the overrides of `CompleteAsync` and `CompleteStreamingAsync` only need to do work before and after delegating to the next client in the pipeline. To achieve the same thing without writing a custom class, you can use an overload of `Use` that accepts a delegate that's used for both `CompleteAsync` and `CompleteStreamingAsync`, reducing the boilerplate required:

:::code language="csharp" source="snippets/ai/ConsoleAI.UseExample/Program.cs":::

The preceding overload internally uses an `AnonymousDelegatingChatClient`, which enables more complicated patterns with only a little additional code. For example, to achieve the same result but with the <xref:System.Threading.RateLimiting.RateLimiter> retrieved from DI:

:::code language="csharp" source="snippets/ai/ConsoleAI.UseExampleAlt/Program.cs":::

For scenarios where the developer would like to specify delegating implementations of `CompleteAsync` and `CompleteStreamingAsync` inline, and where it's important to be able to write a different implementation for each in order to handle their unique return types specially, another overload of `Use` exists that accepts a delegate for each.

### Dependency injection

<xref:Microsoft.Extensions.AI.IChatClient> implementations will typically be provided to an application via [dependency injection (DI)](dependency-injection.md). In this example, an <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> is added into the DI container, as is an `IChatClient`. The registration for the `IChatClient` employs a builder that creates a pipeline containing a caching client (which will then use an `IDistributedCache` retrieved from DI) and the sample client. The injected `IChatClient` can be retrieved and used elsewhere in the app.

:::code language="csharp" source="snippets/ai/ConsoleAI.DependencyInjection/Program.cs":::

The preceding example depends on the following NuGet packages:

- [📦 Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting)
- [📦 Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory)

What instance and configuration is injected can differ based on the current needs of the application, and multiple pipelines can be injected with different keys.

## The `IEmbeddingGenerator` interface

The <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> interface represents a generic generator of embeddings. Here, `TInput` is the type of input values being embedded, and `TEmbedding` is the type of generated embedding, which inherits from the <xref:Microsoft.Extensions.AI.Embedding> class.

The `Embedding` class serves as a base class for embeddings generated by an `IEmbeddingGenerator`. It's designed to store and manage the metadata and data associated with embeddings. Derived types like `Embedding<T>` provide the concrete embedding vector data. For instance, an embedding exposes a <xref:Microsoft.Extensions.AI.Embedding`1.Vector?displayProperty=nameWithType> property to access its embedding data.

The `IEmbeddingGenerator` interface defines a method to asynchronously generate embeddings for a collection of input values, with optional configuration and cancellation support. It also provides metadata describing the generator and allows for the retrieval of strongly typed services that can be provided by the generator or its underlying services.

The following sample implementation of `IEmbeddingGenerator` shows the general structure (however, it just generates random embedding vectors).

:::code language="csharp" source="snippets/ai/AI.Shared/SampleEmbeddingGenerator.cs":::

The preceding code:

- Defines a class named `SampleEmbeddingGenerator` that implements the `IEmbeddingGenerator<string, Embedding<float>>` interface.
- Has a primary constructor that accepts an endpoint and model ID, which are used to identify the generator.
- Exposes a `Metadata` property that provides metadata about the generator.
- Implements the `GenerateAsync` method to generate embeddings for a collection of input values:
  - Simulates an asynchronous operation by delaying for 100 milliseconds.
  - Returns random embeddings for each input value.

You can find actual concrete implementations in the following packages:

- [📦 Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI)
- [📦 Microsoft.Extensions.AI.Ollama](https://www.nuget.org/packages/Microsoft.Extensions.AI.Ollama)

The following sections show specific `IEmbeddingGenerator` usage examples:

- [Create embeddings](#create-embeddings)
- [Custom `IEmbeddingGenerator` middleware](#custom-iembeddinggenerator-middleware)

### Create embeddings

The primary operation performed with an <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> is embedding generation, which is accomplished with its <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2.GenerateAsync*> method.

:::code language="csharp" source="snippets/ai/ConsoleAI.CreateEmbeddings/Program.cs":::

### Custom `IEmbeddingGenerator` middleware

As with `IChatClient`, `IEmbeddingGenerator` implementations can be layered. Just as `Microsoft.Extensions.AI` provides delegating implementations of `IChatClient` for caching and telemetry, it provides an implementation for `IEmbeddingGenerator` as well.

:::code language="csharp" source="snippets/ai/ConsoleAI.CustomEmbeddingsMiddle/Program.cs":::

The `IEmbeddingGenerator` enables building custom middleware that extends the functionality of an `IEmbeddingGenerator`. The <xref:Microsoft.Extensions.AI.DelegatingEmbeddingGenerator`2> class is an implementation of the `IEmbeddingGenerator<TInput, TEmbedding>` interface that serves as a base class for creating embedding generators that delegate their operations to another `IEmbeddingGenerator<TInput, TEmbedding>` instance. It allows for chaining multiple generators in any order, passing calls through to an underlying generator. The class provides default implementations for methods such as <xref:Microsoft.Extensions.AI.DelegatingEmbeddingGenerator`2.GenerateAsync*> and `Dispose`, which forward the calls to the inner generator instance, enabling flexible and modular embedding generation.

The following is an example implementation of such a delegating embedding generator that rate limits embedding generation requests:

:::code language="csharp" source="snippets/ai/AI.Shared/RateLimitingEmbeddingGenerator.cs":::

This can then be layered around an arbitrary `IEmbeddingGenerator<string, Embedding<float>>` to rate limit all embedding generation operations performed.

:::code language="csharp" source="snippets/ai/ConsoleAI.ConsumeRateLimitingEmbedding/Program.cs":::

In this way, the `RateLimitingEmbeddingGenerator` can be composed with other `IEmbeddingGenerator<string, Embedding<float>>` instances to provide rate limiting functionality.

## See also

- [Develop .NET applications with AI features](../../ai/get-started/dotnet-ai-overview.md)
- [Unified AI building blocks for .NET using Microsoft.Extensions.AI](../../ai/ai-extensions.md)
- [Build an AI chat app with .NET](../../ai/quickstarts/get-started-openai.md)
- [.NET dependency injection](dependency-injection.md)
- [Rate limit an HTTP handler in .NET](http-ratelimiter.md)
- [.NET Generic Host](generic-host.md)
- [Caching in .NET](caching.md)
