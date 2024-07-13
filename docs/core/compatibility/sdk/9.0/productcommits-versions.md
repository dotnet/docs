---
title: "Breaking change: `installer` repo version no longer included in `productcommits` files"
description: Learn about a breaking change in the .NET 9 SDK where the `installer` repo commit and version are no longer included in the `productcommits` files.
ms.date: 07/09/2024
---
# `installer` repo version no longer included in `productcommits` files

The version and commit of a subset of the repos that comprise .NET are available in the *productcommits-rid.txt* and *.json* files. These files can be queried from aka.ms links, for example, <https://aka.ms/dotnet/9.0.1xx/daily/productCommit-win-x64.txt>. The files enable customers to get the version and commit of the `runtime`, `aspnetcore`, `windowsdesktop`, and `sdk` repos included in a given build. Some customers have built tooling around this file to help others update their repos to new versions of .NET as builds are available.

In .NET 9, the `dotnet/installer` repo has been merged into the `dotnet/sdk` repo and builds are now shipped exclusively out of the `dotnet/sdk` repo.

## Previous behavior

Previously, the *productcommits-rid.txt* file included the `installer` repo version.

## New behavior

Starting in .NET 9, the `installer` line has been removed from the *productcommits-rid.txt* file.

## Version introduced

.NET 9 Preview 5

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The `installer` repo was removed to reduce code-flow time and complexity of builds, and to allow the team to build a full SDK out of the `sdk` repo for testing.

## Recommended action

Any tooling that depends on the `productcommit` file should be updated to use the `sdk` version.

## Affected APIs

N/A
