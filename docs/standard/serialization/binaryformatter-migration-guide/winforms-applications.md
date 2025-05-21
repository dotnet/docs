---
title: "BinaryFormatter migration guide: WinForms apps"
description: "Learn about the effects of the deprecation and removal of BinaryFormatter from .NET on Windows Forms and how to migrate."
ms.date: 7/31/2024
no-loc: [BinaryFormatter, Windows Forms, WinForms]
helpviewer_keywords:
  - "BinaryFormatter"
  - "WinForms"
  - "Windows Forms"
ms.topic: upgrade-and-migration-article
---

# Windows Forms migration guide for BinaryFormatter

## BinaryFormatter removal

Starting with .NET 9, [BinaryFormatter] is no longer supported due to its known [security risks](../binaryformatter-security-guide.md) and its APIs always throw a <xref:System.PlatformNotSupportedException> for all project types, including Windows Forms apps. For more information about the risks BinaryFormatter poses and the reason for its removal, see the [BinaryFormatter migration guide](index.md).

With BinaryFormatter's removal, it's expected that many Windows Forms applications will be impacted, and you'll need to take action to complete your migration to .NET 9 or a later version.

## How BinaryFormatter affects Windows Forms

Prior to .NET 9, Windows Forms used [BinaryFormatter] to serialize and deserialize data for scenarios such clipboard, drag-and-drop, and storing or loading resources at design time. Starting with .NET 9, Windows Forms and WPF use a subset of the [BinaryFormatter] implementation internally for these scenarios. While BinaryFormatter's risks cannot be addressed in general-purpose serialization/deserialization, measures have been taken to mitigate the risks in these very specific use cases with a known set of types. A fall-back to [BinaryFormatter] is still in place for unknown or unsupported types, which will throw exceptions unless migration steps are taken in the application.

Windows Forms and WPF apps both handle the following types, along with arrays and lists of these types. Clipboard, drag-and-drop, and design-time resources will continue to work with these types without any migration steps needed.

- `bool`
- `byte`
- `char`
- `decimal`
- `double`
- `int`
- `sbyte`
- `float`
- <xref:System.TimeSpan>
- <xref:System.DateTime>
- `uint`
- `string`
- `nint`
- `nuint`
- `long`
- `ulong`
- `short`
- `ushort`
- <xref:System.Drawing.PointF>
- <xref:System.Drawing.RectangleF>

Windows Forms also supports the following additional types:

- <xref:System.Drawing.Bitmap>
- <xref:System.Windows.Forms.ImageListStreamer>

### OLE scenarios

For information about the effects BinaryFormatter removal has on OLE scenarios such as clipboard and drag-and-drop as well as migration guidance see [Windows Forms and Windows Presentation Foundation BinaryFormatter OLE guidance](./winforms-wpf-ole-guidance.md).

### Resources (ResX)

#### The Windows Forms Designer

The Windows Forms Out-Of-Process Designer also uses [BinaryFormatter] internally for ResX serialization and deserialization.

Types and properties might participate in serialization without you realizing due to the standard behavior of the Windows Forms Designer. One way that BinaryFormatter is used that you might not be aware of is when a `public` property on a <xref:System.ComponentModel.IComponent> is introduced and that property is populated or edited at design time. That property is serialized into resource files under the following conditions:

- A public property contains data at the time when a <xref:System.Windows.Forms.Form> in the Designer is saved.
- That property is not read-only.
- That property is not attributed with `[DesignerSerializationVisibility(false)]`.
- That property does not have a <xref:System.ComponentModel.DefaultValueAttribute>.
- That property does not have a respective `bool ShouldSerialize[PropertyName]` method that returns `false` at the time of the CodeDOM serialization process. (Note: the method can have `private` scope.)
- That property is a type that does not have a <xref:Microsoft.VisualStudio.Modeling.DslDefinition.DesignerSerializer>

If these statements are true, the Designer determines if that property's type has a type converter. If it does, the Designer uses the type converter to serialize the property content. Otherwise, it uses BinaryFormatter to serialize the content into the resource file. Windows Forms has added analyzers along with code fixes to help bring awareness to this type of behavior where BinaryFormatter serialization might be occurring without the developer's knowledge.

#### Loading resource during runtime

Types that had been previously serialized into resource files via [BinaryFormatter] will continue to deserialize as expected without the need for [BinaryFormatter] as the content of ResX files are considered trusted data. In the rare case that deserialization cannot occur without [BinaryFormatter], it can be added back with an unsupported compatibility package. See [BinaryFormatter migration guide: Compatibility Package](compatibility-package.md) for details. Note that an extra step of setting `System.Resources.Extensions.UseBinaryFormatter` app context switch to `true` is required to use [BinaryFormatter] for resources.

##### Generating resource files via MSBuild

When you generate resource files via MSBuild, you might encounter an `MSB3825` error. This error specifies that your binary-formatted resources might be deserialized using [BinaryFormatter] during run time. The warning is being removed from builds targeting .NET 9 and later, however the removal is not yet complete in all releases of .NET 9. The warning should be only of concern when targeting .NET 8 and lower. As stated earlier, these resources will not deserialize using [BinaryFormatter] during run time in .NET 9 and later versions. You can turn the warning off by setting the property `GenerateResourceWarnOnBinaryFormatterUse` to `false`. In rare cases that deserialization cannot occur without [BinaryFormatter], it can be added back with an unsupported compatibility package. For more information, see [BinaryFormatter migration guide: Compatibility package](compatibility-package.md). Note that an additional step of setting the `System.Resources.Extensions.UseBinaryFormatter` app context switch to `true` is required to use [BinaryFormatter] for resources.

## Migrate away from BinaryFormatter

If types that aren't intrinsically handled during serialization and deserialization are used in the affected scenarios, you'll need to take action to complete migration to .NET 9 or a later version.

### OLE scenarios

See [Windows Forms and Windows Presentation Foundation BinaryFormatter OLE guidance](./winforms-wpf-ole-guidance.md) for more information on how to migrate away from BinaryFormatter in scenarios such as clipboard and drag-and-drop.

### Loading and saving resources during design time

For types that aren't intrinsically handled during serialization into resources, such as in the case of the Designer with ResX scenarios, the prescribed way of migrating away from BinaryFormatter is to ensure a `TypeConverter` is registered for the type or property that's participating in serialization. This way, during serialization and deserialization, the `TypeConverter` is used in lieu of where [BinaryFormatter] was once used. For more information on implementing a type converter, see [`TypeConverter` Class](/dotnet/api/system.componentmodel.typeconverter#notes-to-inheritors).

## Compatibility workaround (not recommended)

.NET 9 users who can't migrate away from [BinaryFormatter] can install an unsupported compatibility package. For more information, see [BinaryFormatter migration guide: Compatibility Package](compatibility-package.md).

> [!CAUTION]
> BinaryFormatter is dangerous and not recommended as it puts consuming apps at risk for attacks such as denial of service (DoS), information disclosure, or remote code execution. For more information about the risks [BinaryFormatter] poses, see [Deserialization risks in use of BinaryFormatter and related types](../binaryformatter-security-guide.md).

## Issues

If you experience unexpected behavior with your Windows Forms app regarding BinaryFormatter serialization or deserializing, please file an issue at [github.com/dotnet/winforms](https://github.com/dotnet/winforms/issues) and indicate that the issue is related to the removal of BinaryFormatter.

[BinaryFormatter]: xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
