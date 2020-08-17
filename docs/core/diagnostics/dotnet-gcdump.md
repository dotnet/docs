---
title: dotnet-gcdump - .NET Core
description: Installing and using the dotnet-gcdump command-line tool.
ms.date: 07/26/2020
---
# Heap analysis tool (dotnet-gcdump)

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Install dotnet-gcdump

To install the latest release version of the `dotnet-gcdump` [NuGet package](https://www.nuget.org/packages/dotnet-gcdump), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

```dotnetcli
dotnet tool install -g dotnet-gcdump
```

## Synopsis

```console
dotnet-gcdump [-h|--help] [--version] <command>
```

## Description

The `dotnet-gcdump` global tool is a way to collect GC (Garbage Collector) dumps of live .NET processes. It uses the EventPipe technology, which is a cross-platform alternative to ETW on Windows. GC dumps are created by triggering a GC in the target process, turning on special events, and regenerating the graph of object roots from the event stream. This allows for GC dumps to be collected while the process is running, with minimal overhead. These dumps are useful for several scenarios:

- Comparing the number of objects on the heap at several points in time.
- Analyzing roots of objects (answering questions like, "what still has a reference to this type?").
- Collecting general statistics about the counts of objects on the heap.

### View the GC dump captured from dotnet-gcdump

On Windows, `.gcdump` files can be viewed in [PerfView](https://github.com/microsoft/perfview) for analysis or in Visual Studio. Currently, There is no way of opening a `.gcdump` on non-Windows platforms.

You can collect multiple `.gcdump`s and open them simultaneously in Visual Studio to get a comparison experience.

## Options

- **`--version`**

  Displays the version of the `dotnet-gcdump` utility.

- **`-h|--help`**

  Shows command-line help.

## `dotnet-gcdump collect`

Collects a GC dump from a currently running process.

### Synopsis

```console
dotnet-gcdump collect [-h|--help] [-p|--process-id <pid>] [-o|--output <gcdump-file-path>] [-v|--verbose] [-t|--timeout <timeout>] [-n|--name <name>]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-p|--process-id <pid>`**

  The process id to collect the GC dump from.

- **`-o|--output <gcdump-file-path>`**

  The path where collected GC dumps should be written. Defaults to *.\\YYYYMMDD\_HHMMSS\_\<pid>.gcdump*.

- **`-v|--verbose`**

  Output the log while collecting the GC dump.

- **`-t|--timeout <timeout>`**

  Give up on collecting the GC dump if it takes longer than this many seconds. The default value is 30.

- **`-n|--name <name>`**

  The name of the process to collect the GC dump from.

## `dotnet-gcdump ps`

Lists the dotnet processes that GC dumps can be collected for.

### Synopsis

```console
dotnet-gcdump ps
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

  The process id to collect the GC dump from.

- **`-t|--report-type <HeapStat>`**

  The type of report to generate. Available options: heapstat (default).

## Troubleshoot

- There is no type information in the gcdump.

   Prior to .NET Core 3.1, there was an issue where a type cache was not cleared between gcdumps when they were invoked with EventPipe. This resulted in the events needed for determining type information not being sent for the second and subsequent gcdumps. This was fixed in .NET Core 3.1-preview2.

- COM and static types aren't in the GC dump.

   Prior to .NET Core 3.1-preview2, there was an issue where static and COM types weren't sent when the GC dump was invoked via EventPipe. This has been fixed in .NET Core 3.1-preview2.
