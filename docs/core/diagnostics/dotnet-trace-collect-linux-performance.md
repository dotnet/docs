---
title: "Tutorial: Investigate Linux performance with dotnet-trace"
description: Collect Linux performance traces and diagnose a managed CPU hotspot and large object heap pressure with Visual Studio and PerfView.
ms.date: 09/08/2026
ms.topic: tutorial
#Customer intent: As a .NET developer on Linux, I want to collect and analyze the right trace data to find the cause of a performance problem.
ai-usage: ai-assisted
---

# Tutorial: Investigate Linux performance with `dotnet-trace collect-linux`

`dotnet-trace collect-linux` records .NET runtime events together with Linux CPU samples, native call stacks, process activity, scheduling data, and kernel events. By default, collection is machine-wide. This tutorial follows two problems from collection to diagnosis: a managed CPU hotspot and frequent collections caused by large object heap (LOH) allocations.

## Prerequisites

The tutorial requires:

- Linux and .NET 10 or later that meet the [`collect-linux` prerequisites](dotnet-trace.md#prerequisites).
- The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- The latest [`dotnet-trace`](dotnet-trace.md) global tool.
- A Windows machine with [Visual Studio or PerfView](dotnet-trace.md#view-the-trace-captured-from-dotnet-trace) to analyze the trace.
- The [performance scenarios sample](/samples/dotnet/samples/dotnet-trace-collect-linux-performance-scenarios/).

From the sample directory, build the application:

```dotnetcli
dotnet build -c Release
```

Use one Linux terminal for the workload and another for collection. Each workload prints its process ID, symptom, and configured duration. Record that PID so you select the application rather than the `dotnet run` host or another process during analysis.

## Example: Find a managed CPU hotspot

This workload keeps one CPU core busy. CPU samples identify the method that consumes the CPU and the call path that reaches it.

### Collect the CPU trace

Start the workload:

```dotnetcli
dotnet run -c Release --no-build -- cpu-hotspot 45
```

While the workload runs, collect a 15-second trace in the other terminal:

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile dotnet-common,cpu-sampling \
  --duration 00:00:15 \
  --output cpu-hotspot.nettrace
```

`dotnet-common` provides lightweight .NET runtime context, while `cpu-sampling` provides Linux CPU samples and native call stacks.

Wait for the collector to finish, then copy `cpu-hotspot.nettrace` to a local directory on the Windows analysis machine.

### Interpret the CPU trace

Use Visual Studio's [CPU Usage report](/visualstudio/profiling/cpu-usage#analyze-cpu-utilization) to analyze the trace. Select the sample's process ID and the interval in which the workload ran. **Self CPU** identifies samples in a function itself; **Total CPU** includes its callees. The call tree and caller/callee views show the application path that reaches the expensive function.

Look for `Fibonacci` with high self CPU, and for `Fibonacci` appearing as both caller and callee. The following excerpt illustrates the relevant part of the sample's call tree; prefixes and counts vary with the build and selected interval:

```text
CpuScenarios.HotspotAsync
  CpuScenarios.Fibonacci
    CpuScenarios.Fibonacci
      CpuScenarios.Fibonacci
```

**Interpretation:** The process spends its CPU time in recursive Fibonacci computation. High self CPU locates the expensive method; the repeated frames establish recursion. A runtime startup frame with high *total* CPU is a caller of the expensive work, not evidence that startup caused the sustained CPU use.

In the sample source, `CpuScenarios.HotspotAsync` repeatedly computes `Fibonacci(36)`, and `CpuScenarios.Fibonacci` calls itself recursively. An iterative algorithm or reuse of the result can avoid repeated recursive work. After an optimization, repeat the same workload and compare absolute CPU use as well as the stack profile.

You can also analyze `cpu-hotspot.nettrace` with [PerfView](https://github.com/microsoft/perfview). For native symbol information, see [Get symbols for native runtime frames in PerfView](dotnet-trace.md#get-symbols-for-native-runtime-frames-in-perfview).

In either tool, a high percentage means a large share of the *selected samples*, not that the process consumed every CPU on the machine. Check the process, interval, and absolute CPU usage before drawing that conclusion.

## Example: Diagnose large object heap pressure

This workload causes frequent full collections despite a modest retained object count. Collect allocation and GC events to distinguish large-object pressure from frequent small allocations or explicit calls to `GC.Collect`.

### Collect allocation and GC data

After the CPU workload exits, start the LOH workload:

```dotnetcli
dotnet run -c Release --no-build -- loh-gc 45
```

In the collection terminal, run:

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile gc-verbose,cpu-sampling \
  --duration 00:00:15 \
  --output loh-gc.nettrace
```

The `gc-verbose` profile adds detailed GC and sampled allocation events. After collection completes, copy `loh-gc.nettrace` to the Windows analysis machine.

### Interpret allocation and GC data

In Visual Studio, examine allocation and collection data for the sample process and workload interval. Correlate allocation types with GC generation, reason, and pause duration. An **Insights** result can suggest a starting point, but the diagnosis depends on the underlying data:

| View | Result to look for | What it tells you |
| --- | --- | --- |
| **Allocations** | Repeated `System.Byte[]` allocations | Byte arrays contribute to the allocation workload. Sampled allocation records aren't an exact object count. |
| **Collections** | Generation 2, `AllocLarge`, and repeated pauses | Large-object allocations trigger full collections during the workload. |

**Interpretation:** Large-array allocation pressure causes repeated full collections. The collection reason distinguishes this case from an `Induced` collection triggered by an explicit request. GC CPU alone wouldn't identify that distinction.

In the sample source, `MemoryScenarios.LohGcAsync` allocates 200,000-byte arrays, which exceed the [85,000-byte LOH threshold](../../standard/garbage-collection/large-object-heap.md), and retains a rolling set. Reduce repeated large allocations, for example by reusing buffers when their lifetime permits, then compare allocation volume and GC pauses in another trace.

For event-level detail, examine the `Microsoft-Windows-DotNETRuntime` events `GC/HeapStats`, `GC/Start`, and `GC/Stop` in [Visual Studio's Events Viewer](/visualstudio/profiling/events-viewer) or PerfView. Inspect payloads and timestamps for the workload. In either tool, check the process identity and any result limit before interpreting counts.

Allocation pressure doesn't by itself prove a memory leak. If the remaining question is why objects stay alive, follow [Debug a memory leak](debug-memory-leak.md) to inspect retention paths in a process dump.

## Choose a focused follow-up trace

Use the first trace to choose a direction, and then collect only the detailed events required to answer the next question. CPU samples don't explain time spent sleeping or waiting because a thread that isn't running can't be sampled.

### Blocking, contention, and ThreadPool behavior

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile thread-time,cpu-sampling \
  --clrevents threading+contention+waithandle \
  --clreventlevel Verbose
```

For the complete investigation, follow [Debug ThreadPool starvation](debug-threadpool-starvation.md). For example, if `dotnet-common` or `gc-verbose` configures the runtime provider, the tool prints a warning and ignores a supplied `--clrevents` list. Use kernel-only profiles such as `cpu-sampling` or `thread-time` with a focused `--clrevents`/`--clreventlevel` configuration.

## Know when to use another artifact

Use a process dump for an existing [deadlock](debug-deadlock.md), application or [distributed tracing](distributed-tracing.md) for logical request relationships, and a native memory profiler for native allocation ownership. Collecting more of the same data doesn't recover information that the artifact doesn't contain.

## Manage collection overhead

Trace overhead depends on event rate, enabled providers, stack capture, CPU count, and workload behavior. High-volume traces can lose events or perturb the application being measured.

- Keep the initial trace short.
- Enable only the detailed events needed for the current question.
- Treat event totals as lower bounds when they disagree with application or operating-system counters.
- Repeat the capture with a narrower configuration when exact counts matter.
- Test production collection procedures and container limits before an incident.

## See also

- [Performance tutorials](index.md#performance-tutorials)
- [`dotnet-trace` reference](dotnet-trace.md)
- [Debug high CPU usage](debug-highcpu.md)
- [Collect diagnostics in Linux containers](diagnostics-in-containers.md)
