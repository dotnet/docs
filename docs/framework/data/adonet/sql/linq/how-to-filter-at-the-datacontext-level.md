---
title: "How to: Filter at the DataContext Level"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 15505cd7-0df2-427a-9f86-e0f96f60ee2e
---
# How to: Filter at the DataContext Level
You can filter `EntitySets` at the `DataContext` level. Such filters apply to all queries done with that <xref:System.Data.Linq.DataContext> instance.  
  
## Example  
 In the following example, <xref:System.Data.Linq.DataLoadOptions.AssociateWith%28System.Linq.Expressions.LambdaExpression%29?displayProperty=nameWithType> is used to filter the pre-loaded orders for customers by `ShippedDate`.  
  
 [!code-csharp[DLinqQueryConcepts#10](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#10)]
 [!code-vb[DLinqQueryConcepts#10](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#10)]  
  
## See also
 [Query Concepts](../../../../../../docs/framework/data/adonet/sql/linq/query-concepts.md)
