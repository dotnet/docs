---
title: Dumps - .NET
description: An introduction to dumps in .NET.
ms.date: 10/12/2020
---

# Dumps

A dump is a file that contains a snapshot of the process at the time it was created and can be useful for examining the state of your application. Dumps can be used to debug your .NET application when it is difficult to attach a debugger to it such as production or CI environments. Using dumps allows you to capture the state of the problematic process and examine it without having to stop the application.

## Collect dumps

Dumps can be collected in a variety of ways depending on which platform you are running your app on.

> [!NOTE]
> Collecting a dump inside a container requires PTRACE capability, which can be added via `--cap-add=SYS_PTRACE` or `--privileged`.
> [!NOTE]
> Dumps may contain sensitive information because they can contain the full memory of the running process. Handle them with any security restrictions and guidances in mind.

### Collect dumps on crash

You can use environment variables to configure your application to collect a dump upon a crash. This is helpful when you want to get an understanding of why a crash happened. For example, capturing a dump when an exception is thrown helps you identify an issue by examining the state of the app when it crashed.

The following table shows the environment variables you can configure for collecting dumps on a crash.

|Environment variable|Description|Default value|
|-------|---------|---|
|`COMPlus_DbgEnableMiniDump` or `DOTNET_DbgEnableMiniDump`|If set to 1, enable core dump generation.|0|
|`COMPlus_DbgMiniDumpType` or `DOTNET_DbgMiniDumpType`|Type of dump to be collected. For more information, see the table below|2 (`MiniDumpWithPrivateReadWriteMemory`)|
|`COMPlus_DbgMiniDumpName` or `DOTNET_DbgMiniDumpName`|Path to a file to write the dump to.|`/tmp/coredump.<pid>`|
|`COMPlus_CreateDumpDiagnostics` or `DOTNET_CreateDumpDiagnostics`|If set to 1, enable diagnostic logging of dump process.|0|

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

The following table shows all the values you can use for `DOTNET_DbgMiniDumpType`. For example, setting `DOTNET_DbgMiniDumpType` to 1 means `MiniDumpNormal` type dump will be collected on a crash.

|Value|Name|Description|
|-----|----|-----------|
|1|`MiniDumpNormal`|Include just the information necessary to capture stack traces for all existing threads in a process. Limited GC heap memory and information.|
|2|`MiniDumpWithPrivateReadWriteMemory`|Includes the GC heaps and information necessary to capture stack traces for all existing threads in a process.|
|3|`MiniDumpFilterTriage`|Same as `MiniDumpNormal`, but removes personal user information, such as paths and passwords.|
|4|`MiniDumpWithFullMemory`|Include all accessible memory in the process. The raw memory data is included at the end, so that the initial structures can be mapped directly without the raw memory information. This option can result in a very large file.|

### Collect dumps at a specific point in time

You may want to collect a dump when the app hasn't crashed yet. For example, if you want to examine the state of an application that seems to be in a deadlock, configuring the environment variables to collect dumps on crash will not be helpful because the app is still running.

To collect dump at your own request, you can use `dotnet-dump`, which is a CLI tool for collecting and analyzing dumps. For more information on how to use it to collect dumps with `dotnet-dump`, see [Dump collection and analysis utility](dotnet-dump.md).

## Analyze dumps

You can analyze dumps using the [`dotnet-dump`](dotnet-dump.md) CLI tool or with [Visual Studio](/visualstudio/debugger/using-dump-files).

> [!NOTE]
> Visual Studio version 16.8 and later allows you to [open Linux dumps](https://devblogs.microsoft.com/visualstudio/linux-managed-memory-dump-debugging/) generated on .NET Core 3.1.7 or later.
> [!NOTE]
> If native debugging is necessary, the [SOS debugger extension](sos-debugging-extension.md) can be used with [LLDB on Linux and macOS](debug-linux-dumps.md#analyze-dumps-on-linux). SOS is also supported with [Windbg/cdb](/windows-hardware/drivers/debugger/debugger-download-tools) on Windows, although Visual Studio is recommended.

## See also

Learn more about how you can leverage dumps to help diagnosing problems in your .NET application.

* [Debug Linux dumps](debug-linux-dumps.md) tutorial walks you through how to debug a dump that was collected in Linux.

* [Debug deadlock](debug-deadlock.md) tutorial walks you through how to debug a deadlock in your .NET application using dumps.
