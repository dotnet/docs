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

To add resilience to an <xref:System.Net.Http.HttpClient>, you chain a call on the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> type which is returned from calling any of the available <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> methods. There are several available resilience-centric extensions available:

### The standard resilience handler

The standard resilience handler uses multiple resilience strategies with default options to send the requests and handle any transient errors. The standard resilience handler is added by calling the `AddStandardResilienceHandler` extension method.

```csharp
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
|--|--|--|
| **1** | Rate limiter | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. |
| **2** | Total request timeout | Total request timeout pipeline applies an overall timeout to the execution, ensuring that the request including hedging attempts, does not exceed the configured limit. |
| **3** | Retry | The retry pipeline retries the request in case the dependency is slow or returns a transient error. |
| **4** | Circuit breaker | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. |
| **5** | Attempt timeout | The attempt timeout pipeline limits each request attempt duration and throws if its exceeded. |

### The standard hedging handler

The standard hedging handler wraps the execution of the request with a standard hedging mechanism. The standard hedging handler is added by calling the `AddStandardHedgingHandler` extension method.

```csharp
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
|--|--|--|
| **1** | Rate limiter | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. |
| **2** | Total request timeout | Total request timeout pipeline applies an overall timeout to the execution, ensuring that the request including hedging attempts, does not exceed the configured limit. |
| **3** | Retry | The retry pipeline retries the request in case the dependency is slow or returns a transient error. |
| **4** | Circuit breaker | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. |
| **5** | Attempt timeout | The attempt timeout pipeline limits each request attempt duration and throws if its exceeded. |

### Customize resilience handlers

For finite control, you can customize the resilience handlers by calling the `AddResilienceHandler` extension method. This method takes a delegate that configures the `ResiliencePipelineBuilder<HttpResponseMessage>` instance that is used to create the resilience strategies.
