---
description: Learn about the built-in boolean type in C#
title: "bool type"
ms.date: 01/14/2026
f1_keywords: 
  - bool
  - bool_CSharpKeyword
  - "true"
  - "false"
  - true_CSharpKeyword
  - false_CSharpKeyword
helpviewer_keywords: 
  - "bool data type [C#]"
  - "Boolean [C#]"
---
# bool (C# reference)

The `bool` type keyword is an alias for the .NET <xref:System.Boolean?displayProperty=nameWithType> structure type that represents a Boolean value, which can be either `true` or `false`.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

To perform logical operations with values of the `bool` type, use [Boolean logical](../operators/boolean-logical-operators.md) operators. The `bool` type is the result type of [comparison](../operators/comparison-operators.md) and [equality](../operators/equality-operators.md) operators. A `bool` expression can be a controlling conditional expression in the [if](../statements/selection-statements.md#the-if-statement), [do](../statements/iteration-statements.md#the-do-statement), [while](../statements/iteration-statements.md#the-while-statement), and [for](../statements/iteration-statements.md#the-for-statement) statements and in the [conditional operator `?:`](../operators/conditional-operator.md).

The default value of the `bool` type is `false`.

## Literals

Use the `true` and `false` literals to initialize a `bool` variable or to pass a `bool` value:

:::code language="csharp" source="snippets/shared/BoolType.cs" id="Literals":::

## Three-valued Boolean logic

Use the nullable `bool?` type if you need to support three-valued logic. For example, use it when you work with databases that support a three-valued Boolean type. For the `bool?` operands, the predefined `&` and `|` operators support the three-valued logic. For more information, see the [Nullable Boolean logical operators](../operators/boolean-logical-operators.md#nullable-boolean-logical-operators) section of the [Boolean logical operators](../operators/boolean-logical-operators.md) article.

For more information about nullable value types, see [Nullable value types](nullable-value-types.md).

## Conversions

C# provides only two conversions that involve the `bool` type. Those conversions are an implicit conversion to the corresponding nullable `bool?` type and an explicit conversion from the `bool?` type. However, .NET provides additional methods that you can use to convert to or from the `bool` type. For more information, see the [Converting to and from Boolean values](/dotnet/api/system.boolean#converting-to-and-from-boolean-values) section of the <xref:System.Boolean?displayProperty=nameWithType> API reference page.

## C# language specification

For more information, see [The bool type](~/_csharpstandard/standard/types.md#839-the-bool-type) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Value types](value-types.md)
- [true and false operators](../operators/true-false-operators.md)
