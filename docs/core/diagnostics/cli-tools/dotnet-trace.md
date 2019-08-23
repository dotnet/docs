---
title: dotnet-trace - .NET Core
description: Installing and using the dotnet-trace command-line tool.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/21/2019
---
# Trace for performance analysis utility (`dotnet-trace`)

The `dotnet-trace` tool is a cross-platform CLI global tool that enables the collection of .NET Core traces of a running process without any native profiler involved. It's built around the `EventPipe` technology of the .NET Core runtime as a cross-platform alternative to ETW on Windows and LTTng on Linux, which only work on a single platform. With `EventPipe`/`dotnet-trace`, we're trying to deliver the same experience on Windows, Linux, or macOS.

> [!NOTE]
> `dotnet-trace` can be used on any .NET Core applications using versions .NET Core 3.0 Preview 7 or later.

## Installing `dotnet-trace`

To install the latest release version of the `dotnet-trace` [NuGet package](https://www.nuget.org/packages/dotnet-trace):

```
dotnet tool install --global dotnet-trace
```

For details and other options, see [Installing the diagnostics tools](installing.md).

## `dotnet-trace` help

```bash
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
```

## Collect a trace with `dotnet-trace`

To collect traces, using `dotnet-trace`, you'll need to:

- First, find out the process identifier (pid) of the .NET Core application to collect traces from.

  - On Windows, there are options such as using the task manager or the `tasklist` command on the cmd window.
  - On Linux, the trivial option could be using `pidof` on the terminal window.

You may also use the command `dotnet-trace list-processes` command to find out what .NET Core processes are running, along with their process IDs.

- Then, run the following command:

```bash
dotnet-trace collect --process-id <PID>

Press <Enter> to exit...
Connecting to process: <Full-Path-To-Process-Being-Profiled>/dotnet.exe
Collecting to file: <Full-Path-To-Trace>/trace.nettrace
  Session Id: <SessionId>
  Recording trace 721.025 (KB)
```

## Viewing the trace captured from `dotnet-trace`

On Windows, `.nettrace` files can be viewed on [PerfView](https://github.com/microsoft/perfview) for analysis, just like traces collected with ETW or LTTng. For traces collected on Linux, you can either move the trace to a Windows machine to be viewed on PerfView.

You may also view the trace on a Linux machine by changing the output format of `dotnet-trace` to `speedscope`. You can change the output file format using the `-f|--format` option - `-f speedscope` will make `dotnet-trace` to produce a `speedscope` file. You can currently choose between `nettrace` (the default option) and `speedscope`. `Speedscope` files can be opened at https://www.speedscope.app.

Note: The .NET Core runtime generates traces in the `nettrace` format, and they're converted to speedscope (if specified) after the trace is completed. Since some conversions may result in loss of data, the original `nettrace` file is preserved next to the converted file.
- Finally, stop collection by pressing the \<Enter> key, and `dotnet-trace` will finish logging events to *trace.nettrace* file.

## Using `dotnet-trace` to collect counter values over time

If you're trying to use `EventCounter` for basic health monitoring in  performance-sensitive settings like production environments and you want to collect traces instead of watching them in real time, you can do that with `dotnet-trace` as well.

For example, if you want to collect runtime performance counter values, you can use the following command:

```bash
dotnet-trace collect --process-id <PID> --providers System.Runtime:0:1:EventCounterIntervalSec=1
```

This command will tell the runtime counters to be reported once every second for lightweight health monitoring. Replacing `EventCounterIntervalSec=1` with a higher value (say 60) will allow you to collect a smaller trace with less granularity in the counter data.

If you want to disable runtime events to reduce the overhead (and trace size) even further, you can use the following command to disable runtime events and managed stack profiler.

```bash
dotnet-trace collect --process-id <PID> --providers System.Runtime:0:1:EventCounterIntervalSec=1,Microsoft-Windows-DotNETRuntime:0:1,Microsoft-DotNETCore-SampleProfiler:0:1
```

## More information on .NET Providers

The .NET Core runtime supports the following .NET providers. .NET Core uses the same keywords to enable both
`Event Tracing for Windows (ETW)` and `EventPipe` traces.

 Provider Name                          | Information
 ------------------------------------- | ------------
Microsoft-Windows-DotNETRuntime         | [The Runtime Provider](https://docs.microsoft.com/dotnet/framework/performance/clr-etw-providers#the-runtime-provider)<br>[CLR Runtime Keywords](https://docs.microsoft.com/dotnet/framework/performance/clr-etw-keywords-and-levels#runtime)

Microsoft-Windows-DotNETRuntimeRundown  | [The Rundown Provider](https://docs.microsoft.com/dotnet/framework/performance/clr-etw-providers#the-rundown-provider)<br>[CLR Rundown Keywords](https://docs.microsoft.com/dotnet/framework/performance/clr-etw-keywords-and-levels#rundown)
Microsoft-DotNETCore-SampleProfiler     | Enable the sample profiler
