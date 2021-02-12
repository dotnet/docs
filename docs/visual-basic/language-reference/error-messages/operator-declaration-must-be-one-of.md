---
description: "Learn more about: BC33000: Operator declaration must be one of:  +,-,*,,/,^, &amp;, Like, Mod, And, Or, Xor, Not, <<, >>..."
title: "Operator declaration must be one of:  +,-,*,-,-,^, &amp;, Like, Mod, And, Or, Xor, Not, <<, >>, =, <>, <, <=, >, >=, CType, IsTrue, IsFalse"
ms.date: 07/20/2015
f1_keywords:
  - "bc33000"
  - "vbc33000"
helpviewer_keywords:
  - "BC33000"
ms.assetid: 15c5d8eb-3a8c-4141-8f41-33151afabf97
---
# BC33000: Operator declaration must be one of:  +,-,*,\,/,^, &amp;, Like, Mod, And, Or, Xor, Not, \<\<, >>...

You can declare only an operator that is eligible for overloading. The following table lists the operators you can declare.

|Type|Operators|
|----------|---------------|
|Unary|`+`, `-`, `IsFalse`, `IsTrue`, `Not`|
|Binary|`+`, `-`, `*`, `/`, `\`, `&`, `^`, `>>`, `<<`, `=`, `<>`, `>`, `>=`, `<`, `<=`, `And`, `Like`, `Mod`, `Or`, `Xor`|
|Conversion (unary)|`CType`|

 Note that the `=` operator in the binary list is the comparison operator, not the assignment operator.

 **Error ID:** BC33000

## To correct this error

- Select an operator from the set of overloadable operators.

- If you need the functionality of overloading an operator that you cannot overload directly, create a `Function` procedure that takes the appropriate parameters and returns the appropriate value.

## See also

- [Operator Statement](../statements/operator-statement.md)
- [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md)
- [How to: Define an Operator](../../programming-guide/language-features/procedures/how-to-define-an-operator.md)
- [How to: Define a Conversion Operator](../../programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)
- [Function Statement](../statements/function-statement.md)
