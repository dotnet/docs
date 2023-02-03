---
title: Collect Dumps on Crash - .NET
description: How to collect a dump on a crash
ms.date: 12/13/2022
---

# Collect dumps on crash

Configuring your application to collect a dump on crash is done by setting specific environment variables. This is helpful when you want to get an understanding of why a crash happened. For example, capturing a dump when an exception is thrown helps you identify an issue by examining the state of the app when it crashed.

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

## File path templates

Starting in .NET 5, `DOTNET_DbgMiniDumpName` can also include formatting template specifiers that will be filled in dynamically:

|Specifier|Value|
|---------|-----|
|%%|A single % character|
|%p|PID of dumped process|
|%e|The process executable filename|
|%h|Host name return by `gethostname()`|
|%t|Time of dump, expressed as seconds since the Epoch, 1970-01-01 00:00:00 +0000 (UTC)|

## Types of mini dumps

The following table shows all the values you can use for `DOTNET_DbgMiniDumpType`. For example, setting `DOTNET_DbgMiniDumpType` to 1 means `MiniDumpNormal` type dump will be collected on a crash.

|Value|Name|Description|
|-----|----|-----------|
|1|`Mini`|A small dump containing module lists, thread lists, exception information, and all stacks.|
|2|`Heap`|A large and relatively comprehensive dump containing module lists, thread lists, all stacks, exception information, handle information, and all memory except for mapped images.|
|3|`Triage`|Same as `Mini`, but removes personal user information, such as paths and passwords.|
|4|`Full`|The largest dump containing all memory including the module images.|
