---
title: Debugging high CPU usage - .NET Core
description: A tutorial walk-through, debugging high CPU usage in .NET Core.
author: sdmaclea
ms.author: stmaclea
ms.date: 07/16/2020
---

# Debugging high CPU usage

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions

In this scenario, the [sample debug target](sample-debug-target.md) will consume excessive CPU. To diagnose this scenario, we need several key pieces of diagnostics data.

The tutorial uses:

- [Sample debug target](sample-debug-target.md) to trigger the scenario.
- [dotnet-trace](dotnet-trace.md) to list processes and generate a profile.
- [dotnet-counters](dotnet-counters.md) to monitor cpu usage.

The tutorial assumes the sample and tools are ready to use.

## CPU counters

Before we dig into collecting diagnostics data, we need to convince ourselves that what we are actually seeing is a high CPU condition.

Lets run the [sample debug target](sample-debug-target.md).

```dotnetcli
dotnet run
```

Then find the process ID using:

```dotnetcli
dotnet-trace list-processes
```

Before hitting the above URL that will cause the high CPU condition, lets check our CPU counters using the [dotnet-counters](dotnet-counters.md) tool:

```dotnetcli
dotnet-counters monitor --refresh-interval 1 -p 22884
```

22884 is the process ID that was found using `dotnet-trace list-processes`. The refresh-interval is the number of seconds before refreshes.

The output should be similar to the below:

![alt text](https://user-images.githubusercontent.com/15442480/57110746-75730800-6cee-11e9-81a8-1c253aef37ce.jpg)

Here we can see that right after startup, the CPU isn't being consumed at all (0%).

Now, let's hit the URL [http://localhost:5000/api/diagscenario/highcpu/60000](http://localhost:5000/api/diagscenario/highcpu/60000)

Rerun the [dotnet-counters](dotnet-counters.md) command. We should see an increase in CPU usage as shown below:

![alt text](https://user-images.githubusercontent.com/15442480/57110736-6be9a000-6cee-11e9-86b6-6e128318a267.jpg)

Throughout the execution of that request, CPU hovers at around 30%.

```dotnetcli
dotnet-counters monitor System.Runtime[cpu-usage] -p 22884 --refresh-interval 1
```

At this point, we can safely say the CPU is running a hotter than we expect.

## Trace generation

When analyzing a slow request, we need a diagnostics tool that can give us insight into what our code is doing. The usual choice is a profiler. There are a few different profilers options.

### Profile with `dotnet-trace` then view with Windows `PerfView`

We can use the [dotnet-trace](dotnet-trace.md) tool. Using the previous [sample debug target](sample-debug-target.md), hit the URL (<http://localhost:5000/api/diagscenario/highcpu/60000>) again and while its running within the 1-minute request, run:

```dotnetcli
dotnet-trace collect -p 2266  --providers Microsoft-DotNETCore-SampleProfiler
```

22884 is the process ID that was found using `dotnet-trace list-processes`.

Let [dotnet-trace](dotnet-trace.md) run for about 20-30 seconds and then hit enter to exit the collection. The result is a `nettrace` file located in the same folder. `nettrace` files are a great way to use existing analysis tools on Windows.

Open the `nettrace` with `PerfView` as shown below.

![alt text](https://user-images.githubusercontent.com/15442480/57110777-976c8a80-6cee-11e9-9cf7-407a01a08b1d.jpg)

### Profile and view with Linux `perf`

Here, we'll demonstrate the Linux `perf` tool to generate .NET Core app profiles.

Exit the previous instance of the [sample debug target](sample-debug-target.md).

Set the `COMPlus_PerfMapEnabled` to cause the .NET Core app to create a `map` file in the `/tmp` directory. This `map` file is used by `perf` to map CPU address to JIT-generated functions by name.

Run the [sample debug target](sample-debug-target.md) in the same terminal session.

```dotnetcli
export COMPlus_PerfMapEnabled=1
dotnet run
```

Hit the URL (http://localhost:5000/api/diagscenario/highcpu/60000) again and while its running within the 1-minute request, run:

```console
sudo perf record -p 2266 -g
```

This command will start the perf collection process. Let it run for about 20-30 seconds and then hit CTRL-C to exit the collection process.

You can use the same perf command to see the output of the trace.

```console
sudo perf report -f
```

You can also generate a flame-graph by using the following commands:

```console
git clone --depth=1 https://github.com/BrendanGregg/FlameGraph
sudo perf script | FlameGraph/stackcollapse-perf.pl | FlameGraph/flamegraph.pl > flamegraph.svg
```

This command will generate a `flamegraph.svg` that you can view in the browser to investigate the performance problem:

![alt text](https://user-images.githubusercontent.com/15442480/57110767-87ed4180-6cee-11e9-98d9-9f1c908acfd5.jpg)