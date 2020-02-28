---
title: MSBuild properties for Microsoft.NET.Sdk
description: Reference for the MSBuild properties that are understood by the .NET Core SDK.
ms.date: 02/14/2020
ms.topic: reference
---
# MSBuild properties for .NET Core SDK projects

This page describes MSBuild properties for configuring .NET Core projects.

> [!NOTE]
> This page is a work in progress and does not list all of the useful MSBuild properties for the .NET Core SDK. For a list of common MSBuild properties, see [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties).

## Framework properties

- [TargetFramework](#targetframework)
- [TargetFrameworks](#targetframeworks)
- [NetStandardImplicitPackageVersion](#netstandardimplicitpackageversion)

### TargetFramework

The `TargetFramework` property specifies the target framework version for the app, which implicitly references a [metapackage](../packages.md#metapackages). For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-framework-versions).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>
</Project>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### TargetFrameworks

Use the `TargetFrameworks` property when you want your app to target multiple platforms. For a list of valid target framework monikers, see [Target frameworks in SDK-style projects](../../standard/frameworks.md#supported-target-framework-versions).

> [!NOTE]
> This property is ignored if `TargetFramework` (singular) is specified.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>netcoreapp3.1;net462</TargetFrameworks>
  </PropertyGroup>
</Project>
```

For more information, see [Target frameworks in SDK-style projects](../../standard/frameworks.md).

### NetStandardImplicitPackageVersion

> [!NOTE]
> This property only applies to projects using `netstandard1.x`. It doesn't apply to projects that use `netstandard2.x`.

Use the `NetStandardImplicitPackageVersion` property when you want to specify a framework version that's lower than the [metapackage](../packages.md#metapackages) version. The project file in the following example targets `netstandard1.3` but uses the 1.6.0 version of `NETStandard.Library`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard1.3</TargetFramework>
    <NetStandardImplicitPackageVersion>1.6.0</NetStandardImplicitPackageVersion>
  </PropertyGroup>
</Project>
```

## Publish properties

- [RuntimeIdentifier](#runtimeidentifier)
- [RuntimeIdentifiers](#runtimeidentifiers)
- [UseAppHost](#useapphost)

### RuntimeIdentifier

The `RuntimeIdentifier` property lets you specify a single [runtime identifier (RID)](../rid-catalog.md) for the project. The RID enables publishing a self-contained deployment.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <RuntimeIdentifier>ubuntu.16.04-x64</RuntimeIdentifier>
  </PropertyGroup>
</Project>
```

### RuntimeIdentifiers

The `RuntimeIdentifiers` property lets you specify a semicolon-delimited list of [runtime identifiers (RIDs)](../rid-catalog.md) for the project. Use this property if you need to publish for multiple runtimes. `RuntimeIdentifiers` is used at restore time to ensure the right assets are in the graph.

> [!TIP]
> `RuntimeIdentifier` (singular) can provide faster builds when only a single runtime is required.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
  </PropertyGroup>
</Project>
```

### UseAppHost

The `UseAppHost` property was introduced in the 2.1.400 version of the .NET Core SDK. It controls whether or not a native executable is created for a deployment. A native executable is required for self-contained deployments.

In .NET Core 3.0 and later versions, a framework-dependent executable is created by default. Set the `UseAppHost` property to `false` to disable generation of the executable.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <UseAppHost>false</UseAppHost>
  </PropertyGroup>
</Project>
```

For more information about deployment, see [.NET Core application deployment](../deploying/index.md).

## Compile properties

### LangVersion

The `LangVersion` property lets you specify a specific programming language version. For example, if you want access to C# preview features, set `LangVersion` to `preview`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <LangVersion>preview</LangVersion>
  </PropertyGroup>
</Project>
```

For more information, see [C# language versioning](../../csharp/language-reference/configure-language-version.md#override-a-default).

## NuGet packages

- [PackageReference](#packagereference)

### PackageReference

The `PackageReference` item lets you specify a NuGet dependency. For example, you may want to reference a single package instead of a [metapackage](../packages.md#metapackages). The `Include` attribute specifies the package ID. The project file snippet in the following example references the [System.Runtime](https://www.nuget.org/packages/System.Runtime/) package.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  ...
  <ItemGroup>
    <PackageReference Include="System.Runtime" Version="4.3.0" />
  </ItemGroup>
</Project>
```

For more information, see [Package references in project files](/nuget/consume-packages/package-references-in-project-files).

### Pack and restore targets

MSBuild 15.1 introduced `pack` and `restore` targets for creating and restoring NuGet packages as part of a build. For information about the MSBuild properties for these targets, including `PackageTargetFallback`, see [NuGet pack and restore as MSBuild targets](/nuget/reference/msbuild-targets).

## See also

- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [MSBuild properties for NuGet pack](/nuget/reference/msbuild-targets#pack-target)
- [MSBuild properties for NuGet restore](/nuget/reference/msbuild-targets#restore-properties)
- [Customize a build](/visualstudio/msbuild/customize-your-build)
