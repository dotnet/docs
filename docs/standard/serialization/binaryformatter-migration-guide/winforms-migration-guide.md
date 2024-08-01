---
title: "BinaryFormatter Migration Guide: WinForms Migration Guide"
description: "This guide covers the affects the deprecation and removal of BinaryFormatter from .NET has on WinForms and recommends migration steps."
ms.date: 7/31/2024
no-loc: [BinaryFormatter, WinForms]
helpviewer_keywords:
  - "BinaryFormatter"
  - "WinForms"
---

# WinForms Migration Guide

# BinaryFormatter Removal

Starting in .NET 9, `BinaryFormatter` is being moved to a separate, unsupported nuget package due to its known [security risks](https://learn.microsoft.com/dotnet/standard/serialization/binaryformatter-security-guide). For more information about the risks `BinaryFormatter` poses and our decision on its removal, see [BinaryFormatter Migration Guide](./overview.md). With BinaryFormatter’s removal, it is expected that many WinForms applications will be impacted, and action will need to be taken to complete migration to .NET 9+.

# How BinaryFormatter Affects WinForms

WinForms itself has and still currently contains `BinaryFormatter` code internally for scenarios such as clipboard, drag/drop, and Designer ResX, however, measures have been taken to mitigate the usage of `BinaryFormatter` behind the scenes for common primitive types, including primitive arrays and primitive lists. Usage of these types in clipboard and drag/drop scenarios will continue to work without using `BinaryFormatter` and without any gesture from the developer. Primitive types include the following

- `boolean`
- `byte`
- `char`
- `decimal`
- `double`
- `int`
- `sbyte`
- `single`
- `TimeSpan`
- `DateTime`
- `uint`
- `string`
- `nint`
- `nuint`

Additional types WinForms currently supports include the following

- `PointF`
- `RectangleF`
- `Bitmap`
- `ImageListStreamer`

## Clipboard

If your clipboard scenario does not involve the types above, `BinaryFormatter` would be used when [`Clipboard.SetData`](https://learn.microsoft.com/dotnet/api/system.windows.clipboard.setdata) is called with your type and when [`Clipboard.GetData`](https://learn.microsoft.com/dotnet/api/system.windows.clipboard.getdata) is called to get your type. `BinaryFormatter` will also be used if [`Clipboard.SetDataObject(object, copy: true)`](https://learn.microsoft.com/dotnet/api/system.windows.clipboard.setdataobject#system-windows-clipboard-setdataobject(system-object-system-boolean)) is called. With the `BinaryFormatter` removal, developers will now see a string about `BinaryFormatter` being removed on the clipboard when using those APIs with types that are not intrinsically handled during serialization/deserialization.

## Drag/Drop

If your drag/drop scenario involves types that are not intrinsically handled during serialization/deserialization, `BinaryFormatter` would be used when [`Control.DoDragDrop`](https://learn.microsoft.com/dotnet/api/system.windows.forms.control.dodragdrop) is called, and the item is dragged out of process and when `DataObject.GetData`(https://learn.microsoft.com/dotnet/api/system.windows.dataobject.getdata) is called to retrieve your type that has been dragged out of process. With the `BinaryFormatter` removal, developers will now see a string about `BinaryFormatter` being removed upon dropping the dragged item in another process when a drag operation starts with types that are not intrinsically handled.

## The WinForms Designer

The WinForms Designer also uses `BinaryFormatter` internally for ResX serialization/deserialization and CodeDom.

Types and properties may be participating in serialization without developers realizing due to the standard behavior of the WinForms Designer. One way that `BinaryFormatter` is used where developers may not be aware of is when a property on a UserControl is introduced and that control is already populated at design-time, then it’s very likely that that data gets serialized into code or resource files. If all the following are true:

- A property contains data at the time when a Form in the Designer gets saved
- that property is not attributed with `DesignerSerializationVisibility(false)`
- that property is not read-only
- that property does not have a DefaultValueAttribute
- that property does not have a respective bool `ShouldSerialize\[PropertyName\]` method returning false at the time of the CodeDOM serialization process. (Note: the method can be of `private` scope.)

the Designer looks if that property’s type has a type converter. If it does then it uses it to serialize the property content, otherwise `BinaryFormatter` is used to serialize the content into the resource file.
WinForms has added analyzers along with code fixes to help bring awareness to this type of behavior where `BinaryFormatter` serialization may be occurring without the developer’s knowledge.

# Migrating Away from BinaryFormatter

If types that are not intrinsically handled during serialization/deserialization are used in the affected scenarios, action will need to be taken to complete migration to .NET 9+.

## Clipboard and Drag/Drop

For types that are not intrinsically handled that are used in clipboard and drag/drop operations, it is recommended developers format those types as a `byte[]` or `string` payload before passing the data to clipboard or drag/drop APIs. Using JSON is one way to achieve this. Note that adjustments will need to be made to handle receiving a JSON formatted type just as adjustments have been made to place JSON formatted types on clipboard or drag/drop operations. For more information on how to serialize/deserialize the type with JSON, see [How to write .NET objects as JSON (serialize)](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/how-to)

## Designer Scenarios

For types that are not intrinsically handled during serialization into resources/code, such as in the case of the Designer with ResX and CodeDom serialization scenarios, the prescribed way of migrating away from `BinaryFormatter` is to ensure a `TypeConverter` is registered for the type or property that is participating in serialization. This way, during serialization/deserialization, the `TypeConverter` will be used in lieu of where `BinaryFormatter` was once used. For more information on implementing a type converter, see [`TypeConverter` Class](https://learn.microsoft.com/dotnet/api/system.componentmodel.typeconverter#notes-to-inheritors)

# Compatibility Workaround (Not Recommended)

For users who cannot migrate away from `BinaryFormatter` for whatever reason, `BinaryFormatter` can be added back for compatibility. See [BinaryFormatter Migration Guide: Compatibility Package](./compatibility-package.md) for more details. Caution that BinaryFormatter is dangerous and not recommended as it puts the consuming apps at risk for attacks such as denial of service, which may render the app unresponsive and unexpectedly terminate. For more information about the risks `BinaryFormatter` poses see [Deserialization risks in use of BinaryFormatter and related types](https://learn.microsoft.com/dotnet/standard/serialization/binaryformatter-security-guide).

# Issues

If you are experiencing unexpected behavior with your WinForms app regarding `BinaryFormatter` serialization/deserializing please file an issue at [github.com/dotnet/winforms](https://github.com/dotnet/winforms/issues).
