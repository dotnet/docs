---
title: "Breaking change: Version requirements for .NET 10 SDK"
description: Learn about the breaking change in the .NET 10 SDK where specific versions of Visual Studio and MSBuild are required.
ms.date: 01/03/2025
ai-usage: ai-assisted
---
# Version requirements for .NET 10 SDK

Per the [published support rules](../../../porting/versioning-sdk-msbuild-vs.md#targeting-and-support-rules), the minimum Visual Studio and MSBuild version for each new major release is updated with a one quarter delay. For the .NET 10 release:

- 10.0.100 requires version 17.14 to be loaded but only supports targeting .NET 9 in that version.
- To target `net10.0`, you must use version 18.0 or later.

## Version introduced

.NET 10 RC 2

## Previous behavior

The previous minimum for .NET 10 previews was Visual Studio 17.13 to allow time for release and more adoption of Visual Studio 17.14.

## New behavior

- .NET 10.0.100 RC 2 and later will only load on Visual Studio version 17.14 or later.
- .NET 10.0.100 will warn when targeting `net10.0` on Visual Studio version 17.14.
- To target `net10.0`, you must use Visual Studio version 18.0 or later.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This is part of the standard support policy for the SDK as not all prior versions of Visual Studio and MSBuild can be supported.

## Recommended action

Upgrade to Visual Studio 2026 to target `net10.0`. If you only need to target `net9.0` or earlier, you can use Visual Studio 17.14 or later.

## Affected APIs

N/A

## See also

- [Targeting and support rules](../../../porting/versioning-sdk-msbuild-vs.md#targeting-and-support-rules)
