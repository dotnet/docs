---
title: "(Modulo) (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 243ddc4f-3c4e-41e1-a3ef-4ed39e36248b
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# (Modulo) (Entity SQL)
Returns the remainder of one expression divided by another.  
  
## Syntax  
  
```  
dividend % divisor  
```  
  
## Arguments  
 `dividend`  
 The numeric expression to divide. `dividend` is any valid expression of any one of the numeric data types.  
  
 `divisor`  
 The numeric expression to divide the dividend by. `divisor` is any valid expression of any one of the numeric data types.  
  
## Result Types  
 Edm.Int32  
  
## Example  
 The following Entity SQL query uses the % arithmetic operator to return the remainder of one expression divided by another. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#MODULO](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#modulo)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
