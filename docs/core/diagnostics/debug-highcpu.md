---
title: Debug high CPU usage - .NET Core
description: A tutorial walk-through, debugging high CPU usage in .NET Core.
ms.topic: tutorial
ms.date: 07/16/2020
---

# Debug high CPU usage in .NET Core

**This article applies to: ✔️** .NET Core 3.1 SDK and later versions

The tutorial walks through an excessive CPU scenario, using an [ASP.NET Core web app source code example](https://docs.microsoft.com/samples/dotnet/samples/diagnostic-scenarios) that causes a deadlock. In this scenario, the endpoint will experience a hang, and thread accumulation. You'll learn how you can use various tools to diagnose this scenario, with several key pieces of diagnostics data.

In this tutorial, you will:

> [!div class="checklist"]
>
> - Investigate high CPU
> - Determine CPU with [dotnet-counters](dotnet-counters.md)
> - Use [dotnet-trace](dotnet-trace.md) for trace generation
> - Profile performance in PerfView
> - Analyze callstacks and symbolic links
> - Diagnose and solve deadlock

## Prerequisites

The tutorial uses:

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core) or a later version.
- [Sample debug target](https://docs.microsoft.com/samples/dotnet/samples/diagnostic-scenarios) to trigger the scenario.
- [dotnet-trace](dotnet-trace.md) to list processes and generate a profile.
- [dotnet-counters](dotnet-counters.md) to monitor cpu usage.

The tutorial runs on **Linux**.

## CPU counters

Before attempting to collect diagnostics data, you need to observe a high CPU condition. Run the [sample debug](https://docs.microsoft.com/samples/dotnet/samples/diagnostic-scenarios) application using the following command.

```dotnetcli
dotnet run
```

To find the process ID, use the following command:

```dotnetcli
dotnet-trace list-processes
```

Take note of the process ID from your command output (yours will be different), ours was `22884`. To check the current CPU, use the [dotnet-counters](dotnet-counters.md) tool command:

```dotnetcli
dotnet-counters monitor --refresh-interval 1 -p 22884
```

Our process ID was `22884` (again, yours will be different), and was found using `dotnet-trace list-processes`. The `refresh-interval` is the number of seconds between the counter polling CPU values. The output should be similar to the following:

```bash
Press p to pause, r to resume, q to quit.
System.Runtime
    CPU Usage (%) : 0
    Working Set (MB) : 80
    Gen 0 GC / sec : 0
    Gen 1 GC / sec : 0
    Gen 2 GC / sec : 0
    Exceptions / sec : 0
```

With the web app running, immediately after startup, the CPU isn't being consumed at all `0%`. Navigate to the following URL, which is an API endpoint on the sample site:

[http://localhost:5000/api/diagscenario/highcpu/60000](http://localhost:5000/api/diagscenario/highcpu/60000)

Now, re-run the [dotnet-counters](dotnet-counters.md) command. You should see an increase in CPU usage as shown below:

```bash
Press p to pause, r to resume, q to quit.
System.Runtime
    CPU Usage (%) : 32
    Working Set (MB) : 80
    Gen 0 GC / sec : 10
    Gen 1 GC / sec : 0
    Gen 2 GC / sec : 0
    Exceptions / sec : 0
```

Throughout the live of that request, the CPU will hover around 30% (depending on the host machine).

```dotnetcli
dotnet-counters monitor System.Runtime[cpu-usage] -p 22884 --refresh-interval 1
```

At this point, you can safely say the CPU is running higher than you expect.

## Trace generation

When analyzing a slow request, you need a diagnostics tool that can give us insight into what our code is doing. The usual choice is a profiler. There are a few different profilers options.

### Profile with `dotnet-trace` then view with Windows `PerfView`

You can use the [dotnet-trace](dotnet-trace.md) tool. Using the previous [sample debug target](https://docs.microsoft.com/samples/dotnet/samples/diagnostic-scenarios), hit the URL (<http://localhost:5000/api/diagscenario/highcpu/60000>) again and while its running within the 1-minute request, run:

```dotnetcli
dotnet-trace collect -p 22884 --providers Microsoft-DotNETCore-SampleProfiler
```

Let [dotnet-trace](dotnet-trace.md) run for about 20-30 seconds, and then press the <kbd>Enter</kbd> to exit the collection. The result is a `nettrace` file located in the same folder. The `nettrace` files are a great way to use existing analysis tools on **Windows**.

Open the `nettrace` with [`PerfView`](https://github.com/microsoft/perfview/blob/master/documentation/Downloading.md) as shown below.

![alt text](https://user-images.githubusercontent.com/15442480/57110777-976c8a80-6cee-11e9-9cf7-407a01a08b1d.jpg)

### Profile and view with Linux `perf`

Here, you'll demonstrate the Linux `perf` tool to generate .NET Core app profiles.

Exit the previous instance of the [sample debug target](https://docs.microsoft.com/samples/dotnet/samples/diagnostic-scenarios).

Set the `COMPlus_PerfMapEnabled` to cause the .NET Core app to create a `map` file in the `/tmp` directory. This `map` file is used by `perf` to map CPU address to JIT-generated functions by name. For more information, see [Write perf map](../run-time-config/debugging-profiling.md#write-perf-map).

Run the [sample debug target](https://docs.microsoft.com/samples/dotnet/samples/diagnostic-scenarios) in the same terminal session.

```dotnetcli
export COMPlus_PerfMapEnabled=1
dotnet run
```

Hit the URL (<http://localhost:5000/api/diagscenario/highcpu/60000>) again and while its running within the 1-minute request, run:

```bash
sudo perf record -p 2266 -g
```

This command will start the perf collection process. Let it run for about 20-30 seconds and then hit <kbd>Ctrl+C</kbd> to exit the collection process.

You can use the same perf command to see the output of the trace.

```bash
sudo perf report -f
```

You can also generate a flame-graph by using the following commands:

```bash
git clone --depth=1 https://github.com/BrendanGregg/FlameGraph
sudo perf script | FlameGraph/stackcollapse-perf.pl | FlameGraph/flamegraph.pl > flamegraph.svg
```

This command will generate a `flamegraph.svg` that you can view in the browser to investigate the performance problem:

![alt text](https://user-images.githubusercontent.com/15442480/57110767-87ed4180-6cee-11e9-98d9-9f1c908acfd5.jpg)
