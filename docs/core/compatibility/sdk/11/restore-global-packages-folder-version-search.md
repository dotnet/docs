---
title: "Breaking change: Restore doesn't search the global packages folder for a higher package version"
description: "Learn about the breaking change in .NET 11 where NuGet restore no longer considers versions in the global packages folder when it selects a higher package version."
ms.date: 09/01/2026
ai-usage: ai-assisted
---

# Restore doesn't search the global packages folder for a higher package version

When a `PackageReference` or package dependency requests a package version that doesn't exist, NuGet restore searches for the lowest version that's higher than the requested version. NuGet restore no longer includes the versions in the global packages folder in that search.

## Version introduced

.NET 11 RC 1

## Previous behavior

Previously, when restore couldn't find the requested version, it searched both the package sources and the global packages folder for the "next best" version, that is, the lowest version that's higher than the requested version. Restore selected that version and raised an NU1603 or NU1604 warning. If no higher version was found, restore reported an NU1102 error.

| Package source | Global packages folder | Requested version | Version selected | Restore outcome |
|----------------|------------------------|-------------------|------------------|-----------------|
| 1.0.0, 2.0.0   | 1.5.0                  | 1.1.0             | 1.5.0            | NU1603 warning  |
| 1.0.0          | 1.5.0                  | 1.1.0             | 1.5.0            | NU1603 warning  |

## New behavior

Starting in .NET 11, restore searches only the package sources for the "next best" version. Because the global packages folder is excluded from the search, restore might select a higher version than before, or fail with an NU1102 error if no package source has a higher version.

| Package source | Global packages folder | Requested version | Version selected | Restore outcome |
|----------------|------------------------|-------------------|------------------|-----------------|
| 1.0.0, 2.0.0   | 1.5.0                  | 1.1.0             | 2.0.0            | NU1603 warning  |
| 1.0.0          | 1.5.0                  | 1.1.0             | n/a              | NU1102 error    |

If the global packages folder contains the exact requested version, restore uses that version, even if no package source has that version. This behavior is unchanged.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Restore is now more deterministic and repeatable. For performance reasons, NuGet doesn't validate that packages in the global packages folder match the packages on the package sources. However, restore now selects the same package version on different computers, where the global packages folder might contain different versions.

## Recommended action

Reference only package versions that exist on your package sources. Doing so ensures that the version selected during restore doesn't change over time as new versions are published to the package sources.

For more information, see [Best practices for a secure software supply chain](/nuget/concepts/security-best-practices).

## Affected APIs

None.
