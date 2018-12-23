---
title: "/= Operator - C# Reference"
ms.custom: seodec18
ms.date: 12/13/2018
f1_keywords: 
  - "/=_CSharpKeyword"
helpviewer_keywords: 
  - "division assignment operator (/=) [C#]"
  - "/= (division assignment operator) [C#]"
ms.assetid: 50fc02b0-ee9c-4c3e-b58d-d591282caf1c
---
# /= Operator (C# Reference)

The division assignment operator.

An expression using the `/=` operator, such as

```csharp
x /= y
```

is equivalent to

```csharp
x = x / y
```

except that `x` is only evaluated once.

The [division operator](division-operator.md) `/` divides its first operand by its second operand. It's supported by all numeric types.

The following example demonstrates the usage of the `/=` operator:

[!code-csharp-interactive[divide and assign](~/samples/snippets/csharp/language-reference/operators/DivisionExamples.cs#DivisionAssignment)]

## Operator overloadability

If a user-defined type [overloads](../keywords/operator.md) the [division operator](division-operator.md) `/`, the division assignment operator `/=` is implicitly overloaded. A user-defined type cannot explicitly overload the division assignment operator.

## C# language specification

For more information, see the [Compound assignment](~/_csharplang/spec/expressions.md#compound-assignment) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
