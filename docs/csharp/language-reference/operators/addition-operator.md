---
title: "+ Operator (C# Reference)"
ms.date: 10/22/2018
f1_keywords: 
  - "+_CSharpKeyword"
helpviewer_keywords: 
  - "+ operator [C#]"
  - "concatenation operator [C#]"
  - "addition operator [C#]"
ms.assetid: 93e56486-bb42-43c1-bd43-60af11e64e67
---
# + Operator (C# Reference)

The `+` operator is supported in two forms: a unary plus operator or a binary addition operator.

## Unary plus operator

The unary `+` operator returns the value of its operand. It's supported by all numeric types.

## Numeric addition

For numeric types, the `+` operator computes the sum of its operands:

[!code-csharp-interactive[numeric addition](~/samples/snippets/csharp/language-reference/operators/AdditionExamples.cs#AddNumerics)]

## String concatenation

When one or both operands are of type [string](../keywords/string.md), the `+` operator concatenates the string representations of its operands:

[!code-csharp-interactive[string concatenation](~/samples/snippets/csharp/language-reference/operators/AdditionExamples.cs#AddStrings)]

Starting with C# 6, [string interpolation](../tokens/interpolated.md) provides a more convenient way to format strings:

[!code-csharp-interactive[string interpolation](~/samples/snippets/csharp/language-reference/operators/AdditionExamples.cs#UseStringInterpolation)]

## Delegate combination

For [delegate](../keywords/delegate.md) types, the `+` operator returns a new delegate instance that, when invoked, invokes the first operand and then invokes the second operand. If any of the operands is `null`, the `+` operator returns the value of another operand (which also might be `null`). The following example shows how delegates can be combined with the `+` operator:

[!code-csharp-interactive[delegate combination](~/samples/snippets/csharp/language-reference/operators/AdditionExamples.cs#AddDelegates)]

For more information about delegate types, see [Delegates](../../programming-guide/delegates/index.md).

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the unary and binary `+` operators. When a binary `+` operator is overloaded, the [addition assignment operator](addition-assignment-operator.md) `+=` is also implicitly overloaded.

## C# language specification

For more information, see the [Unary plus operator](~/_csharplang/spec/expressions.md#unary-plus-operator) and [Addition operator](~/_csharplang/spec/expressions.md#addition-operator) sections of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [String interpolation](../tokens/interpolated.md)
- [How to: Concatenate Multiple Strings](../../how-to/concatenate-multiple-strings.md)
- [Delegates](../../programming-guide/delegates/index.md)
- [Checked and unchecked](../keywords/checked-and-unchecked.md)
