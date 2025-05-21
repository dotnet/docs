---
title: "Breaking change - MSBuild custom culture resource handling"
description: "Learn about the breaking change in MSBuild 17.14 where custom culture resource handling now requires explicit opt-in."
ms.date: 3/26/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45501
ms.topic: how-to
---

# MSBuild custom culture resource handling

Starting in MSBuild 17.14, custom culture resource handling is no longer enabled by default. Users must explicitly opt in to enable this feature. This change prevents unintended behavior caused by automatic detection of directories resembling culture codes.

## Version introduced

MSBuild 17.14

> [!NOTE]
> As this change affects the behavior of MSBuild, it affects two supported versions of .NET: .NET 10 Preview 1 and .NET 9.0.2. The transparent support for custom culture change was introduced in .NET SDK 9.0.200 and the change making it opt-in is in .NET SDK 9.0.300.

## Previous behavior

MSBuild previously treated directories with names resembling culture codes (for example, `en-US`, `fr-FR`) as culture-specific resource directories by default. This behavior sometimes included unrelated directories, such as those with hash-based or technical names, leading to unintended resource assemblies in the build process.

## New behavior

- Custom culture resource handling is disabled by default.
- To enable this feature, set the project property `EnableCustomCulture` to `true`.
- Use the `CustomCultureExcludeDirectories` property to specify a semicolon-delimited list of directory names to exclude from custom culture processing.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The automatic detection of culture-specific resource directories caused unpredictable build behavior when directory names coincidentally matched culture codes. Requiring explicit opt-in ensures more predictable builds and gives users greater control over resource handling.

## Recommended action

If your build process relies on custom culture resource handling:

1. Set the project property `EnableCustomCulture` to `true`.
2. Optionally use the `CustomCultureExcludeDirectories` property to exclude specific directories from being treated as culture resources.

## Affected APIs

None.
