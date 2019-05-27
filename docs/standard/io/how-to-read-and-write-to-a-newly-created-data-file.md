---
title: "How to: Read and write to a newly created data file"
ms.date: "01/21/2019"
ms.technology: dotnet-standard
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
author: "mairaw"
ms.author: "mairaw"
---
# How to: Read and write to a newly created data file
The <xref:System.IO.BinaryWriter?displayProperty=nameWithType> and <xref:System.IO.BinaryReader?displayProperty=nameWithType> classes are used for writing and reading data other than character strings. The following example shows how to create an empty file stream, write data to it, and read data from it. 

The example creates a data file called *Test.data* in the current directory, creates the associated <xref:System.IO.BinaryWriter> and <xref:System.IO.BinaryReader> objects, and uses the <xref:System.IO.BinaryWriter> object to write the integers 0 through 10 to *Test.data*, which leaves the file pointer at the end of the file. The <xref:System.IO.BinaryReader> object then sets the file pointer back to the origin and reads out the specified content.  
  
> [!NOTE]
> If *Test.data* already exists in the current directory, an <xref:System.IO.IOException> exception is thrown. Use the file mode option <xref:System.IO.FileMode.Create?displayProperty=nameWithType> rather than <xref:System.IO.FileMode.CreateNew?displayProperty=nameWithType> to always create a new file without throwing an exception.  
  
## Example  
 [!code-csharp[System.IO.BinaryReaderWriter#7](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.BinaryReaderWriter/CS/source6.cs#7)]
 [!code-vb[System.IO.BinaryReaderWriter#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.BinaryReaderWriter/VB/source6.vb#7)]  
  
## See also

- <xref:System.IO.BinaryReader>  
- <xref:System.IO.BinaryWriter>  
- <xref:System.IO.FileStream>  
- <xref:System.IO.FileStream.Seek%2A?displayProperty=nameWithType>  
- <xref:System.IO.SeekOrigin>  
- [How to: Enumerate directories and files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)  
- [How to: Open and append to a log file](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
- [How to: Read text from a file](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
- [How to: Write text to a file](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
- [How to: Read characters from a string](../../../docs/standard/io/how-to-read-characters-from-a-string.md)  
- [How to: Write characters to a string](../../../docs/standard/io/how-to-write-characters-to-a-string.md)  
- [File and stream I/O](../../../docs/standard/io/index.md)
