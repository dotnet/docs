---
title: "CREATEREF (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 489828cf-a335-4449-9360-b0d92eec5481
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# CREATEREF (Entity SQL)
Fabricates references to an entity in an entityset.  
  
## Syntax  
  
```  
CreateRef(entityset_identifier, row_typed_expression)  
```  
  
## Arguments  
 `entityset_identifier`  
 The entityset identifier, not a string literal.  
  
 `row_typed_expression`  
 A row-typed expression that corresponds to the key properties of the entity type.  
  
## Remarks  
 `row_typed_expression` must be structurally equivalent to the key type for the entity. That is, it must have the same number and types of fields in the same order as the entity keys.  
  
 In the example below, Orders and BadOrders are both entitysets of type Order, and Id is assumed to be the single key property of Order. The example illustrates how we may produce a reference to an entity in BadOrders. Note that the reference may be dangling.  That is, the reference may not actually identify a specific entity. In those cases, a `DEREF` operation on that reference returns a null.  
  
```  
select CreateRef(LOB.BadOrders, row(o.Id))   
from LOB.Orders as o   
```  
  
## Example  
 The following Entity SQL query uses the CREATEREF operator to fabricate references to an entity in an entity set. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#CREATEREF](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#createref)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [DEREF](../../../../../../docs/framework/data/adonet/ef/language-reference/deref-entity-sql.md)  
 [KEY](../../../../../../docs/framework/data/adonet/ef/language-reference/key-entity-sql.md)  
 [REF](../../../../../../docs/framework/data/adonet/ef/language-reference/ref-entity-sql.md)
