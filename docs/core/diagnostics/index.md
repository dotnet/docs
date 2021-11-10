---
title: Diagnostics tools overview - .NET Core
description: An overview of the tools and techniques available to diagnose .NET Core applications.
ms.date: 07/16/2020
ms.topic: overview
#Customer intent: As a .NET Core developer I want to find the best tools to help me diagnose problems so that I can be productive.
---
# What diagnostic tools are available in .NET Core?

Software doesn't always behave as you would expect, but .NET Core has tools and APIs that will help you diagnose these issues quickly and effectively.

This article helps you find the various tools you need.

## Managed debuggers

[Managed debuggers](managed-debuggers.md) allow you to interact with your program. Pausing, incrementally executing, examining,  and resuming gives you insight into the behavior of your code. A debugger is the first choice for diagnosing functional problems that can be easily reproduced.

## Logging and tracing

[Logging and tracing](logging-tracing.md) are related techniques. They refer to instrumenting code to create log files. The files record the details of what a program does. These details can be used to diagnose the most complex problems. When combined with time stamps, these techniques are also valuable in performance investigations.

## Metrics

[Metrics](metrics.md) are numerical measurements recorded over time to monitor application performance and health. Metrics are often used to
generate alerts when potential problems are detected. In normal use, metrics have very low performance overhead and are configured as
'always-on' telemetry. The .NET runtime and libraries publish many built-in metrics, and you can create new ones using metric APIs.

## Unit testing

[Unit testing](../testing/index.md) is a key component of continuous integration and deployment of high-quality software. Unit tests are designed to give you an early warning when you break something.

## Dumps

A [dump](./dumps.md) is a file that contains a snapshot of the process at the time of creation. These can be useful for examining the state of your application for debugging purposes.

## Symbols

[Symbols](./symbols.md) are a mapping between the source code and the binary produced by the compiler. These are commonly used by .NET debuggers to resolve source line numbers, local variable names, and other types of diagnostic information.

## Collect diagnostics in containers

The same diagnostics tools that are used in non-containerized Linux environments can also be used to [collect diagnostics in containers](diagnostics-in-containers.md). There are just a few usage changes needed to make sure the tools work in a Docker container.

## .NET Core diagnostic global tools

### dotnet-counters

[dotnet-counters](dotnet-counters.md) is a performance monitoring tool for first-level health monitoring and performance investigation. It observes performance counter values published via the <xref:System.Diagnostics.Tracing.EventCounter> API. For example, you can quickly monitor things like the CPU usage or the rate of exceptions being thrown in your .NET Core application.

### dotnet-dump

The [dotnet-dump](dotnet-dump.md) tool is a way to collect and analyze Windows and Linux core dumps without a native debugger.

### dotnet-gcdump

The [dotnet-gcdump](dotnet-gcdump.md) tool is a way to collect GC (Garbage Collector) dumps of live .NET processes.

### dotnet-trace

.NET Core includes what is called the `EventPipe` through which diagnostics data is exposed. The [dotnet-trace](dotnet-trace.md) tool allows you to consume interesting profiling data from your app that can help in scenarios where you need to root cause apps running slow.

### dotnet-stack

The [dotnet-stack](dotnet-stack.md) tool allows you quickly print the managed stacks for all threads in a running .NET process.

### dotnet-symbol

[dotnet-symbol](dotnet-symbol.md) downloads files (symbols, DAC/DBI, host files, etc.) needed to open a core dump or minidump. Use this tool if you need symbols and modules to debug a dump file captured on a different machine.

### dotnet-sos

[dotnet-sos](dotnet-sos.md) installs the [SOS debugging extension](sos-debugging-extension.md) on Linux and macOS (and on Windows if you're using [Windbg/cdb](/windows-hardware/drivers/debugger/debugger-download-tools)).

### PerfCollect

[PerfCollect](trace-perfcollect-lttng.md) is a bash script you can use to collect traces with `perf` and `LTTng` for a more in-depth performance analysis of .NET apps running on Linux distributions.

## .NET Core diagnostics tutorials

### Write your own diagnostic tool

[The diagnostics client library](diagnostics-client-library.md) lets you write your own custom diagnostic tool best suited for your diagnostic scenario. Look up information in the [Microsoft.Diagnostics.NETCore.Client API reference](microsoft-diagnostics-netcore-client.md).

### Debug a memory leak

[Tutorial: Debug a memory leak](debug-memory-leak.md) walks through finding a memory leak. The [dotnet-counters](dotnet-counters.md) tool is used to confirm the leak and the [dotnet-dump](dotnet-dump.md) tool is used to diagnose the leak.

### Debug high CPU usage

[Tutorial: Debug high CPU usage](debug-highcpu.md) walks you through investigating high CPU usage. It uses the [dotnet-counters](dotnet-counters.md) tool to confirm the high CPU usage. It then walks you through using [Trace for performance analysis utility (`dotnet-trace`)](dotnet-trace.md) or Linux `perf` to collect and view CPU usage profile.

### Debug deadlock

[Tutorial: Debug deadlock](debug-deadlock.md) shows you how to use the [dotnet-dump](dotnet-dump.md) tool to investigate threads and locks.

### Debug a StackOverflow

[Tutorial: Debug a StackOverflow](debug-stackoverflow.md) demonstrates how to debug a <xref:System.StackOverflowException> on Linux.

### Debug Linux dumps

[Debug Linux dumps](debug-linux-dumps.md) explains how to collect and analyze dumps on Linux.

### Measure performance using EventCounters

[Tutorial: Measure performance using EventCounters in .NET](event-counter-perf.md) shows you how to use the <xref:System.Diagnostics.Tracing.EventCounter> API to measure performance in your .NET app.
