---
description: "Learn more about: How to: Access Characters in Strings in Visual Basic"
title: "How to: Access Characters in Strings"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "strings [Visual Basic], accessing characters"
  - "characters [Visual Basic], accessing in strings"
ms.assetid: 02c5206c-ffab-494d-b648-3b2ea358dc34
---
# How to: Access Characters in Strings in Visual Basic

This example demonstrates how to use the <xref:System.String.Chars%2A> property to access the character at the specified location in a string.  
  
## Example  

 Sometimes it is useful to have data about the characters in your string and the positions of those characters within your string. You can think of a string as an array of characters (`Char` instances); you can retrieve a particular character by referencing the index of that character through the <xref:System.String.Chars%2A> property.  
  
 [!code-vb[VbVbalrStrings#49](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#49)]  
  
 The `index` parameter of the <xref:System.String.Chars%2A> property is zero-based.  
  
## Robust Programming  

 The <xref:System.String.Chars%2A> property returns the character at the specified position. However, some Unicode characters can be represented by more than one character. For more information on how to work with Unicode characters, see [How to: Convert a String to an Array of Characters](how-to-convert-a-string-to-an-array-of-characters.md).  
  
 The <xref:System.String.Chars%2A> property throws an <xref:System.IndexOutOfRangeException> exception if the `index` parameter is greater than or equal to the length of the string, or if it is less than zero  
  
## See also

- <xref:System.String.Chars%2A>
- [How to: Convert a String to an Array of Characters](how-to-convert-a-string-to-an-array-of-characters.md)
- [Converting Between Strings and Other Data Types in Visual Basic](converting-between-strings-and-other-data-types.md)
- [Strings](index.md)
