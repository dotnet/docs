---
title: "|| (OR) (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8e649648-eb9a-4380-9d74-36e62260628c
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# || (OR) (Entity SQL)
Combines two `Boolean` expressions.  
  
## Syntax  
  
```  
boolean_expression OR boolean_expression  
or   
boolean_expression || boolean_expression  
```  
  
## Arguments  
 `boolean_expression`  
 Any valid expression that returns a `Boolean`.  
  
## Return Value  
 `true` when either of the conditions is `true`; otherwise, `false`.  
  
## Remarks  
 OR is an [!INCLUDE[esql](../../../../../../includes/esql-md.md)] logical operator. It is used to combine two conditions. When more than one logical operator is used in a statement, OR operators are evaluated after AND operators. However, you can change the order of evaluation by using parentheses.  
  
 Double vertical bars (&#124;&#124;) have the same functionality as the OR operator.  
  
 The following table shows possible input values and return types.  
  
||`TRUE`|`FALSE`|`NULL`|  
|-|------------|-------------|------------|  
|`TRUE`|TRUE|TRUE|TRUE|  
|`FALSE`|TRUE|FALSE|NULL|  
|`NULL`|TRUE|NULL|NULL|  
  
## Example  
 The following Entity SQL query uses the OR operator to combine two `Boolean` expressions. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#OR](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#or)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
