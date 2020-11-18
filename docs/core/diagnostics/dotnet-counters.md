---
title: dotnet-counters diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-counter CLI tool for ad-hoc health monitoring and first-level performance investigation.
ms.date: 11/17/2020
---
# Investigate performance counters (dotnet-counters)

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

## Install

There are two ways to download and install `dotnet-counters`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-counters` [NuGet package](https://www.nuget.org/packages/dotnet-counters), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-counters
  ```

- **Direct download:**

  Download the tool executable that matches your platform:

  | OS  | Platform |
  | --- | -------- |
  | Windows | [x86](https://aka.ms/dotnet-counters/win-x86) \| [x64](https://aka.ms/dotnet-counters/win-x64) \| [arm](https://aka.ms/dotnet-counters/win-arm) \| [arm-x64](https://aka.ms/dotnet-counters/win-arm64) |
  | macOS   | [x64](https://aka.ms/dotnet-counters/osx-x64) |
  | Linux   | [x64](https://aka.ms/dotnet-counters/linux-x64) \| [arm](https://aka.ms/dotnet-counters/linux-arm) \| [arm64](https://aka.ms/dotnet-counters/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-counters/linux-musl-x64) \| [musl-arm64](https://aka.ms/dotnet-counters/linux-musl-arm64) |

## Synopsis

```console
dotnet-counters [-h|--help] [--version] <command>
```

## Description

`dotnet-counters` is a performance monitoring tool for ad-hoc health monitoring and first-level performance investigation. It can observe performance counter values that are published via the <xref:System.Diagnostics.Tracing.EventCounter> API. For example, you can quickly monitor things like the CPU usage or the rate of exceptions being thrown in your .NET Core application to see if there's anything suspicious before diving into more serious performance investigation using `PerfView` or `dotnet-trace`.

## Options

- **`--version`**

  Displays the version of the dotnet-counters utility.

- **`-h|--help`**

  Shows command-line help.

## Commands

| Command                                             |
|-----------------------------------------------------|
| [dotnet-counters collect](#dotnet-counters-collect) |
| [dotnet-counters list](#dotnet-counters-list)       |
| [dotnet-counters monitor](#dotnet-counters-monitor) |
| [dotnet-counters ps](#dotnet-counters-ps)           |

## dotnet-counters collect

Periodically collect selected counter values and export them into a specified file format for post-processing.

### Synopsis

```console
dotnet-counters collect [-h|--help] [-p|--process-id] [-n|--name] [--refresh-interval] [--counters <COUNTERS>] [--format] [-o|--output] [-- <command>]
```

### Options

- **`-p|--process-id <PID>`**

  The ID of the process to be collect counter data from.

- **`-n|--name <name>`**

  The name of the process to be collect counter data from.

- **`--refresh-interval <SECONDS>`**

  The number of seconds to delay between updating the displayed counters

- **`--counters <COUNTERS>`**

  A comma-separated list of counters. Counters can be specified `provider_name[:counter_name]`. If the `provider_name` is used without a qualifying list of counters, then all counters from the provider are shown. To discover provider and counter names, use the [dotnet-counters list](#dotnet-counters-list) command.

- **`--format <csv|json>`**

  The format to be exported. Currently available: csv, json.

- **`-o|--output <output>`**

  The name of the output file.

- **`-- <command>` (for target applications running .NET 5.0 or later only)**

  After the collection configuration parameters, the user can append `--` followed by a command to start a .NET application with at least a 5.0 runtime. `dotnet-counters` will launch a process with the provided command and collect the requested metrics. This is often useful to collect metrics for the application's startup path and can be used to diagnose or monitor issues that happen early before or shortly after the main entrypoint.

  > [!NOTE]
  > Using this option monitors the first .NET 5.0 process that communicates back to the tool, which means if your command launches multiple .NET applications, it will only collect the first app. Therefore, it is recommended you use this option on self-contained applications, or using the `dotnet exec <app.dll>` option.

### Examples

- Collect all counters at a refresh interval of 3 seconds and generate a csv as output:

  ```console
  > dotnet-counters collect --process-id 1902 --refresh-interval 3 --format csv

  counter_list is unspecified. Monitoring all counters by default.
  Starting a counter session. Press Q to quit.
  ```

- Start `dotnet mvc.dll` as a child process and start collecting runtime counters and ASP.NET Core Hosting counters from startup and save it as a JSON output:

  ```console
  > dotnet-counters collect --format json --counters System.Runtime,Microsoft.AspNetCore.Hosting -- dotnet mvc.dll
  Starting a counter session. Press Q to quit.
  File saved to counter.json
  ```

## dotnet-counters list

Displays a list of counter names and descriptions, grouped by provider.

### Synopsis

```console
dotnet-counters list [-h|--help]
```

### Example

```console
> dotnet-counters list
Showing well-known counters only. Specific processes may support additional counters.

System.Runtime
    cpu-usage                                    Amount of time the process has utilized the CPU (ms)
    working-set                                  Amount of working set used by the process (MB)
    gc-heap-size                                 Total heap size reported by the GC (MB)
    gen-0-gc-count                               Number of Gen 0 GCs / min
    gen-1-gc-count                               Number of Gen 1 GCs / min
    gen-2-gc-count                               Number of Gen 2 GCs / min
    time-in-gc                                   % time in GC since the last GC
    gen-0-size                                   Gen 0 Heap Size
    gen-1-size                                   Gen 1 Heap Size
    gen-2-size                                   Gen 2 Heap Size
    loh-size                                     LOH Heap Size
    alloc-rate                                   Allocation Rate
    assembly-count                               Number of Assemblies Loaded
    exception-count                              Number of Exceptions / sec
    threadpool-thread-count                      Number of ThreadPool Threads
    monitor-lock-contention-count                Monitor Lock Contention Count
    threadpool-queue-length                      ThreadPool Work Items Queue Length
    threadpool-completed-items-count             ThreadPool Completed Work Items Count
    active-timer-count                           Active Timers Count

Microsoft.AspNetCore.Hosting
    requests-per-second                  Request rate
    total-requests                       Total number of requests
    current-requests                     Current number of requests
    failed-requests                      Failed number of requests
```

> [!NOTE]
> The `Microsoft.AspNetCore.Hosting` counters are displayed when there are processes identified that support these counters, for example; when an ASP.NET Core application is running on the host machine.

## dotnet-counters monitor

Displays periodically refreshing values of selected counters.

### Synopsis

```console
dotnet-counters monitor [-h|--help] [-p|--process-id] [-n|--name] [--refresh-interval] [--counters] [-- <command>]
```

### Options

- **`-p|--process-id <PID>`**

  The ID of the process to be monitored.

- **`-n|--name <name>`**

  The name of the process to be monitored.

- **`--refresh-interval <SECONDS>`**

  The number of seconds to delay between updating the displayed counters

- **`--counters <COUNTERS>`**

  A comma-separated list of counters. Counters can be specified `provider_name[:counter_name]`. If the `provider_name` is used without a qualifying list of counters, then all counters from the provider are shown. To discover provider and counter names, use the [dotnet-counters list](#dotnet-counters-list) command.

 **`-- <command>` (for target applications running .NET 5.0 or later only)**

  After the collection configuration parameters, the user can append `--` followed by a command to start a .NET application with at least a 5.0 runtime. `dotnet-counters` will launch a process with the provided command and monitor the requested metrics. This is often useful to collect metrics for the application's startup path and can be used to diagnose or monitor issues that happen early before or shortly after the main entrypoint.

  > [!NOTE]
  > Using this option monitors the first .NET 5.0 process that communicates back to the tool, which means if your command launches multiple .NET applications, it will only collect the first app. Therefore, it is recommended you use this option on self-contained applications, or using the `dotnet exec <app.dll>` option.

### Examples

- Monitor all counters from `System.Runtime` at a refresh interval of 3 seconds:

  ```console
  > dotnet-counters monitor --process-id 1902  --refresh-interval 3 --counters System.Runtime
  Press p to pause, r to resume, q to quit.
      Status: Running

  [System.Runtime]
      % Time in GC since last GC (%)                                 0
      Allocation Rate (B / 1 sec)                                5,376
      CPU Usage (%)                                                  0
      Exception Count (Count / 1 sec)                                0
      GC Fragmentation (%)                                          48.467
      GC Heap Size (MB)                                              0
      Gen 0 GC Count (Count / 1 sec)                                 1
      Gen 0 Size (B)                                                24
      Gen 1 GC Count (Count / 1 sec)                                 1
      Gen 1 Size (B)                                                24
      Gen 2 GC Count (Count / 1 sec)                                 1
      Gen 2 Size (B)                                           272,000
      IL Bytes Jitted (B)                                       19,449
      LOH Size (B)                                              19,640
      Monitor Lock Contention Count (Count / 1 sec)                  0
      Number of Active Timers                                        0
      Number of Assemblies Loaded                                    7
      Number of Methods Jitted                                     166
      POH (Pinned Object Heap) Size (B)                             24
      ThreadPool Completed Work Item Count (Count / 1 sec)           0
      ThreadPool Queue Length                                        0
      ThreadPool Thread Count                                        2
      Working Set (MB)                                              19
  ```

- Monitor just CPU usage and GC heap size from `System.Runtime`:

  ```console
  > dotnet-counters monitor --process-id 1902 --counters System.Runtime[cpu-usage,gc-heap-size]

  Press p to pause, r to resume, q to quit.
    Status: Running

  [System.Runtime]
      CPU Usage (%)                                 24
      GC Heap Size (MB)                            811
  ```

- Monitor `EventCounter` values from user-defined `EventSource`. For more information, see [Tutorial: Measure performance using EventCounters in .NET Core](event-counter-perf.md).

  ```console
  > dotnet-counters monitor --process-id 1902 --counters Samples-EventCounterDemos-Minimal

  Press p to pause, r to resume, q to quit.
      request                                      100
  ```

- Launch `my-aspnet-server.exe` and monitor the # of assemblies loaded from its startup (.NET 5.0 or later only):

  > [!IMPORTANT]
  > This works for apps running .NET 5.0 or later only.

  ```console
  > dotnet-counters monitor --counters System.Runtime[assembly-count] -- my-aspnet-server.exe

  Press p to pause, r to resume, q to quit.
    Status: Running

  [System.Runtime]
      Number of Assemblies Loaded                   24
  ```
  
- Launch `my-aspnet-server.exe` with `arg1` and `arg2` as command-line arguments and monitor its working set and GC heap size from its startup (.NET 5.0 or later only):

  > [!IMPORTANT]
  > This works for apps running .NET 5.0 or later only.

  ```console
  > dotnet-counters monitor --counters System.Runtime[working-set,gc-heap-size] -- my-aspnet-server.exe arg1 arg2
  ```

  ```console
  Press p to pause, r to resume, q to quit.
    Status: Running

  [System.Runtime]
      GC Heap Size (MB)                                 39
      Working Set (MB)                                  59
  ```

## dotnet-counters ps

Display a list of dotnet processes that can be monitored.

### Synopsis

```console
dotnet-counters ps [-h|--help]
```

### Example

```console
> dotnet-counters ps
  
  15683 WebApi     /home/suwhang/repos/WebApi/WebApi
  16324 dotnet     /usr/local/share/dotnet/dotnet
```
