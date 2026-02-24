---
title: Microsoft.Testing.Platform OpenTelemetry extension
description: Learn how to use the OpenTelemetry extension to emit traces and metrics from Microsoft.Testing.Platform.
author: Evangelink
ms.author: amauryleve
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# OpenTelemetry extension

This extension integrates [OpenTelemetry](https://opentelemetry.io/) with Microsoft.Testing.Platform, allowing test runs to emit traces and metrics through the standard OpenTelemetry SDK. This extension is shipped as part of [Microsoft.Testing.Extensions.OpenTelemetry](https://nuget.org/packages/Microsoft.Testing.Extensions.OpenTelemetry) NuGet package.

> [!IMPORTANT]
> This extension is currently experimental. All public APIs are gated behind the `TPEXP` diagnostic ID.

## Registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);

builder.AddOpenTelemetryProvider(
    withTracing: tracing => tracing
        .AddTestingPlatformInstrumentation()
        .AddConsoleExporter(),
    withMetrics: metrics => metrics
        .AddTestingPlatformInstrumentation()
        .AddConsoleExporter()
);

using var app = await builder.BuildAsync();
return await app.RunAsync();
```

> [!NOTE]
> To use this extension, you must disable the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>` in your project file.

## API

### `AddOpenTelemetryProvider`

Registers the OpenTelemetry provider on `ITestApplicationBuilder`. Accepts two optional callbacks:

- `withTracing`: configures the `TracerProviderBuilder` for distributed tracing.
- `withMetrics`: configures the `MeterProviderBuilder` for metrics collection.

### `AddTestingPlatformInstrumentation`

Call on `TracerProviderBuilder` or `MeterProviderBuilder` to subscribe to the built-in `Microsoft.Testing.Platform` activity source and meter.

## Activity source and meter

The extension emits telemetry under:

- Activity source: `Microsoft.Testing.Platform`
- Meter: `Microsoft.Testing.Platform`
