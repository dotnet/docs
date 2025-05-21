---
title: "Breaking change: .NET 10 obsoletions in Windows Forms"
titleSuffix: ""
description: Learn about the .NET 10 breaking change where some Windows Forms APIs have been marked as obsolete.
ms.date: 03/10/2025
ms.topic: concept-article
---
# Windows Forms obsoletions (.NET 10)

Some Windows Forms APIs have been marked as obsolete, starting in .NET 10.

## Previous behavior

In previous .NET versions, these APIs can be used without any build warning.

## New behavior

In .NET 10 and later versions, use of these APIs produces a compile-time warning with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages.

| Diagnostic ID | Description | Severity | Version introduced |
| - | - |
| [WFDEV004](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev004) | <xref:System.Windows.Forms.Form.OnClosing(System.ComponentModel.CancelEventArgs)?displayProperty=nameWithType>, <xref:System.Windows.Forms.Form.OnClosed(System.EventArgs)?displayProperty=nameWithType> and the corresponding events are obsolete. Use <xref:System.Windows.Forms.Form.OnFormClosing(System.Windows.Forms.FormClosingEventArgs)?displayProperty=nameWithType>, <xref:System.Windows.Forms.Form.OnFormClosed(System.Windows.Forms.FormClosedEventArgs)?displayProperty=nameWithType>, <xref:System.Windows.Forms.Form.FormClosing?displayProperty=nameWithType> and <xref:System.Windows.Forms.Form.FormClosed?displayProperty=nameWithType> instead. | Warning | Preview 1 |
| [WFDEV005](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev005) | <xref:System.Windows.Clipboard.GetData(System.String)?displayProperty=nameWithType> method is obsolete. Use <xref:System.Windows.Forms.Clipboard.TryGetData*?displayProperty=nameWithType> methods instead. | Warning | Preview 1 |
| [WFDEV006](/dotnet/desktop/winforms/wfdev-diagnostics/wfdev006) | <xref:System.Windows.Forms.ContextMenu>, <xref:System.Windows.Forms.DataGrid>, <xref:System.Windows.Forms.MainMenu>, <xref:System.Windows.Forms.Menu>, <xref:System.Windows.Forms.StatusBar>, <xref:System.Windows.Forms.ToolBar> are obsolete. They're provided for binary compatibility with .NET Framework. | Warning | Preview 1 |

## Version introduced

.NET 10

## Type of breaking change

These obsoletion warnings can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.
- If necessary, you can suppress the warning using the custom `WFDEVxxx` diagnostic ID value.

## Affected APIs

### WFDEV004

- <xref:System.Windows.Forms.Form.OnClosing(System.ComponentModel.CancelEventArgs)>
- <xref:System.Windows.Forms.Form.OnClosed(System.EventArgs)?displayProperty=fullName>

### WFDEV005

- <xref:System.Windows.Clipboard.GetData(System.String)?displayProperty=fullName>

### WFDEV006

- <xref:System.Windows.Forms.ContextMenu?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGrid?displayProperty=fullName>
- <xref:System.Windows.Forms.MainMenu?displayProperty=fullName>
- <xref:System.Windows.Forms.Menu?displayProperty=fullName>
- <xref:System.Windows.Forms.StatusBar?displayProperty=fullName>
- <xref:System.Windows.Forms.ToolBar?displayProperty=fullName>

## See also

- [Obsolete Windows Forms features in .NET 10+](/dotnet/desktop/winforms/wfdev-diagnostics/obsoletions-overview)
