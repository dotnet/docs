---
title: Manage dependencies in .NET
description: Explains how to manage package, project, and assembly dependencies for a .NET application.
no-loc: [dotnet package add, dotnet package remove, dotnet package list, dotnet reference add, dotnet reference remove, dotnet add package, dotnet remove package, dotnet add reference, dotnet remove reference]
ms.topic: how-to
ms.date: 09/16/2026
ai-usage: ai-generated
---
# Manage dependencies in .NET applications

This article explains how to add and remove package, project, and assembly dependencies.

## Add and remove package dependencies

You can add and remove dependencies by editing your project file or through [.NET CLI](index.md) commands.

### The `<PackageReference>` element

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

To add a dependency, run the following command for your SDK version:

# [.NET 10 and later](#tab/dotnet10)

```dotnetcli
dotnet package add Microsoft.EntityFrameworkCore
```

# [.NET 9 and previous](#tab/dotnet9)

```dotnetcli
dotnet add package Microsoft.EntityFrameworkCore
```

---

To remove a dependency, run the following command for your SDK version:

# [.NET 10 and later](#tab/dotnet10)

```dotnetcli
dotnet package remove Microsoft.EntityFrameworkCore
```

# [.NET 9 and previous](#tab/dotnet9)

```dotnetcli
dotnet remove package Microsoft.EntityFrameworkCore
```

---

## Add and remove project references

Use a project-to-project reference when your project depends on another project. The `<ProjectReference>` project file element identifies the path to the referenced project:

```xml
<ItemGroup>
  <ProjectReference Include="../MyLibrary/MyLibrary.csproj" />
</ItemGroup>
```

### Use the CLI

To add a project reference, run the following command for your SDK version:

# [.NET 10 and later](#tab/dotnet10)

```dotnetcli
dotnet reference add ../MyLibrary/MyLibrary.csproj
```

# [.NET 9 and previous](#tab/dotnet9)

```dotnetcli
dotnet add reference ../MyLibrary/MyLibrary.csproj
```

---

To remove a project reference, remove the `<ProjectReference>` element from the project file or run the following command for your SDK version:

# [.NET 10 and later](#tab/dotnet10)

```dotnetcli
dotnet reference remove ../MyLibrary/MyLibrary.csproj
```

# [.NET 9 and previous](#tab/dotnet9)

```dotnetcli
dotnet remove reference ../MyLibrary/MyLibrary.csproj
```

---

## Add and remove assembly references

You can add and remove assembly references through the project file. The .NET CLI doesn't provide commands to add or remove assembly references.

To reference a .NET assembly that isn't part of a project or package, add a `<Reference>` element to the project file. Use the `<HintPath>` element to specify the relative or absolute path to the assembly:

```xml
<ItemGroup>
  <Reference Include="MyAssembly">
    <HintPath>lib/MyAssembly.dll</HintPath>
  </Reference>
</ItemGroup>
```

To remove an assembly reference, remove its `<Reference>` element from the project file.

## Tips

- Don't include inputs to the restore operation in the *.targets* or *.props* file of a referenced package. These inputs can include `PackageReference` items, `ExcludeAssets` attributes, the NuGet feeds to use, or other NuGet configuration. The *.targets* and *.props* files from packages aren't used until after NuGet restore is complete. Anything needed for restore needs to be in the project file or *.targets* file of the project itself, not a package dependency.
- If you want to use ASP.NET APIs in a console application or class library, add a [FrameworkReference](../project-sdk/msbuild-props.md#frameworkreference) item to your project file:

  `<FrameworkReference Include="Microsoft.AspNetCore.App" />`

  For more information, see [Use the ASP.NET Core shared framework](/aspnet/core/fundamentals/target-aspnetcore#use-the-aspnet-core-shared-framework).

## See also

* [Reference-related project items](../project-sdk/msbuild-props.md#reference-related-properties)
* [Common MSBuild project items](/visualstudio/msbuild/common-msbuild-project-items)
* [dotnet package list command](dotnet-package-list.md)
* [Dependencies (library guidance)](../../standard/library-guidance/dependencies.md)
