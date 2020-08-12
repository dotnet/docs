---
title: "switch expression - C# reference"
description: Learn how to use the C# switch expression for pattern matching and other data introspection
ms.date: 03/19/2020
---
# switch expression (C# reference)

This article covers the `switch` expression, introduced in C# 8.0. For information on the `switch` statement, see the article on the [`switch` statement](../keywords/switch.md) in the [statements](../keywords/index.md) section.

## Basic example

The `switch` expression provides for `switch`-like semantics in an expression context. It provides a concise syntax when the switch arms produce a value. The following example shows the structure of a switch expression. It translates values from an `enum` representing visual directions in an online map to the corresponding cardinal direction:

:::code language="csharp" source="snippets/shared/SwitchExpressions.cs" id="SnippetBasicStructure":::

The preceding sample shows the basic elements of a switch expression:

- The *range expression*: The preceding example uses the variable `direction` as the range expression.
- The *switch expression arms*: Each switch expression arm contains a *pattern*, an optional *case guard*, the `=>` token, and an *expression*.

The result of the *switch expression* is the value of the expression of the first *switch expression arm* whose *pattern* matches the *range expression* and whose *case guard*, if present, evaluates to `true`. The *expression* on the right of the `=>` token can't be an expression statement.

The *switch expression arms* are evaluated in text order. The compiler issues an error when a lower *switch expression arm* can't be chosen because a higher *switch expression arm* matches all its values.

## Patterns and case guards

Many patterns are supported in switch expression arms. The preceding example uses a *constant pattern*. A *constant pattern* compares the range expression to a value. That value must be a compile-time constant. The *type pattern* compares the range expression to a known type. The following example retrieves the third element from a sequence. It uses different methods based on the type of the sequence:

:::code language="csharp" source="snippets/shared/SwitchExpressions.cs" id="SnippetTypePattern":::

Patterns can be recursive, where a pattern tests a type, and if that type matches, the pattern matches one or more property values on the range expression. You can use recursive patterns to extend the preceding example. You add switch expression arms for arrays that have fewer than 3 elements. Recursive patterns are shown in the following example:

:::code language="csharp" source="snippets/shared/SwitchExpressions.cs" id="SnippetRecursivePattern":::

Recursive patterns can examine properties of the range expression, but can't execute arbitrary code. You can use a *case guard*, specified in a `when` clause, to provide similar checks for other sequence types:

:::code language="csharp" source="snippets/shared/SwitchExpressions.cs" id="SnippetGuardCase":::

Finally, you can add the `_` pattern and the `null` pattern to catch arguments that aren't processed by any other switch expression arm. That makes the switch expression *exhaustive*, meaning any possible value of the range expression is handled. The following example adds those expression arms:

:::code language="csharp" source="snippets/shared/SwitchExpressions.cs" id="SnippetExhaustive":::

The preceding example adds a `null` pattern, and changes the `IEnumerable<T>` type pattern to a `_` pattern. The `null` pattern provides a null check as a switch expression arm. The expression for that arm throws an <xref:System.ArgumentNullException>. The `_` pattern matches all inputs that haven't been matched by previous arms. It must come after the `null` check, or it would match `null` inputs.

You can read more in the C# language spec proposal for [recursive patterns](~/_csharplang/proposals/csharp-8.0/patterns.md#switch-expression).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Pattern matching](../../pattern-matching.md)
