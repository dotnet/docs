---
title: "switch expressions - C# reference"
description: Learn how to use the C# switch expression for pattern matching and other data introspection
ms.date: 03/19/2020
---
# switch expressions (C# reference)

This article covers the `switch` expression, introduced in C# 8.0. For information on the `switch` statement, see the article on the [`switch` statement](../statements/switch.md) in the [statements](../statements/index.md) section.

## Basic example

The `switch` expression provides for `switch`-like semantics in an expression context. This provides a concise syntax when the switch arms produce a value. The following example shows the structure of a switch expression. It translates values from an `enum` representing visual directions in an online map to the corresponding cardinal direction:

:::code language="csharp" source="snippets/SwitchExpressions.cs" id="SnippetBasicStructure" interactive="csharp-interactive":::

The preceding sample shows the basic elements of a switch expression:

- The *range expression*: The preceding example uses the variable `direction` as the range expression.
- The *switch expression arms*: Each switch expression arm contains a *pattern*, an optional *case guard* , the `=>` token, and an *expression*.

The result of the *switch expression* is the value of the expression of the first *switch expression arm* whose pattern matches the *range expression* and whose *cause guard*, if present, evaluates to `true`. The *expression* on the right of the `=>` token can't be an expression statement.

Each *switch expression arm* is evaluated in text order. The compiler issues an error if later switch expression arms can't be chosen because an earlier *switch expression arm* always matches first.

## Patterns and case guards

-- type pattern
-- value pattern
-- recursive patterns.

-- fluent switch expressions

-- special cases: null, _, var

## See also

- [C# reference](../index.md)
- [C# expressions and operators](index.md)
