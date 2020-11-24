---
title: Dumps - .NET
description: An introduction to dumps in .NET Core.
ms.date: 10/12/2020
---

# Dumps

A dump is a file that contains snapshot of the process at the time they were created and can be useful for examining the state of your application for debugging. Dumps can be used for post-mortem debugging of your .NET application when it is difficult to attach a debugger to it (for example, when the app is running in production). Using dumps allows you to capture the state of the problematic process and examine it without having to stop it from running while being analyzed.

## Collect dumps

Dumps can be collected in a variety of ways depending on which platform you are running your app on.

> [!NOTE]
> Collecting a dump inside a container requires PTRACE capability which can be added via `--cap-add=SYS_PTRACE` or `--privileged`.

### Using dotnet-dump

`dotnet-dump` is a CLI tool that allows you to collect and analyze dumps. For more information on how to use it to collect dumps with `dotnet-dump`, refer to [its documentation](dotnet-dump.md).

### Using environment variables

For some situations, it may be more desirable to use environment variables to collect dumps. For example, capturing a dump when an exception is thrown helps you identify issue by examining the state of the app when it crashed.



COMPlus_DbgEnableMiniDump: if set to "1", enables this core dump generation. The default is NOT to generate a dump.
COMPlus_DbgMiniDumpType: See below. Default is "2" MiniDumpWithPrivateReadWriteMemory.
COMPlus_DbgMiniDumpName: if set, use as the template to create the dump path and file name. The pid can be placed in the name with %d. The default is /tmp/coredump.%d.
COMPlus_CreateDumpDiagnostics: if set to "1", enables the createdump utilities diagnostic messages (TRACE macro).

##