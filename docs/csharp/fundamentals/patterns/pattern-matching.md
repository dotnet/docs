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

*Pattern matching* applies a pattern to an expression. A *pattern* is a condition to test the input expression against. The *pattern input* is that expression. C# evaluates the input expression; the result is the *evaluated value*. The pattern tests whether that value has a particular type, equals a particular value, or has a particular shape. When a pattern matches, your code can use information learned by the test, such as a more specific type or a value extracted from an object.

You can use a pattern in three contexts:

- on the right side of the `is` operator,
- in a `case` label of a `switch` statement, or
- in an arm of a `switch` expression.

Patterns are often clearer than a sequence of comparison statements because each branch describes the data it handles. For example, the following method uses a `switch` expression to choose a delivery message:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="SwitchExpressionOverview":::

Recursive patterns have their own input expressions. In `StandardDelivery { Days: <= 2 }`, the outer pattern receives the `delivery` expression. The recursive `<= 2` pattern receives the `Days` property expression from the matched `StandardDelivery` object.

The expression before `switch` is the input expression. Each line inside the braces is a *switch arm*. The pattern appears before `=>`, and the result appears after it. C# evaluates the input expression, then selects the first arm, in text order, whose pattern matches and whose optional `when` guard is `true`. The optional `when` guard is an additional Boolean condition written after the pattern. The preceding example showed the following patterns:

- `null` is a *constant pattern*. It tests whether the `delivery` expression evaluates to `null`.
- `ExpressDelivery express` is a *declaration pattern* with two parts. `ExpressDelivery` is the type-test part. It tests whether the evaluated value is a non-null object whose run-time type is compatible with `ExpressDelivery`. `express` is the *variable designation*: it declares a variable named `express` and assigns the matched `ExpressDelivery` object to it.
- `StandardDelivery { Days: <= 2 }` begins with a type test. `StandardDelivery` tests whether the evaluated value is a non-null object of that type. The braces contain a *property pattern*. `Days` names the property to inspect, so the `Days` property expression becomes the input to the recursive pattern. The `<= 2` portion is a *relational pattern*, which tests whether the evaluated value is less than or equal to `2`.
- `_` (underscore) is the *discard pattern*. It matches every evaluated value, including `null`. Because earlier arms already handle `null`, express deliveries, and standard deliveries arriving within two days, this final arm handles every remaining value.

An arm without a `when` guard is *unguarded*. All arms in the first example are unguarded. If an earlier unguarded arm matches every evaluated value that a later arm could match, the later arm is *subsumed*. A *subsumed* pattern is one where every possible input value that matches was already matched by an earlier switch arm. It can never match, so the compiler reports an error. The discard arm (`_`) must come last because it matches every input expression. A guarded arm doesn't subsume a later arm based on its pattern alone because the guard might be `false`.

A switch expression is *exhaustive* when its arms handle every possible input expression. The first example is exhaustive because its final discard arm handles anything the earlier arms don't match. The compiler warns when it detects a potential input value that no arm handles. The compiler can't prove exhaustiveness for every combination of patterns, but this diagnostic helps you write correct pattern matching code. For detailed matching, subsumption, and exhaustiveness rules, see the [patterns reference](../../language-reference/operators/patterns.md).

## Test one condition with `is`

Use the `is` operator when you need one Boolean test. The following code evaluates the `delivery` expression and applies the declaration pattern `ExpressDelivery express`. The type portion matches when the evaluated value is non-null and its run-time type is compatible with `ExpressDelivery`. When the pattern matches, its variable designation declares `express`:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="IsPatternOverview":::

The compiler tracks whether a local variable has been assigned before your code reads it. This tracking is called *definite assignment*. Inside the `if` block, the condition can be `true` only when the pattern assigned the matching object to `express`. The compiler therefore knows that `express` is definitely assigned there. Your code can safely use its `TrackingCode` property. You don't need a separate cast. If you only need the type test and don't need to declare a variable, use a [type pattern](type-patterns.md), such as `delivery is ExpressDelivery`.

Use `is null` and `is not null` for null checks. These patterns don't call a user-defined `==` or `!=` operator:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="NullPatterns":::

For more null-safety guidance, see [nullable reference types](../null-safety/nullable-reference-types.md).

## Choose between a statement and an expression

Patterns work with both forms of `switch`:

- Use a [`switch` statement](../statements/selection.md#match-a-value-with-a-switch-statement) when each match should run one or more statements.
- Use a `switch` expression when each match should produce a value.

The following switch statement reports a delivery update. The express-delivery branch writes two messages, so a statement fits naturally:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="SwitchStatement":::

Each `case` applies a pattern to the `delivery` expression. The matching section can run any number of statements before `break` exits the switch. The `default` section handles anything that the earlier cases don't match.

The following switch expression replaces an `if` / `else if` chain that assigns one result:

:::code language="csharp" source="snippets/patterns/Overview.cs" ID="StatusMessage":::

A switch expression is concise because every arm has the same purpose: produce the value returned. Use a switch statement when branches perform actions, and use a switch expression when branches calculate one result.

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

## See also

- [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md)
- [Type patterns](type-patterns.md)
- [Discards](discards.md).
- [Patterns reference](../../language-reference/operators/patterns.md).
- [`switch` expression reference](../../language-reference/operators/switch-expression.md).
