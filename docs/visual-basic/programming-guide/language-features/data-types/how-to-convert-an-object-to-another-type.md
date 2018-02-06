---
title: "How to: Convert an Object to Another Type in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "objects [Visual Basic], converting"
ms.assetid: 60cb5fc7-7ba4-4ab5-9c24-480fa12ddcdc
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Convert an Object to Another Type in Visual Basic
You convert an `Object` variable to another data type by using a conversion keyword such as [CType Function](../../../../visual-basic/language-reference/functions/ctype-function.md).  
  
## Example  
 The following example converts an `Object` variable to an `Integer` and a `String`.  
  
```  
Public Sub objectConversion(ByVal anObject As Object)  
    Dim anInteger As Integer  
    Dim aString As String  
    anInteger = CType(anObject, Integer)  
    aString = CType(anObject, String)  
End Sub  
```  
  
 If you know that the contents of an `Object` variable are of a particular data type, it is better to convert the variable to that data type. If you continue to use the `Object` variable, you incur either *boxing* and *unboxing* (for a value type) or *late binding* (for a reference type). These operations all take extra execution time and make your performance slower.  
  
## Compiling the Code  
 This example requires:  
  
-   A reference to the <xref:System?displayProperty=nameWithType> namespace.  
  
## See Also  
 <xref:System.Object>  
 [Type Conversions in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Widening and Narrowing Conversions](../../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)  
 [Implicit and Explicit Conversions](../../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)  
 [Conversions Between Strings and Other Types](../../../../visual-basic/programming-guide/language-features/data-types/conversions-between-strings-and-other-types.md)  
 [Array Conversions](../../../../visual-basic/programming-guide/language-features/data-types/array-conversions.md)  
 [Structures](../../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Type Conversion Functions](../../../../visual-basic/language-reference/functions/type-conversion-functions.md)
