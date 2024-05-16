---
title: "Breaking change: GetTargetFrameworkProperties and GetNearestTargetFramework removed"
description: Learn about the breaking change in .NET 6 where the GetTargetFrameworkProperties target and the GetNearestTargetFramework task have been removed from the MSBuild ProjectReference protocol.
ms.date: 05/19/2021
---
# GetTargetFrameworkProperties and GetNearestTargetFramework removed from ProjectReference protocol

The `GetTargetFrameworkProperties` target and `GetNearestTargetFramework` task have been removed from the .NET SDK.

## Version introduced

.NET SDK 6.0.100

## Old behavior

The `GetTargetFrameworkProperties` target and the `GetNearestTargetFramework` task were available but not used. However, custom MSBuild logic could take a dependency on them.

## New behavior

The `GetTargetFrameworkProperties` target and the `GetNearestTargetFramework` task no longer exist.

## Reason for change

The `GetTargetFrameworkProperties` target and the `GetNearestTargetFramework` task were deprecated in MSBuild 15.5, and .NET 6 removes them completely.

## Recommended action

Use `GetTargetFrameworks` instead. For more information, see [Targets required to be referenceable](https://github.com/dotnet/msbuild/blob/main/documentation/ProjectReference-Protocol.md#targets-required-to-be-referenceable).

## Affected APIs

N/A

<!--

### Affected APIs

Not detectable via API analysis.

### Category

MSBuild

-->
