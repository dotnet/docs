---
title: "Breaking change: Unlisted packages not installed by default"
description: Learn about a breaking change in the .NET 8 SDK where `dotnet tool install` no longer installs tools from unlisted versions of NuGet packages.
ms.date: 11/07/2023
---
# Unlisted packages not installed by default

The [dotnet tool install](../../../tools/dotnet-tool-install.md) commands no longer install tools from [unlisted versions](/nuget/nuget-org/policies/deleting-packages#unlisting-a-package) of NuGet packages by default. You can still force the install by specifying the unlisted version as an exact version surrounded with brackets, for example `--version [5.0.0]`.

## Previous behavior

Previously, when you installed a .NET tool, the .NET SDK installed tools (and versions of tools) without considering whether the tool package was unlisted.

## New behavior

Starting in .NET 8, unlisted tool versions aren't installed unless you specify the exact version using the `--version` option and brackets around the version number. For example, `--version [5.0.0]`.

## Version introduced

.NET 8 GA

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The correct default behavior is to ignore [unlisted packages](/nuget/nuget-org/policies/deleting-packages#unlisting-a-package) when installing tools. Unlisted versions are purposefully hidden from search on NuGet.org.

## Recommended action

To install an unlisted tool, specify the exact version of the tool surrounded with brackets, for example `--version [5.0.0]`.
