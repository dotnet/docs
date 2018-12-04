---
title: "++ Operator (C# Reference)"
ms.date: 11/26/2018
f1_keywords: 
  - "++_CSharpKeyword"
helpviewer_keywords: 
  - "increment operator (++) [C#]"
  - "++ operator [C#]"
ms.assetid: e9dec353-070b-44fb-98ed-eb8fdf753feb
---
# ++ Operator (C# Reference)

The unary increment operator `++` increments its operand by 1. It's supported in two forms: the postfix increment operator, `x++`, and the prefix increment operator, `++x`.

## Postfix increment operator

The result of `x++` is the value of `x` *before* the operation, as the following example shows:

[!code-csharp-interactive[postfix increment](~/samples/snippets/csharp/language-reference/operators/DecrementAndIncrementExamples.cs#PostfixIncrement)]

## Prefix increment operator

The result of `++x` is the value of `x` *after* the operation, as the following example shows:

[!code-csharp-interactive[prefix increment](~/samples/snippets/csharp/language-reference/operators/DecrementAndIncrementExamples.cs#PrefixIncrement)]

## Remarks

The increment operator is predefined for all [integral types](../keywords/integral-types-table.md) (including the [char](../keywords/char.md) type), [floating-point types](../keywords/floating-point-types-table.md), and any [enum](../keywords/enum.md) type.

An operand of the increment operator must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md) access, or an [indexer](../../../csharp/programming-guide/indexers/index.md) access.

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `++` operator.

## C# language specification

For more information, see the [Postfix increment and decrement operators](~/_csharplang/spec/expressions.md#postfix-increment-and-decrement-operators) and [Prefix increment and decrement operators](~/_csharplang/spec/expressions.md#prefix-increment-and-decrement-operators) sections of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [-- Operator](decrement-operator.md)
- [How to: increment and decrement pointers](../../programming-guide/unsafe-code-pointers/how-to-increment-and-decrement-pointers.md)
