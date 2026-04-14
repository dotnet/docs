---
title: "Delegates, lambdas, and events"
description: Learn how to use Func and Action delegates, write lambda expressions, use static lambdas and discard parameters, and understand the basic event subscription model.
ms.date: 04/14/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Delegates, lambdas, and events

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. You build core type and method skills there before using delegates.
>
> **Experienced in another language?** Think of delegates as strongly typed function variables. In modern C#, you usually write them with lambda expressions and `Func` or `Action` types.

*Delegates* let you pass behavior as data. You use delegates when code needs a callback, a rule, or a transformation that the caller supplies.

In everyday C# code, you most often use:

- `Func<T...>` when a delegate returns a value.
- `Action<T...>` when a delegate returns `void`.
- Lambda expressions to create delegate instances.

A *lambda expression* is an anonymous function with a compact syntax. It lets you write a function inline without naming it, using the arrow operator `=>` to separate parameters from the body.

## Start with Func and Action

<xref:System.Func`2?displayProperty=nameWithType> and <xref:System.Action`1?displayProperty=nameWithType> cover most delegate scenarios without creating a custom delegate type.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="FuncAndAction":::

Use descriptive parameter names in lambdas so readers can understand intent without scanning the full method body.

## Pass lambdas to methods

A common pattern is to accept a `Func<T, bool>` or similar delegate parameter and apply it to a sequence of values.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="LambdaAsArgument":::

This pattern appears throughout LINQ and many .NET APIs.

## Use static lambdas when capture is unnecessary

A static lambda uses the `static` modifier before the parameter list, for example: `static x => x * 2` or `static (x, y) => x + y`. A static lambda can't capture local variables or instance state from the enclosing scope. *Capturing* means the lambda references variables from the enclosing scope. A *closure* is the combination of the lambda and the captured variables it holds a reference to. A non-static lambda can capture those values, while a static lambda must use only its parameters and values declared inside its body.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="StaticLambda":::

Static lambdas make intent clear and prevent accidental captures.

## Use discard parameters when inputs are irrelevant

Sometimes a delegate signature includes parameters you don't need. Use discards to signal that choice clearly.

Common examples include event handlers where you don't use `sender` or `EventArgs`, callbacks where you only need some of several inputs, and LINQ overloads that provide an index you don't use.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="DiscardParameters":::

Discards improve readability because they show which parameters matter.

## Event basics: subscribe with a lambda

Events expose notifications. You subscribe with a delegate, often a lambda expression.

Subscribing to an event is optional because publishers can raise events even when no listeners are attached. By contrast, APIs that accept a callback usually require that callback so the API can complete its work.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="MinimalEventIntro":::

This model lets publishers raise notifications without knowing subscriber implementation details.

## See also

- [Type system overview](index.md)
- [Methods](../../methods.md)
- [Pattern matching](../functional/pattern-matching.md)
- [Events (C# programming guide)](../../programming-guide/events/index.md)
