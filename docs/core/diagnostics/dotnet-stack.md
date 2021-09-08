---
title: dotnet-stack diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-stack CLI tool which captures and prints the managed stacks for all threads in the target .NET process.
ms.date: 04/21/2021
---
# Inspect managed stack traces (dotnet-stack)

**This article applies to:** ✔️ .NET Core 3.0 and later versions

## Install

There are two ways to download and install `dotnet-stack`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-stack` [NuGet package](https://www.nuget.org/packages/dotnet-stack), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-stack
  ```

- **Direct download:**

  Download the tool executable that matches your platform:

  | OS  | Platform |
  | --- | -------- |
  | Windows | [x86](https://aka.ms/dotnet-stack/win-x86) \| [x64](https://aka.ms/dotnet-stack/win-x64) \| [arm](https://aka.ms/dotnet-stack/win-arm) \| [arm-x64](https://aka.ms/dotnet-stack/win-arm64) |
  | macOS   | [x64](https://aka.ms/dotnet-stack/osx-x64) |
  | Linux   | [x64](https://aka.ms/dotnet-stack/linux-x64) \| [arm](https://aka.ms/dotnet-stack/linux-arm) \| [arm64](https://aka.ms/dotnet-stack/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-stack/linux-musl-x64) \| [musl-arm64](https://aka.ms/dotnet-stack/linux-musl-arm64) |

## Synopsis

```console
dotnet-stack [-h, --help] [--version] <command>
```

## Description

The `dotnet-stack` tool:

* Is a cross-platform .NET Core tool.
* Captures and prints the managed stacks for all threads in the target .NET process.
* Utilizes [`EventPipe`](./eventpipe.md) tracing provided by the .NET Core runtime.

## Options

- **`-h|--help`**

  Shows command-line help.

- **`--version`**

  Displays the version of the dotnet-stack utility.

## Commands

| Command                                     | Description                                                   |
|---------------------------------------------|---------------------------------------------------------------|
| [dotnet-stack report](#dotnet-stack-report) | Prints the stack trace for each thread in the target process. |
| [dotnet-stack ps](#dotnet-stack-ps)         | Lists the dotnet processes that traces can be collected from. |

## dotnet-stack report

Prints the stack trace for each thread in the target process.

### Synopsis

```console
dotnet-stack report -p|--process-id <pid>
                    -n|--name <process-name>
                    [-h|--help]
```

### Options

- **`-n, --name <name>`**

  The name of the process to collect the trace from.

- **`-p|--process-id <PID>`**

  The process ID to collect the trace from.

## dotnet-stack ps

 Lists the dotnet processes that traces can be collected from.

### Synopsis

```console
dotnet-stack ps [-h|--help]
```

## Report managed stacks with dotnet-stack

To report managed stacks using `dotnet-stack`:

- Get the process identifier (PID) of the .NET Core application to report stacks from.

  - On Windows, you can use Task Manager or the `tasklist` command, for example.
  - On Linux, for example, the `ps` command.
  - [dotnet-stack ps](#dotnet-stack-ps)

- Run the following command:

  ```console
  dotnet-stack report --process-id <PID>
  ```

  The preceding command generates output similar to the following:

  ```console
  Thread (0x48839B):
    [Native Frames]
    System.Console!System.IO.StdInReader.ReadKey(bool&)
    System.Console!System.IO.SyncTextReader.ReadKey(bool&)
    System.Console!System.ConsolePal.ReadKey(bool)
    System.Console!System.Console.ReadKey()
    StackTracee!Tracee.Program.Main(class System.String[])
  ```

  The output of `dotnet-stack` follows the following form:

  - Comments in the output are prefixed with `#`.
  - Each thread has a header that includes the native thread ID: `Thread (<thread-id>):`.
  - Stack frames follow the form `Module!Method`.
  - Transitions to unmanaged code are represented as `[Native Frames]` in the output.

  ```console
  # comment
  Thread (0x1234):
    module!Method
    module!Method

  Thread (0x5678):
    [Native Frames]
    Module!Method
    Module!Method
  ```
  
## Next steps
  
- [Use dotnet-trace to collect CPU samples of a .NET application](dotnet-trace.md)
- [Use dotnet-dump to collect a dump of a .NET application](dotnet-dump.md)
