---
title: Practice Linux performance investigation scenarios
description: Use runnable performance scenarios to learn how to choose and analyze dotnet-trace collect-linux configurations.
ms.date: 09/04/2026
ms.topic: tutorial
#Customer intent: As a .NET developer on Linux, I want hands-on examples that teach me how to select trace data and diagnose different performance symptoms.
---

# Practice Linux performance investigations with `dotnet-trace collect-linux`

This tutorial uses one sample application to create CPU, memory, garbage collection, blocking, contention, I/O, startup, exception, process, and mixed-cause performance problems. Each group starts from an observed symptom and uses a different collection strategy or analysis pivot. Work through the scenarios without inspecting the implementation first if you want to practice diagnosing an unknown cause.

For an explanation of the trace data and analysis views used in this tutorial, see [Investigate Linux performance with `dotnet-trace collect-linux`](dotnet-trace-collect-linux-performance.md).

## Prerequisites

The tutorial requires:

- Linux that meets the [`collect-linux` prerequisites](dotnet-trace.md#prerequisites).
- The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- The latest [`dotnet-trace`](dotnet-trace.md) global tool.
- A current version of [PerfView](https://github.com/microsoft/perfview) for analysis.
- The [performance scenarios sample](/samples/dotnet/samples/dotnet-trace-collect-linux-performance-scenarios/).

From the sample directory, build the application and list its scenarios:

```dotnetcli
dotnet build -c Release
dotnet run -c Release --no-build -- --list
```

Run workloads for 30 to 60 seconds so that the symptom is visible while you collect a trace. Each workload prints its process ID, symptom, and configured duration:

```dotnetcli
dotnet run -c Release --no-build -- cpu-hotspot 45
```

Use a second terminal for collection. Start with the [short machine-wide trace](dotnet-trace-collect-linux-performance.md#start-with-a-short-machine-wide-trace), which preserves competing processes, child processes, and work performed before a process can be attached. Start the workload shortly before collection unless a scenario specifically instructs you to start collection first. Open each trace in PerfView, select the interval in which the workload ran, and filter to the relevant process when the investigation doesn't require whole-machine context.

## Establish a healthy baseline

Run the control before diagnosing the intentionally unhealthy scenarios:

```dotnetcli
dotnet run -c Release --no-build -- healthy 45
```

Collect the default `dotnet-common,cpu-sampling` trace. CPU, memory, GC, and latency should remain stable, with no dominant anomalous stack, wait, pause, or event rate. Use this result to learn what ordinary runtime, scheduler, and process activity looks like instead of treating every event in a trace as a problem.

## Diagnose CPU consumption

CPU sampling answers what was executing. Use the [general starting configuration](dotnet-trace-collect-linux-performance.md#general-starting-point) for these scenarios.

### Find a managed CPU hotspot

Run:

```dotnetcli
dotnet run -c Release --no-build -- cpu-hotspot 45
```

In **CPU Stacks**, filter to the sample process and find the application method with the greatest exclusive cost. The recursive `Fibonacci` method should own nearly all samples. This is the direct case in which CPU sampling identifies both the expensive method and its application caller.

### Recognize an inlining attribution limit

Run:

```dotnetcli
dotnet run -c Release --no-build -- inlining 45
```

CPU samples reach the surviving application frame, but optimized helper methods and their logical callers might not appear as separate frames. The trace still localizes the expensive region, but source inspection, disassembly, or a diagnostic build with inlining disabled is required to divide cost among methods that optimization removed from the physical stack.

### Follow managed code into native code

Run:

```dotnetcli
dotnet run -c Release --no-build -- native-cpu 45
```

The sample repeatedly copies native memory through the C runtime. Follow CPU stacks from the managed P/Invoke frame into `memcpy`. If the native function is unresolved, configure the [matching native symbols](dotnet-trace.md#get-symbols-for-native-runtime-frames) before assigning cost to an address.

## Diagnose allocation and garbage collection

When the initial trace shows significant GC activity, use the focused [allocation and GC configuration](dotnet-trace-collect-linux-performance.md#allocation-and-gc). Analyze it with the [memory and GC workflow](dotnet-trace-collect-linux-performance.md#4-investigate-memory-and-gc).

### Correlate allocation, GC, and CPU

Run:

```dotnetcli
dotnet run -c Release --no-build -- allocation-gc 45
```

The focused trace should identify `System.String` as the dominant allocation type and reach the sample's string-building path. Correlate allocation timestamps with collections and CPU samples rather than assuming that visible GC activity is the only source of CPU cost.

### Identify large object heap pressure

Run:

```dotnetcli
dotnet run -c Release --no-build -- loh-gc 45
```

Look for large `System.Byte[]` allocations, generation 2 collections, and large object heap data. This distinguishes a workload that allocates a modest number of large objects from one that creates a high count of small objects.

### Attribute induced collections

Run:

```dotnetcli
dotnet run -c Release --no-build -- induced-gc 45
```

Inspect GC start events for the `Induced` reason and follow the application stack to `GC.Collect`. This proves that explicit collection, rather than allocation volume alone, is causing frequent stop-the-world pauses.

### Separate managed retention from native growth

Run the managed growth scenario:

```dotnetcli
dotnet run -c Release --no-build -- managed-memory-growth 45
```

The managed heap and sampled `System.Byte[]` allocations increase together. The trace identifies where objects are allocated, but it doesn't prove why they remain reachable. Use [`dotnet-gcdump`](dotnet-gcdump.md) for heap composition or [`dotnet-dump`](dotnet-dump.md) for retention roots.

Then run:

```dotnetcli
dotnet run -c Release --no-build -- native-memory-growth 45
```

Process RSS rises while managed heap metrics remain nearly flat. That contrast rules out a managed retention problem. Switch to a native memory profiler or operating-system memory mapping data to attribute native allocations; collecting more managed allocation events won't recover that information.

## Diagnose blocking, starvation, and contention

Use the focused [blocking, contention, and ThreadPool configuration](dotnet-trace-collect-linux-performance.md#blocking-contention-and-threadpool-behavior) when an application is slow but consumes little CPU, or when runnable work appears to receive less CPU than expected.

### Find sync-over-async ThreadPool starvation

Run:

```dotnetcli
dotnet run -c Release --no-build -- sync-over-async 45
```

Look for ThreadPool worker growth, cooperative-blocking events, and worker stacks waiting in `Task` methods. Together, these signals distinguish sync-over-async starvation from an application that is merely idle while awaiting asynchronous work.

### Recognize an async causality boundary

Run:

```dotnetcli
dotnet run -c Release --no-build -- async-delay 45
```

Thread-time data proves that the operation spends most of its time waiting on timers with little CPU consumption. A physical wait stack might not preserve the logical caller that initiated an asynchronous operation. Pivot to activities, distributed tracing, or application instrumentation when the question is which request or business operation initiated the delay.

### Distinguish reader and writer contention

Run:

```dotnetcli
dotnet run -c Release --no-build -- lock-contention 45
```

Compare reader and writer lock-acquisition stacks and inspect contention duration. The trace should show writer waits while readers repeatedly hold the lock, which is more actionable than a generic conclusion that the process is blocked.

### Capture deadlock formation

Start the focused blocking collection before launching this scenario. While collection is running, use another terminal:

```dotnetcli
dotnet run -c Release --no-build -- deadlock 15
```

Starting first preserves the opposing acquisition paths as the deadlock forms. Attaching after the process is already deadlocked can't reconstruct earlier lock events. Use a process dump to prove the current owners and complete lock cycle.

### Find more than one cause

Run:

```dotnetcli
dotnet run -c Release --no-build -- cpu-and-contention 45
```

The same focused trace should retain a CPU-intensive application path and independent lock contention. Investigate each signal instead of stopping after the first plausible cause, especially when one finding doesn't explain every observed symptom.

## Diagnose file I/O

Use the focused [reads, writes, and durable flushes configuration](dotnet-trace-collect-linux-performance.md#reads-writes-and-durable-flushes) to collect syscall stacks together with thread-time data.

### Find syscall amplification

Run:

```dotnetcli
dotnet run -c Release --no-build -- tiny-writes 45
```

Filter events to `write` and follow their call stacks to the one-byte application write. A high syscall rate for little useful data identifies batching as the likely optimization. Treat trace event counts as lower bounds if collection reports or external counters indicate event loss.

### Connect synchronous I/O to unavailable workers

Run:

```dotnetcli
dotnet run -c Release --no-build -- sync-io-threadpool 45
```

Look for repeated `fsync` calls beneath ThreadPool worker file operations, then use thread-time data to see the resulting worker unavailability. This scenario requires both I/O events and scheduler context; either source alone gives an incomplete explanation.

## Diagnose exceptions

Run:

```dotnetcli
dotnet run -c Release --no-build -- swallowed-exceptions 45
```

Use the focused [first-chance exception configuration](dotnet-trace-collect-linux-performance.md#first-chance-exceptions).

Count `InvalidOperationException` events and inspect their call stacks. First-chance events reveal repeated exceptions even though the application catches them and writes no error log.

## Diagnose startup and process activity

Startup and short-lived process work can finish before you attach to the target. Start machine-wide collection first.

### Find JIT-dominated startup

Begin the focused [startup and JIT collection](dotnet-trace-collect-linux-performance.md#startup-and-jit), then run:

```dotnetcli
dotnet run -c Release --no-build -- jit-startup 15
```

Correlate early CPU samples with JIT method events and `libclrjit` stacks. The workload becomes idle after generating many methods, so attaching after startup would miss the expensive phase.

### Identify short-lived child processes

Collect the default machine-wide trace first, then run:

```dotnetcli
dotnet run -c Release --no-build -- process-churn 15
```

Process lifecycle events identify repeated `/bin/true` launches even when individual children are too short-lived to receive CPU samples. Follow the parent process stack to the process-start path.

### Prove external CPU competition

Collect the default machine-wide trace while running:

```dotnetcli
dotnet run -c Release --no-build -- cpu-competition 30
```

Compare CPU across all processes and add thread-time data in a follow-up trace if needed. External competition is supported when competing processes consume the machine during the slowdown and runnable target threads receive less CPU than expected. A process-only trace would hide the competing workers.

## Compare your conclusion with the source

After writing down the evidence and conclusion for a scenario, inspect the [sample implementation](/samples/dotnet/samples/dotnet-trace-collect-linux-performance-scenarios/). If the trace doesn't contain the relationship required to prove the cause, identify the appropriate pivot tool rather than treating the expected implementation as evidence.

## See also

- [Diagnose performance issues in .NET applications](performance-diagnostics.md)
- [Investigate Linux performance with `dotnet-trace collect-linux`](dotnet-trace-collect-linux-performance.md)
- [`dotnet-trace` reference](dotnet-trace.md)
