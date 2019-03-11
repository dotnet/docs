---
title: "*= Operator - C# Reference"
ms.custom: seodec18
ms.date: 02/26/2019
f1_keywords: 
  - "*=_CSharpKeyword"
helpviewer_keywords: 
  - "*= operator [C#]"
  - "binary multiplication assignment operator (*=) [C#]"
ms.assetid: 2e472155-59db-4dbf-bb94-bcccfa1a794d
---
# \*= Operator (C# Reference)

The multiplication assignment operator.

An expression using the `*=` operator, such as

```csharp
x *= y
```

is equivalent to

```csharp
x = x * y
```

except that `x` is only evaluated once.

For numeric types, the [\* operator](multiplication-operator.md) computes the product of its operands.

The following example demonstrates the usage of the `*=` operator:

[!code-csharp-interactive[multiply and assign](~/samples/snippets/csharp/language-reference/operators/MultiplicationExamples.cs#MultiplyAndAssign)]

## Operator overloadability

If a user-defined type [overloads](../keywords/operator.md) the [multiplication operator](multiplication-operator.md) `*`, the multiplication assignment operator `*=` is implicitly overloaded. A user-defined type cannot explicitly overload the multiplication assignment operator.

## C# language specification

For more information, see the [Compound assignment](~/_csharplang/spec/expressions.md#compound-assignment) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
