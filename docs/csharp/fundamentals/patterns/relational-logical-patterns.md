---
title: "Relational, logical, and parenthesized patterns"
description: Learn how C# relational patterns compare values and how logical and parenthesized patterns combine pattern tests.
ms.date: 09/24/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Relational, logical, and parenthesized patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if patterns are new to you. For complete language rules, see [relational patterns](../../language-reference/operators/patterns.md#relational-patterns) and [logical patterns](../../language-reference/operators/patterns.md#logical-patterns) in the language reference.

Relational and logical patterns describe ranges, alternatives, and exclusions. The following method combines them to classify a temperature:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="CombinedPatterns":::

The expression `temperature` is the pattern input. C# evaluates it once, and each switch arm tests the resulting value. The arms demonstrate these tests:

- `< 0` tests one boundary.
- `>= 18 and <= 24` tests a range.
- `(>= 0 and < 10) or > 30` tests two alternative ranges.

This article shows both patterns and imperative conditions so you can learn each form and compare how they express the same decisions. A single condition can look similar in either form. Patterns can make a series of related branches easier to read by keeping the choices next to their results. Choose the form that makes the code easiest to understand.

## Compare values with relational patterns

A *relational pattern* compares its pattern input with a compile-time constant by using `<`, `>`, `<=`, or `>=`. A *compile-time constant* is a value the compiler can evaluate while compiling the program. Numeric and character literals, and `const` variables of compatible numeric or character types, are representative examples. Ordinary variables, properties, method calls, and `static readonly` fields aren't compile-time constants. In the opening example, both `>= 18` and `<= 24` test the same evaluated `temperature` value.

The same relational symbol can appear in an ordinary expression or in a pattern. The following example uses both forms with a temperature:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="ExpressionAndPattern":::

`temperature < threshold` is a *relational expression*. It evaluates both operands and produces a `bool`. Either operand can be a nonconstant expression.

In `temperature is < 0`, `temperature` is the pattern input expression. C# evaluates it, and the relational pattern `< 0` tests the resulting value. In the switch arm `< 0 => "Freezing"`, the expression before `switch` supplies the input, so the pattern contains only `< 0`.

The expression can compare `temperature` with the variable `threshold`. A relational-pattern operand must be a compile-time constant, so use the relational expression when the comparison value is a variable. When the comparison value is constant, either form can work.

When the right operand is constant, choose mainly for readability. A relational expression often fits one direct comparison. A relational pattern composes with other patterns and fits naturally when several ranges map to switch results.

## Combine conditions with logical patterns

*Logical patterns* combine or negate patterns with the pattern operators `and`, `or`, and `not`:

- An `and` pattern matches when both nested patterns match.
- An `or` pattern matches when either nested pattern matches.
- A `not` pattern succeeds when its nested pattern fails.

The opening example uses `and` to describe a range and `or` to describe alternatives. A `not` pattern can exclude a value, as in `status is not Status.Complete`. The following methods show both forms so you can learn their syntax and compare how they express the same test:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="PatternAndImperative":::

The pattern form uses two constant patterns joined by `or`. The imperative form uses two equality expressions joined by the conditional-OR operator `||`. Both forms are concise and clear for this single condition. Choose the form that best fits the surrounding code. Patterns often clarify several related choices in a `switch`, as in the opening example.

Pattern operators form patterns rather than Boolean expressions: `and` corresponds to pattern conjunction, `or` to pattern alternatives, and `not` to pattern negation. Boolean expressions use `&&`, `||`, and `!`. Choose `or` when several pattern alternatives have the same result. Choose `not` when expressing the excluded pattern is clearer than listing every accepted value.

## Group patterns with parentheses

A *parenthesized pattern* uses parentheses to show or change how nested patterns are grouped. *Binding* determines which pattern operands an operator groups together, similar to implicit grouping when you don't write parentheses. C# specifies the following binding order:

1. `not`
1. `and`
1. `or`

The following test accepts priorities 1 through 3 or the special priority 9:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="ParenthesizedPattern":::

The compiler groups `and` before `or`. The parentheses make the intended grouping explicit and the two alternatives easy to see: the range from 1 through 3, or 9. For readability, use parentheses whenever a pattern mixes `and` and `or`, or when `not` applies to a compound pattern. Parentheses can also change the default grouping, as in `not (>= 1 and <= 3)`.

The runtime check order for nested patterns is unspecified, and pattern operators follow pattern-matching rules rather than short-circuit Boolean rules. Write nested patterns so their result is independent of check order.

## Use a `when` guard for a separate condition

Logical patterns work best when nested patterns describe the input value itself. A `when` guard is an additional Boolean condition on a `case` label or switch arm. Use a guard when the decision also depends on information separate from the pattern input.

The following warning depends on the temperature and a separate `isOutdoors` value:

:::code language="csharp" source="snippets/patterns/RelationalLogicalPatterns.cs" ID="WhenGuard":::

The relational pattern `> 35` describes the `temperature` input. The guard `when isOutdoors` checks a separate value. A guard is also preferable when the condition needs a method call or a Boolean expression that pattern syntax doesn't express clearly.

Use relational and logical patterns when they make the input's allowed shapes or values easier to see, especially across several switch arms. Use an ordinary Boolean expression when it states a direct condition more simply. Use a `when` guard when a switch choice depends on a separate value or on a condition better expressed as a Boolean expression.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Property and positional patterns](property-positional-patterns.md)
- [C# operators](../expressions/operators.md)
- [Relational pattern reference](../../language-reference/operators/patterns.md#relational-patterns)
- [Logical pattern reference](../../language-reference/operators/patterns.md#logical-patterns)
- [Parenthesized pattern reference](../../language-reference/operators/patterns.md#parenthesized-pattern)
