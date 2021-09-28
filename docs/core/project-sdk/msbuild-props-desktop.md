---
title: MSBuild properties for Microsoft.NET.Sdk.Desktop
description: Reference for the MSBuild properties and items that are understood by the .NET Desktop SDK, which includes WPF and WinForms.
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

Specify the following settings in the project file of your WinForms or WPF project:

- Target the .NET SDK `Microsoft.NET.Sdk`. For more information, see [Project files](overview.md#project-files).
- Set [`TargetFramework`](msbuild-props.md#targetframework) to `net5.0-windows`.
- Add a UI framework property (or both, if necessary):
  - Set [`UseWPF`](#usewpf) to `true` to import and use WPF.
  - Set [`UseWindowsForms`](#usewindowsforms) to `true` to import and use WinForms.
- (Optional) Set `OutputType` to `WinExe`. This produces an app as opposed to a library. To produce a library, omit this property.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net5.0-windows</TargetFramework>

    <UseWPF>true</UseWPF>
    <!-- and/or -->
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>

</Project>
```

### .NET Core 3.1

Specify the following settings in the project file of your WinForms or WPF project:

- Target the .NET SDK `Microsoft.NET.Sdk.WindowsDesktop`. For more information, see [Project files](overview.md#project-files).
- Set [`TargetFramework`](msbuild-props.md#targetframework) to `netcoreapp3.1`.
- Add a UI framework property (or both, if necessary):
  - Set [`UseWPF`](#usewpf) to `true` to import and use WPF.
  - Set [`UseWindowsForms`](#usewindowsforms) to `true` to import and use WinForms.
- (Optional) Set `OutputType` to `WinExe`. This produces an app as opposed to a library. To produce a library, omit this property.

```xml
<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>

    <UseWPF>true</UseWPF>
    <!-- and/or -->
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>

</Project>
```

## WPF default includes and excludes

SDK projects define a set of rules to implicitly include or exclude files from the project. These rules also automatically set the file's build action. This is unlike the older non-SDK .NET Framework projects, which have no default include or exclude rules. .NET Framework projects require you to explicitly declare which files to include in the project.

.NET project files include a [standard set of rules](overview.md#default-includes-and-excludes) for automatically processing files. WPF projects add additional rules.

The following table shows which elements and [globs](https://en.wikipedia.org/wiki/Glob_(programming)) are included and excluded in the .NET Desktop SDK when the [`UseWPF`](#usewpf) project property is set to `true`:

| Element               | Include glob                 | Exclude glob                                                                                           | Remove glob  |
|-----------------------|------------------------------|--------------------------------------------------------------------|--------------|
| ApplicationDefinition | App.xaml or Application.xaml | N/A                                                                | N/A          |
| Page                  | \*\*/\*.xaml                 | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc<br>Any XAML defined by *ApplicationDefinition* | N/A          |
| None                  | N/A                          | N/A                                                                | \*\*/\*.xaml |

Here are the default include and exclude settings for all project types. For more information, see [Default includes and excludes](overview.md#default-includes-and-excludes).

| Element           | Include glob                              | Exclude glob                                                  | Remove glob              |
|-------------------|-------------------------------------------|---------------------------------------------------------------|--------------------------|
| Compile           | \*\*/\*.cs; \*\*/\*.vb (or other language extensions) | \*\*/\*.user;  \*\*/\*.\*proj;  \*\*/\*.sln;  \*\*/\*.vssscc  | N/A          |
| EmbeddedResource  | \*\*/\*.resx                              | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | N/A                      |
| None              | \*\*/\*                                   | \*\*/\*.user; \*\*/\*.\*proj; \*\*/\*.sln; \*\*/\*.vssscc     | \*\*/\*.cs; \*\*/\*.resx |

### Errors related to "duplicate" items

If you explicitly added files to your project, or have XAML globs to automatically include files in your project, you might get one of the following errors:

* Duplicate 'ApplicationDefinition' items were included.
* Duplicate 'Page' items were included.

These errors are a result of the implicit *Include* globs conflicting with your settings. To work around this problem, set either [`EnableDefaultApplicationDefinition`](#enabledefaultapplicationdefinition) or [`EnableDefaultPageItems`](#enabledefaultpageitems) to `false`. Setting these values to `false` reverts to the behavior of previous SDKs where you had to explicitly define the default globs in your project, or explicitly define the files to include in the project.

You can completely disable all implicit includes by setting the [`EnableDefaultItems` property](msbuild-props.md#enabledefaultitems) to `false`.

## WPF settings

- [UseWPF](#usewpf)
- [EnableDefaultApplicationDefinition](#enabledefaultapplicationdefinition)
- [EnableDefaultPageItems](#enabledefaultpageitems)

For information about non-WPF-specific project settings, see [MSBuild reference for .NET SDK projects](msbuild-props.md).

### UseWPF

The `UseWPF` property controls whether or not to include references to WPF libraries. This also alters the MSBuild pipeline to correctly process a WPF project and related files. The default value is `false`. Set the `UseWPF` property to `true` to enable WPF support. You can only target the Windows platform when this property is enabled.

```xml
<PropertyGroup>
  <UseWPF>true</UseWPF>
</PropertyGroup>
```

When this property is set to `true`, .NET 5.0+ projects will automatically import the [.NET Desktop SDK](#enable-net-desktop-sdk).

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

## Windows Forms settings

- [UseWindowsForms](#usewindowsforms)

For information about non-WinForms-specific project properties, see [MSBuild reference for .NET SDK projects](msbuild-props.md).

### UseWindowsForms

The `UseWindowsForms` property controls whether or not your application is built to target Windows Forms. This property alters the MSBuild pipeline to correctly process a Windows Forms project and related files. The default value is `false`. Set the `UseWindowsForms` property to `true` to enable Windows Forms support. You can only target the Windows platform when this setting is enabled.

```xml
<PropertyGroup>
  <UseWindowsForms>true</UseWindowsForms>
</PropertyGroup>
```

When this property is set to `true`, .NET 5.0+ projects will automatically import the [.NET Desktop SDK](#enable-net-desktop-sdk).

.NET Core 3.1 projects need to explicitly target the [.NET Desktop SDK](#enable-net-desktop-sdk) to use this property.

## Shared settings

- [DisableWinExeOutputInference](#disablewinexeoutputinference)

### DisableWinExeOutputInference

Applies to .NET 5.0 SDK and later.

When an app has the `Exe` value set for the `OutputType` property, a console window is created if the app isn't running from a console. This is generally not the desired behavior of a Windows Desktop app. With the `WinExe` value, a console window isn't created. Starting with the .NET 5.0 SDK, the `Exe` value is automatically transformed to `WinExe`.

The `DisableWinExeOutputInference` property reverts the behavior of treating `Exe` as `WinExe`. Set this value to `true` to restore the behavior of the `OutputType` property value of `Exe`. The default value is `false`.

```xml
<PropertyGroup>
  <DisableWinExeOutputInference>true</DisableWinExeOutputInference>
</PropertyGroup>
```

## See also

- [.NET project SDKs](overview.md)
- [MSBuild reference for .NET SDK projects](msbuild-props.md)
- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [Customize a build](/visualstudio/msbuild/customize-your-build)
