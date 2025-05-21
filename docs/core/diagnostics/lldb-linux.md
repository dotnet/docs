---
title: Install and use LLDB on Linux
description: Instructions for installing and using LLDB to debug a .NET application on Linux
ms.date: 02/13/2025
ms.topic: install-set-up-deploy
---

# Install and use LLDB on Linux

[LLDB](https://lldb.llvm.org/) is a powerful, open-source debugger that's part of the LLVM project. When you're debugging .NET applications on Linux, you can use LLDB with the [.NET debugger extensions](debugger-extensions.md) to inspect managed application state. LLDB can work with both dumps and live processes.

## Install

### Install LLDB

The .NET debugger extensions require at least LLDB 3.9 but version 10.0 or later is recommended. The following sections provide instructions for installing LLDB on popular Linux distributions.

#### AzureLinux 2.0 and later

To install the LLDB packages:

```console
    sudo tdnf install lldb
```

To launch LLDB:

```console
    lldb
```

#### Ubuntu 20.04 and later

To install the LLDB packages:

```console
    sudo apt-get update
    sudo apt-get install lldb
```

To launch LLDB:

```console
    lldb
```

#### Alpine 3.9 and later

To install the LLDB packages:

```console
    apk update
    apk add lldb py3-lldb
```

To launch LLDB:

```console
    lldb
```

#### Debian 9 and later

To install the LLDB packages:

```console
    sudo apt-get install lldb-3.9 python-lldb-3.9
```

To launch LLDB:

```console
    lldb-3.9
```

#### Fedora 29 and later

To install the LLDB packages:

```console
    sudo dnf install lldb python2-lldb
```

To launch LLDB:

```console
    lldb
```

#### RHEL 7.5 and later

See [LLDB](https://access.redhat.com/documentation/en-us/red_hat_developer_tools/1/html/using_llvm_12.0.1_toolset/assembly_llvm#proc_installing-comp-toolset_assembly_llvm) on RedHat's website.

### Install the .NET debugger extensions

Install the .NET debugger extensions using the [dotnet-debugger-extensions](dotnet-debugger-extensions.md) install tool. The installer creates a `.lldbinit` file in your home directory that automatically loads the extensions when you start LLDB.

> [!NOTE]
> The version of the debugger extensions does not need to match the version of the .NET runtime. We recommend using the latest extension version.

> [!NOTE]
> Installing with [dotnet-sos](dotnet-sos.md) instead of [dotnet-debugger-extensions](dotnet-debugger-extensions.md) also works, but only installs a subset of the extension commands.

## Getting started with LLDB

This example shows using LLDB to attach to a pre-existing .NET application (`dotnet webapp.dll`) that's running on the machine.

1. Use the `ps` command to find the process ID (PID) of the .NET application you want to debug.

   ```console
       $ ps -ao pid,cmd
       PID CMD
       697 -bash
       229233 dotnet webapp.dll
       229696 ps -ao pid,cmd
       ... other processes omitted for brevity ...
   ```

   In this case, the PID of the .NET application to debug is 229233.

1. Run LLDB and attach to the process.

   Launch LLDB using the appropriate command for your distribution (shown previously in the [Install LLDB](#install-lldb) section). Often this is just `lldb`, but some distros require a version number in the name, like `lldb-3.9`.

   ```console
       $ lldb
       Current symbol store settings:
       -> Cache: /home/username/.dotnet/symbolcache
       -> Server: https://msdl.microsoft.com/download/symbols/ Timeout: 4 RetryCount: 0
       (lldb)
   ```

1. At the `(lldb)` prompt, run the process attach command.

   ```console
       (lldb) process attach --pid 229233
       Process 229233 stopped
       * thread #1, name = 'dotnet', stop reason = signal SIGSTOP
           frame #0: 0x00007f2ca7c11117 libc.so.6`___lldb_unnamed_symbol3457 + 231
       libc.so.6`___lldb_unnamed_symbol3457:
       ->  0x7f2ca7c11117 <+231>: movl   %r12d, %edi
           0x7f2ca7c1111a <+234>: movq   %rax, %rbx
           0x7f2ca7c1111d <+237>: callq  0x7f2ca7c10a60            ; ___lldb_unnamed_symbol3445
           0x7f2ca7c11122 <+242>: jmp    0x7f2ca7c11089            ; <+89>
         thread #2, name = 'dotnet-ust', stop reason = signal SIGSTOP
           frame #0: 0x00007f2ca7c9e88d libc.so.6`syscall + 29
       libc.so.6`syscall:
       ... more output omitted ...
   ```

   The debugger is now attached and you can use both built-in LLDB commands and .NET debugger extension commands to inspect the process state.

   > [!NOTE]
   > If LLDB outputs 'error: attach failed: Operation not permitted', this means you don't have sufficient privileges to debug. The most reliable way to resolve this is to quit LLDB and restart using sudo. When elevated LLDB won't automatically run the normal .lldbinit script, you can do so explicitly by using the `--source` argument on the command line: `sudo lldb --source ~/.lldbinit`.

1. Run an example command

   The clrstack command displays the stack trace for .NET code on the currently selected thread.

   ```console
       (lldb) clrstack
       OS Thread Id: 0x497 (1)
               Child SP               IP Call Site
       00007FFD0877D260 00007f2ca7c11117 [HelperMethodFrame_1OBJ: 00007ffd0877d260] 
   System.Threading.Monitor.ObjWait(Int32, System.Object)
       00007FFD0877D390 00007F2C2864AA0E System.Threading.Monitor.Wait(System.Object, Int32)
       00007FFD0877D3A0 00007F2C28654625 System.Threading.ManualResetEventSlim.Wait(Int32, 
   System.Threading.CancellationToken)
       00007FFD0877D420 00007F2C286684A8 System.Threading.Tasks.Task.SpinThenBlockingWait(Int32, 
   System.Threading.CancellationToken)
       00007FFD0877D480 00007F2C2866832D System.Threading.Tasks.Task.InternalWaitCore(Int32, 
   System.Threading.CancellationToken)
       00007FFD0877D4D0 00007F2C286B2508 System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(System.Threading.Tasks.Task, System.Threading.Tasks.ConfigureAwaitOptions)
       00007FFD0877D4F0 00007F2C29281B45 Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run(Microsoft.Extensions.Hosting.IHost)
       00007FFD0877D510 00007F2C29121A7D Program.<Main>$(System.String[]) [/home/username/app/Program.cs @ 25]
   ```

## Next steps

To learn more about the commands available when debugging .NET applications with LLDB, see the documentation for the [.NET debugger extensions](debugger-extensions.md) and [LLDB](https://lldb.llvm.org/).

## See also

- [LLDB](https://lldb.llvm.org/) for more information about the LLDB debugger.
- [.NET debugger extensions](debugger-extensions.md) for a reference of the extension commands available.
- [dotnet-symbol](dotnet-symbol.md) for more details on installing and using the symbol download tool.
