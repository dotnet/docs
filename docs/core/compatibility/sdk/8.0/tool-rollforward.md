---
title: "Breaking change: .NET tool roll-forward behavior"
description: Learn about a breaking change in the .NET 8 SDK where the default roll-forward behavior for .NET tools changed from 'latestPatch' to 'major'.
ms.date: 06/06/2023
---
# .NET tool roll-forward behavior

We changed the default [roll-forward behavior](../../../tools/global-json.md#rollforward) for [.NET tools](../../../tools/global-tools.md) from `latestPatch` to `major`.

## Previous behavior

Previously, .NET tools had the same default roll-forward behavior as all other .NET apps, which is `latestPatch`. `latestPatch` allows an application to run on any runtime of the same major and minor version that's at least as high as the version that the application was built against.

## New behavior

Starting in .NET 8, .NET tools have a default roll-forward behavior of `major`. This change allows .NET tools to run on any .NET runtime version that's greater than or equal to the version the app was built against, including a higher major version. This change only affects tools that are rebuilt in .NET 8.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

A .NET (local) tool is a specific kind of .NET application that's intended to be distributed and managed via SDK commands. .NET tools are usually development tools and utilities. The semantics of tools are such that tools should be able to run on *any* .NET runtime equal to or greater than the runtime the application originally targeted. Previously, tool authors had to either explicitly set a more flexible roll-forward policy or target multiple versions, such as .NET 6 and .NET 7.

## Recommended action

If this change is undesirable, you can explicitly set the roll-forward policy to `latestPatch` in the [global.json](../../../tools/global-json.md) file.

## See also

- [rollForward](../../../tools/global-json.md#rollforward)
