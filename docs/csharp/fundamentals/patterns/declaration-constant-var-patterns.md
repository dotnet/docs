---
title: "Declaration, constant, and var patterns"
description: Learn to test and capture values with C# declaration, constant, and var patterns.
ms.date: 09/14/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Declaration, constant, and `var` patterns

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. Start with the [pattern matching overview](pattern-matching.md) if you haven't used C# patterns before. For the complete language rules, see the [patterns reference](../../language-reference/operators/patterns.md).

Declaration, constant, and `var` patterns answer three everyday questions:

- **Declaration pattern:** Does this value have a compatible run-time type? If so, capture it in a new variable.
- **Constant pattern:** Does this value equal one specific constant?
- **`var` pattern:** Capture this value in a new variable without testing it.

> [!NOTE]
> Beginning with C# 15, which is currently in preview, declaration and constant patterns generally test a [union type's `Value`](../../language-reference/builtin-types/union.md#union-pattern-matching). The `null` constant pattern also follows the union null-matching rules. A `var` pattern is an exception: It captures the union value itself.

## Test and capture a type with a declaration pattern

A *declaration pattern* contains a type followed by a variable name. It matches a non-null value whose run-time type is compatible with the specified type:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="DeclarationPattern":::

The pattern `decimal amount` performs two operations together: it tests whether `value` can be treated as a `decimal`, and it assigns the converted value to `amount`. The new variable is definitely assigned only where the pattern matched.

The specified type can be a class, a base class, or an implemented interface. This capability lets one switch expression handle several related types without separate casts:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="DeclarationSwitch":::

Declaration patterns don't match `null`. They also don't use user-defined conversions. The input's compile-time type and the pattern type must be *pattern compatible*. Pattern compatibility includes identity, reference, boxing, unboxing, nullable, and open-type cases described in the [declaration pattern reference](../../language-reference/operators/patterns.md#declaration-and-type-patterns). At run time, the value must pass the corresponding type test.

## Match a specific value with a constant pattern

A *constant pattern* compares an input with one constant value. Constants include number, character, string, Boolean, and enum values, declared `const` values, and `null`:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="ConstantPatterns":::

Use constant patterns when each named or discrete value has a distinct meaning. For integral and enum inputs, including their nullable forms, C# compares the converted values with the built-in `==` operation. For other supported inputs, matching uses `object.Equals`, with one exception: A `Span<char>` or `ReadOnlySpan<char>` input can match a non-null constant string by using <xref:System.MemoryExtensions.SequenceEqual*>. User-defined `==` operators aren't used by constant-pattern matching.

Put the most specific arms first and finish with another pattern, such as `_`, when other input values are valid.

Use `is null` or `is not null` for null checks:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="ConstantNullPattern":::

The `null` constant pattern matches only `null`. It doesn't call a user-defined equality operator. That behavior makes the test reliable even when the value's type overloads `==`.

## Capture any value with a `var` pattern

A *`var` pattern* always matches and assigns the input to a new variable. Unlike a declaration pattern, it doesn't test the run-time type:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="VarPattern":::

The compiler infers `total` as `decimal` from the input expression. A `var` pattern matches every value, including `null`, and the variable has the input expression's compile-time type. Because the pattern always matches, an unguarded `var` arm belongs last. Otherwise, it subsumes every later arm.

A `var` pattern is most useful when the input is an expression whose result you want to name and use in a condition:

:::code language="csharp" source="snippets/patterns/BasicPatterns.cs" ID="VarPatternWhen":::

The `when` clause is a *case guard*: an additional Boolean condition evaluated after the pattern matches. In this example, `var average` gives the calculated value a name so the guard and result can both use it. The arms remain reachable because a guard can be `false`.

If you don't need the captured value, use the [discard pattern `_`](discards.md#pattern-matching-with-switch) instead of giving it a name.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Type patterns](type-patterns.md)
- [Discards](discards.md)
- [Declaration and type pattern reference](../../language-reference/operators/patterns.md#declaration-and-type-patterns)
- [Constant pattern reference](../../language-reference/operators/patterns.md#constant-pattern)
- [`var` pattern reference](../../language-reference/operators/patterns.md#var-pattern)
