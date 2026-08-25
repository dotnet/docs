---
title: "Async lambda pitfalls"
description: Learn how to avoid common pitfalls when passing async lambdas to methods that expect Action delegates, Parallel.ForEach, or Task.Factory.StartNew.
ms.date: 04/09/2026
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "async lambda"
  - "async void, lambda"
  - "Parallel.ForEach, async"
  - "Task.Factory.StartNew, async"
  - "Task<Task>"
  - "Action delegate, async"
---
# Async lambda pitfalls

Async lambdas and anonymous methods are powerful features that let you create delegates representing asynchronous operations. Use them with APIs that are designed for asynchronous delegates. This article shows the right patterns first, and then explains what goes wrong when you pass async lambdas to APIs that expect synchronous delegates.

## Async lambdas assigned to `Action` delegates

Create an overload that accepts `Func<Task>` and await the result:

:::code language="csharp" source="./snippets/async-lambda-pitfalls/csharp/Program.cs" id="ActionFix":::
:::code language="vb" source="./snippets/async-lambda-pitfalls/vb/Program.vb" id="ActionFix":::

Whenever you pass an async lambda to a method, verify the parameter's delegate type. If the parameter is `Action`, `Action<T>`, or any other void-returning delegate, switch to a task-returning delegate for asynchronous operations.

An async lambda can match a `void`-returning delegate type like <xref:System.Action> in addition to `Func<Task>`. When the target parameter is an `Action`, the compiler maps the async lambda to an async void method. The caller has no way to track completion.

Consider a timing helper that accepts an `Action`:

:::code language="csharp" source="./snippets/async-lambda-pitfalls/csharp/Program.cs" id="ActionPitfall":::
:::code language="vb" source="./snippets/async-lambda-pitfalls/vb/Program.vb" id="ActionPitfall":::

When you pass a synchronous lambda, the measured time is accurate. With an async lambda, the `Action` delegate returns as soon as the first `await` yields, so the timer captures only the synchronous portion instead of the full operation.

## `Parallel.ForEach` with async lambdas

In .NET 6 and later, use <xref:System.Threading.Tasks.Parallel.ForEachAsync*>, which accepts a `Func<TSource, CancellationToken, ValueTask>`:

:::code language="csharp" source="./snippets/async-lambda-pitfalls/csharp/Program.cs" id="ParallelForEachFix":::
:::code language="vb" source="./snippets/async-lambda-pitfalls/vb/Program.vb" id="ParallelForEachFix":::

Alternatively, project the items into tasks and use <xref:System.Threading.Tasks.Task.WhenAll*>:

:::code language="csharp" source="./snippets/async-lambda-pitfalls/csharp/Program.cs" id="WhenAllAlternative":::
:::code language="vb" source="./snippets/async-lambda-pitfalls/vb/Program.vb" id="WhenAllAlternative":::

<xref:System.Threading.Tasks.Parallel.ForEach*> accepts an `Action<T>` for its body parameter. Passing an async lambda creates an async void delegate. `Parallel.ForEach` returns as soon as each delegate hits its first yielding `await`:

:::code language="csharp" source="./snippets/async-lambda-pitfalls/csharp/Program.cs" id="ParallelForEachBug":::
:::code language="vb" source="./snippets/async-lambda-pitfalls/vb/Program.vb" id="ParallelForEachBug":::

The loop completes in milliseconds instead of the expected duration because the async lambdas become fire-and-forget operations.

## `Task.Factory.StartNew` with async lambdas

<xref:System.Threading.Tasks.Task.Run*> automatically unwraps async lambdas. It accepts `Func<Task>` and `Func<Task<TResult>>` overloads and returns the inner task:

:::code language="csharp" source="./snippets/async-lambda-pitfalls/csharp/Program.cs" id="StartNewFix1":::
:::code language="vb" source="./snippets/async-lambda-pitfalls/vb/Program.vb" id="StartNewFix1":::

If you need `StartNew`-specific options (such as <xref:System.Threading.Tasks.TaskCreationOptions.LongRunning>), call <xref:System.Threading.Tasks.TaskExtensions.Unwrap*> on the result:

:::code language="csharp" source="./snippets/async-lambda-pitfalls/csharp/Program.cs" id="StartNewFix2":::
:::code language="vb" source="./snippets/async-lambda-pitfalls/vb/Program.vb" id="StartNewFix2":::

When you pass an async lambda to <xref:System.Threading.Tasks.TaskFactory.StartNew*>, the return type is `Task<Task>` (or `Task<Task<TResult>>`). The outer task represents only the synchronous part of the delegate—it completes at the first yielding `await`. The inner task represents the full asynchronous operation:

:::code language="csharp" source="./snippets/async-lambda-pitfalls/csharp/Program.cs" id="StartNewBug":::
:::code language="vb" source="./snippets/async-lambda-pitfalls/vb/Program.vb" id="StartNewBug":::

If you treat the outer task as the whole operation, you'll observe completion before the async work actually finishes.

## Summary

When you pass an async lambda to any method, verify the target parameter's delegate type:

| Delegate type                             | Async behavior                                              | Risk   |
|-------------------------------------------|-------------------------------------------------------------|--------|
| `Func<Task>`, `Func<Task<T>>`             | Caller receives a task that represents completion           | Safe   |
| `Action`, `Action<T>`                     | Becomes async void—caller can't observe completion          | High   |
| `Func<TResult>` where `TResult` is `Task` | Returns `Task<Task>`—outer task doesn't represent full work | Medium |

## See also

- [Common async/await bugs](common-async-bugs.md)
- [Task-based asynchronous pattern (TAP)](task-based-asynchronous-pattern-tap.md)
- [Consume the task-based asynchronous pattern](consuming-the-task-based-asynchronous-pattern.md)
