---
title: "Breaking change: 'dotnet watch' incompatible with Hot Reload for old frameworks"
description: Learn about a breaking change in the .NET 9 SDK where 'dotnet watch' requires disabling Hot Reload for projects targeting .NET 5 or earlier.
ms.date: 11/08/2024
---
# 'dotnet watch' incompatible with Hot Reload for old frameworks

.NET 9 introduces a change that requires [`dotnet watch`](../../../tools/dotnet-watch.md) to launched with Hot Reload disabled for projects targeting .NET 5 or earlier versions.

## Previous behavior

Previously, [`dotnet watch`](../../../tools/dotnet-watch.md) automatically disabled Hot Reload when used with projects targeting .NET 5 or earlier.

## New behavior

Starting in .NET 9, an error is reported when [`dotnet watch`](../../../tools/dotnet-watch.md) is launched without `--no-hot-reload` for projects targeting .NET 5 or earlier versions. The error is similar to:

> Hot Reload based watching is only supported in .NET 6.0 or newer apps.

## Version introduced

.NET 9 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The internal architecture of the `dotnet watch` tool underwent significant improvements. Preserving behavior for out-of-support .NET versions did not warrant increasing the complexity of the new implementation.

## Recommended action

Pass `--no-hot-reload` to `dotnet watch` on the command line, or update your project to target `net6.0` or later (using the `TargetFramework` property).

## Affected APIs

N/A
