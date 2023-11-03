---
title: ".NET 8 breaking change: GetSystemVersion no longer returns ImageRuntimeVersion"
description: Learn about the .NET 8 breaking change in core .NET libraries where RuntimeEnvironment.GetSystemVersion no longer returns ImageRuntimeVersion, which is a .NET Framework-oriented value.
ms.date: 09/06/2023
---
# GetSystemVersion no longer returns ImageRuntimeVersion

<xref:System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion?displayProperty=nameWithType> no longer returns <xref:System.Reflection.Assembly.ImageRuntimeVersion?displayProperty=nameWithType>, which is a .NET Framework-oriented value. It's been updated to return a more relevant value, however, the historical leading `v` has been maintained.

## Previous behavior

<xref:System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion?displayProperty=nameWithType> returned <xref:System.Reflection.Assembly.ImageRuntimeVersion?displayProperty=nameWithType>, which is an indicator of .NET Framework in-place replacement, not a product release.

Example: `v4.0.30319`

## New behavior

Starting in .NET 8, <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion?displayProperty=nameWithType> returns `"v"` concatenated with <xref:System.Environment.Version?displayProperty=nameWithType>, which is the version of the CLR.

Example: `v8.0.0`

## Version introduced

.NET 8 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The existing version wasn't useful or meaningful for .NET.

## Recommended action

Update your code to expect the new version, or use `typeof(object).Assembly.ImageRuntimeVersion` instead.

## Affected APIs

- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion?displayProperty=fullName>

## See also

The following changes are related:

- [Improved .NET Core version APIs](../../../whats-new/dotnet-core-3-0.md#improved-net-core-version-apis)
- [FrameworkDescription's value is .NET instead of .NET Core](../5.0/frameworkdescription-returns-net-not-net-core.md)
