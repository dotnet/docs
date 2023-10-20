---
title: "Build resilient HTTP apps: Key development patterns"
description: Learn how to build resilient HTTP apps using the Microsoft.Extensions.Http.Resilience NuGet package.
author: IEvangelist
ms.author: dapine
ms.date: 10/19/2023
---

# Build resilient HTTP apps: Key development patterns

Building robust HTTP apps that can recover from transient fault errors is a common requirement. This article assumes that you've already read [Introduction to resilient app development](index.md), as this article builds upon the core concepts conveyed. To help build resilient HTTP apps, the [Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience) NuGet package provides resilience mechanisms specifically for the <xref:System.Net.Http.HttpClient>. This NuGet package is built on top of the `Microsoft.Extensions.Resilience` library and _Polly_, which is a popular open-source project. For more information, see [Polly](https://github.com/App-vNext/Polly).

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

## Add resilience to an HTTP client

To add resilience to an <xref:System.Net.Http.HttpClient>, you chain a call on the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> type that is returned from calling any of the available <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> methods. For more information, see [IHttpClientFactory with .NET](../extensions/httpclient-factory.md).

There are several resilience-centric extensions available. Some are standard, thus employing various industry best practices, and others are more customizable. When adding resilience, you should only add one resilience handler and avoid stacking handlers. If you need to add multiple resilience handlers, you should consider using the `AddResilienceHandler` extension method, which allows you to customize the resilience strategies.

> [!IMPORTANT]
> All of the examples within this article rely on the <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> API, from the [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http) library, which returns an <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> instance. The <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> instance is used to configure the <xref:System.Net.Http.HttpClient> and add the resilience handler.

## Add standard resilience handler

The standard resilience handler uses multiple resilience strategies stacked atop one another, with default options to send the requests and handle any transient errors. The standard resilience handler is added by calling the `AddStandardResilienceHandler` extension method on an <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> instance.

:::code language="csharp" source="snippets/http-resilience/Program.ServiceCollection.cs" id="services":::

The preceding code:

- Creates a <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> instance.
- Adds an <xref:System.Net.Http.HttpClient> for the `ExampleClient` type to the service container.
- Configures the <xref:System.Net.Http.HttpClient> to use `"https://jsonplaceholder.typicode.com"` as the base address.
- Creates the `httpClientBuilder` that's used throughout the other examples within this article.

A more real-world example would rely on hosting, such as that described in the [.NET Generic Host](../extensions/generic-host.md) article. Using the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package, consider the following updated example:

:::code language="csharp" source="snippets/http-resilience/Program.cs" id="setup":::

The preceding code is similar to the manual `ServiceCollection` creation approach, but instead relies on the <xref:Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder?displayProperty=nameWithType> to build out a host that exposes the services.

The `ExampleClient` is defined as follows:

:::code language="csharp" source="snippets/http-resilience/ExampleClient.cs":::

The preceding code:

- Defines an `ExampleClient` type that has a constructor that accepts an <xref:System.Net.Http.HttpClient>.
- Exposes a `GetCommentsAsync` method that sends a GET request to the `/comments` endpoint and returns the response.

The `Comment` type is defined as follows:

:::code language="csharp" source="snippets/http-resilience/Comment.cs":::

Given that you've created an <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> (`httpClientBuilder`), and you now understand the `ExampleClient` implementation and corresponding `Comment` model, consider the following example:

:::code language="csharp" source="snippets/http-resilience/Program.ResilienceHandler.cs" id="standard":::

The preceding code adds the standard resilience handler to the <xref:System.Net.Http.HttpClient>. Like most resilience APIs, there are overloads that allow you to customize the default options and applied resilience strategies.

### Standard resilience handler defaults

The default configuration chains five resilience strategies in the following order (from the outermost to the innermost):

| Order | Strategy | Description |
|--:|--|--|
| **1** | Rate limiter | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. |
| **2** | Total request timeout | The total request timeout pipeline applies an overall timeout to the execution, ensuring that the request, including retry attempts, doesn't exceed the configured limit. |
| **3** | Retry | The retry pipeline retries the request in case the dependency is slow or returns a transient error. |
| **4** | Circuit breaker | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. |
| **5** | Attempt timeout | The attempt timeout pipeline limits each request attempt duration and throws if it's exceeded. |

## Add standard hedging handler

The standard hedging handler wraps the execution of the request with a standard hedging mechanism. Hedging retries slow requests in parallel.

To use the standard hedging handler, call `AddStandardHedgingHandler` extension method. The following example configures the `ExampleClient` to use the standard hedging handler.

:::code language="csharp" source="snippets/http-resilience/Program.HedgingHandler.cs" id="standard":::

The preceding code adds the standard hedging handler to the <xref:System.Net.Http.HttpClient>.

### Standard hedging handler defaults

The standard hedging uses a pool of circuit breakers to ensure that unhealthy endpoints aren't hedged against. By default, the selection from the pool is based on the URL authority (scheme + host + port).

> [!TIP]
> It's recommended that you configure the way the strategies are selected by calling `StandardHedgingHandlerBuilderExtensions.SelectPipelineByAuthority` or `StandardHedgingHandlerBuilderExtensions.SelectPipelineBy` for more advanced scenarios.

The preceding code adds the standard hedging handler to the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder>. The default configuration chains five resilience strategies in the following order (from the outermost to the innermost):

| Order | Strategy | Description |
|--:|--|--|
| **1** | Total request timeout | The total request timeout pipeline applies an overall timeout to the execution, ensuring that the request, including hedging attempts, doesn't exceed the configured limit. |
| **2** | Hedging | The hedging strategy executes the requests against multiple endpoints in case the dependency is slow or returns a transient error. Routing is options, by default it just hedges the URL provided by the original <xref:System.Net.Http.HttpRequestMessage>. |
| **3** | Rate limiter (per endpoint) | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. |
| **4** | Circuit breaker (per endpoint) | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. |
| **5** | Attempt timeout (per endpoint) | The attempt timeout pipeline limits each request attempt duration and throws if it's exceeded. |

### Customize hedging handler route selection

When using the standard hedging handler, you can customize the way the request endpoints are selected by calling various extensions on the `IRoutingStrategyBuilder` type. This can be useful for scenarios such as a/b testing, where you want to route a percentage of the requests to a different endpoint:

:::code language="csharp" source="snippets/http-resilience/Program.HedgingHandler.cs" id="ordered":::

The preceding code:

- Adds the hedging handler to the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder>.
- Configures the `IRoutingStrategyBuilder` to use the `ConfigureOrderedGroups` method to configure the ordered groups.
- Adds an `EndpointGroup` to the `orderedGroup` that routes 3% of the requests to the `https://example.net/api/experimental` endpoint and 97% of the requests to the `https://example.net/api/stable` endpoint.
- Configures the `IRoutingStrategyBuilder` to use the `ConfigureWeightedGroups` method to configure the

To configure a weighted group, call the `ConfigureWeightedGroups` method on the `IRoutingStrategyBuilder` type. The following example configures the `IRoutingStrategyBuilder` to use the `ConfigureWeightedGroups` method to configure the weighted groups.

:::code language="csharp" source="snippets/http-resilience/Program.HedgingHandler.cs" id="weighted":::

The preceding code:

- Adds the hedging handler to the <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder>.
- Configures the `IRoutingStrategyBuilder` to use the `ConfigureWeightedGroups` method to configure the weighted groups.
- Sets the `SelectionMode` to `WeightedGroupSelectionMode.EveryAttempt`.
- Adds a `WeightedEndpointGroup` to the `weightedGroup` that routes 33% of the requests to the `https://example.net/api/a` endpoint, 33% of the requests to the `https://example.net/api/b` endpoint, and 33% of the requests to the `https://example.net/api/c` endpoint.

> [!TIP]
> The maximum number of hedging attempts directly correlates to the number of configured groups. For example, if you have two groups, the maximum number of attempts is two.

For more information, see [Polly docs: Hedging resilience strategy](https://www.pollydocs.org/strategies/hedging).

It's common to configure either an ordered group or weighted group, but it's valid to configure both. Using ordered and weighted groups is helpful in scenarios where you want to send a percentage of the requests to a different endpoint, such is the case with A/B testing.

## Add custom resilience handlers

To have more control, you can customize the resilience handlers by using the `AddResilienceHandler` API. This method accepts a delegate that configures the `ResiliencePipelineBuilder<HttpResponseMessage>` instance that is used to create the resilience strategies.

To configure a named resilience handler, call the `AddResilienceHandler` extension method with the name of the handler. The following example configures a named resilience handler called `"CustomPipeline"`.

:::code language="csharp" source="snippets/http-resilience/Program.CustomHandler.cs" id="custom":::

The preceding code:

- Adds a resilience handler with the name `"CustomPipeline"` as the `pipelineName` to the service container.
- Adds a retry strategy with exponential backoff, five retries, and jitter preference to the resilience builder.
- Adds a circuit breaker strategy with a sampling duration of 10 seconds, a failure ratio of 0.2 (20%), a minimum throughput of three, and a predicate that handles `RequestTimeout` and `TooManyRequests` HTTP status codes to the resilience builder.
- Adds a timeout strategy with a timeout of five seconds to the resilience builder.

There are many options available for each of the resilience strategies. For more information, see the [Polly docs: Strategies](https://www.pollydocs.org/strategies). For more information about configuring `ShouldHandle` delegates, see [Polly docs: Fault handling in reactive strategies](https://www.pollydocs.org/strategies/index.html#fault-handling).

### Dynamic reload

Polly supports dynamic reloading of the configured resilience strategies. This means that you can change the configuration of the resilience strategies at run time. To enable dynamic reload, use the appropriate `AddResilienceHandler` overload that exposes the `ResilienceHandlerContext`. Given the context, call `EnableReloads` of the corresponding resilience strategy options:

:::code language="csharp" source="snippets/http-resilience/Program.CustomHandler.cs" id="advanced":::

The preceding code:

- Adds a resilience handler with the name `"AdvancedPipeline"` as the `pipelineName` to the service container.
- Enables the reloads of the `"AdvancedPipeline"` pipeline whenever the named `RetryStrategyOptions` options change.
- Retrieves the named options from the <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> service.
- Adds a retry strategy with the retrieved options to the resilience builder.

For more information, see [Polly docs: Advanced dependency injection](https://www.pollydocs.org/advanced/dependency-injection#dynamic-reloads).

This example relies on an options section that is capable of change, such as an _appsettings.json_ file. Consider the following _appsettings.json_ file:

:::code language="json" source="snippets/http-resilience/appsettings.json":::

Now imagine that these options were bound to the app's configuration, binding the `HttpRetryStrategyOptions` to the `"RetryOptions"` section:

:::code language="csharp" source="snippets/http-resilience/Program.RetryOptions.cs" id="options":::

For more information, see [Options pattern in .NET](../extensions/options.md).

## Example usage

Your app relies on [dependency injection](../extensions/dependency-injection.md) to resolve the `ExampleClient` and its corresponding <xref:System.Net.Http.HttpClient>. The code builds the <xref:System.IServiceProvider> and resolves the `ExampleClient` from it.

:::code language="csharp" source="snippets/http-resilience/Program.cs" id="usage":::

The preceding code:

- Builds the <xref:System.IServiceProvider> from the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection>.
- Resolves the `ExampleClient` from the <xref:System.IServiceProvider>.
- Calls the `GetCommentsAsync` method on the `ExampleClient` to get the comments.
- Writes each comment to the console.

<!--
Mermaid diagram generated from the following code:

  https://mermaid.live/edit#pako:eNptU01vIjEM_SvW9NJKDCAOu2pWXYmvtpdKq8Kt7MGTeJi0mWSaeAQI-O-bmYGqoM3J9nt-dhxnn0inKBFJbtxGFugZlrOVhXjGt2-4Qc0gjSbL_SfiqSvLaIZx2Fn5904IsYGHh98wuc1R5JhmzjA8L5d_4Gm-hIE80e86wUnDPXTMtXEZpViS1xIDFMxVEIPBe3C2MiipcEaR7_Ou0k2D_Sh1gOl-32U3IXiOOa8UKmcDvVAIuKbjsas0bSu1jSwYuQ4wjRkCRsPhAWanZsNnjZ5SWZD8gEUtZdSAAbwS197C-arNJcNZNe2n_5O1zqat9ONJmr1GuzaU0lYaLJG1szD33vlYYFyza0ISjdk15fyuKUKd-mk8hB7mW5I1U6QE3TyBpFjWI9NaUziMu6aifggzymEDuTZG3OR5_usKoi9ISaWu0XBC1X3E76_RzNTn9Oyn-pGPrnEI7N0HiZvhcNjr7HSjFRdiVG2_q8EYsis3an-PTC4J00t3duk-Qpb0krhAJWoVF3jfgKuECypplYhoZhiitbLHyKsrFQc3V5qdT-KETaBegvElFnGTE8G-pjNppnHtsfxiUZv00n2T9rcc_wHXoA8n

-->

Imagine a situation where the network goes down or the server becomes unresponsive. The following diagram shows how the resilience strategies would handle the situation, given the `ExampleClient` and the `GetCommentsAsync` method:

:::image type="content" source="assets/http-get-comments-flow.png" lightbox="assets/http-get-comments-flow.png" alt-text="Example HTTP GET work flow with resilience pipeline.":::

The preceding diagram depicts:

- The `ExampleClient` sends an HTTP GET request to the `/comments` endpoint.
- The <xref:System.Net.Http.HttpResponseMessage> is evaluated:
  - If the response is successful (HTTP 200), the response is returned.
  - If the response is unsuccessful (HTTP non-200), the resilience pipeline employs the configured resilience strategies.

While this is a simple example, it demonstrates how the resilience strategies can be used to handle transient errors. For more information, see [Polly docs: Strategies](https://www.pollydocs.org/strategies).
