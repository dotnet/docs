---
title: "Breaking change: ResolvePackageDependencies no longer called"
description: Learn about a breaking change in SDK for .NET 7 where the .NET SDK no longer calls the ResolvePackageDependencies target to get package information.
ms.date: 07/14/2023
ms.topic: concept-article
---
# SDK no longer calls ResolvePackageDependencies

Previously, the .NET SDK called the `ResolvePackageDependencies` target in order to generate `PackageDependencies` and `PackageDefinitions`. However, that data was already available from a different target. Instead, those two items are now added from `PreprocessPackageDependenciesDesignTime` into the design-time build cache and the prior target isn't called.

## Version introduced

.NET SDK 7.0.200

## Type of change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Previous behavior

An existing .NET SDK target was called to get information on packages that were already available.

## New behavior

Package information is added from `PreprocessPackageDependenciesDesignTime` into the design-time build cache. If you depended on `PackageDependencies` and `PackageDefinitions` in your build, you'll see build errors such as **No dependencies found**.

## Reason for change

In some situations, performance was particularly slow for the prior target. Solutions that have large NuGet dependency graphs will see faster IntelliSense after solution loads, branch switches, or when making solution-wide changes while using the Central Package Management feature.

## Recommended action

If your build depends on the previous behavior, add the `<EmitLegacyAssetsFileItems>true</EmitLegacyAssetsFileItems>` property to your project to return to the legacy behavior. We expect this to only impact a small number of users.

```xml
<PropertyGroup>
  <EmitLegacyAssetsFileItems>true</EmitLegacyAssetsFileItems>
</PropertyGroup>
```
