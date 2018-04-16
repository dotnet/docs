---
title: "How to: Read Characters from a String"
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
  - "reading characters from strings"
  - "data streams, reading characters from string"
  - "I/O [.NET Framework], reading characters from strings"
  - "reading data, strings"
  - "streams, reading characters from string"
ms.assetid: 27ea5e52-6db8-42d8-980a-50bcfc7fd270
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Read Characters from a String
The following code examples show how to read characters synchronously and asynchronously from a string.  
  
## Example  
 This example reads 13 characters synchronously from a string, stores them in an array, and displays those characters. It then reads the remaining characters in the string, stores them in the array starting at the sixth element, and displays the contents of the array.  
  
 [!code-cpp[Conceptual.StringReader#1](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.stringreader/cpp/source.cpp#1)]
 [!code-csharp[Conceptual.StringReader#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.stringreader/cs/source.cs#1)]
 [!code-vb[Conceptual.StringReader#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.stringreader/vb/source.vb#1)]  
  
## Example  
 The next example reads all the characters asynchronously from a <xref:System.Windows.Controls.TextBox> control, and stores them in an array. It then asynchronously writes each letter or white space character on a separate line followed by a line break to a <xref:System.Windows.Controls.TextBlock> control.  
  
 [!code-csharp[Conceptual.StringReader#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.stringreader/cs/source2.cs#2)]
 [!code-vb[Conceptual.StringReader#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.stringreader/vb/source2.vb#2)]  
  
## See Also  
 <xref:System.IO.StringReader>  
 <xref:System.IO.StringReader.Read%2A?displayProperty=nameWithType>  
 [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
 [NIB: How to: Create a Directory Listing](https://msdn.microsoft.com/library/4d2772b1-b991-4532-a8a6-6ef733277e69)  
 [How to: Read and Write to a Newly Created Data File](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
 [How to: Open and Append to a Log File](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
 [How to: Read Text from a File](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
 [How to: Write Text to a File](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
 [How to: Write Characters to a String](../../../docs/standard/io/how-to-write-characters-to-a-string.md)  
 [File and Stream I-O](../../../docs/standard/io/index.md)
