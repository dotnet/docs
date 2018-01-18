---
title: "How to: Read From a Text File (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "StreamReader.ReadToEnd"
helpviewer_keywords: 
  - "text files, writing to"
  - "reading text files"
  - "reading data, text files"
  - "text files, reading"
ms.assetid: 92246c5b-e819-4eea-9370-1a9460e12de3
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Read From a Text File (C# Programming Guide)
This example reads the contents of a text file by using the static methods <xref:System.IO.File.ReadAllText%2A> and <xref:System.IO.File.ReadAllLines%2A> from the <xref:System.IO.File?displayProperty=nameWithType> class.  
  
 For an example that uses <xref:System.IO.StreamReader>, see [How to: Read a Text File One Line at a Time](../../../csharp/programming-guide/file-system/how-to-read-a-text-file-one-line-at-a-time.md).  
  
> [!NOTE]
>  The files that are used in this example are created in the topic [How to: Write to a Text File](../../../csharp/programming-guide/file-system/how-to-write-to-a-text-file.md).  
  
## Example  
 [!code-csharp[csFilesandFolders#4](../../../csharp/programming-guide/file-system/codesnippet/CSharp/how-to-read-from-a-text-file_1.cs)]  
  
## Compiling the Code  
 Copy the code and paste it into a C# console application.  
  
 If you are not using the text files from [How to: Write to a Text File](../../../csharp/programming-guide/file-system/how-to-write-to-a-text-file.md), replace the argument to `ReadAllText` and `ReadAllLines` with the appropriate path and file name on your computer.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The file doesn't exist or doesn't exist at the specified location. Check the path and the spelling of the file name.  
  
## .NET Framework Security  
 Do not rely on the name of a file to determine the contents of the file. For example, the file `myFile.cs` might not be a C# source file.  
  
## See Also  
 <xref:System.IO?displayProperty=nameWithType>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [File System and the Registry (C# Programming Guide)](../../../csharp/programming-guide/file-system/index.md)
