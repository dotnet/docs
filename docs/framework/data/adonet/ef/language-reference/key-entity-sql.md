---
title: "KEY (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cbaa97a8-c89c-4460-8c74-00474695789f
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# KEY (Entity SQL)
Extracts the key of a reference or of an entity expression.  
  
## Syntax  
  
```  
KEY(createref_expression)  
```  
  
## Remarks  
 An entity key contains the key values in the correct order of the specified entity or entity reference. Because multiple entity sets can be based on the same type, the same key might appear in each entity set. To get a unique reference, use `REF`. The return type of the KEY operator is a row type that includes one field for each key of the entity, in the same order.  
  
 In the following example, the key operator is passed a reference to the BadOrder entity, and returns the key portion of that reference. In this case, a record type with exactly one field corresponding to the `Id` property.  
  
```  
select Key( CreateRef(LOB.BadOrders, row(o.Id)) )   
from LOB.Orders as o  
```  
  
## Example  
 The following Entity SQL query uses the KEY operator to extract the key portion of an expression with type reference. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#KEY](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#key)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [CREATEREF](../../../../../../docs/framework/data/adonet/ef/language-reference/createref-entity-sql.md)  
 [REF](../../../../../../docs/framework/data/adonet/ef/language-reference/ref-entity-sql.md)  
 [DEREF](../../../../../../docs/framework/data/adonet/ef/language-reference/deref-entity-sql.md)
