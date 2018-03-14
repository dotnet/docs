---
title: "Widening (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.widening"
helpviewer_keywords: 
  - "conversions [Visual Basic], type"
  - "type conversion [Visual Basic]"
  - "conversions [Visual Basic], data type"
  - "Widening keyword [Visual Basic]"
  - "data type conversion [Visual Basic]"
ms.assetid: 646ae263-94d3-40a2-b0cc-64f619292f56
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# Widening (Visual Basic)
Indicates that a conversion operator (`CType`) converts a class or structure to a type that can hold all possible values of the original class or structure.  
  
## Converting with the Widening Keyword  
 The conversion procedure must specify `Public Shared` in addition to `Widening`.  
  
 Widening conversions always succeed at run time and never incur data loss. Examples are `Single` to `Double`, `Char` to `String`, and a derived type to its base type. This last conversion is widening because the derived type contains all the members of the base type and thus is an instance of the base type.  
  
 The consuming code does not have to use `CType` for widening conversions, even if `Option Strict` is `On`.  
  
 The `Widening` keyword can be used in this context:  
  
 [Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md)  
  
 For example definitions of widening and narrowing conversion operators, see [How to: Define a Conversion Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md).  
  
## See Also  
 [Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md)  
 [Narrowing](../../../visual-basic/language-reference/modifiers/narrowing.md)  
 [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)  
 [How to: Define an Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-an-operator.md)  
 [CType Function](../../../visual-basic/language-reference/functions/ctype-function.md)  
 [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md)  
 [How to: Define a Conversion Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)
