---
title: "Paging (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ba4f334d-03e5-4a7b-9d42-628f4639b9a2
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Paging (Entity SQL)
Physical paging can be performed by using the [SKIP](../../../../../../docs/framework/data/adonet/ef/language-reference/skip-entity-sql.md) and [LIMIT](../../../../../../docs/framework/data/adonet/ef/language-reference/limit-entity-sql.md) sub-clauses in the [ORDER BY](../../../../../../docs/framework/data/adonet/ef/language-reference/order-by-entity-sql.md) clause. To perform physical paging deterministically, you should use SKIP and LIMIT. If you only want to restrict the number of rows in the result in a non-determinsitic way, you should use [TOP](../../../../../../docs/framework/data/adonet/ef/language-reference/top-entity-sql.md). TOP and SKIP/LIMIT are mutually exclusive.  
  
## TOP Overview  
 The SELECT clause can have an optional TOP sub-clause following the optional ALL/DISTINCT modifier. The TOP sub-clause specifies that only the first set of rows will be returned from the query result. For more information, see [TOP](../../../../../../docs/framework/data/adonet/ef/language-reference/top-entity-sql.md).  
  
## SKIP And LIMIT Overview  
 SKIP and LIMIT are part of the ORDER BY clause. If a SKIP expression sub-clause is present in a ORDER BY clause, the results will be sorted according to the sort specification and the result set will include row(s) starting from the next row immediately after the SKIP expression. For example, SKIP 5 will skip the first five rows and return from the sixth row forward. If a LIMIT expression sub-clause is present in an ORDER BY clause, the query will be sorted according to the sort specification and the resulting number of rows will be restricted by the LIMIT expression. For instance, LIMIT 5 will restrict the result set to five instances or rows. SKIP and LIMIT do not have to be used together; you can use just SKIP or just LIMIT with ORDER BY clause. For more information, see the following topics:  
  
-   [SKIP](../../../../../../docs/framework/data/adonet/ef/language-reference/skip-entity-sql.md)  
  
-   [LIMIT](../../../../../../docs/framework/data/adonet/ef/language-reference/limit-entity-sql.md)  
  
-   [ORDER BY](../../../../../../docs/framework/data/adonet/ef/language-reference/order-by-entity-sql.md)  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)  
 [How to: Page Through Query Results](http://msdn.microsoft.com/library/ffc0f920-e7de-42e0-9b12-ef356421d030)
