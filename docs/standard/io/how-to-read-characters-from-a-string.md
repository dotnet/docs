---
title: "How to: Read characters from a string"
ms.date: "01/21/2019"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "reading characters from strings"
  - "data streams, reading characters from string"
  - "I/O [.NET Framework], reading characters from strings"
  - "reading data, strings"
  - "streams, reading characters from string"
ms.assetid: 27ea5e52-6db8-42d8-980a-50bcfc7fd270
author: "mairaw"
ms.author: "mairaw"
---
# How to: Read characters from a string
The following code examples show how to read characters synchronously or asynchronously from a string.  
  
## Example: Read characters synchronously 
 This example reads 13 characters synchronously from a string, stores them in an array, and displays them. The example then reads the rest of the characters in the string, stores them in the array starting at the sixth element, and displays the contents of the array.  
  
 [!code-csharp[Conceptual.StringReader#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.stringreader/cs/source.cs#1)]
 [!code-vb[Conceptual.StringReader#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.stringreader/vb/source.vb#1)]  
  
## Example: Read characters asynchronously  
 The next example is the code behind a WPF app. On window load, the example asynchronously reads all characters from a <xref:System.Windows.Controls.TextBox> control and stores them in an array. It then asynchronously writes each letter or white-space character to a separate line of a <xref:System.Windows.Controls.TextBlock> control.  
  
 [!code-csharp[Conceptual.StringReader#2](../../../samples/snippets/csharp/VS_Snippets_Wpf/StringReaderWriter/MainWindow.xaml.cs)]
 [!code-vb[Conceptual.StringReader#2](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/StringReaderWriter/MainWindow.xaml.vb)]  
  
## See also

- <xref:System.IO.StringReader>  
- <xref:System.IO.StringReader.Read%2A?displayProperty=nameWithType>  
- [Asynchronous file I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
- [How to: Create a directory listing](https://msdn.microsoft.com/library/4d2772b1-b991-4532-a8a6-6ef733277e69)  
- [How to: Read and write to a newly created data file](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
- [How to: Open and append to a log file](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
- [How to: Read text from a file](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
- [How to: Write text to a file](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
- [How to: Write characters to a string](../../../docs/standard/io/how-to-write-characters-to-a-string.md)  
- [File and stream I/O](../../../docs/standard/io/index.md)
