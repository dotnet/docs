---
title: "Nullable value types"
description: Learn about C# nullable value types and how to use them
ms.date: 01/14/2026
helpviewer_keywords: 
  - "nullable value types [C#]"
---
# Nullable value types (C# reference)

A *nullable value type* `T?` represents all values of its underlying [value type](value-types.md) `T` and an additional [null](../keywords/null.md) value. For example, you can assign any of the following three values to a `bool?` variable: `true`, `false`, or `null`. An underlying value type `T` can't be a nullable value type itself.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Any nullable value type is an instance of the generic <xref:System.Nullable%601?displayProperty=nameWithType> structure. You can refer to a nullable value type with an underlying type `T` in any of the following interchangeable forms: `Nullable<T>` or `T?`.

Typically, use a nullable value type when you need to represent the undefined value of an underlying value type. For example, a Boolean, or `bool`, variable can only be either `true` or `false`. However, in some applications a variable value can be undefined or missing. For example, a database field may contain `true` or `false`, or it might contain no value at all, that is, `NULL`. You can use the `bool?` type in that scenario.

## Declaration and assignment

Because a value type is implicitly convertible to the corresponding nullable value type, you can assign a value to a variable of a nullable value type as you do that for its underlying value type. You can also assign the `null` value. For example:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="Declaration":::

The default value of a nullable value type represents `null`. It's an instance whose <xref:System.Nullable%601.HasValue%2A?displayProperty=nameWithType> property returns `false`.

## Examination of an instance of a nullable value type

To check an instance of a nullable value type for `null` and get a value of an underlying type, use the [`is` operator with a type pattern](../operators/type-testing-and-cast.md#type-testing-with-pattern-matching):

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="PatternMatching":::

You can always use the following read-only properties to check and get a value of a nullable value type variable:

- <xref:System.Nullable%601.HasValue%2A?displayProperty=nameWithType> shows whether an instance of a nullable value type has a value of its underlying type.

- <xref:System.Nullable%601.Value%2A?displayProperty=nameWithType> gets the value of an underlying type if <xref:System.Nullable%601.HasValue%2A> is `true`. If <xref:System.Nullable%601.HasValue%2A> is `false`, the <xref:System.Nullable%601.Value%2A> property throws an <xref:System.InvalidOperationException>.

The following example uses the `HasValue` property to check whether the variable contains a value before displaying it:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="HasValue":::

You can also compare a variable of a nullable value type with `null` instead of using the `HasValue` property, as the following example shows:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="CompareWithNull":::

## Conversion from a nullable value type to an underlying type

If you want to assign a value of a nullable value type to a non-nullable value type variable, you might need to specify the value to assign in place of `null`. Use the [null-coalescing operator `??`](../operators/null-coalescing-operator.md) to do that. You can also use the <xref:System.Nullable%601.GetValueOrDefault(%600)?displayProperty=nameWithType> method for the same purpose:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="NullCoalescing":::

If you want to use the [default](default-values.md) value of the underlying value type in place of `null`, use the <xref:System.Nullable%601.GetValueOrDefault?displayProperty=nameWithType> method.

You can also explicitly cast a nullable value type to a non-nullable type, as the following example shows:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="Cast":::

At run time, if the value of a nullable value type is `null`, the explicit cast throws an <xref:System.InvalidOperationException>.

A non-nullable value type `T` is implicitly convertible to the corresponding nullable value type `T?`.

## Lifted operators

A nullable value type `T?` supports the predefined unary and binary [operators](../operators/index.md) or any overloaded operators that a value type `T` supports. These operators, also known as *lifted operators*, return `null` if one or both operands are `null`. Otherwise, the operator uses the contained values of its operands to calculate the result. For example:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="LiftedOperator":::

> [!NOTE]
> For the `bool?` type, the predefined `&` and `|` operators don't follow the rules described in this section: the result of an operator evaluation can be non-null even if one of the operands is `null`. For more information, see the [Nullable Boolean logical operators](../operators/boolean-logical-operators.md#nullable-boolean-logical-operators) section of the [Boolean logical operators](../operators/boolean-logical-operators.md) article.

For the [comparison operators](../operators/comparison-operators.md) `<`, `>`, `<=`, and `>=`, if one or both operands are `null`, the result is `false`. Otherwise, the contained values of operands are compared. Don't assume that because a particular comparison (for example, `<=`) returns `false`, the opposite comparison (`>`) returns `true`. The following example shows that 10 is

- neither greater than or equal to `null`
- nor less than `null`

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="ComparisonOperators":::

For the [equality operator](../operators/equality-operators.md#equality-operator-) `==`, if both operands are `null`, the result is `true`. If only one of the operands is `null`, the result is `false`. Otherwise, the contained values of operands are compared.

For the [inequality operator](../operators/equality-operators.md#inequality-operator-) `!=`, if both operands are `null`, the result is `false`. If only one of the operands is `null`, the result is `true`. Otherwise, the contained values of operands are compared.

If a [user-defined conversion](../operators/user-defined-conversion-operators.md) exists between two value types, the same conversion can also be used between the corresponding nullable value types.

## Boxing and unboxing

The following rules apply when you [box](../../programming-guide/types/boxing-and-unboxing.md) an instance of a nullable value type `T?`:

- If <xref:System.Nullable%601.HasValue%2A> returns `false`, the boxing operation returns the null reference.
- If <xref:System.Nullable%601.HasValue%2A> returns `true`, the boxing operation boxes the corresponding value of the underlying value type `T`, not the instance of <xref:System.Nullable%601>.

You can unbox a boxed value of a value type `T` to the corresponding nullable value type `T?`, as the following example shows:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="Boxing":::

## How to identify a nullable value type

The following example shows how to determine whether a <xref:System.Type?displayProperty=nameWithType> instance represents a constructed nullable value type, that is, the <xref:System.Nullable%601?displayProperty=nameWithType> type with a specified type parameter `T`:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="IsTypeNullable":::

As the example shows, you use the [typeof](../operators/type-testing-and-cast.md#the-typeof-operator) operator to create a <xref:System.Type?displayProperty=nameWithType> instance.

If you want to determine whether an instance is of a nullable value type, don't use the <xref:System.Object.GetType%2A?displayProperty=nameWithType> method to get a <xref:System.Type> instance to test by using the preceding code. When you call the <xref:System.Object.GetType%2A?displayProperty=nameWithType> method on an instance of a nullable value type, the instance is [boxed](#boxing-and-unboxing) to <xref:System.Object>. Because boxing a non-null instance of a nullable value type is equivalent to boxing a value of the underlying type, <xref:System.Object.GetType%2A> returns a <xref:System.Type> instance that represents the underlying type of a nullable value type:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="GetType":::

Also, don't use the [is](../operators/type-testing-and-cast.md#the-is-operator) operator to determine whether an instance is of a nullable value type. As the following example shows, you can't distinguish types of a nullable value type instance and its underlying type instance by using the `is` operator:

:::code language="csharp" source="snippets/shared/NullableValueTypes.cs" id="IsOperator":::

Instead, use the <xref:System.Nullable.GetUnderlyingType%2A?displayProperty=nameWithType> method from the first example and the [typeof](../operators/type-testing-and-cast.md#the-typeof-operator) operator to check if an instance is of a nullable value type.

> [!NOTE]
> The methods described in this section don't apply to [nullable reference types](nullable-reference-types.md).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Nullable types](~/_csharpstandard/standard/types.md#8312-nullable-value-types)
- [Lifted operators](~/_csharpstandard/standard/expressions.md#1248-lifted-operators)
- [Implicit nullable conversions](~/_csharpstandard/standard/conversions.md#1026-implicit-nullable-conversions)
- [Explicit nullable conversions](~/_csharpstandard/standard/conversions.md#1034-explicit-nullable-conversions)
- [Lifted conversion operators](~/_csharpstandard/standard/conversions.md#1062-lifted-conversions)

## See also

- [What exactly does 'lifted' mean?](/archive/blogs/ericlippert/what-exactly-does-lifted-mean)
- <xref:System.Nullable%601?displayProperty=nameWithType>
- <xref:System.Nullable?displayProperty=nameWithType>
- <xref:System.Nullable.GetUnderlyingType%2A?displayProperty=nameWithType>
- [Nullable reference types](nullable-reference-types.md)
