---
title: "Breaking change - Empty ColumnDefinitions and RowDefinitions are disallowed"
description: "Learn about the breaking change in WPF in .NET 10 where empty Grid.ColumnDefinitions or Grid.RowDefinitions declarations now cause MC3063 compilation errors."
ms.date: 08/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47743
---

# Empty ColumnDefinitions and RowDefinitions are disallowed

Starting with .NET 10, WPF applications fail to build if `<Grid.ColumnDefinitions>` or `<Grid.RowDefinitions>` are declared but left empty in XAML. This results in error `MC3063`, which indicates that the property doesn't have a value.

## Version introduced

.NET 10 Preview 5

## Previous behavior

Previously, WPF applications with empty `<Grid.ColumnDefinitions>` or `<Grid.RowDefinitions>` compiled successfully, even though the layout definitions were incomplete. The layout defaulted to a single row and column, placing all child elements in that single cell unless otherwise specified.

Example that previously compiled:

```xml
<Grid>
  <Grid.ColumnDefinitions>
  </Grid.ColumnDefinitions>
</Grid>
```

## New behavior

Starting in .NET 10, the same code now fails to compile with the following error:

```output
error MC3063: Property 'ColumnDefinitions' does not have a value.
```

This occurs when `<Grid.ColumnDefinitions>` or `<Grid.RowDefinitions>` elements are declared but contain no child `<ColumnDefinition />` or `<RowDefinition />` elements.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change is a direct consequence of implementing Grid XAML Shorthand Syntax support.

## Recommended action

Ensure that all `<Grid.ColumnDefinitions>` and `<Grid.RowDefinitions>` contains at least one valid or element.

Corrected example:

```xml
<Grid>
  <Grid.ColumnDefinitions>
    <ColumnDefinition />
  </Grid.ColumnDefinitions>
</Grid>
```

## Affected APIs

None.
