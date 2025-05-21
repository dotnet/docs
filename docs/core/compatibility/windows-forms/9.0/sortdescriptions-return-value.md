---
title: "Breaking change: BindingSource.SortDescriptions doesn't return null"
description: Learn about the breaking change in .NET 9 for Windows Forms where BindingSource.SortDescriptions no longer returns null if the data source is not an IBindingListView.
ms.date: 01/16/2024
ms.topic: concept-article
---
# BindingSource.SortDescriptions doesn't return null

<xref:System.Windows.Forms.BindingSource.SortDescriptions?displayProperty=nameWithType> has been updated to return an empty <xref:System.ComponentModel.ListSortDescriptionCollection> instead of `null` if the data source is not an <xref:System.ComponentModel.IBindingListView>.

## Version introduced

.NET 9 Preview 1

## Previous behavior

Previously, <xref:System.Windows.Forms.BindingSource.SortDescriptions?displayProperty=nameWithType> returned `null` if the data source wasn't an <xref:System.ComponentModel.IBindingListView>.

## New behavior

Starting in .NET 9, <xref:System.Windows.Forms.BindingSource.SortDescriptions?displayProperty=nameWithType> returns an empty <xref:System.ComponentModel.ListSortDescriptionCollection> if the data source is not an <xref:System.ComponentModel.IBindingListView>.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was incorrect.

<xref:System.Windows.Forms.BindingSource.SortDescriptions?displayProperty=nameWithType> has historically returned `null` if the data source was not an `IBindingListView`. However `BindingSource.SortDescriptions` implements <xref:System.ComponentModel.IBindingListView.SortDescriptions?displayProperty=nameWithType>, whose return type is non-nullable. To align with the interface it implements, `BindingSource.SortDescriptions` was changed to return an empty `ListSortDescriptionCollection` instead.

## Recommended action

If your code expects `null` from <xref:System.Windows.Forms.BindingSource.SortDescriptions?displayProperty=nameWithType> for any reason, update your code to expect an empty <xref:System.ComponentModel.ListSortDescriptionCollection> instead.

## Affected APIs

- <xref:System.Windows.Forms.BindingSource.SortDescriptions?displayProperty=fullName>
