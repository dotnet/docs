---
title: EventPipe Overview
description: Learn about EventPipe and how to use it for tracing your .NET applications to diagnose performance issues.
ms.date: 11/09/2020
ms.topic: overview
---

# EventPipe

EventPipe is a runtime component that can be used to collect tracing data, similar to ETW or LTTng. The goal of EventPipe is to allow .NET developers to easily trace their .NET applications without having to rely on platform-specific OS-native components such as ETW or LTTng.

EventPipe is the mechanism behind many of the diagnostic tools and can be used for consuming events emitted by the runtime as well as custom events written with [EventSource](xref:System.Diagnostics.Tracing.EventSource).

This article is a high-level overview of EventPipe. It describes when and how to use EventPipe, and how to configure it to best suit your needs.

## EventPipe basics

EventPipe aggregates events emitted by runtime components - for example, the Just-In-Time compiler or the garbage collector - and events written from [EventSource](xref:System.Diagnostics.Tracing.EventSource) instances in the libraries and user code.

The events are then serialized and can be written directly to a file or consumed through a Diagnostics Port from out-of-proces. On Windows, Diagnostic Ports are implemented as `NamedPipe`s. On non-Windows platforms, such as Linux or macOS, it is implemented using Unix Domain Sockets. For more information about the Diagnostics Port and how to interact with it via its custom inter-process communication protocol, see the [diagnostics IPC protocol documentation](https://github.com/dotnet/diagnostics/blob/main/documentation/design-docs/ipc-protocol.md).

EventPipe then writes the serialized events in the `.nettrace` file format, either as a stream via Diagnostic Ports or directly to a file. To learn more about the EventPipe serialization format, refer to the [EventPipe format documentation](https://github.com/microsoft/perfview/blob/main/src/TraceEvent/EventPipe/EventPipeFormat.md).

## EventPipe vs. ETW/LTTng

EventPipe is part of the .NET runtime (CoreCLR) and is designed to work the same way across all the platforms .NET Core supports. This allows tracing tools based on EventPipe, such as `dotnet-counters`, `dotnet-gcdump`, and `dotnet-trace`, to work seamlessly across platforms.

However, because EventPipe is a runtime built-in component, its scope is limited to managed code and the runtime itself. EventPipe cannot be used for tracking some lower-level events, such as resolving native code stack or getting various kernel events. If you use C/C++ interop in your app or you want to trace the runtime itself (which is written in C++), or want deeper diagnostics into the behavior of the app that requires kernel events (that is, native-thread context-switching events) you should use ETW or [perf/LTTng](./trace-perfcollect-lttng.md).

Another major difference between EventPipe and ETW/LTTng is admin/root privilege requirement. To trace an application using ETW or LTTng you need to be an admin/root. Using EventPipe, you can trace applications as long as the tracer (for example, `dotnet-trace`) is run as the same user as the user that launched the application.

The following table is a summary of the differences between EventPipe and ETW/LTTng.

|Feature|EventPipe|ETW|LTTng|
|-------|---------|---|-----------|
|Cross-platform|Yes|No (only on Windows)|No (only on supported Linux distros)|
|Require admin/root privilege|No|Yes|Yes|
|Can get OS/kernel events|No|Yes|Yes|
|Can resolve native callstacks|No|Yes|Yes|

## Use EventPipe to trace your .NET application

You can use EventPipe to trace your .NET application in many ways:

* Use one of the [diagnostics tools](#tools-that-use-eventpipe) that are built on top of EventPipe.

* Use [Microsoft.Diagnostics.NETCore.Client](diagnostics-client-library.md) library to write your own tool to configure and start EventPipe sessions.

* Use [environment variables](#trace-using-environment-variables) to start EventPipe.

After you've produced a `nettrace` file that contains your EventPipe events, you can view the file in [PerfView](https://github.com/Microsoft/perfview#perfview-overview) or Visual Studio. On non-Windows platforms, you can convert the `nettrace` file to a `speedscope` or `Chromium` trace format by using [dotnet-trace convert](./dotnet-trace.md#dotnet-trace-convert) command and view it with [speedscope](https://www.speedscope.app/) or Chrome DevTools.

You can also analyze EventPipe traces programmatically with [TraceEvent](https://github.com/Microsoft/perfview/blob/main/documentation/TraceEvent/TraceEventLibrary.md).

### Tools that use EventPipe

This is the easiest way to use EventPipe to trace your application. To learn more about how to use each of these tools, refer to each tool's documentation.

* [dotnet-counters](./dotnet-counters.md) lets you monitor and collect various metrics emitted by the .NET runtime and core libraries, as well as custom metrics you can write.

* [dotnet-gcdump](./dotnet-gcdump.md) lets you collect GC heap dumps of live processes for analyzing an application's managed heap.

* [dotnet-trace](./dotnet-trace.md) lets you collect traces of applications to analyze for performance.

## Trace using environment variables

The preferred mechanism for using EventPipe is to use [dotnet-trace](dotnet-trace.md) or the [Microsoft.Diagnostics.NETCore.Client](diagnostics-client-library.md) library.

However, you can use the following environment variables to set up an EventPipe session on an app and have it write the trace directly to a file. To stop tracing, exit the application.

* `DOTNET_EnableEventPipe`: Set this to `1` to start an EventPipe session that writes directly to a file. The default value is `0`.

* `DOTNET_EventPipeOutputPath`: The path to the output EventPipe trace file when it's configured to run via `DOTNET_EnableEventPipe`. The default value is `trace.nettrace`, which will be created in the same directory that the app is running from.

  > [!NOTE]
  > Since .NET 6, instances of the string `{pid}` in `DOTNET_EventPipeOutputPath` are replaced with the process id of the process being traced.

* `DOTNET_EventPipeCircularMB`: A hexadecimal value that represents the size of EventPipe's internal buffer in megabytes. This configuration value is only used when EventPipe is configured to run via `DOTNET_EnableEventPipe`. The default buffer size is 1024MB which translates to this environment variable being set to `400`, since `0x400` == `1024`.

  > [!NOTE]
  > If the target process writes events too frequently, it can overflow this buffer and some events might be dropped. If too many events are getting dropped, increase the buffer size to see if the number of dropped events reduces. If the number of dropped events does not decrease with a larger buffer size, it may be due to a slow reader preventing the target process' buffers from being flushed.

* `DOTNET_EventPipeProcNumbers`: Set this to `1` to enable capturing processor numbers in EventPipe event headers. The default value is `0`.

* `DOTNET_EventPipeConfig`: Sets up the EventPipe session configuration when starting an EventPipe session with `DOTNET_EnableEventPipe`.
  The syntax is as follows:

  `<provider>:<keyword>:<level>`

  You can also specify multiple providers by concatenating them with a comma:

  `<provider1>:<keyword1>:<level1>,<provider2>:<keyword2>:<level2>`

  If this environment variable is not set but EventPipe is enabled by `DOTNET_EnableEventPipe`, it will start tracing by enabling the following providers with the following keywords and levels:

  - `Microsoft-Windows-DotNETRuntime:4c14fccbd:5`
  - `Microsoft-Windows-DotNETRuntimePrivate:4002000b:5`
  - `Microsoft-DotNETCore-SampleProfiler:0:5`

  To learn more about some of the well-known providers in .NET, refer to [Well-known Event Providers](./well-known-event-providers.md).

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]
