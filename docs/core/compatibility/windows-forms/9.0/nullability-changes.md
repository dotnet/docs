---
title: "Breaking change: Changes to nullability annotations (Windows Forms)"
description: Learn about the .NET 9 breaking change in Windows Forms where some nullable reference type annotations have changed.
ms.date: 01/16/2024
---
# Changes to nullability annotations (Windows Forms)

In .NET 9, some nullability annotations on the Windows Forms APIs have changed.

## Previous behavior

Previously, some parameters were marked as nullable.

## New behavior

Starting in .NET 9, these parameters are marked as non-nullable. If you pass an argument that might be null, you'll get a compiler warning.

## Version introduced

.NET 9 Preview 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The parameter on <xref:System.Windows.Forms.Design.IWindowsFormsEditorService.DropDownControl(System.Windows.Forms.Control)?displayProperty=nameWithType> was previously marked as nullable, but there's no guidance for implementers on how they should handle null input. Also, logically this method should not accept `null`.

## Affected APIs

The following table lists the affected APIs:

| API | What changed | Recommended action |
| - | - | - |
| <xref:System.Windows.Forms.Design.IWindowsFormsEditorService.DropDownControl(System.Windows.Forms.Control)?displayProperty=nameWithType> | The `control` parameter is non-nullable | Make sure you're not passing a nullable `Control` to this method. Also, update any implementations of <xref:System.Windows.Forms.Design.IWindowsFormsEditorService> to remove nullability of the `DropDownControl` method's parameter. |
