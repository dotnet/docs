---
title: "<<= operator - C# Reference"
ms.custom: seodec18
ms.date: 02/12/2019
f1_keywords: 
  - "<<=_CSharpKeyword"
helpviewer_keywords: 
  - "<<= operator (left-shift assignment) [C#]"
  - "left shift assignment operator (<<=) [C#]"
ms.assetid: 3bc99c78-1edb-4827-86fc-bce6c3048871
---
# \<\<= operator (C# Reference)

The left-shift assignment operator.

An expression using the `<<=` operator, such as

```csharp
x <<= y
```

is equivalent to

```csharp
x = x << y
```

except that `x` is only evaluated once.

The [`<<` operator](left-shift-operator.md) shifts its first operand left by the number of bits defined by its second operand.

The following example demonstrates the usage of the `<<=` operator:

[!code-csharp-interactive[left shift assignment](~/samples/snippets/csharp/language-reference/operators/ShiftOperatorsExamples.cs#LeftShiftAssignment)]

## Operator overloadability

If a user-defined type [overloads](../keywords/operator.md) the [`<<` operator](left-shift-operator.md), the left-shift assignment operator `<<=` is implicitly overloaded. A user-defined type cannot explicitly overload the left-shift assignment operator.

## C# language specification

For more information, see the [Compound assignment](~/_csharplang/spec/expressions.md#compound-assignment) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
