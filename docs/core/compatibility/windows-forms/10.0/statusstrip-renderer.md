---
title: "Breaking change: System.Windows.Forms.StatusStrip uses a different default renderer"
description: Learn about the breaking change in .NET 10 for Windows Forms where System.Windows.Forms.StatusStrip uses a different default value for the RenderMode property.
ms.date: 02/12/2025
---
# System.Windows.Forms.StatusStrip uses a different default renderer

<xref:System.Windows.Forms.StatusStrip?displayProperty=nameWithType> has been updated to use the default renderer.

## Version introduced

.NET 10 Preview 1

## Previous behavior

Previously, <xref:System.Windows.Forms.StatusStrip?displayProperty=nameWithType> used the default renderer.

## New behavior

The `StatusStrip`'s `RenderMode` property is set to <xref:System.Windows.Forms.ToolStripRenderMode.System?displayProperty=nameWithType> by default. You might observe minor changes to the appearance of the `StatusStrip`.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was [changed in .NET 9](../9.0/statusstrip-renderer.md). This reverts the behavior to the previous default behavior.

## Recommended action

The new behavior is recommended for accessibility reasons. If you want to revert to the previous behavior, set the `RenderMode` property to <xref:System.Windows.Forms.ToolStripRenderMode.System?displayProperty=nameWithType>.

> [!NOTE]
> The new behavior was reverted to the previous behavior in .NET 10 Preview 1.

## Affected APIs

- <xref:System.Windows.Forms.StatusStrip?displayProperty=fullName>
- <xref:System.Windows.Forms.ToolStripManager.RenderMode?displayProperty=fullName>
