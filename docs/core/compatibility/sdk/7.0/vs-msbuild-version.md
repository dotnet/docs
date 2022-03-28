---
title: "Breaking change: Version requirements for .NET 7 SDK"
description: Learn about the breaking change in the .NET 7 SDK where version 17.0 or newer of Visual Studio and MSBuild is required.
ms.date: 03/25/2022
---
# Version requirements for .NET 7 SDK

The NET 7.0.100 SDK no longer loads in version 16.11 or earlier of Visual Studio or MSBuild.

## Version introduced

.NET SDK 7.0.100 (.NET 7 Preview 3)

## Old behavior

.NET SDK 7.0.100 would load in the 16.10 and 16.11 versions of Visual Studio and MSBuild.

## New behavior

.NET SDK 7.0.100 can only be used with version 17.0 or later of Visual Studio and MSBuild. In addition, any scenarios that use a source generator could fail when using a Visual Studio or MSBuild version earlier than version 17.2.

## Reason for change

Changes were made to features within the SDK that aren't compatible with Visual Studio version 16.11.

## Recommended action

Upgrade to Visual Studio 2022 version 17.0 or later. It's recommended that you use version 17.2 preview builds.

## Affected APIs

N/A
