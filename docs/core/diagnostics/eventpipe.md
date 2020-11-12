---
title: EventPipe Overview
description: Learn about EventPipe and how to use it for tracing your .NET applications to diagnose performance issues.
ms.date: 11/09/2020
ms.topic: overview
---

# EventPipe

EventPipe is a runtime (CoreCLR) component that can be used as one of tracing egression points, similar to ETW or LTTng. The goal of EventPipe is to allow .NET developers to easily trace their .NET applications without having to rely on OS-native components such as ETW or LTTng.

EventPipe is the mechanism behind many of the diagnostic tools and can be used for consuming events emitted by the runtime as well as custom events written by [EventSource](xref:System.Diagnostics.Tracing.EventSource).

This article is a high-level overview on EventPipe describing when to use EventPipe, how to use it to trace your applications, and how to configure it to best suit your needs.

## EventPipe Basics

At a high level, EventPipe can be thought of as an aggregation mechanism for the runtime when various components of the runtime (for example, the Just-In-Time compiler or the garbage collector) emits events or when events are written from [EventSource](xref:System.Diagnostics.Tracing.EventSource) instances.

The events are then serialized and can be written either directly to a file or through a diagnostics port that the runtime creates. On Windows, this port is implemented as a `NamedPipe` while on non-Windows platforms such as Linux or macOS it is implemented as a Unix Domain Socket. You can read more about the diagnostics port and how to interact with it via its custom inter-process communication protocol on the [diagnostics IPC protocol documentation](https://github.com/dotnet/diagnostics/blob/master/documentation/design-docs/ipc-protocol.md).

EventPipe will then produce a trace file with `.nettrace` extension. To learn more about EventPipe serialization format, refer to the [EventPipe format documentation](https://github.com/microsoft/perfview/blob/master/src/TraceEvent/EventPipe/EventPipeFormat.md).

## Decide whether you should use EventPipe or ETW/LTTng

EventPipe is part of the .NET runtime (CoreCLR) and is designed to work the same way across all the platforms .NET Core supports. This allows tracing tools based on EventPipe such as `dotnet-counters`, `dotnet-gcdump` and `dotnet-trace` to work cross platform seemlessly.

However, because EventPipe is a runtime built-in component, its scope is limited to managed code and the runtime itself only, and cannot be used for tracking some lower level events such as resolving native code stack or getting various kernel events. If you use C/C++ interop in your app or you want to trace the runtime itself (which is written in C++), or want deeper diagnostics into the behavior of the app that requires kernel events (i.e. native thread context switching events) you should use ETW or [perf/LTTng](./trace-perfcollect-lttng.md).

The table below is a summary of the differences between EventPipe and ETW/LTTng.

## Use EventPipe to trace your .NET application

You can use EventPipe to trace your .NET application in many ways:

* Use one of the [diagnostics tools](#tools-using-eventpipe) that are built on top of EventPipe.

* Use [Microsoft.Diagnostics.NETCore.Client](https://github.com/dotnet/diagnostics/blob/master/documentation/diagnostics-client-library-instructions.md) library to write your own tool to configure and start EventPipe sessions yourself.

* Use [environment variables](#trace-using-environment-variables) to start EventPipe.

After you've produced a `nettrace` file that contains your EventPipe events, this can be viewed in [`PerfView`](https://github.com/Microsoft/perfview#perfview-overview) or Visual Studio.

You can also analyze EventPipe traces programmatically with [TraceEvent](https://github.com/Microsoft/perfview/blob/master/documentation/TraceEvent/TraceEventLibrary.md).

### Tools using EventPipe

This is the easiest way to use EventPipe to trace your application. To learn more about how to use each of these tools, refer to each tools' documentation.

* [dotnet-counters](./dotnet-counters.md) lets you monitor/collect various metrics emitted by the .NET runtime and core libraries, as well as custom metrics you can write.

* [dotnet-gcdump](./dotnet-gcdump.md) lets you collect GC heap dump of applications for analyzing your application's managed heap.

* [dotnet-trace](./dotnet-trace.md) lets you collect traces of applications to analyze for performance.

## Trace using environment variables

The preferred mechanism for using EventPipe is to use `dotnet-trace` or `Microsoft.Diagnostics.NETCore.Client` library.

However, you can use the following environment variables to set up an EventPipe session on an app and have it write the trace directly to a file. To stop tracing, you need to exit the application.

* `COMPlus_EnableEventPipe`: Setting this to `1` starts an EventPipe session that writes directly to a file. By default this is `0`.

* `COMPlus_EventPipeOutputPath`: This is the path to the output EventPipe trace file when it is configured to run via `COMPlus_EnableEventPipe`. By default this is `trace.nettrace` which will be created in the same directory the app that is running from.

* `COMPlus_CircularBufferMB`: This is the size of the internal buffer size that is used by EventPipe when it is configured to run via `COMPlus_EnableEventPipe`.

* `COMPlus_EventPipeConfig`: This environment variable can be used to set up the EventPipe session configuration when setting up an EventPipe session with `COMPlus_EnableEventPipe`.

The syntax is as following:

* `<provider>:<keyword>:<level>`

You can also specify multiple providers by concatenating them with comma:

* `<provider1>:<keyword1>:<level1>,<provider2>:<keyword2>:<level2>`

If this environment variable is not set but EventPipe is enabled by COMPlus_EnableEventPipe, it will start tracing by enabling the following providers with the following keywords and level:

1. `Microsoft-Windows-DotNETRuntime:4c14fccbd:5`
2. `Microsoft-Windows-DotNETRuntimePrivate:4002000b:5`
3. `Microsoft-DotNETCore-SampleProfiler:0:5`
