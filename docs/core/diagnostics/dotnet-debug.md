---
title: dotnet-debug diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-debug CLI tool to attach to live processes and analyze dumps for CoreCLR-based .NET applications.
ms.date: 02/09/2026
ms.topic: reference
ms.custom: linux-related-content
ai-usage: ai-assisted
---
# Live process debugging and dump analysis utility (dotnet-debug)

**This article applies to:** ✔️ `dotnet-debug` version 0.0.710501 and later versions

> [!NOTE]
> `dotnet-debug` currently only supports CoreCLR-based applications and is not currently supported on macOS.

## Install

There are two ways to download and install `dotnet-debug`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-debug` [NuGet package](https://www.nuget.org/packages/dotnet-debug), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-debug
  ```

- **Direct download:**

  Download the tool executable that matches your platform:

  | OS      | Platform                                                                                                                                                                                                                                                                 |
  | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
  | Windows | [x86](https://aka.ms/dotnet-debug/win-x86) \| [x64](https://aka.ms/dotnet-debug/win-x64) \| [Arm](https://aka.ms/dotnet-debug/win-arm) \| [Arm-x64](https://aka.ms/dotnet-debug/win-arm64)                                                                               |
  | Linux   | [x64](https://aka.ms/dotnet-debug/linux-x64) \| [Arm](https://aka.ms/dotnet-debug/linux-arm) \| [Arm64](https://aka.ms/dotnet-debug/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-debug/linux-musl-x64) \| [musl-Arm64](https://aka.ms/dotnet-debug/linux-musl-arm64) |

## Synopsis

```console
dotnet-debug [-h|--help] [--version] <command>
```

## Description

The `dotnet-debug` global tool lets you attach to live .NET processes and analyze dump files interactively. Unlike `dotnet-dump`, which focuses on dump collection and offline analysis, `dotnet-debug` is designed for live process inspection. It supports all the same [SOS debugging commands](#debugging-sos-commands) as `dotnet-dump`.

This tool is useful on platforms like Alpine Linux where a fully working `lldb` isn't available. The `dotnet-debug` tool runs SOS commands to analyze managed state and heap diagnostics, but it isn't a native debugger, so displaying native stack frames isn't supported.

## Options

- **`--version`**

  Displays the version of the dotnet-debug utility.

- **`-h|--help`**

  Shows command-line help.

## Commands

| Command                                           |
| ------------------------------------------------- |
| [dotnet-debug attach](#dotnet-debug-attach)       |
| [dotnet-debug open-dump](#dotnet-debug-open-dump) |

## dotnet-debug attach

Attaches to a live process and starts an interactive shell with debugging commands to explore it.

### Synopsis

```console
dotnet-debug attach <process-id> [-c|--commands <debug_command>] [--accept-license-agreement]
```

### Arguments

- **`<process-id>`**

  The process ID to attach to and analyze.

### Options

- **`-c|--commands <debug_command>`**

  Runs the commands on start. Multiple instances of this parameter can be used in an invocation to chain commands. Commands run in the order they're provided on the command line. If you want `dotnet-debug` to exit after the commands, your last command should be `exit`.

- **`--accept-license-agreement`**

  Accepts the licensing agreement without prompting.

### Example

Attach to a running process with ID 1234:

```console
$ dotnet-debug attach 1234
Attaching to process: 1234 ...
Ready to process analysis commands. Type 'help' to list available commands or 'help [command]' to get detailed help on a command.
Type 'quit' or 'exit' to exit the session.
>
```

Run a command on attach and then exit:

```console
dotnet-debug attach 1234 -c clrstack -c exit
```

## dotnet-debug open-dump

Starts an interactive shell with debugging commands to explore a dump file.

### Synopsis

```console
dotnet-debug open-dump <dump_path> [-c|--commands] [--accept-license-agreement]
```

### Arguments

- **`<dump_path>`**

  The path to the dump file to analyze.

### Options

- **`-c|--commands <debug_command>`**

  Runs the commands on start. Multiple instances of this parameter can be used in an invocation to chain commands. Commands run in the order they're provided on the command line. If you want `dotnet-debug` to exit after the commands, your last command should be `exit`.

- **`--accept-license-agreement`**

  Accepts the licensing agreement without prompting.

### Example

Open and analyze a dump file:

```console
$ dotnet-debug open-dump ./core_20260209_135837
Loading dump: ./core_20260209_135837 ...
Ready to process analysis commands. Type 'help' to list available commands or 'help [command]' to get detailed help on a command.
Type 'quit' or 'exit' to exit the session.
>
```

## Debugging SOS commands

Both the `attach` and `open-dump` commands bring up an interactive session that accepts the following [SOS commands](#debugging-sos-commands).

| Command                                             | Function |
|-----------------------------------------------------|----------|
| `analyzeoom`                                        | Displays the info of the last OOM that occurred on an allocation request to the GC heap. |
| `clrmodules`                                        | Lists the managed modules in the process. |
| `clrstack`                                          | Provides a stack trace of managed code only. |
| `clrthreads`                                        | Lists the managed threads that are running. |
| `clru`                                              | Displays an annotated disassembly of a managed method. |
| `d` or `readmemory`                                 | Dumps memory contents. |
| `dbgout`                                            | Enables/disables (`-off`) internal SOS logging. |
| `dso`                                               | Displays all managed objects found within the bounds of the current stack. |
| `dumpalc`                                           | Displays details about a collectible AssemblyLoadContext to which the specified object is loaded. |
| `dumparray`                                         | Displays details about a managed array. |
| `dumpasync`                                         | Displays info about async state machines on the garbage-collected heap. |
| `dumpassembly`                                      | Displays details about an assembly. |
| `dumpclass`                                         | Displays information about the `EEClass` structure at the specified address. |
| `dumpconcurrentdictionary`                          | Displays concurrent dictionary content. |
| `dumpconcurrentqueue`                               | Displays concurrent queue content. |
| `dumpdelegate`                                      | Displays information about a delegate. |
| `dumpdomain`                                        | Displays information about the all assemblies within all the AppDomains or the specified one. |
| `dumpgcdata`                                        | Displays information about the GC data. |
| `dumpgen`                                           | Displays heap content for the specified generation. |
| `dumpheap`                                          | Displays info about the garbage-collected heap and collection statistics about objects. |
| `dumpil`                                            | Displays the common intermediate language (CIL) that's associated with a managed method. |
| `dumplog`                                           | Writes the contents of an in-memory stress log to the specified file. |
| `dumpmd`                                            | Displays information about the `MethodDesc` structure at the specified address. |
| `dumpmodule`                                        | Displays information about the module at the specified address. |
| `dumpmt`                                            | Displays information about the method table at the specified address. |
| `dumpobj`                                           | Displays info the object at the specified address. |
| `dumpruntimetypes`                                  | Finds all System.RuntimeType objects in the GC heap and prints the type name and MethodTable they refer to. |
| `dumpsig`                                           | Dumps the signature of a method or field specified by `<sigaddr> <moduleaddr>`. |
| `dumpsigelem`                                       | Dumps a single element of a signature object. |
| `dumpstackobjects`                                  | Displays all managed objects found within the bounds of the current stack. |
| `dumpvc`                                            | Displays info about the fields of a value class. |
| `eeheap`                                            | Displays info about process memory consumed by internal runtime data structures. |
| `eestack`                                           | Runs `dumpstack` on all threads in the process. |
| `eeversion`                                         | Displays information about the runtime and SOS versions. |
| `ehinfo`                                            | Displays the exception handling blocks in a JIT-ed method. |
| `exit` or `quit`                                    | Exits interactive mode. |
| `finalizequeue`                                     | Displays all objects registered for finalization. |
| `findappdomain`                                     | Attempts to resolve the AppDomain of a GC object. |
| `gchandles`                                         | Displays statistics about garbage collector handles in the process. |
| `gcheapstat`                                        | Displays statistics about garbage collector. |
| `gcinfo`                                            | Displays the JIT GC encoding for a method. |
| `gcroot`                                            | Displays info about references (or roots) to the object at the specified address. |
| `gcwhere`                                           | Displays the location in the GC heap of the specified address. |
| `histclear`                                         | Releases any resources used by the family of Hist commands. |
| `histinit`                                          | Initializes the SOS structures from the stress log saved in the debuggee. |
| `histobj`                                           | Examines all stress log relocation records and displays the chain of garbage collection relocations that might have led to the address passed in as an argument. |
| `histobjfind`                                       | Displays all the log entries that reference the object at the specified address. |
| `histroot`                                          | Displays information related to both promotions and relocations of the specified root. |
| `histstats`                                         | Displays stress log stats. |
| `ip2md`                                             | Displays the `MethodDesc` structure at the specified address in code that has been JIT-compiled. |
| `listnearobj`                                       | Displays the object preceding and succeeding the specified address. |
| `logopen`                                           | Enables console file logging. |
| `logclose`                                          | Disables console file logging. |
| `logging`                                           | Enables/disables internal SOS logging. |
| `lm` or `modules`                                   | Displays the native modules in the process. |
| `name2ee`                                           | Displays the `MethodTable` and `EEClass` structures for the specified type or method in the specified module. |
| `objsize`                                           | Displays the size of the specified object. |
| `parallelstacks`                                    | Displays the merged threads stack similarly to the Visual Studio 'Parallel Stacks' panel. |
| `pathto`                                            | Displays the GC path from `<root>` to `<target>`. |
| `pe` or `printexception`                            | Displays and formats fields of any object derived from the <xref:System.Exception> class at the specified address. |
| `r` or `registers`                                  | Displays the thread's registers. |
| `runtimes`                                          | Lists the runtimes in the target or changes the default runtime. |
| `setclrpath`                                        | Sets the path to load coreclr dac/dbi files using `setclrpath <path>`. |
| `setsymbolserver`                                   | Enables the symbol server support. |
| `sos`                                               | Executes various coreclr debugging commands. Use the syntax `sos <command-name> <args>`. For more information, use `soshelp`. |
| `soshelp` or `help`                                 | Displays all available commands. |
| `soshelp <command>` or `help <command>`             | Displays the specified command. |
| `syncblk`                                           | Displays the SyncBlock holder info. |
| `taskstate`                                         | Displays a Task state in a human readable format. |
| `threadpool`                                        | Displays info about the runtime thread pool. |
| `threadpoolqueue`                                   | Displays queued thread pool work items. |
| `threadstate`                                       | Pretty prints the meaning of a threads state. |
| `threads <threadid>` or `setthread <threadid>`      | Sets or displays the current thread ID for the SOS commands. |
| `timerinfo`                                         | Displays information about running timers. |
| `token2ee`                                          | Displays the MethodTable structure and MethodDesc structure for the specified token and module. |
| `traverseheap`                                      | Writes out heap information to a file in a format understood by the CLR Profiler. |
| `verifyheap`                                        | Checks the GC heap for signs of corruption. |
| `verifyobj`                                         | Checks the object that is passed as an argument for signs of corruption. |

> [!NOTE]
> For more details, see [SOS Debugging Extension for .NET](sos-debugging-extension.md).

## Use `dotnet-debug` to attach to a live process

The following example shows how to attach to a running .NET process and investigate a thread pool issue:

```console
$ dotnet-debug attach 1902
Attaching to process: 1902 ...
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
00007FFD28B42DD0 00007FB1B1334F67 System.Reflection.RuntimeMethodInfo.Invoke(System.Object, System.Reflection.BindingFlags, System.Reflection.Binder, System.Object[], System.Globalization.CultureInfo)
00007FFD28B42E20 00007FB1B18D33ED SymbolTestApp.Program.Foo4(System.String)
00007FFD28B42ED0 00007FB1B18D2FC4 SymbolTestApp.Program.Foo2(Int32, System.String)
00007FFD28B42F00 00007FB1B18D2F5A SymbolTestApp.Program.Foo1(Int32, System.String)
00007FFD28B42F30 00007FB1B18D168E SymbolTestApp.Program.Main(System.String[])
```

To see an unhandled exception:

```console
> pe -lines
Exception object: 00007fb18c038590
Exception type:   System.Reflection.TargetInvocationException
Message:          Exception has been thrown by the target of an invocation.
InnerException:   System.Exception, Use !PrintException 00007FB18C038368 to see more.
StackTrace (generated):
SP               IP               Function
00007FFD28B42DD0 0000000000000000 System.Private.CoreLib.dll!System.RuntimeMethodHandle.InvokeMethod(System.Object, System.Object[], System.Signature, Boolean, Boolean)
00007FFD28B42DD0 00007FB1B1334F67 System.Private.CoreLib.dll!System.Reflection.RuntimeMethodInfo.Invoke(System.Object, System.Reflection.BindingFlags, System.Reflection.Binder, System.Object[], System.Globalization.CultureInfo)+0xa7
00007FFD28B42E20 00007FB1B18D33ED SymbolTestApp.dll!SymbolTestApp.Program.Foo4(System.String)+0x15d

StackTraceString: <none>
HResult: 80131604
```

## `dotnet-debug` vs `dotnet-dump`

`dotnet-debug` and `dotnet-dump` share the same SOS debugging commands but serve different primary purposes:

| Feature                    | `dotnet-debug` | `dotnet-dump` |
| -------------------------- | -------------- | ------------- |
| Attach to a live process   | ✔️             | ❌            |
| Collect dumps              | ❌             | ✔️            |
| Analyze dump files         | ✔️             | ✔️            |
| List .NET processes (`ps`) | ❌             | ✔️            |

Use `dotnet-debug` when you need to debug a live process interactively. Use `dotnet-dump` when you need to collect dumps or analyze them offline.

## See also

- [Dump collection and analysis utility (dotnet-dump)](dotnet-dump.md)
- [SOS Debugging Extension for .NET](sos-debugging-extension.md)
- [Heap analysis tool (dotnet-gcdump)](dotnet-gcdump.md)
