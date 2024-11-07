---
title: "Breaking change: Warning emitted when targeting net7.0"
description: Learn about the breaking change in the .NET SDK where a warning is issued for apps that target net7.0, which is out of support.
ms.date: 11/6/2024
---

# Warning emitted when targeting net7.0

Starting with the November 2024 releases of the .NET 8 and 9 SDKs, warning [NETSDK1138](../../../tools/sdk-errors/netsdk1138.md) is issued if your app targets `net7.0`. .NET 7 is now out of support.

When a version of .NET goes out of support, it's marked as such in Visual Studio the following month. The .NET SDK waits 6 months before adding a warning.

This change applies to .NET 8.0.111, 8.0.307, 8.0.404, and 9.0.100.

## Version introduced

.NET 9 GA

## Previous behavior

Previously, apps could target `net7.0` without a warning, even though it was out of support.

## New behavior

Starting in .NET 9 and the other [affected versions](#version-introduced), the following warning is issued at compile time for apps that target `net7.0`:

> warning NETSDK1138: The target framework 'net7.0' is out of support

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This is a planned change to ensure that customers are aware that they're targeting an unsupported framework version.

## Recommended action

Upgrade your app to target `net8.0`.

If you must continue targeting `net7.0`, you can set the MSBuild property `CheckEolTargetFramework` to `false`. You can set it in the project file or by passing `/p:CheckEolTargetFramework=false` to a .NET CLI command such as `dotnet build`.

Example *.csproj* or *.vbproj* file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    ...
    <CheckEolTargetFramework>false</CheckEolTargetFramework>
  </PropertyGroup>
</Project>
```

## Affected APIs

None.

## See also

- [NETSDK1138: The target framework is out of support](../../../tools/sdk-errors/netsdk1138.md)
