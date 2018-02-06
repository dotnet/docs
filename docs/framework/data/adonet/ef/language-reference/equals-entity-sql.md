---
title: "= (Equals) (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 948eb588-7080-4046-bb48-633b007393bf
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# = (Equals) (Entity SQL)
Compares the equality of two expressions.  
  
## Syntax  
  
```  
expression = expression  
or   
expression == expression  
```  
  
## Arguments  
 `expression`  
 Any valid expression. Both expressions must have implicitly convertible data types.  
  
## Result Types  
 `true` if the left expression is equal to the right expression; otherwise, `false`.  
  
## Remarks  
 The == operator is equivalent to =.  
  
## Example  
 The following Entity SQL query uses = comparison operator to compare the equality of two expressions. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#EQUALS](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#equals)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
