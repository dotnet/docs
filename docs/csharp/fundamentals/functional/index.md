---
title: "Functional techniques overview"
description: Learn how lambdas, local functions, and iterators help you pass behavior, organize helper logic, and produce sequences in C#.
ms.date: 10/06/2026
ms.topic: overview
ai-usage: ai-generated
---

# Functional techniques overview

> [!TIP]
> This article is part of the **Fundamentals** section for developers who know basic C# expressions, statements, and methods. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first.

C# is a *multi-paradigm language*. You can combine ideas from several programming styles instead of following one style throughout an application. Object-oriented code organizes data and behavior in types. Functional techniques treat behavior as a value, keep helper logic close to its use, or describe a sequence of values.

This section introduces three techniques that solve different problems:

- A [lambda expression](lambdas.md) defines behavior that you can pass to another method or store in a variable.
- A [local function](local-functions.md) gives nearby helper logic a name and limits its use to the containing member.
- An [iterator](iterators.md) produces a sequence one element at a time for `foreach` or another sequence operation.

These techniques work together, but none replaces the others. Choose the technique that best communicates what the code does.

## Choose a technique

Start with the role that the code needs to play:

| Need | Choose | Why |
| --- | --- | --- |
| Pass a short operation to another method | Lambda expression | The behavior appears beside the call that uses it. |
| Pass an existing named method | Method group | The method name already explains the behavior, so you don't need a wrapper lambda. |
| Reuse named helper logic only inside one member | Local function | The helper stays near its caller and can't be called from elsewhere. |
| Produce values as a caller requests them | Iterator | The method exposes an `IEnumerable<T>` sequence without building the complete result first. |

For longer behavior, prefer a descriptive name over a large inline lambda. Use a local function when only the containing member needs that name. Use a regular method when several members need the same operation.

## Combine the techniques

The following example prepares tasks for a project dashboard. A lambda selects urgent tasks, a local function formats each task, and an iterator produces only tasks that are ready to start. A `ProjectTask` represents one item of project work.

:::code language="csharp" source="snippets/overview/Program.cs" id="CombineTechniques":::

Each technique has one clear job:

- `task => task.Priority >= minimumPriority` passes the selection rule to `Where`. The lambda captures `minimumPriority` from the surrounding method.
- `FormatTask` names formatting logic used only by `ShowDashboard`. The local function captures `projectName`.
- `ReadyTasks` uses `yield return` to provide ready tasks when the `foreach` loop requests them.

The example still uses familiar object-oriented types: `ProjectTask` groups related data, and .NET collection types store that data. Functional techniques complement other C# styles rather than require a different application design.

## Keep data transformations readable

Functional techniques often appear in a flow where one operation produces input for the next. Keep each step focused:

- Use names that describe intent, such as `ReadyTasks` or `FormatTask`.
- Keep a lambda short enough to understand at the call site.
- Move multi-step logic into a local function or regular method.
- Use an iterator when callers benefit from consuming elements as they're produced.

Pattern matching solves a different problem: it tests the type, value, or shape of data. Combine these techniques when they clarify separate parts of a task. For guidance about data tests, see [Pattern matching overview](../patterns/pattern-matching.md).

## Next steps

- [Pass behavior with lambda expressions](lambdas.md)
- [Organize helper logic with local functions](local-functions.md)
- [Produce sequences with iterators](iterators.md)
- [Lambda expressions, delegates, and events](../types/delegates-lambdas.md)
