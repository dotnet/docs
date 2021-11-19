---
title: Debug a memory leak tutorial
description: Learn how to debug a memory leak in .NET Core.
ms.topic: tutorial
ms.date: 04/20/2020
recommendations: false
---

# Debug a memory leak in .NET Core

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

A memory leak may happen when your app references objects that it no longer needs to perform the desired task. Referencing said objects makes the garbage collector to be unable to reclaim the memory used, often resulting in performance degradation and potentially end up throwing a <xref:System.OutOfMemoryException>.

This tutorial demonstrates the tools to analyze a memory leak in a .NET Core app using the .NET diagnostics CLI tools. If you are on Windows, you may be able to [use Visual Studio's Memory Diagnostic tools](/visualstudio/profiling/memory-usage) to debug the memory leak.

This tutorial uses a sample app, which is designed to intentionally leak memory. The sample is provided as an exercise. You can analyze an app that is unintentionally leaking memory too.

In this tutorial, you will:

> [!div class="checklist"]
>
> - Examine managed memory usage with [dotnet-counters](dotnet-counters.md).
> - Generate a dump file.
> - Analyze the memory usage using the dump file.

## Prerequisites

The tutorial uses:

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version.
- [dotnet-counters](dotnet-counters.md) to check managed memory usage.
- [dotnet-dump](dotnet-dump.md) to collect and analyze a dump file.
- A [sample debug target](/samples/dotnet/samples/diagnostic-scenarios/) app to diagnose.

The tutorial assumes the sample and tools are installed and ready to use.

## Examine managed memory usage

Before you start collecting diagnostics data to help us root cause this scenario, you need to make sure you're actually seeing a memory leak (memory growth). You can use the [dotnet-counters](dotnet-counters.md) tool to confirm that.

Open a console window and navigate to the directory where you downloaded and unzipped the [sample debug target](/samples/dotnet/samples/diagnostic-scenarios/). Run the target:

```dotnetcli
dotnet run
```

From a separate console, find the process ID:

```console
dotnet-counters ps
```

The output should be similar to:

```console
4807 DiagnosticScena /home/user/git/samples/core/diagnostics/DiagnosticScenarios/bin/Debug/netcoreapp3.0/DiagnosticScenarios
```

Now, check managed memory usage with the [dotnet-counters](dotnet-counters.md) tool. The `--refresh-interval` specifies the number of seconds between refreshes:

```console
dotnet-counters monitor --refresh-interval 1 -p 4807
```

The live output should be similar to:

```console
Press p to pause, r to resume, q to quit.
    Status: Running

[System.Runtime]
    # of Assemblies Loaded                           118
    % Time in GC (since last GC)                       0
    Allocation Rate (Bytes / sec)                 37,896
    CPU Usage (%)                                      0
    Exceptions / sec                                   0
    GC Heap Size (MB)                                  4
    Gen 0 GC / sec                                     0
    Gen 0 Size (B)                                     0
    Gen 1 GC / sec                                     0
    Gen 1 Size (B)                                     0
    Gen 2 GC / sec                                     0
    Gen 2 Size (B)                                     0
    LOH Size (B)                                       0
    Monitor Lock Contention Count / sec                0
    Number of Active Timers                            1
    ThreadPool Completed Work Items / sec             10
    ThreadPool Queue Length                            0
    ThreadPool Threads Count                           1
    Working Set (MB)                                  83
```

Focusing on this line:

```console
    GC Heap Size (MB)                                  4
```

You can see that the managed heap memory is 4 MB right after startup.

Now, hit the URL `https://localhost:5001/api/diagscenario/memleak/20000`.

Observe that the memory usage has grown to 30 MB.

```console
    GC Heap Size (MB)                                 30
```

By watching the memory usage, you can safely say that memory is growing or leaking. The next step is to collect the right data for memory analysis.

### Generate memory dump

When analyzing possible memory leaks, you need access to the app's memory heap. Then you can analyze the memory contents. Looking at relationships between objects, you create theories on why memory isn't being freed. A common diagnostics data source is a memory dump on Windows or the equivalent core dump on Linux. To generate a dump of a .NET Core application, you can use the [dotnet-dump](dotnet-dump.md) tool.

Using the [sample debug target](/samples/dotnet/samples/diagnostic-scenarios/) previously started, run the following command to generate a Linux core dump:

```dotnetcli
dotnet-dump collect -p 4807
```

The result is a core dump located in the same folder.

```console
Writing minidump with heap to ./core_20190430_185145
Complete
```

### Restart the failed process

Once the dump is collected, you should have sufficient information to diagnose the failed process. If the failed process is running on a production server, now it's the ideal time for short-term remediation by restarting the process.

In this tutorial, you're now done with the [Sample debug target](/samples/dotnet/samples/diagnostic-scenarios/) and you can close it. Navigate to the terminal that started the server, and press <kbd>Ctrl+C</kbd>.

### Analyze the core dump

Now that you have a core dump generated, use the [dotnet-dump](dotnet-dump.md) tool to analyze the dump:

```dotnetcli
dotnet-dump analyze core_20190430_185145
```

Where `core_20190430_185145` is the name of the core dump you want to analyze.

> [!NOTE]
> If you see an error complaining that *libdl.so* cannot be found, you may have to install the *libc6-dev* package. For more information, see [Prerequisites for .NET Core on Linux](../install/linux.md).

You'll be presented with a prompt where you can enter SOS commands. Commonly, the first thing you want to look at is the overall state of the managed heap:

```console
> dumpheap -stat

Statistics:
              MT    Count    TotalSize Class Name
...
00007f6c1eeefba8      576        59904 System.Reflection.RuntimeMethodInfo
00007f6c1dc021c8     1749        95696 System.SByte[]
00000000008c9db0     3847       116080      Free
00007f6c1e784a18      175       128640 System.Char[]
00007f6c1dbf5510      217       133504 System.Object[]
00007f6c1dc014c0      467       416464 System.Byte[]
00007f6c21625038        6      4063376 testwebapi.Controllers.Customer[]
00007f6c20a67498   200000      4800000 testwebapi.Controllers.Customer
00007f6c1dc00f90   206770     19494060 System.String
Total 428516 objects
```

Here you can see that most objects are either `String` or `Customer` objects.

You can use the `dumpheap` command again with the method table (MT) to get a list of all the `String` instances:

```console
> dumpheap -mt 00007faddaa50f90

         Address               MT     Size
...
00007f6ad09421f8 00007faddaa50f90       94
...
00007f6ad0965b20 00007f6c1dc00f90       80
00007f6ad0965c10 00007f6c1dc00f90       80
00007f6ad0965d00 00007f6c1dc00f90       80
00007f6ad0965df0 00007f6c1dc00f90       80
00007f6ad0965ee0 00007f6c1dc00f90       80

Statistics:
              MT    Count    TotalSize Class Name
00007f6c1dc00f90   206770     19494060 System.String
Total 206770 objects
```

You can now use the `gcroot` command on a `System.String` instance to see how and why the object is rooted. Be patient because this command takes several minutes with a 30-MB heap:

```console
> gcroot -all 00007f6ad09421f8

Thread 3f68:
    00007F6795BB58A0 00007F6C1D7D0745 System.Diagnostics.Tracing.CounterGroup.PollForValues() [/_/src/System.Private.CoreLib/shared/System/Diagnostics/Tracing/CounterGroup.cs @ 260]
        rbx:  (interior)
            ->  00007F6BDFFFF038 System.Object[]
            ->  00007F69D0033570 testwebapi.Controllers.Processor
            ->  00007F69D0033588 testwebapi.Controllers.CustomerCache
            ->  00007F69D00335A0 System.Collections.Generic.List`1[[testwebapi.Controllers.Customer, DiagnosticScenarios]]
            ->  00007F6C000148A0 testwebapi.Controllers.Customer[]
            ->  00007F6AD0942258 testwebapi.Controllers.Customer
            ->  00007F6AD09421F8 System.String

HandleTable:
    00007F6C98BB15F8 (pinned handle)
    -> 00007F6BDFFFF038 System.Object[]
    -> 00007F69D0033570 testwebapi.Controllers.Processor
    -> 00007F69D0033588 testwebapi.Controllers.CustomerCache
    -> 00007F69D00335A0 System.Collections.Generic.List`1[[testwebapi.Controllers.Customer, DiagnosticScenarios]]
    -> 00007F6C000148A0 testwebapi.Controllers.Customer[]
    -> 00007F6AD0942258 testwebapi.Controllers.Customer
    -> 00007F6AD09421F8 System.String

Found 2 roots.
```

You can see that the `String` is directly held by the `Customer` object and indirectly held by a `CustomerCache` object.

You can continue dumping out objects to see that most `String` objects follow a similar pattern. At this point, the investigation provided sufficient information to identify the root cause in your code.

This general procedure allows you to identify the source of major memory leaks.

## Clean up resources

In this tutorial, you started a sample web server. This server should have been shut down as explained in the [Restart the failed process](#restart-the-failed-process) section.

You can also delete the dump file that was created.

## See also

- [dotnet-trace](dotnet-trace.md) to list processes
- [dotnet-counters](dotnet-counters.md) to check managed memory usage
- [dotnet-dump](dotnet-dump.md) to collect and analyze a dump file
- [dotnet/diagnostics](https://github.com/dotnet/diagnostics/tree/main/documentation/tutorial)
- [Use Visual Studio to debug memory leaks](/visualstudio/profiling/memory-usage)

## Next steps

> [!div class="nextstepaction"]
> [Debug high CPU in .NET Core](debug-highcpu.md)
