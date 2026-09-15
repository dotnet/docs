---
title: Microsoft.Testing.Platform (MTP) OpenTelemetry
description: Learn how to use the OpenTelemetry extension to emit traces and metrics from MTP.
author: Evangelink
ms.author: amauryleve
ms.date: 08/26/2026
ai-usage: ai-assisted
---

# OpenTelemetry

This feature requires the [Microsoft.Testing.Extensions.OpenTelemetry](https://nuget.org/packages/Microsoft.Testing.Extensions.OpenTelemetry) NuGet package.

This extension integrates [OpenTelemetry](https://opentelemetry.io/) with Microsoft.Testing.Platform (MTP), allowing test runs to emit traces and metrics through the standard OpenTelemetry SDK.

> [!NOTE]
> This extension is available in MTP starting with version 2.1.0.

> [!IMPORTANT]
> Starting with MTP 2.4.0, the OpenTelemetry extension follows the MTP release version and its public entry points are no longer experimental.

## Registration

> [!NOTE]
> This extension doesn't support auto-registration. You must register it manually by disabling the auto-generated entry point (`<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`) and calling `AddOpenTelemetryProvider` in your `Main` method.

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

To configure instrumentation, resource attributes, and an OTLP exporter from standard `OTEL_*` environment variables, call:

```csharp
builder.AddOpenTelemetryProviderFromEnvironment();
```

The method adds instrumentation only when you configure an exporter or pass a configuration callback, so you can leave the registration in the application when some environments don't export telemetry.

## API

### `AddOpenTelemetryProvider`

Registers the OpenTelemetry provider on `ITestApplicationBuilder`. Accepts two optional callbacks:

- `withTracing`: configures the `TracerProviderBuilder` for distributed tracing.
- `withMetrics`: configures the `MeterProviderBuilder` for metrics collection.

### `AddTestingPlatformInstrumentation`

Call on `TracerProviderBuilder` or `MeterProviderBuilder` to subscribe to the built-in `Microsoft.Testing.Platform` activity source and meter.

### `AddTestingPlatformResource`

Call on `ResourceBuilder` to add test assembly, host, operating system, and runtime attributes. The detector also identifies CI provider, pipeline, branch, and commit information for GitHub Actions, Azure Pipelines, GitLab CI, and Jenkins.

### `AddOpenTelemetryProviderFromEnvironment`

Registers tracing, metrics, resource detection, and an OTLP exporter from standard OpenTelemetry environment variables. `OTEL_SDK_DISABLED=true` disables the integration. Configure `OTEL_TRACES_EXPORTER`, `OTEL_METRICS_EXPORTER`, or `OTEL_EXPORTER_OTLP_ENDPOINT` to activate export.

## Activity source and meter

The extension emits telemetry under:

- Activity source: `Microsoft.Testing.Platform`
- Meter: `Microsoft.Testing.Platform`

## Semantic conventions

MTP emits standard OpenTelemetry testing and code attributes where a convention exists, including `test.case.name`, `test.case.result.status`, `test.suite.name`, `code.function.name`, `code.file.path`, `code.line.number`, `code.stacktrace`, and `error.type`. Failed tests set the span status to `Error` and add an `exception` event.

MTP extends the conventions with additional result states (`skipped`, `error`, `timeout`, `cancelled`, and `unknown`) and test attributes for concepts that OpenTelemetry doesn't define. To preserve existing dashboards, legacy attribute and instrument names remain enabled by default.

When the launching process supplies `TRACEPARENT` and `TRACESTATE`, MTP places the test run under that trace instead of starting an unrelated root trace.

## Emitted metrics

| Instrument | Type | Unit | Description |
|---|---|---|---|
| `test.case.duration` | Histogram | `s` | Test duration, grouped by result status and suite. |
| `test.case.result.count` | Counter | `{test}` | Completed tests, grouped by result status and suite. |
| `test.case.active` | UpDownCounter | `{test}` | Tests that are currently running. |
| `test.run.duration` | Histogram | `s` | Run duration, grouped by result status and exit code. |
| `test.case.retry.count` | Counter | `{test}` | Tests scheduled for another attempt by the retry extension. |

## Environment configuration

| Environment variable | Default | Description |
|---|---|---|
| `TRACEPARENT`, `TRACESTATE` | Unset | W3C trace context for the parent run. |
| `TESTINGPLATFORM_OTEL_CAPTURE_TEST_OUTPUT` | `1` | Attaches captured standard output and error to test spans. Set to `0` when output might contain secrets. |
| `TESTINGPLATFORM_OTEL_ATTRIBUTE_VALUE_LENGTH_LIMIT` | `8192` | Sets the maximum characters retained for a string attribute. |
| `TESTINGPLATFORM_OTEL_EMIT_LEGACY_ATTRIBUTES` | `1` | Emits legacy attribute and instrument names alongside semantic-convention names. |
| `OTEL_SDK_DISABLED` | Unset | Set to `true` to disable the OpenTelemetry SDK. |
| `OTEL_SERVICE_NAME` | Unset | Overrides the service name. |
| `OTEL_EXPORTER_OTLP_ENDPOINT` | Unset | Sets the OTLP endpoint. |
| `OTEL_TRACES_EXPORTER`, `OTEL_METRICS_EXPORTER` | Unset | Selects trace and metric exporters. |
