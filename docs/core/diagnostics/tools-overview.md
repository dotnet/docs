---
title: .NET Diagnostic tools overview
description: An overview of the tools available to diagnose .NET applications.
ms.date: 09/04/2026
ms.topic: overview
#Customer intent: As a .NET developer I want to find the best tools to help me diagnose problems so that I can be productive.
---

# .NET diagnostic tools

.NET supports a number of tools that can be used to diagnose your applications.

## IDEs and editors

### Visual Studio

[Visual Studio](https://visualstudio.microsoft.com/#vs-section) is the most comprehensive IDE for .NET developers on Windows. It includes [debugging](/visualstudio/debugger/) and [performance profiling](/visualstudio/profiling) tools to aid .NET developers in diagnosing their applications.

### Visual Studio Code

[Visual Studio Code](https://visualstudio.microsoft.com/#vscode-section) is a lightweight but powerful source code editor that runs on your desktop and is available for Windows, macOS, and Linux. It supports local and remote [debugging](https://code.visualstudio.com/docs/csharp/debugging) for .NET.

## CLI tools

### dotnet-counters

[dotnet-counters](dotnet-counters.md) is a performance monitoring tool for first-level health monitoring and performance investigation. It observes performance counter values published via the <xref:System.Diagnostics.Tracing.EventCounter> API. For example, you can quickly monitor things like the CPU usage or the rate of exceptions being thrown in your .NET application.

### dotnet-dump

The [dotnet-dump](dotnet-dump.md) tool is a way to collect and analyze Windows and Linux core dumps without a native debugger.

### dotnet-gcdump

The [dotnet-gcdump](dotnet-gcdump.md) tool is a way to collect garbage collector (GC) dumps of live .NET processes.

### dotnet-monitor

The [dotnet-monitor](dotnet-monitor.md) tool is a way to monitor .NET applications in production environments and to collect diagnostic artifacts (for example, dumps, traces, logs, and metrics) on-demand or using automated rules for collecting under specified conditions.

### dotnet-trace

The [dotnet-trace](dotnet-trace.md) tool is a cross-platform .NET diagnostic tool that collects traces from running applications without using a native profiler. On Linux, it can also combine .NET runtime and application events with machine-wide CPU samples, native call stacks, and Linux kernel events collected through the `perf_events` facility.

### dotnet-stack

The [dotnet-stack](dotnet-stack.md) tool allows you to quickly print the managed stacks for all threads in a running .NET process.

### dotnet-symbol

[dotnet-symbol](dotnet-symbol.md) downloads files (for example, symbols, DAC/DBI, and host files) needed to open a core dump or minidump. Use this tool if you need symbols and modules to debug a dump file captured on a different machine.

### dotnet-debugger-extensions

[dotnet-debugger-extensions](dotnet-debugger-extensions.md) installs the [.NET debugger extensions](debugger-extensions.md) on Linux, macOS, and Windows.  [LLDB](https://lldb.llvm.org/) is required for Linux and macOS, and  [Windbg/cdb](/windows-hardware/drivers/debugger/debugger-download-tools) is needed for Windows.  

## Other tools

### OneCollect `record-trace`

The [OneCollect `record-trace`](https://github.com/microsoft/one-collect/tree/main/record-trace) tool records system-wide performance traces on Linux and Windows. Use it for lower-level, scriptable control over event selection, process and CPU filtering, and trace output. For a .NET-oriented Linux workflow that configures runtime events and system profiling together, use [`dotnet-trace collect-linux`](dotnet-trace.md#dotnet-trace-collect-linux).

### PerfCollect

[PerfCollect](trace-perfcollect-lttng.md) is the earlier bash-based workflow for collecting Linux CPU samples with `perf` and .NET runtime and EventSource events with LTTng. Prefer `dotnet-trace collect-linux` for new investigations when possible. PerfCollect remains documented for existing workflows, but its runtime-event collection depends on an older LTTng ABI.
