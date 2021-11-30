---
title: Tracing .NET applications with PerfCollect.
description: A tutorial that walks you through collecting a trace with perfcollect in .NET.
ms.topic: tutorial
ms.date: 10/23/2020
---

# Trace .NET applications with PerfCollect

**This article applies to: ✔️** .NET Core 2.1 SDK and later versions

When performance problems are encountered on Linux, collecting a trace with `perfcollect` can be used to gather detailed information about what was happening on the machine at the time of the performance problem.

`perfcollect` is a bash script that uses [Linux Trace Toolkit: next generation (LTTng)](https://lttng.org) to collect events written from the runtime or any [EventSource](xref:System.Diagnostics.Tracing.EventListener), as well as [perf](https://perf.wiki.kernel.org/) to collect CPU samples of the target process.

## Prepare your machine

Follow these steps to prepare your machine to collect a performance trace with `perfcollect`.

> [!NOTE]
> If you are in a container environment, your container needs to have `SYS_ADMIN` capability. For more information on tracing applications inside containers using PerfCollect, see [Collect diagnostics in containers](./diagnostics-in-containers.md).

1. Download `perfcollect`.

    > ```bash
    > curl -OL https://aka.ms/perfcollect
    > ```

2. Make the script executable.

    > ```bash
    > chmod +x perfcollect
    > ```

3. Install tracing prerequisites - these are the actual tracing libraries.

    > ```bash
    > sudo ./perfcollect install
    > ```

    This will install the following prerequisites on your machine:

    1. `perf`: the Linux Performance Events subsystem and companion user-mode collection/viewer application. `perf` is part of the Linux kernel source, but is not usually installed by default.

    2. `LTTng`: Used to capture event data emitted at run time by CoreCLR. This data is then used to analyze the behavior of various runtime components such as the GC, JIT, and thread pool.

Recent versions of .NET Core and the Linux perf tool support automatic resolution of method names for framework code. If you are working with .NET Core version 3.1 or less, an extra step is necessary. See [Resolving Framework Symbols](#resolve-framework-symbols) for details.

For resolving method names of native runtime DLLs (such as libcoreclr.so), `perfcollect` will resolve symbols for them when it converts the data, but only if the symbols for these binaries are present. See [Getting Symbols for the Native Runtime](#get-symbols-for-the-native-runtime) section for details.

## Collect a trace

1. Have two shells available - one for controlling tracing, referred to as **[Trace]**, and one for running the application, referred to as **[App]**.

2. **[Trace]** Start collection.

    > ```bash
    > sudo ./perfcollect collect sampleTrace
    > ```

    Expected Output:

    > ```bash
    > Collection started.  Press CTRL+C to stop.
    > ```

3. **[App]** Set up the application shell with the following environment variables - this enables tracing configuration of CoreCLR.

    > ```bash
    > export DOTNET_PerfMapEnabled=1
    > export DOTNET_EnableEventLog=1
    > ```

   [!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

4. **[App]** Run the app - let it run as long as you need to in order to capture the performance problem. The exact length can be as short as you need as long as it sufficiently captures the window of time where the performance problem you want to investigate occurs.

    > ```bash
    > dotnet run
    > ```

5. **[Trace]** Stop collection - hit CTRL+C.

    > ```bash
    > ^C
    > ...STOPPED.
    >
    > Starting post-processing. This may take some time.
    >
    > Generating native image symbol files
    > ...SKIPPED
    > Saving native symbols
    > ...FINISHED
    > Exporting perf.data file
    > ...FINISHED
    > Compressing trace files
    > ...FINISHED
    > Cleaning up artifacts
    > ...FINISHED
    >
    > Trace saved to sampleTrace.trace.zip
    > ```

    The compressed trace file is now stored in the current working directory.

## View a trace

There are a number of options for viewing the trace that was collected. Traces are best viewed using [PerfView](https://aka.ms/perfview) on Windows, but they can be viewed directly on Linux using `PerfCollect` itself or `TraceCompass`.

### Use PerfCollect to view the trace file

You can use perfcollect itself to view the trace that you collected. To do this, use the following command:

```bash
./perfcollect view sampleTrace.trace.zip
```

By default, this will show the CPU trace of the application using `perf`.

To look at the events that were collected via `LTTng`, you can pass in the flag `-viewer lttng` to see the individual events:

```bash
./perfcollect view sampleTrace.trace.zip -viewer lttng
```

This will use `babeltrace` viewer to print the events payload:

```bash
# [01:02:18.189217659] (+0.020132603) ubuntu-xenial DotNETRuntime:ExceptionThrown_V1: { cpu_id = 0 }, { ExceptionType = "System.Exception", ExceptionMessage = "An exception happened", ExceptionEIP = 139875671834775, ExceptionHRESULT = 2148734208, ExceptionFlags = 16, ClrInstanceID = 0 }
# [01:02:18.189250227] (+0.020165171) ubuntu-xenial DotNETRuntime:ExceptionCatchStart: { cpu_id = 0 }, { EntryEIP = 139873639728404, MethodID = 139873626968120, MethodName = "void [helloworld] helloworld.Program::Main(string[])", ClrInstanceID = 0 }
```

### Use PerfView to open the trace file

To see an aggregate view of both the CPU sample and the events, you can use `PerfView` on a Windows machine.

1. Copy the trace.zip file from Linux to a Windows machine.

2. Download PerfView from <https://aka.ms/perfview>.

3. Run PerfView.exe

    > ```cmd
    > PerfView.exe <path to trace.zip file>
    > ```

PerfView will display the list of views that are supported based on the data contained in the trace file.

- For CPU investigations, choose **CPU stacks**.

- For detailed GC information, choose **GCStats**.

- For per-process/module/method JIT information, choose **JITStats**.

- If there is not a view for the information you need, you can try looking for the events in the raw events view.  Choose **Events**.

For more information on how to interpret views in PerfView, see help links in the view itself, or from the main window in PerfView, choose **Help->Users Guide**.

> [!NOTE]
> Events written via <xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType> API (including the events from Framework) won't show up under their provider name. Instead, they are written as `EventSourceEvent` events under `Microsoft-Windows-DotNETRuntime` provider and their payloads are JSON serialized.

### Use TraceCompass to open the trace file

[Eclipse TraceCompass](https://www.eclipse.org/tracecompass/) is another option you can use to view the traces. `TraceCompass` works on Linux machines as well, so you don't need to move your trace over to a Windows machine. To use `TraceCompass` to open your trace file, you will need to unzip the file.

```bash
unzip myTrace.trace.zip
```

`perfcollect` will save the LTTng trace it collected into a CTF file format in a subdirectory in the `lttngTrace`. Specifically, the CTF file will be located in a directory that looks like `lttngTrace/auto-20201025-101230\ust\uid\1000\64-bit\`.

You can open the CTF trace file in `TraceCompass` by selecting `File -> Open Trace` and select the `metadata` file.

For more details, please refer to [`TraceCompass` documentation](https://www.eclipse.org/tracecompass/).

## Resolve framework symbols

Framework symbols need to be manually generated at the time the trace is collected. They are different than app-level symbols because the framework is pre-compiled while app code is just-in-time-compiled. For framework code that was precompiled to native code, you need to call `crossgen` that knows how to generate the mapping from the native code to the name of the methods.

`perfcollect` can handle most of the details for you, but it needs to have `crossgen` available. By default it is not installed with .NET distribution. If `crossgen` is not there, `perfcollect` warns you and refers you to these instructions. To fix things you need to fetch exactly the right version of crossgen for the runtime you are using. If you place the crossgen tool in the same directory as the .NET Runtime DLLs (for example, libcoreclr.so), then `perfcollect` can find it and add the framework symbols to the trace file for you.

Normally when you create a .NET application, it just generates the DLL for the code you wrote, using a shared copy of the runtime for the rest.   However you can also generate what is called a 'self-contained' version of an application and this contains all runtime DLLs. `crossgen` is part of the NuGet package that is used to create self-contained apps, so one way of getting the right version of `crossgen` is to create a self-contained package of your application.

For example:

   >```bash
   > mkdir helloWorld
   > cd helloWorld
   > dotnet new console
   > dotnet publish --self-contained -r linux-x64
   >```

This creates a new Hello World application and builds it as a self-contained app.

As a side effect of creating the self-contained application the dotnet tool will download a NuGet package called runtime.linux-x64.microsoft.netcore.app and place it in the directory ~/.nuget/packages/runtime.linux-x64.microsoft.netcore.app/VERSION, where VERSION is the version number of your .NET Core runtime (for example, 2.1.0). Under that is a tools directory and inside there is the crossgen tool you need. Starting with .NET Core 3.0, the package location is ~/.nuget/packages/microsoft.netcore.app.runtime.linux-x64/VERSION.

The `crossgen` tool needs to be put next to the runtime that is actually used by your application. Typically your app uses the shared version of .NET Core that is installed at /usr/share/dotnet/shared/Microsoft.NETCore.App/VERSION where VERSION is the version number of the .NET Runtime. This is a shared location, so you need to be super-user to modify it. If the VERSION is 2.1.0 the commands to update `crossgen` would be:

   >```bash
   > sudo bash
   > cp ~/.nuget/packages/runtime.linux-x64.microsoft.netcore.app/2.1.0/tools/crossgen /usr/share/dotnet/shared/Microsoft.NETCore.App/2.1.0
   >```

Once you have done this, `perfcollect` will use crossgen to include framework symbols. The warning that `perfcollect` used to issue should go away. This only has to be one once per machine (until you update your runtime).

### Alternative: Turn off use of precompiled code

If you don't have the ability to update the .NET Runtime (to add `crossgen`), or if the above procedure did not work for some reason, there is another approach to getting framework symbols. You can tell the runtime to simply not use the precompiled framework code. The code will be Just-In-Time compiled and `crossgen` is not needed.

> [!NOTE]
> Choosing this approach may increase the startup time for your application.

To do this, you can add the following environment variable:

```bash
export DOTNET_ZapDisable=1
```

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

With this change, you should get the symbols for all .NET code.

## Get symbols for the native runtime

Most of the time you are interested in your own code, which `perfcollect` resolves by default. Sometimes it is useful to see what is going on inside the .NET DLLs (which is what the last section was about), but sometimes what is going on in the native runtime dlls (typically libcoreclr.so), is interesting.  `perfcollect` will resolve the symbols for these when it converts its data, but only if the symbols for these native DLLs are present (and are beside the library they are for).

There is a global command called [dotnet-symbol](https://github.com/dotnet/symstore/blob/main/src/dotnet-symbol/README.md#symbol-downloader-dotnet-cli-extension) that does this. To use dotnet-symbol to get native runtime symbols:

1. Install `dotnet-symbol`:

    ```bash
    dotnet tool install -g dotnet-symbol
    ```

2. Download the symbols. If your installed version of the .NET Core runtime is 2.1.0, the command to do this is:

    ```bash
    mkdir mySymbols
    dotnet symbol --symbols --output mySymbols  /usr/share/dotnet/shared/Microsoft.NETCore.App/2.1.0/lib*.so
    ```

3. Copy the symbols to the correct place.

    ```bash
    sudo cp mySymbols/* /usr/share/dotnet/shared/Microsoft.NETCore.App/2.1.0
    ```

    If this cannot be done because you do not have write access to the appropriate directory, you can use `perf buildid-cache` to add the symbols.

After this, you should get symbolic names for the native dlls when you run `perfcollect`.

## Collect in a Docker container

For more information on how to use `perfcollect` in container environments, see [Collect diagnostics in containers](./diagnostics-in-containers.md).

## Learn more about collection options

You can specify the following optional flags with `perfcollect` to better suit your diagnostic needs.

### Collect for a specific duration

When you want to collect a trace for a specific duration, you can use `-collectsec` option followed by a number specifying the total seconds to collect a trace for.

### Collect threadtime traces

Specifying `-threadtime` with `perfcollect` lets you collect per-thread CPU usage data. This lets you analyze where every thread was spending its CPU time.

### Collect traces for managed memory and garbage collector performance

The following options let you specifically collect the GC events from the runtime.

* `perfcollect collect -gccollectonly`

Collect only a minimal set of GC Collection events. This is the least verbose GC eventing collection profile with the lowest impact on the target app's performance. This command is analogous to `PerfView.exe /GCCollectOnly collect` command in PerfView.

* `perfcollect collect -gconly`

Collect more verbose GC collection events with JIT, Loader, and Exception events. This requests more verbose events (such as the allocation information and GC join information) and will have more impact to the target app's performance than `-gccollectonly` option. This command is analogous to `PerfView.exe /GCOnly collect` command in PerfView.

* `perfcollect collect -gcwithheap`

Collect the most verbose GC collection events, which tracks the heap survival and movements as well. This gives in-depth analysis of the GC behavior but will incur high performance cost as each GC can take more than two times longer. It is recommended you understand the performance implication of using this trace option when tracing in production environments.
