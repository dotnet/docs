---
title: "How to: Write text to a file"
ms.date: "01/04/2019"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "writing text to files"
  - "I/O [.NET Framework], writing text to files"
  - "streams, writing text to files"
  - "data streams, writing text to files"
ms.assetid: 060cbe06-2adf-4337-9e7b-961a5c840208
author: "mairaw"
ms.author: "mairaw"
---
# How to: Write text to a file
This topic shows different ways to write text to a file for a .NET app. 

The following classes and methods are typically used to write text to a file:  
  
-   <xref:System.IO.StreamWriter> contains methods to write to a file synchronously (<xref:System.IO.StreamWriter.Write%2A> and <xref:System.IO.TextWriter.WriteLine%2A>) or asynchronously (<xref:System.IO.StreamWriter.WriteAsync%2A> and <xref:System.IO.StreamWriter.WriteLineAsync%2A>).  
  
-   <xref:System.IO.File> provides static methods to write text to a file, such as <xref:System.IO.File.WriteAllLines%2A> and <xref:System.IO.File.WriteAllText%2A>, or to append text to a file, such as <xref:System.IO.File.AppendAllLines%2A>, <xref:System.IO.File.AppendAllText%2A>, and <xref:System.IO.File.AppendText%2A>.  
  
- <xref:System.IO.Path> is for strings that have file or directory path information. It contains the <xref:System.IO.Path.Combine%2A> method and, in .NET Core 2.1 and later, the <xref:System.IO.Path.Join%2A> and <xref:System.IO.Path.TryJoin%2A> methods, which allow concatenation of strings to build a file or directory path.

> [!NOTE]
> The following examples show only the minimum amount of code needed. A real-world app usually provides more robust error checking and exception handling.  
  
## Example: Synchronously write text with StreamWriter

The following example shows how to use the <xref:System.IO.StreamWriter> class to synchronously write text to a new file one line at a time. Because the <xref:System.IO.StreamWriter> object is declared and instantiated in a `using` statement, the <xref:System.IO.StreamWriter.Dispose%2A> method is invoked, which automatically flushes and closes the stream.  

[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/write.cs)] 
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/write.vb)]  

## Example: Synchronously append text with StreamWriter

The following example shows how to use the <xref:System.IO.StreamWriter> class to synchronously append text to the text file created in the first example.   

[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/append.cs)] 
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/append.vb)]  

## Example: Asynchronously write text with StreamWriter

The following example shows how to asynchronously write text to a new file using the <xref:System.IO.StreamWriter> class. To invoke the <xref:System.IO.StreamWriter.WriteAsync%2A> method, the method call must be within an `async` method. The C# example requires C# 7.1 or later, which adds support for the `async` modifier on the program entry point. 

[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/async.cs)] 
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/async.vb)]  

## Example: Write and append text with the File class

The following example shows how to write text to a new file and append new lines of text to the same file using the <xref:System.IO.File> class. The <xref:System.IO.File.WriteAllText%2A> and <xref:System.IO.File.AppendAllLines%2A> methods open and close the file automatically. If the path you provide to the <xref:System.IO.File.WriteAllText%2A> method already exists, the file is overwritten.  

[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/file.cs)] 
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/file.vb)]  

## See also

- <xref:System.IO.StreamWriter>
- <xref:System.IO.Path>
- <xref:System.IO.File.CreateText%2A?displayProperty=nameWithType>
- [How to: Enumerate directories and files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)
- [How to: Read and write to a newly-created data file](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)
- [How to: Open and append to a log file](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)
- [How to: Read text from a file](../../../docs/standard/io/how-to-read-text-from-a-file.md)
- [File and stream I/O](../../../docs/standard/io/index.md)