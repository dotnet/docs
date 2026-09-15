---
title: "Pattern matching overview"
description: Learn how C# patterns test the type, value, and shape of data, and how to use patterns with is expressions, switch statements, and switch expressions.
ms.date: 09/14/2026
ms.topic: overview
ai-usage: ai-assisted
---

# Pattern matching overview

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. Experienced C# developers can use the [patterns reference](../../language-reference/operators/patterns.md) for the complete syntax and rules.
>
> **Coming from another language?** C# patterns serve a role similar to Java's pattern matching and Python's `match` cases. C# uses patterns in `is` expressions, `switch` statements, and `switch` expressions.

*Pattern matching* tests whether a value has a particular type, value, or shape. A *pattern* describes the condition to test. The value tested by a pattern is the *pattern input*. When a pattern matches, your code can use information learned by the test, such as a more specific type or a value extracted from an object.

You can use a pattern in three contexts:

- on the right side of the `is` operator,
- in a `case` label of a `switch` statement, or
- in an arm of a `switch` expression.

Nested patterns have their own inputs. For example, in `{ Days: <= 2 }`, the delivery object is the input to the property pattern, and the value of its `Days` property is the input to the nested relational pattern.

Patterns are often clearer than a sequence of casts, null checks, and comparisons because each branch describes the data it handles. For example, the following method uses a `switch` expression to choose a delivery message:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="SwitchExpressionOverview":::

The value before `switch` is the *input expression*. Each line inside the braces is a *switch arm*. The pattern appears before `=>`, and the result appears after it. C# selects the first arm, in text order, whose pattern matches and whose optional `when` guard is `true`:

- `null` is a *constant pattern*. It matches the `null` value.
- `ExpressDelivery express` is a *declaration pattern*. It tests the run-time type and, when the test succeeds, assigns the value to the new variable `express`.
- `StandardDelivery { Days: <= 2 }` combines a type test with a *property pattern* and a nested *relational pattern*.
- `_` is the *discard pattern*. It matches any value not handled by an earlier arm.

An unguarded arm affects which arms can follow it. When earlier unguarded patterns already match every value that a later pattern could match, the later pattern is *subsumed*, and the compiler reports an error. A guarded arm normally doesn't subsume a later arm because its guard might be `false`. A guard that's the constant `true` is treated as unguarded and can subsume later arms.

A switch expression is *exhaustive* when its arms handle every possible input. The compiler warns when it detects that a switch expression isn't exhaustive. The compiler analyzes many common pattern combinations, but it can't prove exhaustiveness for every possible arrangement of patterns. If no arm matches at run time, the switch expression throws <xref:System.Runtime.CompilerServices.SwitchExpressionException> on current .NET implementations. Add a final discard or `var` arm when you need a guaranteed catch-all.

Pattern matching can read properties, call `Deconstruct` methods, or access tuple-like data while matching nested patterns. Don't rely on the order of those operations or use property getters with matching-dependent side effects. The language doesn't specify their evaluation order.

## Test one condition with `is`

Use the `is` operator when you need one Boolean test. The following code tests a package's run-time type and creates a variable with that more specific type:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="IsPatternOverview":::

The variable `express` is definitely assigned only where the pattern matched. You don't need a separate cast, and the declaration pattern doesn't match `null`. If you only need the type test and don't need a new variable, use a [type pattern](type-patterns.md), such as `delivery is ExpressDelivery`.

Use `is null` and `is not null` for null checks. These patterns don't call a user-defined `==` or `!=` operator:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="NullPatterns":::

For more null-safety guidance, see [nullable reference types](../null-safety/nullable-reference-types.md).

## Choose between a statement and an expression

Patterns work with both forms of `switch`:

- Use a [`switch` statement](../statements/selection.md#match-a-value-with-a-switch-statement) when each match should run one or more statements.
- Use a `switch` expression when each match should produce a value.

The following switch expression replaces an `if` / `else if` chain that assigns one result:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="StatusMessage":::

A switch expression is concise because every arm has the same purpose: produce the value returned by the method. Keep an `if` statement when you're testing one Boolean condition, and keep a switch statement when branches perform several actions.

## Pattern categories

C# includes patterns for common kinds of data tests:

| Pattern category | What it tests |
| --- | --- |
| [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md) | A run-time type, a specific constant value, or any value that you want to capture |
| [Type patterns](type-patterns.md) | A run-time type without declaring a variable |
| Property and positional patterns | Properties, fields, or deconstructed values |
| Relational and logical patterns | Comparisons and combinations such as `and`, `or`, and `not` |
| List patterns | The values and shape of a list or array |
| [Discard patterns and discards](discards.md) | Any remaining value, or a value your code intentionally ignores |

The Fundamentals articles linked in the table provide focused coverage of the categories currently documented in this section. For complete syntax and examples for all pattern categories, see the [patterns reference](../../language-reference/operators/patterns.md).

## Related techniques

Patterns describe tests on data. You can combine them with other techniques without treating pattern matching as belonging to one programming style:

- [Selection statements](../statements/selection.md) use patterns to choose which statements run.
- [LINQ](../statements/linq.md) can filter or transform data before or after a pattern test.
- [Deconstruction](../functional/deconstruct.md) extracts values and also supports positional patterns.
- [Pattern matching tutorial](../tutorials/pattern-matching.md) combines several pattern forms in a complete scenario.

## See also

- [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md)
- [Type patterns](type-patterns.md)
- [Discards](discards.md)
- [Patterns reference](../../language-reference/operators/patterns.md)
- [`switch` expression reference](../../language-reference/operators/switch-expression.md)
