---
description: "Learn more about: How to: Append to Text Files in Visual Basic"
title: "How to: Append to Text Files"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "I/O [Visual Basic], appending to files"
  - "I/O [Visual Basic], My.Computer.FileSystem.WriteAllText method"
  - "I/O [Visual Basic], WriteAllText method"
ms.assetid: bbbd7fb5-f169-41a9-b53f-520ea9613913
---
# How to: Append to Text Files in Visual Basic

The <xref:Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText%2A> method can be used to append to a text file by specifying that the `append` parameter is set to `True`.  
  
### To append to a text file  
  
- Use the `WriteAllText` method, specifying the target file and string to be appended and setting the `append` parameter to `True`.  
  
     This example writes the string `"This is a test string."` to the file named `Testfile.txt`.  
  
     [!code-vb[VbFileIOWrite#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIOWrite/VB/Class1.vb#6)]  
  
## Robust Programming  

 The following conditions may cause an exception:  
  
- The path is not valid for one of the following reasons: it is a zero-length string, it contains only white space, it contains invalid characters, or it is a device path (starts with \\\\.\\) (<xref:System.ArgumentException>).  
  
- The path is not valid because it is `Nothing` (<xref:System.ArgumentNullException>).  
  
- `File` points to a path that does not exist (<xref:System.IO.FileNotFoundException> or <xref:System.IO.DirectoryNotFoundException>).  
  
- The file is in use by another process, or an I/O error occurs (<xref:System.IO.IOException>).  
  
- The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).  
  
- A file or directory name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).  
  
- The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText%2A>
- <xref:Microsoft.VisualBasic.FileIO.FileSystem>
- [Writing to Files](writing-to-files.md)
