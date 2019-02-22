---
title: "!= Operator - C# Reference"
ms.custom: seodec18
ms.date: 12/14/2018
f1_keywords: 
  - "!=_CSharpKeyword"
helpviewer_keywords: 
  - "inequality operator (!=) [C#]"
  - "not equals operator (!=) [C#]"
  - "!= operator [C#]"
ms.assetid: eeff7a4e-ad6f-462d-9f8d-49e9b91c6c97
---
# != Operator (C# Reference)

The inequality operator `!=` returns `true` if its operands are not equal, `false` otherwise. For the operands of the [built-in types](../keywords/built-in-types-table.md), the expression `x != y` produces the same result as the expression `!(x == y)`. For more information, see the [== Operator](equality-comparison-operator.md) article.

The following example demonstrates the usage of the `!=` operator:

[!code-csharp-interactive[non-equality examples](~/samples/snippets/csharp/language-reference/operators/EqualityAndNonEqualityExamples.cs#NonEquality)]

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `!=` operator. If a type overloads the inequality operator `!=`, it must also overload the [equality operator](equality-comparison-operator.md) `==`.

## C# language specification

For more information, see the [Relational and type-testing operators](~/_csharplang/spec/expressions.md#relational-and-type-testing-operators) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Equality comparisons](../../programming-guide/statements-expressions-operators/equality-comparisons.md)
