---
description: "Learn more about: How to: Write Text to Files with a StreamWriter in Visual Basic"
title: "How to: Write Text to Files with a StreamWriter"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "files [Visual Basic], writing to"
  - "text, writing to files"
  - "writing to files [Visual Basic], StreamWriter"
ms.assetid: 99762e57-ef46-4dcc-8959-a8f79c22f067
---
# How to: Write Text to Files with a StreamWriter in Visual Basic

This example opens a <xref:System.IO.StreamWriter> object with the `My.Computer.FileSystem.OpenTextFileWriter` method and uses it to write a string to a text file with the <xref:System.IO.TextWriter.WriteLine%2A> method of the <xref:System.IO.StreamWriter> class.  
  
## Example  

 [!code-vb[VbFileIOWrite#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIOWrite/VB/Class1.vb#5)]  
  
## Robust Programming  

 The following conditions may cause an exception:  
  
- The file exists and is read-only (<xref:System.IO.IOException>).  
  
- The disk is full (<xref:System.IO.IOException>).  
  
- The pathname is too long (<xref:System.IO.PathTooLongException>).  
  
## .NET Framework Security  

 This example creates a new file, if the file does not already exist. If an application needs to create a file, that application needs `Create` access for the folder. If the file already exists, the application needs only `Write` access, a lesser privilege. Where possible, it is more secure to create the file during deployment, and only grant `Read` access to a single file, rather than `Create` access for a folder.  
  
## See also

- <xref:System.IO.StreamWriter>
- <xref:Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileWriter%2A>
- [How to: Read from Text Files](how-to-read-from-text-files.md)
- [Writing to Files](writing-to-files.md)
