---
title: "Breaking change: PublishDepsFilePath behavior change"
description: Learn about the breaking change in .NET 5 where the PublishDepsFilePath MSBuild property is empty for single-file applications.
ms.date: 09/17/2020
---
# PublishDepsFilePath behavior change

The `PublishDepsFilePath` MSBuild property is empty for single-file applications. Additionally, for non single-file applications, the *deps.json* file may not be copied to the output directory until later in the build.

## Version introduced

5.0

## Change description

In previous .NET versions, the `PublishDepsFilePath` MSBuild property is the path to the app's *deps.json* file in the output directory for non single-file applications, and a path in the intermediate directory for single-file apps.

Starting in .NET 5, `PublishDepsFilePath` is empty for single-file applications and a new `IntermediateDepsFilePath` property specifies the *deps.json* location in the intermediate directory. Additionally, for non single-file applications, the *deps.json* file may not be copied to the output directory (that is, the path specified by `PublishDepsFilePath`) until later in the build.

## Reason for change

This change was made for a couple of reasons:

- Due to a refactoring of the publish logic in order to support [improved single-file apps](https://github.com/dotnet/designs/blob/main/accepted/2020/single-file/design.md) in .NET 5.

- In single-file apps, to help guard against targets that try to rewrite the *deps.json* file after *deps.json* has already been bundled, thus silently not affecting the app. For this reason, `PublishDepsFilePath` is empty for single-file applications.

## Recommended action

Targets that rewrite the *deps.json* file should generally do so using the `IntermediateDepsFilePath` property.

## Affected APIs

N/A

<!--

### Affected APIs

Not detectable via API analysis.

### Category

MSBuild

-->
