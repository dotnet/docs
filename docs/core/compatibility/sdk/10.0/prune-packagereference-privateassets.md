---
title: "Breaking change - PrunePackageReference automatically marks direct prunable references with PrivateAssets=all and IncludeAssets=none"
description: "Learn about the breaking change in .NET 10 Preview 7 where PrunePackageReference automatically marks directly prunable PackageReference with PrivateAssets=all and IncludeAssets=none."
ms.date: 01/03/2025
ai-usage: ai-assisted
---

# PrunePackageReference automatically marks direct prunable references with PrivateAssets=all and IncludeAssets=none

Starting in .NET 10 Preview 7, the PrunePackageReference feature automatically marks directly prunable PackageReference items with `PrivateAssets=all` and `IncludeAssets=none` attributes. This prevents these packages from appearing in generated dependency lists for multi-targeting packages.

## Version introduced

.NET 10 Preview 7

## Previous behavior

In .NET 10 Preview 6 and earlier, directly prunable PackageReference items would generate an [`NU1510` warning](/nuget/reference/errors-and-warnings/nu1510) but would still appear in the generated *.nuspec* dependencies for all target frameworks, even those where the package is provided by the platform.

For example, a multi-targeting project with the following configuration:

```xml
<PropertyGroup>
  <TargetFramework>net9.0;net472</TargetFramework>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="System.Text.Json" Version="9.0.4" />
</ItemGroup>
```

Would generate a *.nuspec* file with dependencies for both target frameworks:

```xml
<dependencies>
  <group targetFramework=".NETFramework4.7.2">
    <dependency id="System.Text.Json" version="9.0.4" />
  </group>
  <group targetFramework="net9.0">
    <dependency id="System.Text.Json" version="9.0.4" />
  </group>
</dependencies>
```

## New behavior

Starting in .NET 10 Preview 7, directly prunable PackageReference items are automatically marked with `PrivateAssets=all` and `IncludeAssets=none`, which excludes them from the generated dependencies for target frameworks where they're provided by the platform.

The same project configuration now generates a *.nuspec* file with the prunable dependency removed from target frameworks that provide it:

```xml
<dependencies>
  <group targetFramework=".NETFramework4.7.2">
    <dependency id="System.Text.Json" version="9.0.4" />
  </group>
  <group targetFramework="net9.0">
  </group>
</dependencies>
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-changes).

## Reason for change

This change ensures that package dependencies accurately reflect the actual requirements for each target framework. It prevents unnecessary package references from appearing in generated packages when those APIs are already provided by the target framework, reducing maintenance burden and avoiding false dependency issues.

## Recommended action

If you're creating packages and the generated *.nuspec* dependencies are missing a PackageReference for certain target frameworks:

1. **If the package is no longer needed for any target framework**: Remove the PackageReference entirely from your project file.

2. **If the package is still needed for some target frameworks**: Use conditional PackageReference to include it only where necessary. For example:

   ```xml
   <ItemGroup>
     <!-- Include System.Text.Json only for frameworks older than .NET 8 -->
     <PackageReference Include="System.Text.Json" Version="9.0.4" 
                       Condition="!$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net8.0'))" />
   </ItemGroup>
   ```

3. **If you need to override the automatic pruning behavior**: Set `RestoreEnablePackagePruning` to `false` in your project file or *Directory.Build.props* file:

   ```xml
   <PropertyGroup>
     <RestoreEnablePackagePruning>false</RestoreEnablePackagePruning>
   </PropertyGroup>
   ```

For more information about package pruning, see [PrunePackageReference](/nuget/consume-packages/package-references-in-project-files#prunepackagereference).

## Affected APIs

None.
