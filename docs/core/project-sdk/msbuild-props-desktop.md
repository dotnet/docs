---
title: MSBuild properties for Microsoft.NET.Sdk.Desktop
description: Reference for the MSBuild properties and items that are understood by the .NET Desktop SDK
ms.date: 02/04/2021
ms.topic: reference
author: adegeo
ms.author: adegeo
ms.custom: updateeachrelease
no-loc: ["App.xaml", "Application.xaml", "ApplicationDefinition", "Page", "EmbeddedResource", "Compile", "None"]
---
# MSBuild reference for .NET Desktop SDK projects

This page is a reference for the MSBuild properties and items that you use to configure Windows Forms (WinForms) and Windows Presentation Foundation (WPF) projects with the .NET Desktop SDK.

> [!NOTE]
> This article documents a subset of the MSBuild properties for the .NET SDK as it relates to desktop apps. For a list of common .NET SDK-specific MSBuild properties, see [MSBuild reference for .NET SDK projects](msbuild-props.md). For a list of common MSBuild properties, see [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties).

## Enable .NET Desktop SDK

To use WinForms or WPF, configure your project file.

### .NET 5.0

WinForms and WPF projects should specify the following settings in the project file:

- Target the .NET SDK `Microsoft.NET.Sdk`. For more information, see [Project files](overview.md#project-files).
- Set the `TargetFramework` to `net5.0-windows`.
- Set one of the following to enable a UI framework:
  - Set `UseWPF` to `true` to use WPF.
  - Set `UseWindowsForms` to `true` to use WinForms.
- (Optional) Set `OutputType` to `WinExe`. This produces an app as opposed to a library. To produce a library, omit this property.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net5.0-windows</TargetFramework>

    <UseWPF>true</UseWPF>
    <!-- or -->
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>

</Project>
```

### .NET Core 3.1

- Target the .NET SDK `Microsoft.NET.Sdk.WindowsDesktop`. For more information, see [Project files](overview.md#project-files).
- Set the `TargetFramework` to `netcoreapp3.1`.
- Set one of the following to enable a UI framework:
  - Set `UseWPF` to `true` to use WPF.
  - Set `UseWindowsForms` to `true` to use WinForms.
- (Optional) Set `OutputType` to `WinExe`. This produces an app as opposed to a library. To produce a library, omit this property.

```xml
<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>

    <UseWPF>true</UseWPF>
    <!-- or -->
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>

</Project>
```

## WPF default include exclude

SDK project files define a set of rules to implicitly include or exclude files, and to set their build action. This is unlike the older non-SDK .NET Framework projects, which had no default include or exclude rules and required you to explicitly declare which files to include in the project. WPF projects include rules in addition to the [standard .NET SDK rules](overview.md#default-includes-and-excludes) for automatically processing files.

The following table shows which elements and which [globs](https://en.wikipedia.org/wiki/Glob_(programming)) are included and excluded in the .NET Desktop SDK when the [`UseWPF`](#usewpf) project property is set to `true`:

| Element               | Include glob                 | Exclude glob                                                                                           | Remove glob  |
|-----------------------|------------------------------|--------------------------------------------------------------------|--------------|
| ApplicationDefinition | App.xaml or Application.xaml | N/A                                                                | N/A          |
| Page                  | \*\*/\*.xaml                 | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc<br>Any XAML defined by *ApplicationDefinition* | N/A          |
| None                  | N/A                          | N/A                                                                | \*\*/\*.xaml |

For reference, here are the default include and exclude for all project types. For more information, see [Default includes and excludes](overview.md#default-includes-and-excludes).

| Element           | Include glob                              | Exclude glob                                                  | Remove glob              |
|-------------------|-------------------------------------------|---------------------------------------------------------------|--------------------------|
| Compile           | \*\*/\*.cs; \*\*/\*.vb (or other language extensions) | \*\*/\*.user;  \*\*/\*.\*proj;  \*\*/\*.sln;  \*\*/\*.vssscc  | N/A          |
| EmbeddedResource  | \*\*/\*.resx                              | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | N/A                      |
| None              | \*\*/\*                                   | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | \*\*/\*.cs; \*\*/\*.resx |

### Errors related to "duplicate" items

If you have XAML globs in your project or explicitly add files to your project, you'll possibly get one of the following errors:

* Duplicate 'ApplicationDefinition' items were included.
* Duplicate 'Page' items were included.

These errors are a result of the implicit *Include* globs conflicting with your settings. To work around this problem, either set [`EnableDefaultApplicationDefinition`](#enabledefaultapplicationdefinition) or [`EnableDefaultPageItems`](#enabledefaultpageitems) to `false`. Setting these to `false` reverts to the behavior of previous SDKs where you had to explicitly define the default globs in your project, or explicitly define the files to include in the project.

You can completely disable all implicit includes by setting the [`EnableDefaultItems` property](msbuild-props.md#enabledefaultitems) to `false`.

## WPF settings

- [UseWPF](#usewpf)
- [EnableDefaultApplicationDefinition](#enabledefaultapplicationdefinition)
- [EnableDefaultPageItems](#enabledefaultpageitems)

For more information about standard .NET SDK project settings, see [MSBuild reference for .NET SDK projects](msbuild-props.md).

### UseWPF

The `UseWPF` property controls whether or not to include references to WPF libraries. This also alters the MSBuild pipeline to correctly process a WPF project and related files. The default value is `false`. Set the `UseWPF` property to `true` to enable WPF support. You can only target the Windows platform when this property is enabled.

```xml
<PropertyGroup>
  <UseWPF>true</UseWPF>
</PropertyGroup>
```

.NET 5.0 projects will automatically import the [.NET Desktop SDK](#enable-net-desktop-sdk) when this property is set to `true`.

.NET Core 3.1 projects need to explicitly target the [.NET Desktop SDK](#enable-net-desktop-sdk) to use this property.

### EnableDefaultApplicationDefinition

The `EnableDefaultApplicationDefinition` property controls whether `ApplicationDefinition` items are implicitly included in the project. The default value is `true`. Set the `EnableDefaultApplicationDefinition` property to `false` to disable the implicit file inclusion.

```xml
<PropertyGroup>
  <EnableDefaultApplicationDefinition>false</EnableDefaultApplicationDefinition>
</PropertyGroup>
```

This property requires that the [`EnableDefaultItems` property](msbuild-props.md#enabledefaultitems) property is set to `true`, which is the default setting.

### EnableDefaultPageItems

The `EnableDefaultPageItems` property controls whether `Page` items, which are _.xaml_ files, are implicitly included in the project. The default value is `true`. Set the `EnableDefaultPageItems` property to `false` to disable the implicit file inclusion.

```xml
<PropertyGroup>
  <EnableDefaultPageItems>false</EnableDefaultPageItems>
</PropertyGroup>
```

This property requires that the [`EnableDefaultItems` property](msbuild-props.md#enabledefaultitems) property is set to `true`, which is the default setting.

## WinForms settings

- [UseWindowsForms](#usewindowsforms)

For more information about standard .NET SDK project properties, see [MSBuild reference for .NET SDK projects](msbuild-props.md).

### UseWindowsForms

The `UseWindowsForms` property controls whether or not your application is built to target Windows Forms. This property alters the MSBuild pipeline to correctly process a WinForms project and related files. The default value is `false`. Set the `UseWindowsForms` property to `true` to enable WinForms support. You can only target the Windows platform when this setting is enabled.

```xml
<PropertyGroup>
  <UseWindowsForms>true</UseWindowsForms>
</PropertyGroup>
```

.NET 5.0 projects will automatically import the [.NET Desktop SDK](#enable-net-desktop-sdk) when this property is set to `true`.

.NET Core 3.1 projects need to explicitly target the [.NET Desktop SDK](#enable-net-desktop-sdk) to use this property.

## See also

- [.NET project SDKs](overview.md)
- [MSBuild reference for .NET SDK projects](msbuild-props.md)
- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [Customize a build](/visualstudio/msbuild/customize-your-build)
