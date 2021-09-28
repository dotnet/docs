---
title: "How to read from a text file - C# Programming Guide"
description: Learn how to read from a text file using static methods from the File class. See a code example and view additional available resources.
ms.date: 07/20/2015
ms.topic: how-to
f1_keywords: 
  - "StreamReader.ReadToEnd"
helpviewer_keywords: 
  - "text files, writing to"
  - "reading text files"
  - "reading data, text files"
  - "text files, reading"
ms.assetid: 92246c5b-e819-4eea-9370-1a9460e12de3
---
# How to read from a text file (C# Programming Guide)

This example reads the contents of a text file by using the static methods <xref:System.IO.File.ReadAllText%2A> and <xref:System.IO.File.ReadAllLines%2A> from the <xref:System.IO.File?displayProperty=nameWithType> class.  
  
For an example that uses <xref:System.IO.StreamReader>, see [How to read a text file one line at a time](./how-to-read-a-text-file-one-line-at-a-time.md).
  
> [!NOTE]
> The files that are used in this example are created in the topic [How to write to a text file](./how-to-write-to-a-text-file.md).
  
## Example  

 [!code-csharp[csFilesandFolders#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#4)]  
  
## Compiling the Code  

 Copy the code and paste it into a C# console application.  
  
If you are not using the text files from [How to write to a text file](./how-to-write-to-a-text-file.md), replace the argument to `ReadAllText` and `ReadAllLines` with the appropriate path and file name on your computer.
  
## Robust Programming  

 The following conditions may cause an exception:  
  
- The file doesn't exist or doesn't exist at the specified location. Check the path and the spelling of the file name.  
  
## .NET Security  

 Do not rely on the name of a file to determine the contents of the file. For example, the file `myFile.cs` might not be a C# source file.  
  
## See also

- <xref:System.IO?displayProperty=nameWithType>
- [C# Programming Guide](../index.md)
- [File System and the Registry (C# Programming Guide)](./index.md)
