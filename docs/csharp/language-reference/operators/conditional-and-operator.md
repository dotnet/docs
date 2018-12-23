---
title: "&amp;&amp; Operator - C# Reference"
ms.custom: seodec18

ms.date: 11/06/2018
f1_keywords: 
  - "&&_CSharpKeyword"
helpviewer_keywords: 
  - "&& operator [C#]"
  - "logical AND operator [C#]"
ms.assetid: 2e4f0a1c-92a3-40f8-8e3b-17b607f20c31
---
# &amp;&amp; Operator (C# Reference)

The conditional logical AND operator `&&`, also known as the "short-circuiting" logical AND operator, computes the logical AND of its [bool](../keywords/bool.md) operands. The result of `x && y` is `true` if both `x` and `y` evaluate to `true`. Otherwise, the result is `false`. If the first operand evaluates to `false`, the second operand is not evaluated and the result of operation is `false`. The following example demonstrates that behavior:

[!code-csharp-interactive[conditional logical AND](~/samples/snippets/csharp/language-reference/operators/ConditionalLogicalOperatorsExamples.cs#And)]

The [logical AND operator](and-operator.md) `&` also computes the logical AND of its `bool` operands, but always evaluates both operands.

## Operator overloadability

A user-defined type cannot overload the conditional logical AND operator. However, if a user-defined type overloads the [logical AND](and-operator.md) and [true and false operators](../keywords/true-false-operators.md) in a certain way, the `&&` operation can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](../language-specification/index.md).

## C# language specification

For more information, see the [Conditional logical operators](~/_csharplang/spec/expressions.md#conditional-logical-operators) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [|| operator](conditional-or-operator.md)
- [! operator](logical-negation-operator.md)
- [& operator](and-operator.md)
