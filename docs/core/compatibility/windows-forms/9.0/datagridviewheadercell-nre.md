---
title: "Breaking change: No exception if DataGridView is null"
description: Learn about the breaking change in .NET 9 for Windows Forms where DataGridViewHeaderCell methods no longer throw an exception if the DataGridView property is null.
ms.date: 01/16/2024
ms.topic: concept-article
---
# No exception if DataGridView is null

Previously, a <xref:System.NullReferenceException> was thrown in <xref:System.Windows.Forms.DataGridViewHeaderCell.MouseDownUnsharesRow(System.Windows.Forms.DataGridViewCellMouseEventArgs)?displayProperty=nameWithType>, <xref:System.Windows.Forms.DataGridViewHeaderCell.MouseEnterUnsharesRow(System.Int32)?displayProperty=nameWithType>, <xref:System.Windows.Forms.DataGridViewHeaderCell.MouseLeaveUnsharesRow(System.Int32)?displayProperty=nameWithType>, and <xref:System.Windows.Forms.DataGridViewHeaderCell.MouseUpUnsharesRow(System.Windows.Forms.DataGridViewCellMouseEventArgs)?displayProperty=nameWithType> if the <xref:System.Windows.Forms.DataGridViewElement.DataGridView> property was null. That behavior was unexpected and incorrect. These methods have been updated to simply return `false` if `DataGridView` is `null`.

## Version introduced

.NET 9 Preview 1

## Previous behavior

Previously, the [affected methods](#affected-apis) threw a <xref:System.NullReferenceException> when `DataGridViewHeaderCell.DataGridView` was `null`.

## New behavior

Starting in .NET 9, the [affected methods](#affected-apis) return `false` if the `DataGridViewHeaderCell.DataGridView` property is `null`

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was incorrect.

## Recommended action

If you were relying on the code to throw a <xref:System.NullReferenceException> in this scenario, change your code to check the return value instead.

## Affected APIs

- <xref:System.Windows.Forms.DataGridViewHeaderCell.MouseDownUnsharesRow(System.Windows.Forms.DataGridViewCellMouseEventArgs)?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGridViewHeaderCell.MouseEnterUnsharesRow(System.Int32)?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGridViewHeaderCell.MouseLeaveUnsharesRow(System.Int32)?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGridViewHeaderCell.MouseUpUnsharesRow(System.Windows.Forms.DataGridViewCellMouseEventArgs)?displayProperty=fullName>
