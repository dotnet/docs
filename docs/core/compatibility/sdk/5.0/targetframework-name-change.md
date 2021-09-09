---
title: "Breaking change: TargetFramework change from netcoreapp to net"
description: Learn about the breaking change in .NET 5 where the value for the MSBuild TargetFramework property changed from netcoreapp3.1 to net5.0.
ms.date: 10/17/2020
---
# TargetFramework change from netcoreapp to net

The value for the MSBuild `TargetFramework` property changed from `netcoreapp3.1` to `net5.0`. This can break code that relies on parsing the value of `TargetFramework`.

## Version introduced

5.0

## Change description

In .NET Core 1.0 - 3.1, the value for the MSBuild `TargetFramework` property starts with `netcoreapp`, for example, `netcoreapp3.1` for apps that target .NET Core 3.1. Starting in .NET 5, this value is simplified to just start with `net`, for example, `net5.0` for .NET 5.0.

For more information, see [The future of .NET Standard](https://devblogs.microsoft.com/dotnet/the-future-of-net-standard/) and [Target framework names in .NET 5](https://github.com/dotnet/designs/blob/main/accepted/2020/net5/net5.md).

## Reason for change

- Simplifies the `TargetFramework` value.
- Enables projects to include a `TargetPlatform` in the `TargetFramework` property.

## Recommended action

If you have logic that parses the value of `TargetFramework`, you'll need to update it. For example, the following MSBuild condition relies on the value of `TargetFramework`.

```xml
<PropertyGroup Condition="$(TargetFramework.StartsWith('netcoreapp'))">
```

For this requirement, you can update the code to compare the target framework identifier instead.

```xml
<PropertyGroup Condition="'$([MSBuild]::GetTargetFrameworkIdentifier('$(TargetFramework)'))' == '.NETCoreApp'">
```

## Affected APIs

N/A

<!--

### Affected APIs

Not detectable via API analysis.

### Category

MSBuild

-->
