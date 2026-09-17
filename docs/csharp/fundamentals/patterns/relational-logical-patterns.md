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

Suppose a weather app receives the outdoor temperature as a whole number of degrees Celsius. The app needs to decide whether to show a freeze warning and to display a short description of the current conditions. The same relational symbol can appear in an ordinary expression or in a pattern:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="ExpressionAndPattern":::

`temperature < 0` is a *relational expression*. It has a left operand and a right operand, and produces a `bool`.

In `temperature is < 0`, `temperature` is the pattern input expression. C# evaluates it, and the relational pattern `< 0` tests the resulting value. In the switch arm `< 0 => "Freezing"`, the expression before `switch` supplies the input, so the pattern contains only `< 0`.

The example displays both Boolean results to show that these two tests classify the same temperature. It uses the result from `temperature is < 0` to choose whether to show the warning. The string returned by the switch expression becomes the conditions description.

Choose a relational expression for one direct comparison. Choose relational patterns when the comparison is part of a larger pattern or when several ranges map cleanly to switch results.

## Describe ranges with `and`

A greenhouse controller has a preferred temperature range of 18 through 24 degrees Celsius, inclusive. When the temperature is in that range, the controller keeps the current airflow. Otherwise, it tells the ventilation system to adjust the airflow:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="AndPattern":::

The input expression is `temperature`. The logical pattern `>= 18 and <= 24` combines two relational patterns that both test the same evaluated value. The `and` pattern matches only when both nested patterns match.

`and` is a pattern operator here, not the conditional-AND Boolean operator `&&`. Don't read the syntax as a promise that nested patterns are tested left to right or short-circuit like Boolean operands. Pattern matching describes what must match; don't rely on the order in which nested patterns are tested.

## Describe alternatives with `or` and exclusions with `not`

A transit service uses named enum values for a service day. Weekend service follows a different timetable:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="OrNotPatterns":::

`ServiceDay` is an enum that defines the named values used by the schedule. `ServiceDay.Saturday or ServiceDay.Sunday` is one logical pattern composed of two constant patterns. It matches when either nested pattern matches. The returned timetable name controls which schedule the app displays.

`ServiceStatus` represents the current operating condition of the transit service. An `Open` or `Limited` service can still accept trip-planning requests, but a `Closed` service can't. The `IsAvailable` result controls whether the app offers trip planning or shows that the service is unavailable.

The `IsAvailable` method uses the `not` pattern to reject the `Closed` status. `not` is a pattern operator, not the Boolean negation operator `!`. Choose `or` when several pattern alternatives have the same result. Choose `not` when expressing the excluded pattern is clearer than listing every accepted value.

## Group patterns with parentheses

Pattern operators bind in this order:

1. `not`
1. `and`
1. `or`

Suppose a request queue supports priority levels 1 through 3 for ordinary requests. Dispatchers can use priority 9 as an override for an urgent request. The following test accepts either kind of supported priority:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="ParenthesizedPattern":::

The parentheses aren't required for the compiler because `and` binds before `or`, but they make the two alternatives visible: an ordinary priority range, or the override. The program uses the Boolean result to add a request to the queue or reject an unsupported priority. Use parentheses whenever a reader might hesitate over the grouping. Parentheses can also change the default grouping, such as `not (>= 1 and <= 3)`.

## Use a `when` guard for a separate condition

Logical patterns work best when nested patterns describe the input value itself. A `when` guard is an additional Boolean condition on a `case` label or switch arm. Use a guard when the decision also depends on information that isn't naturally part of the pattern.

The following delivery price depends on the package weight and on a separate `isHoliday` setting:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="WhenGuard":::

The relational pattern `> 20` describes the `weightKg` input. The guard `when isHoliday` checks separate application state. A guard is also preferable when the condition needs a method call or a Boolean expression that pattern syntax doesn't express clearly.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Property and positional patterns](property-positional-patterns.md)
- [C# operators](../expressions/operators.md)
- [Relational pattern reference](../../language-reference/operators/patterns.md#relational-patterns)
- [Logical and parenthesized pattern reference](../../language-reference/operators/patterns.md#logical-patterns)
