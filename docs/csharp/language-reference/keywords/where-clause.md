---
title: "where clause - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "whereclause_CSharpKeyword"
helpviewer_keywords: 
  - "where keyword [C#]"
  - "where clause [C#]"
ms.assetid: 7f9bf952-7744-4f91-b676-cddb55d107c3
---
# where clause (C# Reference)

The `where` clause is used in a query expression to specify which elements from the data source will be returned in the query expression. It applies a Boolean condition (*predicate*) to each source element (referenced by the range variable) and returns those for which the specified condition is true. A single query expression may contain multiple `where` clauses and a single clause may contain multiple predicate subexpressions.

## Example

In the following example, the `where` clause filters out all numbers except those that are less than five. If you remove the `where` clause, all numbers from the data source would be returned. The expression `num < 5` is the predicate that is applied to each element.

[!code-csharp[cscsrefQueryKeywords#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsCsrefQueryKeywords/CS/Where.cs#5)]

## Example

Within a single `where` clause, you can specify as many predicates as necessary by using the [&&](../operators/conditional-and-operator.md) and [&#124;&#124;](../operators/conditional-or-operator.md) operators. In the following example, the query specifies two predicates in order to select only the even numbers that are less than five.

[!code-csharp[cscsrefQueryKeywords#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsCsrefQueryKeywords/CS/Where.cs#6)]  

## Example

A `where` clause may contain one or more methods that return Boolean values. In the following example, the `where` clause uses a method to determine whether the current value of the range variable is even or odd.

[!code-csharp[cscsrefQueryKeywords#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsCsrefQueryKeywords/CS/Where.cs#7)]

## Remarks

The `where` clause is a filtering mechanism. It can be positioned almost anywhere in a query expression, except it cannot be the first or last clause. A `where` clause may appear either before or after a [group](group-clause.md) clause depending on whether you have to filter the source elements before or after they are grouped.

If a specified predicate is not valid for the elements in the data source, a compile-time error will result. This is one benefit of the strong type-checking provided by [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)].

At compile time the `where` keyword is converted into a call to the <xref:System.Linq.Enumerable.Where%2A> Standard Query Operator method.

## See also

- [Query Keywords (LINQ)](query-keywords.md)
- [from clause](from-clause.md)
- [select clause](select-clause.md)
- [Filtering Data](../../programming-guide/concepts/linq/filtering-data.md)
- [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)
- [Getting Started with LINQ in C#](../../programming-guide/concepts/linq/getting-started-with-linq.md)