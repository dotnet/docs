---
description: "Learn more about: Return the First Element in a Sequence"
title: "Return the First Element in a Sequence"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: ccdc3777-b2c2-44e3-a627-abef8d79a555
---
# Return the First Element in a Sequence

Use the <xref:System.Linq.Enumerable.First%2A> operator to return the first element in a sequence. Queries that use <xref:System.Linq.Enumerable.First%2A> are executed immediately.  
  
> [!NOTE]
> [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support the <xref:System.Linq.Enumerable.Last%2A> operator.  
  
## Example 1

 The following code finds the first `Shipper` in a table:  
  
 If you run this query against the Northwind sample database, the results are  
  
 `ID = 1, Company = Speedy Express`.  
  
 [!code-csharp[DLinqQueryExamples#14](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#14)]
 [!code-vb[DLinqQueryExamples#14](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#14)]  
  
## Example 2  

 The following code finds the single `Customer` that has the `CustomerID` BONAP.  
  
 If you run this query against the Northwind sample database, the results are `ID = BONAP, Contact = Laurence Lebihan`.  
  
 [!code-csharp[DLinqQueryExamples#15](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#15)]
 [!code-vb[DLinqQueryExamples#15](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#15)]  
  
## See also

- [Query Examples](query-examples.md)
- [Downloading Sample Databases](downloading-sample-databases.md)
