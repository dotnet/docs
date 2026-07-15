---
title: "LINQ queries in C#"
description: Query collections with LINQ by using query syntax, method syntax, common operators, and lambda expressions.
ms.date: 07/15/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# LINQ queries

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For a deeper tour of providers, operators, and advanced scenarios, see the [Language Integrated Query (LINQ)](../../linq/index.md) section.
>
> **Coming from another language?** LINQ query syntax reads like a SQL-style query written inside C#. LINQ method syntax reads like chained collection operations in JavaScript, Java streams, or Python pipelines. Both forms describe the same query.

*Language Integrated Query (LINQ)* is the C# feature set for querying data with C# syntax. A *query* describes which data to read and how to shape the result. A query reads from a *data source*. A data source can be an in-memory collection, such as an array or <xref:System.Collections.Generic.List`1>, or an external source, such as a database or XML, exposed through a LINQ provider. A *LINQ provider* is a library that connects LINQ syntax to a specific kind of data source. A *sequence* is an ordered set of elements represented by <xref:System.Collections.Generic.IEnumerable`1>. This article uses in-memory collections for its examples; for provider-based queries, see the [Language Integrated Query (LINQ)](../../linq/index.md) section.

## Query data with LINQ

The examples in this article read [in-memory collections](collections.md) such as arrays and <xref:System.Collections.Generic.List`1>. A query usually has three parts: get the data source, describe the result, and enumerate the result. To *enumerate* a sequence means to read its elements one at a time, often with `foreach`.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="QuerySyntax":::

The query describes the result before the `foreach` loop reads it. That separation helps you name the data source, the filtering rule, and the result shape clearly.

## Write the same query with method syntax

*Query syntax* uses clauses such as `from`, `where`, `orderby`, and `select`. *Method syntax* calls LINQ methods directly. For in-memory sequences, the standard LINQ methods are the built-in <xref:System.Linq.Enumerable> methods for filtering, projection, sorting, grouping, and related operations.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="MethodSyntax":::

Method syntax is also called *fluent syntax* because each call returns a result that the next call can use. Many queries can use either form. Use the form that makes the query easiest to read.

## Use lambda expressions in LINQ

A *lambda expression* is an anonymous function that you can pass as an argument. LINQ method syntax commonly uses lambda expressions to say what each operator should do with each element.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="LambdaExpressions":::

In `name => name.Length == 3`, `name` is the input element and `name.Length == 3` is the Boolean expression that decides whether the element stays in the result. For more information, see [Lambda expressions](../../language-reference/operators/lambda-expressions.md).

## Filter, map, reduce, sort, and group

LINQ includes operators that match common functional operations. A *filter* keeps only elements that match a condition; in C#, use <xref:System.Linq.Enumerable.Where*> to filter. A *map* transforms each element into a new value; C# calls this operation a *projection*, and you use <xref:System.Linq.Enumerable.Select*> for it. A *reduce* combines all elements into a single value, such as a sum or count; in C#, use aggregation methods such as <xref:System.Linq.Enumerable.Aggregate*>, <xref:System.Linq.Enumerable.Sum*>, or <xref:System.Linq.Enumerable.Count*>. Use <xref:System.Linq.Enumerable.OrderBy*> to sort elements. These operators are in the <xref:System.Linq> namespace and work with sequences such as <xref:System.Collections.Generic.IEnumerable`1>.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="CommonOperators":::

A *projection* creates a result value from each input element. In the previous example, the projection creates strings that combine a work item name and its priority.

### Group related values

Use <xref:System.Linq.Enumerable.GroupBy*> when the result should contain groups of elements that share a key. Each group is represented by <xref:System.Linq.IGrouping`2>, which exposes the group key and the elements in that group.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="GroupBy":::

Grouping is useful for summaries, reports, and menus. For joins, nested groupings, and provider-specific behavior, see the [Language Integrated Query (LINQ)](../../linq/index.md) section.

## Run a query by enumerating it

Many LINQ operators use *deferred execution*. Deferred execution means the query holds the recipe for producing results until a `foreach` loop, <xref:System.Linq.Enumerable.ToList*>, or <xref:System.Linq.Enumerable.ToArray*> runs it.

:::code language="csharp" source="./snippets/linq-statements/Program.cs" id="DeferredExecution":::

If you need a snapshot of the current results, call <xref:System.Linq.Enumerable.ToList*> or <xref:System.Linq.Enumerable.ToArray*> and store that result. This call triggers *eager evaluation*, which runs the query immediately and stores the results instead of deferring work until later enumeration. For more detail, see [Introduction to LINQ queries](../../linq/get-started/introduction-to-linq-queries.md).

## Go deeper with LINQ

This article uses in-memory collections to teach LINQ syntax and core operators. The LINQ section covers more operators and advanced scenarios, including joins, XML, database providers, dynamic queries, and custom operators.

## See also

- [Collections](collections.md)
- [Language Integrated Query (LINQ)](../../linq/index.md)
- [Introduction to LINQ queries](../../linq/get-started/introduction-to-linq-queries.md)
- [Write LINQ queries](../../linq/get-started/write-linq-queries.md)
- [Standard query operators](../../linq/standard-query-operators/index.md)
- [Lambda expressions](../../language-reference/operators/lambda-expressions.md)
- [LINQ and collections](../../linq/how-to-query-collections.md)
