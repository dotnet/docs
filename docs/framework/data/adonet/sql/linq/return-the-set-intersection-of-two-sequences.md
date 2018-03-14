---
title: "Return the Set Intersection of Two Sequences"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: d09c344e-3548-4944-a3ed-051880e3f5b8
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Return the Set Intersection of Two Sequences
Use the <xref:System.Linq.Queryable.Intersect%2A> operator to return the set intersection of two sequences.  
  
## Example  
 This example uses <xref:System.Linq.Queryable.Intersect%2A> to return a sequence of all countries in which both `Customers` and `Employees` live.  
  
 [!code-csharp[DLinqQueryExamples#42](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#42)]
 [!code-vb[DLinqQueryExamples#42](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#42)]  
  
 In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], the <xref:System.Linq.Queryable.Intersect%2A> operation is well defined only on sets. The semantics for multisets is undefined.  
  
## See Also  
 [Query Examples](../../../../../../docs/framework/data/adonet/sql/linq/query-examples.md)  
 [Standard Query Operator Translation](../../../../../../docs/framework/data/adonet/sql/linq/standard-query-operator-translation.md)
