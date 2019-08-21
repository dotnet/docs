---
title: dotnet-trace - .NET Core
description: Installing and using the dotnet-trace command line tool.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/05/2019
---
# Trace for performance analysis utility (dotnet-trace)

The dotnet-trace tool is a cross-platform CLI global tool that enables the collection of .NET Core traces of a running process without any native profiler involved. It is built around the EventPipe technology of the .NET Core runtime as a cross-platform alternative to ETW on Windows and LTTng on Linux, which only work on a single platform. With EventPipe/dotnet-trace, we are trying to deliver the same experience on Windows, Linux, or macOS. dotnet-trace can be used on any .NET Core applications using versions .NET Core 3.0 Preview 5 or later.

## Installing dotnet-trace

The first step is to install the dotnet-trace CLI global tool.

```cmd
$ dotnet tool install --global dotnet-trace --version 3.0.0-preview8.19412.1
You can invoke the tool using the following command: dotnet-trace
Tool 'dotnet-trace' (version '3.0.0-preview8.19412.1') was successfully installed.
```

## Using dotnet-trace

In order to collect traces using dotnet-trace, you will need to:

- First, find out the process identifier (pid) of the .NET Core 3.0 application (using builds Preview 5 or after) to collect traces from.

  - On Windows, there are options such as using the task manager or the `tasklist` command on the cmd window.
  - On Linux, the trivial option could be using `pidof` on the terminal window.

You may also use the command `dotnet-trace list-processes` command to find out what .NET Core processes are running, along with their process IDs.

- Then, run the following command:

```cmd
dotnet-trace collect --process-id <PID> --providers Microsoft-Windows-DotNETRuntime

Press <Enter> to exit...
Connecting to process: <Full-Path-To-Process-Being-Profiled>/dotnet.exe
Collecting to file: <Full-Path-To-Trace>/trace.nettrace
  Session Id: <SessionId>
  Recording trace 721.025 (KB)
```

- Finally, stop collection by pressing the \<Enter> key, and *dotnet-trace* will finish logging events to *trace.nettrace* file.

### Using dotnet-trace to collect counter values over time

If you are trying to use EventCounter for basic health monitoring in  performance-sensitive settings like production environments and you want to collect traces instead of watching them in real-time, you can do that with `dotnet-trace` as well.

For example, if you want to enable and collect runtime performance counter values, you can use the following command:
```cmd
dotnet-trace collect --process-id <PID> --providers System.Runtime:0:1:EventCounterIntervalSec=1
```

This will tell the runtime counters to be reported once every second for lightweight health monitoring. Replacing `EventCounterIntervalSec=1` with a higher value (say 60) will allow you to collect a smaller trace with less granularity in the counter data.

If you want to disable runtime events to reduce the overhead (and trace size) even further, you can use the following command to disable runtime events and managed stack profiler.
```cmd
dotnet-trace collect --process-id <PID> --providers System.Runtime:0:1:EventCounterIntervalSec=1,Microsoft-Windows-DotNETRuntime:0:1,Microsoft-DotNETCore-SampleProfiler:0:1
```
 

## Viewing the trace captured from dotnet-trace

On Windows, `.nettrace` files can be viewed on PerfView (https://github.com/microsoft/perfview) for analysis, just like traces collected with ETW or LTTng. For traces collected on Linux, you can either move the trace to a Windows machine to be viewed on PerfView.

If you would rather view the trace on a Linux machine, you can do this by changing the output format of `dotnet-trace` to `speedscope`. You can change the output file format using the `-f|--format` option - `-f speedscope` will make `dotnet-trace` to produce a speedscope file. You can currently choose between `nettrace` (the default option) and `speedscope`. Speedscope files can be opened at https://www.speedscope.app.

Note: The .NET Core runtime generates traces in the `nettrace` format, and are converted to speedscope (if specified) after the trace is completed. Since some conversions may result in loss of data, the original `nettrace` file is preserved next to the converted file.

## Known Caveats

- Perfview/VS aren't showing any callstacks

There was a regression in Preview6 (https://github.com/dotnet/coreclr/issues/25046) that dropped these callstacks. It has since been fixed in daily builds. If you want to demo callstacks you can use either Preview5, Preview7 which will be out soon, or daily builds.


- "dotnet-trace used to work but now it's giving me `Unable to create a session`"

Between .NET Core Preview 5 and Preview 6, there were breaking changes in the runtime. To use the Preview 6 version of dotnet-trace, you need to be using it on an application with Preview 6 of the runtime, and the same holds for the other way around - To trace an application using .NET Core Preview 6 or later, you need to use the latest version of dotnet-trace.



## Commonly used keywords for the *Microsoft-Windows-DotNETRuntime* provider

 Runtime keyword name           | Keyword Value     | Description
 ------------------------------ | ----------------: | ------------
None                            |                 0 |
All                             |  FFFFFFFFFFFFFFBF | All does not include start-enumeration.  It just is not that useful.
GC                              |                 1 | Logging when garbage collections and finalization happen.
GCHandle                        |                 2 | Events when GC handles are set or destroyed.
Binder                          |                 4 |
Loader                          |                 8 | Logging when modules actually get loaded and unloaded.
Jit                             |                10 | Logging when Just in time (JIT) compilation occurs.
NGen                            |                20 | Logging when precompiled native (NGEN) images are loaded.
StartEnumeration                |                40 | Indicates that on attach or module load, a rundown of all existing methods should be done.
StopEnumeration                 |                80 | Indicates that on detach or process shutdown, a rundown of all existing methods should be done.
Security                        |               400 | Events associated with validating security restrictions.
AppDomainResourceManagement     |               800 | Events for logging resource consumption on an app-domain level granularity.
JitTracing                      |              1000 | Logging of the internal workings of the Just In Time compiler. This is fairly verbose. It details decisions about interesting optimization (like inlining and tail call).
Interop                         |              2000 | Log information about code thunks that transition between managed and unmanaged code.
Contention                      |              4000 | Log when lock contention occurs. (Monitor.Enters actually blocks).
Exception                       |              8000 | Log exception processing.
Threading                       |             10000 | Log events associated with the threadpool, and other threading events.
JittedMethodILToNativeMap       |             20000 | Dump the native to IL mapping of any method that is JIT compiled. (V4.5 runtimes and above).
OverrideAndSuppressNGenEvents   |             40000 | If enabled will suppress the rundown of NGEN events on V4.0 runtime (has no effect on Pre-V4.0 runtimes).
SupressNGen                     |             40000 | This suppresses NGEN events on V4.0 (where you have NGEN PDBs), but not on V2.0 (which does not know about this bit and also does not have NGEN PDBS).
JITSymbols                      |             60098 | What is needed to get symbols for JIT compiled code.<br>This is equivalent to `Jit+JittedMethodILToNativeMap+Loader+OverrideAndSuppressNGenEvents+StopEnumeration`
Type                            |             80000 | Enables the 'BulkType' event.
GCHeapDump                      |            100000 | Enables the events associated with dumping the GC heap.
GCSampledObjectAllocationHigh   |            200000 | Enables allocation sampling with the 'fast'. Sample to limit to 100 allocations per second per type. This is good for most detailed performance investigations.<br>Note that this DOES update the allocation path to be slower and only works if the process start with this on.
GCHeapSurvivalAndMovement       |            400000 | Enables events associate with object movement or survival with each GC.
GCHeapCollect                   |            800000 | Triggers a GC. Can pass a 64 bit value that will be logged with the GC Start event so you know which GC you actually triggered.
GCHeapAndTypeNames              |           1000000 | Indicates that you want type names looked up and put into the events (not just meta-data tokens).
GCHeapSnapshot                  |           1980001 | This provides the flags commonly needed to take a heap .NET Heap snapshot with EventPipe.<br>This is equivalent to `GC+Type+GCHeapDump+GCHeapCollect+GCHeapAndTypeNames`
GCSampledObjectAllocationLow    |           2000000 | Enables allocation sampling with the 'slow' rate, Sample to limit to 5 allocations per second per type. This is reasonable for monitoring. Note that this DOES update the allocation path to be slower and only works if the process start with this on.
GCAllObjectAllocation           |           2200000 | Turns on capturing the stack and type of object allocation made by the .NET Runtime. This is only supported after V4.5.3 (Late 2014) This can be very verbose and you should seriously using GCSampledObjectAllocationHigh instead (and GCSampledObjectAllocationLow for production scenarios).
Stack                           |          40000000 | Also log the stack trace of events for which this is valuable.
ThreadTransfer                  |          80000000 | This allows tracing work item transfer events (thread pool enqueue/dequeue/ioenqueue/iodequeue/a.o.).
Debugger                        |         100000000 | .NET Debugger events
Monitoring                      |         200000000 | Events intended for monitoring on an ongoing basis.
Codesymbols                     |         400000000 | Events that will dump PDBs of dynamically generated assemblies to the EventPipe stream.
Default                         |         4C14FCCBD | Recommend default flags (good compromise on verbosity).

[source](https://github.com/Microsoft/perfview/blob/master/src/TraceEvent/Parsers/ClrTraceEventParser.cs#L41)

## More information on .NET Providers

 Provider Name                          | Information
 -------------------------------------: | ------------
Microsoft-Windows-DotNETRuntime         | [The Runtime Provider](https://docs.microsoft.com/en-us/dotnet/framework/performance/clr-etw-providers#the-runtime-provider)<br>[CLR Runtime Keywords](https://docs.microsoft.com/en-us/dotnet/framework/performance/clr-etw-keywords-and-levels#runtime)
Microsoft-Windows-DotNETRuntimeRundown  | [The Rundown Provider](https://docs.microsoft.com/en-us/dotnet/framework/performance/clr-etw-providers#the-rundown-provider)<br>[CLR Rundown Keywords](https://docs.microsoft.com/en-us/dotnet/framework/performance/clr-etw-keywords-and-levels#rundown)
Microsoft-DotNETCore-SampleProfiler     | Enable the sample profiler

## *dotnet-trace* help

```cmd
dotnet.exe run -c Release --no-restore --no-build -- collect --help

collect:
  Collects a diagnostic trace from a currently running process

Usage:
  dotnet-trace collect [options]

Options:
  -h, --help
    Shows this help message and exit.

  -p, --process-id <pid>
    The process to collect the trace from

  -o, --output <trace-file-path>
    The output path for the collected trace data. If not specified it defaults to 'trace.nettrace'

  --profile
      A named pre-defined set of provider configurations that allows common tracing scenarios to be specified
      succinctly. The options are:
      runtime-basic   Useful for tracking CPU usage and general runtime information. This the default option
                      if no profile is specified.
      gc              Tracks allocation and collection performance
      gc-collect      Tracks GC collection only at very low overhead
      none            Tracks nothing. Only providers specified by the --providers option will be available.

  --providers <list-of-comma-separated-providers>
    A list of comma separated EventPipe providers to be enabled.
    This option adds to the configuration already provided via the --profile argument. If the same provider is configured in both places, this option takes precedence.
    A provider consists of the name and optionally the keywords, verbosity level, and custom key/value pairs.

    The string is written 'Provider[,Provider]'
        Provider format: KnownProviderName[:Keywords[:Level][:KeyValueArgs]]
            KnownProviderName       - The provider's name
            Keywords                - 8 character hex number bit mask
            Level                   - A number in the range [0, 5]
                0 - Always
                1 - Critical
                2 - Error
                3 - Warning
                4 - Informational
                5 - Verbose
            KeyValueArgs            - A semicolon separated list of key=value
        KeyValueArgs format: '[key1=value1][;key2=value2]' 
            note: values that contain ';' or '=' characters should be surrounded by double quotes ("), e.g., 'key="value;with=symbols";key2=value2'

  --buffersize <Size>
    Sets the size of the in-memory circular buffer in megabytes. Default 256 MB.

  -f, --format
    The format of the output trace file.  This defaults to "nettrace" on Windows and "speedscope" on other OSes.
