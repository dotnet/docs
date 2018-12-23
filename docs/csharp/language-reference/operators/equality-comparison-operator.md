---
title: "== Operator - C# Reference"
ms.custom: seodec18
ms.date: 12/14/2018
f1_keywords: 
  - "==_CSharpKeyword"
helpviewer_keywords: 
  - "== operator [C#]"
  - "equality operator [C#]"
ms.assetid: 34c6b597-caa2-4855-a7cd-38ecdd11bd07
---
# == Operator (C# Reference)

The equality operator `==` returns `true` if its operands are equal, `false` otherwise.

## Value types equality

Operands of the [built-in value types](../keywords/value-types-table.md) are equal if their values are equal:

[!code-csharp-interactive[value types equality](~/samples/snippets/csharp/language-reference/operators/EqualityAndNonEqualityExamples.cs#ValueTypesEquality)]

> [!NOTE]
> For relational operators `==`, `>`, `<`, `>=`, and `<=`, if any of the operands is not a number (<xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType>) the result of operation is `false`. That means that the `NaN` value is neither greater than, less than, nor equal to any other `double` (or `float`) value. For more information and examples, see the <xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType> reference article.

Two operands of the same [enum](../keywords/enum.md) type are equal if the corresponding values of the underlying integral type are equal.

By default, the `==` operator is not defined for a user-defined [struct](../keywords/struct.md) type. A user-defined type can [overload](#operator-overloadability) the `==` operator.

Beginning with C# 7.3, the `==` and [`!=`](not-equal-operator.md) operators are supported by C# [tuples](../../tuples.md). For more information, see the [Equality and tuples](../../tuples.md#equality-and-tuples) section of the [C# tuple types](../../tuples.md) article.

## String equality

Two [string](../keywords/string.md) operands are equal when both of them are `null` or both string instances are of the same length and have identical characters in each character position:

[!code-csharp-interactive[string equality](~/samples/snippets/csharp/language-reference/operators/EqualityAndNonEqualityExamples.cs#StringEquality)]

That is case-sensitive ordinal comparison. For more information about how to compare strings, see [How to compare strings in C#](../../how-to/compare-strings.md).

## Reference types equality

Two other than `string` reference type operands are equal when they refer to the same object:

[!code-csharp-interactive[reference type equality](~/samples/snippets/csharp/language-reference/operators/EqualityAndNonEqualityExamples.cs#ReferenceTypesEquality)]

The example shows that the `==` operator is supported by user-defined reference types. However, a user-defined reference type can overload the `==` operator. If a reference type overloads the `==` operator, use the <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType> method to check if two references of that type refer to the same object.

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `==` operator. If a type overloads the equality operator `==`, it must also overload the [inequality operator](not-equal-operator.md) `!=`.

## C# language specification

For more information, see the [Relational and type-testing operators](~/_csharplang/spec/expressions.md#relational-and-type-testing-operators) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Equality comparisons](../../programming-guide/statements-expressions-operators/equality-comparisons.md)
