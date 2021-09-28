---
description: "Learn more about: Sort Elements in a Sequence"
title: "Sort Elements in a Sequence"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: d59b93a9-50c8-4770-a114-d902f6a0ea76
---
# Sort Elements in a Sequence

Use the <xref:System.Linq.Enumerable.OrderBy%2A> operator to sort a sequence according to one or more keys.

> [!NOTE]
> [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] is designed to support ordering by simple primitive types, such as `string`, `int`, and so on. It does not support ordering for complex multi-valued classes, such as anonymous types. It also does not support `byte` datatypes.

## Example 1

 The following example sorts `Employees` by date of hire.

 [!code-csharp[DLinqQueryExamples#20](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#20)]
 [!code-vb[DLinqQueryExamples#20](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#20)]

## Example 2

 The following example uses `where` to sort `Orders` shipped to `London` by freight.

 [!code-csharp[DLinqQueryExamples#21](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#21)]
 [!code-vb[DLinqQueryExamples#21](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#21)]

## Example 3

 The following example sorts `Products` by unit price from highest to lowest.

 [!code-csharp[DLinqQueryExamples#22](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#22)]
 [!code-vb[DLinqQueryExamples#22](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#22)]

## Example 4

 The following example uses a compound `OrderBy` to sort `Customers` by city and then by contact name.

 [!code-csharp[DLinqQueryExamples#24](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#24)]
 [!code-vb[DLinqQueryExamples#24](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#24)]

## Example 5

 The following example sorts Orders from `EmployeeID 1` by `ShipCountry`, and then by highest to lowest freight.

 [!code-csharp[DLinqQueryExamples#25](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#25)]
 [!code-vb[DLinqQueryExamples#25](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#25)]

## Example 6

 The following example combines <xref:System.Linq.Enumerable.OrderBy%2A>, <xref:System.Linq.Enumerable.Max%2A>, and <xref:System.Linq.Enumerable.GroupBy%2A> operators to find the `Products` that have the highest unit price in each category, and then sorts the group by category id.

 [!code-csharp[DLinqQueryExamples#26](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#26)]
 [!code-vb[DLinqQueryExamples#26](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#26)]

 If you run the previous query against the Northwind sample database, the results will resemble the following:

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

- [Query Examples](query-examples.md)
- [Downloading Sample Databases](downloading-sample-databases.md)
