---
description: "Learn more about: Find the Maximum Value in a Numeric Sequence"
title: "Find the Maximum Value in a Numeric Sequence"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 70d7c058-0280-4815-a008-6f290093591a
---
# Find the Maximum Value in a Numeric Sequence

Use the <xref:System.Linq.Enumerable.Max%2A> operator to find the highest value in a sequence of numeric values.

## Example 1

 The following example finds the latest date of hire for any employee.

 If you run this query against the sample Northwind database, the output is: `11/15/1994 12:00:00 AM`.

 [!code-csharp[DLinqQueryExamples#6](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#6)]
 [!code-vb[DLinqQueryExamples#6](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#6)]

## Example 2

 The following example finds the most units in stock for any product.

 If you run this example against the sample Northwind database, the output is: `125`.

 [!code-csharp[DLinqQueryExamples#7](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#7)]
 [!code-vb[DLinqQueryExamples#7](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#7)]

## Example 3

 The following example uses Max to find the `Products` that have the highest unit price in each category. The output then lists the results by category.

 [!code-csharp[DLinqQueryExamples#8](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#8)]
 [!code-vb[DLinqQueryExamples#8](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#8)]

 If you run the previous query against the Northwind sample database, your results will resemble the following:

 `1`

 `Côte de Blaye`

 `2`

 `Vegie-spread`

 `3`

 `Sir Rodney's Marmalade`

 `4`

 `Raclette Courdavault`

 `5`

 `Gnocchi di nonna Alice`

 `6`

 `Thüringer Rostbratwurst`

 `7`

 `Manjimup Dried Apples`

 `8`

 `Carnarvon Tigers`

## See also

- [Aggregate Queries](aggregate-queries.md)
- [Downloading Sample Databases](downloading-sample-databases.md)
