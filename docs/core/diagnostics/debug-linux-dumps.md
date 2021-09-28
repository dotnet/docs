---
title: Debug Linux dumps
description: In this article, you'll learn how to collect and analyze dumps from Linux environments.
ms.date: 08/27/2020
---

# Debug Linux dumps

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions

## Collect dumps on Linux

The two recommended ways of collecting dumps on Linux are:

* [`dotnet-dump`](dotnet-dump.md) CLI tool
* [Environment variables](dumps.md#collect-dumps-on-crash) that collect dumps on crashes

### Managed dumps with `dotnet-dump`

The [`dotnet-dump`](dotnet-dump.md) tool is simple to use, and does not have a dependency on any native debuggers. `dotnet-dump` works on a wide variety of Linux platforms (like Alpine or ARM32/ARM64) where traditional debugging tools may not be available. However, `dotnet-dump` only captures managed state so it can't be used for debugging issues in native code. Dumps collected by `dotnet-dump` are analyzed in an environment with the same OS and architecture the dump was created on. The [`dotnet-gcdump`](dotnet-gcdump.md) tool can be used as an alternative that only captures GC heap information but produces dumps that can be analyzed on Windows.

### Core dumps with `createdump`

As an alternative to `dotnet-dump`, which creates managed-only dumps, [`createdump`](https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/botr/xplat-minidump-generation.md) is the recommended tool for creating core dumps on Linux containing both native and managed information. Other tools like gdb or gcore can also be used to create core dumps but may miss state needed for managed debugging, resulting in "UNKNOWN" type or function names during analysis.

The `createdump` tool is installed with the .NET Core runtime and can be found next to libcoreclr.so (typically in "/usr/share/dotnet/shared/Microsoft.NETCore.App/[version]"). The tool takes a process ID to collect a dump from as its primary argument and can also take optional parameters specifying what kind of dump to collect (a minidump with heap is the default). Options include:

- **`<input-filename>`**

  Input trace file to be converted. Defaults to *trace.nettrace*.

### Options

- **`-f|--name <output-filename>`**

  The file to write the dump to. Default is '/tmp/coredump.%p' where %p is the process ID of the target process.

- **`-n|--normal`**

  Create a minidump.

- **`-h|--withheap`**

  Create a minidump with heap (default).

- **`-t|--triage`**

  Create a triage minidump.

- **`-u|--full`**

  Create a full core dump.

- **`-d|--diag`**

  Enable diagnostic messages.

Collecting core dumps requires either the `SYS_PTRACE` capability or that `createdump` be run with sudo or su.

## Analyze dumps on Linux

Both managed dumps collected with `dotnet-dump` and core dumps collected with `createdump` can be analyzed with the `dotnet-dump` tool using the `dotnet-dump analyze` command. The `dotnet dump` requires that the environment analyzing the dump has the same OS and architecture as the environment the dump was captured in.

Alternatively, [LLDB](https://lldb.llvm.org/) can be used to analyze core dumps on Linux, which allows analysis of both managed and native frames. LLDB uses the SOS extension to debug managed code. The [`dotnet-sos`](dotnet-sos.md) CLI tool can be used to install SOS, which has [many useful commands](https://github.com/dotnet/diagnostics/blob/main/documentation/sos-debugging-extension.md) for debugging managed code. In order to analyze .NET Core dumps, LLDB and SOS require the following .NET Core binaries from the environment the dump was created in:

1. libmscordaccore.so
2. libcoreclr.so
3. dotnet (the host used to launch the app)

In most cases, these binaries can be downloaded using the [`dotnet-symbol`](dotnet-symbol.md) tool. If the necessary binaries can't be downloaded with `dotnet-symbol` (for example, if a private version of .NET Core built from source was in use), it may be necessary to copy the files listed above from the environment the dump was created in. If the files aren't located next to the dump file, you can use the LLDB/SOS command `setclrpath <path>` to set the path they should be loaded from and `setsymbolserver -directory <path>` to set the path to look in for symbol files.

Once the necessary files are available, the dump can be loaded in LLDB by specifying the dotnet host as the executable to debug:

```console
lldb --core <dump-file> <host-program>
```

In the above command line, `<dump-file>` is the path of the dump to analyze and `<host-program>` is the native program that started the .NET Core application. This is typically the `dotnet` binary unless the app is self-contained, in which case it is the name of the application without the dll extension.

Once LLDB starts, it may be necessary to use the `setsymbolserver` command to point at the correct symbol location (`setsymbolserver -ms` to use Microsoft's symbol server or `setsymbolserver -directory <path>` to specify a local path). Native symbols can be loaded by running `loadsymbols`. At this point, [SOS commands](https://github.com/dotnet/diagnostics/blob/main/documentation/sos-debugging-extension.md) can be used to analyze the dump.

## See also

- [dotnet-sos](dotnet-sos.md) for more details on installing the SOS extension.
- [dotnet-symbol](dotnet-symbol.md) for more details on installing and using the symbol download tool.
- [.NET Core diagnostics repo](https://github.com/dotnet/diagnostics/blob/main/documentation/) for more details on debugging, including a useful FAQ.
- [Installing LLDB](https://github.com/dotnet/diagnostics/blob/main/documentation/sos.md#getting-lldb) for instructions on installing LLDB on Linux or Mac.
