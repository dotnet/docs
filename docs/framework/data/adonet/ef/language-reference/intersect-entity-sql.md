---
title: "INTERSECT (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 93c6fe33-f341-4b52-911e-adf503891951
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# INTERSECT (Entity SQL)
Returns a collection of any distinct values that are returned by both the query expressions on the left and right sides of the INTERSECT operand. All expressions must be of the same type or of a common base or derived type as `expression`.  
  
## Syntax  
  
```  
expression INTERSECT expression  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that returns a collection to compare with the collection returned from another query expression.  
  
## Return Value  
 A collection of the same type or of a common base or derived type as `expression`.  
  
## Remarks  
 INTERSECT is one of the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators. All [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators are evaluated from left to right. For precedence information for the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators, see [EXCEPT](../../../../../../docs/framework/data/adonet/ef/language-reference/except-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the INTERSECT operator to return a collection of any distinct values that are returned by both the query expressions on the left and right sides of the INTERSECT operand. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#INTERSECT](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#intersect)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
