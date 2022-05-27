---
title: "Breaking change: Some APIs throw ArgumentNullException"
description: Learn about the breaking change in .NET 6 where some APIs validate arguments and now throw an ArgumentNullException.
ms.date: 11/04/2021
---
# Some APIs throw ArgumentNullException

Some APIs now validate input parameters and throw an <xref:System.ArgumentNullException> where previously they threw a <xref:System.NullReferenceException>, if invoked with `null` input arguments.

## Change description

In previous .NET versions, the affected APIs throw a <xref:System.NullReferenceException> if invoked with an argument that's `null`.

Starting in .NET 6, the affected APIs throw an <xref:System.ArgumentNullException> if invoked with an argument that's `null`.

## Change category

This change affects [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Throwing <xref:System.ArgumentNullException> conforms to .NET Runtime behavior. It provides a better debug experience by clearly communicating which argument caused the exception.

## Version introduced

.NET 6

## Recommended action

- Review and, if necessary, update your code to prevent passing `null` input arguments to the affected APIs.
- If your code handles <xref:System.NullReferenceException>, replace or add an additional handler for <xref:System.ArgumentNullException>.

## Affected APIs

The following table lists the affected APIs and specific parameters:

| Method/property | Parameter name |
|-|-|
| <xref:System.Windows.Forms.TreeNodeCollection.Item(System.Int32)?displayProperty=fullName> | `index` |
| <xref:System.Windows.Forms.DrawTreeNodeEventArgs.%23ctor(System.Drawing.Graphics,System.Windows.Forms.TreeNode,System.Drawing.Rectangle,System.Windows.Forms.TreeNodeStates)> | `graphics` |
| <xref:System.Windows.Forms.DataGridViewRowStateChangedEventArgs.%23ctor(System.Windows.Forms.DataGridViewRow,System.Windows.Forms.DataGridViewElementStates)> | `dataGridViewRow` |
| <xref:System.Windows.Forms.DataGridViewColumnStateChangedEventArgs.%23ctor(System.Windows.Forms.DataGridViewColumn,System.Windows.Forms.DataGridViewElementStates)> | `dataGridViewColumn` |

## See also

- [TreeNodeCollection.Item throws exception if node is assigned elsewhere](treenodecollection-item-throws-argumentexception.md)
