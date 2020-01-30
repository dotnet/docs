---
title: MSBuild properties for Microsoft.NET.Sdk
description: Reference for the MSBuild properties that are understood by the .NET Core SDK.
ms.date: 02/02/2020
ms.topic: reference
---
# MSBuild properties for .NET Core SDK projects

This page describes MSBuild properties for configuring .NET Core projects.

> [!NOTE]
> This page is a work in progress and does not list all of the useful MSBuild properties for the .NET Core SDK.

## Compile properties

### LangVersion

The `LangVersion` property lets you specify a specific programming language version. For example, if you want access to C# preview features, set `LangVersion` to `preview`.

```xml
<PropertyGroup>
  <LangVersion>preview</LangVersion>
</PropertyGroup>
```

For more information, see [C# language versioning](../../csharp/language-reference/configure-language-version.md#override-a-default).

## NuGet pack and restore properties

MSBuild 15.1 introduced `pack` and `restore` targets for creating and restoring NuGet packages as part of a build. For information about the MSBuild properties for these targets, see [NuGet pack and restore as MSBuild targets](/nuget/reference/msbuild-targets).

## See also

- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [MSBuild properties for NuGet pack](/nuget/reference/msbuild-targets#pack-target)
- [MSBuild properties for NuGet restore](/nuget/reference/msbuild-targets#restore-properties)
- [Customize a build](/visualstudio/msbuild/customize-your-build)
