---
title: "Breaking change: .NET tool packaging may create RuntimeIdentifier-specific tool packages"
description: "Learn about the breaking change in the .NET 10 SDK where .NET tool packaging may use RuntimeIdentifiers to create platform-specific tools"
ms.date: 08/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47916
---

# .NET tool packaging invokes Publish instead of Build

The .NET tool packaging process changed when `RuntimeIdentifiers` are present in the project.
Since the SDK now supports creating [platform-specific tools](https://github.com/dotnet/core/blob/main/release-notes/10.0/preview/preview6/sdk.md#platform-specific-net-tools), `RuntimeIdentifiers` are used to determine the set of platforms for which to create tool packages.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously when you ran `dotnet pack` on a project with `PackAsTool` set to `true`, it ignored any `RuntimeIdentifiers`.

## New behavior

Starting in .NET 10, `RuntimeIdentifiers` are used to determine the set of platforms for which to create tool packages.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change enables the creation of optimized, platform-specific .NET Tool packages, and supports use cases like:

- Self-contained tools.
- Trimmed and AOT tools.
- Tools that can eventually be used on platforms without an SDK or runtime installed.

## Recommended action

If you would like to create tools for only a subset of platforms, use `ToolPackageRuntimeIdentifiers`. If you would like to disable RID-specific tool packages entirely, you should conditionally include or exclude the `RuntimeIdentifiers` property in your project file.

## Affected APIs

None.
