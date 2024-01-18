---
title: Perform a subquery on a grouping operation (LINQ in C#)
description: How to perform a subquery on a grouping operation using LINQ in C#.
ms.date: 01/23/2024
---
# Perform a subquery on a grouping operation

This article shows two different ways to create a query that orders the source data into groups, and then performs a subquery over each group individually. The basic technique in each example is to group the source elements by using a *continuation* named `newGroup`, and then generating a new subquery against `newGroup`. This subquery is run against each new group that is created by the outer query. Note that in this particular example the final output is not a group, but a flat sequence of anonymous types.

For more information about how to group, see [group clause](../../../language-reference/keywords/group-clause.md).

For more information about continuations, see [into](../../../language-reference/keywords/into.md). The following example uses an in-memory data structure as the data source, but the same principles apply for any kind of LINQ data source.

## Example

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [the overview article](../index.md).

:::code language="csharp" source="../snippets/standard-query-operators/SubqueryOnGroup.cs" id="SubQueryOnGroupQuerySyntax":::

The query in the snippet above can also be written using method syntax. The following code snippet has a semantically equivalent query written using method syntax.

:::code language="csharp" source="../snippets/standard-query-operators/SubqueryOnGroup.cs" id="SubQueryOnGroupMethodSyntax":::
