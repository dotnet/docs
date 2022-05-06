---
title: "Breaking change: Serialization of custom types in .NET 7"
description: Learn about a breaking change in MSBuild for .NET 7 where serialization using BinaryFormatter of certain user-defined types is removed.
author: baronfel
ms.date: 05/06/2022
---

# BinaryFormatter serialization of custom BuildEventArgs and ITaskItems removed for .NET 7

MSBuild in .NET 7 doesn't support serialization of custom BuildEventArgs and ITaskItems via the BinaryFormatter serializer.

## Version Introduced

MSBuild 17.4 (.NET SDK 7.0.100)

## Old Behavior

MSBuild used BinaryFormatter via the `TranslateDotNet` method to translate custom BuildEventArgs and ITaskItems that users could define in their own Tasks.

## New Behavior

MSBuild will no longer support this mechanism, so code that used `TranslateDotNet` will fail to compile.

## Reason for change

BinaryFormatter was [obsoleted in .NET 5](https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md). Per this plan, all first-party dotnet org code bases must migrate away from its use by .NET 7. This change specifically impacts user-exposed functionality of MSBuild, which is why this breaking change notice is separate from the original deprecation notice.

## Recommended action

* Engage with the MSBuild team on [this GitHub discussion](https://github.com/dotnet/msbuild/discussions/7582) about your specific use cases and how you can migrate away from the `TranslateDotNet` mechanism.

* Update your Tasks to use a different serialization mechanism.
