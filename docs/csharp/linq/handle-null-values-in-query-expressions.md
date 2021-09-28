---
title: Handle null values in query expressions (LINQ in C#)
description: Learn how to handle null values in LINQ query expressions in C#.
ms.date: 04/29/2021
ms.assetid: ac63ae8b-724d-4251-9334-528f4e884ae7
---
# Handle null values in query expressions

This example shows how to handle possible null values in source collections. An object collection such as an <xref:System.Collections.Generic.IEnumerable%601> can contain elements whose value is [null](../language-reference/keywords/null.md). If a source collection is `null` or contains an element whose value is `null`, and your query doesn't handle `null` values, a <xref:System.NullReferenceException> will be thrown when you execute the query.

You can code defensively to avoid a null reference exception as shown in the following example:

[!code-csharp[csProgGuideLINQ#82](~/samples/snippets/csharp/concepts/linq/how-to-handle-null-values-in-query-expressions_1.cs)]

In the previous example, the `where` clause filters out all null elements in the categories sequence. This technique is independent of the null check in the join clause. The conditional expression with null in this example works because `Products.CategoryID` is of type `int?`, which is shorthand for `Nullable<int>`.

In a join clause, if only one of the comparison keys is a nullable value type, you can cast the other to a nullable value type in the query expression. In the following example, assume that `EmployeeID` is a column that contains values of type `int?`:

[!code-csharp[csProgGuideLINQ#83](~/samples/snippets/csharp/concepts/linq/how-to-handle-null-values-in-query-expressions_2.cs)]

In each of the examples, the `equals` query keyword is used. C# 9 adds [pattern matching](../language-reference/operators/patterns.md), which includes patterns for `is null` and `is not null`. These patterns aren't recommended in LINQ queries because query providers may not interpret the new C# syntax correctly. A query provider is a library that translates C# query expressions into a native data format, such as Entity Framework Core. Query providers implement the <xref:System.Linq.IQueryProvider?displayProperty=nameWithType> interface to create data sources that implement the <xref:System.Linq.IQueryable%601?displayProperty=nameWithType> interface.

## See also

- <xref:System.Nullable%601>
- [Language Integrated Query (LINQ)](index.md)
- [Nullable value types](../language-reference/builtin-types/nullable-value-types.md)
