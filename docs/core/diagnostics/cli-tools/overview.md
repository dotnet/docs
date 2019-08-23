---
title: Diagnostic dotnet tools overview - .NET Core
description: An overview of the dotnet global command-line tools available to diagnose .NET Core applications.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/21/2019
ms.topic: overview
#Customer intent: As a .NET Core developer I want to diagnose problems so that I can be productive.
---
# .NET Core dotnet diagnostic global command-line tools

## dotnet-counters

[dotnet-counters](dotnet-counters.md) is a performance monitoring tool for ad-hoc health monitoring or first-level performance investigation. It can observe performance counter values that are published via the `EventCounter` [API](https://docs.microsoft.com/dotnet/api/system.diagnostics.tracing.eventcounter). For example, you can quickly monitor things like the CPU usage or the rate of exceptions being thrown in your .NET Core application.

### dotnet-dump

The [dotnet-dump](dotnet-dump.md) tool is a way to collect and analyze Windows and Linux core dumps all without any native debugger.

### dotnet-trace

.NET Core includes what is called the `EventPipe` through which diagnostics data is exposed. The [dotnet-trace](dotnet-trace.md) tool allows you to consume interesting profiling data from your app that can help in scenarios where you need to root cause apps running slow.
