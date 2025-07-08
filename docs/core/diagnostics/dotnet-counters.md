---
title: dotnet-counters diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-counter CLI tool for ad-hoc health monitoring and first-level performance investigation.
ms.date: 11/17/2020
ms.topic: reference
---
# Investigate performance counters (dotnet-counters)

**This article applies to:** ✔️ `dotnet-counters` version 3.0.47001 and later versions.

Counters can be read from applications running .NET 5 or later.

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
  | Windows | [x86](https://aka.ms/dotnet-counters/win-x86) \| [x64](https://aka.ms/dotnet-counters/win-x64) \| [Arm](https://aka.ms/dotnet-counters/win-arm) \| [Arm-x64](https://aka.ms/dotnet-counters/win-arm64) |
  | Linux   | [x64](https://aka.ms/dotnet-counters/linux-x64) \| [Arm](https://aka.ms/dotnet-counters/linux-arm) \| [Arm64](https://aka.ms/dotnet-counters/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-counters/linux-musl-x64) \| [musl-Arm64](https://aka.ms/dotnet-counters/linux-musl-arm64) |

> [!NOTE]
> To use `dotnet-counters` on an x86 app, you need a corresponding x86 version of the tool.

## Synopsis

```dotnetcli
dotnet-counters [-h|--help] [--version] <command>
```

## Description

`dotnet-counters` is a performance monitoring tool for ad-hoc health monitoring and first-level performance investigation. It can observe performance counter values that are published via the <xref:System.Diagnostics.Tracing.EventCounter> API or the <xref:System.Diagnostics.Metrics.Meter> API. For example, you can quickly monitor things like the CPU usage or the rate of exceptions being thrown in your .NET Core application to see if there's anything suspicious before diving into more serious performance investigation using `PerfView` or `dotnet-trace`.

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

```dotnetcli
dotnet-counters collect [-h|--help] [-p|--process-id] [-n|--name] [--diagnostic-port] [--refresh-interval] [--counters <COUNTERS>] [--format] [-o|--output] [-- <command>]
```

### Options

- **`-p|--process-id <PID>`**

  The ID of the process to collect counter data from.

  > [!NOTE]
  > On Linux and macOS, using this option requires the target application and `dotnet-counters` to share the same `TMPDIR` environment variable. Otherwise, the command will time out.

- **`-n|--name <name>`**

  The name of the process to collect counter data from.

  > [!NOTE]
  > On Linux and macOS, using this option requires the target application and `dotnet-counters` to share the same `TMPDIR` environment variable. Otherwise, the command will time out.

- **`--diagnostic-port <port-address[,(listen|connect)]>`**

  Sets the [diagnostic port](diagnostic-port.md) used to communicate with the process to be monitored. dotnet-counters and the .NET runtime inside the target process must agree on the port-address, with one listening and the other connecting. dotnet-counters automatically determines the correct port when attaching using the `--process-id` or `--name` options, or when launching a process using the `-- <command>` option. It's usually only necessary to specify the port explicitly when waiting for a process that will start in the future or communicating to a process that is running inside a container that isn't part of the current process namespace.

  The `port-address` differs by OS:

  - Linux and macOS - a path to a Unix domain socket such as `/foo/tool1.socket`.
  - Windows - a path to a named pipe such as `\\.\pipe\my_diag_port1`.
  - Android, iOS, and tvOS - an IP:port such as `127.0.0.1:9000`.
  
  By default, dotnet-counters listens at the specified address. You can request dotnet-counters to connect instead by appending `,connect` after the address. For example, `--diagnostic-port /foo/tool1.socket,connect` will connect to a .NET runtime process that's listening to the `/foo/tool1.socket` Unix domain socket.

  For information about how to use this option to start monitoring counters from app startup, see [using diagnostic port](#using-diagnostic-port).

- **`--refresh-interval <SECONDS>`**

  The number of seconds to delay between updating the displayed counters

- **`--counters <COUNTERS>`**

  A comma-separated list of counters. Counters can be specified `provider_name[:counter_name]`. If the `provider_name` is used without a qualifying list of counters, then all counters from the provider are shown. To discover provider and counter names, use the [dotnet-counters list](#dotnet-counters-list) command. For [EventCounters](event-counters.md), `provider_name` is the name of the EventSource and for [Meters](metrics.md), `provider_name` is the name of the Meter.

- **`--format <csv|json>`**

  The format to be exported. Currently available: csv, json.

- **`-o|--output <output>`**

  The name of the output file.

- **`-- <command>`**

  After the collection configuration parameters, the user can append `--` followed by a command to start a .NET application. `dotnet-counters` will launch a process with the provided command and collect the requested metrics. This is often useful to collect metrics for the application's startup path and can be used to diagnose or monitor issues that happen early before or shortly after the main entrypoint.

  > [!NOTE]
  > Using this option monitors the first .NET process that communicates back to the tool, which means if your command launches multiple .NET applications, it will only collect the first app. Therefore, it is recommended you use this option on self-contained applications, or using the `dotnet exec <app.dll>` option.

  > [!NOTE]
  > Launching a .NET executable via dotnet-counters will redirect its input/output and you won't be able to interact with its stdin/stdout. Exiting the tool via CTRL+C or SIGTERM will safely end both the tool and the child process. If the child process exits before the tool, the tool will exit as well. If you need to use stdin/stdout, you can use the `--diagnostic-port` option. See [Using diagnostic port](#using-diagnostic-port) for more information.

> [!NOTE]
> To collect metrics using `dotnet-counters`, it needs to be run as the same user as the user running target process or as root. Otherwise, the tool will fail to establish a connection with the target process.

### Examples

- Collect all counters at a refresh interval of 3 seconds and generate a csv as output:

  ```dotnetcli
  > dotnet-counters collect --process-id 1902 --refresh-interval 3 --format csv

  --counters is unspecified. Monitoring System.Runtime counters by default.
  Starting a counter session. Press Q to quit.
  ```

- Start `dotnet mvc.dll` as a child process and start collecting runtime counters and ASP.NET Core Hosting counters from startup and save it as a JSON output:

  ```dotnetcli
  > dotnet-counters collect --format json --counters System.Runtime,Microsoft.AspNetCore.Hosting -- dotnet mvc.dll
  Starting a counter session. Press Q to quit.
  File saved to counter.json
  ```

## dotnet-counters list

Displays a list of counter names and descriptions, grouped by provider.

### Synopsis

```dotnetcli
dotnet-counters list [-h|--help]
```

### Example

```dotnetcli
> dotnet-counters list
Showing well-known counters only. Specific processes may support additional counters.

System.Runtime
    cpu-usage                                    Amount of time the process has utilized the CPU (ms)
    working-set                                  Amount of working set used by the process (MB)
    gc-heap-size                                 Total heap size reported by the GC (MB)
    gen-0-gc-count                               Number of Gen 0 GCs per interval
    gen-1-gc-count                               Number of Gen 1 GCs per interval
    gen-2-gc-count                               Number of Gen 2 GCs per interval
    time-in-gc                                   % time in GC since the last GC
    gen-0-size                                   Gen 0 Heap Size
    gen-1-size                                   Gen 1 Heap Size
    gen-2-size                                   Gen 2 Heap Size
    loh-size                                     LOH Heap Size
    alloc-rate                                   Allocation Rate
    assembly-count                               Number of Assemblies Loaded
    exception-count                              Number of Exceptions per interval
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

```dotnetcli
dotnet-counters monitor [-h|--help] [-p|--process-id] [-n|--name] [--diagnostic-port] [--refresh-interval] [--counters] [-- <command>]
```

### Options

- **`-p|--process-id <PID>`**

  The ID of the process to be monitored.

- **`-n|--name <name>`**

  The name of the process to be monitored.

- **`--diagnostic-port`**

  The name of the diagnostic port to create. See [using diagnostic port](#using-diagnostic-port) for how to use this option to start monitoring counters from app startup.

- **`--refresh-interval <SECONDS>`**

  The number of seconds to delay between updating the displayed counters

- **`--counters <COUNTERS>`**

  A comma-separated list of counters. Counters can be specified `provider_name[:counter_name]`. If the `provider_name` is used without a qualifying list of counters, then all counters from the provider are shown. To discover provider and counter names, use the [dotnet-counters list](#dotnet-counters-list) command. For [EventCounters](event-counters.md), `provider_name` is the name of the EventSource and for [Meters](metrics.md), `provider_name` is the name of the Meter.

 **`-- <command>`**

  After the collection configuration parameters, the user can append `--` followed by a command to start a .NET application. `dotnet-counters` will launch a process with the provided command and monitor the requested metrics. This is often useful to collect metrics for the application's startup path and can be used to diagnose or monitor issues that happen early before or shortly after the main entrypoint.

  > [!NOTE]
  > Using this option monitors the first .NET process that communicates back to the tool, which means if your command launches multiple .NET applications, it will only collect the first app. Therefore, it is recommended you use this option on self-contained applications, or using the `dotnet exec <app.dll>` option.

  > [!NOTE]
  > Launching a .NET executable via dotnet-counters will redirect its input/output and you won't be able to interact with its stdin/stdout. Exiting the tool via CTRL+C or SIGTERM will safely end both the tool and the child process. If the child process exits before the tool, the tool will exit as well. If you need to use stdin/stdout, you can use the `--diagnostic-port` option. See [Using diagnostic port](#using-diagnostic-port) for more information.

> [!NOTE]
> On Linux and macOS, this command expects the target application and `dotnet-counters` to share the same `TMPDIR` environment variable.

> [!NOTE]
> To monitor metrics using `dotnet-counters`, it needs to be run as the same user as the user running target process or as root.

> [!NOTE]
> If you see an error message similar to the following one: `[ERROR] System.ComponentModel.Win32Exception (299): A 32 bit processes cannot access modules of a 64 bit process.`, you are trying to use `dotnet-counters` that has mismatched bitness against the target process. Make sure to download the correct bitness of the tool in the [install](#install) link.

### Examples

- Monitor all counters from `System.Runtime` at a refresh interval of 3 seconds:

  ```dotnetcli
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

  ```dotnetcli
  > dotnet-counters monitor --process-id 1902 --counters System.Runtime[cpu-usage,gc-heap-size]

  Press p to pause, r to resume, q to quit.
    Status: Running

  [System.Runtime]
      CPU Usage (%)                                 24
      GC Heap Size (MB)                            811
  ```

- Monitor `EventCounter` values from user-defined `EventSource`. For more information, see [Tutorial: Measure performance using EventCounters in .NET Core](event-counter-perf.md).

  ```dotnetcli
  > dotnet-counters monitor --process-id 1902 --counters Samples-EventCounterDemos-Minimal

  Press p to pause, r to resume, q to quit.
      request                                      100
  ```

- View all well-known counters that are available in `dotnet-counters`:

  ```dotnetcli
  > dotnet-counters list

  Showing well-known counters for .NET (Core) version 3.1 only. Specific processes may support additional counters.
  System.Runtime
      cpu-usage                          The percent of process' CPU usage relative to all of the system CPU resources [0-100]
      working-set                        Amount of working set used by the process (MB)
      gc-heap-size                       Total heap size reported by the GC (MB)
      gen-0-gc-count                     Number of Gen 0 GCs between update intervals
      gen-1-gc-count                     Number of Gen 1 GCs between update intervals
      gen-2-gc-count                     Number of Gen 2 GCs between update intervals
      time-in-gc                         % time in GC since the last GC
      gen-0-size                         Gen 0 Heap Size
      gen-1-size                         Gen 1 Heap Size
      gen-2-size                         Gen 2 Heap Size
      loh-size                           LOH Size
      alloc-rate                         Number of bytes allocated in the managed heap between update intervals
      assembly-count                     Number of Assemblies Loaded
      exception-count                    Number of Exceptions / sec
      threadpool-thread-count            Number of ThreadPool Threads
      monitor-lock-contention-count      Number of times there were contention when trying to take the monitor lock between update intervals
      threadpool-queue-length            ThreadPool Work Items Queue Length
      threadpool-completed-items-count   ThreadPool Completed Work Items Count
      active-timer-count                 Number of timers that are currently active

  Microsoft.AspNetCore.Hosting
      requests-per-second                Number of requests between update intervals
      total-requests                     Total number of requests
      current-requests                   Current number of requests
      failed-requests                    Failed number of requests
  ```

- View all well-known counters that are available in `dotnet-counters` for .NET 5 apps:

  ```dotnetcli
  > dotnet-counters list --runtime-version 5.0

  Showing well-known counters for .NET (Core) version 5.0 only. Specific processes may support additional counters.
  System.Runtime
      cpu-usage                          The percent of process' CPU usage relative to all of the system CPU resources [0-100]
      working-set                        Amount of working set used by the process (MB)
      gc-heap-size                       Total heap size reported by the GC (MB)
      gen-0-gc-count                     Number of Gen 0 GCs between update intervals
      gen-1-gc-count                     Number of Gen 1 GCs between update intervals
      gen-2-gc-count                     Number of Gen 2 GCs between update intervals
      time-in-gc                         % time in GC since the last GC
      gen-0-size                         Gen 0 Heap Size
      gen-1-size                         Gen 1 Heap Size
      gen-2-size                         Gen 2 Heap Size
      loh-size                           LOH Size
      poh-size                           POH (Pinned Object Heap) Size
      alloc-rate                         Number of bytes allocated in the managed heap between update intervals
      gc-fragmentation                   GC Heap Fragmentation
      assembly-count                     Number of Assemblies Loaded
      exception-count                    Number of Exceptions / sec
      threadpool-thread-count            Number of ThreadPool Threads
      monitor-lock-contention-count      Number of times there were contention when trying to take the monitor lock between update intervals
      threadpool-queue-length            ThreadPool Work Items Queue Length
      threadpool-completed-items-count   ThreadPool Completed Work Items Count
      active-timer-count                 Number of timers that are currently active
      il-bytes-jitted                    Total IL bytes jitted
      methods-jitted-count               Number of methods jitted

  Microsoft.AspNetCore.Hosting
      requests-per-second   Number of requests between update intervals
      total-requests        Total number of requests
      current-requests      Current number of requests
      failed-requests       Failed number of requests

  Microsoft-AspNetCore-Server-Kestrel
      connections-per-second      Number of connections between update intervals
      total-connections           Total Connections
      tls-handshakes-per-second   Number of TLS Handshakes made between update intervals
      total-tls-handshakes        Total number of TLS handshakes made
      current-tls-handshakes      Number of currently active TLS handshakes
      failed-tls-handshakes       Total number of failed TLS handshakes
      current-connections         Number of current connections
      connection-queue-length     Length of Kestrel Connection Queue
      request-queue-length        Length total HTTP request queue

  System.Net.Http
      requests-started        Total Requests Started
      requests-started-rate   Number of Requests Started between update intervals
      requests-aborted        Total Requests Aborted
      requests-aborted-rate   Number of Requests Aborted between update intervals
      current-requests        Current Requests
  ```

- Launch `my-aspnet-server.exe` and monitor the # of assemblies loaded from its startup:

  ```dotnetcli
  > dotnet-counters monitor --counters System.Runtime[assembly-count] -- my-aspnet-server.exe

  Press p to pause, r to resume, q to quit.
    Status: Running

  [System.Runtime]
      Number of Assemblies Loaded                   24
  ```
  
- Launch `my-aspnet-server.exe` with `arg1` and `arg2` as command-line arguments and monitor its working set and GC heap size from its startup:

  ```dotnetcli
  > dotnet-counters monitor --counters System.Runtime[working-set,gc-heap-size] -- my-aspnet-server.exe arg1 arg2
  ```

  ```output
  Press p to pause, r to resume, q to quit.
    Status: Running

  [System.Runtime]
      GC Heap Size (MB)                                 39
      Working Set (MB)                                  59
  ```

## dotnet-counters ps

 Lists the dotnet processes that can be monitored by `dotnet-counters`.
 `dotnet-counters` version 6.0.320703 and later, also display the command-line arguments that each process was started with, if available.

### Synopsis

```dotnetcli
dotnet-counters ps [-h|--help]
```

### Example

Suppose you start a long-running app using the command ```dotnet run --configuration Release```. In another window, you run the ```dotnet-counters ps``` command. The output you'll see is as follows. The command-line arguments, if any, are shown in `dotnet-counters` version 6.0.320703 and later.

```dotnetcli
> dotnet-counters ps
  
  21932 dotnet     C:\Program Files\dotnet\dotnet.exe   run --configuration Release
  36656 dotnet     C:\Program Files\dotnet\dotnet.exe
```

## Using diagnostic port

[Diagnostic port](./diagnostic-port.md) is a runtime feature that allows you to start monitoring or collecting counters from app startup. To do this using `dotnet-counters`, you can either use `dotnet-counters <collect|monitor> -- <command>` as described in the examples above, or use the `--diagnostic-port` option.

Using `dotnet-counters <collect|monitor> -- <command>` to launch the application as a child process is the simplest way to quickly monitor it from its startup.

However, when you want to gain a finer control over the lifetime of the app being monitored (for example, monitor the app for the first 10 minutes only and continue executing) or if you need to interact with the app using the CLI, using `--diagnostic-port` option allows you to control both the target app being monitored and `dotnet-counters`.

1. The command below makes dotnet-counters create a diagnostics socket named `myport.sock` and wait for a connection.

    > ```dotnetcli
    > dotnet-counters collect --diagnostic-port myport.sock
    > ```

    Output:

    > ```output
    > Waiting for connection on myport.sock
    > Start an application with the following environment variable: DOTNET_DiagnosticPorts=/home/user/myport.sock
    > ```

2. In a separate console, launch the target application with the environment variable `DOTNET_DiagnosticPorts` set to the value in the `dotnet-counters` output.

    > ```console
    > export DOTNET_DiagnosticPorts=/home/user/myport.sock
    > ./my-dotnet-app arg1 arg2
    > ```

    This should then enable `dotnet-counters` to start collecting counters on `my-dotnet-app`:

    > ```output
    > Waiting for connection on myport.sock
    > Start an application with the following environment variable: DOTNET_DiagnosticPorts=myport.sock
    > Starting a counter session. Press Q to quit.
    > ```

    > [!IMPORTANT]
    > Launching your app with `dotnet run` can be problematic because the dotnet CLI may spawn many child processes that are not your app and they can connect to `dotnet-counters` before your app, leaving your app to be suspended at run time. It is recommended you directly use a self-contained version of the app or use `dotnet exec` to launch the application.
