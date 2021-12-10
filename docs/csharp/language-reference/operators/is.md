---
title: "is operator - C# reference"
description: "Learn about the C# is operator that matches an expression against a pattern."
ms.date: 04/23/2021
f1_keywords: 
  - "is_CSharpKeyword"
  - "is"
helpviewer_keywords: 
  - "is keyword [C#]"
ms.assetid: bc62316a-d41f-4f90-8300-c6f4f0556e43
---
# is operator (C# reference)

The `is` operator checks if the result of an expression is compatible with a given type. For information about the type-testing `is` operator, see the [is operator](type-testing-and-cast.md#is-operator) section of the [Type-testing and cast operators](type-testing-and-cast.md) article.

Beginning with C# 7.0, you can also use the `is` operator to match an expression against a pattern, as the following example shows:

:::code language="csharp" source="snippets/shared/IsOperator.cs" id="IntroExample":::

In the preceding example, the `is` operator matches an expression against a [property pattern](patterns.md#property-pattern) (available in C# 8.0 and later) with nested [constant](patterns.md#constant-pattern) and [relational](patterns.md#relational-patterns) (available in C# 9.0 and later) patterns.

The `is` operator can be useful in the following scenarios:

- To check the run-time type of an expression, as the following example shows:

  :::code language="csharp" source="snippets/shared/IsOperator.cs" id="DeclarationPattern":::

  The preceding example shows the use of a [declaration pattern](patterns.md#declaration-and-type-patterns).

- To check for `null`, as the following example shows:

  :::code language="csharp" source="snippets/shared/IsOperator.cs" id="NullCheck":::

  When you match an expression against `null`, the compiler guarantees that no user-overloaded `==` or `!=` operator is invoked.

- Beginning with C# 9.0, you can use a [negation pattern](patterns.md#logical-patterns) to do a non-null check, as the following example shows:

  :::code language="csharp" source="snippets/shared/IsOperator.cs" id="NonNullCheck":::

> [!NOTE]
> For the complete list of patterns supported by the `is` operator, see [Patterns](patterns.md).

## C# language specification

For more information, see [The is operator](~/_csharplang/spec/expressions.md#the-is-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md) and the following C# language proposals:

- [Pattern matching](~/_csharplang/proposals/csharp-7.0/pattern-matching.md)
- [Pattern matching with generics](~/_csharplang/proposals/csharp-7.1/generics-pattern-match.md)

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Patterns](patterns.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../fundamentals/tutorials/pattern-matching.md)
- [Type-testing and cast operators](../operators/type-testing-and-cast.md)
