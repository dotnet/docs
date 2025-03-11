---
title: "Breaking change: Environment variable renamed to DOTNET_ICU_VERSION_OVERRIDE"
description: Learn about the .NET 10 breaking change in globalization where the environment variable CLR_ICU_VERSION_OVERRIDE was renamed to DOTNET_ICU_VERSION_OVERRIDE.
ms.date: 01/30/2025
ai-usage: ai-assisted
---

# Environment variable renamed to DOTNET_ICU_VERSION_OVERRIDE

.NET previously supported a configuration-switch environment variable called `CLR_ICU_VERSION_OVERRIDE`, which allowed users to specify the preferred ICU library version for apps running on Linux. In .NET 10, this environment variable has been renamed to `DOTNET_ICU_VERSION_OVERRIDE` to align with the naming convention of other configuration switch environment variables in .NET.

## Previous behavior

The `CLR_ICU_VERSION_OVERRIDE` environment variable was used to specify the preferred ICU version to be loaded in the application.

## New behavior

The `DOTNET_ICU_VERSION_OVERRIDE` environment variable is used to specify the preferred ICU version to be loaded in the application.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change ensures the environment variable is consistent with the naming convention used for all [.NET environment variables](../../../tools/dotnet-environment-variables.md).

## Recommended action

If you have a .NET 10 app that previously used the `CLR_ICU_VERSION_OVERRIDE` environment variable, use `DOTNET_ICU_VERSION_OVERRIDE` instead.

## Affected APIs

N/A
