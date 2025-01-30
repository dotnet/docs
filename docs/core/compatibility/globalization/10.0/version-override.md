---
title: "Breaking change: Environment variable renamed to DOTNET_ICU_VERSION_OVERRIDE"
description: Learn about the .NET 10 breaking change in core .NET libraries where the environment variable CLR_ICU_VERSION_OVERRIDE was renamed to DOTNET_ICU_VERSION_OVERRIDE.
ms.date: 01/30/2025
---
# Environment variable renamed to DOTNET_ICU_VERSION_OVERRIDE

.NET has previously supported a configuration switch environment variable called `CLR_ICU_VERSION_OVERRIDE`, which allows users to specify the preferred ICU library version for apps running on Linux. In .NET 10, this environment variable has been renamed to `DOTNET_ICU_VERSION_OVERRIDE` to align with the naming convention of other configuration switch environment variables in .NET.

## Previous behavior

The `CLR_ICU_VERSION_OVERRIDE` environment variable is used to specify the preferred ICU version to be loaded in the application.

## New behavior

The `DOTNET_ICU_VERSION_OVERRIDE` environment variable is used to specify the preferred ICU version to be loaded in the application.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change ensures the environment variable is consistent with the naming convention used for all .NET environment variables.

## Recommended action

Users running .NET 10 apps who previously used the `CLR_ICU_VERSION_OVERRIDE` environment variable will now need to use `DOTNET_ICU_VERSION_OVERRIDE` instead.
