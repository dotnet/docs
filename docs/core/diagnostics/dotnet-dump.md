---
title: dotnet-dump diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-dump CLI tool to collect and analyze Windows and Linux dumps without any native debugger.
ms.date: 11/17/2020
ms.topic: reference
ms.custom: linux-related-content
---
# Dump collection and analysis utility (dotnet-dump)

**This article applies to:** ✔️ `dotnet-dump` version 3.0.47001 and later versions

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
  | Windows | [x86](https://aka.ms/dotnet-dump/win-x86) \| [x64](https://aka.ms/dotnet-dump/win-x64) \| [Arm](https://aka.ms/dotnet-dump/win-arm) \| [Arm-x64](https://aka.ms/dotnet-dump/win-arm64) |
  | Linux   | [x64](https://aka.ms/dotnet-dump/linux-x64) \| [Arm](https://aka.ms/dotnet-dump/linux-arm) \| [Arm64](https://aka.ms/dotnet-dump/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-dump/linux-musl-x64) \| [musl-Arm64](https://aka.ms/dotnet-dump/linux-musl-arm64) |

> [!NOTE]
> To use `dotnet-dump` on an x86 app, you need a corresponding x86 version of the tool.

## Synopsis

```console
dotnet-dump [-h|--help] [--version] <command>
```

## Description

The `dotnet-dump` global tool is a way to collect and analyze dumps on Windows, Linux, and macOS without any native debugger involved. This tool is important on platforms like Alpine Linux where a fully working `lldb` isn't available. The `dotnet-dump` tool allows you to run SOS commands to analyze crashes and the garbage collector (GC), but it isn't a native debugger so things like displaying native stack frames aren't supported.

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
| [dotnet-dump ps](#dotnet-dump-ps)           |

## dotnet-dump collect

Captures a dump from a process.

### Synopsis

```console
dotnet-dump collect [-h|--help] [-p|--process-id] [-n|--name] [--type] [-o|--output] [--diag] [--crashreport]
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
  - `Triage` - A small dump containing module lists, thread lists, exception information, all stacks, and PII removed.

  If not specified, `Full` is the default.

- **`-o|--output <output_dump_path>`**

  The full path and file name where the collected dump should be written. Ensure that the user under which the dotnet process is running has write permissions to the specified directory.

  If not specified:

  - Defaults to *.\dump_YYYYMMDD_HHMMSS.dmp* on Windows.
  - Defaults to *./core_YYYYMMDD_HHMMSS* on Linux and macOS.

  YYYYMMDD is Year/Month/Day and HHMMSS is Hour/Minute/Second.

- **`--diag`**

  Enables dump collection diagnostic logging.

- **`--crashreport`**

  Enables crash report generation.

> [!NOTE]
> On Linux and macOS, this command expects the target application and `dotnet-dump` to share the same `TMPDIR` environment variable. Otherwise, the command will time out.

> [!NOTE]
> To collect a dump using `dotnet-dump`, it needs to be run as the same user as the user running target process or as root. Otherwise, the tool will fail to establish a connection with the target process.

> [!NOTE]
> Collecting a full or heap dump may cause the OS to page in substantial virtual memory for the target process. If the target process is running in a container with an enforced memory limit, the increased memory usage
> may cause the OS to terminate the container if the limit was exceeded. We recommend testing to ensure the memory limit is set high enough. Another option is to temporarily change or remove the limit
> prior to dump collection if your environment supports doing so.

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

  Runs the [command](#analyze-sos-commands) on start. Multiple instances of this parameter can be used in an invocation to chain commands. Commands will get run in the order that they are provided on the command line. If you want dotnet dump to exit after the commands, your last command should be 'exit'.

### Analyze SOS commands

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
| `dumpruntimetypes`                                  | Finds all System.RuntimeType objects in the GC heap and prints the type name and MethodTable they refer too. |
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
| `histobj`                                           | Examines all stress log relocation records and displays the chain of garbage collection relocations that may have led to the address passed in as an argument. |
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
| `sos`                                               | Executes various coreclr debugging commands. Use the syntax `sos <command-name> <args>`. For more information, see 'soshelp'. |
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
> Additional details can be found in [SOS Debugging Extension for .NET](sos-debugging-extension.md).

## dotnet-dump ps

 Lists the dotnet processes that dumps can be collected from.
 `dotnet-dump` version 6.0.320703 and later versions also display the command-line arguments that each process was started with, if available.

### Synopsis

```console
dotnet-dump ps [-h|--help]
```

### Example

Suppose you start a long-running app using the command ```dotnet run --configuration Release```. In another window, you run the ```dotnet-dump ps``` command. The output you'll see is as follows. The command-line arguments, if any, are shown in `dotnet-dump` version 6.0.320703 and later.

```console
> dotnet-dump ps

  21932 dotnet     C:\Program Files\dotnet\dotnet.exe   run --configuration Release
  36656 dotnet     C:\Program Files\dotnet\dotnet.exe
```

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

## Analyzing memory leaks and allocations

Memory leaks occur when your app holds references to objects that are no longer needed, preventing the garbage collector from reclaiming memory. Use `dotnet-dump` to identify memory leaks, find the largest objects, and understand where memory is being consumed.

For a complete walkthrough of debugging a memory leak, see [Debug a memory leak in .NET](debug-memory-leak.md).

### Identify the largest objects

Use the `dumpheap` command with the `-stat` option to see a summary of objects on the heap, sorted by total size:

```console
> dumpheap -stat

Statistics:
              MT    Count    TotalSize Class Name
00007f6c1eeefba8      576        59904 System.Reflection.RuntimeMethodInfo
00007f6c1dc021c8     1749        95696 System.SByte[]
00000000008c9db0     3847       116080      Free
00007f6c1e784a18      175       128640 System.Char[]
00007f6c1dbf5510      217       133504 System.Object[]
00007f6c1dc014c0      467       416464 System.Byte[]
00007f6c21625038        6      4063376 testwebapi.Controllers.Customer[]
00007f6c20a67498   200000      4800000 testwebapi.Controllers.Customer
00007f6c1dc00f90   206770     19494060 System.String
Total 428516 objects
```

This output shows you which types consume the most memory. In this example, `System.String` objects consume about 19 MB, and `Customer` objects consume about 4.8 MB.

### Identify objects by namespace or assembly

To find which modules or namespaces are consuming memory, use the `-type` option with a partial type name to filter results:

```console
> dumpheap -type MyCompany.Data -stat

Statistics:
              MT    Count    TotalSize Class Name
00007f6c21625038    15000      3600000 MyCompany.Data.CustomerRecord
00007f6c21625040     8000      2560000 MyCompany.Data.OrderHistory
00007f6c21625048     2000       960000 MyCompany.Data.ProductCache
Total 25000 objects, 7120000 bytes
```

This approach helps you identify which parts of your codebase are responsible for memory consumption.

### Find the highest number of instantiations

To see which types have the most instances, regardless of total size, look at the **Count** column in the `dumpheap -stat` output. Objects with high instance counts might indicate inefficient object creation or caching issues:

```console
> dumpheap -stat

Statistics:
              MT    Count    TotalSize Class Name
00007f6c1dc00f90   206770     19494060 System.String
00007f6c20a67498   200000      4800000 testwebapi.Controllers.Customer
00007f6c1dc021c8     1749        95696 System.SByte[]
```

In this example, there are 206,770 `String` instances and 200,000 `Customer` instances.

### Analyze object references with gcroot

After identifying large or numerous objects, use `gcroot` to find out why an object isn't being garbage collected. The `gcroot` command shows the reference chain from GC roots to a specific object:

```console
> dumpheap -mt 00007f6c20a67498
         Address               MT     Size
00007f6ad09421f8 00007f6c20a67498       24
...

> gcroot 00007f6ad09421f8

Thread 3f68:
    00007F6795BB58A0 00007F6C1D7D0745 testwebapi.Controllers.CustomerCache.GetAll()
        rbx:  (interior)
            ->  00007F6BDFFFF038 System.Object[]
            ->  00007F69D0033570 testwebapi.Controllers.Processor
            ->  00007F69D0033588 testwebapi.Controllers.CustomerCache
            ->  00007F69D00335A0 System.Collections.Generic.List`1[[testwebapi.Controllers.Customer]]
            ->  00007F6C000148A0 testwebapi.Controllers.Customer[]
            ->  00007F6AD0942258 testwebapi.Controllers.Customer

Found 1 root.
```

This output shows that the `Customer` object is held by a `CustomerCache` object, which helps you identify the source of the leak in your code.

### Analyze memory by object size

Use the `-min` and `-max` options to filter objects by size:

```console
> dumpheap -min 100000 -stat

Statistics:
              MT    Count    TotalSize Class Name
00007f6c21625038        6      4063376 testwebapi.Controllers.Customer[]
00007f6c1dc014c0       12       416464 System.Byte[]
Total 18 objects
```

This command shows only objects larger than 100,000 bytes, helping you focus on the biggest memory consumers.

## Finding deadlocks

Use `dotnet-dump` to diagnose deadlock situations where threads are blocked waiting for resources. For a complete deadlock debugging walkthrough, see [Debug a deadlock in .NET](debug-deadlock.md).

### List all threads

Use the `threads` command to see all managed threads:

```console
> threads
*0 0x1DBFF (121855)
 1 0x1DC01 (121857)
 2 0x1DC02 (121858)
 ...
```

### Examine thread stacks

Use `clrstack -all` to see the call stacks of all threads:

```console
> clrstack -all
```

Look for patterns where multiple threads are blocked on `Monitor.Enter` or similar synchronization primitives.

### Find lock owners

Use the `syncblk` command to see which threads hold locks and which threads are waiting:

```console
> syncblk
Index         SyncBlock MonitorHeld Recursion Owning Thread Info          SyncBlock Owner
   43 00000246E51268B8          603         1 0000024B713F4E30 5634  28   00000249654b14c0 System.Object
   44 00000246E5126908            3         1 0000024B713F47E0 51d4  29   00000249654b14d8 System.Object
```

The **MonitorHeld** column shows the number of threads waiting for the lock. The **Owning Thread Info** column shows which thread owns the lock.

## Configuring symbols to avoid UNKNOWN in call stacks

To see source file names and line numbers in call stacks instead of `UNKNOWN`, you need to configure symbol loading.

### Enable Microsoft symbol server

Use the `setsymbolserver` command to enable symbol downloading:

```console
> setsymbolserver -ms
```

This command enables downloading symbols from the Microsoft public symbol server.

### Load symbols for the runtime

To download symbols for the .NET runtime, use:

```console
> setsymbolserver -ms -loadsymbols
```

### Configure custom symbol paths

If your app uses private symbols, specify a custom symbol cache directory:

```console
> setsymbolserver -ms -cache /path/to/symbol/cache
```

Or add additional symbol search directories:

```console
> setsymbolserver -ms -directory /path/to/symbols
```

### Verify symbol loading

After configuring symbols, run `clrstack` again to verify that source file names and line numbers appear:

```console
> clrstack
OS Thread Id: 0x573d (0)
    Child SP               IP Call Site
00007FFD28B42E20 00007FB1B18D33ED SymbolTestApp.Program.Foo4(System.String) [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 54]
00007FFD28B42ED0 00007FB1B18D2FC4 SymbolTestApp.Program.Foo2(Int32, System.String) [/home/mikem/builds/SymbolTestApp/SymbolTestApp/SymbolTestApp.cs @ 29]
```

For more information about symbols, see [Symbols in .NET](symbols.md).

## GUI tools and IDE extensions

While `dotnet-dump` is a powerful command-line tool, several GUI tools and IDE extensions provide visual memory analysis capabilities:

### Visual Studio memory profiler

Visual Studio includes comprehensive memory profiling tools that provide graphical views of memory usage, allocations, and object references. These tools are available on Windows.

- **Memory Usage tool**: Provides snapshots of memory usage over time and lets you compare snapshots to identify leaks.
- **Diagnostic Tools window**: Shows real-time memory and CPU usage while debugging.
- **.NET Object Allocation Tracking**: Records all allocations and shows where objects are created.

For more information, see [Memory Usage in Visual Studio](/visualstudio/profiling/memory-usage).

### Visual Studio Code extensions

While Visual Studio Code doesn't have built-in memory profiling, you can use the C# debugger to inspect objects and variables during debugging sessions:

- **C# Dev Kit**: Provides debugging support for .NET applications.
- **Heap dump analysis**: Use `dotnet-dump` from the integrated terminal and analyze results.

For more information, see [Debugging in Visual Studio Code](https://code.visualstudio.com/docs/csharp/debugging).

### Other diagnostic tools

- **dotnet-monitor**: A tool that exposes diagnostic endpoints for monitoring and collecting diagnostics artifacts. It provides HTTP endpoints that can be used to collect dumps and traces. See [dotnet-monitor](dotnet-monitor.md).
- **PerfView**: A performance analysis tool for Windows that can collect and analyze memory and CPU traces. Available at [PerfView on GitHub](https://github.com/microsoft/perfview).
- **dotnet-gcdump**: A tool specifically designed for analyzing GC heap dumps with lower overhead than full dumps. See [dotnet-gcdump](dotnet-gcdump.md).

## Advanced memory analysis scenarios

### Compare multiple dumps

To understand memory growth over time, collect multiple dumps and compare them:

1. Collect a baseline dump: `dotnet-dump collect -p <pid> -o baseline.dmp`
1. Let your app run and consume more memory
1. Collect a second dump: `dotnet-dump collect -p <pid> -o after.dmp`
1. Analyze both dumps and compare the `dumpheap -stat` results

Look for types that have significantly more instances or larger total sizes in the second dump.

### Analyze memory for specific object types

To dump all instances of a specific type:

```console
> dumpheap -type Customer
         Address               MT     Size
00007f6ad09421f8 00007f6c20a67498       24
00007f6ad0942210 00007f6c20a67498       24
...
```

Then use `dumpobj` to examine individual objects:

```console
> dumpobj 00007f6ad09421f8
Name:        testwebapi.Controllers.Customer
MethodTable: 00007f6c20a67498
EEClass:     00007f6c21625000
Size:        24(0x18) bytes
File:        /app/testwebapi.dll
Fields:
              MT    Field   Offset                 Type VT     Attr            Value Name
00007f6c1dc00f90  4000001        8        System.String  0 instance 00007f6ad09421f0 Name
00007f6c1dbf4c18  4000002       10         System.Int32  1 instance               42 Id
```

## Troubleshooting dump collection issues

Dump collection requires the process to be able to call `ptrace`. If you are facing issues collecting dumps, the environment you are running on may be configured to restrict such calls. See our [Dumps: FAQ](faq-dumps.yml) for troubleshooting tips and potential solutions to common issues.

## See also

- [Collecting and analyzing memory dumps blog](https://devblogs.microsoft.com/dotnet/collecting-and-analyzing-memory-dumps/)
- [Heap analysis tool (dotnet-gcdump)](dotnet-gcdump.md)
