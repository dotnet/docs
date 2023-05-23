---
title: Performance tracing
description: A guide to tracing in .NET
ms.date: 05/19/2023
---

# Performance tracing overview

Performance tracing is the ability to collect detailed diagnostic information about what is happening inside .NET processes, and includes telemetry information for the Runtime, GC, Libraries and application code.

There are a number of aspects to performance tracing for .NET, including:

## How events are sourced

There are two main mechanisms within .NET for providing events for use with performance tracing:

| Name | Description |
| --- | --- |
| [EventSource](./eventsource.md) | <xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType> is a fast structured logging solution built into the .NET runtime. On .NET Framework EventSource can send events to [Event Tracing for Windows (ETW)](/windows/win32/etw/event-tracing-portal) and <xref:System.Diagnostics.Tracing.EventListener?displayProperty=nameWithType>. On .NET Core EventSource additionally supports [EventPipe](./eventpipe.md), a cross-platform tracing option. Most often developers use EventSource logs for performance analysis, but EventSource can be used for any diagnostic tasks where logs are useful. The .NET runtime is already instrumented with [built-in events](./well-known-event-providers.md) and you can log your own custom events. |
| [DiagnosticSource](./diagnosticsource-diagnosticlistener.md) | <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> is a module that allows code to be instrumented for production-time logging of rich data payloads for consumption within the process that was instrumented. At run time, consumers can dynamically discover data sources and subscribe to the ones of interest. <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> was designed to allow in-process tools to access rich data. DiagnosticSource data can also be egressed via EventPipe enabling rich diagnostic data to be collected by dedicated tools. |

## How events are collected

Events can be collected:

| Mechanism | Description |
| --- | --- |
| In-Process | `EventSource` and `DiagnosticSource` can both be listened to in-process and used by tools such as [Open Telemetry](https://opentelemetry.io/docs/instrumentation/net/) to collect detailed events about features like ASP.NET or HttpClient and then produce metrics based on those events. For example Open Telemetry uses DiagnosticSource to create an [Instumentation Library for ASP.NET](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry.Instrumentation.AspNetCore/README.md). |
| Out-of-process | .NET supports rich collection of tracing data via [EventPipe](./eventpipe.md), which can be used by external tools to collect performance tracing data, then can the be analyzed by different tools. |

## Collection tools

The primary collection tools for performance data for .NET are:

| Tool | OS | Description |
| --- | --- | --- |
| [dotnet-trace](./dotnet-trace.md) | All | `dotnet-trace` is a command line tool that will collect traces in the .nettrace format. It can also convert traces to the Chromium or Speedscope formats for viewing. |
| [dotnet-monitor](./dotnet-monitor.md) | All | `dotnet-monitor` is an agent that can be instructed to collect a trace for .NET processes, either by making Web API calls, or by configuring trigger-based rules for CPU or Memory usage thresholds. |
| [Visual Studio](https://learn.microsoft.com/visualstudio/profiling/events-viewer?view=vs-2022) | Windows | Microsoft Visual Studio supports collecting traces for .NET processes as part of the *Performance Profiler* feature. In addition to being able to collect traces, it also can open `.nettrace` traces collected with the other tools in this table. |
| [PerfView](https://github.com/Microsoft/perfview) | Windows | PerfView is a tool for collecting and examining perfomance traces on Windows |
| [PerfCollect](./trace-perfcollect-lttng.md) | Linux | Perfcollect is a collection of scripts that works with the Linux `LTTng` and `perf` tools to collect detailed performance traces for .NET Processes. The resulting traces can be analyzed with a variety of tools include PerfView. |
| [Windows Performance Analyzer](https://learn.microsoft.com/windows-hardware/test/wpt/wpt-getting-started-portal) | Windows | WPA includes a performance recorder and viewer based on the Windows `ETW` event recorder system. It can record a trace of the complete system, including all processes and how they interact with the OS functionality for Networking, Disk IO etc. |

## See also

[Debug high CPU usage](./debug-highcpu.md)
[Collect a performance trace in Linux with PerfCollect](./trace-perfcollect-lttng.md)