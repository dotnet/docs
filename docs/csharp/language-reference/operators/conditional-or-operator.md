---
title: "|| Operator (C# Reference)"
ms.date: 11/06/2018
f1_keywords: 
  - "||_CSharpKeyword"
helpviewer_keywords: 
  - "logical OR operator [C#]"
  - "conditional-OR operator (||) [C#]"
  - "|| operator [C#]"
ms.assetid: 7d442d8e-400d-421f-b4d2-034bf82bcbdc
---
# || Operator (C# Reference)

The conditional logical OR operator `||`, also known as the "short-circuiting" logical OR operator, computes the logical OR of its [bool](../keywords/bool.md) operands. The result of `x || y` is `true` if either `x` or `y` evaluates to `true`. Otherwise, the result is `false`. If the first operand evaluates to `true`, the second operand is not evaluated and the result of operation is `true`. The following example demonstrates that behavior:

[!code-csharp-interactive[conditional logical OR](~/samples/snippets/csharp/language-reference/operators/ConditionalLogicalOperatorsExamples.cs#Or)]

The [logical OR operator](or-operator.md) `|` also computes the logical OR of its `bool` operands, but always evaluates both operands.

## Operator overloadability

A user-defined type cannot overload the conditional logical OR operator. However, if a user-defined type overloads the [logical OR](or-operator.md) and [true and false operators](../keywords/true-false-operators.md) in a certain way, the `||` operation can be evaluated for the operands of that type. For more information, see the [User-defined conditional logical operators](~/_csharplang/spec/expressions.md#user-defined-conditional-logical-operators) section of the [C# language specification](../language-specification/index.md).

## C# language specification

For more information, see the [Conditional logical operators](~/_csharplang/spec/expressions.md#conditional-logical-operators) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [&& operator](conditional-and-operator.md)
- [! operator](logical-negation-operator.md)
- [| operator](or-operator.md)
