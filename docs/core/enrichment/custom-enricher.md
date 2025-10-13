---
title: Custom log enricher
description: Learn how to use the custom log enricher in .NET.
ms.date: 10/13/2025
---

# Custom log enricher

You can easily create a custom enricher by creating a class that implements the <xref:Microsoft.Extensions.Diagnostics.Enrichment.ILogEnricher> interface.
After the class is created, you register it with <xref:Microsoft.Extensions.DependencyInjection.EnrichmentServiceCollectionExtension.AddLogEnricher>.
And after it's registered, the enricher is invoked any time enrichment is called for.

Your custom enricher only needs to implement a single <xref:Microsoft.Extensions.Diagnostics.Enrichment.ILogEnricher.Enrich(Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector)> method.
During enrichment, this method is called and given an <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector> instance. The enricher then calls one of the overloads of
the <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector.Add(System.String,System.Object)> method to record any properties it wants.

> [!Note]
> If your custom log enricher calls <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector.Add(System.String,System.Object)>,
> it is acceptable to send any type of argument to the `value` parameter as is, because it is parsed into the actual type and serialized internally
> to be sent further down the logging pipeline.

```cs
public class CustomEnricher : ILogEnricher
{
    // Your custom code

    public void Enrich(IEnrichmentTagCollector collector)
    {
        // Call Add to add all required key/value pair to enrich logs with.
        foreach(var property in propertiesToEnrichWith)
        {
            collector.Add(propertyName, propertyValue);
        }
    }
}

...

var hostBuilder = new HostBuilder()
    .ConfigureServices((_, serviceCollection) =>
    {
        _ = serviceCollection.AddLogEnricher<CustomEnricher>());
    });
```

It's also possible to configure manual instantiation of custom enrichers:

```cs
public class AnotherEnricher : ILogEnricher() {}

...

var hostBuilder = new HostBuilder()
    .ConfigureServices((_, serviceCollection) =>
    {
        _ = serviceCollection.AddLogEnricher(new AnotherEnricher()));
    });
```

Alternatively:

```cs
var hostApplicationBuilder = WebApplication.CreateBuilder();
hostApplicationBuilder.Services.AddLogEnricher<CustomEnricher>();
```

and

```cs
var hostApplicationBuilder = WebApplication.CreateBuilder();
hostApplicationBuilder.Services.AddLogEnricher(new AnotherEnricher()));
```
