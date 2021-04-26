---
title: "Equality operators - C# reference"
description: "Learn about C# equality comparison operators and C# type equality."
ms.date: 10/30/2020
author: pkulikov
f1_keywords: 
  - "==_CSharpKeyword"
  - "!=_CSharpKeyword"
helpviewer_keywords: 
  - "comparison operators [C#]"
  - "relational operators [C#]"
  - "equality operator [C#]"
  - "equals operator [C#]"
  - "== operator [C#]"
  - "inequality operator [C#]"
  - "not equals operator [C#]"
  - "!= operator [C#]"
---
# Equality operators (C# reference)

The [`==` (equality)](#equality-operator-) and [`!=` (inequality)](#inequality-operator-) operators check if their operands are equal or not.

## Equality operator ==

The equality operator `==` returns `true` if its operands are equal, `false` otherwise.

### Value types equality

Operands of the [built-in value types](../builtin-types/value-types.md#built-in-value-types) are equal if their values are equal:

[!code-csharp-interactive[value types equality](snippets/shared/EqualityOperators.cs#ValueTypesEquality)]

> [!NOTE]
> For the `==`, [`<`, `>`, `<=`, and `>=`](comparison-operators.md) operators, if any of the operands is not a number (<xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType>), the result of operation is `false`. That means that the `NaN` value is neither greater than, less than, nor equal to any other `double` (or `float`) value, including `NaN`. For more information and examples, see the <xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType> reference article.

Two operands of the same [enum](../builtin-types/enum.md) type are equal if the corresponding values of the underlying integral type are equal.

User-defined [struct](../builtin-types/struct.md) types don't support the `==` operator by default. To support the `==` operator, a user-defined struct must [overload](operator-overloading.md) it.

Beginning with C# 7.3, the `==` and `!=` operators are supported by C# [tuples](../builtin-types/value-tuples.md). For more information, see the [Tuple equality](../builtin-types/value-tuples.md#tuple-equality) section of the [Tuple types](../builtin-types/value-tuples.md) article.

### Reference types equality

By default, two non-record reference-type operands are equal if they refer to the same object:

[!code-csharp[reference type equality](snippets/shared/EqualityOperators.cs#ReferenceTypesEquality)]

As the example shows, user-defined reference types support the `==` operator by default. However, a reference type can overload the `==` operator. If a reference type overloads the `==` operator, use the <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType> method to check if two references of that type refer to the same object.

### Record types equality

Available in C# 9.0 and later, [record types](../builtin-types/record.md) support the `==` and `!=` operators that by default provide value equality semantics. That is, two record operands are equal when both of them are `null` or corresponding values of all fields and auto-implemented properties are equal.

:::code language="csharp" source="snippets/shared/EqualityOperators.cs" id="RecordTypesEquality":::

As the preceding example shows, in case of non-record reference-type members their reference values are compared, not the referenced instances.

### String equality

Two [string](../builtin-types/reference-types.md#the-string-type) operands are equal when both of them are `null` or both string instances are of the same length and have identical characters in each character position:

[!code-csharp-interactive[string equality](snippets/shared/EqualityOperators.cs#StringEquality)]

That is a case-sensitive ordinal comparison. For more information about string comparison, see [How to compare strings in C#](../../how-to/compare-strings.md).

### Delegate equality

Two [delegate](../../programming-guide/delegates/index.md) operands of the same run-time type are equal when both of them are `null` or their invocation lists are of the same length and have equal entries in each position:

[!code-csharp-interactive[delegate equality](snippets/shared/EqualityOperators.cs#DelegateEquality)]

For more information, see the [Delegate equality operators](~/_csharplang/spec/expressions.md#delegate-equality-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

Delegates that are produced from evaluation of semantically identical [lambda expressions](lambda-expressions.md) are not equal, as the following example shows:

[!code-csharp-interactive[from identical lambdas](snippets/shared/EqualityOperators.cs#IdenticalLambdas)]

## Inequality operator !=

The inequality operator `!=` returns `true` if its operands are not equal, `false` otherwise. For the operands of the [built-in types](../builtin-types/built-in-types.md), the expression `x != y` produces the same result as the expression `!(x == y)`. For more information about type equality, see the [Equality operator](#equality-operator-) section.

The following example demonstrates the usage of the `!=` operator:

[!code-csharp-interactive[non-equality examples](snippets/shared/EqualityOperators.cs#NonEquality)]

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `==` and `!=` operators. If a type overloads one of the two operators, it must also overload the other one.

A record type cannot explicitly overload the `==` and `!=` operators. If you need to change the behavior of the `==` and `!=` operators for record type `T`, implement the <xref:System.IEquatable%601.Equals%2A?displayProperty=nameWithType> method with the following signature:

```csharp
public virtual bool Equals(T? other);
```

## C# language specification

For more information, see the [Relational and type-testing operators](~/_csharplang/spec/expressions.md#relational-and-type-testing-operators) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about equality of record types, see the [Equality members](~/_csharplang/proposals/csharp-9.0/records.md#equality-members) section of the [records feature proposal note](~/_csharplang/proposals/csharp-9.0/records.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- <xref:System.IEquatable%601?displayProperty=nameWithType>
- <xref:System.Object.Equals%2A?displayProperty=nameWithType>
- <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType>
- [Equality comparisons](../../programming-guide/statements-expressions-operators/equality-comparisons.md)
- [Comparison operators](comparison-operators.md)
