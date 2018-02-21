---
title: "Return the First Element in a Sequence"
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
ms.assetid: ccdc3777-b2c2-44e3-a627-abef8d79a555
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Return the First Element in a Sequence
Use the <xref:System.Linq.Enumerable.First%2A> operator to return the first element in a sequence. Queries that use <xref:System.Linq.Enumerable.First%2A> are executed immediately.  
  
> [!NOTE]
>  [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support the <xref:System.Linq.Enumerable.Last%2A> operator.  
  
## Example  
 The following code finds the first `Shipper` in a table:  
  
 If you run this query against the Northwind sample database, the results are  
  
 `ID = 1, Company = Speedy Express`.  
  
 [!code-csharp[DLinqQueryExamples#14](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#14)]
 [!code-vb[DLinqQueryExamples#14](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#14)]  
  
## Example  
 The following code finds the single `Customer` that has the `CustomerID` BONAP.  
  
 If you run this query against the Northwind sample database, the results are `ID = BONAP, Contact = Laurence Lebihan`.  
  
 [!code-csharp[DLinqQueryExamples#15](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryExamples/cs/Program.cs#15)]
 [!code-vb[DLinqQueryExamples#15](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryExamples/vb/Module1.vb#15)]  
  
## See Also  
 [Query Examples](../../../../../../docs/framework/data/adonet/sql/linq/query-examples.md)  
 [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md)
