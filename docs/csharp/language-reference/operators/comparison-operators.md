---
title: "Comparison operators - C# reference"
description: "Learn about C# comparison operators that you can use to check the order of numeric values."
ms.date: 04/25/2019
author: pkulikov
f1_keywords: 
  - "<_CSharpKeyword"
  - ">_CSharpKeyword"
  - "<=_CSharpKeyword"
  - ">=_CSharpKeyword"
helpviewer_keywords: 
  - "comparison operators [C#]"
  - "relational operators [C#]"
  - "less than operator [C#]"
  - "< operator [C#]"
  - "greater than operator [C#]"
  - "> operator [C#]"
  - "less than or equal to operator [C#]"
  - "<= operator [C#]"
  - "greater than or equal to operator [C#]"
  - ">= operator [C#]"
---
# Comparison operators (C# reference)

The [`<` (less than)](#less-than-operator-), [`>` (greater than)](#greater-than-operator-), [`<=` (less than or equal)](#less-than-or-equal-operator-), and [`>=` (greater than or equal)](#greater-than-or-equal-operator-) comparison, also known as relational, operators compare their operands. Those operators support all [integral](../builtin-types/integral-numeric-types.md) and [floating-point](../builtin-types/floating-point-numeric-types.md) numeric types.

> [!NOTE]
> For the `==`, `<`, `>`, `<=`, and `>=` operators, if any of the operands is not a number (<xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType>), the result of operation is `false`. That means that the `NaN` value is neither greater than, less than, nor equal to any other `double` (or `float`) value, including `NaN`. For more information and examples, see the <xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType> reference article.

Enumeration types also support comparison operators. For operands of the same [enum](../keywords/enum.md) type, the corresponding values of the underlying integral type are compared.

The [`==` and `!=` operators](equality-operators.md) check if their operands are equal or not.

## Less than operator \<

The `<` operator returns `true` if its left-hand operand is less than its right-hand operand, `false` otherwise:

[!code-csharp-interactive[less than example](~/samples/csharp/language-reference/operators/ComparisonOperators.cs#Less)]

## Greater than operator >

The `>` operator returns `true` if its left-hand operand is greater than its right-hand operand, `false` otherwise:

[!code-csharp-interactive[greater than example](~/samples/csharp/language-reference/operators/ComparisonOperators.cs#Greater)]

## Less than or equal operator \<=

The `<=` operator returns `true` if its left-hand operand is less than or equal to its right-hand operand, `false` otherwise:

[!code-csharp-interactive[less than or equal example](~/samples/csharp/language-reference/operators/ComparisonOperators.cs#LessOrEqual)]

## Greater than or equal operator >=

The `>=` operator returns `true` if its left-hand operand is greater than or equal to its right-hand operand, `false` otherwise:

[!code-csharp-interactive[greater than or equal example](~/samples/csharp/language-reference/operators/ComparisonOperators.cs#GreaterOrEqual)]

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `<`, `>`, `<=`, and `>=` operators.

If a type overloads one of the `<` or `>` operators, it must overload both `<` and `>`. If a type overloads one of the `<=` or `>=` operators, it must overload both `<=` and `>=`.

## C# language specification

For more information, see the [Relational and type-testing operators](~/_csharplang/spec/expressions.md#relational-and-type-testing-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- <xref:System.IComparable%601?displayProperty=nameWithType>
- [Equality operators](equality-operators.md)
