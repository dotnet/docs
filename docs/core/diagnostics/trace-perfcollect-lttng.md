---
title: Tracing .NET applications with LTTng.
description: A tutorial that walks you through collecting a trace with LTTng and perfcollect in .NET.
ms.topic: tutorial
ms.date: 10/23/2020
---

# Tracing .NET applications with LTTng and PerfCollect

**This article applies to: ✔️** .NET Core 2.1 SDK and later versions

When a performance problem is encountered on Linux, collecting a trace with `perfcollect` can be used to gather detailed information about what was happening on the machine at the time of the performance problem.

`perfcollect` is a bash script that leverages [Linux Tracing Tookit-Next Generation (LTTng)](https://lttng.org) to collect events written from the runtime or any [EventSource](xref:System.Diagnostics.Tracing.EventListener), as well as [perf](https://perf.wiki.kernel.org/) to collect CPU samples of the target process.

## Preparing Your Machine

Follow these steps to prepare your machine to collect a performance trace with `perfcollect`.

1. Download `perfcollect`.

    > ```bash
    > curl -OL http://aka.ms/perfcollect
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

    1. `perf`: the Linux Performance Events sub-system and companion user-mode collection/viewer application. `perf` is part of the Linux kernel source, but is not usually installed by default.

    2. `LTTng`: Used to capture event data emitted at runtime by CoreCLR. This data is then used to analyze the behavior of various runtime components such as the GC, JIT and thread pool.

## Collecting a Trace

1. Have two shells available - one for controlling tracing, referred to as **[Trace]**, and one for running the application, referred to as **[App]**.

2. **[App]** Setup the application shell with the following environment variables - this enables tracing configuration of CoreCLR.

    > ```bash
    > export COMPlus_PerfMapEnabled=1
    > export COMPlus_EnableEventLog=1
    > ```

3. **[Trace]** Start collection.

    > ```bash
    > sudo ./perfcollect collect sampleTrace
    > ```

    Expected Output:

    > ```bash
    > Collection started.  Press CTRL+C to stop.
    > ```

4. **[App]** Run the app - let it run as long as you need to in order to capture the performance problem.

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

## Resolving Framework Symbols

Framework symbols need to be manually generated at the time the trace is collected. They are different than app-level symbols because the framework is pre-compiled while apps are just-in-time-compiled. For code like the framework that was precompiled to native code, you need a special tool called crossgen that knows how to generate the mapping from the native code to the name of the methods.

`perfcollect` can handle most of the details for you, but it needs to have the crossgen tool and by default this is not part of the standard .NET distribution. If it is not there it warns you and refers you to these instructions. To fix things you need to fetch exactly the right version of crossgen for the runtime you happen to be using. If you place the crossgen tool in the same directory as the .NET Runtime DLLs (e.g. libcoreclr.so), then `perfcollect` can find it and add the framework symbols to the trace file for you.

Normally when you create a .NET application, it just generates the DLL for the code you wrote, using a shared copy of the runtime for the rest.   However you can also generate what is called a 'self-contained' version of an application and this contains all runtime DLLs. The crossgen tool is part of the Nuget package that is used to create self-contained apps, so one way of getting the right crossgen tool is to create a self-contained package of your application.

For example:

   >```bash
   > mkdir helloWorld
   > cd helloWorld
   > dotnet new console
   > dotnet publish --self-contained -r linux-x64
   >```

This creates a new Hello World application and builds it as a self-contained app. Note that if you have multiple versions of the .NET Runtime installed, the instructions above will use the latest. As long as your app also uses the latest (likely) then these instructions will work without modification.

As a side effect of creating the self-contained application the dotnet tool will download a nuget package called runtime.linux-x64.microsoft.netcore.app and place it in the directory ~/.nuget/packages/runtime.linux-x64.microsoft.netcore.app/VERSION, where VERSION is the version number of your .NET Core runtime (e.g. 2.1.0). Under that is a tools directory and inside there is the crossgen tool you need. Starting with .NET Core 3.0, the package location is ~/.nuget/packages/microsoft.netcore.app.runtime.linux-x64/VERSION.

The `crossgen` tool needs to be put next to the runtime that is actually used by your application. Typically your app uses the shared version of .NET Core that is installed at /usr/share/dotnet/shared/Microsoft.NETCore.App/VERSION where VERSION is the version number of the .NET Runtime. This is a shared location, so you need to be super-user to modify it. If the VERSION is 2.1.0 the commands to update `crossgen` would be:

   >```bash
   > sudo bash
   > cp ~/.nuget/packages/runtime.linux-x64.microsoft.netcore.app/2.1.0/tools/crossgen /usr/share/dotnet/shared/Microsoft.NETCore.App/2.1.0
   >```

Once you have done this, `perfcollect` will use crossgen to include framework symbols. The warning that `perfcollect` used to issue should go away. This only has to be one once per machine (until you update your runtime).

### Alternative: Turn off use of precompiled code

If you don't have the ability to update the .NET Runtime (to add `crossgen`), or if the above procedure did not work for some reason, there is another approach to getting framework symbols. You can tell the runtime to simply not use the precompiled framework code. The code will be Just-In-Time compiled and the `crossgen` tool is not needed.

> [!NOTE]
> Choosing this approach may increase the startup time for your application.

To do this, you can add the following environment variable:

```bash
export COMPlus_ZapDisable=1
```

With this change you should get the symbols for all .NET code.

## Getting Symbols For the Native Runtime

Most of the time you are interested in your own code, which `perfcollect` resolves by default. Sometimes it is very useful to see what is going on inside the .NET DLLs (which is what the last section was about), but sometimes what is going on in the native runtime dlls (typically libcoreclr.so), is interesting.  `perfcollect` will resolve the symbols for these when it converts its data, but only if the symbols for these native DLLs are present (and are beside the library they are for).

There is a global command called [dotnet-symbol](https://github.com/dotnet/symstore/blob/master/src/dotnet-symbol/README.md#symbol-downloader-dotnet-cli-extension) which does this. To use dotnet-symbol to get native runtime symbols:

1. Install `dotnet-symbol`:

    ```bash
    dotnet tool install -g dotnet-symbol
    ```

2. Download the symbols. If your installed version of the .NET Core runtime is 2.1.0 the command to do this is

    ```bash
    mkdir mySymbols
    dotnet symbol --symbols --output mySymbols  /usr/share/dotnet/shared/Microsoft.NETCore.App/2.1.0/lib*.so
    ```

3. Copy the symbols to the correct place

    ```bash
    sudo cp mySymbols/* /usr/share/dotnet/shared/Microsoft.NETCore.App/2.1.0
    ```

After this, you should get symbolic names for the native dlls when you run `perfcollect`.

## Collecting in a Docker Container

For more information on how to use `perfcollect` in container environments, refer to [Collect diagnostics in containers](./diagnostics-in-containers.md) documentation.

## Viewing a Trace

Traces are best viewed using PerfView on Windows.  Note that we're currently looking into porting the analysis pieces of PerfView to Linux so that the entire investigation can occur on Linux.

### Open the Trace File

1. Copy the trace.zip file from Linux to a Windows machine.

2. Download PerfView from <http://aka.ms/perfview>.

3. Run PerfView.exe

    > ```cmd
    > PerfView.exe <path to trace.zip file>
    > ```

### Select a View

PerfView will display the list of views that are supported based on the data contained in the trace file.

- For CPU investigations, choose **CPU stacks**.

- For very detailed GC information, choose **GCStats**.

- For per-process/module/method JIT information, choose **JITStats**.

- If there is not a view for the information you need, you can try looking for the events in the raw events view.  Choose **Events**.

For more details on how to interpret views in PerfView, see help links in the view itself, or from the main window in PerfView choose **Help->Users Guide**.
