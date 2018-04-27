---
title: "How to: Read Text from a File"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
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
caps.latest.revision: 23
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Read Text from a File
The following examples show how to read text synchronously and asynchronously from a text file using .NET for desktop apps. In both examples, when you create the instance of the <xref:System.IO.StreamReader> class, you provide the relative or absolute path to the file. The following examples assume that the file named TestFile.txt is in the same folder as the application.  
  
 These code examples do not apply developing for Windows Store Apps because the Windows Runtime provides different streams types reading and writing to files. For an example that shows how to read text from a file within the context of a Windows Store app, see [Quickstart: Reading and writing files](http://msdn.microsoft.com/library/windows/apps/hh758325.aspx). For examples that show how to convert between .NET Framework streams and Windows runtime streams see [How to: Convert Between .NET Framework Streams and Windows Runtime Streams](../../../docs/standard/io/how-to-convert-between-dotnet-streams-and-winrt-streams.md).  
  
## Example  
 The first example shows a synchronous read operation within a console application. In this example, the text file is opened using a stream reader, the contents are copied to a string and string is output to the console.  
  
 [!code-csharp[Conceptual.BasicIO.TextFiles#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/source3.cs#3)]
 [!code-vb[Conceptual.BasicIO.TextFiles#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/source3.vb#3)]  
  
## Example  
 The second example shows an asynchronous read operation within a Windows Presentation Foundation (WPF) application.  
  
 [!code-csharp[Conceptual.BasicIO.TextFiles#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/source6.cs#6)]
 [!code-vb[Conceptual.BasicIO.TextFiles#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/source6.vb#6)]  
  
## See Also  
 <xref:System.IO.StreamReader>  
 <xref:System.IO.File.OpenText%2A?displayProperty=nameWithType>  
 <xref:System.IO.StreamReader.ReadLine%2A?displayProperty=nameWithType>  
 [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
 [NIB: How to: Create a Directory Listing](https://msdn.microsoft.com/library/4d2772b1-b991-4532-a8a6-6ef733277e69)  
 [Quickstart: Reading and writing files](http://msdn.microsoft.com/library/windows/apps/hh758325.aspx)  
 [How to: Convert Between .NET Framework Streams and Windows Runtime Streams](../../../docs/standard/io/how-to-convert-between-dotnet-streams-and-winrt-streams.md)  
 [How to: Read and Write to a Newly Created Data File](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
 [How to: Open and Append to a Log File](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
 [How to: Write Text to a File](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
 [How to: Read Characters from a String](../../../docs/standard/io/how-to-read-characters-from-a-string.md)  
 [How to: Write Characters to a String](../../../docs/standard/io/how-to-write-characters-to-a-string.md)  
 [File and Stream I-O](../../../docs/standard/io/index.md)
