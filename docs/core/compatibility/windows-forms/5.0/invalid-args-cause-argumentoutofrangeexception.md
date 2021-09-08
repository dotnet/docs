---
title: "Breaking change: WinForms properties now throw ArgumentOutOfRangeException"
description: Learn about the breaking change in .NET 5 where Some Windows Forms properties now throw an ArgumentOutOfRangeException for invalid arguments.
ms.date: 06/18/2020
---
# WinForms properties now throw ArgumentOutOfRangeException

Some Windows Forms properties now throw an <xref:System.ArgumentOutOfRangeException> for invalid arguments, where previously they did not.

## Change description

Previously, these properties threw various exceptions, such as <xref:System.NullReferenceException>, <xref:System.IndexOutOfRangeException>, or <xref:System.ArgumentException>, when passed out-of-range arguments. Starting in .NET 5, these properties now throw an <xref:System.ArgumentOutOfRangeException> when passed arguments that are out of range.

Throwing an <xref:System.ArgumentOutOfRangeException> conforms to the behavior of the .NET runtime. It also improves the debugging experience by clearly communicating which argument is invalid.

## Version introduced

.NET 5.0

## Recommended action

- Update the code to prevent passing invalid arguments.
- If necessary, handle an <xref:System.ArgumentOutOfRangeException> when setting the property.

## Affected APIs

The following table lists the affected properties and parameters:

> [!div class="mx-tdBreakAll"]
> | Property | Parameter name | Version added |
> |-|-|-|
> | <xref:System.Windows.Forms.ListBox.IntegerCollection.Item(System.Int32)?displayProperty=nameWithType> | `index` | 5.0 Preview 5 |
> | <xref:System.Windows.Forms.TreeNode.ImageIndex?displayProperty=nameWithType> | `value` | 5.0 Preview 6 |
> | <xref:System.Windows.Forms.TreeNode.SelectedImageIndex?displayProperty=nameWithType> | `value` | 5.0 Preview 6 |

<!--

### Affected APIs

- `P:System.Windows.Forms.ListBox.IntegerCollection.Item(System.Int32)`
- `P:System.Windows.Forms.TreeNode.ImageIndex`
- `P:System.Windows.Forms.TreeNode.SelectedImageIndex`

### Category

Windows Forms

-->
