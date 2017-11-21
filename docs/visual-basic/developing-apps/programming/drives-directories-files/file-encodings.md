---
title: "File Encodings (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "character encodings"
  - "files [Visual Basic], encoding"
  - "Unicode, file encoding"
  - "file encoding"
ms.assetid: ea2c5f5f-bbb1-4150-9928-b9951fa6bc57
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# File Encodings (Visual Basic)
File encodings, also known as character encodings, specify how to represent characters when text processing. One encoding may be preferable over another in terms of which language characters it can or cannot handle, although Unicode is usually preferred.  
  
 When reading from or writing to files, improperly matching file encodings may result in exceptions or incorrect results.  
  
## Types of Encodings  
 Unicode is the preferred encoding when working with files. Unicode is a worldwide character-encoding standard that uses 16-bit code values to represent all the characters used in modern computing, including technical symbols and special characters used in publishing.  
  
 Previous character-encoding standards consisted of traditional character sets, such as the Windows ANSI character set that uses 8-bit code values, or combinations of 8-bit values, to represent the characters used in a specific language or geographical region.  
  
## Encoding Class  
 The <xref:System.Text.Encoding> class represents a character encoding. This table lists the type of encodings available and describes each.  
  
|Name|Description|
|---|---|    
|<xref:System.Text.ASCIIEncoding>|Represents an ASCII character encoding of Unicode characters.|  
|<xref:System.Text.UnicodeEncoding>|Represents a UTF-16 encoding of Unicode characters.|  
|<xref:System.Text.UTF32Encoding>|Represents a UTF-32 encoding of Unicode characters.|  
|<xref:System.Text.UTF7Encoding>|Represents a UTF-7 encoding of Unicode characters.|  
|<xref:System.Text.UTF8Encoding>|Represents a UTF-8 encoding of Unicode characters.|  
  
## See Also  
 [Reading from Files](../../../../visual-basic/developing-apps/programming/drives-directories-files/reading-from-files.md)  
 [Writing to Files](../../../../visual-basic/developing-apps/programming/drives-directories-files/writing-to-files.md)
