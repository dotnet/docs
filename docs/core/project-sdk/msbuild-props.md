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

## Dependency properties

## TargetFramework

The `TargetFramework` property specifies the target framework version for the app, which implicitly references a [metapackage](../packages.md#metapackages). For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-framework-versions).

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp3.1</TargetFramework>
</PropertyGroup>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

## TargetFrameworks

Use the `TargetFrameworks` property when you want your app to target multiple platforms. This property is ignored if `TargetFramework` is specified. For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-framework-versions).

```xml
<PropertyGroup>
  <TargetFrameworks>netcoreapp3.1;net462</TargetFrameworks>
</PropertyGroup>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

## PackageReference

The `PackageReference` property lets you reference a single package instead of a [metapackage](../packages.md#metapackages). The project file snippet in the following example references the [System.Runtime](https://www.nuget.org/packages/System.Runtime/) package.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  ...
  <ItemGroup>
    <PackageReference Include="System.Runtime" Version="4.3.0" />
  </ItemGroup>
</Project>
```

For more information, see [Package references in project files](/nuget/consume-packages/package-references-in-project-files).

## Compile properties

### LangVersion

The `LangVersion` property lets you specify a specific programming language version. For example, if you want access to C# preview features, set `LangVersion` to `preview`.

```xml
<PropertyGroup>
  ...
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
