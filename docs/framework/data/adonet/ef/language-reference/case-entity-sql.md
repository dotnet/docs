---
title: "CASE (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 26a47873-e87d-4ba2-9e2c-3787c21efe89
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# CASE (Entity SQL)
Evaluates a set of `Boolean` expressions to determine the result.  
  
## Syntax  
  
```  
CASE  
     WHEN Boolean_expression THEN result_expression   
    [ ...n ]   
     [   
    ELSE else_result_expression   
     ]   
END  
```  
  
## Arguments  
 `n`  
 Is a placeholder that indicates that multiple WHEN `Boolean_expression` THEN `result_expression` clauses can be used.  
  
 THEN `result_expression`  
 Is the expression returned when `Boolean_expression` evaluates to `true`. `result expression` is any valid expression.  
  
 ELSE `else_result_expression`  
 Is the expression returned if no comparison operation evaluates to `true`. If this argument is omitted and no comparison operation evaluates to `true`, CASE returns null. `else_result_expression` is any valid expression. The data types of `else_result_expression` and any `result_expression` must be the same or must be an implicit conversion.  
  
 WHEN `Boolean_expression`  
 Is the `Boolean` expression evaluated when the searched CASE format is used. `Boolean_expression` is any valid `Boolean` expression.  
  
## Return Value  
 Returns the highest precedence type from the set of types in the `result_expression` and the optional `else_result_expression`.  
  
## Remarks  
 The [!INCLUDE[esql](../../../../../../includes/esql-md.md)] case expression resembles the [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] case expression. You use the case expression to make a series of conditional tests to determine which expression will yield the appropriate result. This form of the case expression applies to a series of one or more `Boolean` expressions to determine the correct resulting expression.  
  
 The CASE function evaluates `Boolean_expression` for each WHEN clause in the order specified, and returns `result_expression` of the first `Boolean_expression` that evaluates to `true`. The remaining expressions are not evaluated. If no `Boolean_expression` evaluates to `true`, the Database Engine returns the `else_result_expression` if an ELSE clause is specified, or a null value if no ELSE clause is specified.  
  
 A CASE statement cannot return a multiset.  
  
## Example  
 The following Entity SQL query uses the CASE expression to evaluate a set of `Boolean` expressions in order to determine the result. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2.  Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#CASE_WHEN_THEN_ELSE](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#case_when_then_else)]  
  
## See Also  
 [THEN](../../../../../../docs/framework/data/adonet/ef/language-reference/then-entity-sql.md)  
 [SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md)  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
