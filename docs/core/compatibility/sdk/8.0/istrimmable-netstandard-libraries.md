---
title: "Breaking change: IsTrimmable warns when used with netstandard libraries"
description: Learn about a breaking change in the .NE 8 SDK where netstandard libraries that specify IsTrimmable produce a new warning.
ms.date: 08/21/2023
---
# IsTrimmable warns when used with netstandard libraries

Libraries that set `<IsTrimmable>true</IsTrimmable>` with a `TargetFramework` that is any version of netstandard produce a warning that `IsTrimmable` is unsupported.
Setting `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>` in such a library produces the same warning.

## Previous behavior

Previously, `<IsTrimmable>true</IsTrimmable>` would embed an assembly-level attribute `[assembly: AssemblyMetadata("IsTrimmable", "true")]` into the library, opting it into trimming when consumed in a trimmed app (even an app that uses `<TrimMode>partial</TrimMode>`).

`<EnableTrimAnalyzer>true</EnableTrimAnalyzer>` would enable trim analysis for the library, using the netstandard reference assemblies corresponding to the library's `TargetFramework` even though the netstandard reference assemblies were not annotated for trimming.

## New behavior

In the .NET 8 SDK, building a netstandard library with `<IsTrimmable>` or `<EnableTrimAnalyzer>` produces a warning that `<IsTrimmable>` is unsupported for the target framework, and does not otherwise change the build output.

## Version introduced

.NET 8 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Allowing the use of `<IsTrimmable>` or `<EnableTrimAnalyzer>` with netstandard meant that it was easy for library authors to opt into trimming, without being alerted about trim incompatibilities. Because the netstandard reference assemblies were not annotated for trimming, there would be no warnings about uses of framework APIs that are incompatible with trimming.

## Recommended action

Avoid setting `<IsTrimmable>` or `<EnableTrimAnalyzer>` for libraries which target netstandard. Also avoid setting `<IsAotCompatible>`, which implies the former settings. Instead, multi-target the library to include the latest `TargetFramework`, and enable `<IsTrimmable>` only for the supported target frameworks. This will run the latest version of the trim analyzer, using trim compatibility annotations from the latest version of the framework.

For example, these settings multi-target to include `net8.0`, and set `<IsTrimmable>` only for this target framework. This logic uses `IsTargetFrameworkCompatible` so that it will apply to any frameworks compatible with `net6.0`, when trimming was first officially supported. This way, the condition doesn't need to be updated when adding new target frameworks.

```xml
<PropertyGroup>
  <TargetFrameworks>netstandard2.1;net8.0</TargetFrameworks>
  <IsTrimmable Condition="$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net6.0'))">true</IsTrimmable>
</PropertyGroup>
```

## See also

- [Prepare .NET libraries for trimming](../../../deploying/trimming/prepare-libraries-for-trimming.md)
