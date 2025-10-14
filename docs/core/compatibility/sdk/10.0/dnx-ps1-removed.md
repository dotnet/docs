---
title: "Breaking change - dnx.ps1 file is no longer included in .NET SDK"
description: "Learn about the breaking change in .NET 10 where the dnx.ps1 script is no longer included in Windows versions of the .NET SDK."
ms.date: 10/13/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/497988
---

# dnx.ps1 file is no longer included in .NET SDK

The `dnx.ps1` shim script is no longer included in the .NET SDK.

## Version introduced

.NET 10 GA

## Previous behavior

Since .NET 10 Preview 7, on Windows versions of the .NET SDK, a `dnx.ps1` script was included in the dotnet root folder, alongside `dotnet.exe` and `dnx.cmd`.

## New behavior

The `dnx.ps1` script is no longer included. The `dnx.cmd` script remains available for executing tools.

## Type of breaking change

This change can affect <a>source compatibility</a>.

## Reason for change

The `dnx.ps1` script was added to avoid an extra `Terminate Batch Job` prompt when cancelling tools run via `dnx` with <kbd>Ctrl+C</kbd>. However, PowerShell has special handling for `--`, so if `--` was passed on the command line, it never made it through to `dnx`. This meant that in PowerShell, it was impossible to pass options to a tool using `dnx` if `dnx` itself has the same option. For example, `dnx dotnet-serve -- --help` showed the help for `dnx` instead of the help for `dotnet-serve`.

## Recommended action

In most cases, the `dnx.cmd` script is used instead so no action is necessary. If you were calling `dnx.ps1` directly, switch to `dnx.cmd`.

## Affected APIs

None.
