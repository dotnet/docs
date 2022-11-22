---
title: "How to: Read text from a file"
description: In this article, see examples of how to read text synchronously or asynchronously from a text file, using the StreamReader class in .NET for desktop apps.
ms.date: "07/29/2022"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "streams, reading text from files"
  - "reading text files"
  - "reading data, text files"
  - "data streams, reading text from files"
  - "I/O [.NET], reading text from files"
ms.assetid: ed180baa-dfc6-4c69-a725-46e87edafb27
---
# How to: Read text from a file

The following examples show how to read text synchronously and asynchronously from a text file using .NET for desktop apps. In both examples, when you create the instance of the <xref:System.IO.StreamReader> class, you provide the relative or absolute path to the file.
  
> [!NOTE]
> These code examples don't apply to Universal Windows (UWP) apps because the Windows runtime provides different stream types for reading and writing to files. For an example that shows how to read text from a file in a UWP app, see [Quickstart: Reading and writing files](/previous-versions/windows/apps/hh758325(v=win.10)). For examples that show how to convert between .NET Framework streams and Windows Runtime streams, see [How to: Convert between .NET Framework streams and Windows Runtime streams](how-to-convert-between-dotnet-streams-and-winrt-streams.md).  
  
## Example: Synchronous read in a console app  

The following example shows a synchronous read operation within a console app. This example opens the text file using a stream reader, copies the contents to a string, and outputs the string to the console.  
  
> [!IMPORTANT]
> The example assumes that a file named *TestFile.txt* already exists in the same folder as the app.  

:::code language="csharp" source="snippets/how-to-read-text-from-a-file/csharp/sync-console/Program.cs":::
:::code language="vb" source="snippets/how-to-read-text-from-a-file/vb/sync-console/Program.vb":::
  
## Example: Asynchronous read in a WPF app

 The following example shows an asynchronous read operation in a Windows Presentation Foundation (WPF) app.  
  
> [!IMPORTANT]
> The example assumes that a file named *TestFile.txt* already exists in the same folder as the app.  

:::code language="csharp" source="snippets/how-to-read-text-from-a-file/csharp/async-wpf/MainWindow.xaml.cs":::
:::code language="vb" source="snippets/how-to-read-text-from-a-file/vb/async-wpf/MainWindow.xaml.vb":::
  
## See also

- <xref:System.IO.StreamReader>  
- <xref:System.IO.File.OpenText%2A?displayProperty=nameWithType>  
- <xref:System.IO.StreamReader.ReadLine%2A?displayProperty=nameWithType>  
- [Asynchronous file I/O](asynchronous-file-i-o.md)  
- [How to: Create a directory listing](/previous-versions/dotnet/netframework-4.0/5cf8zcfh(v=vs.100))  
- [Quickstart: Reading and writing files](/previous-versions/windows/apps/hh758325(v=win.10))  
- [How to: Convert between .NET Framework streams and Windows Runtime streams](how-to-convert-between-dotnet-streams-and-winrt-streams.md)  
- [How to: Read and write to a newly created data file](how-to-read-and-write-to-a-newly-created-data-file.md)  
- [How to: Open and append to a log file](how-to-open-and-append-to-a-log-file.md)  
- [How to: Write text to a file](how-to-write-text-to-a-file.md)  
- [How to: Read characters from a string](how-to-read-characters-from-a-string.md)  
- [How to: Write characters to a string](how-to-write-characters-to-a-string.md)  
- [File and stream I/O](index.md)
