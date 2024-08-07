---
title: "BinaryFormatter migration guide: WPF applications"
description: "Learn about the effects of the deprecation and removal of BinaryFormatter from .NET on WPF and how to migrate."
ms.date: 8/05/2024
no-loc: [BinaryFormatter, WPF]
helpviewer_keywords:
  - "BinaryFormatter"
  - "WPF"
---

# WPF migration guide for BinaryFormatter

## BinaryFormatter removal 

In .NET 9, the entire `BinaryFormatter` infrastructure was removed from the product and moved into a separate NuGet  package. For more information about the risks `Binaryformatter` poses and the decision on its removal, see [BinaryFormatter migration guide](index.md). 

 
## How BinaryFormatter affects WPF

Windows Presentation Foundation (WPF) uses `BinaryFormatter` to serialize and deserialize data for scenarios such clipboard and drag-and-drop, and to store data for Avalon Binding in Journal.  

WPF has and still currently uses `Binaryformatter` code internally for all of the previously mentioned scenarios. However, WPF has taken some measures to mitigate its use.  

WPF has added an implementation based on Windows Forms to handle common primitive types, including primitive arrays and lists. Usage of these types in the mentioned scenarios will continue to work without using `BinaryFormatter`, similarly as before. 

Primitive types include:

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

Additional types include:

- `PointF` 
- `RectangleF`  
  
## Where BinaryFormatter is used in WPF

### Clipboard  

`BinaryFormatter` is used in WPF apps if you're using a clipboard to copy or paste the data into the application, or to set or get data from a `DataObject` or using drag-and-drop. 

If the [data format](/dotnet/api/system.windows.dataformats) is included in the following list, it doesn't require using `BinaryFormatter` to handle:

- `Stream` 
- `Text`, `Rtf`, `OemText`, `CommaSeparatedValue` 
- `UnicodeText` 
- `FileDrop` 
- `FileName` 
- `BitmapSource` 

However, if the type is serializable and not included in the previous list of types that are handled by the new implementation, `BinaryFormatter` is used. 

In scenarios where `BinaryFormatter` is used, its removal will result in a run-time exception that indicates that `BinaryFormatter` has been removed. 

You can refer to the function where we have used `Binaryformatter` as fallback to read/save object to handle:  [SaveObjectToHandle](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/dataobject.cs#L1677) and  [ReadObjectFromHandle](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/dataobject.cs#L3051) 

Additionally, if you encounter an exception that states "Data stored in clipboard is invalid," it might be because `BinaryFormatter` was used to save the data. 

Ref: [DataObject.cs](https://github.com/dotnet/wpf/blob/4e977f5fe8c73094ee5826dbfa7a0f37c3bf0e33/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/dataobject.cs) 

 

### Drag/Drop 

In drag/drop any UI element or Content element can participate, for an event is raised which is defined in [DragDrop.cs](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/DragDrop.cs). In the Drag/Drop operation a DataObject is used to store the data and to Get/Set data we call `GetData()`/`SetData()`. In this scenario if the type involved is not intrinsically handled during serialization/deserialization, `Binaryformatter` is used. 

With `Binaryformatter` removed, developers will now encounter an exception indicating that `Binaryformatter` has been removed. 
	 

### Journaling 

In the case when we need to store or load a state while managing the navigation history in WPF. 

To load/save we call [LoadSubStreams](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationFramework/MS/Internal/DataStreams.cs#L244)/ [SaveSubStreams](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationFramework/MS/Internal/DataStreams.cs#L86) of DataStream class. If the element used in not part of know type handled by the new implementation, it will use `Binaryformatter`. 

When a developer navigates through JournalEntry using `Navigate`,`GoForward`,or `GoBack`, the node's data is loaded or saved to a stream. If the type involved is not intrinsically handled during serialization/deserialization, `Binaryformatter` is used. 

Ref: [DataStream.cs](https://github.com/dotnet/wpf/blob/4e977f5fe8c73094ee5826dbfa7a0f37c3bf0e33/src/Microsoft.DotNet.Wpf/src/PresentationFramework/MS/Internal/DataStreams.cs)

 

### Compatibility Workaround (Not Recommended) 

For users who cannot migrate away from `BinaryFormatter` for whatever reason, `BinaryFormatter` can be added back for compatibility. For more information, see [BinaryFormatter migration guide: Compatibility Package](compatibility-package.md). 

> [!CAUTION]
> BinaryFormatter is dangerous and not recommended as it puts consuming apps at risk for attacks such as denial of service, which can render the app unresponsive and or unexpectedly terminate it. For more information about the risks `BinaryFormatter` poses, see [Deserialization risks in use of BinaryFormatter and related types](../binaryformatter-security-guide.md).

### Issues
If you experiance unexpected behaviour with your WPF application regarding `Binaryformatter`, please file an issue at [dotnet/wpf/issues](https://github.com/dotnet/wpf/issues)