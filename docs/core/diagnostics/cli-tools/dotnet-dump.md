---
title: dotnet-dump - .NET Core
description: Installing and using the dotnet-dump command-line tool.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/21/2019
---
# Dump collection and analysis utility (`dotnet-dump`)

The `dotnet-dump` CLI global tool is a way to collect and analyze Windows and Linux dumps all without any native debugger involved like `lldb` on Linux. This tool is important on platforms like Alpine Linux where a fully working `lldb` isn't available. The `dotnet-dump` tool will allow you to run SOS commands to analyze crashes and the GC, but it isn't a native debugger so things like displaying native stack frames aren't supported.

> [!NOTE]
> `dotnet-dump` is not supported on macOS.

## Installing `dotnet-dump`

To install the latest release version of the `dotnet-dump` [NuGet package](https://www.nuget.org/packages/dotnet-dump):

```bash
$ dotnet tool install -g dotnet-dump
You can invoke the tool using the following command: dotnet-dump
Tool 'dotnet-dump' (version '3.0.0') was successfully installed.
```

For details and other options, see [Installing the diagnostics tools](installing.md).

## Using `dotnet-dump`

The next step is to collect a dump. This step can be skipped if a core dump has already been generated. The operating system or the .NET Core runtime's built-in [dump generation feature](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/xplat-minidump-generation.md#configurationpolicy) can each create core dumps.

On Linux, the runtime version must be 3.0 or greater.

```bash
$ dotnet-dump collect --process-id 1902
Writing minidump to file ./core_20190226_135837
Written 98983936 bytes (24166 pages) to core file
Complete
```

Now `analyze` the core dump.

```bash
$ dotnet-dump analyze ./core_20190226_135850
Loading core dump: ./core_20190226_135850
Ready to process analysis commands. Type 'help' to list available commands or 'help [command]' to get detailed help on a command.
Type 'quit' or 'exit' to exit the session.
>
```

This action brings up an interactive session that accepts commands like:

```bash
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

To see an unhandled exception that terminated your app:

```bash
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

To display the help:

 ```bash
> help
Usage:
    dotnet-dump [command]

Commands:
    exit, quit                           Exit interactive mode.
    help <command>                       Display help for a command.
    lm, modules                          Displays the native modules in the process.
    threads, setthread <threadid>        Sets or displays the current thread id for the SOS commands.
    clrstack <arguments>                 Provides a stack trace of managed code only.
    clrthreads <arguments>               List the managed threads running.
    dumpasync <arguments>                Displays info about async state machines on the garbage-collected heap.
    dumpassembly <arguments>             Displays details about an assembly.
    dumpclass <arguments>                Displays information about a EE class structure at the specified address.
    dumpdelegate <arguments>             Displays information about a delegate.
    dumpdomain <arguments>               Displays information all the AppDomains and all assemblies within the domains.
    dumpheap <arguments>                 Displays info about the garbage-collected heap and collection statistics about objects.
    dumpil <arguments>                   Displays the Microsoft intermediate language (MSIL) that is associated with a managed method.
    dumplog <arguments>                  Writes the contents of an in-memory stress log to the specified file.
    dumpmd <arguments>                   Displays information about a MethodDesc structure at the specified address.
    dumpmodule <arguments>               Displays information about a EE module structure at the specified address.
    dumpmt <arguments>                   Displays information about a method table at the specified address.
    dumpobj <arguments>                  Displays info about an object at the specified address.
    dso, dumpstackobjects <arguments>    Displays all managed objects found within the bounds of the current stack.
    eeheap <arguments>                   Displays info about process memory consumed by internal runtime data structures.
    finalizequeue <arguments>            Displays all objects registered for finalization.
    gcroot <arguments>                   Displays info about references (or roots) to an object at the specified address.
    gcwhere <arguments>                  Displays the location in the GC heap of the argument passed in.
    ip2md <arguments>                    Displays the MethodDesc structure at the specified address in code that has been JIT-compiled.
    name2ee <arguments>                  Displays the MethodTable structure and EEClass structure for the specified type or method in the specified module.
    pe, printexception <arguments>       Displays and formats fields of any object derived from the Exception class at the specified address.
    syncblk <arguments>                  Displays the SyncBlock holder info.
    histclear <arguments>                Releases any resources used by the family of Hist commands.
    histinit <arguments>                 Initializes the SOS structures from the stress log saved in the debuggee.
    histobj <arguments>                  Examines all stress log relocation records and displays the chain of garbage collection relocations that may have led to the address passed in as an argument.
    histobjfind <arguments>              Displays all the log entries that reference an object at the specified address.
    histroot <arguments>                 Displays information related to both promotions and relocations of the specified root.
    setsymbolserver <arguments>          Enables the symbol server support
    soshelp <arguments>                  Displays all available commands when no parameter is specified, or displays detailed help information about the specified command. soshelp <command>
```

## Docker special instructions

If you're running under docker, dump collection requires `SYS_PTRACE` docker capabilities (`--cap-add=SYS_PTRACE or --privileged`).

On Microsoft .NET Core SDK Linux docker images, some `dotnet-dump` commands can throw `Unhandled exception: System.DllNotFoundException: Unable to load shared library 'libdl.so' or one of its dependencies` exception. To work around this problem, install the "libc6-dev" package.
