---
title: "Building software"
description: Choose C# techniques for the task at hand. Compare ways to pass behavior, organize helper logic, and produce sequences.
ms.date: 10/15/2026
ms.topic: overview
ai-usage: ai-generated
---

# Building software

Choose the C# technique that makes your intent clear to the next person who reads your code. You've learned language elements such as types, expressions, statements, and methods. This section helps you decide how to combine them to solve a task, and when to choose one approach over another.

> [!TIP]
> This article is part of the **Fundamentals** section for developers who know basic C# expressions, statements, and methods. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.

Often, several approaches produce the same result. You can write a loop or use a LINQ operation, give an operation a name or write it inline, and build a collection or produce its elements on demand. Start with what the caller needs, then choose the form that communicates that purpose most directly.

## Choose how to express an operation

Use a [lambda expression](lambdas.md) when you want to pass a short operation to another method. For example, a lambda beside a call to `Where` makes the rule for which items to keep visible at the call site.

When an existing method already expresses that operation, pass its name instead. This form is called a *method group*. A wrapper lambda adds little when the method name already says what the operation does.

For logic that needs several steps or a descriptive name, choose a named function:

- Use a [local function](local-functions.md) when only one member needs the helper. Its location makes that limited role clear.
- Use a regular [method](../../methods.md) when several members need the same operation.

Keep short operations close to their use. Give longer operations names that let readers understand the main flow before they read the details.

## Choose how to process a sequence

Use [LINQ](../statements/linq.md) when a standard operation, such as filtering, sorting, or selecting a result, describes the work clearly. Choose a [loop](../statements/iteration.md) when the main purpose is to perform an action for each item or when custom control flow makes the steps easier to follow.

When a method needs to return a sequence, choose how callers should receive the results:

- Use an [iterator](iterators.md) when callers can consume elements one at a time. An iterator produces elements as the caller requests them, so a caller can stop without producing the rest.
- Build and return a collection when callers need indexed access or need to reuse a saved result without repeating the computation.

An iterator and a loop serve different roles. An iterator supplies values for a caller to use. A loop can consume those values and perform the caller's work.

## Combine techniques where each one helps

The following example displays tasks that are urgent and ready to start. A `ProjectTask` holds a task's title, priority, and blocked status. The dashboard filters the tasks, formats each result, and writes it to the console.

:::code language="csharp" source="snippets/overview/Program.cs" id="CombineTechniques":::

Each choice keeps a different part of the work clear:

- The lambda passed to `Where` puts a short priority rule beside the operation that uses it.
- The local function `FormatTask` names a formatting step that belongs only to `ShowDashboard`.
- The iterator `ReadyTasks` lets callers consume ready tasks without creating an intermediate collection.
- The `foreach` loop makes the final action, writing each result, explicit.

These aren't the only possible choices. For example, `Where(static task => !task.IsBlocked)` could replace `ReadyTasks` because this readiness test is a simple filter. Prefer that shorter form for a one-off filter; give the operation a name when callers benefit from that name or when the sequence logic needs more steps.

Choose each technique for the job it does, rather than try to use every technique in every method.

## Next steps

- [Pass behavior with lambda expressions](lambdas.md)
- [Organize helper logic with local functions](local-functions.md)
- [Produce sequences with iterators](iterators.md)
