---
description: "Learn more about: Find the Minimum Value in a Numeric Sequence"
title: "Find the Minimum Value in a Numeric Sequence"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 78203093-f242-4572-9b31-9495b10926aa
---
# Find the Minimum Value in a Numeric Sequence

Use the <xref:System.Linq.Enumerable.Min%2A> operator to return the minimum value from a sequence of numeric values.

## Example 1

 The following example finds the lowest unit price of any product.

 If you run this query against the Northwind sample database, the output is: `2.5000`.

 [!code-csharp[DLinqQueryExamples#9](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#9)]
 [!code-vb[DLinqQueryExamples#9](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#9)]

## Example 2

 The following example finds the lowest freight amount for any order.

 If you run this query against the Northwind sample database, the output is: `0.0200`.

 [!code-csharp[DLinqQueryExamples#10](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#10)]
 [!code-vb[DLinqQueryExamples#10](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#10)]

## Example 3

 The following example uses Min to find the `Products` that have the lowest unit price in each category. The output is arranged by category.

 [!code-csharp[DLinqQueryExamples#11](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#11)]
 [!code-vb[DLinqQueryExamples#11](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#11)]

 If you run the previous query against the Northwind sample database, your results will resemble the following:

 `1`

 `Guaraná Fantástica`

 `2`

 `Aniseed Syrup`

 `3`

 `Teatime Chocolate Biscuits`

 `4`

 `Geitost`

 `5`

 `Filo Mix`

 `6`

 `Tourtière`

 `7`

 `Longlife Tofu`

 `8`

 `Konbu`

## See also

- [Aggregate Queries](aggregate-queries.md)
- [Downloading Sample Databases](downloading-sample-databases.md)
