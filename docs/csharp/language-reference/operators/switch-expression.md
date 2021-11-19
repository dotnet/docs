---
title: "switch expression - C# reference"
description: Learn about the C# switch expression that provides switch-like semantics based on pattern matching.
ms.date: 04/16/2021
f1_keywords:
  - "switch_CSharpKeyword"
helpviewer_keywords:
  - "switch expression [C#]"
  - "pattern matching [C#]"
---
# switch expression (C# reference)

Beginning with C# 8.0, you use the `switch` expression to evaluate a single expression from a list of candidate expressions based on a pattern match with an input expression. For information about the `switch` statement that supports `switch`-like semantics in a statement context, see the [`switch` statement](../statements/selection-statements.md#the-switch-statement) section of the [Selection statements](../statements/selection-statements.md) article.

The following example demonstrates a `switch` expression, which converts values of an [`enum`](../builtin-types/enum.md) representing visual directions in an online map to the corresponding cardinal directions:

:::code language="csharp" source="snippets/shared/SwitchExpressions.cs" id="SnippetBasicStructure":::

The preceding example shows the basic elements of a `switch` expression:

- An expression followed by the `switch` keyword. In the preceding example, it's the `direction` method parameter.
- The *`switch` expression arms*, separated by commas. Each `switch` expression arm contains a *pattern*, an optional [*case guard*](#case-guards), the `=>` token, and an *expression*.

At the preceding example, a `switch` expression uses the following patterns:

- A [constant pattern](patterns.md#constant-pattern): to handle the defined values of the `Direction` enumeration.
- A [discard pattern](patterns.md#discard-pattern): to handle any integer value that doesn't have the corresponding member of the `Direction` enumeration (for example, `(Direction)10`). That makes the `switch` expression [exhaustive](#non-exhaustive-switch-expressions).

> [!IMPORTANT]
> For information about the patterns supported by the `switch` expression and more examples, see [Patterns](patterns.md).

The result of a `switch` expression is the value of the expression of the first `switch` expression arm whose pattern matches the input expression and whose case guard, if present, evaluates to `true`. The `switch` expression arms are evaluated in text order.

The compiler generates an error when a lower `switch` expression arm can't be chosen because a higher `switch` expression arm matches all its values.

## Case guards

A pattern may be not expressive enough to specify the condition for the evaluation of an arm's expression. In such a case, you can use a case guard. That is an additional condition that must be satisfied together with a matched pattern. A case guard must be a Boolean expression. You specify a case guard after the `when` keyword that follows a pattern, as the following example shows:

:::code language="csharp" source="snippets/shared/SwitchExpressions.cs" id="CaseGuardExample":::

The preceding example uses [property patterns](patterns.md#property-pattern) with nested [var patterns](patterns.md#var-pattern).

## Non-exhaustive switch expressions

If none of a `switch` expression's patterns matches an input value, the runtime throws an exception. In .NET Core 3.0 and later versions, the exception is a <xref:System.Runtime.CompilerServices.SwitchExpressionException?displayProperty=nameWithType>. In .NET Framework, the exception is an <xref:System.InvalidOperationException>. The compiler generates a warning if a `switch` expression doesn't handle all possible input values.

> [!TIP]
> To guarantee that a `switch` expression handles all possible input values, provide a `switch` expression arm with a [discard pattern](patterns.md#discard-pattern).

## C# language specification

For more information, see the [`switch` expression](~/_csharplang/proposals/csharp-8.0/patterns.md#switch-expression) section of the [feature proposal note](~/_csharplang/proposals/csharp-8.0/patterns.md).

## See also

- [C# reference](../index.md)
- [C# operators and expressions](index.md)
- [Patterns](patterns.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](../../fundamentals/tutorials/pattern-matching.md)
- [`switch` statement](../statements/selection-statements.md#the-switch-statement)
