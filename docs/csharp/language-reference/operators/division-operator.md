---
title: "/ Operator - C# Reference"
ms.custom: seodec18
ms.date: 12/13/2018
f1_keywords: 
  - "/_CSharpKeyword"
helpviewer_keywords: 
  - "/ operator [C#]"
  - "division operator [C#]"
ms.assetid: d155e496-678f-4efa-bebe-2bd08da2c5af
---
# / Operator (C# Reference)

The division operator `/` divides its first operand by its second operand. All numeric types support the division operator.

## Integer division

For the operands of integer types, the result of the `/` operator is of an integer type and equals the quotient of the two operands rounded towards zero:

[!code-csharp-interactive[integer division](~/samples/snippets/csharp/language-reference/operators/DivisionExamples.cs#Integer)]

To obtain the quotient of the two operands as a floating-point number, use the `float`, `double`, or `decimal` type:

[!code-csharp-interactive[integer as floating-point division](~/samples/snippets/csharp/language-reference/operators/DivisionExamples.cs#IntegerAsFloatingPoint)]

## Floating-point division

For the `float`, `double`, and `decimal` types, the result of the `/` operator is the quotient of the two operands:

[!code-csharp-interactive[floating-point division](~/samples/snippets/csharp/language-reference/operators/DivisionExamples.cs#FloatingPoint)]

If one of the operands is `decimal`, another operand can be neither `float` nor `double`, because neither `float` nor `double` is implicitly convertible to `decimal`. You must explicitly convert the `float` or `double` operand to the `decimal` type. For more information about implicit conversions between numeric types, see [Implicit numeric conversions table](../keywords/implicit-numeric-conversions-table.md).

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `/` operator. When the `/` operator is overloaded, the [division assignment operator](division-assignment-operator.md) `/=` is also implicitly overloaded.

## C# language specification

For more information, see the [Division operator](~/_csharplang/spec/expressions.md#division-operator) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [% Operator](remainder-operator.md)
