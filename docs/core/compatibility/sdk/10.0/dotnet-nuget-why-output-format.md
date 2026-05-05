---
title: "Breaking change: `dotnet nuget why` output format changed"
description: "Learn about the breaking change in .NET 10.0.400 SDK where `dotnet nuget why` changed its output format to show both requested and resolved package versions."
ms.date: 05/05/2026
ai-usage: ai-assisted
---

# `dotnet nuget why` output format changed

The [`dotnet nuget why`](../../../tools/dotnet-nuget-why.md) command changed its package version output format to include both the requested version constraint and the resolved version.

## Version introduced

.NET 10.0.400 SDK

## Previous behavior

Previously, `dotnet nuget why` displayed each package in the dependency graph using only the resolved version, in the format `<PackageName> (v<ResolvedVersion>)`.

For example:

```output
System.Text.Json (v9.0.0-rc.2.24427.10)
```

## New behavior

Starting in .NET 10.0.400 SDK, `dotnet nuget why` displays each package using the resolved version and the minimum requested version constraint, in the format `<PackageName>@<ResolvedVersion> (>= <RequestedVersion>)`.

For example:

```output
System.Text.Json@10.0.1 (>= 9.0.0)
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To help you investigate why a transitive package resolves to a particular version, the output now shows both the version that each dependent package requested and the version that NuGet actually resolved. This information makes it easier to understand version conflicts and dependency requirements.

## Recommended action

If you use a regular expression or other string parsing to process the output of `dotnet nuget why`, update your parsing logic to handle the new format `<PackageName>@<ResolvedVersion> (>= <RequestedVersion>)`.

If some team members or CI agents might run older versions of the .NET SDK, update the parsing logic to support both formats:

- Old format: `<PackageName> (v<ResolvedVersion>)`
- New format: `<PackageName>@<ResolvedVersion> (>= <RequestedVersion>)`

## Affected APIs

None.
