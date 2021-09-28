---
description: "Learn more about: Order By Clause (Visual Basic)"
title: "Order By Clause"
ms.date: 07/20/2015
f1_keywords:
  - "vb.QueryOrderBy"
  - "vb.QueryAscending"
  - "vb.QueryDescending"
helpviewer_keywords:
  - "queries [Visual Basic], Order By"
  - "Order By clause [Visual Basic]"
  - "Order By statement [Visual Basic]"
ms.assetid: fa911282-6b81-44c7-acfa-46b5bb93df75
---
# Order By Clause (Visual Basic)

Specifies the sort order for a query result.

## Syntax

```vb
Order By orderExp1 [ Ascending | Descending ] [, orderExp2 [...] ]
```

## Parts

 `orderExp1`
 Required. One or more fields from the current query result that identify how to order the returned values. The field names must be separated by commas (,). You can identify each field as sorted in ascending or descending order by using the `Ascending` or `Descending` keywords. If no `Ascending` or `Descending` keyword is specified, the default sort order is ascending. The sort order fields are given precedence from left to right.

## Remarks

 You can use the `Order By` clause to sort the results of a query. The `Order By` clause can only sort a result based on the range variable for the current scope. For example, the `Select` clause introduces a new scope in a query expression with new iteration variables for that scope. Range variables defined before a `Select` clause in a query are not available after the `Select` clause. Therefore, if you want to order your results by a field that is not available in the `Select` clause, you must put the `Order By` clause before the `Select` clause. One example of when you would have to do this is when you want to sort your query by fields that are not returned as part of the result.

 Ascending and descending order for a field is determined by the implementation of the <xref:System.IComparable> interface for the data type of the field. If the data type does not implement the <xref:System.IComparable> interface, the sort order is ignored.

## Example 1

 The following query expression uses a `From` clause to declare a range variable `book` for the `books` collection. The `Order By` clause sorts the query result by price in ascending order (the default). Books with the same price are sorted by title in ascending order. The `Select` clause selects the `Title` and `Price` properties as the values returned by the query.

 [!code-vb[VbSimpleQuerySamples#24](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#24)]

## Example 2

 The following query expression uses the `Order By` clause to sort the query result by price in descending order. Books with the same price are sorted by title in ascending order.

 [!code-vb[VbSimpleQuerySamples#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#25)]

## Example 3

 The following query expression uses a `Select` clause to select the book title, price, publish date, and author. It then populates the `Title`, `Price`, `PublishDate`, and `Author` fields of the range variable for the new scope. The `Order By` clause orders the new range variable by author name, book title, and then price. Each column is sorted in the default order (ascending).

 [!code-vb[VbSimpleQuerySamples#26](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbSimpleQuerySamples/VB/QuerySamples1.vb#26)]

## See also

- [Introduction to LINQ in Visual Basic](../../programming-guide/language-features/linq/introduction-to-linq.md)
- [Queries](index.md)
- [Select Clause](select-clause.md)
- [From Clause](from-clause.md)
