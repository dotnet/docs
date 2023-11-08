---
title: "Breaking change: Version requirements for .NET 8 SDK"
description: Learn about the breaking change in the .NET 8 SDK where specific versions of Visual Studio and MSBuild are required.
ms.date: 09/05/2023
---
# Version requirements for .NET 8 SDK

Per the [published support rules](../../../porting/versioning-sdk-msbuild-vs.md#targeting-and-support-rules), the minimum Visual Studio and MSBuild version for each new major release is updated with a one quarter delay. For the .NET 8 release, 8.0.100 requires version 17.7 to be loaded but only supports targeting .NET 7 in that version. To target `net8.0`, you must use version 17.8 or later.

## Version introduced

.NET SDK 8 RC 1

## Previous behavior

.NET 8.0.1xx-preview1 required version 17.4 of Visual Studio and MSBuild. .NET 8.0.1xx-preview4 required version 17.6 of Visual Studio and MSBuild.

## New behavior

Versions 8.0.1xx of the .NET SDK require Visual Studio version 17.7 and MSBuild version 17.7.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This is our standard support policy for the SDK as we can't support all prior versions of Visual Studio and MSBuild.

## Recommended action

Upgrade your Visual Studio version to the required version.

## Affected APIs

N/A

## See also

- [Targeting and support rules](../../../porting/versioning-sdk-msbuild-vs.md#targeting-and-support-rules)
