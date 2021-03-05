---
title: "NETSDK1080: PackageReference to Microsoft.AspNetCore.App is not necessary"
description: Learn about .NET SDK error NETSDK1080, which warns about an unnecessary entry in your project file.
ms.topic: error-reference
ms.date: 02/25/2021
f1_keywords:
- NETSDK1080
---
# NETSDK1080: PackageReference to Microsoft.AspNetCore.App is not necessary

NETSDK1080 warns you that the `PackageReference` element for `Microsoft.AspNetCore.App` in your project file is not necessary. The full error message is similar to the following example:

> warning NETSDK1080: A PackageReference to Microsoft.AspNetCore.App is not necessary when targeting .NET Core 3.0 or higher. If Microsoft.NET.Sdk.Web is used, the shared framework will be referenced automatically. Otherwise, the PackageReference should be replaced with a FrameworkReference.

This error typically occurs after you've upgraded a project to .NET Core 3.0 or later, from an earlier version that required `PackageReference` entries in the project file.

## ASP.NET Core project files

For example, your original project file might look like this example:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.App"/>
    <PackageReference Include="Microsoft.AspNetCore.Razor.Design" Version="2.2.0" PrivateAssets="All" />
  </ItemGroup>

</Project>
```

After updating to .NET Core 3.1 the project file for the same project should look like the following example:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

</Project>
```

Make these changes, in particular delete the `PackageReference` element, to eliminate the warning. For more information, see [Remove obsolete package references](/aspnet/core/migration/22-to-30#remove-obsolete-package-references).

## Class library project

In a class library project that uses ASP.NET Core APIs, replace the `PackageReference` with a `FrameworkReference`, as shown in the following example:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <FrameworkReference Include="Microsoft.AspNetCore.App" />
  </ItemGroup>

</Project>
```

For more information, see [Use ASP.NET Core APIs in a class library](/aspnet/core/fundamentals/target-aspnetcore).
