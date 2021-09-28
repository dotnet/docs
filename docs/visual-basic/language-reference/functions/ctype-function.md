---
description: "Learn more about: CType Function (Visual Basic)"
title: "CType Function"
ms.date: 07/20/2015
f1_keywords:
  - "vb.CType"
helpviewer_keywords:
  - "expression conversion results"
  - "explicit data type conversions [Visual Basic]"
  - "CType function"
  - "conversions [Visual Basic], expression"
ms.assetid: dd4b29e7-6fa1-428c-877e-69955420bb72
---

# CType Function (Visual Basic)

Returns the result of explicitly converting an expression to a specified data type, object, structure, class, or interface.

## Syntax

```vb
CType(expression, typename)
```

## Parts

`expression`
Any valid expression. If the value of `expression` is outside the range allowed by `typename`, Visual Basic throws an exception.

`typename`
Any expression that is legal within an `As` clause in a `Dim` statement, that is, the name of any data type, object, structure, class, or interface.

## Remarks

> [!TIP]
> You can also use the following functions to perform a type conversion:
>
> - Type conversion functions such as `CByte`, `CDbl`, and `CInt` that perform a conversion to a specific data type. For more information, see [Type Conversion Functions](type-conversion-functions.md).
> - [DirectCast Operator](../operators/directcast-operator.md) or [TryCast Operator](../operators/trycast-operator.md). These operators require that one type inherit from or implement the other type. They can provide somewhat better performance than `CType` when converting to and from the `Object` data type.

`CType` is compiled inline, which means that the conversion code is part of the code that evaluates the expression. In some cases, the code runs faster because no procedures are called to perform the conversion.

If no conversion is defined from `expression` to `typename` (for example, from `Integer` to `Date`), Visual Basic displays a compile-time error message.

If a conversion fails at run time, the appropriate exception is thrown. If a narrowing conversion fails, an <xref:System.OverflowException> is the most common result. If the conversion is undefined, an <xref:System.InvalidCastException> in thrown. For example, this can happen  if `expression` is of type `Object` and its run-time type has no conversion to `typename`.

If the data type of `expression` or `typename` is a class or structure you've defined, you can define `CType` on that class or structure as a conversion operator. This makes `CType` act as an *overloaded operator*. If you do this, you can control the behavior of conversions to and from your class or structure, including the exceptions that can be thrown.

## Overloading

The `CType` operator can also be overloaded on a class or structure defined outside your code. If your code converts to or from such a class or structure, be sure you understand the behavior of its `CType` operator. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).

## Converting Dynamic Objects

Type conversions of dynamic objects are performed by user-defined dynamic conversions that use the <xref:System.Dynamic.DynamicObject.TryConvert%2A> or <xref:System.Dynamic.DynamicMetaObject.BindConvert%2A> methods. If you're working with dynamic objects, use the <xref:Microsoft.VisualBasic.Conversion.CTypeDynamic%2A> method to convert the dynamic object.

## Example

The following example uses the `CType` function to convert an expression to the `Single` data type.

[!code-vb[VbVbalrFunctions#24](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrFunctions/VB/Class1.vb#24)]

For additional examples, see [Implicit and Explicit Conversions](../../programming-guide/language-features/data-types/implicit-and-explicit-conversions.md).

## See also

- <xref:System.OverflowException>
- <xref:System.InvalidCastException>
- [Type Conversion Functions](type-conversion-functions.md)
- [Conversion Functions](conversion-functions.md)
- [Operator Statement](../statements/operator-statement.md)
- [How to: Define a Conversion Operator](../../programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)
- [Type Conversion in the .NET Framework](../../../standard/base-types/type-conversion.md)
