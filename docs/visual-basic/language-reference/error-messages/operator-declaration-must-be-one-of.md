---
title: "Operator declaration must be one of:  +,-,*,-,-,^, &amp;, Like, Mod, And, Or, Xor, Not, <<, >>, =, <>, <, <=, >, >=, CType, IsTrue, IsFalse"
ms.date: 07/20/2015
f1_keywords: 
  - "bc33000"
  - "vbc33000"
helpviewer_keywords: 
  - "BC33000"
ms.assetid: 15c5d8eb-3a8c-4141-8f41-33151afabf97
---
# Operator declaration must be one of:  +,-,*,\,/,^, &amp;, Like, Mod, And, Or, Xor, Not, \<\<, >>...
You can declare only an operator that is eligible for overloading. The following table lists the operators you can declare.  
  
|Type|Operators|  
|----------|---------------|  
|Unary|`+`, `-`, `IsFalse`, `IsTrue`, `Not`|  
|Binary|`+`, `-`, `*`, `/`, `\`, `&`, `^`, `>>`, `<<`, `=`, `<>`, `>`, `>=`, `<`, `<=`, `And`, `Like`, `Mod`, `Or`, `Xor`|  
|Conversion (unary)|`CType`|  
  
 Note that the `=` operator in the binary list is the comparison operator, not the assignment operator.  
  
 **Error ID:** BC33000  
  
## To correct this error  
  
1. Select an operator from the set of overloadable operators.  
  
2. If you need the functionality of overloading an operator that you cannot overload directly, create a `Function` procedure that takes the appropriate parameters and returns the appropriate value.  
  
## See also

- [Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md)
- [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md)
- [How to: Define an Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-an-operator.md)
- [How to: Define a Conversion Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)
- [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)
