---
description: "Learn more about: How to: Create a String from An Array of Char Values (Visual Basic)"
title: "How to: Create a String from An Array of Char Values"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "examples [Visual Basic], arrays"
  - "examples [Visual Basic], Char data type"
ms.assetid: 69f94e85-d57c-4ccc-a62a-426e829f5c5e
---
# How to: Create a String from An Array of Char Values (Visual Basic)

This example creates the string "abcd" from individual characters.  
  
## Example  

 [!code-vb[VbVbalrStrings#61](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#61)]  
  
## Compile the code  

 This method has no special requirements.  
  
 The syntax `"a"c`, where a single `c` follows a single character in quotation marks, is used to create a character literal.  
  
## Robust Programming  

 Null characters (equivalent to `Chr(0)`) in the string lead to unexpected results when using the string. The null character will be included with the string, but characters following the null character will not be displayed in some situations.  
  
## See also

- <xref:System.String>
- [Char Data Type](../../../language-reference/data-types/char-data-type.md)
- [Data Types](../data-types/index.md)
