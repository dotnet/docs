---
title: "Breaking change: HttpClient high-cardinality metrics use observable counters"
description: "Learn about the breaking change in .NET 11 where the http.client.open_connections and http.client.active_requests metrics become observable counters."
ms.date: 09/16/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/runtime/issues/133895
---

# HttpClient high-cardinality metrics use observable counters

Starting in .NET 11, the `http.client.open_connections` and `http.client.active_requests` metrics use <xref:System.Diagnostics.Metrics.ObservableUpDownCounter`1> instead of <xref:System.Diagnostics.Metrics.UpDownCounter`1>. If your code uses <xref:System.Diagnostics.Metrics.MeterListener> directly to listen for measurements from these two instruments, you no longer receive them through the measurement event callback.

## Version introduced

.NET 11 RC 1

## Previous behavior

Previously, `http.client.open_connections` and `http.client.active_requests` were regular `UpDownCounter<long>` instruments. `HttpClient` called `Add` on the counter every time a connection or request started or stopped, so a `MeterListener` that enabled measurement events for either instrument received a push notification for each individual `Add` call.

## New behavior

Starting in .NET 11, `http.client.open_connections` and `http.client.active_requests` are `ObservableUpDownCounter<long>` instruments. `HttpClient` maintains the current counts internally and only reports them when a collection tool asks for the current value. A `MeterListener` that enables measurement events for either instrument no longer receives individual push notifications. Instead, you must call <xref:System.Diagnostics.Metrics.MeterListener.RecordObservableInstruments?displayProperty=nameWithType> periodically to pull the current measurements on demand.

Tools that already collect metrics on a pull basis, such as the OpenTelemetry SDK, Prometheus exporters, `dotnet-counters`, `dotnet-monitor`, and the Aspire dashboard, are unaffected because they already sample observable instruments periodically.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The `http.client.open_connections` and `http.client.active_requests` metrics include high-cardinality tags such as server and peer addresses. Because these metrics were regular counters, every unique combination of tag values that a monitoring back end observed was retained and aggregated indefinitely, which caused unbounded memory growth and increased costs in some monitoring systems. Observable counters let `HttpClient` maintain the counts internally, report only the combinations that are currently active, and drop entries whose count returns to zero. For more information, see the [pull request that made this change](https://github.com/dotnet/runtime/pull/131275) and the related [issue about high-cardinality attributes](https://github.com/dotnet/runtime/issues/122752).

## Recommended action

If you use `MeterListener` directly to read `http.client.open_connections` or `http.client.active_requests`, call `RecordObservableInstruments()` on your listener at the interval you want to sample these metrics, instead of relying solely on the measurement event callback. If you consume these metrics through a metrics collection tool, an exporter, or the Aspire dashboard, no action is needed because those tools already pull values from observable instruments.

## Affected APIs

- <xref:System.Diagnostics.Metrics.MeterListener.EnableMeasurementEvents*?displayProperty=fullName>
- <xref:System.Diagnostics.Metrics.MeterListener.SetMeasurementEventCallback*?displayProperty=fullName>
- <xref:System.Diagnostics.Metrics.MeterListener.RecordObservableInstruments?displayProperty=fullName>
