---
title: "!= (Not Equal To) (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3b4a02ad-ddfc-4c42-8dfa-676234461312
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# != (Not Equal To) (Entity SQL)
Compares two expressions to determine whether the left expression is not equal to the right expression. The != (Not Equal To) operator is functionally equivalent to the <> operator.  
  
## Syntax  
  
```  
expression != expression  
or  
expression <> expression  
```  
  
## Arguments  
 `expression`  
 Any valid expression. Both expressions must have implicitly convertible data types.  
  
## Result Types  
 `true` if the left expression is not equal to the right expression; otherwise, `false`.  
  
## Example  
 The following Entity SQL query uses the != operator to compare two expressions to determine whether the left expression is not equal to the right expression. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#NOT_EQUALS](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#not_equals)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
