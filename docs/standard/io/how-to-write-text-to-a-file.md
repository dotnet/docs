---
title: "How to: Write text to a file"
description: Learn ways to write or append text to a file for a .NET app. Use methods from the StreamWriter or File classes to write text synchronously or asynchronously.
ms.date: "10/21/2025"
ms.custom: devdivchpfy22
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "writing text to files"
  - "I/O [.NET], writing text to files"
  - "streams, writing text to files"
  - "data streams, writing text to files"
ms.assetid: 060cbe06-2adf-4337-9e7b-961a5c840208
ai-usage: ai-assisted
---
# How to: Write text to a file

This article shows different ways to write text to a file for a .NET app.

The following classes and methods are typically used to write text to a file:

- <xref:System.IO.StreamWriter> contains methods to write to a file synchronously (<xref:System.IO.StreamWriter.Write*> and <xref:System.IO.TextWriter.WriteLine*>) or asynchronously (<xref:System.IO.StreamWriter.WriteAsync*> and <xref:System.IO.StreamWriter.WriteLineAsync*>).

- <xref:System.IO.File> provides static methods to write text to a file such as <xref:System.IO.File.WriteAllLines*> and <xref:System.IO.File.WriteAllText*>, or to append text to a file such as <xref:System.IO.File.AppendAllLines*>, <xref:System.IO.File.AppendAllText*>, and <xref:System.IO.File.AppendText*>.

- <xref:System.IO.Path> is for strings that have file or directory path information. It contains the <xref:System.IO.Path.Combine*> method and in .NET Core 2.1 and later, the <xref:System.IO.Path.Join*> and <xref:System.IO.Path.TryJoin*> methods. These methods let you concatenate strings for building a file or directory path.

> [!NOTE]
> The following examples show only the minimum amount of code needed. A real-world app usually provides more robust error checking and exception handling.

## Example: Synchronously write text with StreamWriter

The following example shows how to use the <xref:System.IO.StreamWriter> class to synchronously write text to a new file one line at a time. Because the <xref:System.IO.StreamWriter> object is declared and instantiated in a `using` statement, the <xref:System.IO.StreamWriter.Dispose*> method is invoked, which automatically flushes and closes the stream.

[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/write.cs)]
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/write.vb)]

## Example: Synchronously append text with StreamWriter

The following example shows how to use the <xref:System.IO.StreamWriter> class to synchronously append text to the text file created in the first example:

[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/append.cs)]
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/append.vb)]

## Example: Asynchronously write text with StreamWriter

The following example shows how to asynchronously write text to a new file using the <xref:System.IO.StreamWriter> class. To invoke the <xref:System.IO.StreamWriter.WriteAsync*> method, the method call must be within an `async` method.

[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/async.cs)]
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/async.vb)]

## Example: Write and append text with the File class

The following example shows how to write text to a new file and append new lines of text to the same file using the <xref:System.IO.File> class. The <xref:System.IO.File.WriteAllText*> and <xref:System.IO.File.AppendAllLines*> methods open and close the file automatically. If the path you provide to the <xref:System.IO.File.WriteAllText*> method already exists, the file is overwritten.

[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/file.cs)]
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/file.vb)]

## See also

- <xref:System.IO.StreamWriter>
- <xref:System.IO.Path>
- <xref:System.IO.File.CreateText*?displayProperty=nameWithType>
- [How to: Enumerate directories and files](how-to-enumerate-directories-and-files.md)
- [How to: Read and write to a newly created data file](how-to-read-and-write-to-a-newly-created-data-file.md)
- [How to: Open and append to a log file](how-to-open-and-append-to-a-log-file.md)
- [How to: Read text from a file](how-to-read-text-from-a-file.md)
- [File and stream I/O](index.md)
