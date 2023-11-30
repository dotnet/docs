---
title: Perform custom join operations (LINQ in C#)
description: Learn how to perform custom LINQ join operations in C#.
ms.date: 12/01/2016
ms.assetid: 56a2a4a5-7299-497d-b3c3-23c848678911
---
# Perform custom join operations

This example shows how to perform join operations that aren't possible with the `join` clause. In a query expression, the `join` clause is limited to, and optimized for, equijoins, which are by far the most common type of join operation. When performing an equijoin, you will probably always get the best performance by using the `join` clause.

However, the `join` clause cannot be used in the following cases:

- When the join is predicated on an expression of inequality (a non-equijoin).

- When the join is predicated on more than one expression of equality or inequality.

- When you have to introduce a temporary range variable for the right side (inner) sequence before the join operation.

 To perform joins that aren't equijoins, you can use multiple `from` clauses to introduce each data source independently. You then apply a predicate expression in a `where` clause to the range variable for each source. The expression also can take the form of a method call.

> [!NOTE]
> Don't confuse this kind of custom join operation with the use of multiple `from` clauses to access inner collections. For more information, see [join clause](../language-reference/keywords/join-clause.md).

## Cross-join

> [!NOTE]
> This example and the one after use the `Product` and `Category` definitions from [Order the results of a join clause](order-the-results-of-a-join-clause.md).

This query shows a simple cross join. Cross joins must be used with caution because they can produce very large result sets. However, they can be useful in some scenarios for creating source sequences against which additional queries are run.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/CustomJoins.cs" id="cross_join":::

## Non-equijoin

This query produces a sequence of all the products whose category ID is listed in the category list on the left side. Note the use of the `let` clause and the `Contains` method to create a temporary array. It also is possible to create the array before the query and eliminate the first `from` clause.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/CustomJoins.cs" id="non_equijoin":::

## Merge CSV files

In the following example, the query must join two sequences based on matching keys that, in the case of the inner (right side) sequence, cannot be obtained prior to the join clause itself. If this join were performed with a `join` clause, then the `Split` method would have to be called for each element. The use of multiple `from` clauses enables the query to avoid the overhead of the repeated method call. However, since `join` is optimized, in this particular case it might still be faster than using multiple `from` clauses. The results will vary depending primarily on how expensive the method call is.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/CustomJoins.cs" id="merge_csv_files":::

Note that `queryNamesScores`, containing the merged data sources, in the above example is using a named type. You could use `var` instead of an explicit type for the query.
<br/>Also, the `students` variable is optional to create. This good practice of storing the newly created `Student` objects in memory allows for faster access in future queries.

## See also

- [Language Integrated Query (LINQ)](index.md)
- [join clause](../language-reference/keywords/join-clause.md)
- [Order the results of a join clause](order-the-results-of-a-join-clause.md)
