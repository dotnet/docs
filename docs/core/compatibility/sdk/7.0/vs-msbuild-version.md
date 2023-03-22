---
title: "Breaking change: Version requirements for .NET 7 SDK"
description: Learn about the breaking change in the .NET 7 SDK where specific versions of Visual Studio and MSBuild are required.
ms.date: 01/09/2023
---
# Version requirements for .NET 7 SDK

Certain .NET SDK versions require newer versions of Visual Studio and MSBuild.

## Version introduced

.NET SDK 7

## Change description

The following table shows the minimum version of Visual Studio and MSBuild you need to use the .NET 7.0.100 or 7.0.200 SDK.

| NET SDK version   | Minimum Visual Studio and MSBuild version |
| ----------------- | ----------------------------------------- |
| 7.0.100           | 17.4                                      |
| 7.0.200           | 17.4                                      |

<sup>1</sup>In addition, scenarios that use a source generator could fail when using a Visual Studio or MSBuild version earlier than version 17.2.

For more information about minimum supported versions, see [Targeting and support rules](../../../porting/versioning-sdk-msbuild-vs.md#targeting-and-support-rules).

## Reason for change

Changes were made to features within the SDK that aren't compatible with previous Visual Studio versions. In addition, it enables .NET SDK partners to have a reliable minimum version of Visual Studio that they can expect to work against.

## Recommended action

Upgrade your Visual Studio version to the required version. Alternatively, you can use a [global.json](../../../tools/global-json.md) file to pin to an older standalone SDK install.

## Affected APIs

N/A

## See also

- [Targeting and support rules](../../../porting/versioning-sdk-msbuild-vs.md#targeting-and-support-rules)
