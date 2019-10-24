---
title: dotnet-trace - .NET Core
description: Installing and using the dotnet-trace command-line tool.
author: sdmaclea
ms.author: stmaclea
ms.date: 10/14/2019
---
# Trace for performance analysis utility (`dotnet-trace`)

**This article applies to:** .NET Core 3.0 SDK and later versions

## Installing `dotnet-trace`

To install the latest release version of the `dotnet-trace` [NuGet package](https://www.nuget.org/packages/dotnet-trace), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

```dotnetcli
dotnet tool install --global dotnet-trace
```

## Synopsis

```console
dotnet-trace [-h, --help] [--version] <command>
```

## Description

The `dotnet-trace` tool is a cross-platform CLI global tool that enables the collection of .NET Core traces of a running process without any native profiler involved. It's built around the cross-platform `EventPipe` technology of the .NET Core runtime. `dotnet-trace` delivers the same experience on Windows, Linux, or macOS.

## Options

- **`--version`**

Display the version of the dotnet-counters utility.

- **`-h|--help`**

Show command-line help.

## Commands

| Command                                                     |
| ----------------------------------------------------------- |
| [dotnet-trace collect](#dotnet-trace-collect)               |
| [dotnet-trace convert](#dotnet-trace-convert)               |
| [dotnet-trace list-processes](#dotnet-trace-list-processes) |
| [dotnet-trace list-profiles](#dotnet-trace-list-profiles)   |

## dotnet-trace collect

Collects a diagnostic trace from a running process.

### Synopsis

```console
dotnet-trace collect [-h|--help] [-p|--process-id] [--buffersize <size>] [-o|--output]
    [--providers] [--profile <profile-name>] [--format]
```

### Options

- **`-p|--process-id <PID>`**

  The process to collect the trace from.

- **`--buffersize <size>`**

  Sets the size of the in-memory circular buffer in megabytes. Default 256 MB.

- **`-o|--output <trace-file-path>`**

  The output path for the collected trace data. If not specified it defaults to `trace.nettrace`.

- **`--providers <list-of-comma-separated-providers>`**

  A comma-separated list of `EventPipe` providers to be enabled. These providers supplement any providers implied by `--profile <profile-name>`. If there's any inconsistency for a particular provider, the configuration here takes precedence over the implicit configuration from the profile.

  This list of providers is in the form:

  - `Provider[,Provider]`
  - `Provider` is in the form: `KnownProviderName[:Flags[:Level][:KeyValueArgs]]`.
  - `KeyValueArgs` is in the form: `[key1=value1][;key2=value2]`.

- **`--profile <profile-name>`**

  A named pre-defined set of provider configurations that allows common tracing scenarios to be specified succinctly.

- **`--format <NetTrace|Speedscope>`**

  Sets the output format for the trace file conversion.

## dotnet-trace convert

Converts `nettrace` traces to alternate formats for use with alternate trace analysis tools.

### Synopsis

```console
dotnet-trace convert [<input-filename>] [-h|--help] [--format] [-o|--output]
```

### Arguments

- **`<input-filename>`**

  Input trace file to be converted. Defaults to *trace.nettrace*.

### Options

- **`--format <NetTrace|Speedscope>`**

  Sets the output format for the trace file conversion.

- **`-o|--output <output-filename>`**

  Output filename. Extension of target format will be added.

## dotnet-trace list-processes

Lists dotnet processes that can be traced.

### Synopsis

```console
dotnet-trace list-processes [-h|--help]
```

## dotnet-trace list-profiles

Lists pre-built tracing profiles with a description of what providers and filters are in each profile.

### Synopsis

```console
dotnet-trace list-profiles [-h|--help]
```

## Collect a trace with `dotnet-trace`

- To collect traces using `dotnet-trace`, you'll need to first, find out the process identifier (PID) of the .NET Core application to collect traces from.

  - On Windows, there are options such as using the task manager or the `tasklist` command.
  - On Linux, the trivial option could be using `ps` command.

You may also use the [dotnet-trace list-processes](#dotnet-trace-list-processes) command to find out what .NET Core processes are running, along with their PIDs.

- Then, run the following command:

```console
> dotnet-trace collect --process-id <PID>

Press <Enter> to exit...
Connecting to process: <Full-Path-To-Process-Being-Profiled>/dotnet.exe
Collecting to file: <Full-Path-To-Trace>/trace.nettrace
  Session Id: <SessionId>
  Recording trace 721.025 (KB)
```

- Finally, stop collection by pressing the `<Enter>` key, and `dotnet-trace` will finish logging events to `trace.nettrace` file.

## Viewing the trace captured from `dotnet-trace`

On Windows, `.nettrace` files can be viewed on [PerfView](https://github.com/microsoft/perfview) for analysis, just like traces collected with ETW or LTTng. For traces collected on Linux, you can move the trace to a Windows machine to be viewed on PerfView.

You may also view the trace on a Linux machine by changing the output format of `dotnet-trace` to `speedscope`. You can change the output file format using the `-f|--format` option - `-f speedscope` will make `dotnet-trace` to produce a `speedscope` file. You can currently choose between `nettrace` (the default option) and `speedscope`. `Speedscope` files can be opened at <https://www.speedscope.app>.

> [!NOTE]
> The .NET Core runtime generates traces in the `nettrace` format, and they're converted to speedscope (if specified) after the trace is completed. Since some conversions may result in loss of data, the original `nettrace` file is preserved next to the converted file.

## Using `dotnet-trace` to collect counter values over time

If you're trying to use `EventCounter` for basic health monitoring in  performance-sensitive settings like production environments and you want to collect traces instead of watching them in real time, you can do that with `dotnet-trace` as well.

For example, if you want to collect runtime performance counter values, you can use the following command:

```console
dotnet-trace collect --process-id <PID> --providers System.Runtime:0:1:EventCounterIntervalSec=1
```

This command tells the runtime counters to be reported once every second for lightweight health monitoring. Replacing `EventCounterIntervalSec=1` with a higher value (for example, 60) allows you to collect a smaller trace with less granularity in the counter data.

If you want to disable runtime events to reduce the overhead (and trace size) even further, you can use the following command to disable runtime events and managed stack profiler.

```console
dotnet-trace collect --process-id <PID> --providers System.Runtime:0:1:EventCounterIntervalSec=1,Microsoft-Windows-DotNETRuntime:0:1,Microsoft-DotNETCore-SampleProfiler:0:1
```

## .NET Providers

The .NET Core runtime supports the following .NET providers. .NET Core uses the same keywords to enable both
`Event Tracing for Windows (ETW)` and `EventPipe` traces.

| Provider name                            | Information |
|------------------------------------------|-------------|
| `Microsoft-Windows-DotNETRuntime`        | [The Runtime Provider](../../framework/performance/clr-etw-providers.md#the-runtime-provider)<br>[CLR Runtime Keywords](../../framework/performance/clr-etw-keywords-and-levels.md#runtime) |
| `Microsoft-Windows-DotNETRuntimeRundown` | [The Rundown Provider](../../framework/performance/clr-etw-providers.md#the-rundown-provider)<br>[CLR Rundown Keywords](../../framework/performance/clr-etw-keywords-and-levels.md#rundown) |
| `Microsoft-DotNETCore-SampleProfiler`    | Enables the sample profiler. |
