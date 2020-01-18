---
title: "How to: Write characters to a string"
ms.date: "01/21/2019"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "data streams, writing characters to string"
  - "writing characters to strings"
  - "streams, writing characters to strings"
  - "I/O [.NET Framework], writing characters to strings"
ms.assetid: 1222cbeb-0760-44bf-9888-914a2a37174b
---
# How to: Write characters to a string
The following code examples write characters synchronously or asynchronously from a character array into a string.  
  
## Example: Write characters synchronously in a console app  
 The following example uses a <xref:System.IO.StringWriter> to write five characters synchronously to a <xref:System.Text.StringBuilder> object. 
  
 [!code-csharp[Conceptual.StringBuilder#9](../../../samples/snippets/csharp/VS_Snippets_CLR/Conceptual.StringBuilder/cs/example2.cs#9)]
 [!code-vb[Conceptual.StringBuilder#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Conceptual.StringBuilder/vb/example2.vb#9)]  
  
## Example: Write characters asynchronously in a WPF app 
 The next example is the code behind a WPF app. On window load, the example asynchronously reads all characters from a <xref:System.Windows.Controls.TextBox> control and stores them in an array. It then asynchronously writes each letter or white-space character to a separate line of a <xref:System.Windows.Controls.TextBlock> control.  
  
 [!code-csharp[StreamReaderWriter](../../../samples/snippets/csharp/VS_Snippets_Wpf/StringReaderWriter/MainWindow.xaml.cs)]
 [!code-vb[StreamReaderWriter](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/StringReaderWriter/MainWindow.xaml.vb)]  
  
## See also

- <xref:System.IO.StringWriter>  
- <xref:System.IO.StringWriter.Write%2A?displayProperty=nameWithType>  
- <xref:System.Text.StringBuilder>  
- [File and stream I/O](../../../docs/standard/io/index.md)  
- [Asynchronous file I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
- [How to: Enumerate directories and files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)  
- [How to: Read and write to a newly created data file](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
- [How to: Open and append to a log file](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
- [How to: Read text from a file](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
- [How to: Write text to a file](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
- [How to: Read characters from a string](../../../docs/standard/io/how-to-read-characters-from-a-string.md)
