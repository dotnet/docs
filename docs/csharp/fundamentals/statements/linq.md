---
title: "LINQ queries in C#"
description: Query collections with LINQ by using query syntax, method syntax, common operators, and lambda expressions.
ms.date: 07/15/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# LINQ queries

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For more information about providers, operators, and advanced scenarios, see [Language Integrated Query (LINQ)](../../linq/index.md).
>
> **Coming from another language?** LINQ query syntax reads like a SQL-style query written inside C#. LINQ method syntax reads like chained collection operations in JavaScript, Java streams, or Python pipelines. Both forms describe the same query.

*Language Integrated Query (LINQ)* is the C# feature set for querying data with C# syntax. Many LINQ operators use *deferred execution*: they describe the result first and read the data later, when your code asks for the results. A *query* describes which data to read and how to shape the result. A query reads from a *data source*. A data source can be an in-memory collection, such as an array or <xref:System.Collections.Generic.List`1>, or an external source, such as a database or XML, exposed through a LINQ provider. A *LINQ provider* is a library that connects LINQ syntax to a specific kind of data source. This article uses in-memory collections for its examples. A *sequence* is an ordered set of elements represented by <xref:System.Collections.Generic.IEnumerable`1>. For more information about provider-based queries, see [Language Integrated Query (LINQ)](../../linq/index.md) in the LINQ section.

## LINQ query expression syntax

The examples in this article read in-memory collections such as arrays and <xref:System.Collections.Generic.List`1>. A query usually has three parts: specify the data source, describe the result, and enumerate the source to produce the result. To *enumerate* a sequence means to read its elements one at a time, often with `foreach`.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="QuerySyntax":::

The query expression starts with `from` to name the data source and range variable. The `where` clause keeps only matching elements, `orderby` sorts them, and `select` shapes the result.

## LINQ method syntax

*Query syntax* uses clauses such as `from`, `where`, `orderby`, and `select`. *Method syntax* calls LINQ methods directly. For in-memory sequences, the standard LINQ methods are the built-in <xref:System.Linq.Enumerable> methods for filtering, projection, sorting, grouping, and related operations.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="MethodSyntax":::

Method syntax is also called *fluent syntax* because each call returns a result that the next call can use. Many queries can use either form. Use the form that makes the query easiest to read.

Query syntax often reads well when the query has several clauses. The `let` clause gives a name to an intermediate value before the query filters, sorts, and selects the final result:

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="QuerySyntaxClearer":::

Method syntax often reads well for short operations. It's necessary for methods that don't have query-syntax keyword. For example, <xref:System.Linq.Enumerable.Count*> returns one value directly:

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="MethodSyntaxClearer":::

## Lambda expressions and LINQ

A *lambda expression* is an anonymous function that you can pass as an argument. LINQ method syntax commonly uses lambda expressions to say what each operator should do with each element.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="LambdaExpressions":::

In `name => name.Length == 3`, `name` is the input element and `name.Length == 3` is the Boolean expression that decides whether the element belongs in the result. For more information about lambda expressions and delegate types, see [Lambda expressions, delegates, and events](../types/delegates-lambdas.md) in the fundamentals.

Query-syntax clauses use lambda expressions too. Clauses such as `where`, `orderby`, and `select` compile to method calls that take lambda expressions. The range variable becomes the lambda parameter, and the clause expression becomes the lambda body. Query syntax is a concise way to write those same lambdas:

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="QuerySyntaxLambda":::

## Common LINQ methods

The most common LINQ methods cover the everyday steps of a query: filter data, shape results, sort, group, and summarize. These methods are in the <xref:System.Linq> namespace and work with sequences such as <xref:System.Collections.Generic.IEnumerable`1>.

- <xref:System.Linq.Enumerable.Where*> keeps only the elements that match a condition.
- <xref:System.Linq.Enumerable.Select*> transforms each element into a new value. C# calls this operation a *projection*.
- <xref:System.Linq.Enumerable.OrderBy*> sorts elements.
- <xref:System.Linq.Enumerable.GroupBy*> creates groups of elements that share a key.
- Aggregation methods such as <xref:System.Linq.Enumerable.Sum*>, <xref:System.Linq.Enumerable.Count*>, and <xref:System.Linq.Enumerable.Aggregate*> produce a single value from all elements in the data source.

> [!NOTE]
> If you know the traditional functional-programming terms, <xref:System.Linq.Enumerable.Where*> is a *filter*, <xref:System.Linq.Enumerable.Select*> is a *map* (C# calls it a projection), and aggregation methods such as <xref:System.Linq.Enumerable.Aggregate*>, <xref:System.Linq.Enumerable.Sum*>, and <xref:System.Linq.Enumerable.Count*> are a *reduce*.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="CommonOperators":::

A *projection* creates a result value from each input element. In the previous example, the projection creates strings that combine a work item name and its priority.

### Group related values

Use <xref:System.Linq.Enumerable.GroupBy*> when the result should contain groups of elements that share a key. Each group is represented by <xref:System.Linq.IGrouping`2>, which exposes the group key and the elements in that group.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="GroupBy":::

Grouping is useful for summaries, reports, and menus. For more information about joins, nested groupings, and provider-specific behavior, see [Language Integrated Query (LINQ)](../../linq/index.md).

## Run a query

Many LINQ operators use *deferred execution*. Deferred execution means operators that return a sequence, such as <xref:System.Linq.Enumerable.Where*>, <xref:System.Linq.Enumerable.Select*>, and <xref:System.Linq.Enumerable.OrderBy*>, don't run when you define them. They build the recipe for producing results. A `foreach` loop is one way to run that recipe:

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="DeferredExecution":::

Other operations run a query immediately. Operators that return a single value, such as <xref:System.Linq.Enumerable.Count*>, <xref:System.Linq.Enumerable.Sum*>, <xref:System.Linq.Enumerable.First*>, and <xref:System.Linq.Enumerable.Any*>, must read the elements when you call them so they can produce that value.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="ImmediateExecution":::

There's no single trigger that runs a query. *Eager evaluation*, also called immediate evaluation, runs the query right away and stores or returns the result. Scalar and aggregate operators such as <xref:System.Linq.Enumerable.Count*>, <xref:System.Linq.Enumerable.Sum*>, <xref:System.Linq.Enumerable.First*>, and <xref:System.Linq.Enumerable.Any*> use eager evaluation. So do <xref:System.Linq.Enumerable.ToList*> and <xref:System.Linq.Enumerable.ToArray*> when you need a snapshot of the current results. For more information about deferred execution, see [Introduction to LINQ Queries](../../linq/get-started/introduction-to-linq-queries.md) in the LINQ documentation.

## Compose queries

Real queries often grow from smaller decisions: start with a shared filter, add a sort for one screen, or apply an optional condition from user input. By composing queries, you can keep each step readable and reuse common parts instead of repeating one large query.

Imagine an app that shows open work items in several places. One view needs all open items, and another view needs only the highest-priority open items. To *compose* a query, start with a base query stored in a variable, then build a more specific query from it. Because execution is deferred, each step describes more of the result. No work happens until you enumerate the final query.

The following example stores the open work items in one query, then reuses that query to find the highest-priority open items:

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="ComposeQuerySyntax":::

You can also compose queries with method syntax. The next example starts with all open items, then conditionally adds another filter before it selects the titles:

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="ComposeMethodSyntax":::

Composition can use either or both *eager evaluation* and *deferred execution*. Materialize a shared intermediate result with <xref:System.Linq.Enumerable.ToList*> or <xref:System.Linq.Enumerable.ToArray*> when you want that part to run once and stay fixed. Then build another deferred query from the cached results for the final output:

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="ComposeWithCaching":::

## Explore LINQ in depth

This article uses in-memory collections to teach LINQ syntax and core operators. For more information about LINQ operators and advanced scenarios, see [Language Integrated Query (LINQ)](../../linq/index.md) in the LINQ section. The LINQ section covers joins, XML, database providers, dynamic queries, and custom operators.

## See also

- [Collections](collections.md)
- [Introduction to LINQ queries](../../linq/get-started/introduction-to-linq-queries.md)
- [Write LINQ queries](../../linq/get-started/write-linq-queries.md)
- [Standard query operators](../../linq/standard-query-operators/index.md)
- [Lambda expressions](../../language-reference/operators/lambda-expressions.md)
- [LINQ and collections](../../linq/how-to-query-collections.md)
