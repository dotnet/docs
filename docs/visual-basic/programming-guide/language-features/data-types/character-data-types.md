---
title: "Character Data Types (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "data types [Visual Basic], character"
  - "String data type [Visual Basic], character data types"
  - "character data types [Visual Basic]"
  - "Char data type [Visual Basic], character data types"
  - "data types [Visual Basic], choosing"
ms.assetid: 902479ef-1679-47fc-9911-0c1c5008226c
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
---
# Character Data Types (Visual Basic)
[!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides *character data types* to deal with printable and displayable characters. While they both deal with Unicode characters, `Char` holds a single character whereas `String` contains an indefinite number of characters.  
  
 For a table that displays a side-by-side comparison of the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] data types, see [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md).  
  
## Char Type  
 The `Char` data type is a single two-byte (16-bit) Unicode character. If a variable always stores exactly one character, declare it as `Char`. For example:  
  
 [!code-vb[VbVbalrCharTypes#1](../../../../visual-basic/programming-guide/language-features/data-types/codesnippet/VisualBasic/character-data-types_1.vb)]  
  
 Each possible value in a `Char` or `String` variable is a *code point*, or character code, in the Unicode character set. Unicode characters include the basic ASCII character set, various other alphabet letters, accents, currency symbols, fractions, diacritics, and mathematical and technical symbols.  
  
> [!NOTE]
>  The Unicode character set reserves the code points D800 through DFFF (55296 through 55551 decimal) for *surrogate pairs*, which require two 16-bit values to represent a single code point. A `Char` variable cannot hold a surrogate pair, and a `String` uses two positions to hold such a pair.  
  
 For more information, see [Char Data Type](../../../../visual-basic/language-reference/data-types/char-data-type.md).  
  
## String Type  
 The `String` data type is a sequence of zero or more two-byte (16-bit) Unicode characters. If a variable can contain an indefinite number of characters, declare it as `String`. For example:  
  
 [!code-vb[VbVbalrCharTypes#2](../../../../visual-basic/programming-guide/language-features/data-types/codesnippet/VisualBasic/character-data-types_2.vb)]  
  
 For more information, see [String Data Type](../../../../visual-basic/language-reference/data-types/string-data-type.md).  
  
## See Also  
 [Elementary Data Types](../../../../visual-basic/programming-guide/language-features/data-types/elementary-data-types.md)  
 [Composite Data Types](../../../../visual-basic/programming-guide/language-features/data-types/composite-data-types.md)  
 [Generic Types in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Type Conversions in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [Type Characters](../../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)
