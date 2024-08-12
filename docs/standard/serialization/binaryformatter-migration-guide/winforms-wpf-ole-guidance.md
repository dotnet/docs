---
title: "BinaryFormatter migration guide: WinForms and WPF OLE guidance"
description: "Learn about the effects of the deprecation and removal of BinaryFormatter from .NET on clipboard and drag-and-drop operations in Windows Forms and Windows Presentation Foundation."
ms.date: 7/31/2024
no-loc: [BinaryFormatter, Windows Forms, WPF, Windows Presentation Foundation, OLE]
helpviewer_keywords:
  - "BinaryFormatter"
  - "WinForms"
  - "Windows Forms"
  - "WPF"
  - "Windows Presentation Foundation"
  - "Clipboard"
  - "Drag-and-drop"
  - "OLE"
---

# Windows Forms and Windows Presentation Foundation BinaryFormatter OLE guidance

This document outlines the effects the [BinaryFormatter] removal has on OLE scenarios in Windows Forms and Windows Presentation Foundation (WPF). For information about the effects of BinaryFormatter removal in Windows Forms in general see [Windows Forms migration guide for BinaryFormatter](./winforms-applications.md). For information about the effects of [BinaryFormatter] removal in WPF in general see [WPF migration guide for BinaryFormatter](./wpf-applications.md).

## BinaryFormatter in OLE scenarios

### Clipboard

All standard OLE DataFormats in [`System.Windows.Forms.DataFormats`](/dotnet/api/system.windows.forms.dataformats#fields) and [`System.Windows.DataFormats`](/dotnet/api/system.windows.dataformats#remarks) don't go through BinaryFormatter, except for `DataFormats.Serializable` and any custom format. If you're using `DataFormats.Serializable` or a custom format, [BinaryFormatter] is used if your clipboard scenario involves a type that isn't intrinsically handled as outlined in [Windows Forms migration guide for BinaryFormatter](./winforms-applications.md) and [WPF Migration Guide – Binary Formatter](./wpf-applications.md). Particularly, [BinaryFormatter] is used when <xref:System.Windows.Forms.Clipboard.SetData*?displayProperty=fullName> or <xref:System.Windows.Clipboard.SetData*?displayProperty=fullName> is called with your type and when <xref:System.Windows.Forms.Clipboard.GetData*?displayProperty=fullName> or <xref:System.Windows.Clipboard.GetData*?displayProperty=fullName> is called to get your type. BinaryFormatter is also used if <xref:System.Windows.Forms.Clipboard.SetDataObject*?displayProperty=fullName> or <xref:System.Windows.Clipboard.SetDataObject*?displayProperty=fullName> is called. With the BinaryFormatter removal, you won't see an exception when setting the data on the clipboard if BinaryFormatter was needed. Instead, you'll see a string about [BinaryFormatter] being removed when you attempt to get the type that isn't intrinsically handled from the clipboard.

### Drag-and-drop feature

If your drag-and-drop scenario involves types that aren't intrinsically handled during serialization and deserialization, [BinaryFormatter] is used when <xref:System.Windows.Forms.Control.DoDragDrop*?displayProperty=fullName> or <xref:System.Windows.DragDrop.DoDragDrop*?displayProperty=fullName> is called and the data has been dragged out of process. [BinaryFormatter] is also used when <xref:System.Windows.Forms.DataObject.GetData*?displayProperty=fullName> or <xref:System.Windows.DataObject.GetData*?displayProperty=fullName> is called to retrieve the data that originated from another process if the type isn't intrinsically handled. With the [BinaryFormatter] removal, you'll now see a string about [BinaryFormatter] being removed when you attempt retrieve the data that has originated from another process for types that aren't intrinsically handled.

## Migrating away from BinaryFormatter

### Clipboard and drag-and-drop

For types that aren't intrinsically handled that are used in clipboard and drag-and-drop operations, it's recommended that you format those types as a `byte[]` or `string` payload before passing the data to clipboard or drag-and-drop APIs. Using JSON is one way to achieve this. You'll need to make adjustments to handle receiving a JSON formatted type similar to adjustments made to place JSON formatted types on clipboard or drag-and-drop operations. For more information on how to serialize and deserialize the type with JSON, see [How to write .NET objects as JSON (serialize)](../system-text-json/how-to.md).

## Issues

If you experience unexpected behavior with your Windows Forms or WPF app regarding [BinaryFormatter] serialization or deserializing, please file an issue at [github.com/dotnet/winforms](https://github.com/dotnet/winforms/issues) or [github.com/dotnet/wpf](https://github.com/dotnet/wpf/issues) respectively.

[BinaryFormatter]: xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
