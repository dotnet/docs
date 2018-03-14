---
title: "MULTISET (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: eb90a377-e47a-43a5-b308-e993b6d611e6
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# MULTISET (Entity SQL)
Creates an instance of a multiset from a list of values. All the values in the MULTISET constructor must be of a compatible type `T`. Empty multiset constructors are not allowed.  
  
## Syntax  
  
```  
MULTISET ( expression [{, expression }] )  
or  
{ expression [{, expression }] }  
```  
  
## Arguments  
 `expression`  
 Any valid list of values.  
  
## Return Value  
 A collection of type MULTISET\<T>.  
  
## Remarks  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides three kinds of constructors: row constructors, object constructors, and multiset (or collection) constructors. For more information, see [Constructing Types](../../../../../../docs/framework/data/adonet/ef/language-reference/constructing-types-entity-sql.md).  
  
 The multiset constructor creates an instance of a multiset from a list of values. All the values in the constructor must be of a compatible type.  
  
 For example, the following expression creates a multiset of integers.  
  
 `MULTISET(1, 2, 3)`  
  
 `{1, 2, 3}`  
  
> [!NOTE]
>  Nested multiset literals are only supported when a wrapping mutiset has a single multiset element; for example, `{{1, 2, 3}}`. When the wrapping multiset has multiple multiset elements (for example, `{{1, 2}, {3, 4}}`), nested multiset literals are not supported.  
  
## Example  
 The following Entity SQL query uses the MULTISET operator to create an instance of a multiset from a list of values. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#MULTISET](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#multiset)]  
  
## See Also  
 [Constructing Types](../../../../../../docs/framework/data/adonet/ef/language-reference/constructing-types-entity-sql.md)  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
