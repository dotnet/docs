---
title: "Breaking change - WPF throws MC3063 error for empty ColumnDefinitions or RowDefinitions"
description: "Learn about the breaking change in .NET 10 where empty Grid.ColumnDefinitions or Grid.RowDefinitions declarations now cause MC3063 compilation errors."
ms.date: 01/27/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/47743
---

# WPF throws MC3063 error for empty ColumnDefinitions or RowDefinitions

Starting with .NET 10 Preview 5, WPF applications fail to build if `<Grid.ColumnDefinitions>` or `<Grid.RowDefinitions>` are declared but left empty in XAML. This results in error **MC3063**, indicating that the property doesn't have a value.

## Version introduced

.NET 10 Preview 5

## Previous behavior

WPF applications with empty `<Grid.ColumnDefinitions>` or `<Grid.RowDefinitions>` compiled successfully, even though the layout definitions were incomplete. WPF would default to a single row and column, placing all child elements in that single cell unless otherwise specified.

Example that previously compiled:

```xml
<Grid>
  <Grid.ColumnDefinitions>
  </Grid.ColumnDefinitions>
  <Grid.RowDefinitions>
  </Grid.RowDefinitions>
  <TextBlock Text="Hello World" />
</Grid>
```

## New behavior

The same code now fails to compile with the following error:

```output
error MC3063: Property 'ColumnDefinitions' does not have a value.
error MC3063: Property 'RowDefinitions' does not have a value.
```

This occurs when `<Grid.ColumnDefinitions>` or `<Grid.RowDefinitions>` elements are declared but contain no child `<ColumnDefinition />` or `<RowDefinition />` elements.

## Type of breaking change

This is a [source-incompatible](../../categories.md#source-compatibility) change.

## Reason for change

This change is a direct consequence of implementing Grid XAML Shorthand Syntax support. The enhancement improves XAML parsing by being more strict about property declarations that don't contain meaningful content.

## Recommended action

Choose one of the following approaches to resolve the compilation error:

### Option 1: Remove empty declarations

Remove the empty `<Grid.ColumnDefinitions>` and `<Grid.RowDefinitions>` elements entirely:

```xml
<Grid>
  <TextBlock Text="Hello World" />
</Grid>
```

### Option 2: Add actual definitions

If you need specific column or row definitions, add the appropriate `<ColumnDefinition />` or `<RowDefinition />` elements:

```xml
<Grid>
  <Grid.ColumnDefinitions>
    <ColumnDefinition />
  </Grid.ColumnDefinitions>
  <Grid.RowDefinitions>
    <RowDefinition />
  </Grid.RowDefinitions>
  <TextBlock Text="Hello World" />
</Grid>
```

## Affected APIs

None.
