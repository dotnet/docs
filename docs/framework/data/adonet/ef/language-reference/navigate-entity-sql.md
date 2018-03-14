---
title: "NAVIGATE (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f107f29d-005f-4e39-a898-17f163abb1d0
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# NAVIGATE (Entity SQL)
Navigates over the relationship established between entities.  
  
## Syntax  
  
```  
navigate(instance-expresssion, [relationship-type], [to-end [, from-end] ])  
```  
  
## Arguments  
 `instance-expresssion`  
 An instance of an entity.  
  
 `relationship-type`  
 The type name of the relationship, from the conceptual schema definition language (CSDL) file. The `relationship-type` is qualified as \<namespace>.\<relationship type name>.  
  
 `to`  
 The end of the relationship.  
  
 `from`  
 The beginning of the relationship.  
  
## Return Value  
 If the cardinality of the to end is 1, the return value will be `Ref<T>`. If the cardinality of the to end is n, the return value will be `Collection<Ref<T>>`.  
  
## Remarks  
 Relationships are first-class constructs in the [!INCLUDE[adonet_edm](../../../../../../includes/adonet-edm-md.md)] (EDM). Relationships can be established between two or more entity types, and users can navigate over the relationship from one end (entity) to another. `from` and `to` are conditionally optional when there is no ambiguity in name resolution within the relationship.  
  
 NAVIGATE is valid in O and C space.  
  
 The general form of a navigation construct is the following:  
  
 navigate(`instance-expresssion`, `relationship-type`, [ `to-end` [, `from-end` ] ] )  
  
 For example:  
  
```  
Select o.Id, navigate(o, OrderCustomer, Customer, Order)  
From LOB.Orders as o  
```  
  
 Where OrderCustomer is the `relationship`, and Customer and Order are the `to-end` (customer) and `from-end` (order) of the relationship. If OrderCustomer was a n:1 relationship, then the result type of the navigate expression is Ref\<Customer>.  
  
 The simpler form of this expression is the following:  
  
```  
Select o.Id, navigate(o, OrderCustomer)  
From LOB.Orders as o  
```  
  
 Similarly, in a query of the following form, The navigate expression would produce a Collection<Ref\<Order>>.  
  
```  
Select c.Id, navigate(c, OrderCustomer, Order, Customer)  
From LOB.Customers as c  
```  
  
 The instance-expression must be an entity/ref type.  
  
## Example  
 The following Entity SQL query uses the NAVIGATE operator to navigate over the relationship established between Address and SalesOrderHeader entity types. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#NAVIGATE](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#navigate)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [How to: Navigate Relationships with Navigate Operator](../../../../../../docs/framework/data/adonet/ef/language-reference/navigate-entity-sql.md)
