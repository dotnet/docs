---
title: "How to: Open and Append to a Log File"
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
  - "log files, opening"
  - "streams, opening and appending to log file"
  - "log files, appending to"
  - "I/O [.NET Framework], log files"
ms.assetid: 74423362-1721-49cb-aa0a-e04005f72a06
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Open and Append to a Log File
<xref:System.IO.StreamWriter> and <xref:System.IO.StreamReader> write characters to and read characters from streams. The following code example opens the `log.txt` file for input, or creates the file if it does not already exist, and appends information to the end of the file. The contents of the file are then written to standard output for display. As an alternative to this example, the information could be stored as a single string or string array, and the <xref:System.IO.File.WriteAllText%2A> or <xref:System.IO.File.WriteAllLines%2A> method could be used to achieve the same functionality.  
  
> [!NOTE]
>  Visual Basic users may choose to use the methods and properties provided by the <xref:Microsoft.VisualBasic.Logging.Log> class or <xref:Microsoft.VisualBasic.FileIO.FileSystem> class for creating or writing to log files.  
  
## Example  
 [!code-csharp[Conceptual.BasicIO.TextFiles#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/source2.cs#2)]
 [!code-vb[Conceptual.BasicIO.TextFiles#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/source2.vb#2)]  
  
## See Also  
 <xref:System.IO.StreamWriter>  
 <xref:System.IO.StreamReader>  
 <xref:System.IO.File.AppendText%2A?displayProperty=nameWithType>  
 <xref:System.IO.File.OpenText%2A?displayProperty=nameWithType>  
 <xref:System.IO.StreamReader.ReadLine%2A?displayProperty=nameWithType>  
 [How to: Enumerate Directories and Files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)  
 [How to: Read and Write to a Newly Created Data File](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
 [How to: Read Text from a File](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
 [How to: Write Text to a File](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
 [How to: Read Characters from a String](../../../docs/standard/io/how-to-read-characters-from-a-string.md)  
 [How to: Write Characters to a String](../../../docs/standard/io/how-to-write-characters-to-a-string.md)  
 [File and Stream I-O](../../../docs/standard/io/index.md)
