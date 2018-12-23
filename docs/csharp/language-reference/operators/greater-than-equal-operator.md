---
title: "&gt;= Operator - C# Reference"
ms.custom: seodec18
ms.date: 12/18/2018
f1_keywords: 
  - ">=_CSharpKeyword"
helpviewer_keywords: 
  - "greater than or equal to operator (>=) [C#]"
  - ">= operator [C#]"
ms.assetid: 0db4dcaf-56a3-4884-a7ad-35f64978a58d
---
# &gt;= Operator (C# Reference)

The "greater than or equal" relational operator `>=` returns `true` if its first operand is greater than or equal to its second operand, `false` otherwise. All numeric and  enumeration types support the `>=` operator. For operands of the same [enum](../keywords/enum.md) type, the corresponding values of the underlying integral type are compared.

> [!NOTE]
> For relational operators `==`, `>`, `<`, `>=`, and `<=`, if any of the operands is not a number (<xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType>) the result of operation is `false`. That means that the `NaN` value is neither greater than, less than, nor equal to any other `double` (or `float`) value. For more information and examples, see the <xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType> reference article.

The following example demonstrates the usage of the `>=` operator:

[!code-csharp-interactive[greater than or equal example](~/samples/snippets/csharp/language-reference/operators/GreaterAndLessOperatorsExamples.cs#GreaterOrEqual)]

## Operator overloadability

User-defined types can [overload](../keywords/operator.md) the `>=` operator. If a type overloads the "greater than or equal" operator `>=`, it must also overload the ["less than or equal" operator](less-than-equal-operator.md) `<=`.

## C# language specification

For more information, see the [Relational and type-testing operators](~/_csharplang/spec/expressions.md#relational-and-type-testing-operators) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [> Operator](greater-than-operator.md)
- [== Operator](equality-comparison-operator.md)
- <xref:System.IComparable%601?displayProperty=nameWithType>
