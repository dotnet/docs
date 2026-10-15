---
title: "Tutorial: Investigate Linux performance with dotnet-trace"
description: Collect Linux performance traces and investigate a managed CPU hotspot and garbage collection pauses with Visual Studio and PerfView.
ms.date: 09/08/2026
ms.topic: tutorial
#Customer intent: As a .NET developer on Linux, I want to collect and analyze the right trace data to find the cause of a performance problem.
ai-usage: ai-assisted
---

# Tutorial: Investigate Linux performance with `dotnet-trace collect-linux`

`dotnet-trace collect-linux` records .NET runtime events together with Linux CPU samples, native call stacks, process activity, scheduling data, and kernel events. By default, collection is machine-wide. This tutorial follows two problems from collection to diagnosis: a managed CPU hotspot and garbage collection (GC) pauses caused by managed heap pressure.

## Prerequisites

The tutorial requires:

- A Linux host that meets the [`collect-linux` prerequisites](dotnet-trace.md#prerequisites) and has the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) to build and run the sample. The SDK includes the required .NET 10 runtime.
- The latest [`dotnet-trace`](dotnet-trace.md) global tool.
- A Windows machine with [Visual Studio or PerfView](dotnet-trace.md#view-the-trace-captured-from-dotnet-trace) to analyze the trace.
- The [performance scenarios sample](/samples/dotnet/samples/dotnet-trace-collect-linux-performance-scenarios/).

From the sample directory, build the application:

```dotnetcli
dotnet build -c Release
```

Use one Linux terminal for the workload and another for collection. Each workload prints its process ID, symptom, and configured duration. Record that PID so you select the application rather than the `dotnet run` host or another process during analysis.
When you analyze either trace, select that PID and the workload interval. Before you rely on event counts in Visual Studio or PerfView, check whether the event view limits the displayed results.

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

Open `cpu-hotspot.nettrace` in Visual Studio. In the **CPU Usage** summary, select **Open details** to examine the [CPU Usage report](https://learn.microsoft.com/visualstudio/profiling/cpu-usage#analyze-cpu-utilization) for the sample's process ID and workload interval. **Self CPU** identifies samples in a function itself; **Total CPU** includes its callees. The call tree and caller/callee views show the application path that reaches the expensive function.

Look for `Fibonacci` with high self CPU, and for `Fibonacci` appearing as both caller and callee. The following excerpt illustrates the relevant part of the sample's call tree; prefixes and counts vary with the build and selected interval:

```text
CpuScenarios.HotspotAsync
  CpuScenarios.Fibonacci
    CpuScenarios.Fibonacci
      CpuScenarios.Fibonacci
```

**Interpretation:** The process spends its CPU time in recursive Fibonacci computation. High self CPU locates the expensive method; the repeated frames establish recursion.

In the sample source, `CpuScenarios.HotspotAsync` repeatedly computes `Fibonacci(36)`, and `CpuScenarios.Fibonacci` calls itself recursively. An iterative algorithm or reuse of the result can avoid repeated recursive work. After an optimization, repeat the same workload and compare absolute CPU use as well as the stack profile.

You can also analyze `cpu-hotspot.nettrace` with [PerfView](https://github.com/microsoft/perfview). For native symbol information, see [Get symbols for native runtime frames in PerfView](dotnet-trace.md#get-symbols-for-native-runtime-frames-in-perfview).

## Example: Investigate long GC pauses

If you suspect GC-related delays, examine pause durations and collection frequency alongside allocation activity and collection reasons. This workload creates managed heap pressure through repeated large object heap (LOH) allocations, which trigger frequent generation 2 (full) collections despite a modest retained object count. A generation 2 collection includes younger generations and the LOH.

### Collect allocation and GC data

Start the LOH workload:

```dotnetcli
dotnet run -c Release --no-build -- loh-gc 45
```

While the workload runs, collect a 15-second trace in the other terminal:

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile gc-verbose \
  --duration 00:00:15 \
  --output loh-gc.nettrace
```

The `gc-verbose` profile adds detailed GC and sampled allocation events. After collection completes, copy `loh-gc.nettrace` to the Windows analysis machine.

### Interpret allocation and GC data

Open `loh-gc.nettrace` in Visual Studio and examine **Collections** and **Allocations** for the sample's process ID and workload interval. Compare the recorded pause durations with your application's latency requirements, then correlate the pauses with allocation types, GC generation, and collection reason:

| View | Result to look for | What it tells you |
| --- | --- | --- |
| **Collections** | Pause duration, generation 2, and `AllocLarge` | Shows the duration of pauses associated with collections triggered by large-object allocations. |
| **Allocations** | Repeated `System.Byte[]` allocations | Byte arrays contribute to the allocation workload. Sampled allocation records aren't an exact object count. |

**Interpretation:** In this example, heap pressure from large-array allocations causes repeated full collections. Frequent collections alone don't establish a long pause; compare individual pause durations and total time spent paused with your latency requirements. The sample doesn't measure an application delay, so match pause timestamps to measured delays in your own application before you conclude GC caused a slowdown. The `AllocLarge` collection reason distinguishes this case from an `Induced` collection triggered by an explicit request; GC CPU alone wouldn't identify that distinction.

For optional event-level detail, examine the `Microsoft-Windows-DotNETRuntime` events `GC/HeapStats`, `GC/Start`, and `GC/Stop` in [Visual Studio's Events Viewer](/visualstudio/profiling/events-viewer) or PerfView. Inspect payloads and timestamps for the workload.

In the sample source, `MemoryScenarios.LohGcAsync` allocates 200,000-byte arrays, which exceed the [default 85,000-byte LOH threshold](../runtime-config/garbage-collector.md#large-object-heap-threshold), and retains a rolling set. Reduce repeated large allocations, for example by reusing buffers when their lifetime permits, then compare allocation volume and GC pauses in another trace.

Allocation pressure doesn't by itself prove a memory leak. This `gc-verbose` capture records allocation samples and GC activity, not a complete snapshot of object references and roots. If the remaining question is why objects stay alive, follow [Debug a memory leak](debug-memory-leak.md) to inspect retention paths in a process dump.

## Understanding tracing overhead

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
