---
title: "Breaking change: 'Text drag-and-drop operations'"
description: Learn about a breaking change in Windows Presentation Foundation (WPF) in .NET Core 3.0. Drag-and-drop behavior changed when dragging text from a text editor control.
ms.date: 11/4/2024
ms.topic: include
ai-usage: ai-assisted
---

### Altered drag-and-drop behavior on text editors

.NET Core 3.0 introduced a change in how text editor controls create a <xref:System.Windows.DataObject?displayProperty=fullName> when dragging text to another control. The change disabled autoconversion, causing the operation to keep the data as <xref:System.Windows.DataFormats.Text?displayProperty=nameWithType> or <xref:System.Windows.DataFormats.UnicodeText?displayProperty=nameWithType> instead of converting it to <xref:System.Windows.DataFormats.StringFormat?displayProperty=nameWithType>.

#### Version introduced

.NET Core 3.0

#### Category

Windows Presentation Foundation

#### Previous behavior

The data type on <xref:System.Windows.DataObject?displayProperty=fullName> when dragging text from a text editor control was <xref:System.Windows.DataFormats.StringFormat?displayProperty=nameWithType>.

#### New behavior

The data type on <xref:System.Windows.DataObject?displayProperty=fullName> when dragging text from a text editor control is <xref:System.Windows.DataFormats.Text?displayProperty=nameWithType> or <xref:System.Windows.DataFormats.UnicodeText?displayProperty=nameWithType>.

#### Type of breaking change

This change is a [behavioral change](../../../../docs/core/compatibility/categories.md).

#### Reason for change

The change was unintentional.

#### Recommended action

This change was [reverted in .NET 7](../../../../docs/core/compatibility/wpf/7.0/drag-and-drop.md). Upgrade to .NET 7 or later.

#### Affected APIs

- <xref:System.Windows.DataObject?displayProperty=fullName>
