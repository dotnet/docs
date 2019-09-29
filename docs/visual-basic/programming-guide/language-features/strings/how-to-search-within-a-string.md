---
title: "How to: search within a string - Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords:
  - "strings [Visual Basic], finding"
  - "strings [Visual Basic], searching"
  - "examples [Visual Basic], strings"
ms.assetid: ae4c79e0-08ea-489f-bdb2-5eb6d355f284
---
# How to: search within a string (Visual Basic)
  
## Example

This example calls the <xref:System.String.IndexOf%2A> method on a <xref:System.String> object to report the index of the first occurrence of a substring:

 [!code-vb[VbVbalrStrings#71](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class2.vb#71)]

## Robust programming

The <xref:System.String.IndexOf%2A> method returns the location of the first character of the first occurrence of the substring. The index is 0-based, which means the first character of a string has an index of 0.

If <xref:System.String.IndexOf%2A> does not find the substring, it returns -1.

The <xref:System.String.IndexOf%2A> method is case-sensitive and uses the current culture.

For optimal error control, you might want to enclose the string search in the `Try` block of a [Try...Catch...Finally Statement](../../../language-reference/statements/try-catch-finally-statement.md) construction.

## See also

- <xref:System.String.IndexOf%2A>
- [Try...Catch...Finally Statement](../../../language-reference/statements/try-catch-finally-statement.md)
- [Introduction to Strings in Visual Basic](introduction-to-strings.md)
- [Strings](index.md)
