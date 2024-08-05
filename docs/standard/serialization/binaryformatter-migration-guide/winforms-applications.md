---
title: "BinaryFormatter migration guide: WinForms applications"
description: "Learn about the effects of the deprecation and removal of BinaryFormatter from .NET on Windows Forms and how to migrate."
ms.date: 7/31/2024
no-loc: [BinaryFormatter, WinForms]
helpviewer_keywords:
  - "BinaryFormatter"
  - "WinForms"
---

# Windows Forms migration guide for BinaryFormatter

## BinaryFormatter removal

Starting in .NET 9, `BinaryFormatter` has moved to a separate, unsupported NuGet package due to its known [security risks](../binaryformatter-security-guide.md). For more information about the risks `BinaryFormatter` poses and the reason for its removal, see [BinaryFormatter migration guide](index.md). With BinaryFormatter’s removal, it's expected that many Windows Forms applications will be impacted, and you'll need to take action to complete your migration to .NET 9 or a later version.

## How BinaryFormatter affects Windows Forms

Windows Forms itself has and still contains `BinaryFormatter` code internally for scenarios such as clipboard, drag-and-drop, and storing or loading resources at design time. However, measures have been taken to mitigate the usage of BinaryFormatter behind the scenes for common types, including common collections. Usage of these types in clipboard and drag-and-drop scenarios will continue to work without using BinaryFormatter and without any gesture from the developer. Common types include the following:

- `bool`
- `byte`
- `char`
- `decimal`
- `double`
- `int`
- `sbyte`
- `float`
- `TimeSpan`
- `DateTime`
- `uint`
- `string`
- `nint`
- `nuint`
- `long`
- `ulong`
- `short`
- `ushort`

Windows Forms also supports the following additional types:

- `PointF`
- `RectangleF`
- `Bitmap`
- `ImageListStreamer`

### Clipboard

All standard OLE [`DataFormats`](/dotnet/api/system.windows.forms.dataformats#fields) don't go through BinaryFormatter, except for `DataFormats.Serializable` and any custom format. If you're using `DataFormats.Serializable` or a custom format, BinaryFormatter is used if your clipboard scenario involves types that aren't intrinsically handled when [`Clipboard.SetData`](/dotnet/api/system.windows.forms.clipboard.setdata) is called with your type and when [`Clipboard.GetData`](/dotnet/api/system.windows.forms.clipboard.getdata) is called to get your type. BinaryFormatter is also used if [`Clipboard.SetDataObject(object, copy: true)`](/dotnet/api/system.windows.forms.clipboard.setdataobject) is called. With the BinaryFormatter removal, you won't see an exception when setting the data on the clipboard if BinaryFormatter was needed. Instead, you'll see a string about BinaryFormatter being removed when you attempt to get the type that isn't intrinsically handled from the clipboard.

### Drag-and-drop feature

If your drag-and-drop scenario involves types that aren't intrinsically handled during serialization and deserialization, BinaryFormatter is used when [`Control.DoDragDrop`](/dotnet/api/system.windows.forms.control.dodragdrop) is called, and when [`DataObject.GetData`](/dotnet/api/system.windows.dataobject.getdata) is called to retrieve a type that's been dragged out of process. With the BinaryFormatter removal, you'll now see a string about BinaryFormatter being removed when you drop a dragged item in another process for drag-and-drop operations with types that aren't intrinsically handled.

### The Windows Forms Designer

The Windows Forms Out-Of-Process Designer also uses `BinaryFormatter` internally for ResX serialization and deserialization.

Types and properties might participate in serialization without you realizing due to the standard behavior of the Windows Forms Designer. One way that BinaryFormatter is used that you might not be aware of is when a `public` property on a <xref:System.ComponentModel.IComponent> is introduced and that component is populated or that property is edited at design time. It's likely that that data gets serialized into resource files. Consider the following conditions:

- A public property contains data at the time when a `Form` in the Designer is saved.
- That property is not read-only.
- That property is not attributed with `DesignerSerializationVisibility(false)`.
- That property does not have a DefaultValueAttribute.
- That property does not have a respective `bool ShouldSerialize[PropertyName]` method that returns `false` at the time of the CodeDOM serialization process. (Note: the method can have `private` scope.)
- That property does not have a [`DesignerSerializer`](https://learn.microsoft.com/dotnet/api/microsoft.visualstudio.modeling.dsldefinition.designerserializer?view=visualstudiosdk-2019)

If these statements are true, the Designer determines if that property’s type has a type converter. If it does, the Designer uses the type converter to serialize the property content. Otherwise, it uses BinaryFormatter to serialize the content into the resource file.
Windows Forms has added analyzers along with code fixes to help bring awareness to this type of behavior where BinaryFormatter serialization might be occurring without the developer’s knowledge.

## Migrate away from BinaryFormatter

If types that aren't intrinsically handled during serialization and deserialization are used in the affected scenarios, you'll need to take action to complete migration to .NET 9 or a later version.

### Clipboard and drag-and-drop

For types that aren't intrinsically handled that are used in clipboard and drag-and-drop operations, it's recommended that you format those types as a `byte[]` or `string` payload before passing the data to clipboard or drag-and-drop APIs. Using JSON is one way to achieve this. You'll need to make adjustments to handle receiving a JSON formatted type just as adjustments have been made to place JSON formatted types on clipboard or drag-and-drop operations. For more information on how to serialize and deserialize the type with JSON, see [How to write .NET objects as JSON (serialize)](../system-text-json/how-to.md).

### Designer scenarios

For types that aren't intrinsically handled during serialization into resources or code, such as in the case of the Designer with ResX and CodeDom serialization scenarios, the prescribed way of migrating away from BinaryFormatter is to ensure a `TypeConverter` is registered for the type or property that's participating in serialization. This way, during serialization and deserialization, the `TypeConverter` is used in lieu of where `BinaryFormatter` was once used. For more information on implementing a type converter, see [`TypeConverter` Class](/dotnet/api/system.componentmodel.typeconverter#notes-to-inheritors)

## Compatibility workaround (not recommended)

For users who cannot migrate away from `BinaryFormatter` for whatever reason, `BinaryFormatter` can be added back for compatibility. For more information, see [BinaryFormatter migration guide: Compatibility Package](compatibility-package.md).

> [!CAUTION]
> BinaryFormatter is dangerous and not recommended as it puts consuming apps at risk for running untrusted code from an unknown source. For more information about the risks BinaryFormatter poses, see [Deserialization risks in use of BinaryFormatter and related types](../binaryformatter-security-guide.md).

## Issues

If you experience unexpected behavior with your Windows Forms app regarding BinaryFormatter serialization or deserializing, please file an issue at [github.com/dotnet/winforms](https://github.com/dotnet/winforms/issues).
