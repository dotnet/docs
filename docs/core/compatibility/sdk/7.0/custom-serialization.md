---
title: "Breaking change: Serialization of custom types in .NET 7"
description: Learn about a breaking change in MSBuild for .NET 7 where serialization using BinaryFormatter of certain user-defined types is removed.
author: baronfel
ms.date: 05/06/2022
ms.topic: concept-article
---

# BinaryFormatter serialization of custom BuildEventArgs and ITaskItems removed for .NET 7

MSBuild in .NET 7 doesn't support serialization of custom `BuildEventArgs`-derived and `ITaskItem`-derived types via the `BinaryFormatter` serializer.

## Version introduced

MSBuild 17.4 (.NET SDK 7.0.100)

## Old behavior

MSBuild used BinaryFormatter to preserve custom types that derived from BuildEventArgs and ITaskItem across certain boundaries, most notably when running in a multi-process environment.

## New behavior

MSBuild will no longer support this mechanism, so code that used custom types derived from BuildEventArgs and ITaskItem may fail.

## Reason for change

BinaryFormatter was [made obsolete in .NET 5](https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md). Per this plan, all first-party code in the dotnet GitHub organization must migrate away from its use by .NET 7. This change impacts user-exposed functionality of MSBuild.

## Recommended action

* Engage with the MSBuild team on [this GitHub discussion](https://github.com/dotnet/msbuild/discussions/7582) about your specific use cases and how you can migrate away from the `TranslateDotNet` mechanism.

* Avoid returning custom derived types from tasks or when logging.
