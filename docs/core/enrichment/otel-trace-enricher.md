---
title: OpenTelemetry trace enricher
description: Learn how to use the OpenTelemetry TraceEnricher to add custom tags to traces in .NET.
ms.date: 03/17/2026
ai-usage: ai-assisted
---

# OpenTelemetry trace enricher

You can create a custom trace enricher by extending the `TraceEnricher` abstract class from the `OpenTelemetry.Extensions.Enrichment` package. Unlike working with `Activity` directly, the `TraceEnricher` uses a `TraceEnrichmentBag` — a lightweight `readonly struct` passed by reference — to add tags to traces.

After the class is created, you register it with `TryAddTraceEnricher` or `AddTraceEnricher`. Once registered, the OpenTelemetry pipeline automatically calls your enricher when an `Activity` starts or stops.

## Install the package

To get started, install the [📦 OpenTelemetry.Extensions.Enrichment](https://www.nuget.org/packages/OpenTelemetry.Extensions.Enrichment) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package OpenTelemetry.Extensions.Enrichment
```

Or, if you're using .NET 10+ SDK:

```dotnetcli
dotnet package add OpenTelemetry.Extensions.Enrichment
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="OpenTelemetry.Extensions.Enrichment"
                  Version="*" /> <!-- Adjust version -->
```

---

## TraceEnricher implementation

Your custom trace enricher needs to override the `Enrich` method. During enrichment, this method is called and given a `TraceEnrichmentBag` instance. The enricher then calls `TraceEnrichmentBag.Add` to record any tags it wants.

```csharp
using OpenTelemetry.Extensions.Enrichment;

public class CustomTraceEnricher : TraceEnricher
{
    public override void Enrich(in TraceEnrichmentBag bag)
    {
        bag.Add("deployment.environment", "production");
        bag.Add("service.instance", Environment.MachineName);
    }
}
```

You can also override `EnrichOnActivityStart` to add tags when an `Activity` starts, rather than when it stops:

```csharp
using OpenTelemetry.Extensions.Enrichment;

public class CustomTraceEnricher : TraceEnricher
{
    public override void Enrich(in TraceEnrichmentBag bag)
    {
        bag.Add("deployment.environment", "production");
    }

    public override void EnrichOnActivityStart(in TraceEnrichmentBag bag)
    {
        bag.Add("trace.start_time", DateTimeOffset.UtcNow.ToString("o"));
    }
}
```

And you register it as shown in the following code:

```csharp
using OpenTelemetry.Trace;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddOpenTelemetry().WithTracing(tracing =>
{
    tracing.TryAddTraceEnricher<CustomTraceEnricher>();
});
```

You can also register with a pre-created instance or a factory delegate:

```csharp
using OpenTelemetry.Trace;

var builder = Host.CreateApplicationBuilder();
builder.Services.AddOpenTelemetry().WithTracing(tracing =>
{
    // With an instance
    tracing.TryAddTraceEnricher(new CustomTraceEnricher());

    // With a factory
    tracing.AddTraceEnricher(sp => new CustomTraceEnricher());
});
```

For simple scenarios, you can add inline enrichment without creating a dedicated class:

```csharp
using OpenTelemetry.Trace;

var builder = Host.CreateApplicationBuilder();
builder.Services.AddOpenTelemetry().WithTracing(tracing =>
{
    tracing.AddTraceEnricher(bag =>
    {
        bag.Add("deployment.environment", "production");
    });
});
```

All registration methods are also available directly on `IServiceCollection`:

```csharp
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder();
builder.Services.TryAddTraceEnricher<CustomTraceEnricher>();

// With an instance
builder.Services.TryAddTraceEnricher(new CustomTraceEnricher());

// With a factory
builder.Services.AddTraceEnricher(sp => new CustomTraceEnricher());
```

## Remarks

- The `Enrich` method is called when an `Activity` stops. Use it for most enrichment scenarios.
- The `EnrichOnActivityStart` method is called when an `Activity` starts. It has a default no-op implementation, so you only need to override it when you need start-time enrichment.
- `TraceEnrichmentBag` wraps the underlying `Activity` and exposes a single `Add(string key, object? value)` method for adding tags.
- Multiple enrichers can be registered and are executed in the order they were registered.
- `TryAddTraceEnricher` only adds the enricher if the same type is not already registered. Use `AddTraceEnricher` with a factory or action delegate when you need to always add the enricher.
- Your enricher can accept constructor dependencies resolved from the DI container when registered with `TryAddTraceEnricher<T>()` or a factory delegate.
