---
title: "Local functions"
description: Learn how C# local functions keep named helper logic near its caller, capture local state, and support recursion.
ms.date: 10/06/2026
ms.topic: concept-article
ai-usage: ai-generated
---

# Local functions

> [!TIP]
> This article teaches practical use of local functions for developers who know how to write methods. For declaration details and diagnostic rules, see [Local function declarations](~/_csharpstandard/standard/statements.md#1364-local-function-declarations).

A *local function* is a named function declared inside another member, such as a method or constructor. Only code within the containing member can call it. Use a local function when helper logic belongs to one operation and a name makes that logic easier to understand.

The following shape declares and calls a local function:

```csharp
string CreateMessage(string name)
{
    return AddGreeting(name);

    string AddGreeting(string value) => $"Hello, {value}!";
}
```

`AddGreeting` stays inside `CreateMessage`. Other members of the type can't call it.

## Keep helper logic near its caller

Local functions let the main flow state what happens while helper functions explain individual steps. The following example creates a reading plan. It uses a local function to add one week's assignment at a time.

:::code language="csharp" source="snippets/local-functions/Program.cs" id="NearbyHelper":::

A `ReadingWeek` records a week number and the range of chapters assigned for that week. `AddWeek` belongs only to `CreateReadingPlan`, so its local scope communicates that relationship.

You can declare a local function before or after the statements that call it. Place it where readers can follow the main flow without losing context.

## Use parameters or capture local state

A non-static local function can use parameters and local variables from its containing member. This use is called *capture*. In the reading-plan example, `AddWeek` captures:

- `bookTitle`, `chapterCount`, and `chaptersPerWeek` from the `CreateReadingPlan` parameters.
- `plan` from a local variable.

Capture is useful when the helper naturally belongs to the surrounding operation. Keep the captured values few and obvious. If the helper can receive all its data through parameters, consider a `static` local function:

```csharp
static int LastChapter(int firstChapter, int chaptersPerWeek, int chapterCount) =>
    Math.Min(firstChapter + chaptersPerWeek - 1, chapterCount);
```

A static local function can't capture local variables, parameters, or instance state from the containing member. That restriction documents the helper's inputs.

## Use recursion when the problem repeats itself

*Recursion* occurs when a function calls itself with a smaller part of the problem. `AddWeek` in the example adds one week, then calls itself with the first chapter for the next week.

Every recursive function needs a condition that stops the calls. `AddWeek` stops when `firstChapter` exceeds `chapterCount`:

```csharp
if (firstChapter > chapterCount)
{
    return;
}
```

Local functions work well for recursion because their names are in scope throughout the containing member. Prefer a loop when it expresses the repeated work more directly. Choose recursion when the recursive structure makes the algorithm easier to understand.

## Choose a local function or lambda expression

Local functions and lambda expressions can both use surrounding variables, but they communicate different intent:

| Choose | When |
| --- | --- |
| Local function | The helper benefits from a name, has several statements, needs recursion, or is called from more than one place in the containing member. |
| Lambda expression | You pass short behavior directly to another method or store it in a delegate variable. |

The following code uses both forms:

:::code language="csharp" source="snippets/local-functions/Program.cs" id="LocalAndLambda":::

`IsShortWeek` names a rule reused by two operations in the method. The lambda passed to `Select` performs one short transformation at its point of use.

Use a regular method instead of a local function when several members need the helper. Use a lambda instead when the behavior is short and its purpose is clear from the receiving method.

Local functions can also be iterator functions that contain `yield return`. For that use, see [Iterators](iterators.md).

## See also

- [Functional techniques overview](index.md)
- [Lambda expressions](lambdas.md)
- [Methods](../../methods.md)
- [Local function compiler diagnostics](../../language-reference/compiler-messages/local-function-errors.md)
- [Use local function instead of lambda (style rule IDE0039)](../../../fundamentals/code-analysis/style-rules/ide0039.md)
