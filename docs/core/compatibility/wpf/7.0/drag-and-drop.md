---
title: "Breaking change: 'Revert behavior with text drag-and-drop operations'"
description: Learn about a breaking change in Windows Presentation Foundation (WPF) and .NET 7. Drag-and-drop behavior was reverted to .NET Framework behavior behavior when dragging text from a text editor control.
ms.date: 11/4/2024
ai-usage: ai-assisted
---

# .NET 7 restored drag-and-drop operations behavior on text editors

.NET 7 addresses a regression introduced in .NET Core 3.0 concerning drag operations in text editor controls. This update restores the behavior to match that of the .NET Framework, ensuring consistency in how data is set during drag operations.

## Version introduced

.NET 7

## Previous behavior

The data type on <xref:System.Windows.DataObject?displayProperty=fullName> when dragging text from a text editor control is <xref:System.Windows.DataFormats.Text?displayProperty=nameWithType> or <xref:System.Windows.DataFormats.UnicodeText?displayProperty=nameWithType>.

## New behavior

The data type on <xref:System.Windows.DataObject?displayProperty=fullName> when dragging text from a text editor control is <xref:System.Windows.DataFormats.StringFormat?displayProperty=nameWithType>.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change is made to match the behavior of the .NET Framework, ensuring consistency and expected behavior across different .NET versions.

## Recommended action

Upgrade older projects to the latest version of .NET to restore the behavior.

## Affected APIs

- <xref:System.Windows.DataObject?displayProperty=fullName>
