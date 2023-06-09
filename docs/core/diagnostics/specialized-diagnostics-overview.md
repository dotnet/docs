---
title: Specialized Diagnostics
description: A guide to more advanced diagnostics support in .NET
ms.date: 05/19/2023
---
# Specialized Diagnostics

If debugging or observability is not sufficient, .NET supports additional diagnostic mechanisms.

## Tracing with Event Source

[Event Source](./eventsource.md)) provides the ability to collect detailed diagnostic information about what is happening inside .NET processes, and includes telemetry information for the Runtime, GC, Libraries and application code.

Event Source data can be collected in-process using the <xref:System.Diagnostics.Tracing.EventListener?displayProperty=nameWithType> API or with external diagostics tools such as [Visual Studio](/visualstudio/profiling), [dotnet-monitor](./dotnet-monitor.md), [dotnet-trace](./dotnet-trace.md), [PerfView](https://github.com/microsoft/perfview) and the [Perfcollect](./trace-perfcollect-lttng.md) scripts. Using the external tools to collect eventsource data in traces is commonly used for perforance analysis.

### Collecting diagnostics in containers

The same diagnostics tools that are used in non-containerized Linux environments can also be used to [collect diagnostics in containers](diagnostics-in-containers.md). There are just a few usage changes needed to make sure the tools work in a Docker container.

### EventPipe

[EventPipe](./eventpipe.md) is a runtime component that can be used to collect tracing data, similar to ETW or LTTng. The goal of EventPipe is to allow .NET developers to easily trace their .NET applications without having to rely on platform-specific OS-native components such as ETW or LTTng.

EventPipe is the mechanism behind many of the diagnostic tools and can be used for consuming events emitted by the runtime as well as custom events written with [EventSource](xref:System.Diagnostics.Tracing.EventSource).

## Dumps

A [dump](./dumps.md) is a file that contains a snapshot of the process at the time of dump creation. These can be useful for examining the state of your application for debugging purposes.

## Symbols

[Symbols](./symbols.md) are a mapping between the source code and the binary produced by the compiler. These are commonly used by .NET debuggers & tracing tools to resolve source line numbers, local variable names, and other types of diagnostic information.

## Diagnostic port

The .NET Core runtime exposes a service endpoint that allows other processes to send diagnostic commands and receive responses over an [IPC channel](https://en.wikipedia.org/wiki/Inter-process_communication). This endpoint is called a *diagnostic port*. Commands can be sent to the diagnostic port to:

- Capture a memory dump.
- Start an EventPipe trace.
- Request the command-line used to launch the app.

## DiagnosticSource & DiagnosticListener

[DiagnosticSource](./diagnosticsource-diagnosticlistener.md) is a module that allows code to be instrumented for production-time logging of rich data payloads for consumption within the process that was instrumented. At run time, consumers can dynamically discover data sources and subscribe to the ones of interest. <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> was designed to allow in-process tools to access rich data such as by [Open Telemetry instrumentation libraries](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry.Instrumentation.AspNetCore/README.md). DiagnosticSource data can also be egressed via EventPipe enabling rich diagnostic data to be collected by dedicated tools. |

## See Also

[Debug high CPU usage](./debug-highcpu.md)
[Collect a performance trace in Linux with PerfCollect](./trace-perfcollect-lttng.md)
