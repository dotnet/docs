---
description: "where clause - C# Reference"
title: "where clause"
ms.date: 01/22/2026
f1_keywords: 
  - "whereclause_CSharpKeyword"
helpviewer_keywords: 
  - "where keyword [C#]"
  - "where clause [C#]"
---
# where clause (C# Reference)

Use the `where` clause in a query expression to specify which elements from the data source to return. It applies a Boolean condition (*predicate*) to each source element (referenced by the range variable) and returns those elements for which the specified condition is true. A single query expression can contain multiple `where` clauses, and a single clause can contain multiple predicate subexpressions.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

In the following example, the `where` clause filters out all numbers except those that are less than five. If you remove the `where` clause, the query returns all numbers from the data source. The expression `num < 5` is the predicate that the query applies to each element.

:::code language="csharp" source="./snippets/Where.cs" id="5":::

Within a single `where` clause, you can specify as many predicates as necessary by using the [&&](../operators/boolean-logical-operators.md#conditional-logical-and-operator-) and [&#124;&#124;](../operators/boolean-logical-operators.md#conditional-logical-or-operator-) operators. In the following example, the query specifies two predicates in order to select only the even numbers that are less than five.

:::code language="csharp" source="./snippets/Where.cs" id="6":::

A `where` clause can contain one or more methods that return Boolean values. In the following example, the `where` clause uses a method to determine whether the current value of the range variable is even or odd.

:::code language="csharp" source="./snippets/Where.cs" id="7":::

## Remarks

The `where` clause is a filtering mechanism. You can position it almost anywhere in a query expression, except it can't be the first or last clause. A `where` clause can appear either before or after a [group](group-clause.md) clause depending on whether you need to filter the source elements before or after they are grouped.

If you specify a predicate that's not valid for the elements in the data source, the query results in a compile-time error. This error is one benefit of the strong type-checking that LINQ provides.

At compile time, the `where` keyword is converted into a call to the <xref:System.Linq.Enumerable.Where%2A> Standard Query Operator method.

## See also

- [Query Keywords (LINQ)](query-keywords.md)
- [from clause](from-clause.md)
- [select clause](select-clause.md)
- [Filtering Data](../../linq/standard-query-operators/filtering-data.md)
- [LINQ in C#](../../linq/index.md)
