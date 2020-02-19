---
title: "How to: Open and append to a log file"
ms.date: "01/21/2019"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "log files, opening"
  - "streams, opening and appending to log file"
  - "log files, appending to"
  - "I/O [.NET Framework], log files"
ms.assetid: 74423362-1721-49cb-aa0a-e04005f72a06
---
# How to: Open and append to a log file
<xref:System.IO.StreamWriter> and <xref:System.IO.StreamReader> write characters to and read characters from streams. The following code example opens the *log.txt* file for input, or creates it if it doesn't exist, and appends log information to the end of the file. The example then writes the contents of the file to standard output for display. 

As an alternative to this example, you could store the information as a single string or string array, and use the <xref:System.IO.File.WriteAllText%2A?displayProperty=nameWithType> or <xref:System.IO.File.WriteAllLines%2A?displayProperty=nameWithType> method to achieve the same functionality.  
  
> [!NOTE]
> Visual Basic users may choose to use the methods and properties provided by the <xref:Microsoft.VisualBasic.Logging.Log> class or <xref:Microsoft.VisualBasic.FileIO.FileSystem> class for creating or writing to log files.  
  
## Example  
 [!code-csharp[Conceptual.BasicIO.TextFiles#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/source2.cs#2)]
 [!code-vb[Conceptual.BasicIO.TextFiles#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/source2.vb#2)]  
  
## See also

- <xref:System.IO.StreamWriter>  
- <xref:System.IO.StreamReader>  
- <xref:System.IO.File.AppendText%2A?displayProperty=nameWithType>  
- <xref:System.IO.File.OpenText%2A?displayProperty=nameWithType>  
- <xref:System.IO.StreamReader.ReadLine%2A?displayProperty=nameWithType>  
- [How to: Enumerate directories and files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)  
- [How to: Read and write to a newly created data file](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
- [How to: Read text from a file](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
- [How to: Write text to a file](../../../docs/standard/io/how-to-write-text-to-a-file.md)  
- [How to: Read characters from a string](../../../docs/standard/io/how-to-read-characters-from-a-string.md)  
- [How to: Write characters to a string](../../../docs/standard/io/how-to-write-characters-to-a-string.md)  
- [File and stream I/O](../../../docs/standard/io/index.md)
