---
title: "Breaking change - NU1510 is raised for direct references pruned by NuGet"
description: "Learn about the breaking change in .NET 10 where NU1510 is raised for unnecessary direct package references."
ms.date: 3/25/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45462
---

# NU1510 is raised for direct references pruned by NuGet

Starting in .NET 10, NuGet raises a [`NU1510` warning](/nuget/reference/errors-and-warnings/nu1510) when a project includes a direct package reference that overlaps with a framework-provided library and is not required. 

## Version introduced

.NET 10 Preview 1

## Previous behavior

Previously, the .NET SDK ignored the contents of a package if it overlapped with a framework-provided library. The package reference was allowed but had no effect on the build output.

## New behavior

NuGet now removes unnecessary package references entirely and raises a `NU1510` warning to notify you of the issue.

## Type of breaking change

This is a [source-incompatible change](../../categories.md#source-compatibility).

## Reason for change

This change reduces the maintenance burden on developers by eliminating unused package references. It prevents unnecessary updates, reduces download and restore times, and ensures cleaner build artifacts. The [`NU1510` warning](/nuget/reference/errors-and-warnings/nu1510) warning helps you identify and clean up these references proactively.

## Recommended action

If your project targets only frameworks where the package is pruned, remove the package reference entirely. For multi-targeting projects, conditionally include the package reference only for frameworks that require it. Use the following example as a guide:

```xml
<ItemGroup>
    <!-- reference 8.0 System.Text.Json when targeting things older than .NET 8 -->
    <PackageReference Include="System.Text.Json"  Version="8.0.5" Condition="!$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net8.0'))" />

    <!-- reference 10.0 System.Linq.AsyncEnumerable when targeting things older than .NET 10 -->
    <PackageReference Include="System.Linq.AsyncEnumerable"  Version="10.0.0-preview.2.25163.2" Condition="!$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net.10'))" />

    <!-- Reference System.Memory on frameworks not compatible with .NET Core 2.1 nor .NETStandard 2.1 -->
    <PackageReference Include="System.Memory" Condition="!$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'netcoreapp2.1')) and !$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'netstandard2.1'))" />
</ItemGroup>
```

## Affected APIs

None.
