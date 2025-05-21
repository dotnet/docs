---
title: "Breaking change: All assemblies trimmed by default"
description: Learn about the .NET 7 breaking change in deployment where all assemblies in a console app are trimmed by default.
ms.date: 07/28/2022
ms.topic: concept-article
---
# All assemblies trimmed by default

Trimming now trims all assemblies in console apps, by default. This change only affects apps that are published with `PublishTrimmed=true`, and it only breaks apps that had existing trim warnings. It also only affects plain .NET apps that don't use the Windows Desktop, Android, iOS, WASM, or ASP.NET SDK.

## Previous behavior

Previously, only assemblies that were opted-in with `<IsTrimmable>true</IsTrimmable>` in the library project file were trimmed.

## New behavior

Starting in .NET 7, trimming trims all the assemblies in the app by default. Apps that may have previously worked with `PublishTrimmed` may not work in .NET 7. However, only apps with trim warnings will be affected. If your app has no trim warnings, the change in behavior should not cause any adverse effects, and will likely decrease the app size.

If your app did have trim warnings, you may see changes in behavior or exceptions. For example, an app that uses `Newtonsoft.Json` or `System.Text.Json` without source generation to serialize and deserialize a type in the user project may have functioned before the change, because types in the user project were fully preserved. However, one or more trim warnings (warning codes `ILxxxx`) would have been present. Now, types in the user project are trimmed, and serialization may fail or produce unexpected results.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change helps to decrease app size without users having to explicitly opt in and aligns with user expectations that the entire app is trimmed unless noted otherwise.

## Recommended action

The best resolution is to resolve all the trim warnings in your application. For information about resolving the warnings in your own libraries, see [Introduction to trim warnings](../../../deploying/trimming/fixing-warnings.md). For other libraries, contact the author to request that they resolve the warnings, or choose a different library that already supports trimming. For example, you can switch to <xref:System.Text.Json?displayProperty=fullName> with [source generation](../../../../standard/serialization/system-text-json/source-generation.md), which supports trimming, instead of `Newtonsoft.Json`.

To revert to the previous behavior, set the `TrimMode` property to `partial`, which is the pre-.NET 7 behavior.

```xml
<TrimMode>partial</TrimMode>
```

The default .NET 7+ value is `full`:

```xml
<TrimMode>full</TrimMode>
```

## Affected APIs

None.

## See also

- [Trimming options](../../../deploying/trimming/trimming-options.md)
