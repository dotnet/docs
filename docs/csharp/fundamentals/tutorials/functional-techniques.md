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
1. Copy the complete source in the following section into `Program.cs`. Use this same file for every step and experiment:

   :::code language="csharp" source="snippets/functional-techniques/Program.cs" id="Complete":::

1. At the top of the file, comment out the four active `#define` lines. Leave the three experiment lines commented out, too.
1. From that folder, run the [file-based app](file-based-programs.md):

   ```dotnetcli
   dotnet run --file Program.cs
   ```

The program writes:

```output
Ben | Host
Ada | Guest
```

The file contains every stage. From now on, change only the `#define` lines at the top, not method bodies or declarations. A `#if` directive includes code only when its symbol is defined; an `#else` branch supplies the alternative. See [Conditional compilation](../program-structure/preprocessor-directives.md#conditional-compilation).

Uncomment one additional stage line at each step, and keep the previous stage lines enabled:

| Stage | Active stage symbols |
| --- | --- |
| One label per attendee | None |
| Sort attendees | `BADGE_SORT` |
| Produce copies | `BADGE_SORT`, `BADGE_COPIES` |
| Format messages | `BADGE_SORT`, `BADGE_COPIES`, `BADGE_FORMAT` |
| Verify the count | `BADGE_SORT`, `BADGE_COPIES`, `BADGE_FORMAT`, `BADGE_COUNT` |

The downloaded source enables all four stage symbols, so it runs the final program by default. The other three symbols control optional experiments and stay off during the normal progression. These symbols use a `BADGE_` prefix to avoid SDK-defined symbols such as `TRACE`.

The following excerpts highlight code already in your file. Don't copy them over the complete program.

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="Input":::

The `Attendee` declaration defines a *record*, a type that groups related data and supplies value-based equality. Each attendee has a `Name`, a `Role`, and a requested number of `Copies`. A record fits this small data model because the program passes attendee data between operations without changing it. For more about this type, see [Records](../types/records.md).

The fixed input uses an [array and a collection expression](../statements/collections.md). In each `new(...)` call, C# infers `Attendee` from the array element type; see [Target-typed `new`](../../language-reference/operators/new-operator.md#target-typed-new). [Top-level statements](../program-structure/top-level-statements.md) let you run the example without writing a `Main` method.

The [`foreach` loop](../statements/iteration.md#iterate-a-collection-with-foreach) reads each attendee, and an [interpolated string](../strings/interpolation.md) inserts their values into the output. The loop currently ignores `Copies`.

Keep this small input as you develop the program: Ben requests one copy, and Ada requests two. Only `Guest` and `Host` are supported roles, and copy counts must be positive.

## Sort with a lambda

To put attendees in name order, uncomment `#define BADGE_SORT`. Leave the other symbols commented out. The sort branch defines this query:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="Sort":::

With diagnostics off, the `#else` branch supplies the short lambda. The loop prints the sorted attendees:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="PrintLabels":::

Run the same command. The output now puts Ada first:

```output
Ada | Guest
Ben | Host
```

`attendee => attendee.Name` is a *lambda expression*, an unnamed function supplied where code needs behavior. Here, the lambda selects the name to sort by. The lambda stays *inline*, directly in the `OrderBy` call, because it's short and its purpose is clear there. You could extract the selection into a named helper method, but a method name wouldn't explain this one-property selection better. See [Lambda expressions](../building-software/lambdas.md).

`OrderBy` is part of *Language Integrated Query (LINQ)*, a set of C# features and .NET APIs for queries over data. See [LINQ queries](../statements/linq.md).

This example uses *method syntax*, which calls LINQ methods directly. In contrast, *query syntax* uses C# clauses such as `from`, `orderby`, and `select`:

```csharp
var orderedAttendees =
    from attendee in attendees
    orderby attendee.Name
    select attendee;
```

The compiler translates query syntax into method calls. Query syntax can make a query with several clauses easier to read; method syntax keeps this single sort short and lets you pass a comparer to `OrderBy`. The query-syntax example uses the default string comparer, so it doesn't guarantee the same order across cultures. Keep the method-syntax version for this program. See [LINQ method and query syntax](../statements/linq.md#linq-method-syntax).

To keep the output independent of the machine's culture, the sample uses <xref:System.StringComparer.Ordinal> for name comparisons. For the short names here, that order is alphabetical. See [Sort data with LINQ](../../linq/standard-query-operators/sorting-data.md).

The [`var` declaration](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) lets the compiler infer the query variable's type. The `orderedAttendees` variable describes a query, not a completed sorted collection. To *enumerate* a sequence means to read its elements one at a time. `OrderBy` reads and sorts all the attendees when `foreach` first requests an element.

## Observe the order of execution

*Deferred execution* means work starts when code enumerates a sequence rather than when code defines the query. See [Run a query](../statements/linq.md#run-a-query). Use diagnostic output to see the difference:

1. Keep only `BADGE_SORT` enabled among the stage symbols.
1. Uncomment `#define BADGE_DIAGNOSTICS` at the top of the same file. The diagnostic branches surround the query definition with messages and use a lambda that prints each sort key:

   :::code language="csharp" source="snippets/functional-techniques/Program.cs" id="ObserveExecution":::

1. Run `dotnet run --file Program.cs` again. Before you read the output, predict whether `Sort key:` appears before or after `After query definition.`.

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

The diagnostic lambda needs both a message and a returned key, so it uses a [block statement body](../building-software/lambdas.md#choose-an-expression-or-statement-body) with braces and `return`, instead of the original single-expression body.

With diagnostics on, try the two experiment switches in the same file. No changes to the loops or query are needed:

1. Uncomment `#define BADGE_REPEAT` and run again:

   ```output
   Before query definition.
   After query definition.
   Sort key: Ben
   Sort key: Ada
   Ada | Guest
   Ben | Host
   Sort key: Ben
   Sort key: Ada
   Ada | Guest
   Ben | Host
   ```

   The second pass repeats the sort. The query variable doesn't cache results.

1. Keep `BADGE_REPEAT` enabled, uncomment `#define BADGE_SNAPSHOT`, and run again:

   ```output
   Before query definition.
   After query definition.
   Sort key: Ben
   Sort key: Ada
   Ada | Guest
   Ben | Host
   Ada | Guest
   Ben | Host
   ```

   The two key messages now appear only once, during `ToList`, before either pass prints labels. Both passes read the stored attendees.

These switches select the sequence to enumerate and the number of passes:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="Enumeration":::

*Eager execution* means an operation runs immediately instead of waiting for later enumeration. <xref:System.Linq.Enumerable.ToList*> executes the query immediately and stores its results in a list. Both passes now read the stored attendees without running the sort again. In contrast, defining the `OrderBy` query still defers the sort: it reads and buffers all input only when enumeration begins. Buffering doesn't mean the query executes when you define it. Use a snapshot when you need to reuse results without recalculating them; keep the deferred query when you want each enumeration to read the current input. See [Compose queries with cached results](../statements/linq.md#compose-queries).

Before you continue, comment out `BADGE_DIAGNOSTICS`, `BADGE_REPEAT`, and `BADGE_SNAPSHOT` again. Keep `BADGE_SORT` enabled. Run the app to confirm that only the two sorted labels appear.

## Produce the requested copies with an iterator

To expand each attendee into the requested number of labels, uncomment `#define BADGE_COPIES` alongside `BADGE_SORT`. The loop now selects the `BADGE_COPIES` branch shown earlier and calls the iterator already in the file:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="CreateLabels":::

Run the app again:

```output
Ada | Guest [1/2]
Ada | Guest [2/2]
Ben | Host [1/1]
```

`CreateLabels` is an *iterator*, a function that produces sequence elements one at a time. Its <xref:System.Collections.Generic.IEnumerable`1> return type, written as `IEnumerable<string>`, represents a sequence of strings. Each `yield return` supplies one label to the inner `foreach` loop, which prints it before requesting the next label. See [Iterators](../building-software/iterators.md).

The [`for` loop](../statements/iteration.md#count-with-for) counts copies from 1 through `attendee.Copies`. One attendee produces as many strings as `Copies` requests. A collection would also work, but the caller only needs each label once. The iterator avoids a separate label collection and keeps the copy-number loop together. The outer and inner `foreach` loops separate attendee order from label production; the caller remains responsible for printing.

Calling `CreateLabels(attendee)` doesn't run its body. Like the LINQ query, the iterator uses deferred execution. The inner `foreach` starts that work, including the positive-copy check. A new enumeration runs the iterator again. Unlike `OrderBy`, which reads and sorts all attendees before its first result, this iterator supplies a label without creating the remaining labels.

To observe the iterator's order of execution, uncomment `#define BADGE_DIAGNOSTICS` again. Keep `BADGE_REPEAT` and `BADGE_SNAPSHOT` off. Diagnostics now show both the sort and the iterator:

```output
Before query definition.
After query definition.
Sort key: Ben
Sort key: Ada
Sequence created: Ada
Iterator started: Ada
Ada | Guest [1/2]
Ada | Guest [2/2]
Sequence created: Ben
Iterator started: Ben
Ben | Host [1/1]
```

For each attendee, the sequence-created message appears before the iterator-started message and the labels. Creating the sequence doesn't enter the iterator body; requesting its first element does. Comment out `BADGE_DIAGNOSTICS` again before you continue.

The same experiment controls remain available in the later stages. `BADGE_REPEAT` enumerates the attendees twice and creates each attendee's label sequence again. `BADGE_SNAPSHOT` caches only the sorted attendees, not label strings, so it prevents another sort but doesn't prevent the iterator from running again on each pass.

The <xref:System.ArgumentOutOfRangeException.ThrowIfNegativeOrZero*> check reports invalid input instead of silently producing no labels. An *exception* reports a failure that interrupts normal execution; see [Create and throw exceptions](../exceptions/creating-and-throwing-exceptions.md). Here, an invalid copy count stops the program instead of silently skipping that attendee.

## Calculate a message and name the formatting step

Each role needs a different message. Uncomment `#define BADGE_FORMAT`, and leave `BADGE_SORT` and `BADGE_COPIES` enabled. The same iterator now includes the message calculation:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="Message":::

It also selects the `yield return FormatLabel(...)` branch and includes this local helper:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="FormatLabel":::

Run the app again:

```output
Ada | Guest | Welcome! [1/2]
Ada | Guest | Welcome! [2/2]
Ben | Host | Ask me for help [1/1]
```

The [`switch` expression](../statements/selection.md#switch-expression) calculates the message once per attendee, before the copy loop. An expression fits because each role selects one value to assign to `message`. An `if`/`else` chain or a `switch` statement would work, but would repeat the assignment in each branch.

*Pattern matching* tests an expression against a specified pattern. Here, `attendee.Role` is the input expression, and the [constant patterns](../patterns/declaration-constant-var-patterns.md#match-a-specific-value-with-a-constant-pattern) `"Guest"` and `"Host"` test its evaluated value to select the matching message. The [discard pattern `_`](../patterns/discards.md#pattern-matching-with-switch) matches any other role and throws an exception, so unsupported roles don't receive a misleading default message. See [Pattern matching](../patterns/pattern-matching.md).

The [`nameof` operator](../strings/nameof.md) supplies the parameter name `attendee` to the exception. Unlike a hard-coded string, that name stays correct if you rename the parameter with a refactoring tool.

`FormatLabel` is a *local function*, a named function declared inside another function. Because only `CreateLabels` needs the formatting operation, its placement inside `CreateLabels` limits the helper to the operation that uses it. A private member method on a class would make the helper available to other members of that class. Choose that broader scope if several operations need the same formatting operation. See [Local functions](../building-software/local-functions.md).

The name `FormatLabel` lets you follow the copy loop without reading the formatting details. Keeping the interpolated string directly in `yield return` would also work, as it did in the previous step. The name becomes more useful now that a label includes a role-specific message. The helper's [`=>` expression body](../../language-reference/operators/lambda-operator.md#expression-body-definition) returns the one formatted string.

All formatting inputs arrive through parameters. A non-static local function could *capture*, or use, variables from its surrounding scope. The `static` modifier prevents that capture, so its dependencies stay explicit. See [Parameters and captured state](../building-software/local-functions.md#use-parameters-or-capture-local-state).

Because `CreateLabels` is still an iterator, the role check also runs only when enumeration starts. For this controlled input, those checks belong with label production. The program doesn't promise to validate all attendees before it prints any labels.

## Verify the total and run the complete program

To compare actual label production with the requested count, uncomment `#define BADGE_COUNT`. All four stage symbols are now enabled. Leave the three experiment symbols commented out for the normal final output.

The count setup runs before the attendee loop:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="CountSetup":::

`Sum` uses eager execution to add the copy counts from the input array. Unlike `OrderBy`, it returns one number, not a sequence to enumerate later. Its lambda, `attendee => attendee.Copies`, selects the copy count inline. As with the name selection, a separate helper method wouldn't clarify this short expression. A loop with an accumulator would also work; `Sum` states directly that you want a total. See [Common LINQ methods](../statements/linq.md#common-linq-methods).

The [`printed++` increment](../expressions/operators.md#increment-and-decrement) in the label loop increases the counter only when the loop receives a label. After that loop, the [`if` statement](../statements/selection.md#branch-with-if-and-else) compares that count with the requested total and throws an exception if they differ:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="CountCheck":::

You've reached the default configuration of the complete program you copied at the start. No methods or declarations needed to change:

:::code language="csharp" source="snippets/functional-techniques/Program.cs" id="Controls":::

Run it with `dotnet run --file Program.cs`. The output is:

```output
Ada | Guest | Welcome! [1/2]
Ada | Guest | Welcome! [2/2]
Ben | Host | Ask me for help [1/1]
Printed 3 of 3 requested labels.
```

The input array is already in memory. `Sum` reads it immediately, `OrderBy` sorts it when the attendee loop begins, and `CreateLabels` produces strings as the inner loop advances. The program never builds a separate collection of labels. For broader query guidance, see [LINQ and collections](../../linq/how-to-query-collections.md).

To revisit the diagnostics with the final program, enable `BADGE_DIAGNOSTICS` alone among the experiment symbols. The output is:

```output
Before query definition.
After query definition.
Sort key: Ben
Sort key: Ada
Sequence created: Ada
Iterator started: Ada
Ada | Guest | Welcome! [1/2]
Ada | Guest | Welcome! [2/2]
Sequence created: Ben
Iterator started: Ben
Ben | Host | Ask me for help [1/1]
Printed 3 of 3 requested labels.
```

If you also enable `BADGE_REPEAT`, each pass checks and reports its own count. With `BADGE_SNAPSHOT` enabled, the sort keys appear only once, but the iterator messages, labels, and count report still appear on each pass. Comment out the experiment symbols to restore the normal final output.

## Summary

Each technique serves a different part of the same task:

- **Lambdas and LINQ** select names and copy counts inline for the sort and total.
- **An iterator** expresses custom one-to-many production and leaves label consumption to the caller.
- **A `switch` expression** calculates a role-specific value and makes unsupported roles explicit.
- **A local function** names the formatting step, limits its scope, and states its inputs.

Choose these forms when their scope, dependencies, and order of execution fit the operation. A direct loop, a shared method, or a completed collection can fit other callers better.
