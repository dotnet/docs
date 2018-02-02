---
title: "BETWEEN (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4dcdd754-ae01-4e78-bf28-8a117fb2b73e
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# BETWEEN (Entity SQL)
Determines whether an expression results in a value in a specified range. The [!INCLUDE[esql](../../../../../../includes/esql-md.md)] BETWEEN expression has the same functionality as the Transact-SQL BETWEEN expression.  
  
## Syntax  
  
```  
expression [ NOT ] BETWEEN begin_expression AND end_expression    
```  
  
## Arguments  
 `expression`  
 Any valid expression to test for in the range defined by `begin_expression` and `end_expression`. `expression` must be the same type as both `begin_expression` and `end_expression`.  
  
 `begin_expression`  
 Any valid expression. `begin_expression` must be the same type as both `expression` and `end_expression`. `begin_expression` should be less than `end_expression`, else the return value will be negated.  
  
 `end_expression`  
 Any valid expression. `end_expression` must be the same type as both `expression` and `begin_expression`.  
  
 NOT  
 Specifies that the result of BETWEEN be negated.  
  
 AND  
 Acts as a placeholder that indicates `expression` should be within the range indicated by `begin_expression` and `end_expression`.  
  
## Return Value  
 `true` if `expression` is between the range indicated by `begin_expression` and `end_expression`; otherwise, `false`. `null` will be returned if `expression` is `null` or if `begin_expression` or `end_expression` is `null`.  
  
## Remarks  
 To specify an exclusive range, use the greater than (>) and less than (<) operators instead of BETWEEN.  
  
## Example  
 The following Entity SQL query uses BETWEEN operator to determine whether an expression results in a value in a specified range. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#BETWEEN](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#between)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
