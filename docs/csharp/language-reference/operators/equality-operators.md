---
title: "Equality operators - C# Reference"
ms.date: 03/28/2019
author: pkulikov
f1_keywords: 
  - "==_CSharpKeyword"
  - "!=_CSharpKeyword"
helpviewer_keywords: 
  - "equality operator [C#]"
  - "equals operator [C#]"
  - "== operator [C#]"
  - "inequality operator [C#]"
  - "not equals operator [C#]"
  - "!= operator [C#]"
---
# Equality operators (C# Reference)

The [`==` (equality)](#equality-operator-) and [`!=` (inequality)](#inequality-operator-) operators check if their operands are equal or not.

## Equality operator ==

The equality operator `==` returns `true` if its operands are equal, `false` otherwise.

### Value types equality

Operands of the [built-in value types](../keywords/value-types-table.md) are equal if their values are equal:

[!code-csharp-interactive[value types equality](~/samples/snippets/csharp/language-reference/operators/EqualityAndNonEqualityExamples.cs#ValueTypesEquality)]

> [!NOTE]
> For equality and relational operators `==`, `>`, `<`, `>=`, and `<=`, if any of the operands is not a number (<xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType>), the result of operation is `false`. That means that the `NaN` value is neither greater than, less than, nor equal to any other `double` (or `float`) value, including `NaN`. For more information and examples, see the <xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType> reference article.

Two operands of the same [enum](../keywords/enum.md) type are equal if the corresponding values of the underlying integral type are equal.

User-defined [struct](../keywords/struct.md) types don't support the `==` operator by default. To support the `==` operator, a user-defined struct must [overload](#operator-overloadability) it.

Beginning with C# 7.3, the `==` and `!=` operators are supported by C# [tuples](../../tuples.md). For more information, see the [Equality and tuples](../../tuples.md#equality-and-tuples) section of the [C# tuple types](../../tuples.md) article.

### String equality

Two [string](../keywords/string.md) operands are equal when both of them are `null` or both string instances are of the same length and have identical characters in each character position:

[!code-csharp-interactive[string equality](~/samples/snippets/csharp/language-reference/operators/EqualityAndNonEqualityExamples.cs#StringEquality)]

That is case-sensitive ordinal comparison. For more information about string comparison, see [How to compare strings in C#](../../how-to/compare-strings.md).

### Reference types equality

Two other than `string` reference type operands are equal when they refer to the same object:

[!code-csharp-interactive[reference type equality](~/samples/snippets/csharp/language-reference/operators/EqualityAndNonEqualityExamples.cs#ReferenceTypesEquality)]

As the example shows, user-defined reference types support the `==` operator by default. However, a user-defined reference type can overload the `==` operator. If a reference type overloads the `==` operator, use the <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType> method to check if two references of that type refer to the same object.

## Inequality operator !=

The inequality operator `!=` returns `true` if its operands are not equal, `false` otherwise. For the operands of the [built-in types](../keywords/built-in-types-table.md), the expression `x != y` produces the same result as the expression `!(x == y)`. For more information about type equality, see the [Equality operator](#equality-operator-) section.

The following example demonstrates the usage of the `!=` operator:

[!code-csharp-interactive[non-equality examples](~/samples/snippets/csharp/language-reference/operators/EqualityAndNonEqualityExamples.cs#NonEquality)]

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `==` and `!=` operators. If a type overloads one of the two operators, it must also overload another one.

## C# language specification

For more information, see the [Relational and type-testing operators](~/_csharplang/spec/expressions.md#relational-and-type-testing-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- <xref:System.IEquatable%601?displayProperty=nameWithType>
- <xref:System.Object.Equals%2A?displayProperty=nameWithType>
- <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType>
- [Equality comparisons](../../programming-guide/statements-expressions-operators/equality-comparisons.md)
