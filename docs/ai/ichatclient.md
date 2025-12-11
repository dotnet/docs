---
title: Use the IChatClient interface
description: Learn how to use the IChatClient interface to get model responses and call tools
ms.date: 12/10/2025
---

# Use the IChatClient interface

The <xref:Microsoft.Extensions.AI.IChatClient> interface defines a client abstraction responsible for interacting with AI services that provide chat capabilities. It includes methods for sending and receiving messages with multi-modal content (such as text, images, and audio), either as a complete set or streamed incrementally. Additionally, it allows for retrieving strongly typed services provided by the client or its underlying services.

.NET libraries that provide clients for language models and services can provide an implementation of the `IChatClient` interface. Any consumers of the interface are then able to interoperate seamlessly with these models and services via the abstractions. You can see a simple implementation at [Sample implementations of IChatClient and IEmbeddingGenerator](advanced/sample-implementations.md).

## Request a chat response

With an instance of <xref:Microsoft.Extensions.AI.IChatClient>, you can call the <xref:Microsoft.Extensions.AI.IChatClient.GetResponseAsync*?displayProperty=nameWithType> method to send a request and get a response. The request is composed of one or more messages, each of which is composed of one or more pieces of content. Accelerator methods exist to simplify common cases, such as constructing a request for a single piece of text content.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI/Program.cs":::

The core `IChatClient.GetResponseAsync` method accepts a list of messages. This list represents the history of all messages that are part of the conversation.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.GetResponseAsyncArgs/Program.cs" id="Snippet1":::

The <xref:Microsoft.Extensions.AI.ChatResponse> that's returned from `GetResponseAsync` exposes a list of <xref:Microsoft.Extensions.AI.ChatMessage> instances that represent one or more messages generated as part of the operation. In common cases, there is only one response message, but in some situations, there can be multiple messages. The message list is ordered, such that the last message in the list represents the final message to the request. To provide all of those response messages back to the service in a subsequent request, you can add the messages from the response back into the messages list.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.AddMessages/Program.cs" id="Snippet1":::

## Request a streaming chat response

The inputs to <xref:Microsoft.Extensions.AI.IChatClient.GetStreamingResponseAsync*?displayProperty=nameWithType> are identical to those of `GetResponseAsync`. However, rather than returning the complete response as part of a <xref:Microsoft.Extensions.AI.ChatResponse> object, the method returns an <xref:System.Collections.Generic.IAsyncEnumerable`1> where `T` is <xref:Microsoft.Extensions.AI.ChatResponseUpdate>, providing a stream of updates that collectively form the single response.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.GetStreamingResponseAsync/Program.cs" id="Snippet1":::

> [!TIP]
> Streaming APIs are nearly synonymous with AI user experiences. C# enables compelling scenarios with its `IAsyncEnumerable<T>` support, allowing for a natural and efficient way to stream data.

As with `GetResponseAsync`, you can add the updates from <xref:Microsoft.Extensions.AI.IChatClient.GetStreamingResponseAsync*?displayProperty=nameWithType> back into the messages list. Because the updates are individual pieces of a response, you can use helpers like <xref:Microsoft.Extensions.AI.ChatResponseExtensions.ToChatResponse(System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatResponseUpdate})> to compose one or more updates back into a single <xref:Microsoft.Extensions.AI.ChatResponse> instance.

Helpers like <xref:Microsoft.Extensions.AI.ChatResponseExtensions.AddMessages*> compose a <xref:Microsoft.Extensions.AI.ChatResponse> and then extract the composed messages from the response and add them to a list.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.AddMessages/Program.cs" id="Snippet2":::

## Tool calling

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

For more information about creating AI functions, see [Access data in AI functions](how-to/access-data-in-functions.md).

You can also use Model Context Protocol (MCP) tools with your `IChatClient`. For more information, see [Build a minimal MCP client](./quickstarts/build-mcp-client.md).

## Cache responses

If you're familiar with [caching in .NET](../core/extensions/caching.md), it's good to know that <xref:Microsoft.Extensions.AI> provides delegating `IChatClient` implementations for caching. The <xref:Microsoft.Extensions.AI.DistributedCachingChatClient> is an `IChatClient` that layers caching around another arbitrary `IChatClient` instance. When a novel chat history is submitted to the `DistributedCachingChatClient`, it forwards it to the underlying client and then caches the response before sending it back to the consumer. The next time the same history is submitted, such that a cached response can be found in the cache, the `DistributedCachingChatClient` returns the cached response rather than forwarding the request along the pipeline.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.CacheResponses/Program.cs":::

This example depends on the [📦 Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory) NuGet package. For more information, see [Caching in .NET](../core/extensions/caching.md).

## Use telemetry

Another example of a delegating chat client is the <xref:Microsoft.Extensions.AI.OpenTelemetryChatClient>. This implementation adheres to the [OpenTelemetry Semantic Conventions for Generative AI systems](https://opentelemetry.io/docs/specs/semconv/gen-ai/). Similar to other `IChatClient` delegators, it layers metrics and spans around other arbitrary `IChatClient` implementations.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.UseTelemetry/Program.cs":::

(The preceding example depends on the [📦 OpenTelemetry.Exporter.Console](https://www.nuget.org/packages/OpenTelemetry.Exporter.Console) NuGet package.)

Alternatively, the <xref:Microsoft.Extensions.AI.LoggingChatClient> and corresponding <xref:Microsoft.Extensions.AI.LoggingChatClientBuilderExtensions.UseLogging(Microsoft.Extensions.AI.ChatClientBuilder,Microsoft.Extensions.Logging.ILoggerFactory,System.Action{Microsoft.Extensions.AI.LoggingChatClient})> method provide a simple way to write log entries to an <xref:Microsoft.Extensions.Logging.ILogger> for every request and response.

## Provide options

Every call to <xref:Microsoft.Extensions.AI.IChatClient.GetResponseAsync*> or <xref:Microsoft.Extensions.AI.IChatClient.GetStreamingResponseAsync*> can optionally supply a <xref:Microsoft.Extensions.AI.ChatOptions> instance containing additional parameters for the operation. The most common parameters among AI models and services show up as strongly typed properties on the type, such as <xref:Microsoft.Extensions.AI.ChatOptions.Temperature?displayProperty=nameWithType>. Other parameters can be supplied by name in a weakly typed manner, via the <xref:Microsoft.Extensions.AI.ChatOptions.AdditionalProperties?displayProperty=nameWithType> dictionary, or via an options instance that the underlying provider understands, using the <xref:Microsoft.Extensions.AI.ChatOptions.RawRepresentationFactory?displayProperty=nameWithType> property.

You can also specify options when building an `IChatClient` with the fluent <xref:Microsoft.Extensions.AI.ChatClientBuilder> API by chaining a call to the <xref:Microsoft.Extensions.AI.ConfigureOptionsChatClientBuilderExtensions.ConfigureOptions(Microsoft.Extensions.AI.ChatClientBuilder,System.Action{Microsoft.Extensions.AI.ChatOptions})> extension method. This delegating client wraps another client and invokes the supplied delegate to populate a `ChatOptions` instance for every call. For example, to ensure that the <xref:Microsoft.Extensions.AI.ChatOptions.ModelId?displayProperty=nameWithType> property defaults to a particular model name, you can use code like the following:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.ProvideOptions/Program.cs":::

## Functionality pipelines

`IChatClient` instances can be layered to create a pipeline of components that each add additional functionality. These components can come from `Microsoft.Extensions.AI`, other NuGet packages, or custom implementations. This approach allows you to augment the behavior of the `IChatClient` in various ways to meet your specific needs. Consider the following code snippet that layers a distributed cache, function invocation, and OpenTelemetry tracing around a sample chat client:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.FunctionalityPipelines/Program.cs" id="Snippet1":::

## Custom `IChatClient` middleware

To add additional functionality, you can implement `IChatClient` directly or use the <xref:Microsoft.Extensions.AI.DelegatingChatClient> class. This class serves as a base for creating chat clients that delegate operations to another `IChatClient` instance. It simplifies chaining multiple clients, which allows calls to pass through to an underlying client.

The `DelegatingChatClient` class provides default implementations for methods like `GetResponseAsync`, `GetStreamingResponseAsync`, and `Dispose`, which forward calls to the inner client. A derived class can then override only the methods it needs to augment the behavior, while delegating other calls to the base implementation. This approach is useful for creating flexible and modular chat clients that are easy to extend and compose.

The following is an example class derived from `DelegatingChatClient` that uses the [System.Threading.RateLimiting](https://www.nuget.org/packages/System.Threading.RateLimiting) library to provide rate-limiting functionality.

:::code language="csharp" source="snippets/microsoft-extensions-ai/AI.Shared/RateLimitingChatClient.cs":::

As with other `IChatClient` implementations, the `RateLimitingChatClient` can be composed:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.CustomClientMiddle/Program.cs":::

To simplify the composition of such components with others, component authors should create a `Use*` extension method for registering the component into a pipeline. For example, consider the following `UseRateLimiting` extension method:

:::code language="csharp" source="snippets/microsoft-extensions-ai/AI.Shared/RateLimitingChatClientExtensions.cs" id="one":::

Such extensions can also query for relevant services from the DI container; the <xref:System.IServiceProvider> used by the pipeline is passed in as an optional parameter:

:::code language="csharp" source="snippets/microsoft-extensions-ai/AI.Shared/RateLimitingChatClientExtensions.OptionalOverload.cs"  id="two":::

Now it's easy for the consumer to use this in their pipeline, for example:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.ConsumeClientMiddleware/Program.cs" id="SnippetUse":::

The previous extension methods demonstrate using a `Use` method on <xref:Microsoft.Extensions.AI.ChatClientBuilder>. `ChatClientBuilder` also provides <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use*> overloads that make it easier to write such delegating handlers. For example, in the earlier `RateLimitingChatClient` example, the overrides of `GetResponseAsync` and `GetStreamingResponseAsync` only need to do work before and after delegating to the next client in the pipeline. To achieve the same thing without writing a custom class, you can use an overload of `Use` that accepts a delegate that's used for both `GetResponseAsync` and `GetStreamingResponseAsync`, reducing the boilerplate required:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.UseExample/Program.cs":::

For scenarios where you need a different implementation for `GetResponseAsync` and `GetStreamingResponseAsync` to handle their unique return types, you can use the <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(System.Func{System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,Microsoft.Extensions.AI.IChatClient,System.Threading.CancellationToken,System.Threading.Tasks.Task{Microsoft.Extensions.AI.ChatResponse}},System.Func{System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,Microsoft.Extensions.AI.IChatClient,System.Threading.CancellationToken,System.Collections.Generic.IAsyncEnumerable{Microsoft.Extensions.AI.ChatResponseUpdate}})> overload that accepts a delegate for each.

## Dependency injection

<xref:Microsoft.Extensions.AI.IChatClient> implementations are often provided to an application via [dependency injection (DI)](../core/extensions/dependency-injection.md). In the following example, an <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> is added into the DI container, as is an `IChatClient`. The registration for the `IChatClient` uses a builder that creates a pipeline containing a caching client (which then uses an `IDistributedCache` retrieved from DI) and the sample client. The injected `IChatClient` can be retrieved and used elsewhere in the app.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.DependencyInjection/Program.cs":::

What instance and configuration is injected can differ based on the current needs of the application, and multiple pipelines can be injected with different keys.

## Stateless vs. stateful clients

_Stateless_ services require all relevant conversation history to be sent back on every request. In contrast, _stateful_ services keep track of the history and require only additional messages to be sent with a request. The <xref:Microsoft.Extensions.AI.IChatClient> interface is designed to handle both stateless and stateful AI services.

When working with a stateless service, callers maintain a list of all messages. They add in all received response messages and provide the list back on subsequent interactions.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.StatelessStateful/Program.cs" id="Snippet1":::

For stateful services, you might already know the identifier used for the relevant conversation. You can put that identifier into <xref:Microsoft.Extensions.AI.ChatOptions.ConversationId?displayProperty=nameWithType>. Usage then follows the same pattern, except there's no need to maintain a history manually.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.StatelessStateful/Program.cs" id="Snippet2":::

Some services might support automatically creating a conversation ID for a request that doesn't have one, or creating a new conversation ID that represents the current state of the conversation after incorporating the last round of messages. In such cases, you can transfer the <xref:Microsoft.Extensions.AI.ChatResponse.ConversationId?displayProperty=nameWithType> over to the `ChatOptions.ConversationId` for subsequent requests. For example:

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.StatelessStateful/Program.cs" id="Snippet3":::

If you don't know ahead of time whether the service is stateless or stateful, you can check the response <xref:Microsoft.Extensions.AI.ChatResponse.ConversationId> and act based on its value. If it's set, then that value is propagated to the options and the history is cleared so as to not resend the same history again. If the response `ConversationId` isn't set, then the response message is added to the history so that it's sent back to the service on the next turn.

:::code language="csharp" source="snippets/microsoft-extensions-ai/ConsoleAI.StatelessStateful/Program.cs" id="Snippet4":::

## Chat reduction (experimental)

> [!IMPORTANT]
> This feature is experimental and subject to change.

Chat reduction helps manage conversation history by limiting the number of messages or summarizing older messages when the conversation exceeds a specified length. The `Microsoft.Extensions.AI` library provides reducers like <xref:Microsoft.Extensions.AI.MessageCountingChatReducer> that limits the number of non-system messages, and <xref:Microsoft.Extensions.AI.SummarizingChatReducer> that automatically summarizes older messages while preserving context.

## Tool reduction (experimental)

> [!IMPORTANT]
> This feature is experimental and subject to change.

Tool reduction helps manage large tool catalogs by trimming them based on relevance to the current conversation context. The <xref:Microsoft.Extensions.AI.IToolReductionStrategy> interface defines strategies for reducing the number of tools sent to the model. The library provides implementations like <xref:Microsoft.Extensions.AI.EmbeddingToolReductionStrategy> that ranks tools by embedding similarity to the conversation. Use the <xref:Microsoft.Extensions.AI.ChatClientBuilderToolReductionExtensions.UseToolReduction*> extension method to add tool reduction to your chat client pipeline.
