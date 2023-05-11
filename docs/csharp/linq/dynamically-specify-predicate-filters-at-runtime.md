---
title: Dynamically specify predicate filters at run time (LINQ in C#)
description: Learn how to dynamically specify predicate filters at run time using LINQ in C#.
ms.date: 12/01/2016
ms.assetid: 90238470-0767-497c-916c-52d0d16845e0
---
# Dynamically specify predicate filters at run time

In some cases, you don't know until run time how many predicates you have to apply to source elements in the `where` clause. One way to dynamically specify multiple predicate filters is to use the <xref:System.Linq.Enumerable.Contains%2A> method, as shown in the following example. The query will return different results based on the value of `id` when the query is executed.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/RuntimeFiltering.cs" id="runtime_filtering_1":::

## Using different queries at runtime

You can use control flow statements, such as `if... else` or `switch`, to select among predetermined alternative queries. In the following example, `studentQuery` uses a different `where` clause if the runtime value of `oddYear` is `true` or `false`.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/RuntimeFiltering.cs" id="runtime_filtering_2":::

## See also

- [Language Integrated Query (LINQ)](index.md)
- [where clause](../language-reference/keywords/where-clause.md)
- [Querying based on runtime state](../advanced-topics/expression-trees/debugview-syntax.md)
