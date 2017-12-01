---
title: "String Basics in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "strings [Visual Basic], Like operator"
  - "strings [Visual Basic], Visual Basic"
  - "strings [Visual Basic], regular expressions"
ms.assetid: 5674418d-f00d-4f72-9f98-d15897793350
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# String Basics in Visual Basic
The `String` data type represents a series of characters (each representing in turn an instance of the `Char` data type). This topic introduces the basic concepts of strings in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
## String Variables  
 An instance of a string can be assigned a literal value that represents a series of characters. For example:  
  
 [!code-vb[VbVbalrStrings#63](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-basics_1.vb)]  
  
 A `String` variable can also accept any expression that evaluates to a string. Examples are shown below:  
  
 [!code-vb[VbVbalrStrings#64](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-basics_2.vb)]  
  
 Any literal that is assigned to a `String` variable must be enclosed in quotation marks (""). This means that a quotation mark within a string cannot be represented by a quotation mark. For example, the following code causes a compiler error:  
  
 [!code-vb[VbVbalrStrings#65](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-basics_3.vb)]  
  
 This code causes an error because the compiler terminates the string after the second quotation mark, and the remainder of the string is interpreted as code. To solve this problem, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] interprets two quotation marks in a string literal as one quotation mark in the string. The following example demonstrates the correct way to include a quotation mark in a string:  
  
 [!code-vb[VbVbalrStrings#66](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-basics_4.vb)]  
  
 In the preceding example, the two quotation marks preceding the word `Look` become one quotation mark in the string. The three quotation marks at the end of the line represent one quotation mark in the string and the string termination character.  
  
 String literals can contain multiple lines:  
  
```vb  
Dim x = "hello  
world"  
```  
  
 The resulting string contains newline sequences that you used in your string literal (vbcr, vbcrlf, etc.).  You no longer need to use the old workaround:  
  
```vb  
Dim x = <xml><![CDATA[Hello  
World]]></xml>.Value  
```  
  
## Characters in Strings  
 A string can be thought of as a series of `Char` values, and the `String` type has built-in functions that allow you to perform many manipulations on a string that resemble the manipulations allowed by arrays. Like all array in [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)], these are zero-based arrays. You may refer to a specific character in a string through the `Chars` property, which provides a way to access a character by the position in which it appears in the string. For example:  
  
 [!code-vb[VbVbalrStrings#67](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-basics_5.vb)]  
  
 In the above example, the `Chars` property of the string returns the fourth character in the string, which is `D`, and assigns it to `myChar`. You can also get the length of a particular string through the `Length` property. If you need to perform multiple array-type manipulations on a string, you can convert it to an array of `Char` instances using the `ToCharArray` function of the string. For example:  
  
 [!code-vb[VbVbalrStrings#68](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-basics_6.vb)]  
  
 The variable `myArray` now contains an array of `Char` values, each representing a character from `myString`.  
  
## The Immutability of Strings  
 A string is *immutable*, which means its value cannot be changed once it has been created. However, this does not prevent you from assigning more than one value to a string variable. Consider the following example:  
  
 [!code-vb[VbVbalrStrings#69](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/string-basics_7.vb)]  
  
 Here, a string variable is created, given a value, and then its value is changed.  
  
 More specifically, in the first line, an instance of type `String` is created and given the value `This string is immutable`. In the second line of the example, a new instance is created and given the value `Or is it?`, and the string variable discards its reference to the first instance and stores a reference to the new instance.  
  
 Unlike other intrinsic data types, `String` is a reference type. When a variable of reference type is passed as an argument to a function or subroutine, a reference to the memory address where the data is stored is passed instead of the actual value of the string. So in the previous example, the name of the variable remains the same, but it points to a new and different instance of the `String` class, which holds the new value.  
  
## See Also  
 [Introduction to Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/introduction-to-strings.md)  
 [String Data Type](../../../../visual-basic/language-reference/data-types/string-data-type.md)  
 [Char Data Type](../../../../visual-basic/language-reference/data-types/char-data-type.md)  
 [Basic String Operations](../../../../standard/base-types/basic-string-operations.md)
