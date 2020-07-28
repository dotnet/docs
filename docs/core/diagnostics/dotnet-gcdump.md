---
title: dotnet-gcdump - .NET Core
description: Installing and using the dotnet-gcdump command-line tool.
ms.date: 07/26/2020
---
# Heap analysis tool (`dotnet-gcdump`)

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

The `dotnet-gcdump` global tool is a way to collect gcdumps of live .NET processes. It is built using the EventPipe technology which is a cross-platform alternative to ETW on Windows. Gcdumps are created by triggering a GC in the target process, turning on special events, and regenerating the graph of object roots from the event stream. This allows for gcdumps to be collected while the process is running with minimal overhead. These dumps are useful for several scenarios:

- Comparing the number of objects on the heap at several points in time.
- Analyzing roots of objects (answering questions like, "what still has a reference to this type?").
- Collecting general statistics about the counts of objects on the heap.

## Options

- **`--version`**

  Displays the version of the `dotnet-gcdump` utility.

- **`-h|--help`**

  Shows command-line help.

## `dotnet-gcdump collect`

Collects a gcdump from a currently running process.

### Synopsis

```console
dotnet-gcdump collect [-h|--help] [-p|--process-id <pid>] [-o|--output <gcdump-file-path>] [-v|--verbose] [-t|--timeout <timeout>] [-n|--name <name>]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-p|--process-id <pid>`**

  The process id to collect the gcdump.

- **`-o|--output <gcdump-file-path>`**

  The path where collected gcdumps should be written. Defaults to *.\\YYYYMMDD\_HHMMSS\_\<pid>.gcdump*.

- **`-v|--verbose`**

  Output the log while collecting the gcdump.

- **`-t|--timeout <timeout>`**

  Give up on collecting the gcdump if it takes longer than this many seconds. The default value is 30s.

- **`-n|--name <name>`**

  The name of the process to collect the gcdump.

## `dotnet-gcdump ps`

Lists the dotnet processes that gcdumps can be collected for.

### Synopsis

```console
dotnet-gcdump ps
```

## `dotnet-gcdump report <gcdump_filename>`

Generate report into stdout from a previously generated gcdump or from a running process.

### Synopsis

```console
dotnet-gcdump report [-h|--help] [-p|--process-id <pid>] [-t|--report-type <HeapStat>]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-p|--process-id <pid>`**

  The process id to collect the trace.

- **`-t|--report-type <HeapStat>`**

  The type of report to generate. Available options: heapstat (default).
