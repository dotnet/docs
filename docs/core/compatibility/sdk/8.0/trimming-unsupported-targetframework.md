---
title: "Breaking change: Trimming may not be used with .NET Standard or .NET Framework"
description: Learn about a breaking change in the .NET 8 SDK where trimming settings produce new warnings or errors in .NET Standard or .NET Framework projects.
ms.date: 08/21/2023
---
# Trimming may not be used with .NET standard or .NET framework

Projects that set `<PublishTrimmed>true</PublishTrimmed>`, `<IsTrimmable>true</IsTrimmable>` or `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>` with a `TargetFramework` that is any version of .NET Standard or .NET Framework produce a warning or error because trimming is unsupported for these target frameworks.

## Previous behavior

Previously, when used in a .NET Standard or .NET Framework project, these settings behaved as follows:

- `<PublishTrimmed>true</PublishTrimmed>` would have no effect.
- `<IsTrimmable>true</IsTrimmable>` would embed an assembly-level attribute `[assembly: AssemblyMetadata("IsTrimmable", "true")]` into the output assembly. That attribute opted the assembly into trimming when consumed in a trimmed app (even an app that uses `<TrimMode>partial</TrimMode>`).
- `<EnableTrimAnalyzer>true</EnableTrimAnalyzer>` would enable trim analysis for the library, using the .NET Standard or .NET Framework reference assemblies corresponding to the library's `TargetFramework` even though these reference assemblies aren't annotated for trimming.

## New behavior

Starting in the .NET 8 SDK, in a project targeting .NET Standard or .NET Framework:
- `<PublishTrimmed>` produces an error indicating that this setting is unsupported for the target framework.
- `<IsTrimmable>` or `<EnableTrimAnalyzer>` produce a warning indicating that `<IsTrimmable>` is unsupported for the target framework. These settings otherwise have no effect on the build output.

## Version introduced

.NET 8 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Allowing the use of `<PublishTrimmed>` in a .NET Standard or .NET Framework project might have given the false impression that this setting was trimming the output, when in fact it had no effect.

Allowing the use of `<IsTrimmable>` or `<EnableTrimAnalyzer>` in a .NET Standard or .NET Framework project meant that it was easy for library authors to opt into trimming, without being alerted about trim incompatibilities. Because the .NET Standard and .NET Framework reference assemblies aren't annotated for trimming, there were no warnings about uses of framework APIs that are incompatible with trimming.

## Recommended action

Avoid setting `<PublishTrimmed>` in projects that target .NET Standard or .NET Framework. Also avoid setting `<PublishAot>` which implies the former setting.

Avoid setting `<IsTrimmable>` or `<EnableTrimAnalyzer>` in libraries that target .NET Standard or .NET Framework. Also avoid setting `<IsAotCompatible>`, which implies the former settings. Instead, multi-target the library to include the latest `TargetFramework`, and enable `<IsTrimmable>` only for the supported target frameworks. Setting `<IsTrimmable>` will run the latest version of the trim analyzer using trim-compatibility annotations from the latest version of the framework.

For example, these settings multi-target to include `net8.0`, and set `<IsTrimmable>` only for this target framework. This logic uses `IsTargetFrameworkCompatible` so that it will apply to any frameworks compatible with `net6.0`, when trimming was first officially supported. This way, the condition doesn't need to be updated when adding new target frameworks.

```xml
<PropertyGroup>
  <TargetFrameworks>netstandard2.1;net8.0</TargetFrameworks>
  <IsTrimmable Condition="$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net6.0'))">true</IsTrimmable>
</PropertyGroup>
```

## See also

- [Prepare .NET libraries for trimming](../../../deploying/trimming/prepare-libraries-for-trimming.md)
