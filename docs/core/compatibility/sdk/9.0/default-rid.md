---
title: "Default RID used when targeting .NET Framework"
description: "Learn about the breaking change in the .NET 9 SDK where a new default RID is used for apps that target .NET Framework."
ms.date: 12/5/2024
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/43692
---

# Default RID used when targeting .NET Framework

In .NET 8, a change was introduced to [use a smaller runtime identifier (RID) graph](../8.0/rid-graph.md) when targeting `net8.0` and later versions.

However, this broke customers who multi-target .NET and .NET Framework. That's because the restore happens once, but the .NET Framework project tries to use the old RID default and the .NET (Core) project tries to use the new reduced RID graph.

To enable this multi-targeting scenario, a default RID that's compatible with the new RID graph is now used in this scenario.

## Version introduced

.NET 9 GA

## Previous behavior

SDK-style projects that targeted .NET Framework with no RID set defaulted to `win7-x86` or `win7-x64`.

## New behavior

SDK-style projects that target .NET Framework with no RID set default to `win-x86` or `win-x64`.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

.NET Framework applications were getting a default RID that was incompatible with the portable RID graph. That incompatibility resulted in a restore error:

> Sdks\Microsoft.NET.Sdk\targets\Microsoft.PackageDependencyResolution.targets(266,5): error NETSDK1047: Assets file 'D:\1\s\artifacts\obj\MSBuild\project.assets.json' doesn't have a target for 'net472/win7-x64'. Ensure that restore has run and that you have included 'net472' in the TargetFrameworks for your project. You may also need to include 'win7-x64' in your project's RuntimeIdentifiers. \[MSBuild.csproj::TargetFramework=net472]>

For more information, see [dotnet/sdk issue #35575](https://github.com/dotnet/sdk/issues/35575).

## Recommended action

If you're affected by this change, choose one of the following actions:

- Update your runtime identifier to a value supported by the portable RID graph. Project file example:

   ```xml
   <PropertyGroup>
      <RuntimeIdentifier>win-x64</RuntimeIdentifier>
   </PropertyGroup>
   ```

  If you specify the RID as a command-line argument, make a similar change. For example, `dotnet publish --runtime win-x64`.

- Switch back to the old RID graph by setting `UseRidGraph` to `true` in the project file:

  ```xml
  <PropertyGroup>
    <UseRidGraph>true</UseRidGraph>
  </PropertyGroup>
  ```

## Affected APIs

None.
