---
title: "Breaking change: Use WindowsSdkPackageVersion to override Windows SDK version"
description: Learn about the breaking change in .NET 5 where the WindowsSdkPackageVersion property replaces the FrameworkReference item for overriding the version of the Windows SDK targeting package.
ms.date: 08/04/2021
ms.topic: concept-article
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

When working with the [Windows App SDK](https://github.com/microsoft/WindowsAppSDK), you might need to explicitly add the `WindowsSdkPackageVersion` property if the required [Windows SDK package](https://www.nuget.org/packages/Microsoft.Windows.SDK.NET.Ref) version cannot be resolved by .NET SDK. This issue can arise due to different release mechanisms for the Windows App SDK and .NET SDK, where the .NET SDK is shipped through Visual Studio. See details in this [GitHub issue](https://github.com/microsoft/WindowsAppSDK/issues/4734). You might also consider removing the `WindowsSdkPackageVersion` property once the required Windows SDK package version has been resolved by .NET SDK, ensuring you have the latest Windows SDK package. This typically happens after Visual Studio releases a new version and you've upgraded to that version.

## Affected APIs

Windows APIs in .NET 5 and later versions that are provided by the [Windows SDK targeting package](https://www.nuget.org/packages/Microsoft.Windows.SDK.NET.Ref).
