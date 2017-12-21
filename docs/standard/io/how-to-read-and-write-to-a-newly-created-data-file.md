---
title: "How to: Read and Write to a Newly Created Data File"
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
  - "cpp"
helpviewer_keywords: 
  - "streams, reading and writing data"
  - "BinaryReader class, examples"
  - "I/O [.NET Framework], reading data"
  - "I/O [.NET Framework], writing data"
  - "BinaryWriter class, examples"
ms.assetid: e209d949-31e8-44ea-8e38-87f9093f3093
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Read and Write to a Newly Created Data File
The <xref:System.IO.BinaryWriter> and <xref:System.IO.BinaryReader?displayProperty=nameWithType> classes are used for writing and reading data rather than character strings. The following example demonstrates how to write data to, and read data from, a new, empty file stream called `Test.data`. After creating the data file in the current directory, the associated <xref:System.IO.BinaryWriter> and <xref:System.IO.BinaryReader> objects are created, and the <xref:System.IO.BinaryWriter> object is used to write the integers 0 through 10 to `Test.data`, which leaves the file pointer at the end of the file. After setting the file pointer back to the origin, the <xref:System.IO.BinaryReader> object reads out the specified content.  
  
## Example  
 [!code-cpp[System.IO.BinaryReaderWriter#7](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.IO.BinaryReaderWriter/CPP/source6.cpp#7)]
 [!code-csharp[System.IO.BinaryReaderWriter#7](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.BinaryReaderWriter/CS/source6.cs#7)]
 [!code-vb[System.IO.BinaryReaderWriter#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.BinaryReaderWriter/VB/source6.vb#7)]  
  
## Robust Programming  
 If `Test.data` already exists in the current directory, an <xref:System.IO.IOException> exception is thrown. Use the file mode option <xref:System.IO.FileMode.Create?displayProperty=nameWithType> when you initialize the file stream to always create a new file without throwing an  exception.  
  
## See Also  
 <xref:System.IO.BinaryReader>  
 <xref:System.IO.BinaryWriter>  
 <xref:System.IO.FileStream>  
 <xref:System.IO.FileStream.Seek%2A?displayProperty=nameWithType>  
 <xref:System.IO.SeekOrigin>  
 [How to: Enumerate Directories and Files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)  
 [How to: Open and Append to a Log File](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
 [How to: Read Text from a File](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
 [How to: Write Text to a File](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
 [How to: Read Characters from a String](../../../docs/standard/io/how-to-read-characters-from-a-string.md)  
 [How to: Write Characters to a String](../../../docs/standard/io/how-to-write-characters-to-a-string.md)  
 [File and Stream I-O](../../../docs/standard/io/index.md)
