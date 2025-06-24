---
title: "Breaking change - PackageReference without a version raises an error"
description: "Learn about the breaking change in .NET 10 where PackageReference without a version raises NU1015 error instead of NU1604 warning."
ms.date: 06/23/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46386
---

# PackageReference without a version will raise an error

Starting in .NET 10, NuGet raises a [`NU1015` error](/nuget/reference/errors-and-warnings/nu1015) when a `PackageReference` item doesn't have a version specified, instead of the previous [`NU1604` warning](/nuget/reference/errors-and-warnings/nu1604).

There's no change when using Central Package Management, since by design the PackageReference XML should not have a version in that scenario.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously, NuGet raised a NU1604 warning with the following text:

> Project dependency 'PackageA' does not contain an inclusive lower bound. Include a lower bound in the dependency version to ensure consistent restore results.

## New behavior

Starting in .NET 10, NuGet raises a NU1015 error with the following text:

> The following PackageReference item(s) do not have a version specified: PackageA

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The "no lower bound" message was confusing, and it was unclear how to fix the issue. Additionally, NuGet restored the lowest version for that package, which is rarely what developers want. This change provides clearer and more actionable error messages when the version metadata is missing.

## Recommended action

Add a version to the package reference, for example:

```diff
- <PackageReference Include="Some.Package" />
+ <PackageReference Include="Some.Package" Version="1.2.3" />
```

If the lowest package version is desired, then use `Version="0.0.0"`. In this case, NuGet will raise warning NU1603, rather than the previous NU1604.

To revert to the previous warning, you can set `SdkAnalysisLevel` to `9.0.300` or lower. However, this will affect all features that gate on `SdkAnalysisLevel`.

## Affected APIs

None.
