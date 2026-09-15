---
title: "Discards and the discard pattern"
description: Learn the difference between a C# discard pattern, a discard that ignores a produced value, and an unused lambda parameter.
ms.date: 09/15/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Discards and the discard pattern

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to patterns, start with the [pattern matching overview](pattern-matching.md). For complete syntax, see the [discard pattern reference](../../language-reference/operators/patterns.md#discard-pattern).

The underscore token (`_`) communicates that a value isn't needed. Its exact meaning depends on where it appears:

| Context | Meaning of `_` |
| --- | --- |
| A switch expression arm or a nested pattern | A *discard pattern* that matches without capturing the result |
| A deconstruction or `out` argument | A *discard* that ignores one produced value |
| An assignment such as `_ = expression` | A *discard assignment* that evaluates the expression and ignores its result |
| Two or more lambda parameters named `_` | *Discard parameters* whose inputs aren't used |
| `var _` in a pattern | A `var` pattern with a discard designation |

These forms share spelling and intent, but they aren't interchangeable.

## Pattern matching with `switch`

A discard pattern is applied to an input expression. C# evaluates the expression, and `_` matches every resulting value, including `null`, without capturing it:

:::code language="csharp" source="snippets/discards/Program.cs" ID="DiscardPattern":::

Choose a discard pattern as the final switch-expression arm when every result not handled earlier should use the same fallback. Put it last because it matches everything.

The `_` in this example is a pattern. By contrast, `out _` and a deconstruction `_` ignore values produced by another operation. The form `var _` is a `var` pattern with a discard designation. It also matches every result, but the shorter discard pattern better expresses a catch-all switch arm.

## Deconstruction declarations

A method can return a tuple that contains several components. A *deconstruction declaration* separates those components, declares variables for the retained values, and uses `_` for each component that the current code doesn't need:

:::code language="csharp" source="snippets/discards/Program.cs" ID="TupleDiscards":::

`GetForecast` returns the named components `City`, `High`, `Low`, and `RainChance`. The declaration creates `city` and `high`, and discards the low temperature and rain chance. Choose discards when the operation produces useful values for other callers but this code needs only a subset.

The same discard syntax works when an object's `Deconstruct` method produces several values. For those forms, see [Deconstructing tuples and other types](../functional/deconstruct.md).

## Calls to methods with `out` parameters

Some methods use an `out` parameter to return an additional value. If you need only the method's Boolean success result, use `out _`:

:::code language="csharp" source="snippets/discards/Program.cs" ID="OutDiscard":::

The code asks only whether the text can be parsed. It doesn't need the parsed integer, so naming that integer would suggest that later code uses it.

## A standalone discard

A discard assignment evaluates its right-hand expression and ignores the produced value. The following example uses the null-coalescing operator to validate an argument:

:::code language="csharp" source="snippets/discards/Program.cs" ID="DiscardAssignment":::

Choose a discard assignment when evaluating the expression matters but retaining its result doesn't. Don't use one merely to avoid giving a useful result a meaningful name.

### Discarded tasks require another failure strategy

> [!WARNING]
> `_ = Task.Run(...)` only states that the returned task is intentionally ignored and suppresses the warning for an unawaited call. It doesn't await the task, observe its exception, or report failure. This form isn't general fire-and-forget guidance. Use it only when the application has another deliberate mechanism to track completion and report errors.

The following method shows the syntax:

:::code language="csharp" source="snippets/discards/Program.cs" ID="TaskDiscard":::

In most application code, prefer awaiting the task so completion and exceptions remain part of the calling flow.

## Mark unused lambda parameters

When a lambda expression has two or more unused parameters, you can name each one `_`:

:::code language="csharp" source="snippets/discards/Program.cs" ID="LambdaDiscards":::

Choose discard parameters when a delegate signature requires inputs that the lambda body doesn't use. If a lambda has only one parameter named `_`, `_` remains an ordinary parameter name for backward compatibility.

## Avoid `_` as an identifier

`_` can be an ordinary identifier in contexts where C# doesn't recognize a discard. An in-scope variable named `_` can receive an assignment that looks like a discard assignment. In a pattern context, an accessible constant or type named `_` can also change how `_` is interpreted. Avoid declaring your own variables, constants, or types named `_`; use `_` to communicate discard intent.

## See also

- [Pattern matching overview](pattern-matching.md)
- [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md)
- [Deconstructing tuples and other types](../functional/deconstruct.md)
- [Lambda expression parameters](../../language-reference/operators/lambda-expressions.md#input-parameters-of-a-lambda-expression)
- [Discard pattern reference](../../language-reference/operators/patterns.md#discard-pattern)
