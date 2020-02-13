---
title: "bool type - C# reference"
ms.date: 11/26/2019
f1_keywords: 
  - "bool"
  - "bool_CSharpKeyword"
helpviewer_keywords: 
  - "bool data type [C#]"
  - "Boolean [C#]"
ms.assetid: 551cfe35-2632-4343-af49-33ad12da08e2
---
# bool (C# reference)

The `bool` type keyword is an alias for the .NET <xref:System.Boolean?displayProperty=nameWithType> structure type that represents a Boolean value, which can be either `true` or `false`.

To perform logical operations with values of the `bool` type, use [Boolean logical](../operators/boolean-logical-operators.md) operators. The `bool` type is the result type of [comparison](../operators/comparison-operators.md) and [equality](../operators/equality-operators.md) operators. A `bool` expression can be a controlling conditional expression in the [if](../keywords/if-else.md), [do](../keywords/do.md), [while](../keywords/while.md), and [for](../keywords/for.md) statements and in the [conditional operator `?:`](../operators/conditional-operator.md).

The default value of the `bool` type is `false`.

## Literals

You can use the `true` and `false` literals to initialize a `bool` variable or to pass a `bool` value:

[!code-csharp-interactive[bool literals](~/samples/csharp/language-reference/builtin-types/BoolType.cs#Literals)]

## Three-valued Boolean logic

Use the nullable `bool?` type, if you need to support the three-valued logic, for example, when you work with databases that support a three-valued Boolean type. For the `bool?` operands, the predefined `&` and `|` operators support the three-valued logic. For more information, see the [Nullable Boolean logical operators](../operators/boolean-logical-operators.md#nullable-boolean-logical-operators) section of the [Boolean logical operators](../operators/boolean-logical-operators.md) article.

For more information about nullable value types, see [Nullable value types](nullable-value-types.md).

## Conversions

C# provides only two conversions that involve the `bool` type. Those are an implicit conversion to the corresponding nullable `bool?` type and an explicit conversion from the `bool?` type. However, .NET provides additional methods that you can use to convert to or from the `bool` type. For more information, see the [Converting to and from Boolean values](/dotnet/api/system.boolean#converting-to-and-from-boolean-values) section of the <xref:System.Boolean?displayProperty=nameWithType> API reference page.

## C# language specification

For more information, see [The bool type](~/_csharplang/spec/types.md#the-bool-type) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [Built-in types table](../keywords/built-in-types-table.md)
- [true and false operators](../operators/true-false-operators.md)
