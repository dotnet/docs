---
title: "How to: Write Characters to a String"
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
  - "data streams, writing characters to string"
  - "writing characters to strings"
  - "streams, writing characters to strings"
  - "I/O [.NET Framework], writing characters to strings"
ms.assetid: 1222cbeb-0760-44bf-9888-914a2a37174b
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Write Characters to a String
The following code examples write characters synchronously and asynchronously from a character array into a string.  
  
## Example  
 The following example writes 5 characters synchronously from an array to a string.  
  
 [!code-csharp[Conceptual.StringBuilder#9](../../../samples/snippets/csharp/VS_Snippets_CLR/Conceptual.StringBuilder/cs/example2.cs#9)]
 [!code-vb[Conceptual.StringBuilder#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Conceptual.StringBuilder/vb/example2.vb#9)]  
  
## Example  
 The next example reads all the characters asynchronously from a <xref:System.Windows.Controls.TextBox> control, and stores them in an array. It then asynchronously writes each letter or white space character on a separate line followed by a line break to a <xref:System.Windows.Controls.TextBlock> control.  
  
 [!code-csharp[Conceptual.StringReader#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.stringreader/cs/source2.cs#2)]
 [!code-vb[Conceptual.StringReader#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.stringreader/vb/source2.vb#2)]  
  
## See Also  
 <xref:System.IO.StringWriter>  
 <xref:System.IO.StringWriter.Write%2A?displayProperty=nameWithType>  
 <xref:System.Text.StringBuilder>  
 [File and Stream I-O](../../../docs/standard/io/index.md)  
 [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
 [How to: Enumerate Directories and Files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)  
 [How to: Read and Write to a Newly Created Data File](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
 [How to: Open and Append to a Log File](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
 [How to: Read Text from a File](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
 [How to: Write Text to a File](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
 [How to: Read Characters from a String](../../../docs/standard/io/how-to-read-characters-from-a-string.md)
