---
title: Custom log enricher
description: Learn how to use the custom log enricher in .NET.
ms.date: 10/13/2025
---

# Custom log enricher

You can easily create a custom enricher by creating a class that implements the <xref:Microsoft.Extensions.Diagnostics.Enrichment.ILogEnricher> interface.
After the class is created, you register it with <xref:Microsoft.Extensions.DependencyInjection.EnrichmentServiceCollectionExtensions.AddLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Diagnostics.Enrichment.ILogEnricher)>.
Once registered, the logging infrastructure automatically calls the `Enrich()` method exactly once on every registered enricher for each log message produced.

## Install the package

To get started, install the [📦 Microsoft.Extensions.Telemetry.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Telemetry.Abstractions) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Telemetry.Abstractions
```

Or, if you're using .NET 10+ SDK:

```dotnetcli
dotnet package add Microsoft.Extensions.Telemetry.Abstractions 
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.Telemetry.Abstractions"
                  Version="*" /> <!-- Adjust version -->
```

---

## Implementation

Your custom enricher only needs to implement a single <xref:Microsoft.Extensions.Diagnostics.Enrichment.ILogEnricher.Enrich(Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector)> method.
During enrichment, this method is called and given an <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector> instance. The enricher then calls one of the overloads of
the <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector.Add(System.String,System.Object)> method to record any properties it wants.

> [!NOTE]
> If your custom log enricher calls <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector.Add(System.String,System.Object)>,
> it is acceptable to send any type of argument to the `value` parameter as is, because it is parsed into the actual type and serialized internally
> to be sent further down the logging pipeline.

```csharp
public class CustomEnricher : ILogEnricher
{
    public void Enrich(IEnrichmentTagCollector collector)
    {
        collector.Add("customKey", "customValue");
    }
}

```

And you register it as shown in the following code using <xref:Microsoft.Extensions.DependencyInjection.EnrichmentServiceCollectionExtensions.AddLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection)>:

```csharp
var builder = Host.CreateApplicationBuilder(args);
builder.Logging.EnableEnrichment();
builder.Services.AddLogEnricher<CustomEnricher>();
```

It's also possible to configure manual instantiation of custom enrichers:

```csharp
public class AnotherEnricher : ILogEnricher
{
    private readonly string _key;
    private readonly object _value;
    public CustomEnricher(string key, object value)
    {
        _key = key;
        _value = value;
    }
    public void Enrich(IEnrichmentTagCollector collector)
    {
        collector.Add(_key, _value);
    }
}
```

And you register it as shown in the following code <xref:Microsoft.Extensions.DependencyInjection.EnrichmentServiceCollectionExtensions.AddLogEnricher(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Diagnostics.Enrichment.ILogEnricher)>:

```csharp
var builder = Host.CreateApplicationBuilder();
builder.Logging.EnableEnrichment();
builder.Services.AddLogEnricher(new AnotherEnricher("anotherKey", "anotherValue"));
```
