---
title: "Relational, logical, and parenthesized patterns"
description: Learn how C# relational patterns compare values and how logical and parenthesized patterns combine pattern tests.
ms.date: 09/17/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Relational, logical, and parenthesized patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. For complete language rules, see [relational patterns](../../language-reference/operators/patterns.md#relational-patterns) and [logical patterns](../../language-reference/operators/patterns.md#logical-patterns) in the language reference.

A *relational pattern* compares an evaluated value with a constant by using `<`, `>`, `<=`, or `>=`. *Logical patterns* combine or negate patterns with the pattern operators `and`, `or`, and `not`. A *parenthesized pattern* uses parentheses to make the intended grouping explicit or to change the default grouping.

## Distinguish expressions from patterns

The same relational symbol can appear in an ordinary expression or in a pattern. The following example uses both forms with a temperature:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="ExpressionAndPattern":::

`temperature < 0` is a *relational expression*. It has a left operand and a right operand, and produces a `bool`.

In `temperature is < 0`, `temperature` is the pattern input expression. C# evaluates it, and the relational pattern `< 0` tests the resulting value. In the switch arm `< 0 => "Freezing"`, the expression before `switch` supplies the input, so the pattern contains only `< 0`.

The example displays both Boolean results to show that the two tests classify the same temperature. The switch expression maps the value to a description.

Choose a relational expression for one direct comparison. Choose relational patterns when the comparison is part of a larger pattern or when several ranges map cleanly to switch results.

## Describe ranges with `and`

The following pattern tests whether a temperature is in the inclusive range from 18 through 24:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="AndPattern":::

The input expression is `temperature`. The logical pattern `>= 18 and <= 24` combines two relational patterns that both test the same evaluated value. The `and` pattern matches only when both nested patterns match.

`and` is a pattern operator here, not the conditional-AND Boolean operator `&&`. Pattern matching describes what must match. Don't rely on nested patterns being tested left to right or short-circuiting like Boolean operands.

## Describe alternatives with `or` and exclusions with `not`

The following methods test a day of the week and a simple status value:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="OrNotPatterns":::

`DayOfWeek.Saturday or DayOfWeek.Sunday` is one logical pattern composed of two constant patterns. It matches when either nested pattern matches. `IsActive` uses the `not` pattern to exclude `Status.Complete`.

`not` is a pattern operator, not the Boolean negation operator `!`. Choose `or` when several pattern alternatives have the same result. Choose `not` when expressing the excluded pattern is clearer than listing every accepted value.

## Group patterns with parentheses

Pattern operators bind in this order:

1. `not`
1. `and`
1. `or`

The following test accepts priorities 1 through 3 or the special priority 9:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="ParenthesizedPattern":::

The parentheses aren't required for the compiler because `and` binds before `or`, but they make the two alternatives visible: the range from 1 through 3, or 9. Use parentheses whenever a reader might hesitate over the grouping. Parentheses can also change the default grouping, such as `not (>= 1 and <= 3)`.

## Use a `when` guard for a separate condition

Logical patterns work best when nested patterns describe the input value itself. A `when` guard is an additional Boolean condition on a `case` label or switch arm. Use a guard when the decision also depends on information that isn't naturally part of the pattern.

The following warning depends on the temperature and a separate `isOutdoors` value:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="WhenGuard":::

The relational pattern `> 35` describes the `temperature` input. The guard `when isOutdoors` checks a separate value. A guard is also preferable when the condition needs a method call or a Boolean expression that pattern syntax doesn't express clearly.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Property and positional patterns](property-positional-patterns.md)
- [C# operators](../expressions/operators.md)
- [Relational pattern reference](../../language-reference/operators/patterns.md#relational-patterns)
- [Logical and parenthesized pattern reference](../../language-reference/operators/patterns.md#logical-patterns)
