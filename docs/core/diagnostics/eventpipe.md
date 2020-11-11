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

EventPipe can be thought of as an aggregation buffer for the runtime when various components of the runtime (for example, the Just-In-Time compiler or the garbage collector) emits events or when events are written from [EventSource](xref:System.Diagnostics.Tracing.EventSource) instances.

The events are then serialized and can be written directly to a file or through a diagnostics port that the runtime creates. On Windows, this port is implemented as a `NamedPipe` while on non-Windows platforms such as Linux or macOS it is implemented as a Unix Domain Socket.

## Decide whether you should use EventPipe or ETW/LTTng

EventPipe is part of the .NET Core runtime (CoreCLR) and is designed to work the same way across all the platforms .NET Core supports. This allows tools based on EventPipe such as `dotnet-counters`, `dotnet-gcdump` and `dotnet-trace` to work cross platform seemlessly. However, because it is a runtime built-in component, its scope is limited to managed code and the runtime itself only, and cannot be used for tracking some lower level events such as resolving native code stack or getting various kernel events. If you use C/C++ interop or want to trace the runtime itself (which is written in C/C++), you should use ETW or LTTng. You can learn about using PerfCollect to do this [here]().

The table below is a summary of the differences between EventPipe and ETW/LTTng.

----------------------

## Use EventPipe to trace your .NET application

You can use EventPipe to trace your .NET application in many ways:

* Use one of the [diagnostics tools](#tools-using-eventpipe) that are built on top of EventPipe. 

* Use [Microsoft.Diagnostics.NETCore.Client](https://github.com/dotnet/diagnostics/blob/master/documentation/diagnostics-client-library-instructions.md) library lets you interact with the .NET runtime to start an EventPipe session yourself.

After you've produced a `nettrace` file that contains your EventPipe events, this can be viewed in [`PerfView`](https://github.com/Microsoft/perfview#perfview-overview) or Visual Studio.

You can also analyze EventPipe traces programmatically with [TraceEvent](https://github.com/Microsoft/perfview/blob/master/documentation/TraceEvent/TraceEventLibrary.md).

### Tools using EventPipe
As a .NET developer, you can use EventPipe to trace your application by using one of the diagnostics CLI tools that use EventPipe, or write your own tool by using the `Microsoft.Diagnostics.NETCore.Client` library.

* [dotnet-counters](./dotnet-counters.md) lets you monitor/collect various metrics emitted by the .NET runtime and core libraries, as well as custom metrics you can write.

* [dotnet-gcdump](./dotnet-gcdump.md) lets you collect GC heap dump of applications for analyzing your application's managed heap.

* [dotnet-trace](./dotnet-trace.md) lets you collect traces of applications to analyze for performance.

* [Microsoft.Diagnostics.NETCore.Client] session.

## Configure EventPipe

EventPipe can be configured to best-suit the performance needs of your environment. 