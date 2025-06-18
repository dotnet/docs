---
title: Microsoft.Extensions.AI libraries
description: Learn how to use the Microsoft.Extensions.AI libraries to integrate and interact with various AI services in your .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 04/29/2025
---

# Microsoft.Extensions.AI libraries

.NET developers need to integrate and interact with a growing variety of artificial intelligence (AI) services in their apps. The `Microsoft.Extensions.AI` libraries provide a unified approach for representing generative AI components, and enable seamless integration and interoperability with various AI services. This article introduces the libraries and provides in-depth usage examples to help you get started.

## The packages

The [📦 Microsoft.Extensions.AI.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.AI.Abstractions) package provides the core exchange types, including <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2>. Any .NET library that provides an LLM client can implement the `IChatClient` interface to enable seamless integration with consuming code.

The [📦 Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI) package has an implicit dependency on the `Microsoft.Extensions.AI.Abstractions` package. This package enables you to easily integrate components such as automatic function tool invocation, telemetry, and caching into your applications using familiar dependency injection and middleware patterns. For example, it provides the <xref:Microsoft.Extensions.AI.OpenTelemetryChatClientBuilderExtensions.UseOpenTelemetry(Microsoft.Extensions.AI.ChatClientBuilder,Microsoft.Extensions.Logging.ILoggerFactory,System.String,System.Action{Microsoft.Extensions.AI.OpenTelemetryChatClient})> extension method, which adds OpenTelemetry support to the chat client pipeline.

### Which package to reference

Libraries that provide implementations of the abstractions typically reference only `Microsoft.Extensions.AI.Abstractions`.

To also have access to higher-level utilities for working with generative AI components, reference the `Microsoft.Extensions.AI` package instead (which itself references `Microsoft.Extensions.AI.Abstractions`). Most consuming applications and services should reference the `Microsoft.Extensions.AI` package along with one or more libraries that provide concrete implementations of the abstractions.

### Install the packages

For information about how to install NuGet packages, see [dotnet package add](../core/tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../core/tools/dependencies.md).

## API usage examples

The following subsections show specific [IChatClient](#the-ichatclient-interface) usage examples:

- [Request a chat response](#request-a-chat-response)
- [Request a streaming chat response](#request-a-streaming-chat-response)
- [Tool calling](#tool-calling)
- [Cache responses](#cache-responses)
- [Use telemetry](#use-telemetry)
- [Provide options](#provide-options)
- [Pipelines of functionality](#functionality-pipelines)
- [Custom `IChatClient` middleware](#custom-ichatclient-middleware)
- [Dependency injection](#dependency-injection)
- [Stateless vs. stateful clients](#stateless-vs-stateful-clients)

The following sections show specific [IEmbeddingGenerator](#the-iembeddinggenerator-interface) usage examples:

- [Sample implementation](#sample-implementation)
- [Create embeddings](#create-embeddings)
- [Pipelines of functionality](#pipelines-of-functionality)

### The `IChatClient` interface

The <xref:Microsoft.Extensions.AI.IChatClient> interface defines a client abstraction responsible for interacting with AI services that provide chat capabilities. It includes methods for sending and receiving messages with multi-modal content (such as text, images, and audio), either as a complete set or streamed incrementally. Additionally, it allows for retrieving strongly typed services provided by the client or its underlying services.

.NET libraries that provide clients for language models and services can provide an implementation of the `IChatClient` interface. Any consumers of the interface are then able to interoperate seamlessly with these models and services via the abstractions.

#### Request a chat response

With an instance of <xref:Microsoft.Extensions.AI.IChatClient>, you can call the <xref:Microsoft.Extensions.AI.IChatClient.GetResponseAsync*?displayProperty=nameWithType> method to send a request and get a response. The request is composed of one or more messages, each of which is composed of one or more pieces of content. Accelerator methods exist to simplify common cases, such as constructing a request for a single piece of text content.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI/Program.cs":::

The core `IChatClient.GetResponseAsync` method accepts a list of messages. This list represents the history of all messages that are part of the conversation.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.GetResponseAsyncArgs/Program.cs" id="Snippet1":::

The <xref:Microsoft.Extensions.AI.ChatResponse> that's returned from `GetResponseAsync` exposes a list of <xref:Microsoft.Extensions.AI.ChatMessage> instances that represent one or more messages generated as part of the operation. In common cases, there is only one response message, but in some situations, there can be multiple messages. The message list is ordered, such that the last message in the list represents the final message to the request. To provide all of those response messages back to the service in a subsequent request, you can add the messages from the response back into the messages list.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.AddMessages/Program.cs" id="Snippet1":::

#### Request a streaming chat response

The inputs to <xref:Microsoft.Extensions.AI.IChatClient.GetStreamingResponseAsync*?displayProperty=nameWithType> are identical to those of `GetResponseAsync`. However, rather than returning the complete response as part of a <xref:Microsoft.Extensions.AI.ChatResponse> object, the method returns an <xref:System.Collections.Generic.IAsyncEnumerable`1> where `T` is <xref:Microsoft.Extensions.AI.ChatResponseUpdate>, providing a stream of updates that collectively form the single response.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.GetStreamingResponseAsync/Program.cs" id="Snippet1":::

> [!TIP]
> Streaming APIs are nearly synonymous with AI user experiences. C# enables compelling scenarios with its `IAsyncEnumerable<T>` support, allowing for a natural and efficient way to stream data.

As with `GetResponseAsync`, you can add the updates from <xref:Microsoft.Extensions.AI.IChatClient.GetStreamingResponseAsync*?displayProperty=nameWithType> back into the messages list. Because the updates are individual pieces of a response, you can use helpers like <xref:Microsoft.Extensions.AI.ChatResponseExtensions.ToChatResponse(System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatResponseUpdate})> to compose one or more updates back into a single <xref:Microsoft.Extensions.AI.ChatResponse> instance.

Helpers like <xref:Microsoft.Extensions.AI.ChatResponseExtensions.AddMessages*> compose a <xref:Microsoft.Extensions.AI.ChatResponse> and then extract the composed messages from the response and add them to a list.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.AddMessages/Program.cs" id="Snippet2":::

#### Tool calling

Some models and services support _tool calling_. To gather additional information, you can configure the <xref:Microsoft.Extensions.AI.ChatOptions> with information about tools (usually .NET methods) that the model can request the client to invoke. Instead of sending a final response, the model requests a function invocation with specific arguments. The client then invokes the function and sends the results back to the model with the conversation history. The `Microsoft.Extensions.AI.Abstractions` library includes abstractions for various message content types, including function call requests and results. While `IChatClient` consumers can interact with this content directly, `Microsoft.Extensions.AI` provides helpers that can enable automatically invoking the tools in response to corresponding requests. The `Microsoft.Extensions.AI.Abstractions` and `Microsoft.Extensions.AI` libraries provide the following types:

- <xref:Microsoft.Extensions.AI.AIFunction>: Represents a function that can be described to an AI model and invoked.
- <xref:Microsoft.Extensions.AI.AIFunctionFactory>: Provides factory methods for creating `AIFunction` instances that represent .NET methods.
- <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient>: Wraps an `IChatClient` as another `IChatClient` that adds automatic function-invocation capabilities.

The following example demonstrates a random function invocation (this example depends on the [📦 OllamaSharp](https://www.nuget.org/packages/OllamaSharp) NuGet package):

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.ToolCalling/Program.cs":::

The preceding code:

- Defines a function named `GetCurrentWeather` that returns a random weather forecast.
- Instantiates a <xref:Microsoft.Extensions.AI.ChatClientBuilder> with an `OllamaSharp.OllamaApiClient` and configures it to use function invocation.
- Calls `GetStreamingResponseAsync` on the client, passing a prompt and a list of tools that includes a function created with <xref:Microsoft.Extensions.AI.AIFunctionFactory.Create*>.
- Iterates over the response, printing each update to the console.

#### Cache responses

If you're familiar with [Caching in .NET](../core/extensions/caching.md), it's good to know that <xref:Microsoft.Extensions.AI> provides other such delegating `IChatClient` implementations. The <xref:Microsoft.Extensions.AI.DistributedCachingChatClient> is an `IChatClient` that layers caching around another arbitrary `IChatClient` instance. When a novel chat history is submitted to the `DistributedCachingChatClient`, it forwards it to the underlying client and then caches the response before sending it back to the consumer. The next time the same history is submitted, such that a cached response can be found in the cache, the `DistributedCachingChatClient` returns the cached response rather than forwarding the request along the pipeline.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.CacheResponses/Program.cs":::

This example depends on the [📦 Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory) NuGet package. For more information, see [Caching in .NET](../core/extensions/caching.md).

#### Use telemetry

Another example of a delegating chat client is the <xref:Microsoft.Extensions.AI.OpenTelemetryChatClient>. This implementation adheres to the [OpenTelemetry Semantic Conventions for Generative AI systems](https://opentelemetry.io/docs/specs/semconv/gen-ai/). Similar to other `IChatClient` delegators, it layers metrics and spans around other arbitrary `IChatClient` implementations.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.UseTelemetry/Program.cs":::

(The preceding example depends on the [📦 OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console) NuGet package.)

Alternatively, the <xref:Microsoft.Extensions.AI.LoggingChatClient> and corresponding <xref:Microsoft.Extensions.AI.LoggingChatClientBuilderExtensions.UseLogging(Microsoft.Extensions.AI.ChatClientBuilder,Microsoft.Extensions.Logging.ILoggerFactory,System.Action{Microsoft.Extensions.AI.LoggingChatClient})> method provide a simple way to write log entries to an <xref:Microsoft.Extensions.Logging.ILogger> for every request and response.

#### Provide options

Every call to <xref:Microsoft.Extensions.AI.IChatClient.GetResponseAsync*> or <xref:Microsoft.Extensions.AI.IChatClient.GetStreamingResponseAsync*> can optionally supply a <xref:Microsoft.Extensions.AI.ChatOptions> instance containing additional parameters for the operation. The most common parameters among AI models and services show up as strongly typed properties on the type, such as <xref:Microsoft.Extensions.AI.ChatOptions.Temperature?displayProperty=nameWithType>. Other parameters can be supplied by name in a weakly typed manner, via the <xref:Microsoft.Extensions.AI.ChatOptions.AdditionalProperties?displayProperty=nameWithType> dictionary, or via an options instance that the underlying provider understands, via the <xref:Microsoft.Extensions.AI.ChatOptions.RawRepresentationFactory?displayProperty=nameWithType> property.

You can also specify options when building an `IChatClient` with the fluent <xref:Microsoft.Extensions.AI.ChatClientBuilder> API by chaining a call to the <xref:Microsoft.Extensions.AI.ConfigureOptionsChatClientBuilderExtensions.ConfigureOptions(Microsoft.Extensions.AI.ChatClientBuilder,System.Action{Microsoft.Extensions.AI.ChatOptions})> extension method. This delegating client wraps another client and invokes the supplied delegate to populate a `ChatOptions` instance for every call. For example, to ensure that the <xref:Microsoft.Extensions.AI.ChatOptions.ModelId?displayProperty=nameWithType> property defaults to a particular model name, you can use code like the following:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.ProvideOptions/Program.cs":::

#### Functionality pipelines

`IChatClient` instances can be layered to create a pipeline of components that each add additional functionality. These components can come from `Microsoft.Extensions.AI`, other NuGet packages, or custom implementations. This approach allows you to augment the behavior of the `IChatClient` in various ways to meet your specific needs. Consider the following code snippet that layers a distributed cache, function invocation, and OpenTelemetry tracing around a sample chat client:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.FunctionalityPipelines/Program.cs" id="Snippet1":::

#### Custom `IChatClient` middleware

To add additional functionality, you can implement `IChatClient` directly or use the <xref:Microsoft.Extensions.AI.DelegatingChatClient> class. This class serves as a base for creating chat clients that delegate operations to another `IChatClient` instance. It simplifies chaining multiple clients, allowing calls to pass through to an underlying client.

The `DelegatingChatClient` class provides default implementations for methods like `GetResponseAsync`, `GetStreamingResponseAsync`, and `Dispose`, which forward calls to the inner client. A derived class can then override only the methods it needs to augment the behavior, while delegating other calls to the base implementation. This approach is useful for creating flexible and modular chat clients that are easy to extend and compose.

The following is an example class derived from `DelegatingChatClient` that uses the [System.Threading.RateLimiting](https://www.nuget.org/packages/System.Threading.RateLimiting) library to provide rate-limiting functionality.

:::code language="csharp" source="snippets/microsoft-extensions-ai/AI.Shared/RateLimitingChatClient.cs":::

As with other `IChatClient` implementations, the `RateLimitingChatClient` can be composed:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.CustomClientMiddle/Program.cs":::

To simplify the composition of such components with others, component authors should create a `Use*` extension method for registering the component into a pipeline. For example, consider the following `UseRatingLimiting` extension method:

:::code language="csharp" source="snippets/microsoft-extensions-ai/AI.Shared/RateLimitingChatClientExtensions.cs" id="one":::

Such extensions can also query for relevant services from the DI container; the <xref:System.IServiceProvider> used by the pipeline is passed in as an optional parameter:

:::code language="csharp" source="snippets/microsoft-extensions-ai/AI.Shared/RateLimitingChatClientExtensions.OptionalOverload.cs"  id="two":::

Now it's easy for the consumer to use this in their pipeline, for example:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.ConsumeClientMiddleware/Program.cs" id="SnippetUse":::

The previous extension methods demonstrate using a `Use` method on <xref:Microsoft.Extensions.AI.ChatClientBuilder>. `ChatClientBuilder` also provides <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use*> overloads that make it easier to write such delegating handlers. For example, in the earlier `RateLimitingChatClient` example, the overrides of `GetResponseAsync` and `GetStreamingResponseAsync` only need to do work before and after delegating to the next client in the pipeline. To achieve the same thing without writing a custom class, you can use an overload of `Use` that accepts a delegate that's used for both `GetResponseAsync` and `GetStreamingResponseAsync`, reducing the boilerplate required:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.UseExample/Program.cs":::

For scenarios where you need a different implementation for `GetResponseAsync` and `GetStreamingResponseAsync` in order to handle their unique return types, you can use the <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(System.Func{System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,Microsoft.Extensions.AI.IChatClient,System.Threading.CancellationToken,System.Threading.Tasks.Task{Microsoft.Extensions.AI.ChatResponse}},System.Func{System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,Microsoft.Extensions.AI.IChatClient,System.Threading.CancellationToken,System.Collections.Generic.IAsyncEnumerable{Microsoft.Extensions.AI.ChatResponseUpdate}})> overload that accepts a delegate for each.

#### Dependency injection

<xref:Microsoft.Extensions.AI.IChatClient> implementations are often provided to an application via [dependency injection (DI)](../core/extensions/dependency-injection.md). In this example, an <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> is added into the DI container, as is an `IChatClient`. The registration for the `IChatClient` uses a builder that creates a pipeline containing a caching client (which then uses an `IDistributedCache` retrieved from DI) and the sample client. The injected `IChatClient` can be retrieved and used elsewhere in the app.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.DependencyInjection/Program.cs":::

What instance and configuration is injected can differ based on the current needs of the application, and multiple pipelines can be injected with different keys.

#### Stateless vs. stateful clients

_Stateless_ services require all relevant conversation history to be sent back on every request. In contrast, _stateful_ services keep track of the history and require only additional messages to be sent with a request. The <xref:Microsoft.Extensions.AI.IChatClient> interface is designed to handle both stateless and stateful AI services.

When working with a stateless service, callers maintain a list of all messages. They add in all received response messages and provide the list back on subsequent interactions.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.StatelessStateful/Program.cs" id="Snippet1":::

For stateful services, you might already know the identifier used for the relevant conversation. You can put that identifier into <xref:Microsoft.Extensions.AI.ChatOptions.ConversationId?displayProperty=nameWithType>. Usage then follows the same pattern, except there's no need to maintain a history manually.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.StatelessStateful/Program.cs" id="Snippet2":::

Some services might support automatically creating a conversation ID for a request that doesn't have one, or creating a new conversation ID that represents the current state of the conversation after incorporating the last round of messages. In such cases, you can transfer the <xref:Microsoft.Extensions.AI.ChatResponse.ConversationId?displayProperty=nameWithType> over to the `ChatOptions.ConversationId` for subsequent requests. For example:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.StatelessStateful/Program.cs" id="Snippet3":::

If you don't know ahead of time whether the service is stateless or stateful, you can check the response <xref:Microsoft.Extensions.AI.ChatResponse.ConversationId> and act based on its value. If it's set, then that value is propagated to the options and the history is cleared so as to not resend the same history again. If the response `ConversationId` isn't set, then the response message is added to the history so that it's sent back to the service on the next turn.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.StatelessStateful/Program.cs" id="Snippet4":::

### The `IEmbeddingGenerator` interface

The <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> interface represents a generic generator of embeddings. Here, `TInput` is the type of input values being embedded, and `TEmbedding` is the type of generated embedding, which inherits from the <xref:Microsoft.Extensions.AI.Embedding> class.

The `Embedding` class serves as a base class for embeddings generated by an `IEmbeddingGenerator`. It's designed to store and manage the metadata and data associated with embeddings. Derived types, like `Embedding<T>`, provide the concrete embedding vector data. For example, an `Embedding<float>` exposes a `ReadOnlyMemory<float> Vector { get; }` property for access to its embedding data.

The `IEmbeddingGenerator` interface defines a method to asynchronously generate embeddings for a collection of input values, with optional configuration and cancellation support. It also provides metadata describing the generator and allows for the retrieval of strongly typed services that can be provided by the generator or its underlying services.

#### Sample implementation

The following sample implementation of `IEmbeddingGenerator` shows the general structure.

:::code language="csharp" source="snippets/microsoft-extensions-ai/AI.Shared/SampleEmbeddingGenerator.cs":::

The preceding code:

- Defines a class named `SampleEmbeddingGenerator` that implements the `IEmbeddingGenerator<string, Embedding<float>>` interface.
- Has a primary constructor that accepts an endpoint and model ID, which are used to identify the generator.
- Implements the `GenerateAsync` method to generate embeddings for a collection of input values.

The sample implementation just generates random embedding vectors. You can find a concrete implementation in the [📦 Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI) package.

#### Create embeddings

The primary operation performed with an <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> is embedding generation, which is accomplished with its <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2.GenerateAsync*> method.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.CreateEmbeddings/Program.cs" id="Snippet1":::

Accelerator extension methods also exist to simplify common cases, such as generating an embedding vector from a single input.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.CreateEmbeddings/Program.cs" id="Snippet2":::

#### Pipelines of functionality

As with `IChatClient`, `IEmbeddingGenerator` implementations can be layered. `Microsoft.Extensions.AI` provides a delegating implementation for `IEmbeddingGenerator` for caching and telemetry.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.CustomEmbeddingsMiddle/Program.cs":::

The `IEmbeddingGenerator` enables building custom middleware that extends the functionality of an `IEmbeddingGenerator`. The <xref:Microsoft.Extensions.AI.DelegatingEmbeddingGenerator`2> class is an implementation of the `IEmbeddingGenerator<TInput, TEmbedding>` interface that serves as a base class for creating embedding generators that delegate their operations to another `IEmbeddingGenerator<TInput, TEmbedding>` instance. It allows for chaining multiple generators in any order, passing calls through to an underlying generator. The class provides default implementations for methods such as <xref:Microsoft.Extensions.AI.DelegatingEmbeddingGenerator`2.GenerateAsync*> and `Dispose`, which forward the calls to the inner generator instance, enabling flexible and modular embedding generation.

The following is an example implementation of such a delegating embedding generator that rate-limits embedding generation requests:

:::code language="csharp" source="snippets/microsoft-extensions-ai/AI.Shared/RateLimitingEmbeddingGenerator.cs":::

This can then be layered around an arbitrary `IEmbeddingGenerator<string, Embedding<float>>` to rate limit all embedding generation operations.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.ConsumeRateLimitingEmbedding/Program.cs":::

In this way, the `RateLimitingEmbeddingGenerator` can be composed with other `IEmbeddingGenerator<string, Embedding<float>>` instances to provide rate-limiting functionality.

## Build with Microsoft.Extensions.AI

You can start building with `Microsoft.Extensions.AI` in the following ways:

- **Library developers**: If you own libraries that provide clients for AI services, consider implementing the interfaces in your libraries. This allows users to easily integrate your NuGet package via the abstractions.
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
