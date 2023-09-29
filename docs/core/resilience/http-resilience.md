---
title: "Build resilient HTTP apps: Key development patterns"
description: 
author: IEvangelist
ms.author: dapine
ms.date: 09/29/2023
---

# Build resilient HTTP apps: Key development patterns

Building robust HTTP apps that can recover from transient fault errors is a common requirement. To help build resilient HTTP apps, the [Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience) NuGet package provides resilience mechanisms specifically for the <xref:System.Net.Http.HttpClient>. This NuGet package is built on top of _Polly_, which is a popular open-source project. For more information, see [Polly](https://github.com/App-vNext/Polly).

## Get started

To use resilience-patterns in HTTP apps, install the [Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Http.Resilience --version 8.0.0
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Http.Resilience" Version="8.0.0" />
```

---

For more information, see [dotnet add package](../tools/dotnet-add-package.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Add resilience handlers to an HTTP client

To add resilience to an <xref:System.Net.Http.HttpClient>, you chain a call on the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> type that is returned from calling any of the available <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> methods. There are several resilience-centric extensions available, some are standard employing various industry best practices, and others are more customizable.

While the following examples use the `AddHttpClient` extension method, from the [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http).

### The standard resilience handler

The standard resilience handler uses multiple resilience strategies with default options to send the requests and handle any transient errors. The standard resilience handler is added by calling the `AddStandardResilienceHandler` extension method.

```csharp
// A service collection is manually instantiated for this example.
// If you're using a generic host, you'll instead use its service collection:
//
// var host = Host.CreateApplicationBuilder(args);
// host.Services.AddHttpClient<ExampleClient>(client => { ... });

var services = new ServiceCollection();

var builder = services.AddHttpClient<ExampleClient>(
    configureClient: static client =>
    {
        client.BaseAddress = new("https://jsonplaceholder.typicode.com");
    })
    .AddStandardResilienceHandler();
```

The preceding code:

- Adds an <xref:System.Net.Http.HttpClient> for the `ExampleClient` type to the service container.
- Configures the <xref:System.Net.Http.HttpClient> to use `"https://jsonplaceholder.typicode.com"` as the base address.
- Adds the standard resilience handler to the <xref:System.Net.Http.HttpClient>.
- Declares a `builder` (of type `IHttpStandardResilienceHandlerBuilder`), which is used to configure the standard resilience handler. There are extension methods to configure the standard resilience handler.

#### Standard resilience handler defaults

The default configuration chains five resilience strategies in the following order (from the outermost to the innermost):

| Order | Strategy | Description |
|--:|--|--|
| **1** | Rate limiter | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. |
| **2** | Total request timeout | The total request timeout pipeline applies an overall timeout to the execution, ensuring that the request, including retry attempts, doesn't exceed the configured limit. |
| **3** | Retry | The retry pipeline retries the request in case the dependency is slow or returns a transient error. |
| **4** | Circuit breaker | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. |
| **5** | Attempt timeout | The attempt timeout pipeline limits each request attempt duration and throws if it's exceeded. |

### The standard hedging handler

The standard hedging handler wraps the execution of the request with a standard hedging mechanism. Hedging retries slow requests in parallel. The standard hedging handler is added by calling the `AddStandardHedgingHandler` extension method.

To use the standard hedging handler, call `AddStandardHedgingHandler` extension method. The following example configures the `ExampleClient` to use the standard hedging handler.

```csharp
// A service collection is manually instantiated for this example.
// If you're using a generic host, you'll instead use its service collection:
//
// var host = Host.CreateApplicationBuilder(args);
// host.Services.AddHttpClient<ExampleClient>(client => { ... });

var services = new ServiceCollection();

var builder = services.AddHttpClient<ExampleClient>(
    configureClient: static client =>
    {
        client.BaseAddress = new("https://jsonplaceholder.typicode.com");
    })
    .AddStandardHedgingHandler();
```

The preceding code:

- Adds an <xref:System.Net.Http.HttpClient> for the `ExampleClient` type to the service container.
- Configures the <xref:System.Net.Http.HttpClient> to use `"https://jsonplaceholder.typicode.com"` as the base address.
- Adds the standard hedging resilience handler to the <xref:System.Net.Http.HttpClient>.
- Declares a `builder` (of type `IStandardHedgingHandlerBuilder`), which is used to configure the standard hedging resilience handler. There are extension methods to configure the standard hedging resilience handler.

The `ExampleClient` is defined as follows:

:::code source="snippets/http-resilience/ExampleClient.cs":::

The preceding code:

- Defines an `ExampleClient` type that has a constructor that accepts an <xref:System.Net.Http.HttpClient>.
- Exposes a `GetCommentsAsync` method that sends a GET request to the `"/comments"` endpoint and returns the response.

The `Comment` type is defined as follows:

:::code source="snippets/http-resilience/Comment.cs":::

#### Standard hedging handler defaults

The standard hedging uses a pool of circuit breakers to ensure that unhealthy endpoints aren't hedged against. By default, the selection from the pool is based on the URL authority (scheme + host + port).

> [!TIP]
> It's recommended that you configure the way the strategies are selected by calling `StandardHedgingHandlerBuilderExtensions.SelectPipelineByAuthority`.

The preceding code adds the standard hedging handler to the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder>. The default configuration chains five resilience strategies in the following order (from the outermost to the innermost):

| Order | Strategy | Description |
|--:|--|--|
| **1** | Total request timeout | The total request timeout pipeline applies an overall timeout to the execution, ensuring that the request, including hedging attempts, doesn't exceed the configured limit. |
| **2** | Hedging | The hedging strategy executes the requests against multiple endpoints in case the dependency is slow or returns a transient error. Routing is options, by default it just hedges the URL provided by the original <xref:System.Net.Http.HttpRequestMessage>. |
| **3** | Rate limiter (per endpoint) | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. |
| **4** | Circuit breaker (per endpoint) | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. |
| **5** | Attempt timeout (per endpoint) | The attempt timeout pipeline limits each request attempt duration and throws if it's exceeded. |

### Customize resilience handlers

For finite control, you can customize the resilience handlers by calling the `AddResilienceHandler` extension method. This method takes a delegate that configures the `ResiliencePipelineBuilder<HttpResponseMessage>` instance that is used to create the resilience strategies.

To configure a named resilience handler, call the `AddResilienceHandler` extension method with the name of the handler. The following example configures a named resilience handler called `CustomResilienceHandler`.

```csharp
// The builder is of type, IHttpClientBuilder.
builder.AddResilienceHandler("CustomPipeline", static builder =>
{
    // See: https://www.pollydocs.org/strategies/retry.html
    builder.AddRetry(new HttpRetryStrategyOptions
    {
        BackoffType = DelayBackoffType.Exponential,
        MaxRetryAttempts = 5,
        UseJitter = true
    });

    // See: https://www.pollydocs.org/strategies/circuit-breaker.html
    builder.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
    {
        SamplingDuration = TimeSpan.FromSeconds(10),
        FailureRatio = 0.2,
        MinimumThroughput = 3,
        ShouldHandle = static args =>
        {
            // Handles HTTP status codes 408 and 429.
            return ValueTask.FromResult(args is
            {
                Outcome.Result.StatusCode:
                    HttpStatusCode.RequestTimeout or HttpStatusCode.TooManyRequests
            });
        }
    });

    // See: https://www.pollydocs.org/strategies/timeout.html
    builder.AddTimeout(TimeSpan.FromSeconds(5));
});
```

The preceding code:

- Adds a resilience handler with the name `"CustomPipeline"` as the `pipelineName` to the service container.
- Adds a retry strategy with exponential backoff, five retries, and jitter preference to the resilience builder.
- Adds a circuit breaker strategy with a sampling duration of 10 seconds, a failure ratio of 0.2 (20%), a minimum throughput of three, and a predicate that handles `RequestTimeout` and `TooManyRequests` HTTP status codes to the resilience builder.
- Adds a timeout strategy with a timeout of five seconds to the resilience builder.

There are many options available for each of the resilience strategies. For more information, see the [Polly docs: Strategies](https://www.pollydocs.org/strategies).

## Example usage

Your app relies on [dependency injection](../extensions/dependency-injection.md) to resolve the `ExampleClient` and its corresponding <xref:System.Net.Http.HttpClient> but, for this example, since the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> was manually instantiated, this code builds the <xref:System.IServiceProvider> and resolves the `ExampleClient` from it.

```csharp
var provider = services.BuildServiceProvider();

var client = provider.GetRequiredService<ExampleClient>();

await foreach (var comment in client.GetCommentsAsync())
{
    Console.WriteLine(comment);
}
```

The preceding code:

- Builds the <xref:System.IServiceProvider> from the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection>.
- Resolves the `ExampleClient` from the <xref:System.IServiceProvider>.
- Calls the `GetCommentsAsync` method on the `ExampleClient` to get the comments.
- Writes each comment to the console.

<!--
Mermaid diagram generated from the following code:

  https://mermaid.live/edit#pako:eNp9U01v4jAQ_Suj9NJKBBCHXdWVVgofbS8rrRaOXCb2hLh1YmpPBAj47zshUAGHzWlm3vN748l4n2hvKFFJ4fxGlxgYFtNlDfJlj7hBy6CdpZr7b8QTX1USxizuav2klNpAmv6C8WOBqsA0947hfbH4A2-zBQz0mf3UyY1b7qFjrpzPKcWKgtUYoWReRzUYfERfrx1qKr0zFPq8W9u2vb5IHWCy7w63lc7mL301FBnmYnPsXCYnlxM6Z-QmwkToCkbD4QGm50bjV4OBUl2S_oR5ozXFCAOR4ybUcLlle8H4f9Xa1-lJ-fWszMFivXKU0lY7rJCtr2EWgg-inzXs25JG53atW9i1HnQ9GMIAsy3phkkY0baz1ySuAZlWluIh61oS-RinVMAGCuuceiiK4uUOom_IaGPu0XhGzbPgz_do7prL8fyn-VGM7nGIHPwnqYfhcNjr4nRjDZdqtN5eq0EG-V0q2teV8S1hcptOb9NXyJNeIqtToTWyuPsWXCZcUkXLREmYY5RoWR-F16yNDG5mLPuQyIRdpF6C8iPmssKJ4tDQhTS1uApYfbPodOh39zxOr-T4D3EqCwo

-->

Imagine a situation where the network was to go down, or the server was to become unresponsive. The following diagram shows how the resilience strategies would handle the situation, given the `ExampleClient` and the `GetCommentsAsync` method:

:::image type="content" source="assets/http-get-comments-flow.png" lightbox="assets/http-get-comments-flow.png" alt-text="Example HTTP GET work flow with resilience pipeline.":::
