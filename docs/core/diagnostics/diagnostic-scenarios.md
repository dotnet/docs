---
title: Diagnostics walk-throughs - .NET Core
description:
author: sdmaclea
ms.author: stmaclea
ms.date: 08/27/2019
ms.topic: overview
#Customer intent: As a .NET Core developer I want to find the best tutorial to help me debug my scenario.
---
# .NET Core diagnostics walk throughs

.NET Core has a wide range of diagnostics capabilities. To learn more about production diagnostics in .NET Core 3, we'll run through a set of diagnostics scenarios using the `dotnet` tools.

> [!NOTE]
> The walk-throughs were all run on Ubuntu 16.04 and using the .NET Core 3 preview 5 bits.
>
> The tools/APIs that are used are based on preview 5 and are subject to change. The tutorial will be updated to account for later previews and final release
>
> Please note that you have to be using at least preview 5 for most of the capabilities to work.

## Production diagnostics

Before we jump in, let's take a look at production diagnostic methodology. When an outage occurs, the goal is getting services fully restored quickly. This goal often means restarting the app or node(s).

To improve service reliability, root cause analysis of failures is key. To get to root cause, we need to collect as much diagnostics data as we can **before** restarting.

The diagnostics data collected can then be analyzed postmortem to determine root cause and possible fixes.

## Preparing

Each of the scenarios:

- Uses the [Sample debug target](sample-debug-target.md) to trigger the scenario.
- Uses the [.NET Core dotnet diagnostic global command-line tools](index.md#net-core-dotnet-diagnostic-global-tools).

## The scenarios

### Debugging a memory leak

[Debugging a memory leak](app_is_leaking_memory_eventual_crash.md) walks through finding a memory leak. The [dotnet-counters](dotnet-counters.md) tool is used to confirm the leak. Then the [dotnet-dump](dotnet-dump.md) tool is used to diagnose the leak.

### Debugging a slow running application

[Debugging high CPU usage](app_running_slow_highcpu.md) walks through investigating high CPU usage. It uses the [dotnet-counters](dotnet-counters.md) tool to confirm the high CPU usage. It then walks through using [Trace for performance analysis utility (`dotnet-trace`)](dotnet-trace.md) or Linux `perf` to collect and view CPU usage profile.

### Debugging deadlock

The [debugging deadlock](hung_app.md) tutorial explores using the [dotnet-dump](dotnet-dump.md) tool to investigate threads and locks.
