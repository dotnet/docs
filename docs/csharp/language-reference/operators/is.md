---
title: "The `is` operator - Match an expression against a type or constant pattern"
description: "Learn about the C# `is` operator that matches an expression against a pattern. The `is` operator returns true when the expression matches the pattern."
ms.date: 02/18/2025
f1_keywords: 
  - "is_CSharpKeyword"
  - "is"
helpviewer_keywords: 
  - "is keyword [C#]"
---
# The `is` operator (C# reference)

The `is` operator checks if the result of an expression is compatible with a given type. For information about the type-testing `is` operator, see the [is operator](type-testing-and-cast.md#is-operator) section of the [Type-testing and cast operators](type-testing-and-cast.md) article. You can also use the `is` operator to match an expression against a pattern, as the following example shows:

:::code language="csharp" source="snippets/shared/IsOperator.cs" id="IntroExample":::

In the preceding example, the `is` operator matches an expression against a [property pattern](patterns.md#property-pattern) with nested [constant](patterns.md#constant-pattern) and [relational](patterns.md#relational-patterns) patterns.

The `is` operator can be useful in the following scenarios:

- To check the run-time type of an expression, as the following example shows:

  :::code language="csharp" source="snippets/shared/IsOperator.cs" id="DeclarationPattern":::

  The preceding example shows the use of a [declaration pattern](patterns.md#declaration-and-type-patterns).

- To check for `null`, as the following example shows:

  :::code language="csharp" source="snippets/shared/IsOperator.cs" id="NullCheck":::

  When you match an expression against `null`, the compiler guarantees that no user-overloaded `==` or `!=` operator is invoked.

- You can use a [negation pattern](patterns.md#logical-patterns) to do a non-null check, as the following example shows:

  :::code language="csharp" source="snippets/shared/IsOperator.cs" id="NonNullCheck":::

- Beginning with C# 11, you can use [list patterns](patterns.md#list-patterns) to match elements of a list or array. The following code checks arrays for integer values in expected positions:

  :::code language="csharp" source="snippets/shared/IsOperator.cs" id="ListPatterns":::

> [!NOTE]
> For the complete list of patterns supported by the `is` operator, see [Patterns](patterns.md).

## C# language specification

For more information, see [The is operator](~/_csharpstandard/standard/expressions.md#121212-the-is-operator) section of the [C# language specification](~/_csharpstandard/standard/README.md) and [Pattern matching](/dotnet/csharp/language-reference/language-specification/patterns).

## See also

- [C# operators and expressions](index.md)
- [Patterns](patterns.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../fundamentals/tutorials/pattern-matching.md)
- [Type-testing and cast operators](../operators/type-testing-and-cast.md)
