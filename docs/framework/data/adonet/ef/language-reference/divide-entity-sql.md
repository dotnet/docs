---
title: "- (Divide) (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ef48c368-f3ed-4275-8ada-4e9649781262
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# / (Divide) (Entity SQL)
Divides one number by another.  
  
## Syntax  
  
```  
dividend / divisor  
```  
  
## Arguments  
 `dividend`  
 The numeric expression to divide. `dividend` is any valid expression of any one of the numeric data types.  
  
 `divisor`  
 The numeric expression to divide the dividend by. `divisor` is any valid expression of any one of the numeric data types.  
  
## Result Types  
 The data type that results from the implicit type promotion of the two arguments. For more information about implicit type promotion, see [Type System](../../../../../../docs/framework/data/adonet/ef/language-reference/type-system-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the / arithmetic operator to divide one numer by another. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#DIVIDE](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#divide)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
