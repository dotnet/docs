---
description: "Learn more about: How to: Convert a String to an Array of Characters in Visual Basic"
title: "How to: Convert a String to an Array of Characters"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "character arrays [Visual Basic], converting strings"
  - "arrays [Visual Basic], converting strings to"
  - "examples [Visual Basic], string conversion"
  - "strings [Visual Basic], converting to arrays"
  - "string conversion [Visual Basic], arrays"
ms.assetid: 1b54b686-ab29-413b-adce-6bd5422376eb
---
# How to: Convert a String to an Array of Characters in Visual Basic

Sometimes it is useful to have data about the characters in your string and the positions of those characters within your string, such as when you are parsing a string. This example shows how you can get an array of the characters in a string by calling the string's <xref:System.String.ToCharArray%2A> method.  
  
## Example 1

 This example demonstrates how to split a string into a `Char` array, and how to split a string into a `String` array of its Unicode text characters. The reason for this distinction is that Unicode text characters can be composed of two or more `Char` characters (such as a surrogate pair or a combining character sequence). For more information, see <xref:System.Globalization.TextElementEnumerator> and [The Unicode Standard](https://www.unicode.org/standard/standard.html).  
  
 [!code-vb[VbVbalrStrings#75](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class4.vb#75)]  
  
## Example 2  

 It is more difficult to split a string into its Unicode text characters, but this is necessary if you need information about the visual representation of a string. This example uses the <xref:System.Globalization.StringInfo.SubstringByTextElements%2A> method to get information about the Unicode text characters that make up a string.  
  
 [!code-vb[VbVbalrStrings#76](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class4.vb#76)]  
  
## See also

- <xref:System.String.Chars%2A>
- <xref:System.Globalization.StringInfo?displayProperty=nameWithType>
- [How to: Access Characters in Strings](how-to-access-characters-in-strings.md)
- [Converting Between Strings and Other Data Types in Visual Basic](converting-between-strings-and-other-data-types.md)
- [Strings](index.md)
