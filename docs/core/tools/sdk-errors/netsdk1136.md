---
title: "NETSDK1136: The target platform must be set to Windows"
description: Learn about the .NET SDK error that directs you to set your target platform to Windows.
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1136
---
# NETSDK1136: The target framework must be Windows

If `UseWindowsForms` or `UseWPF` is `true`, .NET assumes that your project is a Windows app, and so the platform has to be set to Windows. This error can happen if you have a project-to-project reference where one is set to Windows and the other is not. The full error message is similar to the following example:

>The target platform must be set to Windows (usually by including `-windows` in the `TargetFramework` property) when using Windows Forms or WPF, or referencing projects or packages that do so.

For example, set `TargetFramework` to `net6.0-windows`, as shown in this project file:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net6.0-windows</TargetFramework>
  </PropertyGroup>
</Project>
```
