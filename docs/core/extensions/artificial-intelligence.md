---
title: Artificial Intelligence in .NET (Preview)
description: Learn how to use the Microsoft.Extensions.AI library to integrate and interact with various AI services in your .NET applications.
author: IEvangelist
ms.author: dapine
ms.date: 12/16/2024
---

# Artificial Intelligence in .NET (Preview)

With a growing variety of artificial intelligence (AI) services available, developers need a way to integrate and interact with these services in their .NET applications. The `Microsoft.Extensions.AI` library provides a unified approach for representing generative AI components, enabling seamless integration and interoperability with various AI services. This article introduces the library, its installation, and usage examples to help you get started.

## Install the package

To install the [📦 Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI) NuGet package, use either the .NET CLI or add a package reference directly to your C# project file:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.AI --prelease
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.AI"
                  Version="*" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Usage examples

The <xref:Microsoft.Extensions.AI.IChatClient> interface defines a client abstraction responsible for interacting with AI services that provide chat capabilities. It includes methods for sending and receiving messages with multi-modal content (text, images, audio, etc.), either as a complete set or streamed incrementally. Additionally, it provides metadata information about the client and allows retrieving strongly typed services.

> [!IMPORTANT]
> For more usage examples and real-world scenarios, see [AI for .NET developers](/dotnet/ai/).

### The `IChatClient` interface

The following sample implements `IChatClient` to show the general structure.

:::code language="csharp" source="snippets/ai/ConsoleAI/SampleChatClient.cs":::

You can find other concrete implementations of `IChatClient` in the following NuGet packages:

- [📦 Microsoft.Extensions.AI.AzureAIInference](https://www.nuget.org/packages/Microsoft.Extensions.AI.AzureAIInference): Implementation backed by [Azure AI Model Inference API](/azure/ai-studio/reference/reference-model-inference-api).
- [📦 Microsoft.Extensions.AI.Ollama](https://www.nuget.org/packages/Microsoft.Extensions.AI.Ollama): Implementation backed by [Ollama](https://ollama.com/).
- [📦 Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI): Implementation backed by either [OpenAI](https://openai.com/) or OpenAI-compatible endpoints (such as [Azure OpenAI](https://azure.microsoft.com/products/ai-services/openai-service)).

#### Request chat completion

To request a completion, call the <xref:Microsoft.Extensions.AI.IChatClient.CompleteAsync*?displayProperty=nameWithType> method. The request is composed of one or more messages, each of which is composed of one or more pieces of content. Accelerator methods exist to simplify common cases, such as constructing a request for a single piece of text content.

:::code language="csharp" source="snippets/ai/ConsoleAI/Program.cs":::

The core `IChatClient.CompleteAsync` method accepts a list of messages. This list represents the history of all messages that are part of the conversation.

```csharp
using Microsoft.Extensions.AI;

IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "my-custom-model");

Console.WriteLine(await client.CompleteAsync(
[
    new(ChatRole.System, "You are a helpful AI assistant"),
    new(ChatRole.User, "What is AI?"),
]));
```

Each message in the history is represented by a <xref:Microsoft.Extensions.AI.ChatMessage> object. The `ChatMessage` class provides a <xref:Microsoft.Extensions.AI.ChatMessage.Role?displayProperty=nameWithType> property that indicates the role of the message. By default, the <xref:Microsoft.Extensions.AI.ChatRole.User?displayProperty=nameWithType> is used. The following roles are available:

- <xref:Microsoft.Extensions.AI.ChatRole.Assistant?displayProperty=nameWithType>: Instructs or sets the behavior of the assistant.
- <xref:Microsoft.Extensions.AI.ChatRole.System?displayProperty=nameWithType>: Provides responses to system-instructed, user-prompted input.
- <xref:Microsoft.Extensions.AI.ChatRole.Tool?displayProperty=nameWithType>: Provides additional information and references for chat completions.
- <xref:Microsoft.Extensions.AI.ChatRole.User?displayProperty=nameWithType>: Provides input for chat completions.

Each chat message is instantiated, assigning to its <xref:Microsoft.Extensions.AI.ChatMessage.Contents> property—a new <xref:Microsoft.Extensions.AI.TextContent>. There are various [types of content](xref:Microsoft.Extensions.AI.AIContent) that may be represented, such as a simple string, or it may be a more complex object that represents a multi-modal message with text, images, audio, etc.:

- <xref:Microsoft.Extensions.AI.AudioContent>
- <xref:Microsoft.Extensions.AI.DataContent>
- <xref:Microsoft.Extensions.AI.FunctionCallContent>
- <xref:Microsoft.Extensions.AI.FunctionResultContent>
- <xref:Microsoft.Extensions.AI.ImageContent>
- <xref:Microsoft.Extensions.AI.TextContent>
- <xref:Microsoft.Extensions.AI.UsageContent>

#### Request chat completion with streaming

The inputs to <xref:Microsoft.Extensions.AI.IChatClient.CompleteStreamingAsync*?displayProperty=nameWithType> are identical to those of `CompleteAsync`. However, rather than returning the complete response as part of a <xref:Microsoft.Extensions.AI.ChatCompletion> object, the method returns an <xref:System.Collections.Generic.IAsyncEnumerable`1> where `T` is <xref:Microsoft.Extensions.AI.StreamingChatCompletionUpdate>, providing a stream of updates that collectively form the single response.

```csharp
using Microsoft.Extensions.AI;

IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "my-custom-model");

await foreach (var update in client.CompleteStreamingAsync("What is AI?"))
{
    Console.Write(update);
}
```

> [!TIP]
> Streaming APIs are nearly synonymous with AI user experiences. C# enables compelling scenarios with its `IAsyncEnumerable<T>` support, allowing for a natural and efficient way to stream data.

#### Tool calling

Some models and services support _tool calling_, where requests can include tools for the model to invoke functions to gather additional information. Instead of sending a final response, the model requests a function invocation with specific arguments. The client then invokes the function and sends the results back to the model along with the conversation history. The `Microsoft.Extensions.AI` library includes abstractions for various message content types, including function call requests and results. While consumers can interact with this content directly, `Microsoft.Extensions.AI` automates these interactions and provides:

- <xref:Microsoft.Extensions.AI.AIFunction>: Represents a function that can be described to an AI service and invoked.
- <xref:Microsoft.Extensions.AI.AIFunctionFactory>: Provides factory methods for creating commonly used implementations of `AIFunction`.
- <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient>: Wraps an `IChatClient` to add automatic function invocation capabilities.

Consider the following example, that demonstrates a random function invocation:

```csharp
using System.ComponentModel;
using Microsoft.Extensions.AI;

[Description("Gets the current weather")]
string GetCurrentWeather() => Random.Shared.NextDouble() > 0.5
    ? "It's sunny"
    : "It's raining";

IChatClient client = new ChatClientBuilder(
        new OllamaChatClient(new Uri("http://localhost:11434"), "llama3.1"))
    .UseFunctionInvocation()
    .Build();

var response = client.CompleteStreamingAsync(
    "Should I wear a rain coat?",
    new() { Tools = [ AIFunctionFactory.Create(GetCurrentWeather) ] });

await foreach (var update in response)
{
    Console.Write(update);
}
```

The preceding code:

- Defines a function named `GetCurrentWeather` that returns a random weather forecast.
  - This function is decorated with a `Description` attribute, which is used to provide a description of the function to the AI service.
- Instantiates a `ChatClientBuilder` with an `OllamaChatClient` and configures it to use function invocation.
- Calls `CompleteStreamingAsync` on the client, passing a prompt and a list of tools that includes a function created with `AIFunctionFactory.Create`.
- Iterates over the response, printing each update to the console.

#### Cache responses

If you're familiar with [Caching in .NET](caching.md), it's good to know that <xref:Microsoft.Extensions.AI> provides other such delegating `IChatClient` implementations. The <xref:Microsoft.Extensions.AI.DistributedCachingChatClient> is an `IChatClient` that layers caching around another arbitrary `IChatClient` instance. When a unique chat history is submitted to the `DistributedCachingChatClient`, it forwards it along to the underlying client, and then caches the response before it being sent back to the consumer. The next time the same history is submitted, such that a cached response can be found in the cache, the `DistributedCachingChatClient` can return back the cached response rather than needing to forward the request along the pipeline.

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

var sampleChatClient = new SampleChatClient(new Uri("http://coolsite.ai"), "my-custom-model");
IChatClient client = new ChatClientBuilder(sampleChatClient)
    .UseDistributedCache(new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions())))
    .Build();

string[] prompts = ["What is AI?", "What is .NET?", "What is AI?"];

foreach (var prompt in prompts)
{
    await foreach (var update in client.CompleteStreamingAsync(prompt))
    {
        Console.Write(update);
    }

    Console.WriteLine();
}
```

#### Use telemetry

Another example of a delegating chat client is the <xref:Microsoft.Extensions.AI.OpenTelemetryChatClient>. This implementation adheres to the [OpenTelemetry Semantic Conventions for Generative AI systems](https://opentelemetry.io/docs/specs/semconv/gen-ai/). Similar to other `IChatClient` delegators, it layers metrics and spans around any underlying `IChatClient` implementation, providing enhanced observability.

```csharp
using Microsoft.Extensions.AI;
using OpenTelemetry.Trace;

// Configure OpenTelemetry exporter
var sourceName = Guid.NewGuid().ToString();
var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .AddSource(sourceName)
    .AddConsoleExporter()
    .Build();

var sampleChatClient = new SampleChatClient(
    new Uri("http://coolsite.ai"), "my-custom-model");

IChatClient client = new ChatClientBuilder(sampleChatClient)
    .UseOpenTelemetry(sourceName, static c => c.EnableSensitiveData = true)
    .Build();

Console.WriteLine((await client.CompleteAsync("What is AI?")).Message);
```

#### Provide options

Every call to <xref:Microsoft.Extensions.AI.IChatClient.CompleteAsync*> or <xref:Microsoft.Extensions.AI.IChatClient.CompleteStreamingAsync*> may optionally supply a <xref:Microsoft.Extensions.AI.ChatOptions> instance containing additional parameters for the operation. The most common parameters among AI models and services show up as strongly typed properties on the type, such as <xref:Microsoft.Extensions.AI.ChatOptions.Temperature?displayProperty=nameWithType>. Other parameters can be supplied by name in a weakly typed manner via the <xref:Microsoft.Extensions.AI.ChatOptions.AdditionalProperties?displayProperty=nameWithType> dictionary.

Options may also be specified when building an `IChatClient` with the fluent <xref:Microsoft.Extensions.AI.ChatClientBuilder> API, and chaining a call to the `ConfigureOptions` extension method. This delegating client wraps another client and invokes the supplied delegate to populate a `ChatOptions` instance for every call. For example, to ensure that the <xref:Microsoft.Extensions.AI.ChatOptions.ModelId?displayProperty=nameWithType> property defaults to a particular model name, code like the following can be used:

```csharp
using Microsoft.Extensions.AI;

IChatClient client = new ChatClientBuilder(
        new OllamaChatClient(new Uri("http://localhost:11434")))
    .ConfigureOptions(options => options.ModelId ??= "phi3")
    .Build();

// will request "phi3"
Console.WriteLine(await client.CompleteAsync("What is AI?"));

// will request "llama3.1"
Console.WriteLine(await client.CompleteAsync("What is AI?", new() { ModelId = "llama3.1" }));
```

#### Functionality pipelines

`IChatClient` instances can be layered to create a pipeline of components, each adding specific functionality. These components can come from `Microsoft.Extensions.AI`, other NuGet packages, or custom implementations. This approach allows you to augment the behavior of the `IChatClient` in various ways to meet your specific needs. Consider the following example code that layers a distributed cache, function invocation, and OpenTelemetry tracing around a sample chat client:

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OpenTelemetry.Trace;

// Configure OpenTelemetry exporter
var sourceName = Guid.NewGuid().ToString();
var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .AddSource(sourceName)
    .AddConsoleExporter()
    .Build();

// Explore changing the order of the intermediate "Use" calls to see that impact
// that has on what gets cached, traced, etc.
IChatClient client = new ChatClientBuilder(
        new OllamaChatClient(new Uri("http://localhost:11434"), "llama3.1"))
    .UseDistributedCache(new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions())))
    .UseFunctionInvocation()
    .UseOpenTelemetry(sourceName, static c => c.EnableSensitiveData = true)
    .Build();

ChatOptions options = new()
{
    Tools =
    [
        AIFunctionFactory.Create(
            () => Random.Shared.NextDouble() > 0.5 ? "It's sunny" : "It's raining",
            name: "GetCurrentWeather", 
            description: "Gets the current weather")
    ]
};

for (int i = 0; i < 3; ++i)
{
    List<ChatMessage> history =
    [
        new ChatMessage(ChatRole.System, "You are a helpful AI assistant"),
        new ChatMessage(ChatRole.User, "Do I need an umbrella?")
    ];

    Console.WriteLine(await client.CompleteAsync(history, options));
}
```

#### Custom `IChatClient` middleware

To add additional functionality, you can implement `IChatClient` directly or use the <xref:Microsoft.Extensions.AI.DelegatingChatClient> class. This class serves as a base for creating chat clients that delegate operations to another `IChatClient` instance. It simplifies chaining multiple clients, allowing calls to pass through to an underlying client.

The `DelegatingChatClient` class provides default implementations for methods like `CompleteAsync`, `CompleteStreamingAsync`, and `Dispose`, which forward calls to the inner client. You can derive from this class and override only the methods you need to enhance behavior, while delegating other calls to the base implementation. This approach helps create flexible and modular chat clients that are easy to extend and compose.

The following is an example class derived from `DelegatingChatClient` to provide rate limiting functionality, utilizing the <xref:System.Threading.RateLimiting.RateLimiter>:

```csharp
using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

public sealed class RateLimitingChatClient(
    IChatClient innerClient, RateLimiter rateLimiter) 
        : DelegatingChatClient(innerClient)
{
    public override async Task<ChatCompletion> CompleteAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
            .ConfigureAwait(false);

        if (!lease.IsAcquired)
        {
            throw new InvalidOperationException("Unable to acquire lease.");
        }

        return await base.CompleteAsync(chatMessages, options, cancellationToken)
            .ConfigureAwait(false);
    }

    public override async IAsyncEnumerable<StreamingChatCompletionUpdate> CompleteStreamingAsync(
        IList<ChatMessage> chatMessages,
        ChatOptions? options = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
            .ConfigureAwait(false);

        if (!lease.IsAcquired)
        {
            throw new InvalidOperationException("Unable to acquire lease.");
        }

        await foreach (var update in base.CompleteStreamingAsync(chatMessages, options, cancellationToken)
            .ConfigureAwait(false))
        {
            yield return update;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            rateLimiter.Dispose();
        }

        base.Dispose(disposing);
    }
}
```

Composition of the `RateLimitingChatClient` with another client is straightforward:

```csharp
using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

var client = new RateLimitingChatClient(
    new SampleChatClient(new Uri("http://localhost"), "test"),
    new ConcurrencyLimiter(new() { PermitLimit = 1, QueueLimit = int.MaxValue }));

await client.CompleteAsync("What color is the sky?");
```

To simplify the composition of such components with others, the author of the component is recommended to create a `Use*` extension method for registering this component into a pipeline, for example consider the following:

```csharp
public static class RateLimitingChatClientExtensions
{
    public static ChatClientBuilder UseRateLimiting(
        this ChatClientBuilder builder, RateLimiter rateLimiter) =>
        builder.Use(innerClient => new RateLimitingChatClient(innerClient, rateLimiter));
}
```

Such extensions may also query for relevant services from the DI container; the <xref:System.IServiceProvider> used by the pipeline is passed in as an optional parameter:

```csharp
public static class RateLimitingChatClientExtensions
{
    public static ChatClientBuilder UseRateLimiting(
        this ChatClientBuilder builder, RateLimiter? rateLimiter = null) =>
        builder.Use((innerClient, services) => 
            new RateLimitingChatClient(
                innerClient,
                rateLimiter ?? services.GetRequiredService<RateLimiter>()));
}
```

The consumer can then easily use this in their pipeline, for example:

```csharp
var client = new SampleChatClient(new Uri("http://localhost"), "test")
    .AsBuilder()
    .UseDistributedCache()
    .UseRateLimiting()
    .UseOpenTelemetry()
    .Build(services);
```

The preceding extension methods demonstrate using a `Use` method on <xref:Microsoft.Extensions.AI.ChatClientBuilder>. The `ChatClientBuilder` also provides <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use*> overloads that make it easier to write such delegating handlers.

- <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(Microsoft.Extensions.AI.IChatClient)>
- <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(System.Func{Microsoft.Extensions.AI.IChatClient,Microsoft.Extensions.AI.IChatClient})>
- <xref:Microsoft.Extensions.AI.ChatClientBuilder.Use(System.Func{System.IServiceProvider,Microsoft.Extensions.AI.IChatClient,Microsoft.Extensions.AI.IChatClient})>

For example, in the earlier `RateLimitingChatClient` example, the overrides of `CompleteAsync` and `CompleteStreamingAsync` only need to do work before and after delegating to the next client in the pipeline. To achieve the same thing without writing a custom class, an overload of `Use` may be used that accepts a delegate which is used for both `CompleteAsync` and `CompleteStreamingAsync`, reducing the boilerplate required:

```csharp
RateLimiter rateLimiter = new ConcurrencyLimiter(new()
{
    PermitLimit = 1, 
    QueueLimit = int.MaxValue
});

var client = new SampleChatClient(new Uri("http://localhost"), "test")
    .AsBuilder()
    .UseDistributedCache()
    .Use(static async (chatMessages, options, nextAsync, cancellationToken) =>
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
            .ConfigureAwait(false);

        if (!lease.IsAcquired)
        {
            throw new InvalidOperationException("Unable to acquire lease.");
        }

        await nextAsync(chatMessages, options, cancellationToken);
    })
    .UseOpenTelemetry()
    .Build();
```

The preceding overload internally uses a `AnonymousDelegatingChatClient`, which enables more complicated patterns with only a little additional code. For example, to achieve the same as above but with the <xref:System.Threading.RateLimiting.RateLimiter> retrieved from DI:

```csharp
var client = new SampleChatClient(new Uri("http://localhost"), "test")
    .AsBuilder()
    .UseDistributedCache()
    .Use(static (innerClient, services) =>
    {
        var rateLimiter = services.GetRequiredService<RateLimiter>();

        return new AnonymousDelegatingChatClient(
            innerClient, async (chatMessages, options, nextAsync, cancellationToken) =>
        {
            using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
                .ConfigureAwait(false);

            if (!lease.IsAcquired)
            {
                throw new InvalidOperationException("Unable to acquire lease.");
            }

            await nextAsync(chatMessages, options, cancellationToken);
        });
    })
    .UseOpenTelemetry()
    .Build();
```

For scenarios where the developer would like to specify delegating implementations of `CompleteAsync` and `CompleteStreamingAsync` inline, and where it's important to be able to write a different implementation for each in order to handle their unique return types specially, another overload of `Use` exists that accepts a delegate for each.

#### Dependency Injection

<xref:Microsoft.Extensions.AI.IChatClient> implementations will typically be provided to an application via [dependency injection (DI)](dependency-injection.md). In this example, an <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> is added into the DI container, as is an `IChatClient`. The registration for the `IChatClient` employs a builder that creates a pipeline containing a caching client (which will then use an `IDistributedCache` retrieved from DI) and the sample client. Elsewhere in the app, the injected `IChatClient` may be retrieved and used.

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// App Setup
var builder = Host.CreateApplicationBuilder();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddChatClient(new SampleChatClient(new Uri("http://coolsite.ai"), "my-custom-model"))
    .UseDistributedCache();

var host = builder.Build();

// Elsewhere in the app
var chatClient = host.Services.GetRequiredService<IChatClient>();

Console.WriteLine(await chatClient.CompleteAsync("What is AI?"));
```

What instance and configuration is injected may differ based on the current needs of the application, and multiple pipelines may be injected with different keys.

### The `IEmbeddingGenerator` interface

The <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> interface represents a generic generator of embeddings. Here, `TInput` is the type of input values being embedded, and `TEmbedding` is the type of generated embedding, which inherits from the <xref:Microsoft.Extensions.AI.Embedding> class.

The `Embedding` class serves as a base class for embeddings generated by an `IEmbeddingGenerator`. It's designed to store and manage the metadata and data associated with embeddings. Derived types like `Embedding<T>` provide the concrete embedding vector data. For instance, an embedding exposes a <xref:Microsoft.Extensions.AI.Embedding`1.Vector?displayProperty=nameWithType> property to access its embedding data.

The `IEmbeddingGenerator` interface defines a method to asynchronously generate embeddings for a collection of input values, with optional configuration and cancellation support. It also provides metadata describing the generator and allows for the retrieval of strongly typed services that may be provided by the generator or its underlying services.

#### Sample implementation

Consider the following sample implementation of an `IEmbeddingGenerator` to show the general structure but that just generates random embedding vectors.

:::code language="csharp" source="snippets/ai/ConsoleAI/SampleEmbeddingGenerator.cs":::

The preceding code:

- Defines a class named `SampleEmbeddingGenerator` that implements the `IEmbeddingGenerator<string, Embedding<float>>` interface.
- Its primary constructor accepts an endpoint and model ID, which are used to identify the generator.
- Exposes a `Metadata` property that provides metadata about the generator.
- Implements the `GenerateAsync` method to generate embeddings for a collection of input values:
  - It simulates an asynchronous operation by delaying for 100 milliseconds.
  - Returns random embeddings for each input value.

You can find actual concrete implementations in the following packages:

- [📦 Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI)
- [📦 Microsoft.Extensions.AI.Ollama](https://www.nuget.org/packages/Microsoft.Extensions.AI.Ollama)

#### Create embeddings

The primary operation performed with an <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> is generating embeddings, which is accomplished with its <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2.GenerateAsync*> method.

```csharp
using Microsoft.Extensions.AI;

IEmbeddingGenerator<string, Embedding<float>> generator =
    new SampleEmbeddingGenerator(
        new Uri("http://coolsite.ai"), "my-custom-model");

foreach (var embedding in await generator.GenerateAsync(["What is AI?", "What is .NET?"]))
{
    Console.WriteLine(string.Join(", ", embedding.Vector.ToArray()));
}
```

#### Custom `IEmbeddingGenerator` middleware

As with `IChatClient`, `IEmbeddingGenerator` implementations may be layered. Just as `Microsoft.Extensions.AI` provides delegating implementations of `IChatClient` for caching and telemetry, it does so for `IEmbeddingGenerator` as well.

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OpenTelemetry.Trace;

// Configure OpenTelemetry exporter
var sourceName = Guid.NewGuid().ToString();
var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .AddSource(sourceName)
    .AddConsoleExporter()
    .Build();

// Explore changing the order of the intermediate "Use" calls to see that impact
// that has on what gets cached, traced, etc.
var generator = new EmbeddingGeneratorBuilder<string, Embedding<float>>(
        new SampleEmbeddingGenerator(new Uri("http://coolsite.ai"), "my-custom-model"))
    .UseDistributedCache(
        new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions())))
    .UseOpenTelemetry(sourceName)
    .Build();

var embeddings = await generator.GenerateAsync(
[
    "What is AI?",
    "What is .NET?",
    "What is AI?"
]);

foreach (var embedding in embeddings)
{
    Console.WriteLine(string.Join(", ", embedding.Vector.ToArray()));
}
```

The `IEmbeddingGenerator` enables building custom middleware that extends the functionality of an `IEmbeddingGenerator`. The <xref:Microsoft.Extensions.AI.DelegatingEmbeddingGenerator`2> class is an implementation of the `IEmbeddingGenerator<TInput, TEmbedding>` interface that serves as a base class for creating embedding generators which delegate their operations to another `IEmbeddingGenerator<TInput, TEmbedding>` instance. It allows for chaining multiple generators in any order, passing calls through to an underlying generator. The class provides default implementations for methods such as <xref:Microsoft.Extensions.AI.DelegatingEmbeddingGenerator`2.GenerateAsync*> and `Dispose`, which forward the calls to the inner generator instance, enabling flexible and modular embedding generation.

The following is an example implementation of such a delegating embedding generator that rate limits embedding generation requests:

```csharp
using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

public class RateLimitingEmbeddingGenerator(
    IEmbeddingGenerator<string, Embedding<float>> innerGenerator, RateLimiter rateLimiter) 
        : DelegatingEmbeddingGenerator<string, Embedding<float>>(innerGenerator)
{
    public override async Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(
        IEnumerable<string> values,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        using var lease = await rateLimiter.AcquireAsync(permitCount: 1, cancellationToken)
            .ConfigureAwait(false);

        if (!lease.IsAcquired)
        {
            throw new InvalidOperationException("Unable to acquire lease.");
        }

        return await base.GenerateAsync(values, options, cancellationToken);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            rateLimiter.Dispose();
        }

        base.Dispose(disposing);
    }
}
```

This can then be layered around an arbitrary `IEmbeddingGenerator<string, Embedding<float>>` to rate limit all embedding generation operations performed.

```csharp
using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

IEmbeddingGenerator<string, Embedding<float>> generator =
    new RateLimitingEmbeddingGenerator(
        new SampleEmbeddingGenerator(new Uri("http://coolsite.ai"), "my-custom-model"),
        new ConcurrencyLimiter(new() { PermitLimit = 1, QueueLimit = int.MaxValue }));

foreach (var embedding in await generator.GenerateAsync(["What is AI?", "What is .NET?"]))
{
    Console.WriteLine(string.Join(", ", embedding.Vector.ToArray()));
}
```

In this way, the `RateLimitingEmbeddingGenerator` can be composed with other `IEmbeddingGenerator<string, Embedding<float>>` instances to provide rate limiting functionality.

## See also

- [Develop .NET applications with AI features](../../ai/get-started/dotnet-ai-overview.md)
- [Unified AI building blocks for .NET using Microsoft.Extensions.AI](../../ai/ai-extensions.md)
- [Build an AI chat app with .NET](../../ai/quickstarts/get-started-openai.md)
- [.NET dependency injection](dependency-injection.md)
- [Rate limit an HTTP handler in .NET](http-ratelimiter.md)
- [.NET Generic Host](generic-host.md)
- [Caching in .NET](caching.md)
