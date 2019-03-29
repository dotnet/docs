---
title: ">>= operator - C# Reference"
ms.custom: seodec18
ms.date: 02/12/2019
f1_keywords: 
  - ">>=_CSharpKeyword"
helpviewer_keywords: 
  - "right shift assignment operator (>>=) [C#]"
  - ">>= operator (right-shift assignment) [C#]"
ms.assetid: b593778c-b9b4-440d-8b29-c1ac22cb81c0
---
# >>= operator (C# Reference)

The right-shift assignment operator.

An expression using the `>>=` operator, such as

```csharp
x >>= y
```

is equivalent to

```csharp
x = x >> y
```

except that `x` is only evaluated once.

The [`>>` operator](right-shift-operator.md) shifts its first operand right by the number of bits defined by its second operand.

The following example demonstrates the usage of the `>>=` operator:

[!code-csharp-interactive[right shift assignment](~/samples/snippets/csharp/language-reference/operators/ShiftOperatorsExamples.cs#RightShiftAssignment)]

## Operator overloadability

If a user-defined type [overloads](../keywords/operator.md) the [`>>` operator](right-shift-operator.md), the right-shift assignment operator `>>=` is implicitly overloaded. A user-defined type cannot explicitly overload the right-shift assignment operator.

## C# language specification

For more information, see the [Compound assignment](~/_csharplang/spec/expressions.md#compound-assignment) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# operators](index.md)