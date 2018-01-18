---
title: "THEN (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 54222642-23c6-4f61-9861-67caca53ac5f
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# THEN (Entity SQL)
The result of a WHEN clause when it evaluates to `true`.  
  
## Syntax  
  
```  
WHEN when_expression THEN then_expression  
```  
  
## Arguments  
 `when_expression`  
 Any valid Boolean expression.  
  
 `then_expression`  
 Any valid query expression that returns a collection.  
  
## Remarks  
 If `when_expression` evaluates to the value `true`, the result is the corresponding `then-expression`. If none of the WHEN conditions are satisfied, the `else-expression` is evaluated. However, if there is no `else-expression`, the result is null.  
  
 For an example, see [CASE](../../../../../../docs/framework/data/adonet/ef/language-reference/case-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the CASE expression to evaluate a set of `Boolean` expressions. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2.  Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#CASE_WHEN_THEN_ELSE](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#case_when_then_else)]  
  
## See Also  
 [CASE](../../../../../../docs/framework/data/adonet/ef/language-reference/case-entity-sql.md)  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
