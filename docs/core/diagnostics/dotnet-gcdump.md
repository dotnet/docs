---
title: dotnet-gcdump diagnostic tool - .NET CLI
description: Learn how to install and use dotnet-gcdump CLI tool to collect GC (Garbage Collector) dumps of live .NET processes using the .NET EventPipe.
ms.date: 11/17/2020
ms.topic: reference
---
# Heap analysis tool (dotnet-gcdump)

**This article applies to:** ✔️ `dotnet-gcdump` version 3.1.57502 and later versions

## Install

There are two ways to download and install `dotnet-gcdump`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-gcdump` [NuGet package](https://www.nuget.org/packages/dotnet-gcdump), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-gcdump
  ```

- **Direct download:**

  Download the tool executable that matches your platform:

  | OS  | Platform |
  | --- | -------- |
  | Windows | [x86](https://aka.ms/dotnet-gcdump/win-x86) \| [x64](https://aka.ms/dotnet-gcdump/win-x64) \| [Arm](https://aka.ms/dotnet-gcdump/win-arm) \| [Arm64](https://aka.ms/dotnet-gcdump/win-arm64) |
  | Linux   | [x64](https://aka.ms/dotnet-gcdump/linux-x64) \| [Arm](https://aka.ms/dotnet-gcdump/linux-arm) \| [Arm64](https://aka.ms/dotnet-gcdump/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-gcdump/linux-musl-x64) \| [musl-Arm64](https://aka.ms/dotnet-gcdump/linux-musl-arm64) |

> [!NOTE]
> To use `dotnet-gcdump` on an x86 app, you need a corresponding x86 version of the tool.

## Synopsis

```console
dotnet-gcdump [-h|--help] [--version] <command>
```

## Description

The `dotnet-gcdump` global tool collects GC (Garbage Collector) dumps of live .NET processes using [EventPipe](./eventpipe.md). GC dumps are created by triggering a GC in the target process, turning on special events, and regenerating the graph of object roots from the event stream. This process allows for GC dumps to be collected while the process is running and with minimal overhead. These dumps are useful for several scenarios:

- Comparing the number of objects on the heap at several points in time.
- Analyzing roots of objects (answering questions like, "what still has a reference to this type?").
- Collecting general statistics about the counts of objects on the heap.

### View the GC dump captured from dotnet-gcdump

On Windows, `.gcdump` files can be viewed in [PerfView](https://github.com/microsoft/perfview) for analysis or in Visual Studio. Currently, there is no way of opening a `.gcdump` on non-Windows platforms.

You can collect multiple `.gcdump`s and open them simultaneously in Visual Studio to get a comparison experience.

## Options

- **`--version`**

  Displays the version of the `dotnet-gcdump` utility.

- **`-h|--help`**

  Shows command-line help.
  
## Commands

| Command                                                        |
|------------------------------------------------                |
| [dotnet-gcdump collect](#dotnet-gcdump-collect)                |
| [dotnet-gcdump ps](#dotnet-gcdump-ps)                          |
| [dotnet-gcdump report](#dotnet-gcdump-report-gcdump_filename)  |

## `dotnet-gcdump collect`

Collects a GC dump from a currently running process.

> [!WARNING]
> To walk the GC heap, this command triggers a generation 2 (full) garbage collection, which can suspend the runtime for a long time, especially when the GC heap is large. Don't use this command in performance-sensitive environments when the GC heap is large.

### Synopsis

```console
dotnet-gcdump collect [-h|--help] [-p|--process-id <pid>] [-o|--output <gcdump-file-path>] [-v|--verbose] [-t|--timeout <timeout>] [-n|--name <name>]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-p|--process-id <pid>`**

  The process ID to collect the GC dump from.

  > [!NOTE]
  > On Linux and macOS, using this option requires the target application and `dotnet-gcdump` to share the same `TMPDIR` environment variable. Otherwise, the command will time out.

- **`-o|--output <gcdump-file-path>`**

  The path where collected GC dumps should be written. Defaults to *.\\YYYYMMDD\_HHMMSS\_\<pid>.gcdump*.

- **`-v|--verbose`**

  Output the log while collecting the GC dump.

- **`-t|--timeout <timeout>`**

  Give up on collecting the GC dump if it takes longer than this many seconds. The default value is 30.

- **`-n|--name <name>`**

  The name of the process to collect the GC dump from.

  > [!NOTE]
  > On Linux and macOS, using this option requires the target application and `dotnet-gcdump` to share the same `TMPDIR` environment variable. Otherwise, the command will time out.

- **`--diagnostic-port <port-address[,(listen|connect)]>`**

  Sets the [diagnostic port](diagnostic-port.md) used to communicate with the process to be dumped. dotnet-gcdump and the .NET runtime inside the target process must agree on the port-address, with one listening and the other connecting. dotnet-gcdump automatically determines the correct port when attaching using the `--process-id` or `--name` options. It's usually only necessary to specify the port explicitly when communicating to a process that's running inside a container that isn't part of the current process namespace.

  The `port-address` differs by OS:

  - Linux and macOS - a path to a Unix domain socket such as `/foo/tool1.socket`.
  - Windows - a path to a named pipe such as `\\.\pipe\my_diag_port1`.
  - Android, iOS, and tvOS - an IP:port such as `127.0.0.1:9000`.
  
  By default, dotnet-gcdump listens at the specified address. You can request dotnet-gcdump to connect instead by appending `,connect` after the address. For example, `--diagnostic-port /foo/tool1.socket,connect` will connect to a .NET runtime process that's listening to the `/foo/tool1.socket` Unix domain socket.

> [!NOTE]
> To collect a GC dump using `dotnet-gcdump`, it needs to be run as the same user as the user running target process or as root. Otherwise, the tool will fail to establish a connection with the target process.

## `dotnet-gcdump ps`

Lists the dotnet processes that GC dumps can be collected for. dotnet-gcdump 6.0.320703 and later, also display the command-line arguments that each process was started with, if available.

### Synopsis

```console
dotnet-gcdump ps [-h|--help]
```

### Example

Suppose you start a long-running app using the command ```dotnet run --configuration Release```. In another window, you run the ```dotnet-gcdump ps``` command. The output you'll see is as follows. The command-line arguments, if any, are shown using `dotnet-gcdump` version 6.0.320703 and later.

```console
> dotnet-gcdump ps
  
  21932 dotnet     C:\Program Files\dotnet\dotnet.exe     run --configuration Release
  36656 dotnet     C:\Program Files\dotnet\dotnet.exe
```

## `dotnet-gcdump report <gcdump_filename>`

Generate a report from a previously generated GC dump or from a running process, and write to `stdout`.

### Synopsis

```console
dotnet-gcdump report [-h|--help] [-p|--process-id <pid>] [-t|--report-type <HeapStat>]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-p|--process-id <pid>`**

  The process ID to collect the GC dump from.

- **`-t|--report-type <HeapStat>`**

  The type of report to generate. Available options: heapstat (default).

## Troubleshoot

- There is no type information in the gcdump.

   Prior to .NET Core 3.1, there was an issue where a type cache was not cleared between gcdumps when they were invoked with EventPipe. This resulted in the events needed for determining type information not being sent for the second and subsequent gcdumps. This was fixed in .NET Core 3.1-preview2.

- COM and static types aren't in the GC dump.

   Prior to .NET Core 3.1, there was an issue where static and COM types weren't sent when the GC dump was invoked via EventPipe. This has been fixed in .NET Core 3.1.

- `dotnet-gcdump` is unable to generate a `.gcdump` file due to missing information, for example, **[Error] Exception during gcdump: System.ApplicationException: ETL file shows the start of a heap dump but not its completion.**. Or, the `.gcdump` file doesn't include the entire heap.

   `dotnet-gcdump` works by collecting a trace of events emitted by the garbage collector during an induced generation 2 collection. If the heap is sufficiently large, or there isn't enough memory to scale the eventing buffers, then the events required to reconstruct the heap graph from the trace may be dropped. In this case, to diagnose issues with the heap, it's recommended to collect a dump of the process.

- `dotnet-gcdump` appears to cause an Out Of Memory issue in a memory constrained environment.

   `dotnet-gcdump` works by collecting a trace of events emitted by the garbage collector during an induced generation 2 collection. The buffer for event collection is owned by the target application and can grow up to 256 MB. `dotnet-gcdump` itself also uses memory. If your environment is memory constrained, be sure to account for these factors when collecting a gcdump to prevent errors.
