---
title: .NET Diagnostic tools overview
description: An overview of the tools available to diagnose .NET Core applications.
ms.date: 06/8/2023
ms.topic: overview
#Customer intent: As a .NET Core developer I want to find the best tools to help me diagnose problems so that I can be productive.
---

# .NET Core diagnostic tools

.NET supports a number of tools that can be used to diagnose your applications.

## IDE / Editors

### Visual Studio

[Visual Studio](https://visualstudio.microsoft.com/#vs-section) is the most comprehensive IDE for .NET developers on Windows. It includes [debugging](/visualstudio/debugger/) and [performance profiling](/visualstudio/profiling) tools to aid .NET developers in diagnosing their applications.

### Visual Studio Code

[Visual Studio Code](https://visualstudio.microsoft.com/#vscode-section) is a lightweight but powerful source code editor which runs on your desktop and is available for Windows, macOS and Linux. It supports local and remote [debugging](https://code.visualstudio.com/docs/csharp/debugging) for .NET.

## CLI Tools

### dotnet-counters

[dotnet-counters](dotnet-counters.md) is a performance monitoring tool for first-level health monitoring and performance investigation. It observes performance counter values published via the <xref:System.Diagnostics.Tracing.EventCounter> API. For example, you can quickly monitor things like the CPU usage or the rate of exceptions being thrown in your .NET Core application.

### dotnet-dump

The [dotnet-dump](dotnet-dump.md) tool is a way to collect and analyze Windows and Linux core dumps without a native debugger.

### dotnet-gcdump

The [dotnet-gcdump](dotnet-gcdump.md) tool is a way to collect GC (Garbage Collector) dumps of live .NET processes.

### dotnet-monitor

The [dotnet-monitor](dotnet-monitor.md) tool is a way to monitor .NET applications in production environments and to collect diagnostic artifacts (for example, dumps, traces, logs, and metrics) on-demand or using automated rules for collecting under specified conditions.

### dotnet-trace

.NET Core includes what is called the `EventPipe` through which diagnostics data is exposed. The [dotnet-trace](dotnet-trace.md) tool allows you to consume interesting profiling data from your app that can help in scenarios where you need to root cause apps running slow.

### dotnet-stack

The [dotnet-stack](dotnet-stack.md) tool allows you to quickly print the managed stacks for all threads in a running .NET process.

### dotnet-symbol

[dotnet-symbol](dotnet-symbol.md) downloads files (symbols, DAC/DBI, host files, etc.) needed to open a core dump or minidump. Use this tool if you need symbols and modules to debug a dump file captured on a different machine.

### dotnet-sos

[dotnet-sos](dotnet-sos.md) installs the [SOS debugging extension](sos-debugging-extension.md) on Linux and macOS (and on Windows if you're using [Windbg/cdb](/windows-hardware/drivers/debugger/debugger-download-tools)).

## Other Tools

### PerfCollect

[PerfCollect](trace-perfcollect-lttng.md) is a bash script you can use to collect traces with `perf` and `LTTng` for a more in-depth performance analysis of .NET apps running on Linux distributions.
