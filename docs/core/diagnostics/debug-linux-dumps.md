---
title: Debug Linux dumps
description: In this article, you'll learn how to collect and analyze dumps from Linux environments.
ms.date: 01/11/2023
---

# Debug Linux dumps

**This article applies to: ✔️** .NET Core 3.0 SDK and later versions

## Collect dumps on Linux

> [!TIP]
> For frequently asked questions about dump collection, analysis, and other caveats, see [Dumps: FAQ](faq-dumps.yml).

The two recommended ways of collecting dumps on Linux are:

* [`dotnet-dump`](dotnet-dump.md) CLI tool
* [Environment variables](collect-dumps-crash.md) that collect dumps on crashes

## Analyze dumps on Linux

After a dump is collected, it can be analyzed using the [`dotnet-dump`](dotnet-dump.md) tool with the `dotnet-dump analyze` command. This analysis step needs to be run on a machine that has the same architecture and Linux distro as the environment the dump was captured in.
The `dotnet-dump` tool supports displaying information about .NET code, but is not useful for understanding code issues for other languages like C and C++.

Alternatively, [LLDB](https://lldb.llvm.org/) can be used to analyze dumps on Linux, which allows analysis of both managed and native code. LLDB uses the SOS extension to debug managed code. The [`dotnet-sos`](dotnet-sos.md) CLI tool can be used to install SOS, which has [many useful commands](https://github.com/dotnet/diagnostics/blob/main/documentation/sos-debugging-extension.md) for debugging managed code. In order to analyze .NET Core dumps, LLDB and SOS require the following .NET Core binaries from the environment the dump was created in:

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

> [!NOTE]
> LLDB can be installed with the command `sudo apt-get install lldb`

## Analyze dumps on Windows

Dumps collected from a Linux machine can also be analyzed on a Windows machine using [Visual Studio](/visualstudio/debugger/using-dump-files), [Windbg](/windows-hardware/drivers/debugger/analyzing-a-user-mode-dump-file), or the [dotnet-dump](dotnet-dump.md) tool. Both Visual Studio and Windbg can analyze native and managed code, while dotnet-dump only analyzes managed code.

> [!NOTE]
> Visual Studio version 16.8 and later allows you to [open and analyze Linux dumps](https://devblogs.microsoft.com/visualstudio/linux-managed-memory-dump-debugging/) generated on .NET Core 3.1.7 or later.

- **Visual Studio** - See the [Visual Studio dump debugging guide](/visualstudio/debugger/using-dump-files).
- **Windbg** - You can debug Linux dumps on windbg using the [same instructions](/windows-hardware/drivers/debugger/analyzing-a-user-mode-dump-file) you would use to debug a Windows user-mode dump. Use the x64 version of windbg for dumps collected from a Linux x64 or Arm64 environment and the
  x86 version for dumps collected from a Linux x86 environment.
- **dotnet-dump** - View the dump using the [dotnet-dump analyze](dotnet-dump.md) command. Use the x64 version of dotnet-dump for dumps collected from a Linux x64 or Arm64 environment and the x86 version for dumps collected from a Linux x86 environment.

## See also

- [dotnet-sos](dotnet-sos.md) for more details on installing the SOS extension.
- [dotnet-symbol](dotnet-symbol.md) for more details on installing and using the symbol download tool.
- [.NET Core diagnostics repo](https://github.com/dotnet/diagnostics/blob/main/documentation/) for more details on debugging, including a useful FAQ.
- [Installing LLDB](https://github.com/dotnet/diagnostics/blob/main/documentation/sos.md#getting-lldb) for instructions on installing LLDB on Linux or Mac.
