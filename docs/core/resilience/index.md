---
title: Introduction to resilient app development
description: Learn about resiliency as it relates to .NET and how to build a resilience pipeline.
author: IEvangelist
ms.author: dapine
ms.date: 11/29/2023
ms.topic: concept-article
---

# Introduction to resilient app development

Resiliency is the ability of an app to recover from transient failures and continue to function. In the context of .NET programming, resilience is achieved by designing apps that can handle failures gracefully and recover quickly. To help build resilient apps in .NET, the following two packages are available on NuGet:

| NuGet package | Description |
|--|--|
| [📦 Microsoft.Extensions.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Resilience) | This NuGet package provides mechanisms to harden apps against transient failures. |
| [📦 Microsoft.Extensions.Http.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Http.Resilience) | This NuGet package provides resilience mechanisms specifically for the <xref:System.Net.Http.HttpClient> class. |

These two NuGet packages are built on top of [Polly](https://github.com/App-vNext/Polly), which is a popular open-source project. Polly is a .NET resilience and transient fault-handling library that allows developers to express strategies such as [retry](/azure/architecture/patterns/retry), [circuit breaker](/azure/architecture/patterns/circuit-breaker), timeout, [bulkhead isolation](/azure/architecture/patterns/bulkhead), [rate-limiting](/azure/architecture/patterns/rate-limiting-pattern), fallback, and hedging in a fluent and thread-safe manner.

> [!IMPORTANT]
> The [Microsoft.Extensions.Http.Polly](https://www.nuget.org/packages/Microsoft.Extensions.Http.Polly) NuGet package is deprecated. Use either of the aforementioned packages instead.

## Get started

To get started with resilience in .NET, install the [Microsoft.Extensions.Resilience](https://www.nuget.org/packages/Microsoft.Extensions.Resilience) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Resilience --version 8.0.0
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Resilience" Version="8.0.0" />
```

---

For more information, see [dotnet package add](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Build a resilience pipeline

To use resilience, you must first build a pipeline of resilience-based strategies. Each configured strategy executes in order of configuration. In other words, order is important. The entry point is an extension method on the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> type, named `AddResiliencePipeline`. This method takes an identifier of the pipeline and a delegate that configures the pipeline. The delegate is passed an instance of `ResiliencePipelineBuilder`, which is used to add resilience strategies to the pipeline.

Consider the following string-based `key` example:

:::code language="csharp" source="snippets/resilience/Program.cs" id="setup":::

The preceding code:

- Creates a new `ServiceCollection` instance.
- Defines a `key` to identify the pipeline.
- Adds a resilience pipeline to the `ServiceCollection` instance.
- Configures the pipeline with a retry and timeout strategies.

Each pipeline is configured for a given `key`, and each `key` is used to identify its corresponding `ResiliencePipeline` when getting the pipeline from the provider. The `key` is a generic type parameter of the `AddResiliencePipeline` method.

### Resilience pipeline builder extensions

To add a strategy to the pipeline, call any of the available `Add*` extension methods on the `ResiliencePipelineBuilder` instance.

- `AddRetry`: Try again if something fails, which is useful when the problem is temporary and might go away.
- `AddCircuitBreaker`: Stop trying if something is broken or busy, which benefits you by avoiding wasted time and making things worse.
- `AddTimeout`: Give up if something takes too long, which can improve performance by freeing up resources.
- `AddRateLimiter`: Limit how many requests you accept, which enables you to control inbound load.
- `AddConcurrencyLimiter`: Limit how many requests you make, which enables you to control outbound load.
- `AddFallback`: Do something else when experiencing failures, which improves user experience.
- `AddHedging`: Issue multiple requests in case of high latency or failure, which can improve responsiveness.

For more information, see [Resilience strategies](https://www.pollydocs.org/strategies). For examples, see [Build resilient HTTP apps: Key development patterns](http-resilience.md).

## Metrics enrichment

_Enrichment_ is the automatic augmentation of telemetry with well-known state, in the form of name/value pairs. For example, an app might emit a log that includes the _operation_ and _result code_ as columns to represent the outcome of some operation. In this situation and depending on peripheral context, enrichment adds _Cluster name_, _Process name_, _Region_, _Tenant ID_, and more to the log as it's sent to the telemetry backend. When enrichment is added, the app code doesn't need to do anything extra to benefit from enriched metrics.

### How enrichment works

Imagine 1,000 globally distributed service instances generating logs and metrics. When you encounter an issue on your [service dashboard](/dotnet/aspire/dashboard), it's crucial to quickly identify the problematic region or data center. Enrichment ensures that metric records contain the necessary information to pinpoint failures in distributed systems. Without enrichment, the burden falls on the app code to internally manage this state, integrate it into the logging process, and manually transmit it. Enrichment simplifies this process, seamlessly handling it without affecting the app's logic.

In the case of resiliency, when you add enrichment the following dimensions are added to the outgoing telemetry:

- `error.type`: Low-cardinality version of an exception's information.
- `request.name`: The name of the request.
- `request.dependency.name`: The name of the dependency.

Under the covers, resilience enrichment is built on top of Polly's Telemetry `MeteringEnricher`. For more information, see [Polly: Metering enrichment](https://www.pollydocs.org/advanced/telemetry#metering-enrichment).

### Add resilience enrichment

In addition to registering a resilience pipeline, you can also register resilience enrichment. To add enrichment, call the <xref:Microsoft.Extensions.DependencyInjection.ResilienceServiceCollectionExtensions.AddResilienceEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection)> extensions method on the `IServiceCollection` instance.

:::code language="csharp" source="snippets/resilience/Program.cs" id="enricher":::

By calling the `AddResilienceEnricher` extension method, you're adding dimensions on top of the default ones that are built into the underlying Polly library. The following enrichment dimensions are added:

- Exception enrichment based on the <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.IExceptionSummarizer>, which provides a mechanism to summarize exceptions for use in telemetry. For more information, see [Exception summarization](../diagnostics/diagnostic-exception-summary.md).
- Request metadata enrichment based on <xref:Microsoft.Extensions.Http.Diagnostics.RequestMetadata>, which holds the request metadata for telemetry. For more information, see [Polly: Telemetry metrics](https://www.pollydocs.org/advanced/telemetry#metrics).

## Use resilience pipeline

To use a configured resilience pipeline, you must get the pipeline from a `ResiliencePipelineProvider<TKey>`. When you added the pipeline earlier, the `key` was of type `string`, so you must get the pipeline from the `ResiliencePipelineProvider<string>`.

:::code language="csharp" source="snippets/resilience/Program.cs" id="pipeline":::

The preceding code:

- Builds a `ServiceProvider` from the `ServiceCollection` instance.
- Gets the `ResiliencePipelineProvider<string>` from the service provider.
- Retrieves the `ResiliencePipeline` from the `ResiliencePipelineProvider<string>`.

## Execute resilience pipeline

To use the resilience pipeline, call any of the available `Execute*` methods on the `ResiliencePipeline` instance. For example, consider an example call to `ExecuteAsync` method:

:::code language="csharp" source="snippets/resilience/Program.cs" id="execute":::

The preceding code executes the delegate within the `ExecuteAsync` method. When there are failures, the configured strategies are executed. For example, if the `RetryStrategy` is configured to retry three times, the delegate is executed four times (one initial attempt plus three retry attempts) before the failure is propagated.

## Next steps

> [!div class="nextstepaction"]
> [Build resilient HTTP apps: Key development patterns](http-resilience.md)
> Consider the [challenges of idempotent handling of retried calls](/azure/architecture/reference-architectures/containers/aks-mission-critical/mission-critical-data-platform#idempotent-message-processing)
