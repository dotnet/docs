---
title: "Breaking change - Incorrect usage of DynamicResource causes application crash"
description: "Learn about the breaking change in .NET 10 where incorrect usage of DynamicResource now causes application crashes."
ms.date: 5/12/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46089
---

# Incorrect usage of DynamicResource causes application crash

Beginning with .NET 10 Preview 4, applications using `DynamicResource` incorrectly now crash at runtime.

## Version introduced

.NET 10 Preview 4

## Previous behavior

Applications that incorrectly initialized `DynamicResource` would continue running without crashing. The values would fall back to defaults, and an `InvalidOperationException` would appear in the output.

## New behavior

Applications now crash with an error similar to the following:

```output
System.Windows.Markup.XamlParseException: Set property 'System.Windows.ResourceDictionary.Source' threw an exception.
```

This occurs when an incorrect resource type is used with `DynamicResource`. For example, the code snippet below causes a crash because a `SolidColorBrush` is used instead of `System.Windows.Media.Color`:

```xml
<SolidColorBrush x:Key="RedColorBrush" Color="#FFFF0000" />
<SolidColorBrush x:Key="ResourceName" Color="{DynamicResource RedColorBrush}" />
```

## Type of breaking change

This is both a [source-incompatible](../../categories.md#source-compatibility) and [behavioral](../../categories.md#behavioral-change) change.

## Reason for change

This change improves the performance of `DynamicResource` usage. The optimization ensures that incorrect resource initialization is caught immediately, preventing unintended behavior.

## Recommended action

To avoid crashes, ensure that the correct resource types are used with `DynamicResource`. For example, the following code resolves the issue by using `System.Windows.Media.Color` instead of `SolidColorBrush`:

```xml
<Color x:Key="RedColor">#FFFF0000</Color>
<SolidColorBrush x:Key="ResourceName" Color="{DynamicResource RedColor}" />
```

## Affected APIs

None.
