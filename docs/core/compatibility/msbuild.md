---
title: MSBuild breaking changes
description: Lists the breaking changes in MSBuild for .NET Core.
ms.date: 02/10/2020
---
# MSBuild breaking changes

The following breaking changes are documented on this page:

| Breaking change | Version introduced |
| - | - |
| [TargetFramework change from netcoreapp to net](#targetframework-change-from-netcoreapp-to-net) | 5.0 |
| [NETCOREAPP3_1 preprocessor symbol is not defined when targeting .NET 5](#netcoreapp3_1-preprocessor-symbol-is-not-defined-when-targeting-net-5) | 5.0 |
| [PublishDepsFilePath behavior change](#publishdepsfilepath-behavior-change) | 5.0 |
| [Directory.Packages.props files is imported by default](#directorypackagesprops-files-is-imported-by-default) | 5.0 |
| [Resource manifest file name change](#resource-manifest-file-name-change) | 3.0 |

## .NET 5.0

[!INCLUDE [targetframework-name-change](../../../includes/core-changes/msbuild/5.0/targetframework-name-change.md)]

***

[!INCLUDE [netcoreapp3_1-preprocessor-symbol-not-defined](../../../includes/core-changes/msbuild/5.0/netcoreapp3_1-preprocessor-symbol-not-defined.md)]

***

[!INCLUDE [publishdepsfilepath-behavior-change](../../../includes/core-changes/msbuild/5.0/publishdepsfilepath-behavior-change.md)]

***

[!INCLUDE [directory-packages-props-imported-by-default](../../../includes/core-changes/msbuild/5.0/directory-packages-props-imported-by-default.md)]

***

## .NET Core 3.0

[!INCLUDE[Resource file names](~/includes/core-changes/msbuild/3.0/resource-manifest-name.md)]

***
