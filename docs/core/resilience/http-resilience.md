---
title: "Build resilient HTTP apps: Key development patterns"
description: Learn how to build resilient HTTP apps using the Microsoft.Extensions.Http.Resilience NuGet package.
author: IEvangelist
ms.author: dapine
ms.date: 07/01/2024
---

# Build resilient HTTP apps: Key development patterns

Building robust HTTP apps that can recover from transient fault errors is a common requirement. This article assumes that you've already read [Introduction to resilient app development](index.md), as this article extends the core concepts conveyed. To help build resilient HTTP apps, the [Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience) NuGet package provides resilience mechanisms specifically for the <xref:System.Net.Http.HttpClient>. This NuGet package relies on the `Microsoft.Extensions.Resilience` library and _Polly_, which is a popular open-source project. For more information, see [Polly](https://github.com/App-vNext/Polly).

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
> All the examples within this article rely on the <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> API, from the [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http) library, which returns an <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> instance. The <xref:Microsoft.Extensions.DependencyInjection.IHttpClientBuilder> instance is used to configure the <xref:System.Net.Http.HttpClient> and add the resilience handler.

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

## Remove standard resilience handlers

We provide a method <xref:Microsoft.Extensions.DependencyInjection.ResilienceHttpClientBuilderExtensions.RemoveAllResilienceHandlers*> which removes all previously registered resilience handlers. It is useful when you need to clear all existing resilience handlers and add your custom one.
The following example demonstrates how to configure a custom <xref:System.Net.Http.HttpClient> using the `AddHttpClient` method, remove all predefined resilience strategies, and replace them with new handlers.
This approach allows you to clear existing configurations and define new ones according to your specific requirements.

:::code language="csharp" source="snippets/http-resilience/Program.RemoveHandlers.cs" range="12-17" id="remove-handlers":::

The preceding code:

- Creates a <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> instance.
- Adds the standard resilience handler to all <xref:System.Net.Http.HttpClient> instances.
- For the "custom" <xref:System.Net.Http.HttpClient>:
- Removes all predefined resilience handlers that were previously registered. This is useful when you want to start with a clean state and add your own custom strategies.
- Adds a `StandardHedgingHandler` to the <xref:System.Net.Http.HttpClient>. You can replace `AddStandardHedgingHandler()` with any strategy that suits your application's needs, such as retry mechanisms, circuit breakers, or other resilience techniques.

### Standard resilience handler defaults

The default configuration chains five resilience strategies in the following order (from the outermost to the innermost):

| Order | Strategy | Description | Defaults |
|--:|--|--|--|
| **1** | Rate limiter | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. | Queue: `0`<br>Permit: `1_000` |
| **2** | Total timeout | The total request timeout pipeline applies an overall timeout to the execution, ensuring that the request, including retry attempts, doesn't exceed the configured limit. | Total timeout: 30s |
| **3** | Retry | The retry pipeline retries the request in case the dependency is slow or returns a transient error. | Max retries: `3`<br>Backoff: `Exponential`<br>Use jitter: `true`<br>Delay:2s |
| **4** | Circuit breaker | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. | Failure ratio: 10%<br>Min throughput: `100`<br>Sampling duration: 30s<br>Break duration: 5s |
| **5** | Attempt timeout | The attempt timeout pipeline limits each request attempt duration and throws if it's exceeded. | Attempt timeout: 10s |

#### Retries and circuit breakers

The retry and circuit breaker strategies both handle a set of specific HTTP status codes and exceptions. Consider the following HTTP status codes:

- HTTP 500 and above (Server errors)
- HTTP 408 (Request timeout)
- HTTP 429 (Too many requests)

Additionally, these strategies handle the following exceptions:

- `HttpRequestException`
- `TimeoutRejectedException`

#### Disable retries for a given list of HTTP methods

By default, the standard resilience handler is configured to make retries for all HTTP methods. For some applications, such behavior could be undesirable or even harmful. For example, if a POST request inserts a new record to a database, then making retries for such a request could lead to data duplication. If you need to disable retries for a given list of HTTP methods you can use the <xref:Microsoft.Extensions.Http.Resilience.HttpRetryStrategyOptionsExtensions.DisableFor(Microsoft.Extensions.Http.Resilience.HttpRetryStrategyOptions,System.Net.Http.HttpMethod[])> method:

:::code language="csharp" source="snippets/http-resilience/Program.RetryOptions.cs" id="disable_for":::

Alternatively, you can use the <xref:Microsoft.Extensions.Http.Resilience.HttpRetryStrategyOptionsExtensions.DisableForUnsafeHttpMethods(Microsoft.Extensions.Http.Resilience.HttpRetryStrategyOptions)> method, which disables retries for `POST`, `PATCH`, `PUT`, `DELETE`, and `CONNECT` requests. According to [RFC](https://www.rfc-editor.org/rfc/rfc7231#section-4.2.1), these methods are considered unsafe; meaning their semantics are not read-only:

:::code language="csharp" source="snippets/http-resilience/Program.RetryOptions.cs" id="disable_for_unsafe_http_methods":::

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

| Order | Strategy | Description | Defaults |
|--:|--|--|--|
| **1** | Total request timeout | The total request timeout pipeline applies an overall timeout to the execution, ensuring that the request, including hedging attempts, doesn't exceed the configured limit. | Total timeout: 30s |
| **2** | Hedging | The hedging strategy executes the requests against multiple endpoints in case the dependency is slow or returns a transient error. Routing is options, by default it just hedges the URL provided by the original <xref:System.Net.Http.HttpRequestMessage>. | Min attempts: `1`<br>Max attempts: `10`<br>Delay: 2s |
| **3** | Rate limiter (per endpoint) | The rate limiter pipeline limits the maximum number of concurrent requests being sent to the dependency. | Queue: `0`<br>Permit: `1_000` |
| **4** | Circuit breaker (per endpoint) | The circuit breaker blocks the execution if too many direct failures or timeouts are detected. | Failure ratio: 10%<br>Min throughput: `100`<br>Sampling duration: 30s<br>Break duration: 5s |
| **5** | Attempt timeout (per endpoint) | The attempt timeout pipeline limits each request attempt duration and throws if it's exceeded. | Timeout: 10s |

### Customize hedging handler route selection

When using the standard hedging handler, you can customize the way the request endpoints are selected by calling various extensions on the `IRoutingStrategyBuilder` type. This can be useful for scenarios such as A/B testing, where you want to route a percentage of the requests to a different endpoint:

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

There are many options available for each of the resilience strategies. For more information, see the [Polly docs: Strategies](https://www.pollydocs.org/strategies). For more information about configuring `ShouldHandle` delegates, see [Polly docs: Fault handling in reactive strategies](https://www.pollydocs.org/strategies#fault-handling).

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

:::image type="content" source="media/http-get-comments-flow.png" lightbox="media/http-get-comments-flow.png" alt-text="Example HTTP GET work flow with resilience pipeline.":::

The preceding diagram depicts:

- The `ExampleClient` sends an HTTP GET request to the `/comments` endpoint.
- The <xref:System.Net.Http.HttpResponseMessage> is evaluated:
  - If the response is successful (HTTP 200), the response is returned.
  - If the response is unsuccessful (HTTP non-200), the resilience pipeline employs the configured resilience strategies.

While this is a simple example, it demonstrates how the resilience strategies can be used to handle transient errors. For more information, see [Polly docs: Strategies](https://www.pollydocs.org/strategies).

## Known issues

The following sections detail various known issues.

### Compatibility with the `Grpc.Net.ClientFactory` package

If you're using `Grpc.Net.ClientFactory` version `2.63.0` or earlier, then enabling the standard resilience or hedging handlers for a gRPC client could cause a runtime exception. Specifically, consider the following code sample:

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>()
    .AddStandardResilienceHandler();
```

The preceding code results in the following exception:

```Output
System.InvalidOperationException: The ConfigureHttpClient method is not supported when creating gRPC clients. Unable to create client with name 'GreeterClient'.
```

To resolve this issue, we recommend upgrading to `Grpc.Net.ClientFactory` version `2.64.0` or later.

There's a build time check that verifies if you're using `Grpc.Net.ClientFactory` version `2.63.0` or earlier, and if you are the check produces a compilation warning. You can suppress the warning by setting the following property in your project file:

```xml
<PropertyGroup>
  <SuppressCheckGrpcNetClientFactoryVersion>true</SuppressCheckGrpcNetClientFactoryVersion>
</PropertyGroup>
```

### Compatibility with .NET Application Insights

If you're using .NET Application Insights, then enabling resilience functionality in your application could cause all Application Insights telemetry to be missing. The issue occurs when resilience functionality is registered before Application Insights services. Consider the following sample causing the issue:

```csharp
// At first, we register resilience functionality.
services.AddHttpClient().AddStandardResilienceHandler();

// And then we register Application Insights. As a result, Application Insights doesn't work.
services.AddApplicationInsightsTelemetry();
```

The issue is caused by the following [bug](https://github.com/microsoft/ApplicationInsights-dotnet/issues/2879) in Application Insights and can be fixed by registering Application Insights services before resilience functionality, as shown below:

```csharp
// We register Application Insights first, and now it will be working correctly.
services.AddApplicationInsightsTelemetry();
services.AddHttpClient().AddStandardResilienceHandler();
```
