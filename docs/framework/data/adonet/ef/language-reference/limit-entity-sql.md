---
title: "LIMIT (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c22ffede-0a52-44d1-99b9-4a91e651e1b9
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# LIMIT (Entity SQL)
Physical paging can be performed by using LIMIT sub-clause in ORDER BY clause. LIMIT can not be used separately from ORDER BY clause.  
  
## Syntax  
  
```  
[ LIMIT n ]  
```  
  
## Arguments  
 `n`  
 The number of items that will be selected.  
  
 If a LIMIT expression sub-clause is present in an ORDER BY clause, the query will be sorted according to the sort specification and the resulting number of rows will be restricted by the LIMIT expression. For instance, LIMIT 5 will restrict the result set to 5 instances or rows. LIMIT is functionally equivalent to TOP with the exception that LIMIT requires ORDER BY clause to be present. SKIP and LIMIT can be used independently along with ORDER BY clause.  
  
> [!NOTE]
>  An Entity Sql query will be considered invalid if TOP modifier and SKIP sub-clause is present in the same query expression. The query should be rewritten by changing TOP expression to LIMIT expression.  
  
## Example  
 The following Entity SQL query uses the ORDER BY operator with LIMIT to specify the sort order used on objects returned in a SELECT statement. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#LIMIT](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#limit)]  
  
## See Also  
 [ORDER BY](../../../../../../docs/framework/data/adonet/ef/language-reference/order-by-entity-sql.md)  
 [How to: Page Through Query Results](http://msdn.microsoft.com/library/ffc0f920-e7de-42e0-9b12-ef356421d030)  
 [Paging](../../../../../../docs/framework/data/adonet/ef/language-reference/paging-entity-sql.md)  
 [TOP](../../../../../../docs/framework/data/adonet/ef/language-reference/top-entity-sql.md)
