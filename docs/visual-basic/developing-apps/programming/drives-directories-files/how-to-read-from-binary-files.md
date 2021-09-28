---
description: "Learn more about: How to: Read From Binary Files in Visual Basic"
title: "How to: Read From Binary Files"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "binary files [Visual Basic], reading from"
  - "I/O [Visual Basic], reading from binary files"
  - "ReadAllBytes method [Visual Basic], reading from binary files"
  - "My.Computer.FileSystem object, reading from binary files"
ms.assetid: d2b1269e-24b6-42e0-9414-ae708db282d8
---
# How to: Read From Binary Files in Visual Basic

The `My.Computer.FileSystem` object provides the `ReadAllBytes` method for reading from binary files.  
  
### To read from a binary file  
  
- Use the `ReadAllBytes` method, which returns the contents of a file as a byte array. This example reads from the file `C:/Documents and Settings/selfportrait.jpg`.  
  
     [!code-vb[VbVbcnMyFileSystem#78](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#78)]  
  
- For large binary files, you can use the <xref:System.IO.FileStream.Read%2A> method of the <xref:System.IO.FileStream> object to read from the file only a specified amount at a time. You can then limit how much of the file is loaded into memory for each read operation. The following code example copies a file and allows the caller to specify how much of the file is read into memory per read operation.  
  
     [!code-vb[VbVbcnMyFileSystem#91](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#91)]  
  
## Robust Programming  

 The following conditions may cause an exception to be thrown:  
  
- The path is not valid for one of the following reasons: it is a zero-length string, it contains only white space, it contains invalid characters, or it is a device path (<xref:System.ArgumentException>).  
  
- The path is not valid because it is `Nothing` (<xref:System.ArgumentNullException>).  
  
- The file does not exist (<xref:System.IO.FileNotFoundException>).  
  
- The file is in use by another process, or an I/O error occurs (<xref:System.IO.IOException>).  
  
- The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).  
  
- A file or directory name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).  
  
- There is not enough memory to write the string to buffer (<xref:System.OutOfMemoryException>).  
  
- The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).  
  
 Do not make decisions about the contents of the file based on the name of the file. For example, the file Form1.vb may not be a Visual Basic source file.  
  
 Verify all inputs before using the data in your application. The contents of the file may not be what is expected, and methods to read from the file may fail.  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.FileSystem.ReadAllBytes%2A>
- <xref:Microsoft.VisualBasic.FileIO.FileSystem.WriteAllBytes%2A>
- [Reading from Files](reading-from-files.md)
- [How to: Read From Text Files with Multiple Formats](how-to-read-from-text-files-with-multiple-formats.md)
- [Storing Data to and Reading from the Clipboard](../computer-resources/storing-data-to-and-reading-from-the-clipboard.md)
