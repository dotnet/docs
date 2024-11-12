---
title: "Breaking change: Version requirements for .NET 9 SDK"
description: Learn about the breaking change in the .NET 9 SDK where specific versions of Visual Studio and MSBuild are required.
ms.date: 11/06/2024
---
# Version requirements for .NET 9 SDK

Per the [published support rules](../../../porting/versioning-sdk-msbuild-vs.md#targeting-and-support-rules), the minimum Visual Studio and MSBuild version for each new major release is updated with a one quarter delay. For the .NET 9 release:

- 9.0.100 requires version 17.11 to target `net8.0` and earlier frameworks.
- 9.0.100 requires version 17.12 or later to target `net9.0`.

## Version introduced

.NET 9 GA

## Previous behavior

Previously, you could load .NET 9.0.100 on earlier Visual Studio versions. In addition, there was no warning when targeting `net9.0` in Visual Studio version 17.11.

## New behavior

- .NET 9.0.100 won't load in Visual Studio version 17.10 or earlier.
- Visual Studio version 17.11 doesn't make `net9.0` available in the project properties.
- .NET 9.0.100 warns when targeting `net9.0` and using Visual Studio version 17.11:

  > NETSDK1223: Targeting .NET 9.0 or higher in Visual Studio 2022 17.11 is not supported.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This is part of the standard support policy for the SDK as not all prior versions of Visual Studio and MSBuild can be supported.

## Recommended action

Upgrade your Visual Studio version to the required version.

## Affected APIs

N/A

## See also

- [Targeting and support rules](../../../porting/versioning-sdk-msbuild-vs.md#targeting-and-support-rules)
