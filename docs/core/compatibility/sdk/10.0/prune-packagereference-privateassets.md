---
title: "Breaking change - PrunePackageReference privatizes direct prunable references"
description: "Learn about the breaking change in the .NET 10 SDK where PrunePackageReference automatically marks directly prunable PackageReference with PrivateAssets=all and IncludeAssets=none."
ms.date: 09/04/2025
ai-usage: ai-assisted
---

# PrunePackageReference privatizes direct prunable references

The [PrunePackageReference](/nuget/consume-packages/package-references-in-project-files#prunepackagereference) feature automatically removes *transitive* packages that are provided by the target platform. With this change, the feature also marks *directly* prunable `PackageReference` items with `PrivateAssets=all` and `IncludeAssets=none` attributes. These attributes prevent the packages from appearing in generated dependency lists for packages.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Starting in .NET 10 Preview 1, if pruning was enabled, directly prunable `PackageReference` items might have generated an [`NU1510` warning](/nuget/reference/errors-and-warnings/nu1510) but still appeared in the generated *.nuspec* dependencies list, even if the package was provided by the platform.

For example, consider a multi-targeting project with the following configuration:

```xml
<PropertyGroup>
  <TargetFramework>net10.0;net472</TargetFramework>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="System.Text.Json" Version="9.0.8" />
</ItemGroup>
```

Such a project file generated a *.nuspec* file with dependencies for both target frameworks:

```xml
<dependencies>
  <group targetFramework=".NETFramework4.7.2">
    <dependency id="System.Text.Json" version="9.0.8" />
  </group>
  <group targetFramework="net10.0">
    <dependency id="System.Text.Json" version="9.0.8" />
  </group>
</dependencies>
```

## New behavior

Starting in .NET 10 Preview 7, when pruning is enabled, directly prunable `PackageReference` items are automatically marked with `PrivateAssets=all` and `IncludeAssets=none`, which excludes them from the generated dependencies for target frameworks where they're provided by the platform. (However, if your project targets .NET 10 or later, you'll still get the `NU1510` warning until you remove the reference from your project.)

The same project configuration now generates a *.nuspec* file with the prunable dependency removed from the target framework that provides it (.NET 10):

```xml
<dependencies>
  <group targetFramework=".NETFramework4.7.2">
    <dependency id="System.Text.Json" version="9.0.8" />
  </group>
  <group targetFramework="net10.0">
  </group>
</dependencies>
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change ensures that package dependencies accurately reflect the actual requirements for each target framework. It prevents unnecessary package references from appearing in generated packages when those APIs are already provided by the target framework.

## Recommended action

- If you create a package and get a [`NU1510` warning](/nuget/reference/errors-and-warnings/nu1510), follow the instructions there.
- If you create a package and the generated *.nuspec* dependencies don't contain a referenced package for *any* target framework, remove the reference from the project file as it's not needed.
- If the referenced package appears in the *.nuspec* file, no action is needed.

## Affected APIs

None.

## See also

- [PrunePackageReference](/nuget/consume-packages/package-references-in-project-files#prunepackagereference)
- [NU1510 is raised for direct references pruned by NuGet](nu1510-pruned-references.md)
