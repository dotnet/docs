---
title: "Breaking change: .NET tool packaging invokes Publish instead of Build"
description: "Learn about the breaking change in the .NET 10 SDK where .NET tool packaging changed from invoking Build to Publish, affecting included assets."
ms.date: 08/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47916
---

# .NET tool packaging invokes Publish instead of Build

The .NET tool packaging process changed from invoking the MSBuild `Build` target to the `Publish` target (logically, not precisely). This means that assets that are included in `Publish` but not in `Build`, like WebSDK StaticWebAssets, now appear in tool packages by default. If you explicitly copied those files into place, you might begin to receive build diagnostics warning of duplicate copies.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously when you ran `dotnet pack` on a project with `PackAsTool` set to `true`, it invoked the `Build` target, and only `Build`-created assets were included in the package.

## New behavior

Starting in .NET 10, the tool packaging process invokes the `Publish` target, which means `Publish`-created assets are included in the package. This includes StaticWebAssets and minified and trimmed application assets.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change enables the creation of optimized, platform-specific .NET Tool packages, and supports use cases like:

- Self-contained tools.
- Trimmed and AOT tools.
- Tools that can eventually be used on platforms without an SDK or runtime installed.

## Recommended action

If your project is impacted, remove any explicit file copy customizations.

## Affected APIs

None.
