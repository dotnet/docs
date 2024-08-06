---
title: "BinaryFormatter migration guide: WinForms applications"
description: "Learn about the effects of the deprecation and removal of BinaryFormatter from .NET on Windows Forms and how to migrate."
ms.date: 7/31/2024
no-loc: [BinaryFormatter, Windows Forms, WinForms]
helpviewer_keywords:
  - "BinaryFormatter"
  - "WinForms"
  - "Windows Forms"
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

For information about the effects BinaryFormatter removal has on OLE scenarios such as clipboard as well as migration guidance see [Windows Forms and Windows Presentation Framework BinaryFormatter OLE guidance](./winforms-wpf-ole-guidance.md).

### Drag-and-drop feature

If your drag-and-drop scenario involves types that aren't intrinsically handled during serialization and deserialization, BinaryFormatter is used when [`Control.DoDragDrop`](/dotnet/api/system.windows.forms.control.dodragdrop) is called, and when [`DataObject.GetData`](/dotnet/api/system.windows.dataobject.getdata) is called to retrieve a type that's been dragged out of process. With the BinaryFormatter removal, you'll now see a string about BinaryFormatter being removed when you drop a dragged item in another process for drag-and-drop operations with types that aren't intrinsically handled.

### Resources (ResX)

#### The Windows Forms Designer

The Windows Forms Out-Of-Process Designer also uses `BinaryFormatter` internally for ResX serialization and deserialization.

Types and properties might participate in serialization without you realizing due to the standard behavior of the Windows Forms Designer. One way that BinaryFormatter is used that you might not be aware of is when a `public` property on a <xref:System.ComponentModel.IComponent> is introduced and that component is populated or that property is edited at design time. It's likely that that data gets serialized into resource files. Consider the following conditions:

- A public property contains data at the time when a `Form` in the Designer is saved.
- That property is not read-only.
- That property is not attributed with `DesignerSerializationVisibility(false)`.
- That property does not have a DefaultValueAttribute.
- That property does not have a respective `bool ShouldSerialize[PropertyName]` method that returns `false` at the time of the CodeDOM serialization process. (Note: the method can have `private` scope.)
- That property does not have a [`DesignerSerializer`](/dotnet/api/microsoft.visualstudio.modeling.dsldefinition.designerserializer)

If these statements are true, the Designer determines if that property’s type has a type converter. If it does, the Designer uses the type converter to serialize the property content. Otherwise, it uses BinaryFormatter to serialize the content into the resource file.
Windows Forms has added analyzers along with code fixes to help bring awareness to this type of behavior where BinaryFormatter serialization might be occurring without the developer’s knowledge.

#### Loading resource during runtime

Types that had been previously serialized into resource files via `BinaryFormatter` will continue to deserialize as expected without the need for `BinaryFormatter` as the content of ResX files are considered trusted data. In the rare case that deserialization cannot occur without `BinaryFormatter`, it can be added back for compatibility. See [BinaryFormatter migration guide: Compatibility Package](compatibility-package.md) for details. Note that an extra step of setting `System.Resources.Extensions.UseBinaryFormatter` app context switch to `true` is required to use `BinaryFormatter` for resources.

## Migrate away from BinaryFormatter

If types that aren't intrinsically handled during serialization and deserialization are used in the affected scenarios, you'll need to take action to complete migration to .NET 9 or a later version.

### Loading and saving resources during design time

For types that aren't intrinsically handled during serialization into resources, such as in the case of the Designer with ResX scenarios, the prescribed way of migrating away from BinaryFormatter is to ensure a `TypeConverter` is registered for the type or property that's participating in serialization. This way, during serialization and deserialization, the `TypeConverter` is used in lieu of where `BinaryFormatter` was once used. For more information on implementing a type converter, see [`TypeConverter` Class](/dotnet/api/system.componentmodel.typeconverter#notes-to-inheritors)


## Compatibility workaround (not recommended)

For users who cannot migrate away from `BinaryFormatter` for whatever reason, `BinaryFormatter` can be added back for compatibility. For more information, see [BinaryFormatter migration guide: Compatibility Package](compatibility-package.md).

> [!CAUTION]
> BinaryFormatter is dangerous and not recommended as it puts consuming apps at risk for running untrusted code from an unknown source. For more information about the risks BinaryFormatter poses, see [Deserialization risks in use of BinaryFormatter and related types](../binaryformatter-security-guide.md).

## Issues

If you experience unexpected behavior with your Windows Forms app regarding BinaryFormatter serialization or deserializing, please file an issue at [github.com/dotnet/winforms](https://github.com/dotnet/winforms/issues).
