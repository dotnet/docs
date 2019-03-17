---
title: "! operator - C# Reference"
ms.custom: seodec18
ms.date: 02/14/2019
f1_keywords: 
  - "!_CSharpKeyword"
helpviewer_keywords: 
  - "! operator [C#]"
  - "logical negation operator (!) [C#]"
  - "NOT operator [C#]"
ms.assetid: f5ae133f-8f64-4560-b34f-cd9cd5eed4ad
---
# ! operator (C# Reference)

The logical negation operator `!` is a unary operator that computes logical negation of its [bool](../keywords/bool.md) operand. That is, it produces `true`, if the operand is `false`, and `false`, if the operand is `true`:

[!code-csharp-interactive[logical negation](~/samples/snippets/csharp/language-reference/operators/LogicalNegationExamples.cs#Example)]

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `!` operator.

## C# language specification

For more information, see the [Logical negation operator](~/_csharplang/spec/expressions.md#logical-negation-operator) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)