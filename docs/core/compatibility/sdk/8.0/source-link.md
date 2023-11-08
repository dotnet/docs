---
title: "Breaking change: Source Link included in the .NET SDK"
description: Learn about a breaking change in the .NET 8 SDK where Source Link is included, and commit information is included in InformationalVersion.
ms.date: 11/08/2023
---
# Source Link included in the .NET SDK

The [Source Link](https://github.com/dotnet/sourcelink) build tooling is now included in the .NET SDK. Source Link enables packages and applications to embed information about the source control information of the built artifacts. As a side effect, commit information is included in the `InformationalVersion` value of built libraries and applications.

## Previous behavior

Prior to this change, the default `InformationalVersion` of a library or application was the `Version` property.

## New behavior

Starting in .NET 8, the default `InformationalVersion` of a library or application is the `Version` property *and* the `SourceRevisionId` property.

## Version introduced

.NET 8 Preview 4

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Source Link enables rich editor tooling, like go-to-definition support for non-local source files. This benefit is worth including by default for all artifacts.

## Recommended action

If your build process or code doesn't expect Source Revision information in `InformationalVersion`, you can disable the new behavior by setting the `IncludeSourceRevisionInInformationalVersion` property to `false` in your project file.
