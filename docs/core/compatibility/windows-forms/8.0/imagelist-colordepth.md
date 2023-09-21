---
title: "Breaking change: ImageList.ColorDepth default is Depth32Bit"
description: Learn about the breaking change in .NET 8 for Windows Forms where the default value of ImageList.ColorDepth has changed from Depth8Bit to Depth32Bit.
ms.date: 01/31/2023
---
# ImageList.ColorDepth default is Depth32Bit

The default value for <xref:System.Windows.Forms.ImageList.ColorDepth?displayProperty=nameWithType> has changed over time. Starting in .NET 8, the default value has changed from <xref:System.Windows.Forms.ColorDepth.Depth8Bit> to <xref:System.Windows.Forms.ColorDepth.Depth32Bit>. This change affects both new and existing applications if they're upgraded to target .NET 8.

## Version introduced

.NET 8 Preview 1

## Previous behavior

The default value for <xref:System.Windows.Forms.ImageList.ColorDepth?displayProperty=nameWithType> was <xref:System.Windows.Forms.ColorDepth.Depth8Bit?displayProperty=nameWithType>.

## New behavior

If you haven't explicitly set <xref:System.Windows.Forms.ImageList.ColorDepth?displayProperty=nameWithType> for an image list, the color depth will automatically be reset to <xref:System.Windows.Forms.ColorDepth.Depth32Bit?displayProperty=nameWithType>. This could increase your app's memory usage.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

The default value was changed to improve image quality.

## Recommended action

If you want to continue using the previous color depth, explicitly set <xref:System.Windows.Forms.ImageList.ColorDepth?displayProperty=nameWithType> to <xref:System.Windows.Forms.ColorDepth.Depth8Bit?displayProperty=nameWithType>.

## Affected APIs

- <xref:System.Windows.Forms.ImageList.ColorDepth?displayProperty=fullName>
