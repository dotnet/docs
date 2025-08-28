---
description: "Learn more about: Narrowing (Visual Basic)"
title: "Narrowing"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.narrowing"
helpviewer_keywords: 
  - "conversions [Visual Basic], type"
  - "type conversion [Visual Basic]"
  - "conversions [Visual Basic], data type"
  - "Narrowing keyword [Visual Basic]"
  - "data type conversion [Visual Basic]"
ms.assetid: a207ee91-aca4-4771-b4e2-713f029bf2bb
---
# Narrowing (Visual Basic)

Indicates that a conversion operator (`CType`) converts a class or structure to a type that might not be able to hold some of the possible values of the original class or structure.  
  
## Converting with the Narrowing Keyword  

 The conversion procedure must specify `Public Shared` in addition to `Narrowing`.  
  
 Narrowing conversions do not always succeed at run time, and can fail or incur data loss. Examples are `Long` to `Integer`, `String` to `Date`, and a base type to a derived type. This last conversion is narrowing because the base type might not contain all the members of the derived type and thus is not an instance of the derived type.  
  
 If `Option Strict` is `On`, the consuming code must use `CType` for all narrowing conversions.  
  
 The `Narrowing` keyword can be used in this context:  
  
 [Operator Statement](../statements/operator-statement.md)  
  
## See also

- [Operator Statement](../statements/operator-statement.md)
- [Widening](widening.md)
- [Widening and Narrowing Conversions](../../programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)
- [How to: Define an Operator](../../programming-guide/language-features/procedures/how-to-define-an-operator.md)
- [CType Operator](ctype-operator.md)
- [Option Strict Statement](../statements/option-strict-statement.md)
