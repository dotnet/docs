---
title: "Breaking change: Deprecation of `TrimmerDefaultAction` property"
description: Learn about the .NET 7 breaking change in deployment where the `TrimmerDefaultAction` property is being deprecated.
ms.date: 09/20/2022
---
# MSBuild property `TrimmerDefaultAction` is deprecated

The value of the property `TrimmerDefaultAction` is going to be ignored by the publish process.

## Previous behavior

Previously, only assemblies that were opted-in with `<IsTrimmable>true</IsTrimmable>` in the library project file were trimmed with the action specified by the `TrimmerDefaultAction`. The default value for that property was `link` in .NET 6.

## New behavior

Starting in .NET 7, the property `TrimmerDefaultAction` is ignored and publishing behaves as if it was set to `link` all the time.

Since the default value for the property was already set to the most aggressive mode `link`, setting it explicitly in a project file would typically try to reduce the aggressiveness of trimming. The most common setting was `copyused`. This means the setting affected almost always apps which produced trim warnings.

If your app did have trim warnings, you may see changes in behavior or exceptions.

## Version introduced

.NET 7 Preview 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change streamlines trimming options.

## Recommended action

The best resolution is to resolve all the trim warnings in your application. For information about resolving the warnings in your own libraries, see [Introduction to trim warnings](../../../deploying/trimming/fixing-warnings.md). For other libraries, contact the author to request that they resolve the warnings, or choose a different library that already supports trimming. For example, you can switch to <xref:System.Text.Json?displayProperty=fullName> with [source generation](../../../../standard/serialization/system-text-json-source-generation.md), which supports trimming, instead of `Newtonsoft.Json`. With that there should be no need to use `TrimmerDefaultAction` anymore.

To revert to the previous behavior, use [`global.json`](../../../tools/global-json.md) to pin your project to .NET 6 SDK.

## See also

- [Trimming options](../../../deploying/trimming/trimming-options.md)
