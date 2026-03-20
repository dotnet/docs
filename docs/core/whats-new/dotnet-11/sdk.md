---
title: What's new in the SDK and tooling for .NET 11
description: Learn about the new .NET SDK features introduced in .NET 11.
titleSuffix: ""
ms.date: 03/10/2026
ai-usage: ai-assisted
ms.update-cycle: 3650-days
---

# What's new in the SDK and tooling for .NET 11

This article describes new features and enhancements in the .NET SDK for .NET 11. It was last updated for Preview 2.

## Smaller SDK installers on Linux and macOS

The .NET SDK installer size on Linux and macOS has been reduced by deduplicating assemblies using symbolic links. Duplicate `.dll` and `.exe` files are identified by content hash and replaced with symbolic links pointing to a single copy. This affects tarballs, `.pkg`, `.deb`, and `.rpm` installers.

Analysis found that 35% of the SDK directory consists of duplicate files. On Linux x64, that's 816 files totaling 140 MB on disk (53 MB compressed). By replacing duplicates with symbolic links, the Linux x64 archive drops significantly in size:

| Platform | SDK artifact | .NET 10 size (MB) | .NET 11 Preview 2 size (MB) | Reduction |
|---|---|---|---|---|
| linux-x64 | tarball | 230 | 189 | 17.8% |
| linux-x64 | deb | 164 | 122 | 25.6% |
| linux-x64 | rpm | 165 | 122 | 26.0% |
| linux-x64 | containers | Varies | Varies | 8–17% |

Windows deduplication is planned for a future preview.

## Code analyzer improvements

### CA1873: Reduced noise and improved messages

Two improvements were made to [CA1873](../../../fundamentals/code-analysis/quality-rules/ca1873.md) (Avoid potentially expensive logging):

**Reduced false positives:** Property accesses, `GetType()`, `GetHashCode()`, and `GetTimestamp()` calls are no longer flagged. Diagnostics now apply only to Information-level logging and below by default, since warning, error, and critical code paths are rarely hot paths.

**Specific reasons in diagnostic messages:** The diagnostic message now includes why an argument was flagged, helping you prioritize which warnings to address:

```text
// Before
warning CA1873: Evaluation of this argument may be expensive and unnecessary if logging is disabled

// After
warning CA1873: Evaluation of this argument may be expensive and unnecessary if logging is disabled (method invocation)
```

The nine specific reasons are:

- Method invocation
- Object creation
- Array creation
- Boxing conversion
- String interpolation
- Collection expression
- Anonymous object creation
- Await expression
- With expression

### Analyzer bug fixes

| Analyzer | Fix |
|----------|-----|
| [CA1515](../../../fundamentals/code-analysis/quality-rules/ca1515.md) | Fixed false positive when C# extension members are present |
| [CA1034](../../../fundamentals/code-analysis/quality-rules/ca1034.md) | Fixed false positive when C# extension members are present |
| [CA1859](../../../fundamentals/code-analysis/quality-rules/ca1859.md) | Fixed improper handling of default interface implementations |

### AnalysisLevel corrected for .NET 11

Projects with `AnalysisLevel=latest` were incorrectly using .NET 9 analyzer rules instead of the expected .NET 11 rules. This is now fixed.

## New SDK warnings

### NETSDK1235: Custom .nuspec with PackAsTool

A new warning is emitted when a project sets `PackAsTool=true` and specifies a custom `NuspecFile` property. Tool packages require specific layout and identifier conventions that custom `.nuspec` files typically violate:

```text
warning NETSDK1235: .NET Tools do not support using a custom .nuspec file, but the nuspec file 'custom.nuspec' was provided. Remove the NuspecFile property from this project to enable packing it as a .NET Tool.
```

The pack operation still proceeds with a warning to avoid breaking existing projects.

## Breaking changes

.NET 11 includes the following breaking change in the SDK:

### Mono launch target no longer set automatically

Starting in .NET 11, the .NET SDK no longer automatically sets `mono` as the launch target for .NET Framework apps on Linux. If you rely on Mono for execution, update your launch configuration to specify `mono` explicitly.

For more information, see [Mono launch target no longer set automatically](../../compatibility/sdk/11/mono-launch-target-removed.md).

## See also

- [What's new in the .NET 11 runtime](runtime.md)
- [What's new in .NET libraries for .NET 11](libraries.md)
- [Breaking changes in .NET 11](../../compatibility/11.md)
