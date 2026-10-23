---
title: "Tutorial: Combine C# techniques to generate badge labels"
description: Build a runnable badge-label generator that combines lambdas, LINQ, iterators, pattern matching, and local functions in one C# program.
ms.date: 10/23/2026
ms.topic: tutorial
ai-usage: ai-assisted
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

1. From that folder, run the [file-based app](file-based-programs.md):

   ```dotnetcli
   dotnet run --file Program.cs
   ```

The program writes:

```output
Ben | Host
Ada | Guest
```

The `Attendee` declaration defines a *record*, a type that groups related data and supplies value-based equality. Each attendee has a `Name`, a `Role`, and a requested number of `Copies`. A record fits this small data model because the program passes attendee data between operations without changing it. For more about this type, see [Records](../types/records.md).

The fixed input uses an [array and a collection expression](../statements/collections.md). In each `new(...)` call, C# infers `Attendee` from the array element type; see [Target-typed `new`](../../language-reference/operators/new-operator.md#target-typed-new). [Top-level statements](../program-structure/top-level-statements.md) let you run the example without writing a `Main` method.

The [`foreach` loop](../statements/iteration.md#iterate-a-collection-with-foreach) reads each attendee, and an [interpolated string](../strings/interpolation.md) inserts their values into the output. The loop currently ignores `Copies`.

Keep this small input as you develop the program: Ben requests one copy, and Ada requests two. Only `Guest` and `Host` are supported roles, and copy counts must be positive.

## Sort with a lambda

To put attendees in name order, replace the `foreach` loop with:

:::code language="csharp" source="snippets/functional-techniques/sort/Program.cs" id="Sort":::

Run the same command. The output now puts Ada first:

```output
Ada | Guest
Ben | Host
```

`attendee => attendee.Name` is a *lambda expression*, an unnamed function supplied where code needs behavior. Here, the lambda tells `OrderBy` which value to sort by. The rule stays at the call site because it's short and its purpose is clear there. A named helper would also work, but wouldn't explain this one-property selection better. See [Lambda expressions](../building-software/lambdas.md).

`OrderBy` is part of *Language Integrated Query (LINQ)*, a set of C# features and .NET APIs for queries over data. See [LINQ queries](../statements/linq.md).

This example uses *method syntax*, which calls LINQ methods directly. A single sort is clearer here as a method call than as a query with `from`, `orderby`, and `select` clauses. Method syntax also lets you pass a comparer to `OrderBy`.

To keep the output independent of the machine's culture, the sample uses <xref:System.StringComparer.Ordinal> for name comparisons. For the short names here, that order is alphabetical. See [Sort data with LINQ](../../linq/standard-query-operators/sorting-data.md).

The [`var` declaration](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) lets the compiler infer the query variable's type. The `orderedAttendees` variable describes a query, not a completed sorted collection. To *enumerate* a sequence means to read its elements one at a time. `OrderBy` reads and sorts all the attendees when `foreach` first requests an element.

## Observe when the query runs

*Deferred execution* means work starts when code enumerates a sequence rather than when code defines the query. See [Run a query](../statements/linq.md#run-a-query). Use diagnostic output to see the difference:

1. Copy your current `Program.cs` to a separate folder named `QueryTiming`. Keep the attendee data and record declaration in that copy.
1. In the copy, replace the `orderedAttendees` declaration and its `foreach` loop with:

   :::code language="csharp" source="snippets/functional-techniques/timing/Program.cs" id="ObserveExecution":::

1. Run `dotnet run --file Program.cs` from `QueryTiming`. Before you read the output, predict whether `Sort key:` appears before or after `After query definition.`.

The output is:

```output
Before query definition.
After query definition.
Sort key: Ben
Sort key: Ada
Ada | Guest
Ben | Host
```

No sort keys appear between the two query-definition messages. The lambda runs only when `foreach` requests the first result. Both key messages appear before the first label because `OrderBy` needs every key before it can determine which attendee comes first. The keys follow the input order, Ben then Ada; the results follow the sorted order, Ada then Ben.

The diagnostic lambda needs both a message and a returned key, so it uses a [statement body](../building-software/lambdas.md#choose-an-expression-or-statement-body) with braces and `return`, instead of the original single-expression body.

Try two more changes in `QueryTiming`:

1. Add a second copy of the `foreach` loop after the first. Run the app again. After the first two labels, you see `Sort key: Ben`, `Sort key: Ada`, and both sorted labels again. Enumerating the query again repeats the sort; the query variable doesn't cache results.
1. Add `var sortedSnapshot = orderedAttendees.ToList();` immediately after the `After query definition.` message. Change both loops to read `sortedSnapshot` instead of `orderedAttendees`, and run again. The two key messages now appear only once, during `ToList`, before either loop prints labels.

*Materialization* means executing a query and storing its results in a collection. <xref:System.Linq.Enumerable.ToList*> does that immediately. Both loops now read the stored attendees without running the sort again. Use a snapshot when you need to reuse results without recalculating them; keep the deferred query when you want each enumeration to read the current input. See [Compose queries with cached results](../statements/linq.md#compose-queries).

The diagnostic messages belong only in this experiment. Return to the original `BadgeLabels` file, with its one-expression lambda and single loop, before you continue.

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

`CreateLabels` is an *iterator*, a function that produces sequence elements one at a time. Its <xref:System.Collections.Generic.IEnumerable`1> return type, written as `IEnumerable<string>`, represents a sequence of strings. Each `yield return` supplies one label to the inner `foreach` loop, which prints it before requesting the next label. See [Iterators](../building-software/iterators.md).

The [`for` loop](../statements/iteration.md#count-with-for) counts copies from 1 through `attendee.Copies`. One attendee produces as many strings as `Copies` requests. A collection would also work, but the caller only needs each label once. The iterator avoids a separate label collection and keeps the copy-number loop together. The outer and inner `foreach` loops separate attendee order from label production; the caller remains responsible for printing.

Calling `CreateLabels(attendee)` doesn't run its body. Like the LINQ query, the iterator uses deferred execution. The inner `foreach` starts that work, including the positive-copy check. A new enumeration runs the iterator again. Unlike `OrderBy`, the iterator doesn't need to produce all its results before it supplies the first one.

To observe that timing, temporarily add `Console.WriteLine($"Iterator started: {attendee.Name}");` as the first line inside `CreateLabels`. Inside the outer loop, replace the inner loop with:

:::code language="csharp" source="snippets/functional-techniques/timing-copies/Program.cs" id="ObserveIterator":::

Run the app. For Ada, `Sequence created: Ada` appears first, then `Iterator started: Ada`, then her two labels. Ben's sequence-created message, iterator-started message, and one label follow. Creating the sequence doesn't enter the iterator body; requesting its first element does. Remove the diagnostic line and restore the original inner loop before you continue.

The <xref:System.ArgumentOutOfRangeException.ThrowIfNegativeOrZero*> check reports invalid input instead of silently producing no labels. An *exception* reports a failure that interrupts normal execution; see [Create and throw exceptions](../exceptions/creating-and-throwing-exceptions.md). Here, an invalid copy count stops the program instead of silently skipping that attendee.

## Calculate a message and name the formatting step

Each role needs a different message. Replace `CreateLabels` with the following version:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="CreateLabels":::

Run the app again:

```output
Ada | Guest | Welcome! [1/2]
Ada | Guest | Welcome! [2/2]
Ben | Host | Ask me for help [1/1]
```

The [`switch` expression](../statements/selection.md#switch-expression) calculates the message once per attendee, before the copy loop. An expression fits because each role selects one value to assign to `message`. An `if`/`else` chain or a `switch` statement would work, but would repeat the assignment in each branch.

*Pattern matching* tests an expression against a specified pattern. Here, `attendee.Role` is the input expression, and the [constant patterns](../patterns/declaration-constant-var-patterns.md#match-a-specific-value-with-a-constant-pattern) `"Guest"` and `"Host"` test its evaluated value to select the matching message. The [discard pattern `_`](../patterns/discards.md#pattern-matching-with-switch) matches any other role and throws an exception, so unsupported roles don't receive a misleading default message. See [Pattern matching](../patterns/pattern-matching.md).

The [`nameof` operator](../strings/nameof.md) supplies the parameter name `attendee` to the exception. Unlike a hard-coded string, that name stays correct if you rename the parameter with a refactoring tool.

`FormatLabel` is a *local function*, a named function declared inside another function. Because only `CreateLabels` needs the formatting rule, its placement inside `CreateLabels` limits the helper to the operation that uses it. A private member method on a class would make the helper available to other members of that class. Choose that broader scope if several operations need the same rule. See [Local functions](../building-software/local-functions.md).

The name `FormatLabel` lets you follow the copy loop without reading the formatting details. Keeping the interpolated string directly in `yield return` would also work, as it did in the previous step; the name becomes more useful now that a label includes a role-specific message. The helper's [`=>` expression body](../../language-reference/operators/lambda-operator.md#expression-body-definition) returns the one formatted string.

All formatting inputs arrive through parameters. A non-static local function could *capture*, or use, variables from its surrounding scope. The `static` modifier prevents that capture, so its dependencies stay explicit. See [Parameters and captured state](../building-software/local-functions.md#use-parameters-or-capture-local-state).

Because `CreateLabels` is still an iterator, the role check also runs only when enumeration starts. For this controlled input, those checks belong with label production; the program doesn't promise to validate all attendees before it prints any labels.

## Verify the total and run the complete program

To compare actual label production with the requested count, replace the `orderedAttendees` declaration and its `foreach` loop with:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="PrintAndCount":::

`Sum` executes immediately and adds the copy counts from the input array. Unlike `OrderBy`, it returns one number, not a sequence to enumerate later. Its lambda, `attendee => attendee.Copies`, keeps another short rule at the call site. A loop with an accumulator would also work; `Sum` states directly that you want a total. See [Common LINQ methods](../statements/linq.md#common-linq-methods).

The [`printed++` increment](../expressions/operators.md#increment-and-decrement) increases the counter only when the loop receives a label. The [`if` statement](../statements/selection.md#branch-with-if-and-else) compares that count with the requested total and throws an exception if they differ.

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
