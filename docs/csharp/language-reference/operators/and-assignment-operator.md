---
title: "&amp;= Operator (C# Reference)"
ms.date: 10/29/2018
f1_keywords: 
  - "&=_CSharpKeyword"
helpviewer_keywords: 
  - "AND assignment operator (&=) [C#]"
  - "&= operator [C#]"
ms.assetid: e8d58f3f-72dd-4b5a-b995-452fcce7e6bb
---
# &amp;= Operator (C# Reference)

The AND assignment operator.

An expression using the `&=` operator, such as

```csharp
x &= y
```

is equivalent to

```csharp
x = x & y
```

except that `x` is only evaluated once.

For integer operands, the [`&` operator](and-operator.md) computes the bitwise logical AND of its operands; for [bool](../keywords/bool.md) operands, it computes the logical AND of its operands.

The following example demonstrates the usage of the `&=` operator:

[!code-csharp-interactive[AND assignment example](~/samples/snippets/csharp/language-reference/operators/AndOperatorExamples.cs#AndAssignmentExample)]

## Operator overloadability

If a user-defined type [overloads](../keywords/operator.md) the [`&` operator](and-operator.md), the AND assignment operator `&=` is implicitly overloaded. A user-defined type cannot explicitly overload the AND assignment operator.

## C# language specification

For more information, see the [Compound assignment](~/_csharplang/spec/expressions.md#compound-assignment) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
