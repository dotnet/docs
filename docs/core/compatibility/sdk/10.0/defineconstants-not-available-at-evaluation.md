---
title: "Breaking change: `DefineConstants` for target frameworks not available at evaluation time"
description: "Learn about the breaking change in .NET 10 SDK where DefineConstants items for target frameworks are no longer available at MSBuild evaluation time."
ms.date: 03/12/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/51763
---

# `DefineConstants` for target frameworks not available at evaluation time

The target-framework-related `DefineConstants` items (such as `NET`, `NET9_0_OR_GREATER`, `NETSTANDARD2_0`, and similar constants) are no longer computed at MSBuild evaluation time. Using these constants in MSBuild `Condition` attributes in your project file will no longer work as expected.

## Version introduced

.NET 10

## Previous behavior

Previously, `DefineConstants` values like `NET`, `NETFRAMEWORK`, and `NETSTANDARD` (with optional version and `_OR_GREATER` suffixes, such as `NET_4_5_2_OR_GREATER` or `NET9_0_OR_GREATER`) were available during MSBuild evaluation. This allowed you to use them directly in `Condition` attributes in your project file:

```xml
<ItemGroup Condition="$(DefineConstants.Contains('NET9_0_OR_GREATER'))">
  <PackageReference Include="SomePackage" Version="1.0.0" />
</ItemGroup>
```

## New behavior

Starting in .NET 10, the target-framework `DefineConstants` values are computed in a `Target`, not during MSBuild evaluation. As a result, `Condition` attributes that inspect `DefineConstants` for TFM-related values evaluate before those values are set and no longer trigger as expected.

For example, the following condition no longer evaluates correctly because `NET9_0_OR_GREATER` isn't present in `DefineConstants` at evaluation time:

```xml
<!-- This no longer works as expected -->
<ItemGroup Condition="$(DefineConstants.Contains('NET9_0_OR_GREATER'))">
  <PackageReference Include="SomePackage" Version="1.0.0" />
</ItemGroup>
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Direct access or manipulation of `DefineConstants` led to users accidentally overwriting the values. In addition, moving the computation into a `Target` enables more complex MSBuild orchestration scenarios required by other tools.

## Recommended action

- **Do not** inspect `DefineConstants` for TFM-related values (for example, `NET9_0_OR_GREATER`, `NETSTANDARD2_0`, and similar) in MSBuild `Condition` attributes at evaluation time.
- **Do** use the documented [MSBuild `TargetFramework` and `TargetPlatform` functions](/visualstudio/msbuild/property-functions#msbuild-targetframework-and-targetplatform-functions) to check for target-framework compatibility. For example:

  ```xml
  <!-- Condition on a specific TFM -->
  <ItemGroup Condition="$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net9.0'))">
    <PackageReference Include="SomePackage" Version="1.0.0" />
  </ItemGroup>

  <!-- Condition excluding a TFM -->
  <ItemGroup Condition="!$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net8.0'))">
    <PackageReference Include="LegacyPackage" Version="2.0.0" />
  </ItemGroup>
  ```

- **Continue** to use `DefineConstants` in `Condition` attributes for constants that you define and control yourself. This change only affects the TFM-related constants that the SDK sets automatically.

## Affected APIs

None.
