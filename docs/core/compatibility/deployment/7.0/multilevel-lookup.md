---
title: "Breaking change: Multi-level lookup is disabled"
description: Learn about the .NET 7 breaking change in deployment where multi-level lookup is disabled.
ms.date: 04/08/2022
ms.topic: concept-article
---
# Multi-level lookup is disabled

On Windows, framework-dependent .NET applications no longer search for frameworks in multiple install locations.

## Previous behavior

In previous versions, a framework-dependent .NET application searched for frameworks in multiple install locations on Windows. The locations were:

- When running the application through [dotnet](../../../tools/dotnet.md), subdirectories relative to the `dotnet` executable.
- When running the application through its executable (`apphost`), the location specified by the value of the `DOTNET_ROOT` environment variable (if set).
- The globally registered install location in **HKLM\SOFTWARE\dotnet\Setup\InstalledVersions\<arch>\InstallLocation** (if set).
- The default install location of *%ProgramFiles%\dotnet* (or *%ProgramFiles(x86)%\dotnet* for 32-bit processes on 64-bit Windows).

This multi-level lookup behavior was enabled by default but could be disabled by setting the environment variable `DOTNET_MULTILEVEL_LOOKUP=0`.

## New behavior

Applications that target .NET 7 or a later version only look for frameworks in one location, which is the first location where a .NET installation is found. When running an application through [dotnet](../../../tools/dotnet.md), frameworks are only searched for in subdirectories relative to the `dotnet` executable. When running an application through its executable (`apphost`), frameworks are only searched for in the first of the following locations where .NET is found:

- The location specified by the value of the `DOTNET_ROOT` environment variable (if set).
- The globally registered install location in **HKLM\SOFTWARE\dotnet\Setup\InstalledVersions\<arch>\InstallLocation** (if set).
- The default install location of *%ProgramFiles%\dotnet* (or *%ProgramFiles(x86)%\dotnet* for 32-bit processes on 64-bit Windows).

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

There've been numerous issues caused by multi-level lookup:

- Confusion for users: application can pick a global or default install location despite running .NET from a private install.
- Inconsistency between platforms (Windows versus non-Windows).
- Behavior breaks, often in automated systems: a new global .NET install can affect otherwise isolated builds and tests.
- Performance issues.

## Recommended action

Make sure the required version of .NET is installed at the single .NET install location. The error messages that are emitted on failure to launch include the expected location.

## Affected APIs

None.
