---
title: "Breaking change: TreeView checkbox image truncation"
description: Learn about the .NET 10 Preview 1 breaking change in Windows Forms where the TreeView checkbox image is truncated under certain conditions.
ms.date: 01/30/2025
---
# TreeView checkbox image truncation

The TreeNode in the TreeView control allows users to customize the DrawMode and add checkboxes. However, the checkbox image will be truncated due to the position of the TreeNode text drawing. To avoid affecting normal common use, an AppContext switch setting is added to solve the problem of checkbox truncation in these specific situations.

The conditions under which the checkbox image is truncated are:

- `CheckBoxes` is set to `true`
- `DrawMode` is set to `OwnerDrawText`
- `DrawDefault` is set to `true` in the `OnDrawNode` event

## Previous behavior

When the TreeView control has `CheckBoxes` set to `true`, `DrawMode` set to `OwnerDrawText`, and `DrawDefault` set to `true` in the `OnDrawNode` event, the TreeNode checkbox images are shown truncated on the right border.

## New behavior

By setting the switch `"System.Windows.Forms.TreeView.MoveTreeViewTextLocationOnePixel": true` in the project's runtime config file, the TreeNode checkboxes will be displayed completely when the TreeView has `CheckBoxes` set to `true`, `DrawMode` set to `OwnerDrawText`, and `DrawDefault` set to `true` in the `OnDrawNode` event.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change ensures that the checkbox of the node in the TreeView control can be fully displayed.

## Recommended action

Manually add `"System.Windows.Forms.TreeView.MoveTreeViewTextLocationOnePixel": true` to the project's *runtimeconfig.json* file to enable the switch.

## Affected APIs

- <xref:System.Windows.Forms.TreeView.CheckBoxes?displayProperty=fullName>
