---
title: "Retrieving Objects from the Identity Cache"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 96c13903-ccb6-4a0e-ab6a-8ca955ca314d
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Retrieving Objects from the Identity Cache
This topic describes the types of LINQ to SQL queries that return an object from the identity cache that is managed by the <xref:System.Data.Linq.DataContext>.  
  
 In LINQ to SQL, one of the ways in which the <xref:System.Data.Linq.DataContext> manages objects is by logging object identities in an identity cache as queries are executed. In some cases, LINQ to SQL will attempt to retrieve an object from the identity cache before executing a query in the database.  
  
 In general, for a LINQ to SQL query to return an object from the identity cache, the query must be based on the primary key of an object and must return a single object. In particular, the query must be in one of the general forms shown below.  
  
> [!NOTE]
>  Pre-compiled queries will not return objects from the identity cache. For more information about pre-compiled queries, see <xref:System.Data.Linq.CompiledQuery> and [How to: Store and Reuse Queries](../../../../../../docs/framework/data/adonet/sql/linq/how-to-store-and-reuse-queries.md).  
  
 A query must be in one of the following general forms to retrieve an object from the identity cache:  
  
-   <xref:System.Data.Linq.Table%601> `.Function1(` `predicate` `)`  
  
-   <xref:System.Data.Linq.Table%601> `.Function1(` `predicate` `).Function2()`  
  
 In these general forms, `Function1`, `Function2`, and `predicate` are defined as follows.  
  
 `Function1` can be any of the following:  
  
-   <xref:System.Linq.Queryable.Where%2A>  
  
-   <xref:System.Linq.Queryable.First%2A>  
  
-   <xref:System.Linq.Queryable.FirstOrDefault%2A>  
  
-   <xref:System.Linq.Queryable.Single%2A>  
  
-   <xref:System.Linq.Queryable.SingleOrDefault%2A>  
  
 `Function2` can be any of the following:  
  
-   <xref:System.Linq.Queryable.First%2A>  
  
-   <xref:System.Linq.Queryable.FirstOrDefault%2A>  
  
-   <xref:System.Linq.Queryable.Single%2A>  
  
-   <xref:System.Linq.Queryable.SingleOrDefault%2A>  
  
 `predicate` must be an expression in which the object's primary key property is set to a constant value. If an object has a primary key defined by more than one property, each primary key property must be set to a constant value. The following are examples of the form `predicate` must take:  
  
-   `c => c.PK == constant_value`  
  
-   `c => c.PK1 == constant_value1 && c=> c.PK2 == constant_value2`  
  
## Example  
 The following code provides examples of the types of LINQ to SQL queries that retrieve an object from the identity cache.  
  
 [!code-csharp[L2S_QueryCache#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/l2s_querycache/cs/program.cs#1)]
 [!code-vb[L2S_QueryCache#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/l2s_querycache/vb/module1.vb#1)]  
  
## See Also  
 [Query Concepts](../../../../../../docs/framework/data/adonet/sql/linq/query-concepts.md)  
 [Object Identity](../../../../../../docs/framework/data/adonet/sql/linq/object-identity.md)  
 [Background Information](../../../../../../docs/framework/data/adonet/sql/linq/background-information.md)  
 [Object Identity](../../../../../../docs/framework/data/adonet/sql/linq/object-identity.md)
