---
title: "Tutorial: Combine C# techniques to generate badge labels"
description: Build a runnable badge-label generator that combines lambdas, LINQ, iterators, pattern matching, and local functions in one C# program.
ms.date: 10/21/2026
ms.topic: tutorial
ai-usage: ai-generated
---

# Tutorial: Combine C# techniques to generate badge labels

A meetup needs badge labels in name order. Each attendee requests one or more copies, and each label includes a message for the attendee's role. In this tutorial, you combine small C# techniques to produce the labels without a separate collection of formatted strings.

This tutorial is for developers who know basic C# methods, loops, and collections. You choose where short operations belong, make helper dependencies explicit, and decide when the program produces results. For the reasoning behind these choices, see [Building software](../building-software/index.md).

## Prerequisites

- The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- A text editor and a terminal.

## Start with one label per attendee

1. Create a folder named `BadgeLabels` and a file named `Program.cs` inside it.
1. Add the following code:

   :::code language="csharp" source="snippets/functional-techniques/start/Program.cs" id="Start":::

1. From that folder, run the file-based app:

   ```dotnetcli
   dotnet run --file Program.cs
   ```

The program writes:

```output
Ben | Host
Ada | Guest
```

The `Attendee` declaration defines a *record*, a type that groups related data and supplies value-based equality. Each attendee has a `Name`, a `Role`, and a requested number of `Copies`. The loop currently ignores `Copies`. For more about this type, see [Records](../types/records.md).

Keep this small input as you develop the program: Ben requests one copy, and Ada requests two. Only `Guest` and `Host` are supported roles, and copy counts must be positive.

## Sort with a lambda

To put attendees in name order, replace the `foreach` loop with:

:::code language="csharp" source="snippets/functional-techniques/sort/Program.cs" id="Sort":::

Run the same command. The output now puts Ada first:

```output
Ada | Guest
Ben | Host
```

`attendee => attendee.Name` is a *lambda expression*, an unnamed function supplied where code needs behavior. Here, the lambda tells `OrderBy` which value to sort by. The rule stays at the call site because it's short and its purpose is clear there.

`OrderBy` is part of *Language Integrated Query (LINQ)*, a set of C# features and .NET APIs for queries over data. `StringComparer.Ordinal` gives this sample a culture-independent name order. For the short names here, that order is alphabetical.

The `orderedAttendees` variable describes a query, not a completed sorted collection. `OrderBy` reads and sorts the attendees when `foreach` begins to enumerate the query. For more detail, see [Lambda expressions](../building-software/lambdas.md) and [Sort data with LINQ](../../linq/standard-query-operators/sorting-data.md).

## Produce the requested copies with an iterator

To expand each attendee into the requested number of labels, keep the data and record declaration. Replace the `orderedAttendees` declaration and its `foreach` loop with:

:::code language="csharp" source="snippets/functional-techniques/copies/Program.cs" id="PrintCopies":::

Add this function before the `Attendee` declaration:

:::code language="csharp" source="snippets/functional-techniques/copies/Program.cs" id="CreateCopies":::

Run the app again:

```output
Ada | Guest [1/2]
Ada | Guest [2/2]
Ben | Host [1/1]
```

`CreateLabels` is an *iterator*, a function that produces sequence elements one at a time. Its `IEnumerable<string>` return type represents a sequence of strings. Each `yield return` supplies one label to the inner `foreach` loop, which prints it before requesting the next label.

The loop expresses a one-to-many operation: one attendee produces as many strings as `Copies` requests. A collection would also work, but the caller only needs each label once. The iterator avoids a separate label collection and keeps the copy-number loop together.

*Deferred execution* means work starts when code enumerates a sequence rather than when code creates the sequence. Calling `CreateLabels(attendee)` doesn't run its body. The inner `foreach` starts that work, including the positive-copy check. A new enumeration runs the iterator again.

The copy check reports invalid input instead of silently producing no labels. For more on element production and timing, see [Iterators](../building-software/iterators.md).

## Calculate a message and name the formatting step

Each role needs a different message. Replace `CreateLabels` with the following version:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="CreateLabels":::

Run the app again:

```output
Ada | Guest | Welcome! [1/2]
Ada | Guest | Welcome! [2/2]
Ben | Host | Ask me for help [1/1]
```

The `switch` expression calculates the message once per attendee, before the copy loop. *Pattern matching* tests an expression against a specified pattern. Here, `attendee.Role` is the input expression, and the constant patterns `"Guest"` and `"Host"` test its evaluated value to select the matching message. The `_` pattern matches any other role and throws an exception, so unsupported roles don't receive a misleading default message.

For more detail, see [Constant patterns](../patterns/declaration-constant-var-patterns.md#match-a-specific-value-with-a-constant-pattern) and the [`switch` expression](../../language-reference/operators/switch-expression.md).

`FormatLabel` is a *local function*, a named function declared inside another function. Its placement inside `CreateLabels` communicates that the helper belongs to label production, not to other operations. The name also keeps the copy loop focused on how many labels to produce.

All formatting inputs arrive through parameters. The `static` modifier prevents `FormatLabel` from using local variables from its surrounding scope, so its dependencies stay explicit. If other operations later need the same formatting rule, consider a method on a shared type. For this program, the helper's local scope matches its use. See [Local functions](../building-software/local-functions.md).

Because `CreateLabels` is still an iterator, the role check also runs only when enumeration starts. For this controlled input, those checks belong with label production; the program doesn't promise to validate all attendees before it prints any labels.

## Verify the total and run the complete program

To compare actual label production with the requested count, replace the `orderedAttendees` declaration and its `foreach` loop with:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="PrintAndCount":::

`Sum` executes immediately and adds the copy counts from the input array. Its lambda, `attendee => attendee.Copies`, keeps another short rule at the call site. The `printed` counter increases only when the loop receives a label. The comparison checks whether label production matches the requested total.

The complete program is:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="Complete":::

Run it with `dotnet run --file Program.cs`. The output is:

```output
Ada | Guest | Welcome! [1/2]
Ada | Guest | Welcome! [2/2]
Ben | Host | Ask me for help [1/1]
Printed 3 of 3 requested labels.
```

The input array is already in memory. `Sum` reads it immediately, `OrderBy` sorts it when the outer loop begins, and `CreateLabels` produces strings as the inner loop advances. The program never builds a separate collection of labels. For broader query guidance, see [LINQ and collections](../../linq/how-to-query-collections.md).

## Summary

Each technique serves a different part of the same task:

- **Lambdas and LINQ** express short rules for name order and total copies beside the operations that use them.
- **An iterator** expresses custom one-to-many production and leaves label consumption to the caller.
- **A `switch` expression** calculates a role-specific value and makes unsupported roles explicit.
- **A local function** names the formatting step, limits its scope, and states its inputs.

Choose these forms when their scope, dependencies, and execution timing fit the operation. A direct loop, a shared method, or a completed collection can fit other callers better.
