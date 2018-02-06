---
title: "Return the Set Difference Between Two Sequences"
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
ms.assetid: 62efb546-c898-408f-af21-36e7c6fed217
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Return the Set Difference Between Two Sequences
Use the <xref:System.Linq.Queryable.Except%2A> operator to return the set difference between two sequences.  
  
## Example  
 This example uses <xref:System.Linq.Queryable.Except%2A> to return a sequence of all countries in which `Customers` live but in which no `Employees` live.  
  
 [!code-csharp[DLinqQueryExamples#41](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#41)]
 [!code-vb[DLinqQueryExamples#41](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#41)]  
  
 In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], the <xref:System.Linq.Queryable.Except%2A> operation is well defined only on sets. The semantics for multisets is undefined.  
  
## See Also  
 [Query Examples](../../../../../../docs/framework/data/adonet/sql/linq/query-examples.md)  
 [Standard Query Operator Translation](../../../../../../docs/framework/data/adonet/sql/linq/standard-query-operator-translation.md)
