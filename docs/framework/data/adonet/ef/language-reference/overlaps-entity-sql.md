---
title: "OVERLAPS (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 41743e89-79cb-4d7b-8a27-355b45024b61
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# OVERLAPS (Entity SQL)
Determines whether two collections have common elements.  
  
## Syntax  
  
```  
expression OVERLAPS expression  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that returns a collection to compare with the collection returned from another query expression. All expressions must be of the same type or of a common base or derived type as `expression`.  
  
## Return Value  
 `true` if the two collections have common elements; otherwise, `false`.  
  
## Remarks  
 OVERLAPS provides functionally equivalent tothe following:  
  
 `EXISTS ( expression INTERSECT expression )`  
  
 OVERLAPS is one of the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators. All [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators are evaluated from left to right. For precedence information for the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators, see [EXCEPT](../../../../../../docs/framework/data/adonet/ef/language-reference/except-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the OVERLAPS operator to determines whether two collections have a common value. The query is based on the AdventureWorks Sales Model. To compile and run this, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#OVERLAPS](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#overlaps)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
