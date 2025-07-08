---
title: "BinaryFormatter migration guide: WPF apps"
description: "Learn about the effects of the deprecation and removal of BinaryFormatter from .NET on WPF and how to migrate."
ms.date: 8/05/2024
no-loc: [BinaryFormatter, WPF]
helpviewer_keywords:
  - "BinaryFormatter"
  - "WPF"
---

# Windows Presentation Foundation(WPF) migration guide for BinaryFormatter

## BinaryFormatter removal

Starting with .NET 9, [BinaryFormatter] is no longer supported due to its known [security risks](../binaryformatter-security-guide.md) and its APIs always throw a <xref:System.PlatformNotSupportedException> for all project types, including WPF apps. For more information about the risks [BinaryFormatter] poses and the reason for its removal, see the [BinaryFormatter migration guide](index.md).

With [BinaryFormatter]’s removal, it's expected that many WPF applications will be impacted, and you'll need to take action to complete your migration to .NET 9 or a later version.

## How BinaryFormatter affects WPF

Prior to .NET 9, Windows Presentation Foundation (WPF) used [BinaryFormatter] to serialize and deserialize data for scenarios such clipboard, drag-and-drop, and load/store state in Journal. Starting with .NET 9, WPF and Windows Forms use a subset of the [BinaryFormatter] implementation internally for these scenarios. While [BinaryFormatter]'s risks cannot be addressed in general-purpose serialization/deserialization, measures have been taken to mitigate the risks in these very specific use cases with a known set of types. A fall-back to [BinaryFormatter] is still in place for unknown or unsupported types, which will throw a <xref:System.PlatformNotSupportedException> unless migration steps are taken in the application.

WPF and WinForms apps both handle the following types, along with arrays and lists of these types. Clipboard, drag-and-drop, and Avalon Binding in Journal will continue to work with these types without any migration steps needed.

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

### OLE Scenarios

For information about the effects [BinaryFormatter] removal has on OLE scenarios such as clipboard and drag-and-drop as well as migration guidance see [Windows Forms and Windows Presentation Foundation BinaryFormatter OLE guidance](./winforms-wpf-ole-guidance.md).

You can refer to the function where we have used [BinaryFormatter] as fallback to read/save object to handle: [SaveObjectToHandle](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/dataobject.cs#L1677) and [ReadObjectFromHandle](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/dataobject.cs#L3051) for OLE scenarios

### Journaling

In the case when we need to store or load a state while managing the navigation history in WPF.

To load/save we call [LoadSubStreams](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationFramework/MS/Internal/DataStreams.cs#L244)/ [SaveSubStreams](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationFramework/MS/Internal/DataStreams.cs#L86) of `DataStream` class. If the element used in not part of know type handled by the new implementation, it will use [BinaryFormatter].

When a developer navigates through JournalEntry using `Navigate`, `GoForward`, or `GoBack`, the node's data is loaded or saved to a stream to save the state. If the type involved is not intrinsically handled during serialization/deserialization, [BinaryFormatter] is used.

Ref: [DataStream.cs](https://github.com/dotnet/wpf/blob/4e977f5fe8c73094ee5826dbfa7a0f37c3bf0e33/src/Microsoft.DotNet.Wpf/src/PresentationFramework/MS/Internal/DataStreams.cs)

### Compatibility Workaround (Not Recommended)

.NET 9 users who can't migrate away from [BinaryFormatter] can install an unsupported compatibility package. For more information, see [BinaryFormatter migration guide: Compatibility Package](compatibility-package.md).

> [!CAUTION]
> [BinaryFormatter] is dangerous and not recommended as it puts consuming apps at risk for attacks such as denial of service (DoS), information disclosure, or remote code execution. For more information about the risks [BinaryFormatter] poses, see [Deserialization risks in use of BinaryFormatter and related types](../binaryformatter-security-guide.md).

### Issues

If you experience unexpected behavior with your WPF application regarding [BinaryFormatter], please file an issue at [dotnet/wpf/issues](https://github.com/dotnet/wpf/issues) and indicate that the issue is related to the removal of [BinaryFormatter].

[BinaryFormatter]: xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
