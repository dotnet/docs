---
title: Diagnose performance issues in .NET applications
description: Choose diagnostic data and tools based on the symptoms of a .NET performance problem.
ms.date: 09/08/2026
ms.topic: conceptual
#Customer intent: As a .NET developer, I want to choose the right diagnostic tools and data to find the cause of a performance problem.
---

# Diagnose performance issues in .NET applications

Performance investigations are most effective when you start with the observed symptom, collect the least expensive data that can distinguish likely causes, and then collect a more detailed artifact only when the evidence points to it.

This article helps you choose among metrics, logs, distributed traces, stack snapshots, performance traces, GC dumps, and process dumps. For installation and complete command syntax, see [.NET diagnostic tools](tools-overview.md).

## Start with the symptom

Before collecting a large trace or dump, record:

- The time range in which the problem occurred.
- The affected process, request, operation, or workload.
- CPU usage, memory usage, request rate, latency, and error rate.
- Whether the problem is continuous, intermittent, or limited to startup.
- Whether the machine, container, or only one process is resource constrained.

Always-on [metrics](metrics.md), logs, and [distributed traces](distributed-tracing.md) are often the best sources for this first step. They have lower overhead than detailed performance traces and help identify the process and time window that require deeper investigation.

## Choose a performance collector for the platform

Many of the workflows in the next section require a trace of activity over time. Choose a collector that provides real operating-system CPU samples and native context when CPU or system activity matters, and add .NET runtime events when the question involves GC, allocation, exceptions, JIT, loading, or managed threading.

| Environment | Preferred collection workflow |
| --- | --- |
| Windows development | Use the [Visual Studio Performance Profiler](/visualstudio/profiling/) for an interactive investigation. |
| Windows system-wide or production analysis | Use ETW through Windows Performance Recorder and Windows Performance Analyzer, or use PerfView. |
| .NET 10+ on Linux with the required kernel support | Use [`dotnet-trace collect-linux`](dotnet-trace-collect-linux-performance.md) for one trace containing .NET events, Linux CPU samples, native stacks, scheduling, and selected Linux events. |
| Linux without the `collect-linux` prerequisites | Use Linux `perf` for CPU, native, and system profiling. Use [`dotnet-trace collect`](dotnet-trace.md#dotnet-trace-collect) separately when you need .NET runtime events or managed stack samples. |
| macOS | Use Xcode Instruments for CPU and native profiling. Use [`dotnet-trace collect`](dotnet-trace.md#dotnet-trace-collect) separately when you need .NET runtime events or managed stack samples. |
| Automated production or container collection | Use [`dotnet-monitor`](dotnet-monitor.md) for automated .NET diagnostics, and pair it with the platform profiler when the investigation requires operating-system or native context. |

On Linux or Windows, use OneCollect [`record-trace`](https://github.com/microsoft/one-collect/tree/main/record-trace) when you need lower-level scripts, event selection, process or CPU filtering, or alternate output formats. On Linux, use `perf` directly when you specifically require `perf.data`, perf-native analysis, or hardware performance counters. [PerfCollect](trace-perfcollect-lttng.md) is the earlier Linux workflow and its runtime-event collection requires LTTng 2.12; it isn't the default fallback for `collect-linux`.

`dotnet-trace collect` works on all operating systems and is useful for .NET runtime events and managed stack sampling. Its managed sampling and managed-only stacks aren't a replacement for a platform CPU profiler when you need unbiased CPU attribution, native frames, kernel activity, or competing-process context.

## Use the recommended workflow for the symptom

Use [`dotnet-counters`](dotnet-counters.md), your monitoring system, or [built-in .NET metrics](built-in-metrics.md) to confirm the symptom and identify the affected process and time range. Then use the platform workflow from the preceding section to collect the evidence described here.

| Observed symptom | Recommended workflow |
| --- | --- |
| High CPU usage | Follow [Debug high CPU usage](debug-highcpu.md). Collect a CPU profile with the platform profiler, find the code with the greatest exclusive cost, and follow its callers back to application code. |
| Increasing managed memory | Confirm managed heap growth, collect a [`dotnet-gcdump`](dotnet-gcdump.md) to identify growing types, and collect a [`dotnet-dump`](dotnet-dump.md) when you need retention roots. Follow [Debug a memory leak](debug-memory-leak.md) for the dump workflow. If process RSS grows while the managed heap remains stable, use a native memory profiler instead. |
| Long or frequent GC pauses | Confirm pause time and collection frequency, then collect allocation and GC events to identify allocation types, callers, generations, collection reasons, and pause duration. On Linux, use the [`collect-linux` allocation and GC configuration](dotnet-trace-collect-linux-performance.md#allocation-and-gc). On other platforms, use ETW, the Visual Studio profiler, or `dotnet-trace collect --profile gc-verbose`. Use a GC dump or process dump only when the remaining question is why objects survive. |
| Slow work with low CPU usage | For a continuously stuck process, begin with repeated [`dotnet-stack`](dotnet-stack.md) snapshots. For an intermittent delay, collect scheduling or thread-time data with the platform profiler. On Linux, use the [`collect-linux` blocking configuration](dotnet-trace-collect-linux-performance.md#blocking-contention-and-threadpool-behavior). Use activities or application instrumentation when physical stacks don't preserve the logical async or request caller. |
| ThreadPool starvation | Follow [Debug ThreadPool starvation](debug-threadpool-starvation.md): confirm worker growth and queueing with metrics, use `dotnet-stack` for a continuous issue, and use a threading and wait trace for an intermittent issue. |
| Deadlock | Collect a process dump and follow [Debug a deadlock](debug-deadlock.md) to inspect lock owners and the wait cycle. To understand how an intermittent deadlock forms, start contention and scheduling collection before reproduction. |
| Slow file or network I/O | Start with dependency telemetry and logs. If the delay is inside the process or operating system, collect scheduling data and the relevant file, socket, or syscall events to connect blocked time and operations to callers. Use storage, network, database, or remote-service diagnostics when the delay is outside the process. |
| High exception rate | Confirm the rate with metrics or logs, then collect .NET first-chance exception events and call stacks to identify repeated throw sites, including caught exceptions. Use a dump when you need the state of one unhandled exception or crash. |
| Slow startup | Start the platform profiler before launching the process and include CPU, loader, JIT, file, and process activity. Add startup-specific application instrumentation when runtime and operating-system events don't identify the delayed logical operation. |
| Slow distributed request | Use distributed tracing to identify the service and dependency that own the latency, then collect a process trace from that service for the same interval. Add application instrumentation when the required business or async relationship isn't represented. |

## Choose a different artifact when a performance trace can't answer the question

Collecting more of the same data doesn't recover information that the artifact doesn't contain. Choose the artifact that records the relationship you still need to prove.

| Information you need | Appropriate source |
| --- | --- |
| Why managed objects remain alive | GC dump or process dump |
| Exact finalizer queue and heap roots | Process dump |
| Existing deadlock ownership and lock cycle | Process dump |
| Logical async, request, or distributed causality | Activity, distributed tracing, or application instrumentation |
| Database query plans or remote-service internals | Database and dependency diagnostics |
| Native allocation ownership | Native memory profiler |
| Cache misses, branch prediction, IPC, or memory bandwidth | Hardware performance counters and platform profiler |
| Inlined methods or generated machine instructions | Source, disassembly, or a diagnostic build |

## See also

- [.NET diagnostic tools](tools-overview.md)
- [Metrics collection](metrics-collection.md)
- [Dumps](dumps.md)
- [Collect dumps on crash](collect-dumps-crash.md)
- [Collect diagnostics in Linux containers](diagnostics-in-containers.md)
- [Investigate Linux performance with `dotnet-trace collect-linux`](dotnet-trace-collect-linux-performance.md)
