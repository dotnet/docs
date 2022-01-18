---
title: "Breaking change: Some APIs throw ArgumentNullException (.NET 7)"
description: Learn about the breaking change in .NET 7 where some APIs validate arguments and now throw an ArgumentNullException.
ms.date: 01/14/2022
---
# Some APIs throw ArgumentNullException (.NET 7)

Some APIs now validate input parameters and throw an <xref:System.ArgumentNullException> where previously they threw a <xref:System.NullReferenceException>, if invoked with `null` input arguments.

## Previous behavior

In previous .NET versions, the affected APIs throw a <xref:System.NullReferenceException> if invoked with an argument that's `null`.

## New behavior

Starting in .NET 7, the affected APIs throw an <xref:System.ArgumentNullException> if invoked with an argument that's `null`.

## Change category

This change affects [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Throwing <xref:System.ArgumentNullException> conforms to .NET Runtime behavior. It provides a better debug experience by clearly communicating which argument caused the exception.

## Version introduced

.NET 7

## Recommended action

- Review and, if necessary, update your code to prevent passing `null` input arguments to the affected APIs.
- If your code handles <xref:System.NullReferenceException>, replace or add an additional handler for <xref:System.ArgumentNullException>.

## Affected APIs

The following table lists the affected APIs and specific parameters:

| Method/property | Parameter name |
|-|-|
| <xref:System.Windows.Forms.ToolStripArrowRenderEventArgs.%23ctor(System.Drawing.Graphics,System.Windows.Forms.ToolStripItem,System.Drawing.Rectangle,System.Drawing.Color,System.Windows.Forms.ArrowDirection)> | `g` |
| <xref:System.Windows.Forms.ToolStripItemRenderEventArgs.%23ctor(System.Drawing.Graphics,System.Windows.Forms.ToolStripItem)> | `g` and `item` |
| <xref:System.Windows.Forms.ControlPaint.CreateHBitmap16Bit(System.Drawing.Bitmap,System.Drawing.Color)?displayProperty=fullName> | `bitmap` |
| <xref:System.Windows.Forms.ControlPaint.CreateHBitmapColorMask(System.Drawing.Bitmap,System.IntPtr)?displayProperty=fullName> | `bitmap` |
| <xref:System.Windows.Forms.ComboBox.ChildAccessibleObject.%23ctor(System.Windows.Forms.ComboBox,System.IntPtr)> | `owner` |
