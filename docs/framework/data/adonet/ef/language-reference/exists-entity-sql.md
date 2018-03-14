---
title: "EXISTS (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d28ead43-4afb-4bdc-af64-efd2e05005d7
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# EXISTS (Entity SQL)
Determines if a collection is empty.  
  
## Syntax  
  
```  
[NOT] EXISTS ( expression )  
```  
  
## Arguments  
 `expression`  
 Any valid expression that returns a collection.  
  
 NOT  
 Specifies that the result of EXISTS be negated.  
  
## Return Value  
 `true` if the collection is not empty; otherwise, `false`.  
  
## Remarks  
 EXISTS is one of the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators. All [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators are evaluated from left to right. For precedence information for the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators, see [EXCEPT](../../../../../../docs/framework/data/adonet/ef/language-reference/except-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the EXISTS operator to determine whether the collection is empty. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#EXISTS](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#exists)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
