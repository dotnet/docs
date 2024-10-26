---
title: "Breaking change: dotnet-watch requires disabling Hot Reload mode for projects targeting .NET 5 or older"
description: Learn about a breaking change in the .NET 9 SDK where dotnet-watch requires disabling Hot Reload for projects targeting .NET 5 or older.
ms.date: 07/09/2024
---
# Error reported for .NET 5 targets or older

## Previous behavior

Previously, `dotnet-watch` automatically disabled Hot Reload when used with projects targeting .NET 5 or older.

## New behavior

An error is reported when dotnet-watch is launched without `--no-hot-reload` on projects targeting .NET 5 or older:

> Hot Reload based watching is only supported in .NET 6.0 or newer apps. 

## Version introduced

.NET 9 RC 1

## Type of breaking change

This change can affect development workflow.

## Reason for change

We have made significant changes in the internal architecture of the tool. Preserving behavior for out of support .NET versions did not warrant increasing complexity of the new implementation.

## Recommended action

Pass `--no-hot-reload` to `dotnet-watch` command line, or update your project to target `net6.0` or higher (`TargetFramework` property).

## Affected APIs

N/A

