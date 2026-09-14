---
title: dnim trace command
description: The trace command identifies .NET processes.
author: joeloff
ms.date: 08/11/2026
---

# dnim trace

## Name

`dnim-win-[x86|x64|arm64] trace` - Identifies .NET and .NET Core processes.

## Synopsis

```dotnetcli
dnim-win-[x86|x64|arm64] trace [-a|--accept-license]
    [-o|--output-file <OUTPUT_FILE>]
    [--output-format <text|csv|html|json>]
    [-v|--verbosity <quiet|normal|diagnostic>]

dnim-win-[x86|x64|arm64] trace -?|-h|--help
```

## Description

The `trace` command processes kernel traces to identify running .NET and .NET Core processes.

The command examines a number of events, including `ProcessDCStart`, `RuntimeStart`, and `ImageLoad` to identify running processes that depend on the global runtime under Program Files, including .NET SDKs.

The command can differentiate between single file and self-contained applications. While non-FDD processes may not be impacted by shared installations of .NET, the information provides a more complete view of a device, allowing administrators to make informed decisions.

> [!IMPORTANT]
> The command requires administrator access to process kernel traces.

## Options

- [!INCLUDE [accept-license](includes/dnim-cli-accept-license.md)]

- [!INCLUDE [output-file](includes/dnim-cli-output-file.md)]

- [!INCLUDE [output-format](includes/dnim-cli-output-format.md)]

- [!INCLUDE [verbosity](includes/dnim-cli-verbosity.md)]

## Results

The results include information about each process (PID and start time) and the shared framework versions that were loaded. The table below contains examples of what the command reports. Note that some columns were removed for brevity.

| Process | PID | Runtime Family | CLR | CLR Version | Frameworks and SDKs |
| --- | --- | --- | --- | --- | --- |
| dnim-win-x64 | 12016 | Net, SingleFile | dnim-win-x64.exe | 8.0.3026.36720 | |
| dotnet | 47852 | Net | coreclr.dll | 10.0.1126.37416 | Microsoft.NETCore.App (10.0.11), sdk (10.0.400-preview.0.26322.102) |
| pwsh | 37364 | Net | coreclr.dll | 10.0.1026.32716 | |

1. DNIM is a single file application and the CLR is reported under the application host.
2. The `dotnet` process is an FDD application running on .NET 10.0.11. Note that the process also loaded modules from the .NET SDK.
3. The `pwsh` process is a self-contained application. The diagnostic log confirms this and shows a local copy of `coreclr.dll` was loaded. The version is also different from the global copy loaded by `dotnet` (second row).
`[2026-08-17 08:31:59.175]d0000: Event: RuntimeStart, timestamp: 08/17/2026 08:31:57, PID: 37364, path: C:\Program Files\PowerShell\7\coreclr.dll`

## See also
