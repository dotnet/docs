---
title: "IN (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 51662950-ee01-4857-b7b9-311dd8515966
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# IN (Entity SQL)
Determines whether a value matches any value in a collection.  
  
## Syntax  
  
```  
value [ NOT ] IN expression  
```  
  
## Arguments  
 `value`  
 Any valid expression that returns the value to match.  
  
 [ NOT ]  
 Specifies that the `Boolean` result of IN be negated.  
  
 `expression`  
 Any valid expression that returns the collection to test for a match. All expressions must be of the same type or of a common base or derived type as `value`.  
  
## Return Value  
 `true` if the value is found in the collection; null if the value is null or the collection is null; otherwise, `false`. Using NOT IN negates the results of IN.  
  
## Example  
 The following Entity SQL query uses the IN operator to determine whether a value matches any value in a collection. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#IN](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#in)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
