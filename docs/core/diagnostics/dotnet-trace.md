---
title: dotnet-trace diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-trace CLI tool to collect .NET traces of a running process without the native profiler, by using the .NET EventPipe.
ms.date: 11/17/2020
---
# dotnet-trace performance analysis utility

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

## Install

There are two ways to download and install `dotnet-trace`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-trace` [NuGet package](https://www.nuget.org/packages/dotnet-trace), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-trace
  ```

- **Direct download:**

  Download the tool executable that matches your platform:

  | OS  | Platform |
  | --- | -------- |
  | Windows | [x86](https://aka.ms/dotnet-trace/win-x86) \| [x64](https://aka.ms/dotnet-trace/win-x64) \| [arm](https://aka.ms/dotnet-trace/win-arm) \| [arm-x64](https://aka.ms/dotnet-trace/win-arm64) |
  | macOS   | [x64](https://aka.ms/dotnet-trace/osx-x64) |
  | Linux   | [x64](https://aka.ms/dotnet-trace/linux-x64) \| [arm](https://aka.ms/dotnet-trace/linux-arm) \| [arm64](https://aka.ms/dotnet-trace/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-trace/linux-musl-x64) \| [musl-arm64](https://aka.ms/dotnet-trace/linux-musl-arm64) |

## Synopsis

```console
dotnet-trace [-h, --help] [--version] <command>
```

## Description

The `dotnet-trace` tool:

* Is a cross-platform .NET Core tool.
* Enables the collection of .NET Core traces of a running process without a native profiler.
* Is built on [`EventPipe`](./eventpipe.md) of the .NET Core runtime.
* Delivers the same experience on Windows, Linux, or macOS.

## Options

- **`-h|--help`**

  Shows command-line help.

- **`--version`**

  Displays the version of the dotnet-trace utility.

## Commands

| Command                                                   |
|-----------------------------------------------------------|
| [dotnet-trace collect](#dotnet-trace-collect)             |
| [dotnet-trace convert](#dotnet-trace-convert)             |
| [dotnet-trace ps](#dotnet-trace-ps)                       |
| [dotnet-trace list-profiles](#dotnet-trace-list-profiles) |

## dotnet-trace collect

Collects a diagnostic trace from a running process.

### Synopsis

```console
dotnet-trace collect [--buffersize <size>] [--clreventlevel <clreventlevel>] [--clrevents <clrevents>]
    [--format <Chromium|NetTrace|Speedscope>] [-h|--help]
    [-n, --name <name>]  [-o|--output <trace-file-path>] [-p|--process-id <pid>]
    [--profile <profile-name>] [--providers <list-of-comma-separated-providers>]
    [-- <command>] (for target applications running .NET 5.0 or later)
```

### Options

- **`--buffersize <size>`**

  Sets the size of the in-memory circular buffer, in megabytes. Default 256 MB.

- **`--clreventlevel <clreventlevel>`**

  Verbosity of CLR events to be emitted.

- **`--clrevents <clrevents>`**

  List of CLR runtime events to emit.

- **`--format {Chromium|NetTrace|Speedscope}`**

  Sets the output format for the trace file conversion. The default is `NetTrace`.

- **`-n, --name <name>`**

  The name of the process to collect the trace from.

- **`-o|--output <trace-file-path>`**

  The output path for the collected trace data. If not specified, it defaults to `trace.nettrace`.

- **`-p|--process-id <PID>`**

  The process ID to collect the trace from.

- **`--profile <profile-name>`**

  A named pre-defined set of provider configurations that allows common tracing scenarios to be specified succinctly.

- **`--providers <list-of-comma-separated-providers>`**

  A comma-separated list of `EventPipe` providers to be enabled. These providers supplement any providers implied by `--profile <profile-name>`. If there's any inconsistency for a particular provider, this configuration takes precedence over the implicit configuration from the profile.

  This list of providers is in the form:

  - `Provider[,Provider]`
  - `Provider` is in the form: `KnownProviderName[:Flags[:Level][:KeyValueArgs]]`.
  - `KeyValueArgs` is in the form: `[key1=value1][;key2=value2]`.

- **`-- <command>` (for target applications running .NET 5.0 only)**

  After the collection configuration parameters, the user can append `--` followed by a command to start a .NET application with at least a 5.0 runtime. This may be helpful when diagnosing issues that happen early in the process, such as startup performance issue or assembly loader and binder errors.

  > [!NOTE]
  > Using this option monitors the first .NET 5.0 process that communicates back to the tool, which means if your command launches multiple .NET applications, it will only collect the first app. Therefore, it is recommended you use this option on self-contained applications, or using the `dotnet exec <app.dll>` option.

## dotnet-trace convert

Converts `nettrace` traces to alternate formats for use with alternate trace analysis tools.

### Synopsis

```console
dotnet-trace convert [<input-filename>] [--format <Chromium|NetTrace|Speedscope>] [-h|--help] [-o|--output <output-filename>]
```

### Arguments

- **`<input-filename>`**

  Input trace file to be converted. Defaults to *trace.nettrace*.

### Options

- **`--format <Chromium|NetTrace|Speedscope>`**

  Sets the output format for the trace file conversion.

- **`-o|--output <output-filename>`**

  Output filename. Extension of target format will be added.

## dotnet-trace ps

 Lists the dotnet processes that traces can be collected from.

### Synopsis

```console
dotnet-trace ps [-h|--help]
```

## dotnet-trace list-profiles

Lists pre-built tracing profiles with a description of what providers and filters are in each profile.

### Synopsis

```console
dotnet-trace list-profiles [-h|--help]
```

## Collect a trace with dotnet-trace

To collect traces using `dotnet-trace`:

- Get the process identifier (PID) of the .NET Core application to collect traces from.

  - On Windows, you can use Task Manager or the `tasklist` command, for example.
  - On Linux, for example, the `ps` command.
  - [dotnet-trace ps](#dotnet-trace-ps)

- Run the following command:

  ```console
  dotnet-trace collect --process-id <PID>
  ```

  The preceding command generates output similar to the following:

  ```console
  Press <Enter> to exit...
  Connecting to process: <Full-Path-To-Process-Being-Profiled>/dotnet.exe
  Collecting to file: <Full-Path-To-Trace>/trace.nettrace
  Session Id: <SessionId>
  Recording trace 721.025 (KB)
  ```

- Stop collection by pressing the `<Enter>` key. `dotnet-trace` will finish logging events to the *trace.nettrace* file.

## Launch a child application and collect a trace from its startup using dotnet-trace

> [!IMPORTANT]
> This works for apps running .NET 5.0 or later only.

Sometimes it may be useful to collect a trace of a process from its startup. For apps running .NET 5.0 or later, it is possible to do this by using dotnet-trace.

This will launch `hello.exe` with `arg1` and `arg2` as its command-line arguments and collect a trace from its runtime startup:

```console
dotnet-trace collect -- hello.exe arg1 arg2
```

The preceding command generates output similar to the following:

```console
No profile or providers specified, defaulting to trace profile 'cpu-sampling'

Provider Name                           Keywords            Level               Enabled By
Microsoft-DotNETCore-SampleProfiler     0x0000F00000000000  Informational(4)    --profile
Microsoft-Windows-DotNETRuntime         0x00000014C14FCCBD  Informational(4)    --profile

Process        : E:\temp\gcperfsim\bin\Debug\net5.0\gcperfsim.exe
Output File    : E:\temp\gcperfsim\trace.nettrace


[00:00:00:05]   Recording trace 122.244  (KB)
Press <Enter> or <Ctrl+C> to exit...
```

You can stop collecting the trace by pressing `<Enter>` or `<Ctrl + C>` key. Doing this will also exit `hello.exe`.

> [!NOTE]
> Launching `hello.exe` via dotnet-trace will make its input/output to be redirected and you won't be able to interact with its stdin/stdout.
> Exiting the tool via CTRL+C or SIGTERM will safely end both the tool and the child process.
> If the child process exits before the tool, the tool will exit as well and the trace should be safely viewable.

## View the trace captured from dotnet-trace

On Windows, *.nettrace* files can be viewed on [PerfView](https://github.com/microsoft/perfview) for analysis: For traces collected on other platforms, the trace file can be moved to a Windows machine to be viewed on PerfView.

On Linux, the trace can be viewed by changing the output format of `dotnet-trace` to `speedscope`. The output file format can be changed using the `-f|--format` option - `-f speedscope` will make `dotnet-trace` produce a `speedscope` file. You can choose between `nettrace` (the default option) and `speedscope`. `Speedscope` files can be opened at <https://www.speedscope.app>.

> [!NOTE]
> The .NET Core runtime generates traces in the `nettrace` format. The traces are converted to speedscope (if specified) after the trace is completed. Since some conversions may result in loss of data, the original `nettrace` file is preserved next to the converted file.

## Use dotnet-trace to collect counter values over time

`dotnet-trace` can:

* Use `EventCounter` for basic health monitoring in performance-sensitive environments. For example, in production.
* Collect traces so they don't need to be viewed in real time.

For example, to collect runtime performance counter values, use the following command:

```console
dotnet-trace collect --process-id <PID> --providers System.Runtime:0:1:EventCounterIntervalSec=1
```

The preceding command tells the runtime counters to report once every second for lightweight health monitoring. Replacing `EventCounterIntervalSec=1` with a higher value (for example, 60) allows collection of a smaller trace with less granularity in the counter data.

The following command reduces overhead and trace size more than the preceding one:

```console
dotnet-trace collect --process-id <PID> --providers System.Runtime:0:1:EventCounterIntervalSec=1,Microsoft-Windows-DotNETRuntime:0:1,Microsoft-DotNETCore-SampleProfiler:0:1
```

The preceding command disables runtime events and the managed stack profiler.

## .NET Providers

The .NET Core runtime supports the following .NET providers. .NET Core uses the same keywords to enable both
`Event Tracing for Windows (ETW)` and `EventPipe` traces.

| Provider name                            | Information |
|------------------------------------------|-------------|
| `Microsoft-Windows-DotNETRuntime`        | [The Runtime Provider](../../framework/performance/clr-etw-providers.md#the-runtime-provider)<br>[CLR Runtime Keywords](../../framework/performance/clr-etw-keywords-and-levels.md#runtime) |
| `Microsoft-Windows-DotNETRuntimeRundown` | [The Rundown Provider](../../framework/performance/clr-etw-providers.md#the-rundown-provider)<br>[CLR Rundown Keywords](../../framework/performance/clr-etw-keywords-and-levels.md#rundown) |
| `Microsoft-DotNETCore-SampleProfiler`    | Enables the sample profiler. |
