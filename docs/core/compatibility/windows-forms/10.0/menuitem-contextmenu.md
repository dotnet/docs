---
title: "Breaking change - Applications referencing both WPF and WinForms must disambiguate MenuItem and ContextMenu types"
description: "Learn about the breaking change in .NET 10 Preview 1 where applications referencing both WPF and WinForms must disambiguate MenuItem and ContextMenu types."
ms.date: 3/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/44738
ms.topic: concept-article
---

# Applications referencing both WPF and WinForms must disambiguate MenuItem and ContextMenu types

This document describes a breaking change introduced in .NET 10 Preview 1. Applications that reference both Windows Presentation Foundation (WPF) and Windows Forms (WinForms) must disambiguate certain types, such as `MenuItem` and `ContextMenu`, to avoid compile-time errors.

## Version introduced

.NET 10 Preview 1

## Previous behavior

Previously, the types `ContextMenu`, `DataGrid`, `DataGridCell`, `Menu`, `MenuItem`, `ToolBar`, and `StatusBar` would resolve to the <xref:System.Windows.Controls> namespace because they did not exist in the <xref:System.Windows.Forms> namespace in .NET Core 3.1 through .NET 9.0.

```xml
<ImplicitUsings>enable</ImplicitUsings>
<UseWindowsForms>true</UseWindowsForms>
<UseWPF>true</UseWPF>
```

## New behavior

The affected types in the <xref:System.Windows.Forms> namespace cause a compile-time error when there is an ambiguous reference between <xref:System.Windows.Controls> and <xref:System.Windows.Forms>.

```output
CS0104 'ContextMenu' is an ambiguous reference between 'System.Windows.Controls.ContextMenu' and 'System.Windows.Forms.ContextMenu'
```

## Type of breaking change

This is a [source incompatible](../../categories.md#source-compatibility) change.

## Reason for change

The change facilitates migration from .NET Framework when third-party libraries cannot be updated. A .NET 10 application can continue to reference .NET Framework dependencies and handle errors at runtime.

## Recommended action

Use aliases to resolve conflicting namespaces. For example:

```csharp
using ContextMenu = System.Windows.Controls.ContextMenu;
```

Refer to the [alias name conflicts documentation](../../../../csharp/language-reference/compiler-messages/using-directive-errors.md#alias-name-conflicts) for more details.

## Affected APIs

- <xref:System.Windows.Forms.ContextMenu?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGrid?displayProperty=fullName>
- <xref:System.Windows.Forms.DataGridCell?displayProperty=fullName>
- <xref:System.Windows.Forms.Menu?displayProperty=fullName>
- <xref:System.Windows.Forms.MenuItem?displayProperty=fullName>
- <xref:System.Windows.Forms.ToolBar?displayProperty=fullName>
- <xref:System.Windows.Forms.StatusBar?displayProperty=fullName>
- <xref:System.Windows.Controls.ContextMenu?displayProperty=fullName>
- <xref:System.Windows.Controls.DataGrid?displayProperty=fullName>
- <xref:System.Windows.Controls.DataGridCell?displayProperty=fullName>
- <xref:System.Windows.Controls.Menu?displayProperty=fullName>
- <xref:System.Windows.Controls.MenuItem?displayProperty=fullName>
- <xref:System.Windows.Controls.ToolBar?displayProperty=fullName>
- `System.Windows.Controls.StatusBar`
