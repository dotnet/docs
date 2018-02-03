---
title: "File is too large to read into a byte array"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: 686630a6-a439-46c7-8d7b-34613ae4c5d8
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# File is too large to read into a byte array
The size of the file you are attempting to read into a byte array exceeds 4 GB. The `My.Computer.FileSystem.ReadAllBytes` method cannot read a file that exceeds this size.  
  
## To correct this error  
  
-   Use a <xref:System.IO.StreamReader> to read the file. For more information, see [Basics of .NET Framework File I/O and the File System (Visual Basic)](../../../visual-basic/developing-apps/programming/drives-directories-files/basics-of-net-framework-file-io-and-the-file-system.md).  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.ReadAllBytes%2A>  
 <xref:System.IO.StreamReader>  
 [File Access with Visual Basic](../../../visual-basic/developing-apps/programming/drives-directories-files/file-access.md)  
 [How to: Read Text from Files with a StreamReader](../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-read-text-from-files-with-a-streamreader.md)
