---
description: "Learn more about: TryCast Operator (Visual Basic)"
title: "TryCast Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.trycast"
  - "trycast"
helpviewer_keywords: 
  - "TryCast keyword [Visual Basic]"
ms.assetid: d1ef5d47-fef4-491e-b014-1d910628f65c
---
# TryCast Operator (Visual Basic)

Introduces a type conversion operation that does not throw an exception.  
  
## Remarks  

 If an attempted conversion fails, `CType` and `DirectCast` both throw an <xref:System.InvalidCastException> error. This can adversely affect the performance of your application. `TryCast` returns [Nothing](../nothing.md), so that instead of having to handle a possible exception, you need only test the returned result against `Nothing`.  
  
 You use the `TryCast` keyword the same way you use the [CType Function](../functions/ctype-function.md) and the [DirectCast Operator](directcast-operator.md) keyword. You supply an expression as the first argument and a type to convert it to as the second argument. `TryCast` operates only on reference types, such as classes and interfaces. It requires an inheritance or implementation relationship between the two types. This means that one type must inherit from or implement the other.  
  
## Errors and Failures  

 `TryCast` generates a compiler error if it detects that no inheritance or implementation relationship exists. But the lack of a compiler error does not guarantee a successful conversion. If the desired conversion is narrowing, it could fail at run time. If this happens, `TryCast` returns [Nothing](../nothing.md).  
  
## Conversion Keywords  

 A comparison of the type conversion keywords is as follows.  
  
|Keyword|Data types|Argument relationship|Run-time failure|  
|---|---|---|---|  
|[CType Function](../functions/ctype-function.md)|Any data types|Widening or narrowing conversion must be defined between the two data types|Throws <xref:System.InvalidCastException>|  
|[DirectCast Operator](directcast-operator.md)|Any data types|One type must inherit from or implement the other type|Throws <xref:System.InvalidCastException>|  
|`TryCast`|Reference types only|One type must inherit from or implement the other type|Returns [Nothing](../nothing.md)|  
  
## Example  

 The following example shows how to use `TryCast`.  
  
 [!code-vb[VbVbalrKeywords#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrKeywords/VB/Class1.vb#6)]  
  
## See also

- [Widening and Narrowing Conversions](../../programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)
- [Implicit and Explicit Conversions](../../programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)
