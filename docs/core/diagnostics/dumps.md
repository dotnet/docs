---
title: Dumps - .NET
description: An introduction to dumps in .NET.
ms.date: 10/31/2022
---

# Dumps

A dump is a file that contains a snapshot of the process at the time it was created and can be useful for examining the state of your application. Dumps can be used to debug your .NET application when it is difficult to attach a debugger to it such as production or CI environments. Using dumps allows you to capture the state of the problematic process and examine it without having to stop the application.

## Collect dumps

Dumps can be collected in a variety of ways depending on which platform you are running your app on.

> [!NOTE]
> Dumps may contain sensitive information because they can contain the full memory of the running process. Handle them with any security restrictions and guidances in mind.

> [!TIP]
> For frequently asked questions about dump collection, analysis, and other caveats, see [Dumps: FAQ](faq-dumps.yml).

### Collect dumps on crash

You can use environment variables to configure your application to collect a dump upon a crash. This is helpful when you want to get an understanding of why a crash happened. For example, capturing a dump when an exception is thrown helps you identify an issue by examining the state of the app when it crashed.

The following table shows the environment variables you can configure for collecting dumps on a crash.

|Environment variable|Description|Default value|
|-------|---------|---|
|`COMPlus_DbgEnableMiniDump` or `DOTNET_DbgEnableMiniDump`|If set to 1, enable core dump generation.|0|
|`COMPlus_DbgMiniDumpType` or `DOTNET_DbgMiniDumpType`|Type of dump to be collected. For more information, see the table below|2 (`MiniDumpWithPrivateReadWriteMemory`)|
|`COMPlus_DbgMiniDumpName` or `DOTNET_DbgMiniDumpName`|Path to a file to write the dump to. Ensure that the user under which the dotnet process is running has write permissions to the specified directory.|`/tmp/coredump.<pid>`|
|`COMPlus_CreateDumpDiagnostics` or `DOTNET_CreateDumpDiagnostics`|If set to 1, enables diagnostic logging of dump process.|0|
|`COMPlus_EnableCrashReport` or `DOTNET_EnableCrashReport`|(Requires .NET 6 or later, not supported on Windows) If set to 1, the runtime generates a JSON-formatted crash report that includes information about the threads and stack frames of the crashing application. The crash report name is the dump path or name with *.crashreport.json* appended.
|`COMPlus_CreateDumpVerboseDiagnostics` or `DOTNET_CreateDumpVerboseDiagnostics`|(Requires .NET 7 or later) If set to 1, enables verbose diagnostic logging of the dump process.|0|
|`COMPlus_CreateDumpLogToFile` or `DOTNET_CreateDumpLogToFile`|(Requires .NET 7 or later) The path of the file to which the diagnostic messages should be written. If unset, the diagnostic messages are written to the console of the crashing application.|

> [!NOTE]
> .NET 7 standardizes on the prefix `DOTNET_` instead of `COMPlus_` for these environment variables. However, the `COMPlus_` prefix will continue to work. If you're using a previous version of the .NET runtime, you should still use the `COMPlus_` prefix for environment variables.

Starting in .NET 5, `DOTNET_MiniDumpName` may also include formatting template specifiers that will be filled in dynamically:

|Specifier|Value|
|---------|-----|
|%%|A single % character|
|%p|PID of dumped process|
|%e|The process executable filename|
|%h|Host name return by `gethostname()`|
|%t|Time of dump, expressed as seconds since the Epoch, 1970-01-01 00:00:00 +0000 (UTC)|

The following table shows all the values you can use for `DOTNET_DbgMiniDumpType`. For example, setting `DOTNET_DbgMiniDumpType` to 1 means `MiniDumpNormal` type dump will be collected on a crash.

|Value|Name|Description|
|-----|----|-----------|
|1|`Mini`|A small dump containing module lists, thread lists, exception information, and all stacks.|
|2|`Heap`|A large and relatively comprehensive dump containing module lists, thread lists, all stacks, exception information, handle information, and all memory except for mapped images.|
|3|`Triage`|Same as `Mini`, but removes personal user information, such as paths and passwords.|
|4|`Full`|The largest dump containing all memory including the module images.|

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
