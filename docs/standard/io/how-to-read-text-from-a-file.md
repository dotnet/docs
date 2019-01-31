---
title: "How to: Read text from a file"
ms.date: "01/03/2019"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "streams, reading text from files"
  - "reading text files"
  - "reading data, text files"
  - "data streams, reading text from files"
  - "I/O [.NET Framework], reading text from files"
ms.assetid: ed180baa-dfc6-4c69-a725-46e87edafb27
author: "mairaw"
ms.author: "mairaw"
---
# How to: Read text from a file
The following examples show how to read text synchronously and asynchronously from a text file using .NET for desktop apps. In both examples, when you create the instance of the <xref:System.IO.StreamReader> class, you provide the relative or absolute path to the file. 
  
> [!NOTE]
> These code examples do not apply to developing for Universal Windows (UWP) apps, because the Windows Runtime provides different stream types for reading and writing to files. For an example that shows how to read text from a file in a UWP app, see [Quickstart: Reading and writing files](https://docs.microsoft.com/previous-versions/windows/apps/hh758325(v=win.10)). For examples that show how to convert between .NET Framework streams and Windows Runtime streams, see [How to: Convert between .NET Framework streams and Windows Runtime streams](../../../docs/standard/io/how-to-convert-between-dotnet-streams-and-winrt-streams.md).  
  
## Example: Synchronous read in a console app  
The following example shows a synchronous read operation within a console app. This example opens the text file using a stream reader, copies the contents to a string, and outputs the string to the console.  
  
> [!IMPORTANT]
> The example assumes that a file named *TestFile.txt* already exists in the same folder as the app.  

 [!code-csharp[Conceptual.BasicIO.TextFiles#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/source3.cs#3)]
 [!code-vb[Conceptual.BasicIO.TextFiles#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/source3.vb#3)]  
  
## Example: Asynchronous read in a WPF app 
 The following example shows an asynchronous read operation in a Windows Presentation Foundation (WPF) app.  
  
> [!IMPORTANT]
> The example assumes that a file named *TestFile.txt* already exists in the same folder as the app.  

 [!code-csharp[TextFiles](../../../samples/snippets/csharp/VS_Snippets_Wpf/TextFiles/MainWindow.xaml.cs)]
 [!code-vb[TextFiles](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TextFiles/MainWindow.xaml.vb)]  
  
## See also

- <xref:System.IO.StreamReader>  
- <xref:System.IO.File.OpenText%2A?displayProperty=nameWithType>  
- <xref:System.IO.StreamReader.ReadLine%2A?displayProperty=nameWithType>  
- [Asynchronous file I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
- [How to: Create a directory listing](https://msdn.microsoft.com/library/4d2772b1-b991-4532-a8a6-6ef733277e69)  
- [Quickstart: Reading and writing files](https://docs.microsoft.com/previous-versions/windows/apps/hh758325%28v=win.10%29)  
- [How to: Convert between .NET Framework streams and Windows Runtime streams](../../../docs/standard/io/how-to-convert-between-dotnet-streams-and-winrt-streams.md)  
- [How to: Read and write to a newly created data file](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
- [How to: Open and append to a log file](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
- [How to: Write text to a file](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
- [How to: Read characters from a string](../../../docs/standard/io/how-to-read-characters-from-a-string.md)  
- [How to: Write characters to a string](../../../docs/standard/io/how-to-write-characters-to-a-string.md)  
- [File and stream I/O](../../../docs/standard/io/index.md)
