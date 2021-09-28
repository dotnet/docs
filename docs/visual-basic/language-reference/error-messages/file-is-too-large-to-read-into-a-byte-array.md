---
description: "Learn more about: File is too large to read into a byte array"
title: "File is too large to read into a byte array"
ms.date: 07/20/2015
ms.assetid: 686630a6-a439-46c7-8d7b-34613ae4c5d8
---
# File is too large to read into a byte array

The size of the file you are attempting to read into a byte array exceeds 4 GB. The `My.Computer.FileSystem.ReadAllBytes` method cannot read a file that exceeds this size.  
  
## To correct this error  
  
- Use a <xref:System.IO.StreamReader> to read the file. For more information, see [Basics of .NET Framework File I/O and the File System (Visual Basic)](../../developing-apps/programming/drives-directories-files/basics-of-net-framework-file-io-and-the-file-system.md).  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.FileSystem.ReadAllBytes%2A>
- <xref:System.IO.StreamReader>
- [File Access with Visual Basic](../../developing-apps/programming/drives-directories-files/file-access.md)
- [How to: Read Text from Files with a StreamReader](../../developing-apps/programming/drives-directories-files/how-to-read-text-from-files-with-a-streamreader.md)
