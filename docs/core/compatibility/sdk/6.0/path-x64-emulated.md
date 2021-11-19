---
title: "Breaking change: Install location for x64 emulated on ARM64"
description: Learn about the breaking change in .NET 6 where the installation location for the x64 version of .NET when installed on ARM64 hardware has changed.
ms.date: 10/12/2021
---
# Install location for x64 emulated on ARM64

We've moved the install location of the x64 version of the .NET SDK and runtime on ARM64 hardware.

Previously, the x64 and ARM64 versions installed to the same location, leading to a broken state. In addition, the `PATH` environment variable value was being set for both installations, so depending on install order, you might have an unexpected version of the [`dotnet` command](../../../tools/dotnet.md) used by default.

## Version introduced

.NET 6 RC 2

## Previous behavior

In previous versions, both the ARM64 and x64 versions of .NET SDK and runtime installed to the same location on ARM64 hardware:

- macOS: */usr/local/share/dotnet*
- Windows: *%ProgramFiles%\dotnet*

This worked if only one version was installed, but was completely broken if both were installed.

## New behavior

In .NET 6, the x64 version of .NET installs to a subfolder named *x64* on ARM64 hardware:

- macOS: */usr/local/share/dotnet/x64*
- Windows: *%ProgramFiles%\dotnet\x64*

For more information, see [Install location](https://github.com/dotnet/designs/blob/main/accepted/2021/x64-emulation-on-arm64/x64-emulation.md#install-location).

## Change category

This change may affect [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

Without this change, the x64 and ARM64 versions of the .NET SDK and .NET runtime install to the same location on ARM64 hardware. This leads to being in a completely broken state. This change allows customers to develop for both x64 and ARM64 at the same time.

## Recommended action

If you need to use the x64 version of the `dotnet` command, manually add that file path to the `PATH` environment variable.

## Affected APIs

N/A

## See also

- [x64 emulation model](https://github.com/dotnet/designs/blob/main/accepted/2021/x64-emulation-on-arm64/x64-emulation.md)
