---
title: dotnet-dump diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-dump CLI tool to collect and analyze Windows and Linux dumps without any native debugger.
ms.date: 11/17/2020
ms.topic: reference
---
# Dump collection and analysis utility (dotnet-dump)

**This article applies to:** ✔️ .NET Core 3.0 SDK and later versions

> [!NOTE]
> `dotnet-dump` for macOS is only supported with .NET 5 and later versions.

## Install

There are two ways to download and install `dotnet-dump`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-dump` [NuGet package](https://www.nuget.org/packages/dotnet-dump), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-dump
  ```

- **Direct download:**

  Download the tool executable that matches your platform:

  | OS  | Platform |
  | --- | -------- |
  | Windows | [x86](https://aka.ms/dotnet-dump/win-x86) \| [x64](https://aka.ms/dotnet-dump/win-x64) \| [arm](https://aka.ms/dotnet-dump/win-arm) \| [arm-x64](https://aka.ms/dotnet-dump/win-arm64) |
  | macOS   | [x64](https://aka.ms/dotnet-dump/osx-x64) |
  | Linux   | [x64](https://aka.ms/dotnet-dump/linux-x64) \| [arm](https://aka.ms/dotnet-dump/linux-arm) \| [arm64](https://aka.ms/dotnet-dump/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-dump/linux-musl-x64) \| [musl-arm64](https://aka.ms/dotnet-dump/linux-musl-arm64) |

> [!NOTE]
> To use `dotnet-dump` on an x86 app, you need a corresponding x86 version of the tool.

## Synopsis

```console
dotnet-dump [-h|--help] [--version] <command>
```

## Description

The `dotnet-dump` global tool is a way to collect and analyze Windows and Linux dumps without any native debugger involved like `lldb` on Linux. This tool is important on platforms like Alpine Linux where a fully working `lldb` isn't available. The `dotnet-dump` tool allows you to run SOS commands to analyze crashes and the garbage collector (GC), but it isn't a native debugger so things like displaying native stack frames aren't supported.

## Options

- **`--version`**

  Displays the version of the dotnet-dump utility.

- **`-h|--help`**

  Shows command-line help.

## Commands

| Command                                     |
| ------------------------------------------- |
| [dotnet-dump collect](#dotnet-dump-collect) |
| [dotnet-dump analyze](#dotnet-dump-analyze) |

## dotnet-dump collect

Captures a dump from a process.

### Synopsis

```console
dotnet-dump collect [-h|--help] [-p|--process-id] [-n|--name] [--type] [-o|--output] [--diag]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-p|--process-id <PID>`**

  Specifies the process ID number to collect a dump from.

- **`-n|--name <name>`**

  Specifies the name of the process to collect a dump from.

- **`--type <Full|Heap|Mini>`**

  Specifies the dump type, which determines the kinds of information that are collected from the process. There are three types:

  - `Full` - The largest dump containing all memory including the module images.
  - `Heap` - A large and relatively comprehensive dump containing module lists, thread lists, all stacks, exception information, handle information, and all memory except for mapped images.
  - `Mini` - A small dump containing module lists, thread lists, exception information, and all stacks.

  If not specified, `Full` is the default.

- **`-o|--output <output_dump_path>`**

  The full path and file name where the collected dump should be written.

  If not specified:

  - Defaults to *.\dump_YYYYMMDD_HHMMSS.dmp* on Windows.
  - Defaults to *./core_YYYYMMDD_HHMMSS* on Linux.

  YYYYMMDD is Year/Month/Day and HHMMSS is Hour/Minute/Second.

- **`--diag`**

  Enables dump collection diagnostic logging.

> [!NOTE]
> On Linux and macOS, this command expects the target application and `dotnet-dump` to share the same `TMPDIR` environment variable. Otherwise, the command will time out.

> [!NOTE]
> To collect a dump using `dotnet-dump`, it needs to be run as the same user as the user running target process or as root. Otherwise, the tool will fail to establish a connection with the target process.

## dotnet-dump analyze

Starts an interactive shell to explore a dump. The shell accepts various [SOS commands](#analyze-sos-commands).

### Synopsis

```console
dotnet-dump analyze <dump_path> [-h|--help] [-c|--command]
```

### Arguments

- **`<dump_path>`**

  Specifies the path to the dump file to analyze.

### Options

- **`-c|--command <debug_command>`**

  Specifies the [command](#analyze-sos-commands) to run in the shell on start.

### Analyze SOS commands

| Command                                             | Function                                                                                      |
|-----------------------------------------------------|-----------------------------------------------------------------------------------------------|
| `soshelp` or `help`                                 | Displays all available commands                                                               |
| `soshelp <command>` or `help <command>`             | Displays the specified command.                                                               |
| `exit` or `quit`                                    | Exits interactive mode.                                                                       |
| `clrstack <arguments>`                              | Provides a stack trace of managed code only.                                                  |
| `clrthreads <arguments>`                            | Lists the managed threads running.                                                            |
| `dumpasync <arguments>`                             | Displays information about async state machines on the garbage-collected heap.                |
| `dumpassembly <arguments>`                          | Displays details about the assembly at the specified address.                                 |
| `dumpclass <arguments>`                             | Displays information about the `EEClass` structure at the specified address.                  |
| `dumpdelegate <arguments>`                          | Displays information about the delegate at the specified address.                             |
| `dumpdomain <arguments>`                            | Displays information all the AppDomains and all assemblies within the specified domain.       |
| `dumpheap <arguments>`                              | Displays info about the garbage-collected heap and collection statistics about objects.       |
| `dumpil <arguments>`                                | Displays the Microsoft intermediate language (MSIL) that is associated with a managed method. |
| `dumplog <arguments>`                               | Writes the contents of an in-memory stress log to the specified file.                         |
| `dumpmd <arguments>`                                | Displays information about the `MethodDesc` structure at the specified address.               |
| `dumpmodule <arguments>`                            | Displays information about the module at the specified address.                               |
| `dumpmt <arguments>`                                | Displays information about the `MethodTable` at the specified address.                        |
| `dumpobj <arguments>`                               | Displays info about the object at the specified address.                                      |
| `dso <arguments>` or `dumpstackobjects <arguments>` | Displays all managed objects found within the bounds of the current stack.                    |
| `eeheap <arguments>`                                | Displays info about process memory consumed by internal runtime data structures.              |
| `finalizequeue <arguments>`                         | Displays all objects registered for finalization.                                             |
| `gcroot <arguments>`                                | Displays info about references (or roots) to the object at the specified address.             |
| `gcwhere <arguments>`                               | Displays the location in the GC heap of the argument passed in.                               |
| `ip2md <arguments>`                                 | Displays the `MethodDesc` structure at the specified address in JIT code.                     |
| `histclear <arguments>`                             | Releases any resources used by the family of `hist*` commands.                                |
| `histinit <arguments>`                              | Initializes the SOS structures from the stress log saved in the debuggee.                     |
| `histobj <arguments>`                               | Displays the garbage collection stress log relocations related to `<arguments>`.              |
| `histobjfind <arguments>`                           | Displays all the log entries that reference the object at the specified address.              |
| `histroot <arguments>`                              | Displays information related to both promotions and relocations of the specified root.        |
| `lm` or `modules`                                   | Displays the native modules in the process.                                                   |
| `name2ee <arguments>`                               | Displays the `MethodTable` and `EEClass` structures for the `<argument>`.                     |
| `pe <arguments>` or `printexception <arguments>`    | Displays any object derived from the <xref:System.Exception> class for the `<argument>`.      |
| `setsymbolserver <arguments>`                       | Enables the symbol server support                                                             |
| `syncblk <arguments>`                               | Displays the SyncBlock holder info.                                                           |
| `threads <threadid>` or `setthread <threadid>`      | Sets or displays the current thread ID for the SOS commands.                                  |

> [!NOTE]
> Additional details can be found in [SOS Debugging Extension for .NET](sos-debugging-extension.md).

## Using `dotnet-dump`

The first step is to collect a dump. This step can be skipped if a core dump has already been generated. The operating system or the .NET Core runtime's built-in [dump generation feature](https://github.com/dotnet/runtime/blob/main/docs/design/coreclr/botr/xplat-minidump-generation.md) can each create core dumps.

```console
$ dotnet-dump collect --process-id 1902
Writing minidump to file ./core_20190226_135837
Written 98983936 bytes (24166 pages) to core file
Complete
```

Now analyze the core dump with the `analyze` command:

```console
$ dotnet-dump analyze ./core_20190226_135850
Loading core dump: ./core_20190226_135850
Ready to process analysis commands. Type 'help' to list available commands or 'help [command]' to get detailed help on a command.
Type 'quit' or 'exit' to exit the session.
>
```

This action brings up an interactive session that accepts commands like:

```console
> clrstack
OS Thread Id: 0x573d (0)
    Child SP               IP Call Site
00007FFD28B42C58 00007fb22c1a8ed9 [HelperMethodFrame_PROTECTOBJ: 00007ffd28b42c58] System.RuntimeMethodHandle.InvokeMethod(System.Object, System.Object[], System.Signature, Boolean, Boolean)
00007FFD28B42DD0 00007FB1B1334F67 System.Reflection.RuntimeMethodInfo.Invoke(System.Object, System.Reflection.BindingFlags, System.Reflection.Binder, System.Object[], System.Globalization.CultureInfo) [/root/coreclr/src/mscorlib/src/System/Reflection/RuntimeMethodInfo.cs @ 472]
00007FFD28B42E20 00007FB1B18D33ED SymbolTestApp.Program.Foo4(System.String) [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 54]
00007FFD28B42ED0 00007FB1B18D2FC4 SymbolTestApp.Program.Foo2(Int32, System.String) [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 29]
00007FFD28B42F00 00007FB1B18D2F5A SymbolTestApp.Program.Foo1(Int32, System.String) [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 24]
00007FFD28B42F30 00007FB1B18D168E SymbolTestApp.Program.Main(System.String[]) [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 19]
00007FFD28B43210 00007fb22aa9cedf [GCFrame: 00007ffd28b43210]
00007FFD28B43610 00007fb22aa9cedf [GCFrame: 00007ffd28b43610]
```

To see an unhandled exception that killed your app:

```console
> pe -lines
Exception object: 00007fb18c038590
Exception type:   System.Reflection.TargetInvocationException
Message:          Exception has been thrown by the target of an invocation.
InnerException:   System.Exception, Use !PrintException 00007FB18C038368 to see more.
StackTrace (generated):
SP               IP               Function
00007FFD28B42DD0 0000000000000000 System.Private.CoreLib.dll!System.RuntimeMethodHandle.InvokeMethod(System.Object, System.Object[], System.Signature, Boolean, Boolean)
00007FFD28B42DD0 00007FB1B1334F67 System.Private.CoreLib.dll!System.Reflection.RuntimeMethodInfo.Invoke(System.Object, System.Reflection.BindingFlags, System.Reflection.Binder, System.Object[], System.Globalization.CultureInfo)+0xa7 [/root/coreclr/src/mscorlib/src/System/Reflection/RuntimeMethodInfo.cs @ 472]
00007FFD28B42E20 00007FB1B18D33ED SymbolTestApp.dll!SymbolTestApp.Program.Foo4(System.String)+0x15d [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 54]
00007FFD28B42ED0 00007FB1B18D2FC4 SymbolTestApp.dll!SymbolTestApp.Program.Foo2(Int32, System.String)+0x34 [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 29]
00007FFD28B42F00 00007FB1B18D2F5A SymbolTestApp.dll!SymbolTestApp.Program.Foo1(Int32, System.String)+0x3a [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 24]
00007FFD28B42F30 00007FB1B18D168E SymbolTestApp.dll!SymbolTestApp.Program.Main(System.String[])+0x6e [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 19]

StackTraceString: <none>
HResult: 80131604
```

## Special instructions for Docker

If you're running under Docker, dump collection requires `SYS_PTRACE` capabilities (`--cap-add=SYS_PTRACE` or `--privileged`).

On Microsoft .NET SDK Linux Docker images, some `dotnet-dump` commands can throw the following exception:

> Unhandled exception: System.DllNotFoundException: Unable to load shared library 'libdl.so' or one of its dependencies' exception.

To work around this problem, install the "libc6-dev" package.

## See also

- [Collecting and analyzing memory dumps blog](https://devblogs.microsoft.com/dotnet/collecting-and-analyzing-memory-dumps/)
- [Heap analysis tool (dotnet-gcdump)](dotnet-gcdump.md)
