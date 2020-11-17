---
title: dotnet-stack tool - .NET Core
description: Installing and using the dotnet-stack command-line tool.
ms.date: 11/21/2019
---
# dotnet-stack performance analysis utility

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

## Install dotnet-stack

### Option 1 - Install as dotnet global tool:

Install `dotnet-stack` [NuGet package](https://www.nuget.org/packages/dotnet-stack) with the [dotnet tool install](../tools/dotnet-tool-install.md) command:

```dotnetcli
dotnet tool install --global dotnet-stack
```

### Option 2 - Direct download:

- Win ([x86](https://aka.ms/dotnet-stack/win-x86) | [x64](https://aka.ms/dotnet-stack/win-x64) | [arm](https://aka.ms/dotnet-stack/win-arm) | [arm-x64](https://aka.ms/dotnet-stack/win-arm64))
- macOS ([x64](https://aka.ms/dotnet-stack/osx-x64))
- Linux ([x64](https://aka.ms/dotnet-stack/linux-x64) | [arm](https://aka.ms/dotnet-stack/linux-arm) | [arm64](https://aka.ms/dotnet-stack/linux-arm64) | [musl-x64](https://aka.ms/dotnet-stack/linux-musl-x64) | [musl-arm64](https://aka.ms/dotnet-stack/linux-musl-arm64))

## Synopsis

```console
dotnet-stack [-h, --help] [--version] <command>
```

## Description

The `dotnet-stack` tool:

* Is a cross-platform .NET Core tool.
* Reports the managed stacks for all threads in .NET process.
* Is built on [`EventPipe`](./eventpipe.md) of the .NET Core runtime.
* Delivers the same experience on Windows, Linux, or macOS.

## Options

- **`-h|--help`**

  Shows command-line help.

- **`--version`**

  Displays the version of the dotnet-stack utility.

## Commands

| Command                                                   |
|-----------------------------------------------------------|
| [dotnet-stack report](#dotnet-stack-report)               |
| [dotnet-stack ps](#dotnet-stack-ps)                       |

## dotnet-stack report

Collects a diagnostic trace from a running process.

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
