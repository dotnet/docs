---
title: "Breaking change: DefaultValueAttribute removed from some properties"
description: Learn about the breaking change in .NET 8 for Windows Forms where DefaultValueAttribute was removed from properties whose default values must be dynamically calculated.
ms.date: 03/13/2023
---
# DefaultValueAttribute removed from some properties

<xref:System.ComponentModel.DefaultValueAttribute> has been removed from control properties that are dependent on the default font height.

## Version introduced

.NET 8

## Previous behavior

The affected properties were decorated with <xref:System.ComponentModel.DefaultValueAttribute>, and default values were hardcoded according to an assumed application-wide font.

## New behavior

Starting in .NET 8, the attribute is removed from certain properties. Design-time default values are calculated at startup based on the current font metrics.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

The <xref:System.ComponentModel.DefaultValueAttribute> attribute is designed to define constant default values used by the Windows Forms designer. In the past, this attribute was used to specify defaults on certain properties that depend on the current font height. A new default font was introduced in .NET Core 3.1, but the attribute values weren't updated accordingly. Moreover, there's now an API to modify application font. Thus, it makes sense to use dynamic default values instead of constant ones.

The designer provides methods to specify dynamic default values, however, for properties decorated with <xref:System.ComponentModel.DefaultValueAttribute>, it always uses the constant default value instead. The methods for specifying dynamic defaults preserve the design-time functionality provided by the attribute.

## Recommended action

<xref:System.ComponentModel.DefaultValueAttribute> is intended for internal use in design-time scenarios. You shouldn't use it in other scenarios.

## Affected APIs

The following table lists the affected properties.

| Property | Change version |
|-|-|-|
| <xref:System.Windows.Forms.DataGridViewRow.Height?displayProperty=fullName> | Preview 2 |
| <xref:System.Windows.Forms.ListBox.ItemHeight?displayProperty=fullName> | Preview 2 |
