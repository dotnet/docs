---
title: "Declaration, constant, and var patterns"
description: Learn when to use C# declaration, constant, and var patterns to test or capture the result of an expression.
ms.date: 09/15/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Declaration, constant, and `var` patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if you haven't used C# patterns before. For complete language rules, see the [patterns reference](../../language-reference/operators/patterns.md).

A pattern is applied to an *input expression*. C# evaluates the expression, then the pattern tests or captures the resulting value. Declaration, constant, and `var` patterns answer three practical questions:

- **Declaration pattern:** Did the expression produce a non-null value of a compatible run-time type? If so, declare a variable for that value.
- **Constant pattern:** Did the expression produce one specific constant value?
- **`var` pattern:** What value did the expression produce? Capture it without first testing its type or value.

## Test and capture a type with a declaration pattern

A *declaration pattern* consists of a type and a *designation*. The type specifies what run-time type to test. The designation declares the variable that receives the matching value.

The following example receives an `object`, so the expression might produce many different types. The declaration pattern lets the matching branch use a decimal amount without a separate type test and cast:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="DeclarationPattern":::

In `value is decimal amount`:

- `value` is the input expression. C# evaluates it first.
- `decimal` is the tested type. The pattern matches when the evaluated value is non-null and its run-time type is compatible with `decimal`.
- `amount` is the designation. When the pattern matches, it declares `amount` and assigns the decimal value to it.

The compiler tracks whether a local variable has received a value before your code reads it. This tracking is called *definite assignment*. Inside the `if` block, the compiler knows that `amount` was assigned because the block runs only when the pattern matches.

Choose a declaration pattern when the matching branch needs to use the result as the tested type. It combines the test, conversion, and variable declaration, which avoids repeating the expression or writing a separate cast.

You can also use declaration patterns when one expression might produce several useful types:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="DeclarationSwitch":::

Each arm declares a variable of the matched type because the result needs that type's formatting behavior. Declaration patterns don't match `null` and don't use user-defined conversions. For the complete compatibility rules, see [Declaration and type patterns](../../language-reference/operators/patterns.md#declaration-and-type-patterns).

## Match a specific value with a constant pattern

A *constant pattern* tests whether an expression produces a particular constant, such as a number, string, Boolean, enum member, declared `const` value, or `null`.

Constant patterns fit a switch expression when several known values each produce a different result:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="ConstantPatterns":::

Choose this form when the command can have several discrete meanings. The switch arms keep the values and their results together. For one simple equality comparison, an `if` statement such as `if (command == Command.Start)` is usually easier to read.

Constant-pattern matching uses built-in language equality rules rather than a user-defined `==` operator. For the detailed equality and conversion rules, see the [constant pattern reference](../../language-reference/operators/patterns.md#constant-pattern).

The `null` constant pattern is useful for a reliable null check:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="ConstantNullPattern":::

Choose `is null` or `is not null` when you're checking null state. These patterns don't call a user-defined equality operator, even when the expression's type overloads `==`.

## Capture a result for a guard with a `var` pattern

A *`var` pattern* matches every result, including `null`, and declares a variable whose type is the input expression's compile-time type. Merely naming a calculation doesn't require a pattern. For example, prefer `var total = subtotal + tax;` over a one-arm switch expression.

A `var` pattern becomes useful when a switch arm needs to name a calculated result before a `when` condition can test it:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="VarPatternWhen":::

The input expression `scores.Average()` is evaluated once. Each `var average` pattern captures its result. The `when` clause is a *case guard*, an additional Boolean condition checked after the pattern matches. This form keeps the calculated average next to the ranges that classify it without calculating the average again.

Choose a `var` pattern when capturing the evaluated result helps a guard or a larger pattern express its decision. Because an unguarded `var` pattern always matches, put an unguarded `var` arm last.

If you don't need the captured value, use the [discard pattern `_`](discards.md#pattern-matching-with-switch) instead of declaring a variable.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Type patterns](type-patterns.md)
- [Discards and the discard pattern](discards.md)
- [Declaration and type pattern reference](../../language-reference/operators/patterns.md#declaration-and-type-patterns)
- [Constant pattern reference](../../language-reference/operators/patterns.md#constant-pattern)
- [`var` pattern reference](../../language-reference/operators/patterns.md#var-pattern)
