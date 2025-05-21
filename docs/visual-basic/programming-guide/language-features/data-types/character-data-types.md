---
description: "Learn more about: Character Data Types (Visual Basic)"
title: "Character Data Types"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "data types [Visual Basic], character"
  - "String data type [Visual Basic], character data types"
  - "character data types [Visual Basic]"
  - "Char data type [Visual Basic], character data types"
  - "data types [Visual Basic], choosing"
ms.assetid: 902479ef-1679-47fc-9911-0c1c5008226c
ms.topic: article
---
# Character Data Types (Visual Basic)

Visual Basic provides *character data types* to deal with printable and displayable characters. While they both deal with Unicode characters, `Char` holds a single character whereas `String` contains an indefinite number of characters.  
  
 For a table that displays a side-by-side comparison of the Visual Basic data types, see [Data Types](../../../language-reference/data-types/index.md).  
  
## Char Type  

 The `Char` data type is a single two-byte (16-bit) Unicode character. If a variable always stores exactly one character, declare it as `Char`. For example:  
  
 [!code-vb[VbVbalrCharTypes#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrchartypes/vb/module1.vb#1)]
  
 Each possible value in a `Char` or `String` variable is a *code point*, or character code, in the Unicode character set. Unicode characters include the basic ASCII character set, various other alphabet letters, accents, currency symbols, fractions, diacritics, and mathematical and technical symbols.  
  
> [!NOTE]
> The Unicode character set reserves the code points D800 through DFFF (55296 through 55551 decimal) for *surrogate pairs*, which require two 16-bit values to represent a single code point. A `Char` variable cannot hold a surrogate pair, and a `String` uses two positions to hold such a pair.  
  
 For more information, see [Char Data Type](../../../language-reference/data-types/char-data-type.md).  
  
## String Type  

 The `String` data type is a sequence of zero or more two-byte (16-bit) Unicode characters. If a variable can contain an indefinite number of characters, declare it as `String`. For example:  
  
 [!code-vb[VbVbalrCharTypes#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrchartypes/vb/module1.vb#2)]
  
 For more information, see [String Data Type](../../../language-reference/data-types/string-data-type.md).  
  
## See also

- [Elementary Data Types](elementary-data-types.md)
- [Composite Data Types](composite-data-types.md)
- [Generic Types in Visual Basic](generic-types.md)
- [Value Types and Reference Types](value-types-and-reference-types.md)
- [Type Conversions in Visual Basic](type-conversions.md)
- [Troubleshooting Data Types](troubleshooting-data-types.md)
- [Type Characters](type-characters.md)
