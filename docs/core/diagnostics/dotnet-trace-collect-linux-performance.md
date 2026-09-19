---
title: Investigate Linux performance with dotnet-trace
description: Use dotnet-trace collect-linux to investigate CPU, memory, blocking, I/O, exception, and startup performance issues.
ms.date: 09/08/2026
ms.topic: how-to
#Customer intent: As a .NET developer on Linux, I want to collect and analyze the right trace data to find the cause of a performance problem.
---

# Investigate Linux performance with `dotnet-trace collect-linux`

`dotnet-trace collect-linux` records .NET runtime events together with Linux CPU samples, native call stacks, process activity, scheduling data, and kernel events. Use it when you need to correlate what a .NET application is doing with what is happening on the rest of the Linux machine.

Start with [Diagnose performance issues in .NET applications](performance-diagnostics.md) to choose the primary workflow for the observed symptom. When that workflow calls for a Linux performance trace, this article explains how to select `collect-linux` data, move from a broad trace to a focused trace, and analyze the result. For complete command syntax and platform requirements, see the [`collect-linux` reference](dotnet-trace.md#dotnet-trace-collect-linux).

For hands-on practice choosing among the configurations in this article, use the runnable [Linux performance investigation scenarios](dotnet-trace-collect-linux-scenarios.md).

## Start with a short machine-wide trace

When the cause is unknown, begin with a short, machine-wide trace that intentionally combines only the `dotnet-common` and `cpu-sampling` profiles. `dotnet-common` provides lightweight .NET runtime context, while `cpu-sampling` provides Linux CPU samples and native call stacks. Together they can show whether CPU is consumed by the application, the runtime, native or kernel code, or another process without enabling every high-volume event source.

Machine-wide collection also preserves evidence that a process-only trace can miss:

- CPU consumed by competing processes.
- Short-lived child processes.
- Work performed before the target process can be attached.
- Application, runtime, native-library, and kernel CPU in the same time range.

The initial trace omits `thread-time` deliberately. Scheduler and context-switch events can make a machine-wide trace much larger. Add `thread-time` when blocking is already the symptom, or as a focused follow-up when the target is slow while using little CPU.

```dotnetcli
sudo dotnet-trace collect-linux --profile dotnet-common,cpu-sampling
```

Start collection shortly before reproducing the problem, capture a representative 10-30 second interval, and stop collection after the symptom occurs. Keeping the first trace short bounds collection overhead and trace size while retaining enough context to choose the next investigation step. Press <kbd>Enter</kbd> or <kbd>Ctrl</kbd>+<kbd>C</kbd> to stop interactively, or add a duration such as `--duration 00:00:00:30`. The profile in the preceding command is the default configuration, shown explicitly.

Resolve native and ReadyToRun frames as described in [Get symbols for native runtime frames](dotnet-trace.md#get-symbols-for-native-runtime-frames).

Open the trace in a current version of PerfView and filter the result to the relevant process and time range.

Use the first trace to choose a direction, and then collect only the detailed events required to answer the next question. High event rates increase trace size and collection overhead, so use a focused configuration from the start for long-running collection.

## Understand the available data

### CPU samples show what was running

CPU sampling periodically records the stack running on each CPU. Use CPU samples to determine:

- Which process consumed CPU.
- Which application method or native function used CPU.
- Whether work moved into the runtime, a native library, or the kernel.
- Whether another process competed with the target for CPU.

CPU samples don't explain time spent sleeping or waiting because a thread that isn't running can't be sampled.

### Thread-time data shows why threads weren't running

Thread-time data records scheduling and context-switch activity. It distinguishes among:

| Thread state | Interpretation |
| --- | --- |
| Running and accumulating CPU time | The thread is executing; use CPU stacks to find the expensive path. |
| Waiting in a lock, task, timer, sleep, or I/O call | The thread can't run until the operation completes. |
| Ready to run but receiving little CPU | Other runnable work is competing for CPU. |
| ThreadPool worker waiting synchronously | The worker can't process queued work and might contribute to starvation. |

PerfView can label time spent not executing as *blocked time* or *off-CPU time*. This time is summed across threads and can exceed the wall-clock duration of the trace.

### .NET runtime events describe runtime activity

Runtime events provide details that CPU samples alone don't contain:

| Runtime data | Questions it can answer |
| --- | --- |
| GC and allocation | Which types allocate? Where are they allocated? Why and how often does GC run? How long are pauses? |
| Exceptions | Which exceptions are thrown, even when caught? Which path repeatedly throws them? |
| Contention | Which lock acquisition path waits, and for how long? |
| Threading | Is the ThreadPool adding workers? Are workers blocked? |
| JIT and loader | Which methods are compiled and which assemblies load during startup? |

The `dotnet-common` profile provides useful summary events. Detailed allocation, contention, exception, and JIT analysis usually requires a focused follow-up trace.

### Linux events connect operations to callers

Linux perf events can record syscalls, process lifecycle, scheduling, and other kernel activity. Event call stacks connect an operation such as `read`, `write`, `fsync`, or `execve` to the managed or native caller that initiated it.

## Choose a focused follow-up trace

The examples show only the event configuration. Add `--duration` or `--output` when appropriate. Use `--name` or `--process-id` only when the target process is already running. To trace startup, collect machine-wide and filter to the process during analysis.

### General starting point

This is the default configuration, written explicitly:

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile dotnet-common,cpu-sampling
```

### Allocation and GC

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile gc-verbose,cpu-sampling
```

### Blocking, contention, and ThreadPool behavior

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile thread-time,cpu-sampling \
  --clrevents threading+contention+waithandle \
  --clreventlevel Verbose
```

### First-chance exceptions

This configuration includes exceptions that application code catches:

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile cpu-sampling \
  --clrevents exception \
  --clreventlevel Verbose
```

### Reads, writes, and durable flushes

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile thread-time,cpu-sampling \
  --perf-events "syscalls:sys_enter_read,syscalls:sys_exit_read,syscalls:sys_enter_write,syscalls:sys_exit_write,syscalls:sys_enter_fsync,syscalls:sys_exit_fsync"
```

### Startup and JIT

Begin collection before launching the application:

```dotnetcli
sudo dotnet-trace collect-linux \
  --profile cpu-sampling \
  --clrevents assemblyloader+loader+jit+threading \
  --clreventlevel Verbose
```

Profiles are presets, and presets for different data sources can be combined. For example, `cpu-sampling` and `thread-time` configure Linux collection while `--clrevents` configures the .NET runtime provider.

Configurations don't merge when `--providers`, `--profile`, and `--clrevents` configure the same .NET provider. The precedence is:

1. An explicit `--providers` entry.
1. The first selected profile that configures the provider.
1. `--clrevents`, only when nothing earlier configured `Microsoft-Windows-DotNETRuntime`.

For example, if `dotnet-common` or `gc-verbose` configures the runtime provider, the tool prints a warning and ignores a supplied `--clrevents` list. Use kernel-only profiles such as `cpu-sampling` or `thread-time` with a focused `--clrevents`/`--clreventlevel` configuration.

## Analyze the trace

### 1. Select the symptom interval

Open the trace in [PerfView](https://github.com/microsoft/perfview) and select the time interval in which the slowdown, memory growth, pause, or startup delay occurred. Analysis outside that interval can hide a short problem beneath otherwise normal behavior.

### 2. Examine the whole machine

Open **CPU Stacks** and compare processes:

- Does the target own most CPU samples?
- Are other processes using the CPUs at the same time?
- Did many child processes appear?
- Is CPU spread across many threads or concentrated in one?

Another process having many samples doesn't by itself prove that it slowed the target. External CPU competition becomes a supported explanation when its CPU use overlaps the slowdown, the machine is close to saturation, and runnable target threads receive less CPU than expected. A thread-time trace can confirm the last condition.

### 3. Follow the target's CPU stacks

Filter to the target process. Begin with methods that have high *exclusive* cost, where samples occurred directly in the method. Then inspect their *inclusive* callers until the stack reaches application code.

If native frames remain unresolved, configure the [matching native symbols](dotnet-trace.md#get-symbols-for-native-runtime-frames) before relying on method names in those frames.

Common directions include:

- One application method dominates: investigate that algorithm or call site.
- GC methods dominate: inspect GC and allocation data.
- Exception helpers dominate: inspect exception events.
- Lock slow paths appear: inspect contention and thread-time data.
- Filesystem, socket, or syscall frames appear: inspect Linux events.
- `libclrjit` dominates early in the trace: inspect JIT and loader events.

Inlining can remove small logical methods from physical stacks. Use source, disassembly, or a diagnostic no-inline build when samples reach only a broad surviving caller.

### 4. Investigate memory and GC

Use these PerfView views:

1. **GCStats** to review collection generation, reason, frequency, pause time, promoted data, and heap size.
1. **GC Heap Alloc Ignore Free (Coarse Sampling)** to find dominant allocation types and their application callers.
1. **Events** filtered to `GC/AllocationTick`, `GC/Start`, and `GC/Stop` for exact timing and payload fields.

Allocation traces show where objects are created, not why they remain alive. Use [`dotnet-gcdump`](dotnet-gcdump.md) or a [process dump](dotnet-dump.md) for retention roots. If process RSS grows while the managed heap remains flat, inspect native allocations and operating-system memory mappings.

### 5. Investigate low-CPU latency

Open thread-time stacks for the target and compare CPU time with blocked time. Look for:

- Monitor, reader/writer lock, task wait, sleep, futex, timer, and I/O frames.
- ThreadPool worker starts, adjustments, and cooperative-blocking events.
- The application callback immediately above a wait.
- Runnable target threads receiving little CPU while other processes execute.

Contention events can identify a waiting lock path and duration without showing what the owner was doing. Use a process dump to prove an existing deadlock and its lock-ownership cycle.

Async work can resume on another thread, so a physical wait stack doesn't always preserve the logical initiating caller. Use activities, distributed tracing, or application instrumentation when that relationship is required.

### 6. Investigate I/O

Filter events to the relevant syscall and open its stacks. Follow `read`, `write`, `fsync`, or a socket operation back to application code. Thread-time data shows whether the operation blocked threads or occupied ThreadPool workers.

Add block-device events only when the remaining question is storage-device latency. They are machine-wide and can be noisy. They aren't required when syscall stacks already identify an application issuing excessive small operations or forced flushes.

### 7. Investigate exceptions and startup

For exceptions, count first-chance events and inspect their stacks. A repeated throw site can reduce throughput even when every exception is caught and no error is logged.

For startup, begin collection before launching the application. Correlate early CPU activity with:

- JIT method events and `libclrjit` stacks.
- Assembly and module loading.
- Static initialization.
- File operations and process launches.

Short-lived child processes can appear in process lifecycle events even when they don't run long enough to receive a CPU sample.

## Know when to use another artifact

See [Choose a different artifact when a performance trace can't answer the question](performance-diagnostics.md#choose-a-different-artifact-when-a-performance-trace-cant-answer-the-question) for artifact-selection guidance. In particular, use a native memory profiler for native allocation ownership, Linux `perf` for hardware performance counters, and source or disassembly when optimization removed a logical method from the physical call stack.

## Manage collection overhead

Trace overhead depends on event rate, enabled providers, stack capture, CPU count, and workload behavior. High-volume traces can lose events or perturb the application being measured.

- Keep the initial trace short.
- Enable only the detailed events needed for the current question.
- Treat event totals as lower bounds when they disagree with application or operating-system counters.
- Repeat the capture with a narrower configuration when exact counts matter.
- Test production collection procedures and container limits before an incident.

## See also

- [Diagnose performance issues in .NET applications](performance-diagnostics.md)
- [Practice Linux performance investigations](dotnet-trace-collect-linux-scenarios.md)
- [`dotnet-trace` reference](dotnet-trace.md)
- [Debug high CPU usage](debug-highcpu.md)
- [Collect diagnostics in Linux containers](diagnostics-in-containers.md)
