---
title: "Remote vs. Local Execution"
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
ms.assetid: ee50e943-9349-4c84-ab1c-c35d3ada1a9c
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Remote vs. Local Execution
You can decide to execute your queries either remotely (that is, the database engine executes the query against the database) or locally ([!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] executes the query against a local cache).  
  
## Remote Execution  
 Consider the following query:  
  
 [!code-csharp[DLinqQueryConcepts#7](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#7)]
 [!code-vb[DLinqQueryConcepts#7](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#7)]  
  
 If your database has thousands of rows of orders, you do not want to retrieve them all to process a small subset. In [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], the <xref:System.Data.Linq.EntitySet%601> class implements the <xref:System.Linq.IQueryable> interface. This approach makes sure that such queries can be executed remotely. Two major benefits flow from this technique:  
  
-   Unnecessary data is not retrieved.  
  
-   A query executed by the database engine is often more efficient because of the database indexes.  
  
## Local Execution  
 In other situations, you might want to have the complete set of related entities in the local cache. For this purpose, <xref:System.Data.Linq.EntitySet%601> provides the <xref:System.Data.Linq.EntitySet%601.Load%2A> method to explicitly load all the members of the <xref:System.Data.Linq.EntitySet%601>.  
  
 If an <xref:System.Data.Linq.EntitySet%601> is already loaded, subsequent queries are executed locally. This approach helps in two ways:  
  
-   If the complete set must be used locally or multiple times, you can avoid remote queries and associated latencies.  
  
-   The entity can be serialized as a complete entity.  
  
 The following code fragment illustrates how local execution can be obtained:  
  
 [!code-csharp[DLinqQueryConcepts#8](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#8)]
 [!code-vb[DLinqQueryConcepts#8](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#8)]  
  
## Comparison  
 These two capabilities provide a powerful combination of options: remote execution for large collections and local execution for small collections or where the complete collection is needed. You implement remote execution through <xref:System.Linq.IQueryable>, and local execution against an in-memory <xref:System.Collections.Generic.IEnumerable%601> collection. To force local execution (that is, <xref:System.Collections.Generic.IEnumerable%601>), see [Convert a Type to a Generic IEnumerable](../../../../../../docs/framework/data/adonet/sql/linq/convert-a-type-to-a-generic-ienumerable.md).  
  
### Queries Against Unordered Sets  
 Note the important difference between a local collection that implements <xref:System.Collections.Generic.List%601> and a collection that provides remote queries executed against *unordered sets* in a relational database. <xref:System.Collections.Generic.List%601> methods such as those that use index values require list semantics, which typically cannot be obtained through a remote query against an unordered set. For this reason, such methods implicitly load the <xref:System.Data.Linq.EntitySet%601> to allow local execution.  
  
## See Also  
 [Query Concepts](../../../../../../docs/framework/data/adonet/sql/linq/query-concepts.md)
