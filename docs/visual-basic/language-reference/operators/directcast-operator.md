---
title: "DirectCast Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.directCast"
  - "directCast"
helpviewer_keywords: 
  - "DirectCast keyword [Visual Basic]"
ms.assetid: 63e5a1d0-4d9e-4732-bf8f-e90c0c8784b8
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
---
# DirectCast Operator (Visual Basic)
Introduces a type conversion operation based on inheritance or implementation.  
  
## Remarks  
 `DirectCast` does not use the Visual Basic run-time helper routines for conversion, so it can provide somewhat better performance than `CType` when converting to and from data type `Object`.  
  
 You use the `DirectCast` keyword similar to the way you use the [CType Function](../../../visual-basic/language-reference/functions/ctype-function.md) and the [TryCast Operator](../../../visual-basic/language-reference/operators/trycast-operator.md) keyword. You supply an expression as the first argument and a type to convert it to as the second argument. `DirectCast` requires an inheritance or implementation relationship between the data types of the two arguments. This means that one type must inherit from or implement the other.  
  
## Errors and Failures  
 `DirectCast` generates a compiler error if it detects that no inheritance or implementation relationship exists. But the lack of a compiler error does not guarantee a successful conversion. If the desired conversion is narrowing, it could fail at run time. If this happens, the runtime throws an <xref:System.InvalidCastException> error.  
  
## Conversion Keywords  
 A comparison of the type conversion keywords is as follows.  
  
|Keyword|Data types|Argument relationship|Run-time failure|  
|---|---|---|---|  
|[CType Function](../../../visual-basic/language-reference/functions/ctype-function.md)|Any data types|Widening or narrowing conversion must be defined between the two data types|Throws <xref:System.InvalidCastException>|  
|`DirectCast`|Any data types|One type must inherit from or implement the other type|Throws <xref:System.InvalidCastException>|  
|[TryCast Operator](../../../visual-basic/language-reference/operators/trycast-operator.md)|Reference types only|One type must inherit from or implement the other type|Returns [Nothing](../../../visual-basic/language-reference/nothing.md)|  
  
## Example  
 The following example demonstrates two uses of `DirectCast`, one that fails at run time and one that succeeds.  
  
 [!code-vb[VbVbalrKeywords#1](../../../visual-basic/language-reference/codesnippet/VisualBasic/directcast-operator_1.vb)]  
  
 In the preceding example, the run-time type of `q` is `Double`. `CType` succeeds because `Double` can be converted to `Integer`. However, the first `DirectCast` fails at run time because the run-time type of `Double` has no inheritance relationship with `Integer`, even though a conversion exists. The second `DirectCast` succeeds because it converts from type <xref:System.Windows.Forms.Form> to type <xref:System.Windows.Forms.Control>, from which <xref:System.Windows.Forms.Form> inherits.  
  
## See Also  
 <xref:System.Convert.ChangeType%2A?displayProperty=nameWithType>  
 [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)  
 [Implicit and Explicit Conversions](../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)
