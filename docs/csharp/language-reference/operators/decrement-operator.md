---
title: "-- Operator - C# Reference"
ms.custom: seodec18

ms.date: 11/26/2018
f1_keywords: 
  - "--_CSharpKeyword"
helpviewer_keywords: 
  - "-- operator [C#]"
  - "decrement operator (--) [C#]"
ms.assetid: 6b9cfe86-63c7-421f-9379-c9690fea8720
---
# -- Operator (C# Reference)

The unary decrement operator `--` decrements its operand by 1. It's supported in two forms: the postfix decrement operator, `x--`, and the prefix decrement operator, `--x`.

## Postfix decrement operator

The result of `x--` is the value of `x` *before* the operation, as the following example shows:

[!code-csharp-interactive[postfix decrement](~/samples/snippets/csharp/language-reference/operators/DecrementAndIncrementExamples.cs#PostfixDecrement)]

## Prefix decrement operator

The result of `--x` is the value of `x` *after* the operation, as the following example shows:

[!code-csharp-interactive[prefix decrement](~/samples/snippets/csharp/language-reference/operators/DecrementAndIncrementExamples.cs#PrefixDecrement)]

## Remarks

The decrement operator is predefined for all [integral types](../keywords/integral-types-table.md) (including the [char](../keywords/char.md) type), [floating-point types](../keywords/floating-point-types-table.md), and any [enum](../keywords/enum.md) type.

An operand of the decrement operator must be a variable, a [property](../../programming-guide/classes-and-structs/properties.md) access, or an [indexer](../../../csharp/programming-guide/indexers/index.md) access.

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `--` operator.

## C# language specification

For more information, see the [Postfix increment and decrement operators](~/_csharplang/spec/expressions.md#postfix-increment-and-decrement-operators) and [Prefix increment and decrement operators](~/_csharplang/spec/expressions.md#prefix-increment-and-decrement-operators) sections of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [++ Operator](increment-operator.md)
- [How to: increment and decrement pointers](../../programming-guide/unsafe-code-pointers/how-to-increment-and-decrement-pointers.md)
