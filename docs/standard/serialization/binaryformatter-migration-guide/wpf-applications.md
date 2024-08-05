---
title: "BinaryFormatter migration guide: WPF applications"
description: "Learn about the effects of the deprecation and removal of BinaryFormatter from .NET on Windows Forms and how to migrate."
ms.date: 8/05/2024
no-loc: [BinaryFormatter, WPF]
helpviewer_keywords:
  - "BinaryFormatter"
  - "WPF"
---

# WPF Migration Guide – Binary Formatter 

 
## Binary Formatter Removal 

In .NET 9.0, the entire `Binaryformatter` infrastructure will be removed from the product and moved as a separate Nuget  package. For more information about the risks `Binaryformatter` poses and our decision on its removal, see [BinaryFormatter migration guide](index.md). 

 
## How Binary Formatter affects WPF 

WPF uses `Binaryformatter` to serialize/deserialize the data for scenarios such clipboard, drag/drop and store data for Avalon Binding in Journal.  

WPF has and is still currently using `Binaryformatter` code internally for all the above scenarios, however we have taken some measures to mitigate the usage of `Binaryformatter`.  

We have added an implementation based on WinForms to handle common primitive types, including primitive arrays and lists. Usage of these types in the mentioned scenarios will continue to work without using `Binaryformatter`, similarly as before. 

Primitive types include: 
- `bool` 
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
- `long` 
- `ulong` 

Additional types include: 
- `PointF` 
- `RectangleF`  
  
## Where Binary Formatter is used in WPF 

### Clipboard  

In WPF application if you are using a clipboard to copy or paste the data into the application or Set/Get data from a DataObject or using drag/drop. 

If the data format ([DataFromats](https://learn.microsoft.com/en-us/dotnet/api/system.windows.dataformats?view=windowsdesktop-8.0)) is part of the following list, it will not require BinaryFormatter to handle: 
- `Stream` 
- `Text`, `Rtf`, `OemText`, `CommaSeparatedValue` 
- `UnicodeText` 
- `FileDrop` 
- `FileName` 
- `BitmapSource` 

Apart from these formats, if the type is serializable and not included in the above list of types handled by the new implementation, `Binaryformatter` will be used for handling. 

In scenarios where `Binaryformatter` is utilized, its removal will result in developers encountering an exception indicating that `Binaryformatter` has been removed. 

You can refer to the function where we have used `Binaryformatter` as fallback to read/save object to handle:  [SaveObjectToHandle](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/dataobject.cs#L1677) and  [ReadObjectFromHandle](https://github.com/dotnet/wpf/blob/0354a597996adae43b12efc72bd705f76d4ba497/src/Microsoft.DotNet.Wpf/src/PresentationCore/System/Windows/dataobject.cs#L3051) 

Additionally, if you encounter an exception stating, 'Data stored in clipboard is invalid,' it may be because `Binaryformatter` was used to save the data. 

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