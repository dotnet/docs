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

### NetStandardImplicitPackageVersion

Use the `NetStandardImplicitPackageVersion` property when you want to specify a framework version that's lower than the [metapackage](../packages.md#metapackages) version. The project file in the following example targets `netstandard1.3` but uses the 1.6.0 version of `NETStandard.Library`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard1.3</TargetFramework>
    <NetStandardImplicitPackageVersion>1.6.0</NetStandardImplicitPackageVersion>
  </PropertyGroup>
</Project>
```

### PackageTargetFallback

The `PackageTargetFallback` property allows you to specify a set of compatible targets to be used when restoring packages. It's designed to allow packages that use the dotnet [TxM (Target x Moniker)](/nuget/schema/target-frameworks) to operate with packages that don't declare a dotnet TxM. If you don't add the `PackageTargetFallback` property, then all the packages your project depends on must also have a dotnet TxM.

The following example specifies fallbacks for all targets:

```xml
<PackageTargetFallback>
  $(PackageTargetFallback);portable-net45+win8+wpa81+wp8
</PackageTargetFallback >
```

The following example uses the `Condition` attribute to specify fallbacks only for the `netcoreapp2.1` target:

```xml
<PackageTargetFallback Condition="'$(TargetFramework)'=='netcoreapp2.1'">
  $(PackageTargetFallback);portable-net45+win8+wpa81+wp8
</PackageTargetFallback >
```

### RuntimeIdentifier

The `RuntimeIdentifier` property allows you to specify a single [runtime identifier (RID)](../rid-catalog.md) for the project. The RID enables publishing a self-contained deployment.

```xml
<RuntimeIdentifier>ubuntu.16.04-x64</RuntimeIdentifier>
```

Use `RuntimeIdentifiers` (plural) instead if you need to publish for multiple runtimes. However, `RuntimeIdentifier` can provide faster builds when only a single runtime is required.

### RuntimeIdentifiers

The `RuntimeIdentifiers` property lets you specify a semicolon-delimited list of [runtime identifiers (RIDs)](../rid-catalog.md) for the project. RIDs enable publishing self-contained deployments.

```xml
<RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
```

### TargetFramework

The `TargetFramework` property specifies the target framework version for the app, which implicitly references a [metapackage](../packages.md#metapackages). For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-framework-versions).

```xml
<PropertyGroup>
  <TargetFramework>netcoreapp3.1</TargetFramework>
</PropertyGroup>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### TargetFrameworks

Use the `TargetFrameworks` property when you want your app to target multiple platforms. This property is ignored if `TargetFramework` is specified. For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-framework-versions).

```xml
<PropertyGroup>
  <TargetFrameworks>netcoreapp3.1;net462</TargetFrameworks>
</PropertyGroup>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### PackageReference

Use the `PackageReference` property lets you specify a NuGet dependency. For example, you may want to reference a single package instead of a [metapackage](../packages.md#metapackages). The `Include` attribute specifies the package ID. The project file snippet in the following example references the [System.Runtime](https://www.nuget.org/packages/System.Runtime/) package.

```xml
<PackageReference Include="<package-id>" Version="" PrivateAssets="" IncludeAssets="" ExcludeAssets="" />
```

```xml
<Project Sdk="Microsoft.NET.Sdk">
  ...
  <ItemGroup>
    <PackageReference Include="System.Runtime" Version="4.3.0" />
  </ItemGroup>
</Project>
```

For more information, see [Package references in project files](/nuget/consume-packages/package-references-in-project-files).

#### Attributes

The required `Version` attribute specifies the version of the package to restore. The attribute respects the rules of the [NuGet versioning](/nuget/reference/package-versioning#version-ranges-and-wildcards) scheme. The default behavior is a minimum-version, inclusive match. For example, specifying `Version="1.2.3"` is equivalent to NuGet notation `[1.2.3, )` and means the resolved package will have the version 1.2.3 if it's available or a later version if not.

The `IncludeAssets` attribute specifies which assets belonging to the package specified by `PackageReference` should be consumed. By default, all package assets are included.

The `ExcludeAssets` attribute specifies which assets belonging to the package specified by `PackageReference` should not be consumed.

The `PrivateAssets` attribute specifies which assets belonging to the package specified by `PackageReference` should be consumed but not flow to the next project. The `Analyzers`, `Build`, and `ContentFiles` assets are private, by default, when this attribute is not present.

The :::no-loc text="assets"::: attributes can contain one or more of the following values. Separate multiple values with a semicolon `;` character.

| Value | Effect |
| - | - |
| `Compile` | The contents of the *lib* folder are available to compile against. |
| `Runtime` | The contents of the *runtime* folder are distributed. |
| `ContentFiles` | The contents of the *contentfiles* folder are used. |
| `Build` | The props/targets in the *build* folder are used. |
| `Native` | The contents from native assets are copied to the *output* folder for runtime. |
| `Analyzers` | The analyzers are used. |
| `None` | None of the assets are used. (This value cannot be combined.) |
| `All` | All assets are used. (This value cannot be combined.) |

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
