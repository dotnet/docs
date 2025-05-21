---
title: "Breaking change: Deprecation of `TrimmerDefaultAction` property"
description: Learn about the .NET 7 breaking change in deployment where the `TrimmerDefaultAction` property is being deprecated.
ms.date: 09/20/2022
ms.topic: concept-article
---
# MSBuild property `TrimmerDefaultAction` is deprecated

The value of the `TrimmerDefaultAction` property is now ignored by the publish process.

## Previous behavior

Previously, only assemblies that were opted-in with `<IsTrimmable>true</IsTrimmable>` in the library project file were trimmed with the action specified by the `TrimmerDefaultAction`. In .NET 6, the default value for that property was `copy`. While apps with trim warnings were more likely to work with this default, run-time behavior could still be affected. In addition, the `copy` action caused apps to be larger than if the entire app was trimmed.

## New behavior

Starting in .NET 7, the property `TrimmerDefaultAction` is ignored and publishing behaves as if it was set to `link` all the time. This means all assemblies are fully trimmed, whether they opt in or not. As a result, applications with trim warnings may see changes in behavior or run-time exceptions. For more information and instructions for restoring the previous behavior, see [All assemblies trimmed by default](./trim-all-assemblies.md).

## Version introduced

.NET 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change streamlines trimming options.

## Recommended action

The best resolution is to resolve all the trim warnings in your application. For information about resolving the warnings in your own libraries, see [Introduction to trim warnings](../../../deploying/trimming/fixing-warnings.md). For other libraries, contact the author to request that they resolve the warnings, or choose a different library that already supports trimming. For example, you can switch to <xref:System.Text.Json?displayProperty=fullName> with [source generation](../../../../standard/serialization/system-text-json/source-generation.md), which supports trimming, instead of `Newtonsoft.Json`. With that library, you should no longer need to use `TrimmerDefaultAction`.

To revert to the previous behavior, use [`global.json`](../../../tools/global-json.md) to pin your project to .NET 6 SDK.

## See also

- [Trimming options](../../../deploying/trimming/trimming-options.md)
- [All assemblies trimmed by default](./trim-all-assemblies.md)
