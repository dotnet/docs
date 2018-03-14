---
title: "DEREF (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4c78e833-b260-453d-9bf4-eb39857dd0fa
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# DEREF (Entity SQL)
Dereferences a reference value and produces the result of that dereference.  
  
## Syntax  
  
```  
SELECT DEREF ( o.expression ) from Table as o;  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that returns a collection.  
  
## Return Value  
 The value of the entity that is referenced.  
  
## Remarks  
 The DEREF operator dereferences a reference value and produces the result of that dereference. For example, if `r` is a reference of type ref\<T>, `Deref``(r)` is an expression of type `T` that yields the entity referenced by `r`. If the reference value is null, or is dangling (that is, the target of the reference does not exist), the result of the DEREF operator is null.  
  
## Example  
 The following [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query uses the DEREF operator to dereference a reference value and produce the result of that dereference. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2.  Pass the following query as an argument to the ExecutePrimitiveTypeQuery method:  
  
 [!code-csharp[DP EntityServices Concepts 2#DEREF](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#deref)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [REF](../../../../../../docs/framework/data/adonet/ef/language-reference/ref-entity-sql.md)  
 [CREATEREF](../../../../../../docs/framework/data/adonet/ef/language-reference/createref-entity-sql.md)  
 [KEY](../../../../../../docs/framework/data/adonet/ef/language-reference/key-entity-sql.md)  
 [Nullable Structured Types](../../../../../../docs/framework/data/adonet/ef/language-reference/nullable-structured-types-entity-sql.md)
