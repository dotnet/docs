---
title: "Breaking change: 'dotnet tool install --local' creates manifest by default"
description: "Learn about the breaking change where 'dotnet tool install --local' now creates a manifest by default if no tools manifest is found."
ms.date: 08/27/2025
ai-usage: ai-generated
---

# dotnet tool install --local creates manifest by default

When running [`dotnet tool install --local`](../../../tools/dotnet-tool-install.md), a manifest is now created if none exists instead of failing with an error. This change was implemented by making the [`--create-manifest-if-needed` option](../../../tools/dotnet-tool-install.md#options) enabled by default. This is a breaking change, since users might have relied on the failure behavior to check if they needed to create a manifest.

The `-d` flag on `dotnet tool install` was previously added to show a user the locations that were searched for manifests. This information was relayed in the error given when there was no manifest. That error is no longer shown since a manifest is now created if necessary. Also, the flag never worked properly.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, if you tried to install a .NET tool as a local tool in a folder that didn't contain a manifest, you got an error:

> Cannot find a manifest file.

## New behavior

Starting in .NET 10, the `--create-manifest-if-needed=true` functionality is now enabled by default. When a tool is installed as a local tool, the manifest is created automatically if it doesn't exist. The manifest is created according to the rules defined under the [`--create-manifest-if-needed` option documentation](../../../tools/dotnet-tool-install.md#options).

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change improves the user experience by making `dotnet tool install --local` work by default without requiring users to manually create a manifest first. Previously, the concern was about creating a manifest in a working directory rather than the repository root, but the tool now tries to put the manifest in the repository root when possible.

## Recommended action

You can turn off the automatic manifest creation behavior by passing `--create-manifest-if-needed=false` when calling `dotnet tool install --local`.

## Affected APIs

N/A

## See also

- [dotnet tool install](../../../tools/dotnet-tool-install.md)
