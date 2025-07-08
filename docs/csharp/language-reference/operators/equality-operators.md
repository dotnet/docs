---
title: "Equality operators - test if two objects are equal or not equal"
description: "C# equality operators test if two objects are equal or not equal. You can define equality operators for your types for custom comparisons for equality"
ms.date: 02/18/2025
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
# Equality operators - test if two objects are equal or not

The [`==` (equality)](#equality-operator-) and [`!=` (inequality)](#inequality-operator-) operators check if their operands are equal or not. Value types are equal when their contents are equal. Reference types are equal when the two variables refer to the same storage.

You can use the [`is`](./is.md) pattern matching operator as an alternative to an `==` test when you test against a [constant value](./patterns.md#constant-pattern). The `is` operator uses the default equality semantics for all value and reference types.

## Equality operator ==

The equality operator `==` returns `true` if its operands are equal, `false` otherwise.

### Value types equality

Operands of the [built-in value types](../builtin-types/value-types.md#built-in-value-types) are equal if their values are equal:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/EqualityOperators.cs" id="ValueTypesEquality":::

> [!NOTE]
> For the `==`, [`<`, `>`, `<=`, and `>=`](comparison-operators.md) operators, if any of the operands isn't a number (<xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType>), the result of operation is `false`. That means that the `NaN` value isn't greater than, less than, or equal to any other `double` (or `float`) value, including `NaN`. For more information and examples, see the <xref:System.Double.NaN?displayProperty=nameWithType> or <xref:System.Single.NaN?displayProperty=nameWithType> reference article.

Two operands of the same [enum](../builtin-types/enum.md) type are equal if the corresponding values of the underlying integral type are equal.

User-defined [struct](../builtin-types/struct.md) types don't support the `==` operator by default. To support the `==` operator, a user-defined struct must [overload](operator-overloading.md) it.

C# [tuples](../builtin-types/value-tuples.md) have built-in support for the `==` and `!=` operators. For more information, see the [Tuple equality](../builtin-types/value-tuples.md#tuple-equality) section of the [Tuple types](../builtin-types/value-tuples.md) article.

### Reference types equality

By default, reference-type operands, excluding records, are equal if they refer to the same object:

:::code language="csharp" source="snippets/shared/EqualityOperators.cs" id="ReferenceTypesEquality":::

As the example shows, user-defined reference types support the `==` operator by default. However, a reference type can overload the `==` operator. If a reference type overloads the `==` operator, use the <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType> method to check if two references of that type refer to the same object.

### Record types equality

[Record types](../builtin-types/record.md) support the `==` and `!=` operators that by default provide value equality semantics. That is, two record operands are equal when both of them are `null` or corresponding values of all fields and automatically implemented properties are equal.

:::code language="csharp" source="snippets/shared/EqualityOperators.cs" id="RecordTypesEquality":::

As the preceding example shows, for reference-type members their reference values are compared, not the referenced instances.

### String equality

Two [string](../builtin-types/reference-types.md#the-string-type) operands are equal when both of them are `null` or both string instances are of the same length and have identical characters in each character position:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/EqualityOperators.cs" id="StringEquality":::

String equality comparisons are case-sensitive ordinal comparisons. For more information about string comparison, see [How to compare strings in C#](../../how-to/compare-strings.md).

### Delegate equality

Two [delegate](../../programming-guide/delegates/index.md) operands of the same run-time type are equal when both of them are `null` or their invocation lists are of the same length and have equal entries in each position:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/EqualityOperators.cs" id="DelegateEquality":::

> [!IMPORTANT]
> Equal entries in an invocation list include all fixed parameters in the invocation, including the receiver. The receiver is the instance of an object represented by `this` when the entry is invoked.

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/EqualityOperators.cs" id="SnippetCheckReceiver":::

For more information, see the [Delegate equality operators](~/_csharpstandard/standard/expressions.md#12129-delegate-equality-operators) section of the [C# language specification](~/_csharpstandard/standard/README.md).

Delegates that are produced from evaluation of semantically identical [lambda expressions](lambda-expressions.md) aren't equal, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/EqualityOperators.cs" id="IdenticalLambdas":::

## Inequality operator `!=`

The inequality operator `!=` returns `true` if its operands aren't equal, `false` otherwise. For the operands of the [built-in types](../builtin-types/built-in-types.md), the expression `x != y` produces the same result as the expression `!(x == y)`. For more information about type equality, see the [Equality operator](#equality-operator-) section.

The following example demonstrates the usage of the `!=` operator:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/shared/EqualityOperators.cs" id="NonEquality":::

## Operator overloadability

A user-defined type can [overload](operator-overloading.md) the `==` and `!=` operators. If a type overloads one of the two operators, it must also overload the other one.

A record type can't explicitly overload the `==` and `!=` operators. If you need to change the behavior of the `==` and `!=` operators for record type `T`, implement the <xref:System.IEquatable%601.Equals%2A?displayProperty=nameWithType> method with the following signature:

```csharp
public virtual bool Equals(T? other);
```

## C# language specification

For more information, see the [Relational and type-testing operators](~/_csharpstandard/standard/expressions.md#1212-relational-and-type-testing-operators) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For more information about equality of record types, see the [Equality members](~/_csharplang/proposals/csharp-9.0/records.md#equality-members) section of the [records feature proposal note](~/_csharplang/proposals/csharp-9.0/records.md).

## See also

- [C# operators and expressions](index.md)
- <xref:System.IEquatable%601?displayProperty=nameWithType>
- <xref:System.Object.Equals%2A?displayProperty=nameWithType>
- <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType>
- [Equality comparisons](../../programming-guide/statements-expressions-operators/equality-comparisons.md)
- [Comparison operators](comparison-operators.md)
