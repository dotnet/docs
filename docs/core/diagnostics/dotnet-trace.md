---
title: dotnet-trace diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-trace CLI tool to collect .NET traces of a running process without the native profiler, by using the .NET EventPipe.
ms.date: 05/12/2025
ms.topic: reference
---
# dotnet-trace performance analysis utility

**This article applies to:** ✔️ `dotnet-trace` 9.0.625801 and later versions

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
  | Windows | [x86](https://aka.ms/dotnet-trace/win-x86) \| [x64](https://aka.ms/dotnet-trace/win-x64) \| [Arm](https://aka.ms/dotnet-trace/win-arm) \| [Arm-x64](https://aka.ms/dotnet-trace/win-arm64) |
  | Linux   | [x64](https://aka.ms/dotnet-trace/linux-x64) \| [Arm](https://aka.ms/dotnet-trace/linux-arm) \| [Arm64](https://aka.ms/dotnet-trace/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-trace/linux-musl-x64) \| [musl-Arm64](https://aka.ms/dotnet-trace/linux-musl-arm64) |

## Synopsis

```dotnetcli
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
  
- **`--duration`**

  How long to run the trace. `--duration 00:00:00:05` will run it for 5 seconds.

## Commands

| Command                                                   |
|-----------------------------------------------------------|
| [dotnet-trace collect](#dotnet-trace-collect)             |
| [dotnet-trace convert](#dotnet-trace-convert)             |
| [dotnet-trace ps](#dotnet-trace-ps)                       |
| [dotnet-trace list-profiles](#dotnet-trace-list-profiles) |
| [dotnet-trace report](#dotnet-trace-report)               |

## dotnet-trace collect

Collects a diagnostic trace from a running process or launches a child process and traces it (.NET 5 or later). To have the tool run a child process and trace it from its startup, append `--` to the collect command.

### Synopsis

```dotnetcli
dotnet-trace collect [--buffersize <size>] [--clreventlevel <clreventlevel>] [--clrevents <clrevents>]
    [--dsrouter <ios|ios-sim|android|android-emu>]
    [--format <Chromium|NetTrace|Speedscope>] [-h|--help] [--duration dd:hh:mm:ss]
    [-n, --name <name>] [--diagnostic-port] [-o|--output <trace-file-path>] [-p|--process-id <pid>]
    [--profile <profile-name>] [--providers <list-of-comma-separated-providers>]
    [-- <command>] (for target applications running .NET 5 or later)
    [--show-child-io] [--resume-runtime]
    [--stopping-event-provider-name <stoppingEventProviderName>]
    [--stopping-event-event-name <stoppingEventEventName>]
    [--stopping-event-payload-filter <stoppingEventPayloadFilter>]
```

### Options

- **`--buffersize <size>`**

  Sets the size of the in-memory buffer, in megabytes. Default 256 MB.

  > [!NOTE]
  > If the target process emits events faster than they can be written to disk, this buffer may overflow and some events will be dropped. You can mitigate this problem by increasing the buffer size or reducing the number of events being recorded.

- **`--clreventlevel <clreventlevel>`**

  Verbosity of CLR events to be emitted.
  The following table shows the available event levels.
  
  | String value    | Numeric value |
  | --------------- | :-----------: |
  | `logalways`     |      `0`      |
  | `critical`      |      `1`      |
  | `error`         |      `2`      |
  | `warning`       |      `3`      |
  | `informational` |      `4`      |
  | `verbose`       |      `5`      |

- **`--clrevents <clrevents>`**

  A list of CLR runtime provider keywords to enable separated by `+` signs. This is a simple mapping that lets you specify event keywords via string aliases rather than their hex values. For example, `dotnet-trace collect --providers Microsoft-Windows-DotNETRuntime:3:4` requests the same set of events as `dotnet-trace collect --clrevents gc+gchandle --clreventlevel informational`. The table below shows the list of available keywords:

  | Keyword String Alias | Keyword Hex Value |
  | ------------ | ------------------- |
  | `gc` | `0x1` |
  | `gchandle` | `0x2` |
  | `fusion` | `0x4` |
  | `loader` | `0x8` |
  | `jit` | `0x10` |
  | `ngen` | `0x20` |
  | `startenumeration` | `0x40` |
  | `endenumeration` | `0x80` |
  | `security` | `0x400` |
  | `appdomainresourcemanagement` | `0x800` |
  | `jittracing` | `0x1000` |
  | `interop` | `0x2000` |
  | `contention` | `0x4000` |
  | `exception` | `0x8000` |
  | `threading` | `0x10000` |
  | `jittedmethodiltonativemap` | `0x20000` |
  | `overrideandsuppressngenevents` | `0x40000` |
  | `type` | `0x80000` |
  | `gcheapdump` | `0x100000` |
  | `gcsampledobjectallocationhigh` | `0x200000` |
  | `gcheapsurvivalandmovement` | `0x400000` |
  | `gcheapcollect` | `0x800000` |
  | `gcheapandtypenames` | `0x1000000` |
  | `gcsampledobjectallocationlow` | `0x2000000` |
  | `perftrack` | `0x20000000` |
  | `stack` | `0x40000000` |
  | `threadtransfer` | `0x80000000` |
  | `debugger` | `0x100000000` |
  | `monitoring` | `0x200000000` |
  | `codesymbols` | `0x400000000` |
  | `eventsource` | `0x800000000` |
  | `compilation` | `0x1000000000` |
  | `compilationdiagnostic` | `0x2000000000` |
  | `methoddiagnostic` | `0x4000000000` |
  | `typediagnostic` | `0x8000000000` |

  You can read about the CLR provider more in detail on the [.NET runtime provider reference documentation](../../fundamentals/diagnostics/runtime-events.md).

- **`--dsrouter {ios|ios-sim|android|android-emu}**

 Starts [dotnet-dsrouter](dotnet-dsrouter.md) and connects to it. Requires [dotnet-dsrouter](dotnet-dsrouter.md) to be installed. Run `dotnet-dsrouter -h` for more information.

- **`--format {Chromium|NetTrace|Speedscope}`**

  Sets the output format for the trace file conversion. The default is `NetTrace`.

- **`-n, --name <name>`**

  The name of the process to collect the trace from.

  > [!NOTE]
  > On Linux and macOS, using this option requires the target application and `dotnet-trace` to share the same `TMPDIR` environment variable. Otherwise, the command will time out.

- **`--diagnostic-port <port-address[,(listen|connect)]>`**

  Sets the [diagnostic port](diagnostic-port.md) used to communicate with the process to be traced. dotnet-trace and the .NET runtime inside the target process must agree on the port-address, with one listening and the other connecting. dotnet-trace automatically determines the correct port when attaching using the `--process-id` or `--name` options, or when launching a process using the `-- <command>` option. It's usually only necessary to specify the port explicitly when waiting for a process that will start in the future or communicating to a process that is running inside a container that isn't part of the current process namespace.

  The `port-address` differs by OS:

  - Linux and macOS - a path to a Unix domain socket such as `/foo/tool1.socket`.
  - Windows - a path to a named pipe such as `\\.\pipe\my_diag_port1`.
  - Android, iOS, and tvOS - an IP:port such as `127.0.0.1:9000`.
  
  By default, `dotnet-trace` listens at the specified address. You can request `dotnet-trace` to connect instead by appending `,connect` after the address. For example, `--diagnostic-port /foo/tool1.socket,connect` will connect to a .NET runtime process that is listening to the `/foo/tool1.socket` Unix domain socket.
  
  To learn how to use this option to collect a trace from app startup, see [Use diagnostic port to collect a trace from app startup](#use-diagnostic-port-to-collect-a-trace-from-app-startup).
  
- **`--duration <time-to-run>`**

  The time for the trace to run. Use the `dd:hh:mm:ss` format. For example `00:00:00:05` will run it for 5 seconds.

- **`-o|--output <trace-file-path>`**

  The output path for the collected trace data. If not specified it defaults to `<appname>_<yyyyMMdd>_<HHmmss>.nettrace`, e.g., `myapp_20210315_111514.nettrace``.

- **`-p|--process-id <PID>`**

  The process ID to collect the trace from.

  > [!NOTE]
  > On Linux and macOS, using this option requires the target application and `dotnet-trace` to share the same `TMPDIR` environment variable. Otherwise, the command will time out.

- **`--profile <profile-name>`**

  A named pre-defined set of provider configurations that allows common tracing scenarios to be specified succinctly. The following profiles are available:

 | Profile | Description |
 |---------|-------------|
 |`cpu-sampling`|Useful for tracking CPU usage and general .NET runtime information. This is the default option if no profile or providers are specified.|
 |`gc-verbose`|Tracks GC collections and samples object allocations.|
 |`gc-collect`|Tracks GC collections only at very low overhead.|

- **`--providers <list-of-comma-separated-providers>`**

  A comma-separated list of `EventPipe` providers to be enabled. These providers supplement any providers implied by `--profile <profile-name>`. If there's any inconsistency for a particular provider, this configuration takes precedence over the implicit configuration from the profile.

  This list of providers is in the form:

  - `Provider[,Provider]`
  - `Provider` is in the form: `KnownProviderName[:Flags[:Level][:KeyValueArgs]]`.
  - `KeyValueArgs` is in the form: `[key1=value1][;key2=value2]`.

  To learn more about some of the well-known providers in .NET, refer to [Well-known Event Providers](./well-known-event-providers.md).

- **`-- <command>` (for target applications running .NET 5 or later)**

  After the collection configuration parameters, the user can append `--` followed by a command to start a .NET application with at least a 5.0 runtime. This may be helpful when diagnosing issues that happen early in the process, such as startup performance issue or assembly loader and binder errors.

  > [!NOTE]
  > Using this option monitors the first .NET process that communicates back to the tool, which means if your command launches multiple .NET applications, it will only collect the first app. Therefore, it is recommended you use this option on self-contained applications, or using the `dotnet exec <app.dll>` option.

- **`--show-child-io`**

  Shows the input and output streams of a launched child process in the current console.

- **`--resume-runtime`**

  Resume runtime once session has been initialized, defaults to true. Disable resume of runtime using --resume-runtime:false.

- **`--stopping-event-provider-name`**

  A string, parsed as-is, that will stop the trace upon hitting an event with the matching provider name. For a more specific stopping event, additionally provide `--stopping-event-event-name` and/or `--stopping-event-payload-filter`. e.g. `--stopping-event-provider-name Microsoft-Windows-DotNETRuntime` to stop the trace upon hitting the first event emitted by the `Microsoft-Windows-DotNETRuntime` event provider.

- **`--stopping-event-event-name`**

  A string, parsed as-is, that will stop the trace upon hitting an event with the matching event name. Requires `--stopping-event-provider-name` to be set. For a more specific stopping event, additionally provide `--stopping-event-payload-filter`. e.g. `--stopping-event-provider-name Microsoft-Windows-DotNETRuntime --stopping-event-event-name Method/JittingStarted` to stop the trace upon hitting the first `Method/JittingStarted` event emitted by the `Microsoft-Windows-DotNETRuntime` event provider.

- **`--stopping-event-payload-filter`**

  A string, parsed as [payload_field_name]:[payload_field_value] pairs separated by commas, that will stop the trace upon hitting an event containing all specified payload pairs. Requires `--stopping-event-provider-name` and `--stopping-event-event-name` to be set. e.g. `--stopping-event-provider-name Microsoft-Windows-DotNETRuntime --stopping-event-event-name Method/JittingStarted --stopping-event-payload-filter MethodNameSpace:Program,MethodName:OnButtonClick` to stop the trace upon the first `Method/JittingStarted` event for the method `OnButtonClick` in the `Program` namespace emitted by the `Microsoft-Windows-DotNETRuntime` event provider.

> [!NOTE]

> - Stopping the trace may take a long time (up to minutes) for large applications. The runtime needs to send over the type cache for all managed code that was captured in the trace.

> - To collect a trace using `dotnet-trace`, it needs to be run as the same user as the user running the target process or as root. Otherwise, the tool will fail to establish a connection with the target process.

> - If you experience an unhandled exception while running `dotnet-trace collect`, this results in an incomplete trace. If finding the root cause of the exception is your priority, navigate to [Collect dumps on crash](collect-dumps-crash.md). As a result of the unhandled exception, the trace is truncated when the runtime shuts down to prevent other undesired behavior such as a hang or data corruption. Even though the trace is incomplete, you can still open it to see what happened leading up to the failure. However, it will be missing Rundown information (this happens at the end of a trace) so stacks might be unresolved (depending on what providers were turned on). Open the trace by executing PerfView with the `/ContinueOnError` flag at the command line. The logs will also contain the location the exception was fired.

> - When specifying a stopping event through the `--stopping-event-*` options, as the EventStream is being parsed asynchronously, there will be some events that pass through between the time a trace event matching the specified stopping event options is parsed and the EventPipeSession is stopped.

## dotnet-trace convert

Converts `nettrace` traces to alternate formats for use with alternate trace analysis tools.

### Synopsis

```dotnetcli
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

> [!NOTE]
> Converting `nettrace` files to `chromium` or `speedscope` files is irreversible. `speedscope` and `chromium` files don't have all the information necessary to reconstruct `nettrace` files. However, the `convert` command preserves the original `nettrace` file, so don't delete this file if you plan to open it in the future.

## dotnet-trace ps

 Lists the dotnet processes that traces can be collected from.
 `dotnet-trace` 6.0.320703 and later, also display the command-line arguments that each process was started with, if available.

> [!NOTE]
> To get full information for enumerated 64 bit processes, you need to use a 64-bit version of the `dotnet-trace` tool.

### Synopsis

```dotnetcli
dotnet-trace ps [-h|--help]
```

### Example

Suppose you start a long-running app using the command ```dotnet run --configuration Release```. In another window, you run the ```dotnet-trace ps``` command. The output you'll see is as follows. The command-line arguments, if available, are shown in `dotnet-trace` version 6.0.320703 and later.

```dotnetcli
> dotnet-trace ps
  
  21932 dotnet     C:\Program Files\dotnet\dotnet.exe   run --configuration Release
  36656 dotnet     C:\Program Files\dotnet\dotnet.exe
```

## dotnet-trace list-profiles

Lists pre-built tracing profiles with a description of what providers and filters are in each profile.

### Synopsis

```dotnetcli
dotnet-trace list-profiles [-h|--help]
```

## dotnet-trace report

Creates a report into stdout from a previously generated trace.

### Synopsis

```dotnetcli
dotnet-trace report [-h|--help] <tracefile> [command]
```

### Arguments

- **`<tracefile>`**

  The file path for the trace being analyzed.

### Commands

#### dotnet-trace report topN

Finds the top N methods that have been on the callstack the longest.

##### Synopsis

```dotnetcli
dotnet-trace report <tracefile> topN [-n|--number <n>] [--inclusive] [-v|--verbose] [-h|--help]
```

##### Options

- **`-n|--number <n>`**

Gives the top N methods on the callstack.

- **`--inclusive`**

Output the top N methods based on [inclusive](/visualstudio/profiling/understanding-sampling-data-values) time. If not specified, exclusive time is used by default.

- **`-v|--verbose`**

Output the parameters of each method in full. If not specified, parameters will be truncated.

## Collect a trace with dotnet-trace

To collect traces using `dotnet-trace`:

- Get the process identifier (PID) of the .NET Core application to collect traces from.

  - On Windows, you can use Task Manager or the `tasklist` command, for example.
  - On Linux, for example, the `ps` command.
  - [dotnet-trace ps](#dotnet-trace-ps)

- Run the following command:

  ```dotnetcli
  dotnet-trace collect --process-id <PID>
  ```

  The preceding command generates output similar to the following:

  ```output
  Press <Enter> to exit...
  Connecting to process: <Full-Path-To-Process-Being-Profiled>/dotnet.exe
  Collecting to file: <Full-Path-To-Trace>/trace.nettrace
  Session Id: <SessionId>
  Recording trace 721.025 (KB)
  ```

- Stop collection by pressing the `<Enter>` key. `dotnet-trace` will finish logging events to the *trace.nettrace* file.

## Launch a child application and collect a trace from its startup using dotnet-trace

Sometimes it may be useful to collect a trace of a process from its startup. For apps running .NET 5 or later, it is possible to do this by using dotnet-trace.

This will launch `hello.exe` with `arg1` and `arg2` as its command-line arguments and collect a trace from its runtime startup:

```dotnetcli
dotnet-trace collect -- hello.exe arg1 arg2
```

The preceding command generates output similar to the following:

```output
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
> Launching `hello.exe` via dotnet-trace will redirect its input/output and you won't be able to interact with it on the console by default. Use the `--show-child-io` switch to interact with its stdin/stdout.
> Exiting the tool via CTRL+C or SIGTERM will safely end both the tool and the child process.
> If the child process exits before the tool, the tool will exit as well and the trace should be safely viewable.

## Use diagnostic port to collect a trace from app startup

[Diagnostic port](./diagnostic-port.md) is a runtime feature added in .NET 5 that allows you to start tracing from app startup. To do this using `dotnet-trace`, you can either use `dotnet-trace collect -- <command>` as described in the examples above, or use the `--diagnostic-port` option.

Using `dotnet-trace <collect|monitor> -- <command>` to launch the application as a child process is the simplest way to quickly trace the application from its startup.

However, when you want to gain a finer control over the lifetime of the app being traced (for example, monitor the app for the first 10 minutes only and continue executing) or if you need to interact with the app using the CLI, using `--diagnostic-port` option allows you to control both the target app being monitored and `dotnet-trace`.

1. The command below makes `dotnet-trace` create a diagnostics socket named `myport.sock` and wait for a connection.

    > ```dotnetcli
    > dotnet-trace collect --diagnostic-port myport.sock
    > ```

    Output:

    > ```output
    > Waiting for connection on myport.sock
    > Start an application with the following environment variable: DOTNET_DiagnosticPorts=/home/user/myport.sock
    > ```

2. In a separate console, launch the target application with the environment variable `DOTNET_DiagnosticPorts` set to the value in the `dotnet-trace` output.

    > ```console
    > export DOTNET_DiagnosticPorts=/home/user/myport.sock
    > ./my-dotnet-app arg1 arg2
    > ```

    This should then enable `dotnet-trace` to start tracing `my-dotnet-app`:

    > ```output
    > Waiting for connection on myport.sock
    > Start an application with the following environment variable: DOTNET_DiagnosticPorts=myport.sock
    > Starting a counter session. Press Q to quit.
    > ```

    > [!IMPORTANT]
    > Launching your app with `dotnet run` can be problematic because the dotnet CLI may spawn many child processes that are not your app and they can connect to `dotnet-trace` before your app, leaving your app to be suspended at run time. It is recommended you directly use a self-contained version of the app or use `dotnet exec` to launch the application.

## View the trace captured from dotnet-trace

On Windows, you can view *.nettrace* files in [Visual Studio](/visualstudio/profiling/beginners-guide-to-performance-profiling?#step-2-analyze-cpu-usage-data) or [PerfView](https://github.com/microsoft/perfview) for analysis.

On Linux, you can view the trace by changing the output format of `dotnet-trace` to `speedscope`. Change the output file format by using the `-f|--format` option. You can choose between `nettrace` (the default option) and `speedscope`. The option `-f speedscope` will make `dotnet-trace` produce a `speedscope` file. `Speedscope` files can be opened at <https://www.speedscope.app>.

For traces collected on non-Windows platforms, you can also move the trace file to a Windows machine and view it in Visual Studio or PerfView.

> [!NOTE]
> The .NET Core runtime generates traces in the `nettrace` format. The traces are converted to speedscope (if specified) after the trace is completed. Since some conversions may result in loss of data, the original `nettrace` file is preserved next to the converted file.

## Use .rsp file to avoid typing long commands

You can launch `dotnet-trace` with an `.rsp` file that contains the arguments to pass. This can be useful when enabling providers that expect lengthy arguments or when using a shell environment that strips characters.

For example, the following provider can be cumbersome to type out each time you want to trace:

```dotnetcli
dotnet-trace collect --providers Microsoft-Diagnostics-DiagnosticSource:0x3:5:FilterAndPayloadSpecs="SqlClientDiagnosticListener/System.Data.SqlClient.WriteCommandBefore@Activity1Start:-Command;Command.CommandText;ConnectionId;Operation;Command.Connection.ServerVersion;Command.CommandTimeout;Command.CommandType;Command.Connection.ConnectionString;Command.Connection.Database;Command.Connection.DataSource;Command.Connection.PacketSize\r\nSqlClientDiagnosticListener/System.Data.SqlClient.WriteCommandAfter@Activity1Stop:\r\nMicrosoft.EntityFrameworkCore/Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting@Activity2Start:-Command;Command.CommandText;ConnectionId;IsAsync;Command.Connection.ClientConnectionId;Command.Connection.ServerVersion;Command.CommandTimeout;Command.CommandType;Command.Connection.ConnectionString;Command.Connection.Database;Command.Connection.DataSource;Command.Connection.PacketSize\r\nMicrosoft.EntityFrameworkCore/Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted@Activity2Stop:",OtherProvider,AnotherProvider
```

In addition, the previous example contains `"` as part of the argument. Because quotes are not handled equally by each shell, you may experience various issues when using different shells. For example, the command to enter in `zsh` is different to the command in `cmd`.

Instead of typing this each time, you can save the following text into a file called `myprofile.rsp`.

```txt
--providers
Microsoft-Diagnostics-DiagnosticSource:0x3:5:FilterAndPayloadSpecs="SqlClientDiagnosticListener/System.Data.SqlClient.WriteCommandBefore@Activity1Start:-Command;Command.CommandText;ConnectionId;Operation;Command.Connection.ServerVersion;Command.CommandTimeout;Command.CommandType;Command.Connection.ConnectionString;Command.Connection.Database;Command.Connection.DataSource;Command.Connection.PacketSize\r\nSqlClientDiagnosticListener/System.Data.SqlClient.WriteCommandAfter@Activity1Stop:\r\nMicrosoft.EntityFrameworkCore/Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting@Activity2Start:-Command;Command.CommandText;ConnectionId;IsAsync;Command.Connection.ClientConnectionId;Command.Connection.ServerVersion;Command.CommandTimeout;Command.CommandType;Command.Connection.ConnectionString;Command.Connection.Database;Command.Connection.DataSource;Command.Connection.PacketSize\r\nMicrosoft.EntityFrameworkCore/Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted@Activity2Stop:",OtherProvider,AnotherProvider
```

Once you've saved `myprofile.rsp`, you can launch `dotnet-trace` with this configuration using the following command:

```dotnetcli
dotnet-trace @myprofile.rsp
```

## See also

- [Well-known event providers from .NET](well-known-event-providers.md)
