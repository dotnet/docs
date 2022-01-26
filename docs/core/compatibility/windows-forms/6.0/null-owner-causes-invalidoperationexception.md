---
title: ".NET 6 breaking change: DataGridView-related APIs throw InvalidOperationException"
description: Learn about the breaking change in .NET 6 where some APIs related to DataGridView throw an exception if the object's DataGridViewCellAccessibleObject.Owner value is null.
ms.date: 03/29/2021
---
# DataGridView-related APIs now throw InvalidOperationException

Some APIs related to <xref:System.Windows.Forms.DataGridView> now throw an <xref:System.InvalidOperationException> if the object's <xref:System.Windows.Forms.DataGridViewCell.DataGridViewCellAccessibleObject.Owner?displayProperty=nameWithType> value is `null`.

## Change description

In previous .NET versions, the affected APIs throw a <xref:System.NullReferenceException> when they are invoked and the <xref:System.Windows.Forms.DataGridViewCell.DataGridViewCellAccessibleObject.Owner> property value is `null`. Starting in .NET 6, these APIs throw an <xref:System.InvalidOperationException> instead of a <xref:System.NullReferenceException> if the <xref:System.Windows.Forms.DataGridViewCell.DataGridViewCellAccessibleObject.Owner> property value is `null` when they're invoked.

## Change category

This change affects [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Throwing an <xref:System.InvalidOperationException> conforms to the behavior of the .NET runtime. It also improves the debugging experience by clearly communicating the invalid property.

## Version introduced

.NET 6

## Recommended action

Review your code and, if necessary, update it to prevent constructing the affected types with the <xref:System.Windows.Forms.DataGridViewCell.DataGridViewCellAccessibleObject.Owner> property as `null`.

## Affected APIs

The following table lists the affected properties and methods:

- <xref:System.Windows.Forms.DataGridViewTopLeftHeaderCell.DataGridViewTopLeftHeaderCellAccessibleObject.Bounds?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGridViewTopLeftHeaderCell.DataGridViewTopLeftHeaderCellAccessibleObject.DefaultAction?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGridViewTopLeftHeaderCell.DataGridViewTopLeftHeaderCellAccessibleObject.Name?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGridViewTopLeftHeaderCell.DataGridViewTopLeftHeaderCellAccessibleObject.Navigate(System.Windows.Forms.AccessibleNavigation)?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGridViewTopLeftHeaderCell.DataGridViewTopLeftHeaderCellAccessibleObject.State?displayProperty=fullName>

## See also

- [DataGridView-related APIs throw InvalidOperationException (.NET 5)](../5.0/null-owner-causes-invalidoperationexception.md)
