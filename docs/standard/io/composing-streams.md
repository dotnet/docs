---
title: "Compose streams"
ms.date: "01/03/2019"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "streams, base streams"
  - "I/O [.NET Framework], composing streams"
  - "Stream class, composing streams"
  - "base streams"
  - "streams, backing stores"
ms.assetid: da761658-a535-4f26-a452-b30df47f73d5
author: "mairaw"
ms.author: "mairaw"
---
# Compose streams
A *backing store* is a storage medium, such as a disk or memory. Each different backing store implements its own stream as an implementation of the <xref:System.IO.Stream> class. 

Each stream type reads and writes bytes from and to its given backing store. Streams that connect to backing stores are called *base streams*. Base streams have constructors with the parameters necessary to connect the stream to the backing store. For example, <xref:System.IO.FileStream> has constructors that specify a path parameter, which specifies how the file will be shared by processes.  

The design of the <xref:System.IO> classes provides simplified stream composing. Base streams can be attached to one or more pass-through streams that provide the functionality you want. A reader or writer can be attached to the end of the chain, so that the preferred types can be read or written easily.  

The following code examples create a **FileStream** around the existing *MyFile.txt* in order to buffer *MyFile.txt*. **FileStreams** are buffered by default.

>[!IMPORTANT]
>The examples assume that a file named *MyFile.txt* already exists in the same folder as the app.  

## Example: Use StreamReader
The following example creates a <xref:System.IO.StreamReader> to read characters from the **FileStream**, which is passed to the **StreamReader** as its constructor argument. <xref:System.IO.StreamReader.ReadLine%2A> then reads until <xref:System.IO.StreamReader.Peek%2A> finds no more characters.  
  
 [!code-cpp[System.IO.StreamReader#20](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.IO.StreamReader/CPP/source2.cpp#20)]
 [!code-csharp[System.IO.StreamReader#20](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.StreamReader/CS/source2.cs#20)]
 [!code-vb[System.IO.StreamReader#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.StreamReader/VB/source2.vb#20)]  
  
## Example: Use BinaryReader
The following example creates a <xref:System.IO.BinaryReader> to read bytes from the **FileStream**, which is passed to the **BinaryReader** as its constructor argument. <xref:System.IO.BinaryReader.ReadByte%2A> then reads until <xref:System.IO.BinaryReader.PeekChar%2A> finds no more bytes.  
  
 [!code-cpp[System.IO.StreamReader#21](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.IO.StreamReader/CPP/source3.cpp#21)]
 [!code-csharp[System.IO.StreamReader#21](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.StreamReader/CS/source3.cs#21)]
 [!code-vb[System.IO.StreamReader#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.StreamReader/VB/source3.vb#21)]  
  
## See also

- <xref:System.IO.StreamReader>  
- <xref:System.IO.StreamReader.ReadLine%2A?displayProperty=nameWithType>  
- <xref:System.IO.StreamReader.Peek%2A?displayProperty=nameWithType>  
- <xref:System.IO.FileStream>  
- <xref:System.IO.BinaryReader>  
- <xref:System.IO.BinaryReader.ReadByte%2A?displayProperty=nameWithType>  
- <xref:System.IO.BinaryReader.PeekChar%2A?displayProperty=nameWithType>
