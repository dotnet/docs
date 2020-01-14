---
title: dotnet-trace tool - .NET Core
description: Installing and using the dotnet-trace command-line tool.
ms.date: 11/21/2019
---
# dotnet-trace performance analysis utility

**This article applies to:** ✓ .NET Core 3.0 SDK and later versions

## Install dotnet-trace

Install `dotnet-trace` [NuGet package](https://www.nuget.org/packages/dotnet-trace) with the [dotnet tool install](../tools/dotnet-tool-install.md) command:

```dotnetcli
dotnet tool install --global dotnet-trace
```

## Synopsis

```console
dotnet-trace [-h, --help] [--version] <command>
```

## Description

The `dotnet-trace` tool:

* Is a cross-platform .NET Core tool.
* Enables the collection of .NET Core traces of a running process without a native profiler.
* Is built around the cross-platform `EventPipe` technology of the .NET Core runtime.
* Delivers the same experience on Windows, Linux, or macOS.

## Options

- **`--version`**  

  Displays the version of the dotnet-counters utility.

- **`-h|--help`**

  Shows command-line help.

## Commands

| Command                                                     |
| ----------------------------------------------------------- |
| [dotnet-trace collect](#dotnet-trace-collect)               |
| [dotnet-trace convert](#dotnet-trace-convert)               |
| [dotnet-trace ps](#dotnet-trace-ps) |
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

  Sets the size of the in-memory circular buffer, in megabytes. Default 256 MB.

- **`-o|--output <trace-file-path>`**

  The output path for the collected trace data. If not specified it defaults to `trace.nettrace`.

- **`--providers <list-of-comma-separated-providers>`**

  A comma-separated list of `EventPipe` providers to be enabled. These providers supplement any providers implied by `--profile <profile-name>`. If there's any inconsistency for a particular provider, this configuration takes precedence over the implicit configuration from the profile.

  This list of providers is in the form:

  - `Provider[,Provider]`
  - `Provider` is in the form: `KnownProviderName[:Flags[:Level][:KeyValueArgs]]`.
  - `KeyValueArgs` is in the form: `[key1=value1][;key2=value2]`.

- **`--profile <profile-name>`**

  A named pre-defined set of provider configurations that allows common tracing scenarios to be specified succinctly.

- **`--format {NetTrace|Speedscope}`**

  Sets the output format for the trace file conversion. The default is `NetTrace`.

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

## dotnet-trace ps

Lists dotnet processes that can be attached to.

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
