---
title: "Breaking change: .NET Tool packaging now invokes Publish instead of Build"
description: "Learn about the breaking change in .NET 10 where .NET Tool packaging changed from invoking Build to Publish, affecting included assets."
ms.date: 08/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47916
---

# .NET Tool packaging now invokes Publish instead of Build

In .NET 10 Preview 6, the .NET Tool packaging process changed from invoking the `Build` target to the `Publish` target. This change enables optimized, platform-specific .NET Tool packages but affects which assets are included in the package.

## Version introduced

.NET 10 Preview 6

## Previous behavior

When you ran `dotnet pack` on a project with `PackAsTool` set to `true`, it invoked the `Build` target, causing only `Build`-time-created assets to be included in the package.

## New behavior

The tool packaging process now invokes the `Publish` target, which means `Publish`-created assets are included in the package. This includes:

- StaticWebAssets (from WebSDK)
- Minified and trimmed application assets
- Other publish-time optimizations

Users who previously copied these files explicitly may receive build diagnostics warning them of duplicate copies.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change enables the creation of optimized, platform-specific .NET Tool packages, supporting use cases like:

- Self-contained tools
- Trimmed and AOT tools
- Tools that can eventually be used on platforms without an SDK or Runtime installed

## Recommended action

Remove any explicit file copy customizations that you had in projects affected by this change. The assets that you were previously copying manually are now included automatically through the `Publish` process.

If you need to exclude specific assets that are now being included, you can customize the publish process by modifying your project file or using MSBuild properties to control which assets are included.

## Affected APIs

None.
