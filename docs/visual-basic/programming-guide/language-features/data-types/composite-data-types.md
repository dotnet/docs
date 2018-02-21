---
title: "Composite Data Types (Visual Basic)"
ms.custom: ""
ms.date: 04/25/2017
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
  - "classes [Visual Basic], composite types"
  - "types [Visual Basic], composite"
ms.assetid: 62970f2e-52c0-4369-8963-613820f1f434
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# Composite Data Types (Visual Basic)
In addition to the elementary data types [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] supplies, you can also assemble items of different types to create *composite data types* such as structures, arrays, and classes. You can build composite data types from elementary types and from other composite types. For example, you can define an array of structure elements, or a structure with array members.  
  
## Data Types  
 A composite type is different from the data type of any of its components. For example, an array of `Integer` elements is not of the `Integer` data type.  
  
 An array data type is normally represented using the element type, parentheses, and commas as necessary. For example, a one-dimensional array of `String` elements is represented as `String()`, and a two-dimensional array of `Boolean` elements is represented as `Boolean(,)`.  
  
## Structure Types  
 There is no single data type comprising all structures. Instead, each definition of a structure represents a unique data type, even if two structures define identical elements in the same order. However, if you create two or more instances of the same structure, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] considers them to be of the same data type.  
  
## Tuples

A tuple is a lightweight structure that contains two or more fields whose types are predefined. Tuples are supported starting with Visual Basic 2017. Tuples are most commonly used to return multiple values from a single method call without having to pass arguments by reference or packaging the returned fields in a more heavy-weight class or structure. See the [Tuples](tuples.md) topic for more information on tuples.

## Array Types  
 There is no single data type comprising all arrays. The data type of a particular instance of an array is determined by the following:  
  
-   The fact of being an array  
  
-   The rank (number of dimensions) of the array  
  
-   The element type of the array  
  
 In particular, the length of a given dimension is not part of the instance's data type. The following example illustrates this.  
  
```  
Dim arrayA( ) As Byte = New Byte(12) {}  
Dim arrayB( ) As Byte = New Byte(100) {}  
Dim arrayC( ) As Short = New Short(100) {}  
Dim arrayD( , ) As Short  
Dim arrayE( , ) As Short = New Short(4, 10) {}  
```  
  
 In the preceding example, array variables `arrayA` and `arrayB` are considered to be of the same data type — `Byte()` — even though they are initialized to different lengths. Variables `arrayB` and `arrayC` are not of the same type because their element types are different. Variables `arrayC` and `arrayD` are not of the same type because their ranks are different. Variables `arrayD` and `arrayE` have the same type — `Short(,)` — because their ranks and element types are the same, even though `arrayD` is not yet initialized.  
  
 For more information on arrays, see [Arrays](../../../../visual-basic/programming-guide/language-features/arrays/index.md).  
  
## Class Types  
 There is no single data type comprising all classes. Although one class can inherit from another class, each is a separate data type. Multiple instances of the same class are of the same data type. If you assign one class instance variable to another, not only do they have the same data type, they point to the same class instance in memory.  
  
 For more information on classes, see [Objects and Classes](../../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md).  
  
## See Also  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)  
 [Elementary Data Types](../../../../visual-basic/programming-guide/language-features/data-types/elementary-data-types.md)  
 [Generic Types in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Type Conversions in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Structures](../../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [How to: Hold More Than One Value in a Variable](../../../../visual-basic/programming-guide/language-features/data-types/how-to-hold-more-than-one-value-in-a-variable.md)
