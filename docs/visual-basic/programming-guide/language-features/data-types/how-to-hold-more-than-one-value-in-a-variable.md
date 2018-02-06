---
title: "How to: Hold More Than One Value in a Variable (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "classes [Visual Basic], composite data types"
  - "composite types [Visual Basic]"
  - "composite data types [Visual Basic]"
  - "data types [Visual Basic], composite"
  - "arrays [Visual Basic], composite data types"
  - "structures [Visual Basic], composite data types"
  - "arrays [Visual Basic], compilation errors"
  - "types [Visual Basic], composite"
ms.assetid: 5fe0e558-aac2-4a40-b7f2-7cfea7336917
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Hold More Than One Value in a Variable (Visual Basic)
A variable holds more than one value if you declare it to be of a *composite data type*.  
  
 [Composite Data Types](../../../../visual-basic/programming-guide/language-features/data-types/composite-data-types.md) include structures, arrays, and classes. A variable of a composite data type can hold a combination of elementary data types and other composite types. Structures and classes can hold code as well as data.  
  
### To hold more than one value in a variable  
  
1.  Determine what composite data type you want to use for your variable.  
  
2.  If the composite data type is not already defined, define it so that your variable can use it.  
  
    -   Define a structure with a [Structure Statement](../../../../visual-basic/language-reference/statements/structure-statement.md).  
  
    -   Define an array with a [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md).  
  
    -   Define a class with a [Class Statement](../../../../visual-basic/language-reference/statements/class-statement.md).  
  
3.  Declare your variable with a `Dim` statement.  
  
4.  Follow the variable name with an `As` clause.  
  
5.  Follow the `As` keyword with the name of the appropriate composite data type.  
  
## See Also  
 [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Characters](../../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)  
 [Composite Data Types](../../../../visual-basic/programming-guide/language-features/data-types/composite-data-types.md)  
 [Structures](../../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Arrays](../../../../visual-basic/programming-guide/language-features/arrays/index.md)  
 [Objects and Classes](../../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)
