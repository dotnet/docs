---
title: Resilience-patterns for HTTP apps
description: 
author: IEvangelist
ms.author: dapine
ms.date: 09/28/2023
---

# Resilience-patterns for HTTP apps

Building robust HTTP apps that can recover from transient fault errors is a common requirement. To help build resilient HTTP apps, the [Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience) NuGet package provides resilience mechanisms specifically for the <xref:System.Net.Http.HttpClient>. This NuGet package is built on top of _Polly_, which is a very popular open-source project. For more information, see [Polly](https://github.com/App-vNext/Polly).

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

## Add resilience handlers to an HTTP client

To add resilience to an <xref:System.Net.Http.HttpClient>, you chain a call on the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> type which is returned from calling any of the available <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> methods. There are several resilience-centric extensions available, some are standard employing various industry best practices, and others are more customizable.

### The standard resilience handler

The standard resilience handler uses multiple resilience strategies with default options to send the requests and handle any transient errors. The standard resilience handler is added by calling the `AddStandardResilienceHandler` extension method.

```csharp
// A service collection is manually instantiated for this example.
// If you're using a generic host, you'll instead use its service collection:
//
// var host = Host.CreateApplicationBuilder(args);
// host.Services.AddHttpClient<ExampleClient>(client => { ... });

var services = new ServiceCollection();

services.AddHttpClient<ExampleClient>(client =>
    {
        client.BaseAddress = new Uri("https://example.com");
    })
    .AddStandardResilienceHandler();
```

The preceding code:

- Adds an <xref:System.Net.Http.HttpClient> for the `ExampleClient` type to the service container.
- Configures the <xref:System.Net.Http.HttpClient> to use `"https://example.com"` as the base address.
- Adds a standard resilience handler to the <xref:System.Net.Http.HttpClient>.

#### Standard resilience handler defaults

The default configuration chains five resilience strategies in the following order (from the outermost to the innermost):

| Order | Strategy | Description |
|--:|--|--|
| **1** | Rate limiter | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. |
| **2** | Total request timeout | Total request timeout pipeline applies an overall timeout to the execution, ensuring that the request including hedging attempts, does not exceed the configured limit. |
| **3** | Retry | The retry pipeline retries the request in case the dependency is slow or returns a transient error. |
| **4** | Circuit breaker | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. |
| **5** | Attempt timeout | The attempt timeout pipeline limits each request attempt duration and throws if its exceeded. |

### The standard hedging handler

The standard hedging handler wraps the execution of the request with a standard hedging mechanism. The standard hedging handler is added by calling the `AddStandardHedgingHandler` extension method.

```csharp
// A service collection is manually instantiated for this example.
// If you're using a generic host, you'll instead use its service collection:
//
// var host = Host.CreateApplicationBuilder(args);
// host.Services.AddHttpClient<ExampleClient>(client => { ... });

services.AddHttpClient<ExampleClient>(client =>
    {
        client.BaseAddress = new Uri("https://example.com");
    })
    .AddStandardHedgingHandler();
```

The preceding code:

- Adds an <xref:System.Net.Http.HttpClient> for the `ExampleClient` type to the service container.
- Configures the <xref:System.Net.Http.HttpClient> to use `"https://example.com"` as the base address.
- Adds the standard hedging resilience handler to the <xref:System.Net.Http.HttpClient>.

#### Standard hedging handler defaults

The standard hedging uses a pool of circuit breakers to ensure that unhealthy endpoints are not hedged against. By default, the selection from the pool is based on the URL authority (scheme + host + port).

> [!TIP]
> It's recommended that you configure the way the strategies are selected by calling `StandardHedgingHandlerBuilderExtensions.SelectPipelineByAuthority`.

The default configuration chains five resilience strategies in the following order (from the outermost to the innermost):

| Order | Strategy | Description |
|--:|--|--|
| **1** | Total request timeout | Total request timeout pipeline applies an overall timeout to the execution, ensuring that the request including hedging attempts, does not exceed the configured limit. |
| **2** | Hedging | The hedging strategy executes the requests against multiple endpoints in case the dependency is slow or returns a transient error. |
| **3** | Rate limiter (per endpoint) | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. |
| **4** | Circuit breaker (per endpoint) | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. |
| **5** | Attempt timeout (per endpoint) | The attempt timeout pipeline limits each request attempt duration and throws if its exceeded. |

### Customize resilience handlers

For finite control, you can customize the resilience handlers by calling the `AddResilienceHandler` extension method. This method takes a delegate that configures the `ResiliencePipelineBuilder<HttpResponseMessage>` instance that is used to create the resilience strategies.

To configure a named resilience handler, call the `AddResilienceHandler` extension method with the name of the handler. The following example configures a named resilience handler called `CustomResilienceHandler`.

```csharp
// A service collection is manually instantiated for this example.
// If you're using a generic host, you'll instead use its service collection:
//
// var host = Host.CreateApplicationBuilder(args);
// host.Services.AddHttpClient<ExampleClient>(client => { ... });

builder.AddResilienceHandler("CustomPipeline", static builder =>
{
    // See: https://www.pollydocs.org/strategies/retry.html
    builder.AddRetry(new RetryStrategyOptions<HttpResponseMessage>
    {
        BackoffType = DelayBackoffType.Exponential,
        MaxRetryAttempts = 5,
        UseJitter = true
    });

    // See: https://www.pollydocs.org/strategies/circuit-breaker.html
    var options = new CircuitBreakerStrategyOptions<HttpResponseMessage>()
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
    };
    builder.AddCircuitBreaker(options);

    // See: https://www.pollydocs.org/strategies/timeout.html
    builder.AddTimeout(TimeSpan.FromSeconds(5));
});
```

The preceding code:

- Adds a resilience handler with the `"CustomPipeline"` as the `pipelineName` to the service container.
- Adds a retry strategy with exponential backoff, five retries, and jitter preference to the resilience builder.
- Adds a circuit breaker strategy with a sampling duration of 10 seconds, a failure ratio of 0.2 (20%), a minimum throughput of three, and a predicate that handles `RequestTimeout` and `TooManyRequests` status codes to the resilience builder.
- Adds a timeout strategy with a timeout of five seconds to the resilience builder.

There are many options available for each of the resilience strategies. For more information, see the [Polly docs: Strategies](https://www.pollydocs.org/strategies).

## Example usage

<!--
Mermaid diagram generated from the following code:

  https://mermaid.live/edit#pako:eNp9U01v4jAQ_Suj9NJKBBCHXdWVVgofbS8rrRaOXCb2hLh1YmpPBAj47zshUAGHzWlm3vN748l4n2hvKFFJ4fxGlxgYFtNlDfJlj7hBy6CdpZr7b8QTX1USxizuav2klNpAmv6C8WOBqsA0947hfbH4A2-zBQz0mf3UyY1b7qFjrpzPKcWKgtUYoWReRzUYfERfrx1qKr0zFPq8W9u2vb5IHWCy7w63lc7mL301FBnmYnPsXCYnlxM6Z-QmwkToCkbD4QGm50bjV4OBUl2S_oR5ozXFCAOR4ybUcLlle8H4f9Xa1-lJ-fWszMFivXKU0lY7rJCtr2EWgg-inzXs25JG53atW9i1HnQ9GMIAsy3phkkY0baz1ySuAZlWluIh61oS-RinVMAGCuuceiiK4uUOom_IaGPu0XhGzbPgz_do7prL8fyn-VGM7nGIHPwnqYfhcNjr4nRjDZdqtN5eq0EG-V0q2teV8S1hcptOb9NXyJNeIqtToTWyuPsWXCZcUkXLREmYY5RoWR-F16yNDG5mLPuQyIRdpF6C8iPmssKJ4tDQhTS1uApYfbPodOh39zxOr-T4D3EqCwo

-->

:::image type="content" source="assets/http-get-comments-flow.png" lightbox="assets/http-get-comments-flow.png" alt-text="Example HTTP GET work flow with resilience pipeline.":::
