---
title: "How to: Convert an Array of Bytes into a String in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "string conversion, arrays"
  - "byte arrays, converting to strings"
  - "examples [Visual Basic], strings"
  - "arrays [Visual Basic], converting to strings"
ms.assetid: d0dc8317-9ab3-4324-99f7-3f5788c0e72a
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Convert an Array of Bytes into a String in Visual Basic
This topic shows how to convert the bytes from a byte array into a string.  
  
## Example  
 This example uses the <xref:System.Text.Encoding.GetString%2A> method of the <xref:System.Text.Encoding.Unicode%2A?displayProperty=fullName> encoding class to convert all the bytes from a byte array into a string.  
  
 [!code-vb[VbVbalrStrings#72](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/how-to-convert-an-array-of-bytes-into-a-string_1.vb)]  
  
 You can choose from several encoding options to convert a byte array into a string:  
  
-   <xref:System.Text.Encoding.ASCII%2A?displayProperty=fullName>: Gets an encoding for the ASCII (7-bit) character set.  
  
-   <xref:System.Text.Encoding.BigEndianUnicode%2A?displayProperty=fullName>: Gets an encoding for the UTF-16 format using the big-endian byte order.  
  
-   <xref:System.Text.Encoding.Default%2A?displayProperty=fullName>: Gets an encoding for the system's current ANSI code page.  
  
-   <xref:System.Text.Encoding.Unicode%2A?displayProperty=fullName>: Gets an encoding for the UTF-16 format using the little-endian byte order.  
  
-   <xref:System.Text.Encoding.UTF32%2A?displayProperty=fullName>: Gets an encoding for the UTF-32 format using the little-endian byte order.  
  
-   <xref:System.Text.Encoding.UTF7%2A?displayProperty=fullName>: Gets an encoding for the UTF-7 format.  
  
-   <xref:System.Text.Encoding.UTF8%2A?displayProperty=fullName>: Gets an encoding for the UTF-8 format.  
  
## See Also  
 <xref:System.Text.Encoding?displayProperty=fullName>   
 <xref:System.Text.Encoding.GetString%2A>   
 [How to: Convert Strings into an Array of Bytes in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/how-to-convert-strings-into-an-array-of-bytes.md)