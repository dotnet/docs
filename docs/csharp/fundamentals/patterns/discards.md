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

In the following example, `statusCode` is an `int`. Each switch arm produces a `string` message, which the program writes to the console. The final `_` handles every status code other than `200` and `404`:

:::code language="csharp" source="snippets/discards/Program.cs" ID="DiscardPattern":::

A discard pattern is applied to an input expression. C# evaluates the expression, and `_` matches the evaluated value without capturing it. Choose `_` as the final switch-expression arm when every value not handled earlier should use the same fallback. Put it last because it matches everything, including `null`.

The form `var _` is a `var` pattern with a discard designation. It also matches every evaluated value, but it doesn't introduce a readable variable. Prefer the shorter `_` discard pattern for a switch catch-all. For more about `var` patterns and designations, see [Declaration, constant, and `var` patterns](declaration-constant-var-patterns.md#capture-a-result-for-a-guard-with-a-var-pattern).

## Deconstruction declarations

`GetForecast` returns a tuple with four components: a `string` city and three `int` values for the high temperature, low temperature, and rain chance. The deconstruction declaration retains `city` and `high` because the program displays them. It uses `_` for the low temperature and rain chance because naming those unused components would imply that the code needs them:

:::code language="csharp" source="snippets/discards/Program.cs" ID="TupleDiscards":::

The same discard syntax works when an object's `Deconstruct` method produces several values. For those forms, see [Deconstructing tuples and other types](../functional/deconstruct.md).

## Calls to methods with `out` parameters

The <xref:System.Int32.TryParse(System.String,System.Int32@)> method takes a `string` and returns a `bool` that reports whether parsing succeeded. It also produces the parsed `int` through its `out` parameter. This code prints only the Boolean result, so `out _` makes it clear that the integer isn't needed:

:::code language="csharp" source="snippets/discards/Program.cs" ID="OutDiscard":::

## A standalone discard

The following method receives a nullable `string`. The null-coalescing expression produces the non-null string or throws an <xref:System.ArgumentNullException>. The caller needs only that validation or exception effect, not the produced string, so a discard assignment provides the required assignment target and ignores the result:

:::code language="csharp" source="snippets/discards/Program.cs" ID="DiscardAssignment":::

A discard assignment fits when evaluating an expression matters but retaining its result doesn't. For ordinary parameter validation, <xref:System.ArgumentNullException.ThrowIfNull*> communicates the intent more directly and should usually be preferred.

> [!IMPORTANT]
> Don't use `_ = Task.Run(...)` or `_ = SomeAsyncMethod()` to discard a task in application code. Await the task so its completion and exceptions remain in the calling flow. A discard assignment doesn't make a task safe, observe its exception, or create a supported fire-and-forget operation.

## Mark unused lambda parameters

An <xref:System.EventHandler> receives an `object?` sender and an <xref:System.EventArgs> value. The following handler needs neither parameter; it only writes `"Timer tick"` to the console. Naming both parameters `_` makes their unused status visible without inventing names that the body never uses:

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
