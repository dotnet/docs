---
title: Manage package dependencies in .NET
description: Explains how to manage NuGet package dependencies for a .NET application.
no-loc: [dotnet add package, dotnet remove package, dotnet list package]
ms.topic: how-to
ms.date: 01/28/2021
---
# Manage package dependencies in .NET applications

This article explains how to add and remove package dependencies by editing the project file or by using the CLI.

## The \<PackageReference> element

The `<PackageReference>` project file element has the following structure:

```xml
<PackageReference Include="PACKAGE_ID" Version="PACKAGE_VERSION" />
```

The `Include` attribute specifies the ID of the package to add to the project. The `Version` attribute specifies the version to get. Versions are specified as per [NuGet version rules](/nuget/create-packages/dependency-versions#version-ranges).

> [!NOTE]
> If you're not familiar with project-file syntax, see the [MSBuild project reference](/visualstudio/msbuild/msbuild-project-file-schema-reference) documentation for more information.

Use conditions to add a dependency that's available only in a specific target, as shown in the following example:

```xml
<PackageReference Include="PACKAGE_ID" Version="PACKAGE_VERSION" Condition="'$(TargetFramework)' == 'netcoreapp2.1'" />
```

The dependency in the preceding example will only be valid if the build is happening for that given target. The `$(TargetFramework)` in the condition is an MSBuild property that's being set in the project. For most common .NET applications, you don't need to do this.

## Add a dependency by editing the project file

To add a dependency, add a `<PackageReference>` element inside an `<ItemGroup>` element. You can add to an existing `<ItemGroup>` or create a new one. The following example uses the default console application project that's created by `dotnet new console`:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.2" />
  </ItemGroup>

</Project>
```

## Add a dependency by using the CLI

To add a dependency, run the [dotnet add package](dotnet-add-package.md) command, as shown in the following example:

```dotnetcli
dotnet add package Microsoft.EntityFrameworkCore
```

## Remove a dependency by editing the project file

To remove a dependency, remove its `<PackageReference>` element from the project file.

## Remove a dependency by using the CLI

To remove a dependency, run the [dotnet remove package](dotnet-remove-package.md) command, as shown in the following example:

```dotnetcli
dotnet remove package Microsoft.EntityFrameworkCore
```

## See also

* [Package references in project files](../project-sdk/msbuild-props.md#reference-properties)
* [dotnet list package command](dotnet-list-package.md)
