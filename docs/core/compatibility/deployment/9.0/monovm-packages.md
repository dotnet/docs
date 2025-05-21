---
title: "Breaking change: Deprecated desktop Windows/macOS/Linux MonoVM runtime packages"
description: Learn about the breaking change in .NET 9 where the desktop Windows, macOS, and Linux MonoVM runtime packages are deprecated.
ms.date: 08/05/2024
ms.topic: concept-article
---
# Deprecated desktop Windows/macOS/Linux MonoVM runtime packages

The following desktop MonoVM runtime NuGet packages are obsolete starting in .NET 9:

- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.win-x64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.win-x86>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.linux-arm>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.linux-x64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.linux-arm64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.linux-musl-x64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.osx-x64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.osx-arm64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.LLVM.AOT.linux-x64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.LLVM.AOT.osx-x64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.LLVM.linux-arm64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.LLVM.linux-x64>
- <https://www.nuget.org/packages/Microsoft.NETCore.App.Runtime.Mono.LLVM.osx-x64>

These desktop MonoVM runtime packages are not the default configuration for .NET publish scenarios. .NET 9 Preview 6 is the last release of these packages.

## Previous behavior

During .NET SDK publish, these desktop MonoVM NuGet runtime packages were available for self-contained applications using an undocumented SDK switch.

## New behavior

Starting in .NET 9, these desktop MonoVM NuGet runtime packages are no longer available.

## Version introduced

.NET 9 Preview 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

There is no official .NET scenario that aligns with these desktop MonoVM runtime NuGet packages.

## Recommended action

If your application publish relies on these packages, we recommend staying on .NET 8 LTS while you migrate the application to the default desktop runtime NuGet packages. Each of these platforms has a corresponding runtime NuGet package.

## Affected APIs

N/A
