---
title: EventPipe Overview
description: Learn about EventPipe and how to use it for tracing your .NET applications to diagnose performance issues.
ms.date: 11/09/2020
ms.topic: overview
#Customer intent: As a .NET Core developer I want to find the best tools to help me diagnose problems so that I can be productive.
---

# EventPipe

EventPipe is a runtime (CoreCLR) component that can be used as one of tracing egression points, similar to ETW or LTTng. The goal of EventPipe is to allow .NET developers to easily trace their .NET applications without having to rely on OS-native components such as ETW or LTTng. 

EventPipe is the mechanism behind many of the diagnostic tools and can be used for consuming events emitted by the runtime as well as custom events written by [EventSource](xref:System.Diagnostics.Tracing.EventSource).

This article describes when to use EventPipe, how to use it to trace your applications, and how to configure it to best suit your needs.

## EventPipe vs ETW/LTTng

EventPipe is part of the .NET Core runtime (CoreCLR) and is designed to work the same way across all the platforms .NET Core supports. This allows tools based on EventPipe such as `dotnet-counters`, `dotnet-gcdump` and `dotnet-trace` to work cross-platform seemlessly. However, because it is a runtime built-in component, it cannot be used for tracking some lower-level events such as resolving native code stack or getting various kernel events.

The table below compares EventPipe to ETW/LTTng, which are the platform-native egression mechanisms supported by the .NET runtime.

----------------------

## Using EventPipe

As a .NET developer, you can use EventPipe to trace your application by using one of the diagnostics CLI tools that use EventPipe, or write your own tool by using the `Microsoft.Diagnostics.NETCore.Client` library.

* [dotnet-counters](./dotnet-counters.md) lets you monitor/collect various metrics emitted by the .NET runtime and core libraries, as well as custom metrics you can write.

* [dotnet-gcdump](./dotnet-gcdump.md) lets you collect GC heap dump of applications for analyzing your application's managed heap.

* [dotnet-trace](./dotnet-trace.md) lets you collect traces of applications to analyze for performance.

* [Microsoft.Diagnostics.NETCore.Client](https://github.com/dotnet/diagnostics/blob/master/documentation/diagnostics-client-library-instructions.md) library lets you interact with the .NET runtime to start an EventPipe session.

## Configuring EventPipe

EventPipe can be configured to best-suit the performance needs of your environment. 