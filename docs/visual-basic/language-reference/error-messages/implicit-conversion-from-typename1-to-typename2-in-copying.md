---
description: "Learn more about: BC41999: Implicit conversion from '<typename1>' to '<typename2>' in copying the value of 'ByRef' parameter '<parametername>' back to the matching argument."
title: "Implicit conversion from '<typename1>' to '<typename2>' in copying the value of 'ByRef' parameter '<parametername>' back to the matching argument."
ms.date: 07/20/2015
f1_keywords:
  - "vbc41999"
  - "bc41999"
helpviewer_keywords:
  - "BC41999"
ms.assetid: ae48c738-dff8-4c0f-8931-bbb70b2c8b03
---
# BC41999: Implicit conversion from '\<typename1>' to '\<typename2>' in copying the value of 'ByRef' parameter '\<parametername>' back to the matching argument.

A procedure is called with a [ByRef](../modifiers/byref.md) argument of a different type than that of its corresponding parameter.

 If you pass an argument `ByRef`, Visual Basic sometimes copies the argument value into a local variable in the procedure instead of passing a reference. In such a case, when the procedure returns, Visual Basic must then copy the local variable value back into the argument in the calling code.

 If a `ByRef` argument value is copied into the procedure and the argument and parameter are of the same type, no conversion is necessary. But if the types are different, Visual Basic must convert in both directions. Because you cannot use `CType` or any of the other conversion keywords on a procedure argument or parameter, such a conversion is always implicit.

 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC41999

## To correct this error

- If possible, use a calling argument of the same type as the procedure parameter, so Visual Basic does not need to do any conversion.

- If you need to call the procedure with an argument type different from the parameter type but do not need to return a value into the calling argument, define the parameter to be [ByVal](../modifiers/byval.md) instead of `ByRef`.

## See also

- [Procedures](../../programming-guide/language-features/procedures/index.md)
- [Procedure Parameters and Arguments](../../programming-guide/language-features/procedures/procedure-parameters-and-arguments.md)
- [Passing Arguments by Value and by Reference](../../programming-guide/language-features/procedures/passing-arguments-by-value-and-by-reference.md)
- [Implicit and Explicit Conversions](../../programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)
