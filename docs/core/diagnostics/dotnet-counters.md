---
title: dotnet-counters - .NET Core
description: Installing and using the dotnet-counter command-line tool.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/21/2019
---
# dotnet-counters

## Intro

`dotnet-counters` is a performance monitoring tool for ad-hoc health monitoring or first-level performance investigation. It can observe performance counter values that are published via the `EventCounter` [API](https://docs.microsoft.com/dotnet/api/system.diagnostics.tracing.eventcounter). For example, you can quickly monitor things like the CPU usage or the rate of exceptions being thrown in your .NET Core application to see if there's anything suspicious before diving into more serious performance investigation using `PerfView` or `dotnet-trace`.

## Install dotnet-counters

To install the latest release version of the `dotnet-counters` [NuGet package](https://www.nuget.org/packages/dotnet-counters):

```
dotnet tool install --global dotnet-counters
```

For details and other options, see [Installing the diagnostics tools](installing.md).

> [!NOTE]
> At the time of this writing, the `dotnet-counters` tool has not been released. The prerelease version can be installed using:
>
> ```
> dotnet tool install --global dotnet-counters --version 3.0.0-preview8.19412.1
> ```
>

## Using dotnet-counters

*SYNOPSIS*

```
dotnet-counters [--version]
                [-h, --help]
                <command> [<args>]
```

*OPTIONS*

```
    --version
        Display the version of the dotnet-counters utility.
    -h, --help
        Show command line help
```

*COMMANDS*

```
    list      Display a list of counter names and descriptions
    monitor   Display periodically refreshing values of selected counters
```

*LIST*

```
    dotnet-counters list [-h|--help]

    Display a list of counter names and descriptions, grouped by provider.

    -h, --help
        Show command line help

    Examples:
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

*MONITOR*

```
    dotnet-counters monitor [-h||--help]
                            [-p|--process-id <pid>]
                            [--refreshInterval <sec>]
                            counter_list

    Display periodically refreshing values of selected counters

    -h, --help
        Show command line help

    -p,--process-id
        The ID of the process that will be monitored

    --refresh-interval
        The number of seconds to delay between updating the displayed counters

    counter_list
        A space separated list of counters. Counters can be specified provider_name[:counter_name]. If the
        provider_name is used without a qualifying counter_name then all counters will be shown. To discover
        provider and counter names, use the list command.

    Examples:

    1. Monitoring all counters from `System.Runtime` at a refresh interval of 3 seconds:

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

    2. Monitoring just CPU usage and GC heap size from `System.Runtime`:

      > dotnet-counters monitor --process-id 1902 System.Runtime[cpu-usage,gc-heap-size]

    Press p to pause, r to resume, q to quit.
      System.Runtime:
        CPU Usage (%)                                 24
        GC Heap Size (MB)                            811

    3. Monitoring EventCounter values from user-defined EventSource: (see https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.Tracing/documentation/EventCounterTutorial.md on how to do this.)

      > dotnet-counters monitor --process-id 1902 Samples-EventCounterDemos-Minimal

    Press p to pause, r to resume, q to quit.
        request                                      100
```
