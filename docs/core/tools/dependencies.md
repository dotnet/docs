---
title: Manage package dependencies in .NET
description: Explains how to manage NuGet package dependencies for a .NET application.
no-loc: [dotnet package add, dotnet package remove, dotnet package list]
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

Use conditions to add a dependency that's available only in a specific target, as shown in the following example:

```xml
<PackageReference Include="PACKAGE_ID" Version="PACKAGE_VERSION" Condition="'$(TargetFramework)' == 'netcoreapp2.1'" />
```

The dependency in the preceding example will only be valid if the build is happening for that given target. The `$(TargetFramework)` in the condition is an MSBuild property that's being set in the project. For most common .NET applications, you don't need to do this.

## Add and remove dependencies

You can add and remove dependencies by editing your project file or through [.NET CLI](index.md) commands.

### Edit the project file

To add a dependency, add a `<PackageReference>` item inside an `<ItemGroup>` element. You can add to an existing `<ItemGroup>` or create a new one.

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    ...
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.2" />
  </ItemGroup>

</Project>
```

To remove a dependency, remove its `<PackageReference>` item from the project file.

### Use the CLI

To add a dependency, run the [dotnet package add](/dotnet/core/tool/dotnet-package-add) command, as shown in the following example:

```dotnetcli
dotnet package add Microsoft.EntityFrameworkCore
```

To remove a dependency, run the [dotnet package remove](/dotnet/core/tool/dotnet-package-remove) command, as shown in the following example:

```dotnetcli
dotnet package remove Microsoft.EntityFrameworkCore
```

## Tips

- Don't include inputs to the restore operation in the *.targets* or *.props* file of a referenced package. These inputs can include `PackageReference` items, `ExcludeAssets` attributes, the NuGet feeds to use, or other NuGet configuration. The *.targets* and *.props* files from packages aren't used until after NuGet restore is complete. Anything needed for restore needs to be in the project file or *.targets* file of the project itself, not a package dependency.
- If you want to use ASP.NET APIs in a console application or class library, add a [FrameworkReference](../project-sdk/msbuild-props.md#frameworkreference) item to your project file:

  `<FrameworkReference Include="Microsoft.AspNetCore.App" />`

  For more information, see [Use the ASP.NET Core shared framework](/aspnet/core/fundamentals/target-aspnetcore#use-the-aspnet-core-shared-framework).

## See also

* [Package references in project files](../project-sdk/msbuild-props.md#reference-related-properties)
* [dotnet package list command](/dotnet/core/tool/dotnet-package-list)
* [Dependencies (library guidance)](../../standard/library-guidance/dependencies.md)
