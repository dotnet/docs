---
title: "Asynchronous File I/O"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "streams, synchronous streams"
  - "asynchronous I/O"
  - "synchronous I/O"
  - "streams, asynchronous streams"
  - "I/O [.NET Framework], asynchronous I/O"
  - "Stream class, synchronous I/O"
  - "data streams, asynchronous streams"
  - "Stream class, asynchronous I/O"
  - "multiple I/O requests"
  - "data streams, synchronous streams"
ms.assetid: dbdd55e7-d6b9-4f9e-8abb-ab0edd4457f7
author: "mairaw"
ms.author: "mairaw"
---
# Asynchronous File I/O

Asynchronous operations enable you to perform resource-intensive I/O operations without blocking the main thread. This performance consideration is particularly important in a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app or desktop app where a time-consuming stream operation can block the UI thread and make your app appear as if it is not working.

Starting with the .NET Framework 4.5, the I/O types include async methods to simplify asynchronous operations. An async method contains `Async` in its name, such as <xref:System.IO.Stream.ReadAsync%2A>, <xref:System.IO.Stream.WriteAsync%2A>, <xref:System.IO.Stream.CopyToAsync%2A>, <xref:System.IO.Stream.FlushAsync%2A>, <xref:System.IO.TextReader.ReadLineAsync%2A>, and <xref:System.IO.TextReader.ReadToEndAsync%2A>. These async methods are implemented on stream classes, such as <xref:System.IO.Stream>, <xref:System.IO.FileStream>, and <xref:System.IO.MemoryStream>, and on classes that are used for reading from or writing to streams, such <xref:System.IO.TextReader> and <xref:System.IO.TextWriter>.

In the .NET Framework 4 and earlier versions, you have to use methods such as <xref:System.IO.Stream.BeginRead%2A> and <xref:System.IO.Stream.EndRead%2A> to implement asynchronous I/O operations. These methods are still available in the .NET Framework 4.5 to support legacy code; however, the async methods help you implement asynchronous I/O operations more easily.

C# and Visual Basic each have two keywords for asynchronous programming:

- `Async` (Visual Basic) or `async` (C#) modifier, which is used to mark a method that contains an asynchronous operation.

- `Await` (Visual Basic) or `await` (C#) operator, which is applied to the result of an async method.

To implement asynchronous I/O operations, use these keywords in conjunction with the async methods, as shown in the following examples. For more information, see [Asynchronous programming with async and await (C#)](../../csharp/programming-guide/concepts/async/index.md) or [Asynchronous Programming with Async and Await (Visual Basic)](../../visual-basic/programming-guide/concepts/async/index.md).

The following example demonstrates how to use two <xref:System.IO.FileStream> objects to copy files asynchronously from one directory to another. Notice that the <xref:System.Web.UI.WebControls.Button.Click> event handler for the <xref:System.Windows.Controls.Button> control is marked with the `async` modifier because it calls an asynchronous method.

[!code-csharp[Asynchronous_File_IO_async#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Asynchronous_File_IO_async/cs/example.cs#1)]
[!code-vb[Asynchronous_File_IO_async#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Asynchronous_File_IO_async/vb/example.vb#1)]

The next example is similar to the previous one but uses <xref:System.IO.StreamReader> and <xref:System.IO.StreamWriter> objects to read and write the contents of a text file asynchronously.

[!code-csharp[Asynchronous_File_IO_async#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Asynchronous_File_IO_async/cs/example2.cs#2)]
[!code-vb[Asynchronous_File_IO_async#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Asynchronous_File_IO_async/vb/example2.vb#2)]

The next example shows the code-behind file and the XAML file that are used to open a file as a <xref:System.IO.Stream> in a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, and read its contents by using an instance of the <xref:System.IO.StreamReader> class. It uses asynchronous methods to open the file as a stream and to read its contents.

[!code-csharp[System.IO.WindowsRuntimeStorageExtensions#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.windowsruntimestorageextensions/cs/blankpage.xaml.cs#2)]
[!code-vb[System.IO.WindowsRuntimeStorageExtensions#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.windowsruntimestorageextensions/vb/blankpage.xaml.vb#2)]

[!code-xaml[System.IO.WindowsRuntimeStorageExtensions#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.io.windowsruntimestorageextensions/cs/blankpage.xaml#1)]

## See also

- <xref:System.IO.Stream>
- [File and Stream I/O](index.md)
- [Asynchronous programming with async and await (C#)](../../csharp/programming-guide/concepts/async/index.md)
- [Asynchronous Programming with Async and Await (Visual Basic)](../../visual-basic/programming-guide/concepts/async/index.md)
