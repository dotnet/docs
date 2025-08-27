---
title: "Breaking change: dotnet tool install --local works by default, by creating a manifest by default"
description: "Learn about the breaking change where dotnet tool install --local now creates a manifest by default using --create-manifest-if-needed behavior."
ms.date: 08/27/2025
ai-usage: ai-generated
---

# dotnet tool install --local works by default, by creating a manifest by default

When running `dotnet tool install --local`, a manifest is now created if one does not exist instead of failing with an error. This was implemented by making `--create-manifest-if-needed` enabled by default.

## Version introduced

.NET 10 Preview 7

## Previous behavior

When a user tried to install a .NET tool as a local tool in a folder that did not contain a manifest, they would get an error: "Cannot find a manifest file."

## New behavior

The `--create-manifest-if-needed` functionality is now enabled by default, so the manifest will be created automatically if it does not exist when a tool is installed as a local tool. The manifest is created according to the following rules:

- Walk up the directory tree searching for a directory that has a `.git` subfolder. If one is found, create the manifest in that directory.
- If the previous step doesn't find a directory, walk up the directory tree searching for a directory that has a `.sln` or `.git` file. If one is found, create the manifest in that directory.
- If neither of the previous two steps finds a directory, create the manifest in the current working directory.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change improves the user experience by making `dotnet tool install --local` work by default without requiring users to manually create a manifest first. Previously, the concern was about creating a manifest in a working directory rather than the repository root, but the tool now tries to put the manifest in the repository root when possible.

## Recommended action

Users can turn off the automatic manifest creation behavior by setting `--create-manifest-if-needed=false` if they prefer the previous behavior where the command would fail when no manifest exists.

## Affected APIs

N/A