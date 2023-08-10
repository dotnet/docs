---
title: Diagnostics tools overview - .NET Core
description: An overview of the tools and techniques available to diagnose .NET Core applications.
ms.date: 07/16/2020
ms.topic: overview
#Customer intent: As a .NET Core developer I want to find the best tools to help me diagnose problems so that I can be productive.
---
# What diagnostic tools are available in .NET Core?

Software doesn't always behave as you would expect, but .NET Core has tools and APIs that will help you diagnose these issues quickly and effectively.

[Native AOT deployment](../../core/deploying/native-aot/index.md) is a relatively new application model that has been available since .NET 7 and details on .NET 8 diagnostic support for native AOT applications can be found [here](../../core/deploying/native-aot/diagnostics.md).

This article helps you find the various tools you need.

## Debuggers

[Debuggers](managed-debuggers.md) allow you to interact with your program. Pausing, incrementally executing, examining,  and resuming gives you insight into the behavior of your code. A debugger is a good choice for diagnosing functional problems that can be easily reproduced.

## Unit testing

[Unit testing](../testing/index.md) is a key component of continuous integration and deployment of high-quality software. Unit tests are designed to give you an early warning when you break something.

## Instrumentation for observability

.NET supports industry standard instrumentation techniques using metrics, logs, and distributed traces, commonly known as the *three pillars of observability*.

Instrumentation is code that is added to a software project to record what it is doing. This information can then be collected in files, databases, or in-memory and analyzed to understand how a software program is operating. This is often used in production environments to monitor for problems and diagnose them. The .NET runtime has built-in instrumentation that can be optionally enabled and APIs that allow you to add custom instrumentation specialized for your application.

### Logs

[Logging](logging-tracing.md) is a technique where code is instrumented to produce a log, a record of interesting events that occurred while the program was running. Often a baseline set of log events are configured on by default and more extensive logging can be enabled on-demand to diagnose particular problems. Performance overhead is variable depending on how much data is being logged.

For most cases, whether adding logging to an existing project or creating a new project, the [ILogger infrastructure](../extensions/logging.md) is a good default choice. `ILogger` supports fast structured logging, flexible configuration, and a collection of [common sinks](../extensions/logging-providers.md#built-in-logging-providers) including the console, which is what you see when running an ASP.NET app. Additionally, the `ILogger` interface can also serve as a facade over many [third party logging implementations](../extensions/logging-providers.md#third-party-logging-providers) that offer rich functionality and extensibility.

### Metrics

[Metrics](metrics.md) are numerical measurements recorded over time to monitor application performance and health. Metrics are often used to generate alerts when potential problems are detected. Metrics have very low performance overhead and many services configure them as always-on telemetry.

### Distributed traces

[Distributed Tracing](./distributed-tracing.md) is a specialized form of logging that helps you localize failures and performance issues within applications distributed across multiple machines or processes. This technique tracks requests through an application correlating together work done by different application components and separating it from other work the application may be doing for concurrent requests. It is possible to trace every request and sampling can be optionally employed to bound the performance overhead.

### Collect instrumentation

There are multiple ways that the instrumentation data can be egressed from the application, including:

- [Open Telemetry](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/docs/trace/getting-started-console/README.md) - a cross-platform, vendor-neutral standard for collecting and exporting telemetry
- [.NET CLI tools](./tools-overview.md) such as [dotnet-counters](./dotnet-counters.md)
- [dotnet-monitor](./dotnet-monitor.md) - an agent for collecting traces and telemetry
- Third-party libraries or app code can read the information from the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType>, <xref:Microsoft.Extensions.Logging.ILogger%601>, and <xref:System.Diagnostics.Activity?displayProperty=nameWithType> APIs.

## Specialized diagnostics

If debugging or observability is not sufficient, .NET supports additional diagnostic mechanisms such as EventSource, Dumps, DiagnosticSource. For more information, see the [specialized diagnostics](./specialized-diagnostics-overview.md) article.

## Diagnostics tools

.NET supports a number of [CLI tools](./tools-overview.md) that can be used to diagnose your applications.

## .NET Core diagnostics tutorials

### Write your own diagnostic tool

[The diagnostics client library](diagnostics-client-library.md) lets you write your own custom diagnostic tool best suited for your diagnostic scenario. Look up information in the [Microsoft.Diagnostics.NETCore.Client API reference](microsoft-diagnostics-netcore-client.md).

### Debug a memory leak

[Tutorial: Debug a memory leak](debug-memory-leak.md) walks through finding a memory leak. The [dotnet-counters](dotnet-counters.md) tool is used to confirm the leak and the [dotnet-dump](dotnet-dump.md) tool is used to diagnose the leak.

### Debug high CPU usage

[Tutorial: Debug high CPU usage](debug-highcpu.md) walks you through investigating high CPU usage. It uses the [dotnet-counters](dotnet-counters.md) tool to confirm the high CPU usage. It then walks you through using [Trace for performance analysis utility (`dotnet-trace`)](dotnet-trace.md) or Linux `perf` to collect and view CPU usage profile.

### Debug deadlock

[Tutorial: Debug deadlock](debug-deadlock.md) shows you how to use the [dotnet-dump](dotnet-dump.md) tool to investigate threads and locks.

### Debug ThreadPool Starvation

[Tutorial: Debug threadPool starvation](debug-threadpool-starvation.md) shows you how to use the [dotnet-counters](dotnet-counters.md) and [dotnet-stack](dotnet-stack.md) tools to investigate ThreadPool starvation.

### Debug a StackOverflow

[Tutorial: Debug a StackOverflow](debug-stackoverflow.md) demonstrates how to debug a <xref:System.StackOverflowException> on Linux.

### Debug Linux dumps

[Debug Linux dumps](debug-linux-dumps.md) explains how to collect and analyze dumps on Linux.

### Measure performance using EventCounters

[Tutorial: Measure performance using EventCounters in .NET](event-counter-perf.md) shows you how to use the <xref:System.Diagnostics.Tracing.EventCounter> API to measure performance in your .NET app.
