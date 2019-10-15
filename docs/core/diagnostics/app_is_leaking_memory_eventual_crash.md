---
title: Debugging a memory leak - .NET Core
description: A tutorial walk-through, debugging a memory leak in .NET Core.
author: sdmaclea
ms.author: stmaclea
ms.date: 10/14/2019
---
# Debugging a memory leak

**This article applies to: ✓** .NET Core 3.0 SDK and later versions

In this scenario, the endpoint will slowly start leaking memory and eventually will result in an out of memory exception. To diagnose this scenario, we need several key pieces of diagnostics data.

## Preparing

The tutorial uses:

- [Sample debug target](sample-debug-target.md) to trigger the scenario.
- [dotnet-trace](dotnet-trace.md) to list processes.
- [dotnet-counters](dotnet-counters.md) to check managed memory usage.
- [dotnet-dump](dotnet-dump.md) to collect and analyze a dump file.

The tutorial assumes the sample and tools are ready to use and you are running on **Linux**.

## Memory counters

Before we dig into collecting diagnostics data to help us root cause this scenario, we need to convince ourselves that what we are actually seeing is a memory leak (memory growth). We can use the [dotnet-counters](dotnet-counters.md) tool to get at this information.

Lets run the [Sample debug target](sample-debug-target.md).

```dotnetcli
dotnet run
```

Then find the process ID using:

```dotnetcli
dotnet-trace list-processes
```

Before causing the leak, lets check our managed memory counters:

```dotnetcli
dotnet-counters monitor --refresh-interval 1 -p 4807
```

4807 is the process ID that was found using `dotnet-trace list-processes`. The refresh-interval is the number of seconds between refreshes.

The output should be similar to:

```console
    Press p to pause, r to resume, q to quit.
      System.Runtime:
        CPU Usage (%)                                  4
        Working Set (MB)                              66
        GC Heap Size (MB)                              4
        Gen 0 GC / second                              0
        Gen 1 GC / second                              0
        Gen 2 GC / second                              0
        Number of Exceptions / sec                     0
```

Here we can see that right after startup, the managed heap memory is 4 MB.

Now, let's hit the URL [http://localhost:5000/api/diagscenario/memleak/200000](http://localhost:5000/api/diagscenario/memleak/200000)

Rerun the dotnet-counters command. We should see an increase in memory usage as shown below:

```console
    Press p to pause, r to resume, q to quit.
      System.Runtime:
        CPU Usage (%)                                  4
        Working Set (MB)                             353
        GC Heap Size (MB)                            258
        Gen 0 GC / second                              0
        Gen 1 GC / second                              0
        Gen 2 GC / second                              0
        Number of Exceptions / sec                     0
```

Memory has now grown to 258 MB.

We can safely say that memory is growing or leaking. The next step is collect the right data for memory analysis.

### Core dump generation

When analyzing possible memory leaks, we need access to the apps memory heap. We then analyze the memory contents. Looking at relationships between objects, we create theories on why memory isn't being freed. A common diagnostics data source is a memory dump (Win) or the equivalent core dump (Linux). To generate a core dump of a .NET Core application, we can use the [dotnet-dump)](dotnet-dump.md) tool.

Using the previous [Sample debug target](sample-debug-target.md) started above, run the following command to generate a core dump:

```dotnetcli
sudo dotnet-dump collect -p 4807
```

4807 is the process ID that can be found using `dotnet-trace list-processes`. The result is a core dump located in the same folder.

> [!NOTE]
> To generate core dumps, `dotnet-dump` requires sudo.

### Analyzing the core dump

Now that we have a core dump generated, use the [dotnet-dump)](dotnet-dump.md) tool to analyze the dump:

```dotnetcli
dotnet-dump analyze core_20190430_185145
```

Where `core_20190430_185145` is the name of the core dump you want to analyze.

> [!NOTE]
> If you see an error complaining that libdl.so cannot be found, you may have to install the libc6-dev package.

You'll be presented with a prompt where you can enter SOS commands. Commonly, the first thing we want to look at is the overall state of the managed heap:

```console
> dumpheap -stat
```

The (partial) output can be seen below:

![alt text](https://user-images.githubusercontent.com/15442480/57110756-7d32ac80-6cee-11e9-9b80-2ce700e7a2f1.png)

Here we can see that we have quite a few strings laying around (also instances of Customer and Customer[]). We can now use the gcroot command on one of the string instances to see how/why the object is rooted:

![alt text](https://user-images.githubusercontent.com/15442480/57110770-8face600-6cee-11e9-8eea-608b59442058.png)

The string instance appears to be rooted from top-level Processor object which in turn references a cache. We can continue dumping out objects to see how much the cache is holding on to:

![alt text](https://user-images.githubusercontent.com/15442480/57110703-4b214a80-6cee-11e9-8887-02c25424a0ad.png)

From here, we can now try to back-track (from code) why the cache seems to be growing in an unbound fashion.
