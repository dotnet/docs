---
title: "How to: Create a String from An Array of Char Values (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "examples [Visual Basic], arrays"
  - "examples [Visual Basic], Char data type"
ms.assetid: 69f94e85-d57c-4ccc-a62a-426e829f5c5e
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create a String from An Array of Char Values (Visual Basic)
This example creates the string "abcd" from individual characters.  
  
## Example  
 [!code-vb[VbVbalrStrings#61](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/how-to-create-a-string-from-an-array-of-char-values_1.vb)]  
  
## Compiling the Code  
 This method has no special requirements.  
  
 The syntax `"a"c`, where a single `c` follows a single character in quotation marks, is used to create a character literal.  
  
## Robust Programming  
 Null characters (equivalent to `Chr(0)`) in the string lead to unexpected results when using the string. The null character will be included with the string, but characters following the null character will not be displayed in some situations.  
  
## See Also  
 <xref:System.String>  
 [Char Data Type](../../../../visual-basic/language-reference/data-types/char-data-type.md)  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)
