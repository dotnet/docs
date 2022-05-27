---
title: "Breaking change: Use WindowsSdkPackageVersion to override Windows SDK version"
description: Learn about the breaking change in .NET 5 where the WindowsSdkPackageVersion property replaces the FrameworkReference item for overriding the version of the Windows SDK targeting package.
ms.date: 08/04/2021
---
# FrameworkReference replaced with WindowsSdkPackageVersion for Windows SDK

Starting in .NET 5.0.8 (which includes .NET SDK 5.0.302 and .NET SDK 5.0.205), developers targeting Windows can't use the `FrameworkReference` item to override their version of the Windows SDK targeting package. The `WindowsSdkPackageVersion` property replaces this functionality.

> [!NOTE]
> We don't recommend overriding the Windows SDK version, because the Windows SDK targeting packages are included with the .NET 5+ SDK. Instead, to reference the latest Windows SDK package, update your version of the .NET SDK.

## Version introduced

.NET SDK 5.0.302, .NET SDK 5.0.205

## Previous behavior

Developers could use the `FrameworkReference` item to override the Windows SDK package version in .NET 5 applications. For example:

```xml
<ItemGroup>
  <FrameworkReference Update="Microsoft.Windows.SDK.NET.Ref" RuntimeFrameworkVersion="10.0.19041.18" />
  <FrameworkReference Update="Microsoft.Windows.SDK.NET.Ref" TargetingPackVersion="10.0.19041.18" />
</ItemGroup>
```

## New behavior

The [`WindowsSdkPackageVersion`](../../../project-sdk/msbuild-props.md#windowssdkpackageversion) property replaces the behavior of the `FrameworkReference` override. For example:

```xml
<PropertyGroup>
  <WindowsSdkPackageVersion>10.0.19041.18</WindowsSdkPackageVersion>
</PropertyGroup>
```

## Category of change

This change might affect [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

This change was introduced to simplify the package override behavior for targeting the Windows SDK packages produced by C#/WinRT.

## Recommended action

Remove any use of `FrameworkReference` in your .NET 5+ app's project file when targeting the Windows SDK.

## Affected APIs

Windows APIs in .NET 5 and later versions that are provided by the [Windows SDK targeting package](https://www.nuget.org/packages/Microsoft.Windows.SDK.NET.Ref).
