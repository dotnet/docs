---
title: dotnet-counters - .NET Core
description: Learn how to install and use the dotnet-counter command-line tool.
author: sdmaclea
ms.author: stmaclea
ms.date: 10/01/2019
---
# dotnet-counters

**This article applies to: ✓** .NET Core 3.0 SDK and later versions

## Install dotnet-counters

To install the latest release version of the `dotnet-counters` [NuGet package](https://www.nuget.org/packages/dotnet-counters), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

```dotnetcli
dotnet tool install --global dotnet-counters
```

For details and other options, see [Installing the diagnostics tools](install-tools.md).

## Synopsis

```console
dotnet-counters [-h|--help] [--version]

dotnet-counters list [-h|--help]

dotnet-counters monitor [-h||--help] [-p|--process-id <pid>] [--refreshInterval <sec>] [counter_list]
```

## Description

`dotnet-counters` is a performance monitoring tool for ad-hoc health monitoring and first-level performance investigation. It can observe performance counter values that are published via the <xref:System.Diagnostics.Tracing.EventCounter> API. For example, you can quickly monitor things like the CPU usage or the rate of exceptions being thrown in your .NET Core application to see if there's anything suspicious before diving into more serious performance investigation using `PerfView` or `dotnet-trace`.

## Options

`--version`

Display the version of the dotnet-counters utility.

`-h|--help`

Show command-line help.

## Commands

| Command                                             | Function                                                     |
| --------------------------------------------------- | ------------------------------------------------------------ |
| [dotnet-counters list](#dotnet-counters-list)       | Display a list of counter names and descriptions.            |
| [dotnet-counters monitor](#dotnet-counters-monitor) | Display periodically refreshing values of selected counters. |

## dotnet-counters list

```console
dotnet-counters list [-h|--help]
```

Display a list of counter names and descriptions, grouped by provider.

### Example - dotnet-counters list

```console
> dotnet-counters list

    Showing well-known counters only. Specific processes may support additional counters.
    System.Runtime
        cpu-usage                    Amount of time the process has utilized the CPU (ms)
        working-set                  Amount of working set used by the process (MB)
        gc-heap-size                 Total heap size reported by the GC (MB)
        gen-0-gc-count               Number of Gen 0 GCs / sec
        gen-1-gc-count               Number of Gen 1 GCs / sec
        gen-2-gc-count               Number of Gen 2 GCs / sec
        exception-count              Number of Exceptions / sec
```

## dotnet-counters monitor

```console
dotnet-counters monitor [-h|--help] [-p|--process-id <pid>] [--refreshInterval <sec>] [counter_list]
```

Display periodically refreshing values of selected counters.

`-p|--process-id`

The ID of the process that will be monitored.

`--refresh-interval`

The number of seconds to delay between updating the displayed counters

`counter_list`

A space separated list of counters. Counters can be specified `provider_name[:counter_name]`. If the `provider_name` is used without a qualifying `counter_name`, then all counters will be shown. To discover provider and counter names, use the [dotnet-counters list](#dotnet-counters-list) command.

### Examples - dotnet-counters monitor

- Monitoring all counters from `System.Runtime` at a refresh interval of 3 seconds:

```console
> dotnet-counters monitor --process-id 1902  --refresh-interval 3 System.Runtime

Press p to pause, r to resume, q to quit.
  System.Runtime:
    CPU Usage (%)                                 24
    Working Set (MB)                            1982
    GC Heap Size (MB)                            811
    Gen 0 GC / second                             20
    Gen 1 GC / second                              4
    Gen 2 GC / second                              1
    Number of Exceptions / sec                     4
```

- Monitoring just CPU usage and GC heap size from `System.Runtime`:

```console
> dotnet-counters monitor --process-id 1902 System.Runtime[cpu-usage,gc-heap-size]

Press p to pause, r to resume, q to quit.
  System.Runtime:
    CPU Usage (%)                                 24
    GC Heap Size (MB)                            811
```

- Monitoring EventCounter values from user-defined EventSource: (see https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.Tracing/documentation/EventCounterTutorial.md for details.)

```console
> dotnet-counters monitor --process-id 1902 Samples-EventCounterDemos-Minimal

Press p to pause, r to resume, q to quit.
    request                                      100
```
