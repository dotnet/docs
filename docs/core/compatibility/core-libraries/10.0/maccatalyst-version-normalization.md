---
title: "Breaking change: MacCatalyst version normalization"
description: Learn about the .NET 10 breaking change in core .NET libraries where MacCatalyst version components are normalized.
ms.date: 01/01/2025
ai-usage: ai-assisted
---

# MacCatalyst version normalization

This update ensures that MacCatalyst version components retrieved from the OS are always normalized to three components: major, minor, and build. The build component is set to `0` if undefined (`-1`), ensuring consistent behavior between iOS and MacCatalyst versions for version checks.

## Previous behavior

The build component in `Version` was not previously normalized, which led to incorrect version checks on MacCatalyst when only two components (major and minor) were provided. This resulted in invalid version checks.

## New behavior

The MacCatalyst build component is now normalized to `0`, ensuring consistent version checks. The revision component is always set to `-1`, as it is not specified on MacCatalyst or iOS.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This changed was made to prevent incorrect version checks and align MacCatalyst versioning with iOS, ensuring consistent version components.

## Recommended action

Use versions of up to three components (major, minor, and build) on MacCatalyst.

## Affected APIs

- <xref:System.OperatingSystem.IsMacCatalystVersionAtLeast(System.Int32,System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.OperatingSystem.IsOSPlatformVersionAtLeast(System.String,System.Int32,System.Int32,System.Int32,System.Int32)?displayProperty=fullName>
- <xref:System.Environment.OSVersion?displayProperty=fullName>
