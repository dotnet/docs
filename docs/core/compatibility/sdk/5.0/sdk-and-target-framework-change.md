---
title: "Breaking change: WinForms and WPF apps use Microsoft.NET.Sdk"
description: Learn about the breaking change in .NET 5 where Windows Forms and Windows Presentation Framework apps now use the .NET SDK instead of the .NET Core WinForms and WPF SDK.
ms.date: 09/18/2020
---
# WinForms and WPF apps use Microsoft.NET.Sdk

Windows Forms and Windows Presentation Framework (WPF) apps now use the .NET SDK (`Microsoft.NET.Sdk`) instead of the .NET Core WinForms and WPF SDK (`Microsoft.NET.Sdk.WindowsDesktop`).

## Change description

In previous .NET Core versions, WinForms and WPF apps used a separate [project SDK](../../../project-sdk/overview.md) (`Microsoft.NET.Sdk.WindowsDesktop`). Starting in .NET 5, the WinForms and WPF SDK has been unified with the .NET SDK (`Microsoft.NET.Sdk`). In addition, new [target framework monikers (TFM)](../../../../standard/frameworks.md) replace `netcoreapp` and `netstandard` in .NET 5. The following example shows the changes you'd need to make for a WPF project file when retargeting to .NET 5 or later.

In previous .NET Core versions:

```xml
<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <UseWPF>true</UseWPF>
  </PropertyGroup>

</Project>
```

In .NET 5 and later versions:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net5.0-windows</TargetFramework>
    <UseWPF>true</UseWPF>
  </PropertyGroup>

</Project>
```

## Version introduced

.NET SDK 5.0.100

## Recommended action

In your WPF or Windows Forms project file:

- Update the `Sdk` attribute  to `Microsoft.NET.Sdk`.
- Update the `TargetFramework` property to `net5.0-windows`.

## Affected APIs

None.

<!--

### Affected APIs

Not detectable via API analysis.

### Category

- SDK
- Windows Forms
- Windows Presentation Framework (WPF)

-->
