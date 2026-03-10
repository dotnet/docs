---
description: "select clause - C# Reference"
title: "select clause"
ms.date: 01/22/2026
f1_keywords: 
  - "select_CSharpKeyword"
  - "select"
helpviewer_keywords: 
  - "select keyword [C#]"
  - "select clause [C#]"
---
# select clause (C# Reference)

In a query expression, the `select` clause specifies the type of values that the query produces when it runs. The result comes from evaluating all the previous clauses and any expressions in the `select` clause itself. A query expression must end with either a `select` clause or a [group](group-clause.md) clause.

The following example shows a simple `select` clause in a query expression.

:::code language="csharp" source="./snippets/select.cs" id="8":::

The type of the sequence that the `select` clause produces determines the type of the query variable `queryHighScores`. In the simplest case, the `select` clause just specifies the range variable. This approach makes the returned sequence contain elements of the same type as the data source. For more information, see [Type Relationships in LINQ Query Operations](../../linq/get-started/type-relationships-in-linq-query-operations.md). However, the `select` clause also provides a powerful mechanism for transforming (or *projecting*) source data into new types. For more information, see [Data Transformations with LINQ (C#)](../../linq/standard-query-operators/index.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The following example shows all the different forms that a `select` clause can take. In each query, note the relationship between the `select` clause and the type of the *query variable* (`studentQuery1`, `studentQuery2`, and so on).

:::code language="csharp" source="./snippets/select.cs" id="9":::

As shown in `studentQuery8` in the previous example, sometimes you want the elements of the returned sequence to contain only a subset of the properties of the source elements. By keeping the returned sequence as small as possible, you reduce the memory requirements and increase the speed of the execution of the query. You can accomplish this goal by creating an anonymous type in the `select` clause and using an object initializer to initialize it with the appropriate properties from the source element. For an example of how to do this, see [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md).

At compile time, the `select` clause is translated to a method call to the <xref:System.Linq.Enumerable.Select%2A> standard query operator.

## See also

- [Query Keywords (LINQ)](query-keywords.md)
- [from clause](from-clause.md)
- [partial (Method) (C# Reference)](partial-member.md)
- [Anonymous Types](../../fundamentals/types/anonymous-types.md)
- [LINQ in C#](../../linq/index.md)
