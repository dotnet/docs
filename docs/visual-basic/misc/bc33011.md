---
description: "Learn more about: Operators must be declared 'Public'"
title: "Operators must be declared 'Public'"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc33011"
  - "bc33011"
helpviewer_keywords: 
  - "BC33011"
ms.assetid: 67fc0dee-4ef5-4afc-a63a-f7d20bce7954
---
# Operators must be declared 'Public'

An [Operator Statement](../language-reference/statements/operator-statement.md) does not include the [Public](../language-reference/modifiers/public.md) keyword.  
  
 An `Operator` procedure requires both the `Public` and [Shared](../language-reference/modifiers/shared.md) keywords, and a conversion operator also requires either the [Widening](../language-reference/modifiers/widening.md) or the [Narrowing](../language-reference/modifiers/narrowing.md) keyword.  
  
 **Error ID:** BC33011  
  
## To correct this error  
  
- Add the `Public` keyword to the `Operator` statement.  
  
## See also

- [Operator Procedures](../programming-guide/language-features/procedures/operator-procedures.md)
- [Operator Statement](../language-reference/statements/operator-statement.md)
- [How to: Define an Operator](../programming-guide/language-features/procedures/how-to-define-an-operator.md)
- [How to: Define a Conversion Operator](../programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)
