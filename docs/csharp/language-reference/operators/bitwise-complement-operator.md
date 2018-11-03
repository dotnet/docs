---
title: "~ Operator (C# Reference)"
ms.date: 11/05/2018
f1_keywords: 
  - "~_CSharpKeyword"
helpviewer_keywords: 
  - "tilde (~) one's complement operator [C#]"
  - "~ operator [C#]"
  - "~ [C#], bitwise complement operator"
  - "bitwise complement operator [C#]"
ms.assetid: 11bc078a-50e2-4d7e-9896-67ef669dc602
---
# ~ Operator (C# Reference)

The bitwise complement `~` operator is a unary operator that produces a bitwise complement of its operand, that is, reverses each bit in the operand's binary representation. All integer types support the `~` operator.

> [!NOTE]
> The `~` symbol is also used to declare finalizers. For more information, see [Finalizers](../../programming-guide/classes-and-structs/destructors.md).

The following example demonstrates the usage of the `~` operator:

[!code-csharp-interactive[bitwise NOT](~/samples/snippets/csharp/language-reference/operators/BitwiseComplementExamples.cs#Example)]

> [!NOTE]
> The preceding example uses the binary literals that are [introduced](../../whats-new/csharp-7.md#numeric-literal-syntax-improvements) in C# 7.0 and [enhanced](../../whats-new/csharp-7-2.md#leading-underscores-in-numeric-literals) in C# 7.2.

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `~` operator.

## C# language specification

For more information, see the [Bitwise complement operator](~/_csharplang/spec/expressions.md#bitwise-complement-operator) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Finalizers](../../programming-guide/classes-and-structs/destructors.md)
- [& operator](and-operator.md)
- [| operator](or-operator.md)
- [^ operator](xor-operator.md)
