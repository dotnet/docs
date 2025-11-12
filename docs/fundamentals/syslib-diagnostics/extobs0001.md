---
title: EXTOBS0001 warning
description: Learn about the obsoletions that generate compile-time warning EXTOBS0001.
ms.date: 11/12/2025
f1_keywords:
  - extobs0001
ai-usage: ai-assisted
---
# EXTOBS0001: IResourceMonitor is obsolete

The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface and related APIs have been marked as obsolete starting in .NET 9. These APIs will be removed in a future version. The resource monitoring functionality has been replaced with a more efficient metrics-based approach using observable instruments.

The following APIs are marked obsolete. Use of these APIs generates warning `EXTOBS0001` at compile time.

- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor?displayProperty=nameWithType>
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor.GetUtilization(System.TimeSpan)?displayProperty=nameWithType>

## Workarounds

Instead of using `IResourceMonitor`, switch to using resource monitoring metrics with observable instruments. The metrics-based approach provides the same resource utilization information (CPU, memory) but integrates better with modern observability systems like OpenTelemetry.

### Migration example

Old approach using `IResourceMonitor`:

```csharp
services.AddResourceMonitoring();

// Inject and use IResourceMonitor
public class MyService
{
    private readonly IResourceMonitor _resourceMonitor;

    public MyService(IResourceMonitor resourceMonitor)
    {
        _resourceMonitor = resourceMonitor;
    }

    public void CheckResources()
    {
        var utilization = _resourceMonitor.GetUtilization(TimeSpan.FromSeconds(1));
        Console.WriteLine($"CPU: {utilization.CpuUsedPercentage}%");
        Console.WriteLine($"Memory: {utilization.MemoryUsedPercentage}%");
    }
}
```

New approach using metrics:

```csharp
services.AddResourceMonitoring();

// Configure metrics collection.
services.AddOpenTelemetry()
    .WithMetrics(builder =>
    {
        builder.AddMeter("Microsoft.Extensions.Diagnostics.ResourceMonitoring");
        builder.AddConsoleExporter(); // Or use any other exporter.
    });
```

The resource monitoring metrics are automatically published and can be consumed by any OpenTelemetry-compatible metrics pipeline. For more information, see [`Microsoft.Extensions.Diagnostics.ResourceMonitoring` metrics](../../core/diagnostics/built-in-metrics-diagnostics.md#microsoftextensionsdiagnosticsresourcemonitoring).

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable EXTOBS0001

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore EXTOBS0001
```

To suppress all the `EXTOBS0001` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);EXTOBS0001</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [Diagnostic resource monitoring](../../core/diagnostics/diagnostic-resource-monitoring.md)
- [`Microsoft.Extensions.Diagnostics.ResourceMonitoring` metrics](../../core/diagnostics/built-in-metrics-diagnostics.md#microsoftextensionsdiagnosticsresourcemonitoring)
