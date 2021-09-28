---
description: "Learn more about: How to: Convert an Array of Bytes into a String in Visual Basic"
title: "How to: Convert an Array of Bytes into a String"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "string conversion [Visual Basic], arrays"
  - "byte arrays [Visual Basic], converting to strings"
  - "examples [Visual Basic], strings"
  - "arrays [Visual Basic], converting to strings"
ms.assetid: d0dc8317-9ab3-4324-99f7-3f5788c0e72a
---
# How to: Convert an Array of Bytes into a String in Visual Basic

This topic shows how to convert the bytes from a byte array into a string.  
  
## Example  

 This example uses the <xref:System.Text.Encoding.GetString%2A> method of the <xref:System.Text.Encoding.Unicode%2A?displayProperty=nameWithType> encoding class to convert all the bytes from a byte array into a string.  
  
 [!code-vb[VbVbalrStrings#72](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#72)]  
  
 You can choose from several encoding options to convert a byte array into a string:  
  
- <xref:System.Text.Encoding.ASCII%2A?displayProperty=nameWithType>: Gets an encoding for the ASCII (7-bit) character set.  
  
- <xref:System.Text.Encoding.BigEndianUnicode%2A?displayProperty=nameWithType>: Gets an encoding for the UTF-16 format using the big-endian byte order.  
  
- <xref:System.Text.Encoding.Default%2A?displayProperty=nameWithType>: Gets an encoding for the system's current ANSI code page.  
  
- <xref:System.Text.Encoding.Unicode%2A?displayProperty=nameWithType>: Gets an encoding for the UTF-16 format using the little-endian byte order.  
  
- <xref:System.Text.Encoding.UTF32%2A?displayProperty=nameWithType>: Gets an encoding for the UTF-32 format using the little-endian byte order.  
  
- <xref:System.Text.Encoding.UTF7%2A?displayProperty=nameWithType>: Gets an encoding for the UTF-7 format.  
  
- <xref:System.Text.Encoding.UTF8%2A?displayProperty=nameWithType>: Gets an encoding for the UTF-8 format.  
  
## See also

- <xref:System.Text.Encoding?displayProperty=nameWithType>
- <xref:System.Text.Encoding.GetString%2A>
- [How to: Convert Strings into an Array of Bytes in Visual Basic](how-to-convert-strings-into-an-array-of-bytes.md)
