---
title: "- (Negative) (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 208e54ef-4741-4ec5-89d6-6ff700863cb0
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# - (Negative) (Entity SQL)
Returns the negative of the value of a numeric expression.  
  
## Syntax  
  
```  
- expression  
```  
  
## Arguments  
 `expression`  
 Any valid expression of any one of the numeric data types.  
  
## Result Types  
 The data type of `expression`.  
  
## Remarks  
 If `expression` is an unsigned type, the result type will be the signed type that most closely relates to the type of `expression`. For example, if `expression` is of type Byte, a value of type Int16 will be returned.  
  
## Example  
 The following Entity SQL query uses the - arithmetic operator to return the negative of the value of a numeric expression. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#NEGATIVE](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#negative)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
