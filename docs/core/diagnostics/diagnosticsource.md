---
title: DiagnosticSource
description: A guide to logging with DiagnosticSource
ms.date: 05/03/2022
---
# DiagnosticSource

**This article applies to: ✔️** .NET Core 3.1 and later versions **✔️** .NET Framework 4.5 and later versions

<xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> is a simple module that allows code to be instrumented for production-time
logging of rich data payloads for consumption within the process that was instrumented. At runtime, consumers can dynamically discover
data sources and subscribe to the ones of interest. <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> was designed to allow in-process
tools to access rich data. When using <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType>, the consumer is assumed
to be within the same process and as a result, non-serializable types (e.g. `HttpResponseMessage` or `HttpContext`) can be passed,
giving customers plenty of data to work with.

> [!NOTE]
> Many technologies that integrate with DiagnosticSource use the terms 'Tracing' and 'Traces' instead of 'Logging' and 'Logs'.
> The meaning is the same here.

- [Getting started](./diagnosticsource-getting-started.md)
- [Instrumenting code to create events and consuming data](./diagnosticsource-instrumentation-consumption.md)
