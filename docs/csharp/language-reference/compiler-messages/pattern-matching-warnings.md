---
title: Resolve pattern matching errors and warnings
description: There are several pattern matching warnings. Learn how to address these warnings.
f1_keywords:
  - "CS8509" # WRN_SwitchNotAllPossibleValues: The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.
  - "CS9134"
  - "CS9135"
  - "CS9335"
  - "CS9336"
  - "CS9337"
helpviewer_keywords:
  - "CS8509"
  - "CS9134"
  - "CS9335"
  - "CS9336"
  - "CS9337"
ms.date: 11/07/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings in pattern matching expressions

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8509**](#incomplete-pattern-matching): *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*
- [**CS9134**](#switch-expression-syntax-errors): *A switch expression arm does not begin with a 'case' keyword.*
- [**CS9135**](#switch-expression-syntax-errors): *A constant value of type is expected*
- [**CS9335, CS9336**](#redundant-patterns): *The pattern is redundant.*
- [**CS9337**](#redundant-patterns): *The pattern is too complex to analyze for redundancy.*

## Switch expression syntax errors

- **CS9134**: *A switch expression arm does not begin with a 'case' keyword.*
- **CS9135**: *A constant value of type is expected*

To write switch expressions correctly, follow the proper syntax rules. For more information, see [Switch expression](../operators/switch-expression.md).

- Don't use the `case` keyword in switch expressions (**CS9134**). The `case` keyword is used in switch statements, not switch expressions. In a switch expression, each arm consists of a pattern, an optional case guard, the `=>` token, and an expression.
- Use constant values in patterns, not variables (**CS9135**). Pattern matching requires compile-time constants for value patterns.

The following example demonstrates the syntax error with `case`:

```csharp
var answer = x switch
{
    // CS9134: remove the keyword "case" from each switch arm:
    case 0 => false,
    case 1 => true,
}
```

To fix this error, remove the `case` keyword:

```csharp
var answer = x switch
{
    0 => false,
    1 => true,
}
```

## Incomplete pattern matching

- **CS8509**: *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*

To create exhaustive switch expressions, cover all possible input values. For more information, see [Switch expression](../operators/switch-expression.md) and [Switch statement](../statements/selection-statements.md#the-switch-statement).

Add switch arms that handle all possible input values. Use the discard pattern (`_`) to match any remaining values that you don't need to handle explicitly.

The following example generates CS8509:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="SwitchNotAllPossibleValues":::

To fix this warning, add a default arm:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="SwitchAllPossibleValues":::

The `_` pattern matches all remaining values. You can use this pattern to handle invalid or unexpected values.

## Redundant patterns

- **CS9335, CS9336**: *The pattern is redundant.*
- **CS9337**: *The pattern is too complex to analyze for redundancy.*

To write clear pattern matching expressions, avoid redundant patterns. For more information, see [Patterns](../operators/patterns.md).

- Review patterns that the compiler identifies as redundant (**CS9335**, **CS9336**). Redundant patterns can indicate a logic error where you meant to use `not` or different logical operators.
- Simplify complex patterns that are too difficult for the compiler to analyze (**CS9337**). Break down complex patterns into simpler, more maintainable expressions.

The following example demonstrates a redundant pattern:

:::code language="csharp" source="./snippets/pattern-matching-warnings/Switch.cs" id="RedundantPattern":::

This warning indicates you likely meant `is not (null or 42)` or `is not (int or string)` instead of using `or` at the top level.
