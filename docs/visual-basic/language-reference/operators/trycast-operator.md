---
title: "TryCast Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.trycast"
  - "trycast"
helpviewer_keywords: 
  - "TryCast keyword [Visual Basic]"
ms.assetid: d1ef5d47-fef4-491e-b014-1d910628f65c
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# TryCast Operator (Visual Basic)
Introduces a type conversion operation that does not throw an exception.  
  
## Remarks  
 If an attempted conversion fails, `CType` and `DirectCast` both throw an <xref:System.InvalidCastException> error. This can adversely affect the performance of your application. `TryCast` returns [Nothing](../../../visual-basic/language-reference/nothing.md), so that instead of having to handle a possible exception, you need only test the returned result against `Nothing`.  
  
 You use the `TryCast` keyword the same way you use the [CType Function](../../../visual-basic/language-reference/functions/ctype-function.md) and the [DirectCast Operator](../../../visual-basic/language-reference/operators/directcast-operator.md) keyword. You supply an expression as the first argument and a type to convert it to as the second argument. `TryCast` operates only on reference types, such as classes and interfaces. It requires an inheritance or implementation relationship between the two types. This means that one type must inherit from or implement the other.  
  
## Errors and Failures  
 `TryCast` generates a compiler error if it detects that no inheritance or implementation relationship exists. But the lack of a compiler error does not guarantee a successful conversion. If the desired conversion is narrowing, it could fail at run time. If this happens, `TryCast` returns [Nothing](../../../visual-basic/language-reference/nothing.md).  
  
## Conversion Keywords  
 A comparison of the type conversion keywords is as follows.  
  
|Keyword|Data types|Argument relationship|Run-time failure|  
|---|---|---|---|  
|[CType Function](../../../visual-basic/language-reference/functions/ctype-function.md)|Any data types|Widening or narrowing conversion must be defined between the two data types|Throws <xref:System.InvalidCastException>|  
|[DirectCast Operator](../../../visual-basic/language-reference/operators/directcast-operator.md)|Any data types|One type must inherit from or implement the other type|Throws <xref:System.InvalidCastException>|  
|`TryCast`|Reference types only|One type must inherit from or implement the other type|Returns [Nothing](../../../visual-basic/language-reference/nothing.md)|  
  
## Example  
 The following example shows how to use `TryCast`.  
  
 [!code-vb[VbVbalrKeywords#6](../../../visual-basic/language-reference/codesnippet/VisualBasic/trycast-operator_1.vb)]  
  
## See Also  
 [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)  
 [Implicit and Explicit Conversions](../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)
