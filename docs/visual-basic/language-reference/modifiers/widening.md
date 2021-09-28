---
description: "Learn more about: Widening (Visual Basic)"
title: "Widening"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.widening"
helpviewer_keywords: 
  - "conversions [Visual Basic], type"
  - "type conversion [Visual Basic]"
  - "conversions [Visual Basic], data type"
  - "Widening keyword [Visual Basic]"
  - "data type conversion [Visual Basic]"
ms.assetid: 646ae263-94d3-40a2-b0cc-64f619292f56
---
# Widening (Visual Basic)

Indicates that a conversion operator (`CType`) converts a class or structure to a type that can hold all possible values of the original class or structure.  
  
## Converting with the Widening Keyword  

 The conversion procedure must specify `Public Shared` in addition to `Widening`.  
  
 Widening conversions always succeed at run time and never incur data loss. Examples are `Single` to `Double`, `Char` to `String`, and a derived type to its base type. This last conversion is widening because the derived type contains all the members of the base type and thus is an instance of the base type.  
  
 The consuming code does not have to use `CType` for widening conversions, even if `Option Strict` is `On`.  
  
 The `Widening` keyword can be used in this context:  
  
 [Operator Statement](../statements/operator-statement.md)  
  
 For example definitions of widening and narrowing conversion operators, see [How to: Define a Conversion Operator](../../programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md).  
  
## See also

- [Operator Statement](../statements/operator-statement.md)
- [Narrowing](narrowing.md)
- [Widening and Narrowing Conversions](../../programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)
- [How to: Define an Operator](../../programming-guide/language-features/procedures/how-to-define-an-operator.md)
- [CType Function](../functions/ctype-function.md)
- [Option Strict Statement](../statements/option-strict-statement.md)
- [How to: Define a Conversion Operator](../../programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)
