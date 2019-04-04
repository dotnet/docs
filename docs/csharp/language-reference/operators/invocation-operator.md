---
title: "() operator - C# Reference"
ms.custom: seodec18
ms.date: 01/15/2019
f1_keywords: 
  - "()_CSharpKeyword"
helpviewer_keywords: 
  - "type conversion [C#], () operator"
  - "cast operator [C#]"
  - "() operator [C#]"
ms.assetid: 846e1f94-8a8c-42fc-a42c-fbd38e70d8cc
---
# () operator (C# Reference)

Parentheses, `()`, are typically used for method or delegate invocation or in cast expressions.

You also use parentheses to specify the order in which to evaluate operations in an expression. For more information, see the [Adding parentheses](../../programming-guide/statements-expressions-operators/operators.md#adding-parentheses) section of the [Operators](../../programming-guide/statements-expressions-operators/operators.md) article. For the list of operators ordered by precedence level, see [C# operators](index.md).

## Method invocation

The following example demonstrates how to invoke a method, with or without arguments, and a delegate:

[!code-csharp-interactive[use for invocation](~/samples/snippets/csharp/language-reference/operators/InvocationOperatorExamples.cs#Invocation)]

You also use parentheses when you invoke a [constructor](../../programming-guide/classes-and-structs/constructors.md) with a [`new`](../keywords/new-operator.md) operator.

For more information about methods, see [Methods](../../programming-guide/classes-and-structs/methods.md). For more information about delegates, see [Delegates](../../programming-guide/delegates/index.md).

## Cast expression

A cast expression of the form `(T)E` invokes a conversion operator to convert the value of expression `E` to type `T`. If no explicit conversion exists from the type of `E` to type `T`, a compile-time error occurs. For information about how to define a conversion operator, see the [explicit](../keywords/explicit.md) and [implicit](../keywords/implicit.md) keyword articles.

The following example demonstrates type conversion between numeric types:

[!code-csharp-interactive[use for cast](~/samples/snippets/csharp/language-reference/operators/InvocationOperatorExamples.cs#Cast)]

For more information about predefined explicit conversions between numeric types, see [Explicit numeric conversions table](../keywords/explicit-numeric-conversions-table.md).

For more information, see [Casting and type conversions](../../programming-guide/types/casting-and-type-conversions.md) and [Conversion operators](../../programming-guide/statements-expressions-operators/conversion-operators.md).

## Operator overloadability

The operator `()` cannot be overloaded.

## C# language specification

For more information, see the [Invocation expressions](~/_csharplang/spec/expressions.md#invocation-expressions) and [Cast expressions](~/_csharplang/spec/expressions.md#cast-expressions) sections of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)