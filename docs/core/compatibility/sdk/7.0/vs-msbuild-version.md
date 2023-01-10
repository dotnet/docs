---
title: "Breaking change: Version requirements for .NET 7 SDK"
description: Learn about the breaking change in the .NET 7 SDK where specific versions of Visual Studio and MSBuild are required.
ms.date: 11/09/2022
---
# Version requirements for .NET 7 SDK

Certain .NET SDK preview and release candidate versions require newer versions of Visual Studio and MSBuild.

## Version introduced

.NET SDK 7

## Change description

The following table shows the minimum version of Visual Studio and MSBuild you'll need to use .NET 7.0.100 SDK Preview 3, Preview 7, RC 2, and GA.

| NET 7.0.100 SDK version | Minimum Visual Studio and MSBuild version |
|-------------------------|-------------------------------------------|
| Preview 3               | 17.0<sup>1</sup>                          |
| Preview 7               | 17.2                                      |
| RC 2                    | 17.3                                      |
| GA                      | 17.4                                      |

<sup>1</sup>In addition, scenarios that use a source generator could fail when using a Visual Studio or MSBuild version earlier than version 17.2.

## Reason for change

Changes were made to features within the SDK that aren't compatible with previous Visual Studio versions.

## Recommended action

Upgrade your Visual Studio version to the required version.

## Affected APIs

N/A
