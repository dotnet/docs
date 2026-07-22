---
title: "Breaking change: NuGet pack warns for package IDs with restricted characters"
description: "Learn about the breaking change in .NET 11 where NuGet's pack command emits warning NU5052 for package IDs that use characters outside the restricted set."
ms.date: 07/22/2026
ai-usage: ai-assisted
---

# NuGet pack warns for package IDs with restricted characters

Starting in .NET 11 Preview 6, `dotnet pack` emits warning **NU5052** when a package ID contains characters outside the restricted character set enforced by nuget.org.

## Version introduced

.NET 11 Preview 6

## Previous behavior

Previously, `dotnet pack` produced a package for any package ID that the legacy NuGet ID rules accepted, including IDs with characters outside ASCII letters, digits, dots, and dashes, or with consecutive `.` or `-` characters.

## New behavior

Starting in .NET 11 (with `SdkAnalysisLevel >= 11.0.100`, first introduced in .NET 11 Preview 6), packing a project whose `PackageId` doesn't meet the restricted rules emits warning **NU5052**. A valid package ID:

- Must start with a letter, digit, or underscore (`_`).
- May contain only ASCII letters, digits, dots (`.`), dashes (`-`), and underscores (`_`).
- Can't contain consecutive `.` or `-` characters.
- Must be 100 characters or fewer.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

NuGet derives strings such as URLs and file-system paths from a normalized version of the package ID. Normalization relies on built-in string libraries that are inconsistent across .NET Framework, modern .NET, Windows, and Linux, so two visibly different IDs can normalize to the same string. Restricting the allowed character set, as npm, PyPI, and other registries have done, closes this security and branding gap.

For more information, see the [NuGet announcement](https://github.com/NuGet/Announcements/issues/75).

## Recommended action

Rename the package to an ID within the restricted character set—for example, transliterate non-ASCII characters to their ASCII equivalents (`Müller.Logging` becomes `Mueller.Logging`). Then deprecate the old package ID and point it at the new one.

Because this warning doesn't block the build, you can also suppress it:

- Add `<NoWarn>NU5052</NoWarn>` to the project file.
- Set `SdkAnalysisLevel` to a version below `11.0.100`.

## Affected APIs

None.
