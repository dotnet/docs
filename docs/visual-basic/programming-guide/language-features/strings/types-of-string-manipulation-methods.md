---
title: "Types of String Manipulation Methods in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "strings [Visual Basic], manipulating [Visual Basic]"
  - "string manipulation"
ms.assetid: 905055cd-7f50-48fb-9eed-b0995af1dc1f
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Types of String Manipulation Methods in Visual Basic
There are several different ways to analyze and manipulate your strings. Some of the methods are a part of the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] language, and others are inherent in the `String` class.  
  
## Visual Basic Language and the .NET Framework  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] methods are used as inherent functions of the language. They may be used without qualification in your code. The following example shows typical use of a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] string-manipulation command:  
  
 [!code-vb[VbVbalrStrings#44](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/types-of-string-manipulation-methods_1.vb)]  
  
 In this example, the `Mid` function performs a direct operation on `aString` and assigns the value to `bString`.  
  
 For a list of Visual Basic string manipulation methods, see [String Manipulation Summary](../../../../visual-basic/language-reference/keywords/string-manipulation-summary.md).  
  
### Shared Methods and Instance Methods  
 You can also manipulate strings with the methods of the `String` class. There are two types of methods in `String`: *shared* methods and *instance* methods.  
  
#### Shared Methods  
 A shared method is a method that stems from the `String` class itself and does not require an instance of that class to work. These methods can be qualified with the name of the class (`String`) rather than with an instance of the `String` class. For example:  
  
 [!code-vb[VbVbalrStrings#45](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/types-of-string-manipulation-methods_2.vb)]  
  
 In the preceding example, the <xref:System.String.Copy%2A?displayProperty=nameWithType> method is a static method, which acts upon an expression it is given and assigns the resulting value to `bString`.  
  
#### Instance Methods  
 Instance methods, by contrast, stem from a particular instance of `String` and must be qualified with the instance name. For example:  
  
 [!code-vb[VbVbalrStrings#46](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/types-of-string-manipulation-methods_3.vb)]  
  
 In this example, the <xref:System.String.Substring%2A?displayProperty=nameWithType> method is a method of the instance of `String` (that is, `aString`). It performs an operation on `aString` and assigns that value to `bString`.  
  
 For more information, see the documentation for the <xref:System.String> class.  
  
## See Also  
 [Introduction to Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/introduction-to-strings.md)
